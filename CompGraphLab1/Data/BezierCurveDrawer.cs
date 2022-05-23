using CompGraphLab1.Utility;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CompGraphLab1.Data
{
    class BezierCurveDrawer
    {
        public List<BezierCurve> curves;
        private Bitmap orig_img;

        public BezierCurveDrawer()
        {
            curves = new List<BezierCurve>();
            orig_img = new Bitmap(@"..\..\..\Sources\axies.bmp");
        }

        public Bitmap Draw()
        {
            Bitmap img = new Bitmap(orig_img);
            foreach (var curve in curves)
            {
                /*if (curve.is_points_visable)
                    for (int i = 0; i < curve.points.Count(); ++i)
                        HighlightPoint(img, curve.points[i], curve.ref_points_color);*/
                for (float change = 0; change <= 1; change += 0.0001f)
                {
                    List<Vector2> new_points = curve.points;
                    while (new_points.Count() > 1)
                        new_points = GetNextListOfPoints(new_points, change);
                    SetPoint(img, new_points[0], curve.curve_color);
                }
            }
            return img;
        }

        public Bitmap DrawLines()
        {
            Bitmap img = new Bitmap(orig_img);
            foreach (var curve in curves)
            {
                float x2 = curve.points.Last().x;
                float x1 = curve.points.First().x;
                float y2 = curve.points.Last().y;
                float y1 = curve.points.First().y;

                bool steep = MathF.Abs(y2 - y1) > MathF.Abs(x2 - x1);
                if (steep)
                {
                    Swap(ref x1, ref y1);
                    Swap(ref x2, ref y2);
                }

                if (x1 > x2)
                {
                    Swap(ref x1, ref x2);
                    Swap(ref y1, ref y2);
                }

                float dx = x2 - x1;
                float dy = MathF.Abs(y2 - y1);

                float error = dx / 2.0f;
                int ystep = (y1 < y2) ? 1 : -1;
                int y = (int)y1;

                int maxX = (int)x2;

                for (int x = (int)x1; x <= maxX; x++)
                {
                    if (steep)
                    {
                        SetPoint(img, new Vector2(y, x), curve.curve_color);
                    }
                    else
                    {
                        SetPoint(img, new Vector2(x, y), curve.curve_color);
                    }

                    error -= dy;
                    if (error < 0)
                    {
                        y += ystep;
                        error += dx;
                    }
                }
            }
            return img;
        }

        private static List<Vector2> GetNextListOfPoints(List<Vector2> points, float change)
        {
            List<Vector2> new_points = new List<Vector2>();
            for (int i = 0; i < points.Count() - 1; ++i)
                new_points.Add(GetNextPoin(points[i], points[i + 1], change));
            return new_points;
        }

        private static Vector2 GetNextPoin(Vector2 point1, Vector2 point2, float change)
        {
            return new Vector2(
                (1 - change) * point1.x + point2.x * change,
                (1 - change) * point1.y + point2.y * change);
        }

        private void SetPoint(Bitmap img, Vector2 point, Color color)
        {
            Vector2 point1 = FixPoint(new Vector2(point.x + 1, point.y));
            Vector2 point2 = FixPoint(new Vector2(point.x, point.y - 1));
            Vector2 point3 = FixPoint(new Vector2(point.x + 1, point.y - 1));
            img.SetPixel((int)point.x, (int)point.y, color);
            img.SetPixel((int)point1.x, (int)point1.y, color);
            img.SetPixel((int)point2.x, (int)point2.y, color);
            img.SetPixel((int)point3.x, (int)point3.y, color);
        }

        private void HighlightPoint(Bitmap img, Vector2 point, Color color)
        {
            for (int i = -1; i <= 1; ++i)
                for (int j = 2; j <= 3; ++j)
                {
                    SetPoint(img, FixPoint(new Vector2(point.x + i, point.y + j)), color);
                    SetPoint(img, FixPoint(new Vector2(point.x + i, point.y - j)), color);
                    SetPoint(img, FixPoint(new Vector2(point.x + j, point.y + i)), color);
                    SetPoint(img, FixPoint(new Vector2(point.x - j, point.y + i)), color);
                }
            SetPoint(img, FixPoint(new Vector2(point.x + 2, point.y + 2)), color);
            SetPoint(img, FixPoint(new Vector2(point.x + 2, point.y - 2)), color);
            SetPoint(img, FixPoint(new Vector2(point.x - 2, point.y + 2)), color);
            SetPoint(img, FixPoint(new Vector2(point.x - 2, point.y - 2)), color);
        }

        private Vector2 FixPoint(Vector2 point)
        {
            return new Vector2(
                Math.Max(Math.Min(orig_img.Width, point.x), 0),
                Math.Max(Math.Min(orig_img.Height, point.y), 0));
        }

        static void Swap<T>(ref T lhs, ref T rhs)
        {
            T temp;
            temp = lhs;
            lhs = rhs;
            rhs = temp;
        }
    }
}
