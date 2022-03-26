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
            curve_color = Color.Red;
            ref_points_color = Color.Blue;
            points = new List<Vector2>();
        }
    }
}
