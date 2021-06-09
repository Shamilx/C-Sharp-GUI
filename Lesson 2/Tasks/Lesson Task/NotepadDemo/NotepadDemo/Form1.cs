using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace NotepadDemo
{
    public partial class Form1 : Form
    {
        private bool _fileOpened;
        private string openedFilePath;
        
        public Form1()
        {
            InitializeComponent();
        }
    
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_fileOpened)
            {
                using (StreamWriter writer = new StreamWriter(openedFilePath))
                {
                    writer.WriteLine(richTextBox1.Text);
                }
            }
            else
            {
                MessageBox.Show("Please first open file!");
            }
            _fileOpened = false;
            openedFilePath = null;
            richTextBox1.Text = "";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void newFIleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
 
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";

            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    myStream.Write(Encoding.UTF8.GetBytes(richTextBox1.Text),0,richTextBox1.Text.Length);
                    myStream.Close();
                }
            }
        }

        private void existingFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Text = File.ReadAllText(openFileDialog.FileName);
                openedFilePath = openFileDialog.FileName;
                _fileOpened = true;
            }
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Shamil");
        }
    }
}