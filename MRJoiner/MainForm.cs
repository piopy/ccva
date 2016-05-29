using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Compression;
using MRJoiner.utility;
using System.Runtime.InteropServices;


namespace MRJoiner
{
    public partial class MainForm : Form
    {
        string currentDir = "";

        //file 1
        string filetoover = "";

        //
        //files
         string[] filetozip;

        //
        //encryptionpart
         bool encryption = false;
        string outputS = "";
        string passwordEN = "";
        //
        //decrypt
        string outp="";
        string passD = "";
        string[] outpD;


        public MainForm()
        {
            InitializeComponent();
            
        }

        private void fileToOverride_Click(object sender, EventArgs e)
        {
            OpenFileDialog result = new OpenFileDialog();
            
            if (result.ShowDialog() == DialogResult.OK)
            {
                filetoover = result.FileName;
                textBox1.Text = "";
                textBox1.Text=filetoover;
                currentDir = Path.GetDirectoryName(filetoover);
                outputS = Path.GetDirectoryName(filetoover)+"\\Joined";
                outputtext.Text = outputS;
            }
        }

        private void filestozip_Click(object sender, EventArgs e)
        {
            OpenFileDialog result = new OpenFileDialog();
            result.Multiselect = true;

            if (result.ShowDialog() == DialogResult.OK)
            {
                filetozip = result.FileNames;
                textBox2.Text = "";
                foreach (string s in filetozip)
                {
                   
                    textBox2.AppendText("\"" + Path.GetFileName(s) + "\" ");
                }
            }
        }

        private void yesEnc_CheckedChanged(object sender, EventArgs e)
        {
            if (noEnc.Checked)
            {
                noEnc.Checked = false;
            }
            else yesEnc.Checked = true;
            encryption = true;
        }

        private void noEnc_CheckedChanged(object sender, EventArgs e)
        {
            if (yesEnc.Checked)
            {
                yesEnc.Checked = false;
            }
            else noEnc.Checked = true;

            pass.Enabled = true;
            encryption = false;
        }

        private void StartJ_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {

                try {
                    Directory.Delete(currentDir + "\\temp_zip", true);
                }
                catch (IOException ex) {
                    Console.WriteLine("Exception caught: {0}", ex);
                }

                try {
                    Directory.Delete(outputS, true);
                }
                catch (IOException ex) {
                    Console.WriteLine("Exception caught: {0}", ex);
                }

                //zip files
                try
                {
                    Directory.CreateDirectory(currentDir + "\\temp_zip");
                }
                catch (IOException ex)
                {
                    Console.WriteLine("Exception caught: {0}", ex);
                }
                string copiedFilesPath = currentDir + "\\temp_zip";

                foreach (string s in filetozip)
                {
                    try {
                        File.Copy(s, copiedFilesPath + "\\" + Path.GetFileName(s));
                    }
                    catch (IOException e2)
                    {
                        Console.WriteLine("Exception caught: {0}", e2);
                    }
                }

                ////encrypt?
                if (encryption)
                {
                    passwordEN = pass.Text;
                    if (passwordEN != "")
                    {
                        foreach (string s in Directory.GetFiles(copiedFilesPath))
                        {
                            AEScryptdecryptutil.EncryptFile(s, passwordEN);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Encryption Password Missing! Please retry!", "Missing Password!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    }


                }


                string zipfile = currentDir + "\\zipped.zip";
                try {
                    File.Delete(zipfile);
                }

                catch (Exception e3) {
                    Console.WriteLine("Exception caught: {0}", e3);
                }

                ZipFile.CreateFromDirectory(copiedFilesPath, zipfile);

                //join files
                Directory.CreateDirectory(outputS);
                cmd.runCommand("copy /b \"" + filetoover + "\"+" + "\"" + zipfile + "\" \"" + outputS + "\\" + Path.GetFileName(filetoover) + "\"");

                MessageBox.Show("File(s) joined!");

                //try { File.Delete(zipfile); } catch (Exception e3) { }
                //try { Directory.Delete(currentDir + "\\temp_zip", true); } catch (Exception ex) { }
            }
            else MessageBox.Show("Something is missed!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog result = new OpenFileDialog();
            result.Multiselect = true;
            if (result.ShowDialog() == DialogResult.OK)
            {
                passDEC.Enabled = true;
                
                outpD = result.FileNames;
                textBox6.Text = "";
                foreach(string s in outpD)
                {
                    textBox6.Text += "\""+Path.GetFileName(s)+"\" ";
                }
                
                currentDir = Path.GetDirectoryName(outpD[1]);
                string dec = currentDir + "\\Decrypted";
                outfile.Text = dec;
                
            }
        }

        private void StartD_Click(object sender, EventArgs e)
        {
            if (textBox6.Text != "")
            {
                bool control = false;
                passD = passDEC.Text;
                foreach (string s in outpD)
                {
                    try { control = AEScryptdecryptutil.DecryptFile(s, passD); }
                    catch (UnauthorizedAccessException e1)
                    {
                        control = false;
                        MessageBox.Show("Incorrect password");
                        if (Directory.Exists(Path.GetDirectoryName(s) + "\\Decrypted")) Directory.Delete(Path.GetDirectoryName(s) + "\\Decrypted", true);
                    }
                    if (control == false) break;
                }

                if (control==true) MessageBox.Show("File decrypted!");
            }
            else MessageBox.Show("Select a file first!");

            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/BurningHAM18");
        }
    }
}
