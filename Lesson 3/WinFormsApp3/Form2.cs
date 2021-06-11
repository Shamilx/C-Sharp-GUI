using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WinFormsApp3
{
    public partial class Form2 : Form
    {
        private List<Point> _points;
        
        public Form2(List<Point> points)
        {
            InitializeComponent();

            _points = FindFarPoints(points);
            this.Paint += OnPaint;
            
        }

        private List<Point> FindFarPoints(List<Point> points)
        {
            double maxDistance = 0;
            List<Point> farDistance = new List<Point>();
            
            for (int i = 0; i < points.Count; i++)
            {
                for (int j = 0; j < points.Count; j++)
                {
                    double distance = FindDistanceForPoints(points[i], points[j]);

                    if (distance > maxDistance)
                    {
                        maxDistance = distance;
                        farDistance.Clear();

                        farDistance.Add(points[i]);
                        farDistance.Add(points[j]);
                    }
                }
            }

            return farDistance;
        }

        private double FindDistanceForPoints(Point point, Point point1)
        {
            int X = point1.X - point.X;
            int Y = point1.Y - point.Y;

            int sum = Convert.ToInt32(Math.Pow(X, 2)) + Convert.ToInt32(Math.Pow(Y, 2));

            return Math.Sqrt(sum);
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            
            var x = e.Graphics;
            
            Pen penBlue = new Pen(Color.Blue, 10);
            Pen penRed = new Pen(Color.Red, 10);

            x.DrawLine(penBlue, 13, 220, 433, 220);
            x.DrawLine(penRed, 220, 9, 220, 429);
            
            Point[] myPoints = _points.ToArray();
            
            myPoints[0] = new Point(myPoints[0].X * 20,myPoints[0].Y * 20);
            myPoints[1] = new Point(myPoints[1].X * 20,myPoints[1].Y * 20);
            
            x.DrawLine(penRed,myPoints[0], myPoints[1]);
        }
    }
}