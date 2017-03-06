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
using System.Threading;
using System.Net;

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

        //robe a cazzo
        string filetobeopened="";
        string winrarPath = "";


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

                //join files e cazzo cancella i file temporanei
                Directory.CreateDirectory(outputS);
                cmd.runCommand("copy /b \"" + filetoover + "\"+" + "\"" + zipfile + "\" \"" + outputS + "\\" + Path.GetFileName(filetoover) + "\"");
                cmd.runCommand("rm" + " " + zipfile);
                cmd.runCommand("rmdir /s /q" + " " + copiedFilesPath);

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
                
                currentDir = Path.GetDirectoryName(outpD[0]);
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
            System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=H_DiH7wnsMo");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //checko se esiste winrar
            doesWinRarExist();

            if (Directory.Exists("C:\\Temp\\"))
            {
                // ok
            }
            else
            {
                try
            {
                    Directory.CreateDirectory("C:\\Temp\\");
                }
            catch (IOException ex)
                {
                    Console.WriteLine("Exception caught: {0}", ex);
                }
            }
            

            String[] argument = Environment.GetCommandLineArgs();
            try
            {
                if (argument[1] == null)
                {
                    // do nothing
                }
                else
                {
                    textBoxOpen.Text = argument[1];
                    tabControl.SelectedTab = decrypt;
                }
            }
            catch (Exception e8)
            {
                // iolo
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog result = new OpenFileDialog();

            if (result.ShowDialog() == DialogResult.OK)
            {
                filetobeopened = result.FileName;
                textBoxOpen.Text = "";
                textBoxOpen.Text = filetobeopened;
               
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //cmd.runCommand("\"C:\\Program Files\\WinRAR\\WinRar.exe\"" + " " + filetobeopened);
            
            //string copiedFilesPath = currentDir + "\\temp_zip";
            string toopen = "C:\\Temp\\Temp.zip";
            if (File.Exists(toopen))
            {
                try
                {
                    File.Delete(toopen);
                }
                catch (IOException temp_e)
                {
                    //ECCCCCCEZZZZIONI ROBBBEEE
                }
            }

            try
            {
                File.Copy(filetobeopened, toopen);
            }
            catch (IOException copy_exception)
            {
                // ALTRE ROBBE BRUTTISIME
            }
            //cmd.runCommand("copy /Y" + " " + filetobeopened + " " + toopen);
            //cmd.runCommand("move /Y" + " " + toopen + " " + "C:\\Windows\\Temp\\aaa.zip");
            cmd.runCommand(winrarPath + " " + toopen);

            MessageBox.Show("Hold on there tiger!\nWait for 9 seconds");
            Sub_Thread();
            //System.Threading.Thread.Sleep(9000);
            cmd.runCommand("rm" + " " + textBoxOpen.Text + ".zip");

            //System.Diagnostics.Process[] pname = System.Diagnostics.Process.GetProcessesByName("WinRar");
            //if (pname.Length == 0)
            //    MessageBox.Show("Hold on there tiger!");
            //else
            //    cmd.runCommand("rm" + " " + textBoxOpen.Text + ".zip");

        }

        private void Sub_Thread()
        {
            ThreadStart child = new ThreadStart(CallToChildThread);
        }

        public static void CallToChildThread()
        {
            Thread.Sleep(10000);
            File.Delete("C:\\Temp\\Temp.zip");
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

            // do nothing
            //cmd.runCommand("rm" + " " + "C:\\Temp\\Temp.zip");
            File.Delete("C:\\Temp\\Temp.zip");

        }

        private string doesWinRarExist()
        {
            if (File.Exists("C:\\Program Files\\WinRAR\\WinRar.exe")){
                winrarPath = "\"C:\\Program Files\\WinRAR\\WinRar.exe\"";
            }
            else if (File.Exists("C:\\Program Files (x86)\\WinRAR\\WinRar.exe"))
            {
                winrarPath = "\"C:\\Program Files (x86)\\WinRAR\\WinRar.exe\"";
            }
            else
            {
                MessageBox.Show("Seems you havent WinRar installed on your system, you can't use open options without it", "Cant find WinRar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                winrarPath = "";
                button1.Enabled = false;
                button3.Enabled = false;
            }
            return winrarPath;
        }

        private void joinFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = encrypt;
        }

        private void openFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = decrypt;
        }

        private void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] b_version_local = Encoding.UTF8.GetBytes(MRJoiner.Properties.Resources.version);
                WebClient client = new WebClient();
               client.DownloadFile("https://raw.githubusercontent.com/BurningHAM18/ccva/master/MRJoiner/version.txt", "wversion.txt");

                byte[] bytes = System.IO.File.ReadAllBytes("wversion.txt");


                if (b_version_local[0] == bytes[0]) MessageBox.Show("You have the last version, man");
                else
                {
                    MessageBox.Show("Found new version, go to my GitHub");
                    System.Diagnostics.Process.Start("https://github.com/BurningHAM18/ccva/releases");
                }
                File.Delete("wversion.txt");
            }
            catch (Exception e3)
            {
                MessageBox.Show("Error, enjoy this version, man");
            }

        }

        private void aboutDevelopersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Made by BurningHAM18 & cttynul\nGNUv3 License");
            System.Diagnostics.Process.Start("https://raw.githubusercontent.com/BurningHAM18/ccva/master/LICENSE");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=H_DiH7wnsMo");
        }
    }
}
