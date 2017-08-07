using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DecodeASPXAUTH
{
	public partial class frmMain : Form
	{
		private readonly CookieDecoder Decoder;

		public frmMain()
		{
			InitializeComponent();

			Decoder = new CookieDecoder();
			Decoder.Recalculated += Decoder_Recalculated;
		}

		private void Decoder_Recalculated( string decodedValue )
		{
			txtValue.Text = decodedValue;
		}

		private void inputField_TextChanged( object sender, EventArgs e )
		{
			Decoder.SetCookieValue( txtCookie.Text );
			Decoder.SetDecryptionKey( txtDecryptionKey.Text );
			Decoder.SetValidationKey( txtValidationKey.Text );
		}
	}
}
