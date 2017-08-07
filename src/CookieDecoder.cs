using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace DecodeASPXAUTH
{
	public delegate void RecalculateDelegate( string decodedValue );

	public class CookieDecoder
	{
		private string ValidationKey;
		private string DecryptionKey;
		private string CookieValue;

		public event RecalculateDelegate Recalculated;
		protected void OnRecalculate( string decodedValue )
		{
			if ( Recalculated != null )
				Recalculated( decodedValue );
		}

		public void SetValidationKey( string validationKey )
		{
			ValidationKey = validationKey;
			Recalculate();
		}
		public void SetCookieValue( string cookieVal )
		{
			CookieValue = cookieVal;
			Recalculate();
		}
		public void SetDecryptionKey( string decryptionKey )
		{
			DecryptionKey = decryptionKey;
			Recalculate();
		}


		public void Recalculate()
		{
			var decodedValue = "";

			if ( !String.IsNullOrEmpty( ValidationKey ) && !String.IsNullOrEmpty( CookieValue ) && !String.IsNullOrEmpty( DecryptionKey ) )
			{
				decodedValue = DecodeCookie();
			}

			OnRecalculate( decodedValue );
		}


		private string DecodeCookie()
		{
			var cookieBytes = SoapHexBinary.Parse( CookieValue ).Value;
			var validationKeyBytes = SoapHexBinary.Parse( ValidationKey ).Value;
			var decryptionKeyBytes = SoapHexBinary.Parse( DecryptionKey ).Value;

			int signatureLength = 0;

			using ( var validationAlgorithm = new HMACSHA1( validationKeyBytes ) )
			{
				signatureLength = validationAlgorithm.HashSize >> 3;
				if ( cookieBytes.Length - 1 < signatureLength )
					return "The cookie cannot be validated. Validation signature hash size does not align with cookie length.";

				var signature = validationAlgorithm.ComputeHash( cookieBytes, 0, cookieBytes.Length - signatureLength );
				for ( int signatureIndex = 0; signatureIndex < signature.Length; signatureIndex++ )
				{
					// If we break early, we'll be more vulnerable to timing attacks.
					if ( signature[signatureIndex] != cookieBytes[cookieBytes.Length - signatureLength + signatureIndex] )
						return "Cookie signature validation failed.";
				}
			}

			int initializationVectorLength;
			var decryptedBytes = DecryptBytes( cookieBytes, decryptionKeyBytes, signatureLength, out initializationVectorLength );

			if ( decryptedBytes.Length < 51 + initializationVectorLength )
				return "Decrypted value is insufficient in length.";

			return DecodeCookieBytes( decryptedBytes, initializationVectorLength );
		}
		private static string DecodeCookieBytes( byte[] decryptedBytes, int initializationVectorLength )
		{
			using ( var stream = new MemoryStream( decryptedBytes, 8 + initializationVectorLength, decryptedBytes.Length - 28 - initializationVectorLength, false ) )
			using ( var reader = new BinaryReader( stream, Encoding.Unicode ) )
			{
				if ( reader.ReadByte() != 0x01 )
					return "First byte should be 0x01";

				int version = (int)reader.ReadByte();
				var issueDate = new DateTime( reader.ReadInt64(), DateTimeKind.Utc );
				if ( reader.ReadByte() != 0xFE )
					return "Date field separator should be 0xFE";

				var expirationDate = new DateTime( reader.ReadInt64(), DateTimeKind.Utc );
				bool isPersistent = reader.ReadBoolean();

				string name = ReadFormsAuthenticationCookieValue( reader );
				string userData = ReadFormsAuthenticationCookieValue( reader );
				string path = ReadFormsAuthenticationCookieValue( reader );

				return "Cookie Data:" + Environment.NewLine +
						"==============================" + Environment.NewLine +
						$"Version: {version}" + Environment.NewLine +
						$"Name: {name}" + Environment.NewLine +
						$"Issue date: {issueDate}" + Environment.NewLine +
						$"Expiration date: {expirationDate}" + Environment.NewLine +
						$"Is persistent: {isPersistent}" + Environment.NewLine +
						$"User data: {userData}" + Environment.NewLine +
						$"Path: {path}";
			}
		}
		private static byte[] DecryptBytes( byte[] cookieBytes, byte[] decryptionKeyBytes, int signatureLength, out int initializationVectorLength )
		{
			using ( var decryptionAlgorithm = Rijndael.Create() )
			{
				initializationVectorLength = decryptionAlgorithm.IV.Length;
				decryptionAlgorithm.Key = decryptionKeyBytes;
				using ( var decryptor = decryptionAlgorithm.CreateDecryptor() )
					return decryptor.TransformFinalBlock( cookieBytes, 0, cookieBytes.Length - signatureLength );
			}
		}
		private static string ReadFormsAuthenticationCookieValue( BinaryReader reader )
		{
			int stringLength = 0;
			byte lengthByte;
			int iterations = 0;
			do
			{
				lengthByte = reader.ReadByte();
				stringLength |= (lengthByte & 0x7F) << (iterations * 7);
				iterations++;
			} while ( (lengthByte & (byte)0x80) != 0 );

			return new string( reader.ReadChars( stringLength ) );
		}
	}
}
