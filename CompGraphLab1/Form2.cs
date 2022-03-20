using CompGraphLab1.Data;
using CompGraphLab1.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CompGraphLab1
{
    public partial class Form2 : Form
    {
        BezierCurveDrawer drawer;
        public Form2()
        {
            InitializeComponent();
            drawer = new BezierCurveDrawer();
            drawer.curves = new List<BezierCurve>();
            pictureBox1.Image = drawer.Draw();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rndm = new Random();
            listBox1.Items.Insert(drawer.curves.Count, "Кривая " + (drawer.curves.Count + 1));
            drawer.curves.Add(new BezierCurve(){
                points = new List<Vector2> {
                    new Vector2(9 + rndm.Next(201) * 2, 827 - rndm.Next(201) * 2),
                    new Vector2(9 + rndm.Next(201) * 2, 827 - rndm.Next(201) * 2)
                }
            });
            pictureBox1.Image = drawer.Draw();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                DeleteCurve(listBox1.SelectedIndex);
                pictureBox1.Image = drawer.Draw();
            }
        }

        private void DeleteCurve(int index)
        {
            drawer.curves.RemoveAt(index);
            listBox1.Items.RemoveAt(index);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                Form3 form3 = new Form3(drawer.curves[listBox1.SelectedIndex], listBox1.SelectedIndex);
                form3.ShowDialog();
                if (drawer.curves[listBox1.SelectedIndex].points.Count() == 0)
                    DeleteCurve(listBox1.SelectedIndex);
                pictureBox1.Image = drawer.Draw();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            for (int i = drawer.curves.Count; i < drawer.curves.Count + 4; ++i)
                listBox1.Items.Insert(i, "Кривая " + (i + 1));
            drawer.curves.Add(
                new BezierCurve()
                {
                    is_points_visable = false,
                    points = new List<Vector2> {
                        new Vector2(9 + 150, 827 - 50),
                        new Vector2(9 + 50, 827 - 100),
                        new Vector2(9 + 50, 827 - 700),
                        new Vector2(9 + 550, 827 - 700),
                        new Vector2(9 + 550, 827 - 100),
                        new Vector2(9 + 450, 827 - 50)
                    }
                });
            drawer.curves.Add(
                new BezierCurve()
                {
                    is_points_visable = false,
                    points = new List<Vector2> {
                        new Vector2(9 + 150, 827 - 50),
                        new Vector2(9 + 240, 827 - 20),
                        new Vector2(9 + 200, 827 - 100),
                        new Vector2(9 + 300, 827 - 300),
                        new Vector2(9 + 400, 827 - 100),
                        new Vector2(9 + 360, 827 - 20),
                        new Vector2(9 + 450, 827 - 50)
                    }
                });
            drawer.curves.Add(
               new BezierCurve()
               {
                   is_points_visable = false,
                   curve_color = Color.Blue,
                   points = new List<Vector2> {
                        new Vector2(9 + 200, 827 - 320),
                        new Vector2(9 + 200, 827 - 390),
                        new Vector2(9 + 400, 827 - 390),
                        new Vector2(9 + 400, 827 - 320)
                    }
               });
            drawer.curves.Add(
                new BezierCurve()
                {
                    is_points_visable = false,
                    curve_color = Color.Blue,
                    points = new List<Vector2> {
                        new Vector2(9 + 200, 827 - 320),
                        new Vector2(9 + 200, 827 - 250),
                        new Vector2(9 + 400, 827 - 250),
                        new Vector2(9 + 400, 827 - 320)
                    }
                });
            pictureBox1.Image = drawer.Draw();
        }
    }
}
