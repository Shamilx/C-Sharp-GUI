using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp3
{
    enum FunctionType
    {
        XETTI,
        KVADRATIK
    }
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text;

            FunctionType functionType = FindOutFunctionType(text);

            if (functionType == FunctionType.XETTI)
            {
                DrawXettiFunction(text);
            }
            else
            {
                DrawKvadratikFunksiya(text);
            }
        }

        private void DrawKvadratikFunksiya(string text)
        {
            
        }

        private void DrawXettiFunction(string text)
        {
            string problem;
            int? x = null;

            if (!text.Contains("x"))
            {
                MessageBox.Show("Please provide correct function!");
                return;
            }
            
            List<Point> points = new List<Point>();
            
            for (int i = -10; i <= 10; i++)
            {
                problem = text.Replace("x", i.ToString());

                if (problem.Contains("y="))
                {
                    problem = problem.Remove(0, 2);
                }

                x = SolveProblem(problem);
                
                if (x.HasValue)
                {
                    points.Add(new Point(i,x.Value));
                }
                else
                {
                    break;
                }
            }

            if (x.HasValue)
            {
                // Form2 form2 = new Form2(points);
                // form2.ShowDialog();
            }
        }

        private int? SolveProblem(string problem)
        {
            try
            {
                DataTable dt = new DataTable();
                var v = dt.Compute(problem, "");
                return (int) v;
            }
            catch (Exception)
            {
                MessageBox.Show("Please provide correct function!");
            }

            return null;
        }

        private FunctionType FindOutFunctionType(string text)
        {
            if (text.Contains("^"))
            {
                return FunctionType.KVADRATIK;
            }
            
            return FunctionType.XETTI;
        }
    }
}