using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASiiMO_BatchCompiler
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openbatfile = new OpenFileDialog();
            openbatfile.FileName = "";
            openbatfile.Filter = "Batch file (*.bat)|*.bat";

            

            //DialogResult result_bat = openFileDialog1.ShowDialog();
            if(openbatfile.ShowDialog() == DialogResult.OK)
            {
                if(Path.GetExtension(openbatfile.FileName) != ".bat")
                {
                    MessageBox.Show("Thats not a batch file!");
                } else
                {
                    label1.Text = openbatfile.FileName;

                    //Getting the BAT file information
                    string batname = Path.GetFileNameWithoutExtension(openbatfile.FileName);
                    long batlength = new System.IO.FileInfo(openbatfile.FileName).Length;

                    //Setting the information labels to visible
                    label5.Visible = true;
                    label7.Visible = true;

                    //Changing labels to the BAT file information
                    label5.Text = batname;
                    label7.Text = (batlength.ToString() + " bytes");

                    button6.Enabled = true;

                }

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = "yourbatchfile.exe";
            savefile.Filter = "Executables (*.exe)|*.exe";

            if (savefile.ShowDialog() == DialogResult.OK)

            {
                string pathtoexe = savefile.FileName;
                textBox1.Text = pathtoexe;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.Filter = "Icons (*.ico)|*.ico|All files (*.*)|*.*";
            
            if (openfile.ShowDialog() == DialogResult.OK)
            {
                string pathtoico = openfile.FileName;
                textBox2.Text = pathtoico;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if ((label1.Text != string.Empty) && (textBox1.Text != string.Empty))
            {
                string b2eargs =
                "/bat " + "\"" + label1.Text + "\"" +
                " /exe " + "\"" + textBox1.Text + "\"" +
                (checkBox1.Checked ? " /x64" : null) +
                (checkBox2.Checked ? " /invisible" : null) +
                (checkBox3.Checked ? " /uac-admin" : null) +
                (checkBox4.Checked ? " /uac-user" : null) +
                (checkBox5.Checked ? " /upx" : null) +
                (checkBox2.Checked ? " /invisible" : null) +
                (checkBox6.Checked ? " /icon " + "\"" + textBox2.Text + "\"" : null);

                // /bat [filename] || /exe [filename] || /invisible /x64 /uac-admin /uac-user /upx ||

                Console.WriteLine("b2e.exe" + " " + b2eargs);
                System.Diagnostics.Process.Start("b2e.exe", " " + b2eargs);
                Thread.Sleep(3000);
                MessageBox.Show("Done!");

                label11.Visible = true;
                label9.Visible = true;
                button4.Visible = true;

                string exename = Path.GetFileNameWithoutExtension(textBox1.Text);
                long exelength = new System.IO.FileInfo(textBox1.Text).Length;

                label11.Text = exename;
                label9.Text = (exelength.ToString() + " bytes");
            } else{
                MessageBox.Show("Please add a .bat file and choose the output file.");
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(textBox1.Text);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/asimo1/bat2executable");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
        }
    }
}
