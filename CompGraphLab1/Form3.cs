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
        List<Vector2> points;
        public Color curve_color;
        public Color ref_points_color;
        public Form3(Color curve_color, Color ref_points_color, List<Vector2> points, int number)
        {
            this.curve_color = curve_color;
            this.ref_points_color = ref_points_color;
            this.points = points;
            InitializeComponent();
            label1.Text = "Текущий цвет: ";
            label2.Text = this.curve_color.ToString();
            {
                listBox1.Items.Insert(0, Color.Red);
                listBox1.Items.Insert(1, Color.Green);
                listBox1.Items.Insert(2, Color.Blue);
                listBox1.Items.Insert(3, Color.Orange);
            }
            label3.Text = "Цвет кривой";
            label4.Text = "Цвет точек кривой";
            label5.Text = label1.Text;
            label6.Text = this.ref_points_color.ToString();
            label7.Text = "Координаты точек кривой";
            label8.Text = "Изменение точек кривой";
            button1.Text = "Изменить точку";
            button2.Text = "Применить изменения";
            label9.Text = "Кривая " + (number + 1);
            {
                listBox2.Items.Insert(0, Color.Red);
                listBox2.Items.Insert(1, Color.Green);
                listBox2.Items.Insert(2, Color.Blue);
                listBox2.Items.Insert(3, Color.Orange);
            }
            for (int i = 1; i < points.Count + 1; i++)
            {
                listBox3.Items.Insert(i - 1, "Точка " + i + ": " + points[i - 1].x + ";" + points[i - 1].y);
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void label7_Click(object sender, EventArgs e) { }
        private void label8_Click(object sender, EventArgs e) { }
        private void label9_Click(object sender, EventArgs e) { }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == 0)
                this.curve_color = Color.Red;
            if (listBox1.SelectedIndex == 1)
                this.curve_color = Color.Green;
            if (listBox1.SelectedIndex == 2)
                this.curve_color = Color.Blue;
            if (listBox1.SelectedIndex == 3)
                this.curve_color = Color.Orange;
            label2.Text = this.curve_color.ToString();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex == 0)
                this.ref_points_color = Color.Red;
            if (listBox2.SelectedIndex == 1)
                this.ref_points_color = Color.Green;
            if (listBox2.SelectedIndex == 2)
                this.ref_points_color = Color.Blue;
            if (listBox2.SelectedIndex == 3)
                this.ref_points_color = Color.Orange;
            label6.Text = this.ref_points_color.ToString();
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox3.SelectedIndex > 0)
            {
                textBox1.Text = points[listBox3.SelectedIndex].x + ";" + points[listBox3.SelectedIndex].y;
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
            return vec;
        }
        private void textBox1_TextChanged(object sender, EventArgs e) {}

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox3.SelectedIndex > 0)
            {
                int temp = listBox3.SelectedIndex;
                points[temp] = getPoint(textBox1.Text);
                listBox3.Items.RemoveAt(listBox3.SelectedIndex);
                listBox3.Items.Insert(temp, "Точка " + (temp + 1) + ": " + points[temp].x + ";" + points[temp].y);
                textBox1.ResetText();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
