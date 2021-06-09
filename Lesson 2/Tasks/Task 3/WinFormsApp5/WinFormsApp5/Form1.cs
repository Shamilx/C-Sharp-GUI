using System;
using System.IO;
using System.Windows.Forms;

// Create an editor based on the RichTextBox and add the ability
// to select from a directory and view the file content by dragging and
// dropping the file to the editor field.

namespace WinFormsApp5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            richTextBox1.AllowDrop = true;
            richTextBox1.DragDrop += richTextBox1_DragDrop;
        }

        void richTextBox1_DragDrop(object sender, DragEventArgs e)
        {
            object filename = e.Data.GetData("FileDrop");
            if (filename != null)
            {
                var list = filename as string[];

                if (list != null && !string.IsNullOrWhiteSpace(list[0]))
                {
                    richTextBox1.Clear();
                    richTextBox1.LoadFile(list[0], RichTextBoxStreamType.PlainText);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(openFileDialog.FileName))
                {
                    richTextBox1.Clear();
                    string[] lines = File.ReadAllLines(openFileDialog.FileName);

                    foreach (var i in lines)
                    {
                        richTextBox1.AppendText(i);
                    }
                }
            }
        }
    }
}