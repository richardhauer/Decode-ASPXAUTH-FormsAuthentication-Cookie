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
	public partial class MainForm : Form
	{
		private readonly CookieDecoder Decoder;

		public MainForm()
		{
			InitializeComponent();

			Decoder = new CookieDecoder();
			Decoder.Recalculated += Decoder_Recalculated;

			LoadFromSettings();
		}

		private void LoadFromSettings()
		{
			txtDecryptionKey.Text = Properties.Settings.Default.DecryptionKey;
			txtValidationKey.Text = Properties.Settings.Default.ValidationKey;
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

		private void frmMain_FormClosing( object sender, FormClosingEventArgs e )
		{
			Properties.Settings.Default.DecryptionKey = txtDecryptionKey.Text;
			Properties.Settings.Default.ValidationKey = txtValidationKey.Text;
			Properties.Settings.Default.Save();
		}
	}
}
