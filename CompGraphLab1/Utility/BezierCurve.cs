using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace CompGraphLab1.Utility
{
    public class BezierCurve
    {
        public bool is_points_visable;
        public Color curve_color;
        public Color ref_points_color;
        public List<Vector2> points;

        public BezierCurve()
        {
            Random rndm = new Random();
            is_points_visable = true;
            curve_color = Color.FromArgb(rndm.Next(256), rndm.Next(256), rndm.Next(256));
            ref_points_color = Color.FromArgb(rndm.Next(256), rndm.Next(256), rndm.Next(256));
            points = new List<Vector2>();
        }
    }
}
