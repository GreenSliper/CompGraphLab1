using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CompGraphLab1.Utility;

namespace CompGraphLab1
{
    public partial class Form3 : Form
    {
        public BezierCurve curve;
        private Vector2 center_in_pixels;
        public Form3(BezierCurve curve, int number)
        {
            this.curve = curve;
            center_in_pixels = new Vector2(9, 827);
            InitializeComponent();
            label2.Text = curve.curve_color.ToString();
            {
                listBox1.Items.Insert(0, Color.Red);
                listBox1.Items.Insert(1, Color.Green);
                listBox1.Items.Insert(2, Color.Blue);
                listBox1.Items.Insert(3, Color.Orange);
            }
            label6.Text = curve.ref_points_color.ToString();
            label9.Text = "Кривая " + (number + 1);
            {
                listBox2.Items.Insert(0, Color.Red);
                listBox2.Items.Insert(1, Color.Green);
                listBox2.Items.Insert(2, Color.Blue);
                listBox2.Items.Insert(3, Color.Orange);
            }
            visiableChangeButton.Text = (curve.is_points_visable) ? "Сделать невидимыми" : "Сделать видимыми";
            for (int i = 1; i < curve.points.Count + 1; i++)
            {
                Vector2 _point = PixelToReal(curve.points[i - 1]);
                listBox3.Items.Insert(i - 1, "Точка " + i + ": " + _point.x + ";" + _point.y);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == 0)
                curve.curve_color = Color.Red;
            if (listBox1.SelectedIndex == 1)
                curve.curve_color = Color.Green;
            if (listBox1.SelectedIndex == 2)
                curve.curve_color = Color.Blue;
            if (listBox1.SelectedIndex == 3)
                curve.curve_color = Color.Orange;
            label2.Text = curve.curve_color.ToString();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex == 0)
                curve.ref_points_color = Color.Red;
            if (listBox2.SelectedIndex == 1)
                curve.ref_points_color = Color.Green;
            if (listBox2.SelectedIndex == 2)
                curve.ref_points_color = Color.Blue;
            if (listBox2.SelectedIndex == 3)
                curve.ref_points_color = Color.Orange;
            label6.Text = curve.ref_points_color.ToString();
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox3.SelectedIndex >= 0)
            {
                Vector2 _point = PixelToReal(curve.points[listBox3.SelectedIndex]);
                textBox1.Text = _point.x + ";" + _point.y;
            }
        }

        public Vector2 getPoint(String str)
        {
            Vector2 vec;
            int i = 0;
            String firstPart = "";
            String secondPart = "";
            char[] temp = str.ToCharArray();
            for(; temp[i] != ';';i++)
            {
                firstPart = firstPart + temp[i].ToString();
            }
            i++;
            for(; i < temp.Length; i++)
            {
                secondPart = secondPart + temp[i].ToString();
            }
            vec.x = Int32.Parse(firstPart);
            vec.y = Int32.Parse(secondPart);
            if (vec.x > 400 || vec.x < 0 || vec.y > 400 || vec.y < 0)
                throw new ArgumentOutOfRangeException();
            return RealToPixel(vec); ;
        }

        public Vector2 RealToPixel(Vector2 point)
        {
            return new Vector2(
                center_in_pixels.x + 2 * point.x,
                center_in_pixels.y - 2 * point.y);
        }

        public Vector2 PixelToReal(Vector2 point)
        {
            return new Vector2(
                (point.x - center_in_pixels.x) / 2,
                (center_in_pixels.y - point.y) / 2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox3.SelectedIndex >= 0)
            {
                try
                {
                    int temp = listBox3.SelectedIndex;
                    curve.points[temp] = getPoint(textBox1.Text);
                    Vector2 _point = PixelToReal(curve.points[temp]);
                    listBox3.Items.RemoveAt(listBox3.SelectedIndex);
                    listBox3.Items.Insert(temp, "Точка " + (temp + 1) + ": " + _point.x + ";" + _point.y);
                    textBox1.ResetText();
                }
                catch (Exception)
                {
                    MessageBox.Show(@"You have entered incorrect data", @"Error");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            curve.points.Add(new Vector2(center_in_pixels.x, center_in_pixels.y));
            listBox3.Items.Insert(curve.points.Count - 1, "Точка " + curve.points.Count + ": " + 0 + ";" + 0);
            listBox3.SetSelected(curve.points.Count - 1, true);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox3.SelectedIndex >= 0)
            {
                int pos = listBox3.SelectedIndex;
                listBox3.Items.RemoveAt(pos);
                curve.points.RemoveAt(pos);
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            curve.is_points_visable = !curve.is_points_visable;
            visiableChangeButton.Text = (curve.is_points_visable) ? "Сделать невидимыми" : "Сделать видимыми";
        }
    }
}
