using CompGraphLab1.Data;
using CompGraphLab1.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            drawer.curves = new List<BezierCurve>(){
                new BezierCurve()
                {
                    ref_points_color = Color.Blue,
                    curve_color = Color.Red,
                    points = {
                        new Vector2(9 + 50, 827 - 200),
                        new Vector2(9 + 150, 827 - 100),
                        new Vector2(9 + 250, 827 - 250),
                        new Vector2(9 + 200, 827 - 50),
                    }
                },
                new BezierCurve()
                {
                    is_points_visable = false,
                    //ref_points_color = Color.Blue,
                    curve_color = Color.Red,
                    points = new List<Vector2> {
                        new Vector2(9 + 150, 827 - 50),
                        new Vector2(9 + 50, 827 - 100),
                        new Vector2(9 + 50, 827 - 700),
                        new Vector2(9 + 550, 827 - 700),
                        new Vector2(9 + 550, 827 - 100),
                        new Vector2(9 + 450, 827 - 50)
                    }
                },
                new BezierCurve()
                {
                    is_points_visable = false,
                    curve_color = Color.Red,
                    points = new List<Vector2> {
                        new Vector2(9 + 150, 827 - 50),
                        new Vector2(9 + 240, 827 - 20),
                        new Vector2(9 + 200, 827 - 100),
                        new Vector2(9 + 300, 827 - 300),
                        new Vector2(9 + 400, 827 - 100),
                        new Vector2(9 + 360, 827 - 20),
                        new Vector2(9 + 450, 827 - 50)
                    }
                },
                new BezierCurve()
                {
                    is_points_visable = false,
                    curve_color = Color.DeepSkyBlue,
                    points = new List<Vector2> {
                        new Vector2(9 + 200, 827 - 320),
                        new Vector2(9 + 200, 827 - 390),
                        new Vector2(9 + 400, 827 - 390),
                        new Vector2(9 + 400, 827 - 320)
                    }
                },
                new BezierCurve()
                {
                    is_points_visable = false,
                    curve_color = Color.DeepSkyBlue,
                    points = new List<Vector2> {
                        new Vector2(9 + 200, 827 - 320),
                        new Vector2(9 + 200, 827 - 250),
                        new Vector2(9 + 400, 827 - 250),
                        new Vector2(9 + 400, 827 - 320)
                    }
                }

            };
            for (int i = 1; i < drawer.curves.Count + 1; i++)
            {
                listBox1.Items.Insert(i-1, "Кривая " + i);
            }
            pictureBox1.Image = drawer.Draw();
        }
           
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(drawer.curves[listBox1.SelectedIndex].curve_color, drawer.curves[listBox1.SelectedIndex].ref_points_color, drawer.curves[listBox1.SelectedIndex].points, listBox1.SelectedIndex);
            form3.ShowDialog();
            drawer.curves[listBox1.SelectedIndex].curve_color = form3.curve_color;
            drawer.curves[listBox1.SelectedIndex].ref_points_color = form3.ref_points_color;
            pictureBox1.Image = drawer.Draw();
        }
    }
}
