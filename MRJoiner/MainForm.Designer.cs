namespace MRJoiner
{
    partial class MainForm
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.fileToOverride = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.filestozip = new System.Windows.Forms.Button();
            this.outputtext = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.decryptbox = new System.Windows.Forms.GroupBox();
            this.StartD = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.passDEC = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.outfile = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pass = new System.Windows.Forms.TextBox();
            this.yesEnc = new System.Windows.Forms.CheckBox();
            this.noEnc = new System.Windows.Forms.CheckBox();
            this.StartJ = new System.Windows.Forms.Button();
            this.decryptbox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileToOverride
            // 
            this.fileToOverride.Location = new System.Drawing.Point(418, 27);
            this.fileToOverride.Name = "fileToOverride";
            this.fileToOverride.Size = new System.Drawing.Size(33, 23);
            this.fileToOverride.TabIndex = 0;
            this.fileToOverride.Text = "...";
            this.fileToOverride.UseVisualStyleBackColor = true;
            this.fileToOverride.Click += new System.EventHandler(this.fileToOverride_Click);
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(9, 28);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(403, 20);
            this.textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(9, 82);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(403, 20);
            this.textBox2.TabIndex = 3;
            // 
            // filestozip
            // 
            this.filestozip.Location = new System.Drawing.Point(418, 81);
            this.filestozip.Name = "filestozip";
            this.filestozip.Size = new System.Drawing.Size(33, 23);
            this.filestozip.TabIndex = 2;
            this.filestozip.Text = "...";
            this.filestozip.UseVisualStyleBackColor = true;
            this.filestozip.Click += new System.EventHandler(this.filestozip_Click);
            // 
            // outputtext
            // 
            this.outputtext.Enabled = false;
            this.outputtext.Location = new System.Drawing.Point(9, 201);
            this.outputtext.Name = "outputtext";
            this.outputtext.Size = new System.Drawing.Size(353, 20);
            this.outputtext.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Select the future container file...";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(240, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Select the file(s) that will be joined to the first file...";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Output file...";
            // 
            // decryptbox
            // 
            this.decryptbox.Controls.Add(this.StartD);
            this.decryptbox.Controls.Add(this.label7);
            this.decryptbox.Controls.Add(this.label6);
            this.decryptbox.Controls.Add(this.passDEC);
            this.decryptbox.Controls.Add(this.textBox6);
            this.decryptbox.Controls.Add(this.label3);
            this.decryptbox.Controls.Add(this.button2);
            this.decryptbox.Controls.Add(this.outfile);
            this.decryptbox.Location = new System.Drawing.Point(8, 227);
            this.decryptbox.Name = "decryptbox";
            this.decryptbox.Size = new System.Drawing.Size(453, 135);
            this.decryptbox.TabIndex = 14;
            this.decryptbox.TabStop = false;
            this.decryptbox.Text = "Decrypt";
            // 
            // StartD
            // 
            this.StartD.Location = new System.Drawing.Point(372, 100);
            this.StartD.Name = "StartD";
            this.StartD.Size = new System.Drawing.Size(75, 23);
            this.StartD.TabIndex = 20;
            this.StartD.Text = "Start";
            this.StartD.UseVisualStyleBackColor = true;
            this.StartD.Click += new System.EventHandler(this.StartD_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Password";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(127, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Select the container file...";
            // 
            // passDEC
            // 
            this.passDEC.Enabled = false;
            this.passDEC.Location = new System.Drawing.Point(62, 64);
            this.passDEC.Name = "passDEC";
            this.passDEC.Size = new System.Drawing.Size(381, 20);
            this.passDEC.TabIndex = 18;
            this.passDEC.UseSystemPasswordChar = true;
            // 
            // textBox6
            // 
            this.textBox6.Enabled = false;
            this.textBox6.Location = new System.Drawing.Point(4, 35);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(403, 20);
            this.textBox6.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Output file...";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(413, 34);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(33, 23);
            this.button2.TabIndex = 16;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // outfile
            // 
            this.outfile.Enabled = false;
            this.outfile.Location = new System.Drawing.Point(4, 103);
            this.outfile.Name = "outfile";
            this.outfile.Size = new System.Drawing.Size(350, 20);
            this.outfile.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.pass);
            this.groupBox1.Controls.Add(this.yesEnc);
            this.groupBox1.Controls.Add(this.noEnc);
            this.groupBox1.Location = new System.Drawing.Point(8, 110);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(453, 72);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Encrypt";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(116, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Password";
            // 
            // pass
            // 
            this.pass.Enabled = false;
            this.pass.Location = new System.Drawing.Point(175, 38);
            this.pass.Name = "pass";
            this.pass.Size = new System.Drawing.Size(272, 20);
            this.pass.TabIndex = 16;
            this.pass.UseSystemPasswordChar = true;
            // 
            // yesEnc
            // 
            this.yesEnc.AutoSize = true;
            this.yesEnc.Location = new System.Drawing.Point(6, 41);
            this.yesEnc.Name = "yesEnc";
            this.yesEnc.Size = new System.Drawing.Size(47, 17);
            this.yesEnc.TabIndex = 15;
            this.yesEnc.Text = "AES";
            this.yesEnc.UseVisualStyleBackColor = true;
            this.yesEnc.CheckedChanged += new System.EventHandler(this.yesEnc_CheckedChanged);
            // 
            // noEnc
            // 
            this.noEnc.AutoSize = true;
            this.noEnc.Checked = true;
            this.noEnc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.noEnc.Location = new System.Drawing.Point(6, 18);
            this.noEnc.Name = "noEnc";
            this.noEnc.Size = new System.Drawing.Size(52, 17);
            this.noEnc.TabIndex = 14;
            this.noEnc.Text = "None";
            this.noEnc.UseVisualStyleBackColor = true;
            this.noEnc.CheckedChanged += new System.EventHandler(this.noEnc_CheckedChanged);
            // 
            // StartJ
            // 
            this.StartJ.Location = new System.Drawing.Point(380, 199);
            this.StartJ.Name = "StartJ";
            this.StartJ.Size = new System.Drawing.Size(75, 23);
            this.StartJ.TabIndex = 16;
            this.StartJ.Text = "Start";
            this.StartJ.UseVisualStyleBackColor = true;
            this.StartJ.Click += new System.EventHandler(this.StartJ_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 370);
            this.Controls.Add(this.StartJ);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.decryptbox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.outputtext);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.filestozip);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.fileToOverride);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(484, 409);
            this.MinimumSize = new System.Drawing.Size(484, 409);
            this.Name = "MainForm";
            this.Text = "TYRELLIOT Joiner";
            this.decryptbox.ResumeLayout(false);
            this.decryptbox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button fileToOverride;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button filestozip;
        private System.Windows.Forms.TextBox outputtext;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox decryptbox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox pass;
        private System.Windows.Forms.CheckBox yesEnc;
        private System.Windows.Forms.CheckBox noEnc;
        private System.Windows.Forms.Button StartD;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox passDEC;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox outfile;
        private System.Windows.Forms.Button StartJ;
    }
}

