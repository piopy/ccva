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
/*
PRIMA PARTE VA DA VEDERE CRYPT E DECRYPT
*/
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
                // 

                //cartella dove verra salvato il file ultimato
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
            try {  Directory.Delete(currentDir + "\\temp_zip",true);  } catch (Exception ex) { }
            try { Directory.Delete(outputS,true); } catch (Exception ex) { }
            
            //zip files
            Directory.CreateDirectory(currentDir + "\\temp_zip");
            string copiedFilesPath = currentDir + "\\temp_zip";
            
            foreach (string s in filetozip)
            {
                try { File.Copy(s, copiedFilesPath + "\\" + Path.GetFileName(s)); }
                catch (IOException e2) { }
            }
            string zipfile = currentDir + "\\zipped.zip";
            try { File.Delete(zipfile); } catch (Exception e3) { }
            ZipFile.CreateFromDirectory(copiedFilesPath,zipfile);
            
            
            //encrypt?
            if (encryption)
            {
                passwordEN = pass.Text;
                //byte[] converted = AEScryptdecryptutil.encrypt(passwordEN , zipfile);
                //try { File.Delete(zipfile); } catch (Exception e3) { }
                //File.WriteAllBytes(zipfile, converted);
                AEScryptdecryptutil.EncryptFile(zipfile, passwordEN);
                //MessageBox.Show("sono qui");
            }

            //join files
            Directory.CreateDirectory(outputS);
            cmd.runCommand("copy /b \""+filetoover+"\"+"+"\""+zipfile+"\" \""+outputS+"\\"+Path.GetFileName(filetoover)+"\"");
            
            try { File.Delete(zipfile); } catch (Exception e3) { }
            try { Directory.Delete(currentDir + "\\temp_zip", true); } catch (Exception ex) { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog result = new OpenFileDialog();

            if (result.ShowDialog() == DialogResult.OK)
            {
                passDEC.Enabled = true;
                
                outp = result.FileName;
                textBox6.Text = "";
                textBox6.Text = outp;
                currentDir = Path.GetDirectoryName(outp);
                string dec = Path.GetDirectoryName(outp) + "\\TYRELLIOT";
                outfile.Text = dec;
                passD = passDEC.Text;

                
            }
        }

        private void StartD_Click(object sender, EventArgs e)
        {
            //byte[] converted = AEScryptdecryptutil.decrypt(passD, outp);
            //Directory.CreateDirectory(currentDir + "\\TYRELLIOT");
            //File.WriteAllBytes(currentDir + "\\TYRELLIOT" + "\\zippedfileswithprevious.extension", converted);
            AEScryptdecryptutil.DecryptFile(outp, passD);
        }

        
    }
}
