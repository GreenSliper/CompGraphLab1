using CompGraphLab1.Rendering;
using CompGraphLab1.Scene;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace CompGraphLab1.Data
{
    public class BezierSurfaceData
    {
        public Vector3[] controlPoints = new Vector3[16];
        public int gridResolution = 16;
        public IRasterizer rasterizer
        {
            get
            {
                if (isPatchRasterizer)
                    return new PatchRasterizer();
                return new AltRasterizer();
            }
        }
        public MeshTransform mesh = new MeshTransform()
        {
            localPosition = Vector3.Forward * 5 + Vector3.Up * 2,
            localScale = Vector3.One,
            localRotation = Vector3.Zero,
            baseColor = new Vector3(1, 0.6471f, 0),
            triangleShader = (mesh, tlg, light) => Color.White
        };
        public bool isPatchRasterizer = true;
        public bool isDiffuseColor = false;
    }
}
