using System.Windows.Forms;
using System;
using System.IO;
using System.Threading;

// Create an application based on the TreeView for viewing a file
// directory with subfolders.


namespace WinFormsApp4
{
    public partial class Form1 : Form
    {
        private DirectoryInfo SumbitedDirectoryInfo;
        
        public Form1()
        {
            InitializeComponent();

            button2.Enabled = false;
            
        }
        
        private void BuildTree(DirectoryInfo directoryInfo, TreeNodeCollection addInMe)
        {
            TreeNode curNode = addInMe.Add(directoryInfo.Name);

            foreach (FileInfo file in directoryInfo.GetFiles())
            {
                curNode.Nodes.Add(file.FullName, file.Name);
            }
            foreach (DirectoryInfo subdir in directoryInfo.GetDirectories())
            {
                BuildTree(subdir, curNode.Nodes);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(textBox1.Text);

            if (directoryInfo.Exists)
            {
                SumbitedDirectoryInfo = directoryInfo;
                button2.Enabled = true;
            }
            else
            {
                button2.Enabled = false;
            }
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            BuildTree(SumbitedDirectoryInfo, treeView1.Nodes);
            
            button2.Enabled = false;
            button4.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            button4.Enabled = false;
        }
    }
}