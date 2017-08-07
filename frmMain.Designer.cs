namespace DecodeASPXAUTH
{
	partial class frmMain
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose( bool disposing )
		{
			if ( disposing && (components != null) )
			{
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.txtValidationKey = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtCookie = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtValue = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtDecryptionKey = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// txtValidationKey
			// 
			this.txtValidationKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtValidationKey.Location = new System.Drawing.Point(12, 29);
			this.txtValidationKey.Name = "txtValidationKey";
			this.txtValidationKey.Size = new System.Drawing.Size(732, 20);
			this.txtValidationKey.TabIndex = 0;
			this.txtValidationKey.TextChanged += new System.EventHandler(this.inputField_TextChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(74, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Validation Key";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 116);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(70, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Cookie Value";
			// 
			// txtCookie
			// 
			this.txtCookie.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCookie.Location = new System.Drawing.Point(12, 132);
			this.txtCookie.Multiline = true;
			this.txtCookie.Name = "txtCookie";
			this.txtCookie.Size = new System.Drawing.Size(733, 82);
			this.txtCookie.TabIndex = 3;
			this.txtCookie.TextChanged += new System.EventHandler(this.inputField_TextChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 231);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(34, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Value";
			// 
			// txtValue
			// 
			this.txtValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtValue.Location = new System.Drawing.Point(12, 247);
			this.txtValue.Multiline = true;
			this.txtValue.Name = "txtValue";
			this.txtValue.ReadOnly = true;
			this.txtValue.Size = new System.Drawing.Size(733, 192);
			this.txtValue.TabIndex = 5;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(13, 64);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(79, 13);
			this.label4.TabIndex = 7;
			this.label4.Text = "Decryption Key";
			// 
			// txtDecryptionKey
			// 
			this.txtDecryptionKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDecryptionKey.Location = new System.Drawing.Point(12, 80);
			this.txtDecryptionKey.Name = "txtDecryptionKey";
			this.txtDecryptionKey.Size = new System.Drawing.Size(732, 20);
			this.txtDecryptionKey.TabIndex = 6;
			this.txtDecryptionKey.TextChanged += new System.EventHandler(this.inputField_TextChanged);
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(757, 451);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtDecryptionKey);
			this.Controls.Add(this.txtValue);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtCookie);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtValidationKey);
			this.MinimumSize = new System.Drawing.Size(388, 385);
			this.Name = "frmMain";
			this.Text = "Decode ASPXAUTH Cookie";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtValidationKey;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtCookie;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtValue;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtDecryptionKey;
	}
}

