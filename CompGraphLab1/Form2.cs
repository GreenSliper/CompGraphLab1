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
        BezierCurveDrawer drawerForCurves;
        List<BezierCurveDrawer> drawerForRectangle;
        List<int> intersectingLinesIndexes;
        private int counterCurve;
        private int counterRectangle;
        private bool reset = false;
        private int lastSelectedRectangleIndex;
        public Form2()
        {
            InitializeComponent();
            counterCurve = 0;
            counterRectangle = 0;
            lastSelectedRectangleIndex = 0;
            drawer = new BezierCurveDrawer();
            drawer.curves = new List<BezierCurve>();
            drawerForCurves = new BezierCurveDrawer();
            drawerForCurves.curves = new List<BezierCurve>();
            drawerForRectangle = new List<BezierCurveDrawer>();
            intersectingLinesIndexes = new List<int>();
            Draw();
        }

        public void Draw()
        {
            pictureBox1.Image = drawer.DrawLines();
        }
        public void DrawCurve()
        {
            drawer.curves.Add(drawerForCurves.curves[counterCurve]);
            pictureBox1.Image = drawer.DrawLines();
        }
        public void DrawRectangle()
        {
            drawer.curves.Add(drawerForRectangle[counterRectangle].curves[0]);
            drawer.curves.Add(drawerForRectangle[counterRectangle].curves[1]);
            drawer.curves.Add(drawerForRectangle[counterRectangle].curves[2]);
            drawer.curves.Add(drawerForRectangle[counterRectangle].curves[3]);
            pictureBox1.Image = drawer.DrawLines();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex >= 0)
            {
                resetDrawer();
                foreach (var line in drawerForRectangle[listBox2.SelectedIndex].curves)
                    line.curve_color = Color.Maroon;
                Draw();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(reset)
            {
                resetDrawer();
            }
            Random rndm = new Random();
            listBox1.Items.Insert(drawerForCurves.curves.Count, "Отрезок " + (counterCurve));
            drawerForCurves.curves.Add(new BezierCurve(){
                points = new List<Vector2> {
                    new Vector2(9 + rndm.Next(402) * 2, 827 - rndm.Next(402) * 2),
                    new Vector2(9 + rndm.Next(402) * 2, 827 - rndm.Next(402) * 2)
                },
                curve_color = Color.Blue
            });
            DrawCurve();
            counterCurve++;
        }   

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                DeleteCurve(listBox1.SelectedIndex);
                Draw();
            }
        }
        private void DeleteCurve(int index)
        {
            if (reset)
            {
                resetDrawer();
            }
            BezierCurve curveCheck = drawerForCurves.curves[index];
            drawer.curves.Remove(curveCheck);
            drawerForCurves.curves.Remove(curveCheck);
            listBox1.Items.RemoveAt(index);
            counterCurve--;
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex >= 0)
            {
                DeleteRectangle(listBox2.SelectedIndex);
                Draw();
            }
        }

        private void DeleteRectangle(int index)
        {
            lastSelectedRectangleIndex = -1;
            if (reset)
            {
                resetDrawer();
            }
            BezierCurve curveCheck_1 = drawerForRectangle[index].curves[0];
            BezierCurve curveCheck_2 = drawerForRectangle[index].curves[1];
            BezierCurve curveCheck_3 = drawerForRectangle[index].curves[2];
            BezierCurve curveCheck_4 = drawerForRectangle[index].curves[3];
            drawer.curves.Remove(curveCheck_1);
            drawer.curves.Remove(curveCheck_2);
            drawer.curves.Remove(curveCheck_3);
            drawer.curves.Remove(curveCheck_4);
            drawerForRectangle.Remove(drawerForRectangle[index]);
            listBox2.Items.RemoveAt(index);
            counterRectangle--;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                Form3 form3 = new Form3(drawerForCurves.curves[listBox1.SelectedIndex], listBox1.SelectedIndex, this);
                form3.ShowDialog();
                if (drawerForCurves.curves[listBox1.SelectedIndex].points.Count() == 0)
                    DeleteCurve(listBox1.SelectedIndex);
                pictureBox1.Image = drawerForCurves.DrawLines();
            }
        }

        private void resetDrawer()
        {
            if (lastSelectedRectangleIndex >= 0)
                foreach (var line in drawerForRectangle[lastSelectedRectangleIndex].curves)
                    line.curve_color = Color.Red;

            foreach (var index in intersectingLinesIndexes)
                drawerForCurves.curves[index].curve_color = Color.Blue;
            intersectingLinesIndexes.Clear();

            lastSelectedRectangleIndex = listBox2.SelectedIndex;
            //for(int i = 0; i < drawer.curves.Count; i++)
            //{
            //    drawer.curves[i].curve_color = Color.Red;
            //}
            reset = false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            for (int i = drawerForCurves.curves.Count; i < drawerForCurves.curves.Count + 4; ++i)
                listBox1.Items.Insert(i, "Отрезок " + (++counterCurve));
            drawerForCurves.curves.Add(
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
            drawerForCurves.curves.Add(
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
            drawerForCurves.curves.Add(
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
            drawerForCurves.curves.Add(
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
            DrawCurve();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            if (reset)
            {
                resetDrawer();
            }
            Random rndm = new Random();
            listBox2.Items.Insert(counterRectangle, "Прямоугольник " + (counterRectangle));
            long rectangleFirxt_x = 9 + rndm.Next(402) * 2;
            long rectangleFirxt_y = 827 - rndm.Next(402) * 2;
            long rectangleSecond_x=0;
            long rectangleSecond_y=0;
            while (rectangleSecond_x < 9 || rectangleSecond_x >= 854 ||  Math.Abs(rectangleSecond_x  - rectangleFirxt_x) < 10)
            {
                rndm = new Random();
                rectangleSecond_x = rectangleFirxt_x - rndm.Next(402);
            }
            while (rectangleSecond_y <= 0 || rectangleSecond_y > 827 || Math.Abs(rectangleSecond_y - rectangleFirxt_y) < 10)
            {
                rndm = new Random();
                rectangleSecond_y = rectangleFirxt_y - rndm.Next(402);
            }
            drawerForRectangle.Add(new BezierCurveDrawer()
            {
                curves = new List<BezierCurve>() {
                    new BezierCurve()
                    {
                        points = new List<Vector2> {
                            new Vector2(rectangleFirxt_x, rectangleFirxt_y),
                            new Vector2(rectangleSecond_x, rectangleFirxt_y)
                        },
                    },
                    new BezierCurve()
                    {
                        points = new List<Vector2> {
                            new Vector2(rectangleFirxt_x, rectangleSecond_y),
                            new Vector2(rectangleSecond_x, rectangleSecond_y)
                        }
                    },
                    new BezierCurve()
                    {
                        points = new List<Vector2> {
                            new Vector2(rectangleFirxt_x, rectangleFirxt_y),
                            new Vector2(rectangleFirxt_x, rectangleSecond_y)
                        }
                    },
                    new BezierCurve()
                    {
                        points = new List<Vector2> {
                            new Vector2(rectangleSecond_x, rectangleFirxt_y),
                            new Vector2(rectangleSecond_x, rectangleSecond_y)
                        }
                    }
                }
            });
            DrawRectangle();
            counterRectangle++;
            }

        private void button3_Click_1(object sender, EventArgs e)
        {
            foreach (var line in drawerForCurves.curves)
                line.curve_color = Color.Blue;

            if (listBox2.SelectedIndex >= 0)
            {
                for(int i = 0; i < drawerForCurves.curves.Count; i++)   
                {
                    
                    if ((drawerForRectangle[listBox2.SelectedIndex].curves[2].points[1].x > drawerForCurves.curves[i].points[0].x &&
                           drawerForRectangle[listBox2.SelectedIndex].curves[2].points[1].x > drawerForCurves.curves[i].points[1].x &&
                           drawerForRectangle[listBox2.SelectedIndex].curves[3].points[1].x < drawerForCurves.curves[i].points[0].x &&
                           drawerForRectangle[listBox2.SelectedIndex].curves[3].points[1].x < drawerForCurves.curves[i].points[1].x) &&
                           (drawerForRectangle[listBox2.SelectedIndex].curves[2].points[1].y < drawerForCurves.curves[i].points[0].y &&
                           drawerForRectangle[listBox2.SelectedIndex].curves[2].points[1].y < drawerForCurves.curves[i].points[1].y &&
                           drawerForRectangle[listBox2.SelectedIndex].curves[2].points[0].y > drawerForCurves.curves[i].points[0].y &&
                           drawerForRectangle[listBox2.SelectedIndex].curves[2].points[0].y > drawerForCurves.curves[i].points[1].y))
                    {
                        drawerForCurves.curves[i].curve_color = Color.Green;
                        intersectingLinesIndexes.Add(i);
                    }
                    else
                    {
                        LineDrawing line = new LineDrawing(new PointF(drawerForCurves.curves[i].points[0].x, drawerForCurves.curves[i].points[0].y),
                        new PointF(drawerForCurves.curves[i].points[1].x, drawerForCurves.curves[i].points[1].y));
                        if (!line.IsIntersectionRectangle(new RectangleF(drawerForRectangle[listBox2.SelectedIndex].curves[3].points[1].x,
                            drawerForRectangle[listBox2.SelectedIndex].curves[3].points[1].y,
                            Math.Abs(drawerForRectangle[listBox2.SelectedIndex].curves[0].points[0].x - drawerForRectangle[listBox2.SelectedIndex].curves[0].points[1].x),
                            Math.Abs(drawerForRectangle[listBox2.SelectedIndex].curves[3].points[0].y - drawerForRectangle[listBox2.SelectedIndex].curves[3].points[1].y)
                            )))
                        {
                            drawerForCurves.curves[i].curve_color = Color.LightSteelBlue;
                            intersectingLinesIndexes.Add(i);
                        }
                        if ((drawerForRectangle[listBox2.SelectedIndex].curves[2].points[1].x < drawerForCurves.curves[i].points[0].x &&
                               drawerForRectangle[listBox2.SelectedIndex].curves[2].points[1].x < drawerForCurves.curves[i].points[1].x ||
                               drawerForRectangle[listBox2.SelectedIndex].curves[3].points[1].x > drawerForCurves.curves[i].points[0].x &&
                               drawerForRectangle[listBox2.SelectedIndex].curves[3].points[1].x > drawerForCurves.curves[i].points[1].x) ||
                               (drawerForRectangle[listBox2.SelectedIndex].curves[2].points[1].y > drawerForCurves.curves[i].points[0].y &&
                               drawerForRectangle[listBox2.SelectedIndex].curves[2].points[1].y > drawerForCurves.curves[i].points[1].y ||
                               drawerForRectangle[listBox2.SelectedIndex].curves[2].points[0].y < drawerForCurves.curves[i].points[0].y &&
                               drawerForRectangle[listBox2.SelectedIndex].curves[2].points[0].y < drawerForCurves.curves[i].points[1].y))
                        {
                            drawerForCurves.curves[i].curve_color = Color.LightSteelBlue;
                            intersectingLinesIndexes.Add(i);
                        }
                        if(drawerForCurves.curves[i].curve_color == Color.Red)
                        {
                            drawerForCurves.curves[i].curve_color = Color.Blue;
                        }
                    }
                }
                drawer.curves.Clear();
                for(int i = 0; i < drawerForCurves.curves.Count; i++)
                {
                    drawer.curves.Add(drawerForCurves.curves[i]);
                }
                for (int i = 0; i < drawerForRectangle.Count; i++)
                {
                    for (int j = 0; j < drawerForRectangle[i].curves.Count; j++)
                    {
                        drawer.curves.Add(drawerForRectangle[i].curves[j]);
                    }
                }
                reset = true;
                Draw();
            }
        }
        class LineDrawing
        {
            public double A { get; private set; }
            /// <summary>Коэфициент B уравнения Ax+By+C=0</summary>
            public double B { get; private set; }
            /// <summary>Коэфициент C уравнения Ax+By+C=0</summary>
            public double C { get; private set; }
            /// <summary>Допустимая погрешность сравнения</summary>
            public double Eps { get; set; }
            /// <summary>Конструтор по двум точкам</summary>
            /// <param name="point1">Точка</param>
            /// <param name="point2">Точка</param>
            /// <param name="eps">Допустимая погрешность сравнения</param>
            public LineDrawing(PointF point1, PointF point2, double eps = 1e-3)
            {
                Eps = eps;
                double ProjectionX = point2.X - point1.X;
                double ProjectionY = point2.Y - point1.Y;
                if (Math.Abs(ProjectionX) <= Eps && Math.Abs(ProjectionY) <= Eps)
                    throw new ArgumentException("Точки совпадают");
                if (ProjectionX == 0)
                {
                    A = 1;
                    B = 0;
                    C = -point1.X;
                }
                else if (ProjectionY == 0)
                {
                    A = 0;
                    B = 1;
                    C = -point1.Y;
                }
                else
                {
                    A = ProjectionY;
                    B = -ProjectionX;
                    C = point1.Y * ProjectionX - point1.X * ProjectionY;
                }

            }

            /// <summary>Получение X по заданному Y</summary>
            /// <param name="y">Значение Y</param>
            /// <returns>Nan в случае если прямая вертикальна</returns>
            public double GetX(double y)
            {
                if (A == 0)
                    return double.NaN;
                return -(B * y + C) / A;
            }
            /// <summary>Получение Y по заданному X</summary>
            /// <param name="x">Значение X</param>
            /// <returns>Nan в случае если прямая горизонтальна</returns>
            public double GetY(double x)
            {
                if (B == 0)
                    return double.NaN;
                return -(A * x + C) / B;
            }

            /// <summary>Проверяет наличие пересечения с прямоугольником </summary>
            /// <param name="rectangle">Прямоугольник RectangleF</param>
            /// <returns><see langword="true"/> - если есть пересечение</returns>
            public bool IsIntersectionRectangle(RectangleF rectangle)
            {
                PointF pointLeftTop;
                PointF pointRightBottom;
                if (Math.Abs(A) <= Math.Abs(B))
                {
                    pointLeftTop = new PointF(rectangle.Left, (float)GetY(rectangle.Left));
                    pointRightBottom = new PointF(rectangle.Right, (float)GetY(rectangle.Right));
                }
                else
                {
                    pointLeftTop = new PointF((float)GetX(rectangle.Top), rectangle.Top);
                    pointRightBottom = new PointF((float)GetX(rectangle.Bottom), rectangle.Bottom);
                }

                float left = Math.Min(pointLeftTop.X, pointRightBottom.X);
                float top = Math.Min(pointLeftTop.Y, pointRightBottom.Y);
                float width = Math.Max(pointLeftTop.X, pointRightBottom.X) - left;
                float height = Math.Max(pointLeftTop.Y, pointRightBottom.Y) - top;

                RectangleF rectIntersect = new RectangleF(left, top, width, height);
                rectIntersect.Intersect(rectangle);
                return !rectIntersect.IsEmpty;
            }
            public override string ToString() => $"LineDrawing = {{ A = {A}, B = {B}, C = {C}}}";
        }
    }
}
