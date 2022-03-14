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
                    points = new List<Vector2> {
                        new Vector2(9 + 50, 827 - 200),
                        new Vector2(9 + 150, 827 - 100),
                        new Vector2(9 + 250, 827 - 250),
                        new Vector2(9 + 200, 827 - 50),
                    }
                },
                /*new BezierCurve()
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
                }*/

            };
            pictureBox1.Image = drawer.Draw();
        }
    }
}
