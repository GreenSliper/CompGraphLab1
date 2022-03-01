using CompGraphLab1.Load;
using CompGraphLab1.Rendering;
using CompGraphLab1.Scene;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompGraphLab1
{
	public partial class Form1 : Form
	{
		Camera cam;
		//IMeshProjector meshProjector = new MeshProjector();
		ZBufferBuilder zbb = new ZBufferBuilder();
		IObjLoader loader = new ObjLoader();
		MeshTransform mesh;
		public Form1()
		{
			InitializeComponent();
			cam = new Camera() { localPosition = Vector3.Zero, horizontalAngle = 60, verticalAngle = 60, renderPlaneDistance = 1f};
			mesh = new MeshTransform()
			{
				localPosition = Vector3.Forward * 5,
				localScale = Vector3.One,
				localRotation = Vector3.Up * 45f,
				objData = loader.LoadFile(@"C:\Users\Igor\Desktop\cube.obj")
			};
		}

		private void Ticker_Tick(object sender, EventArgs e)
		{
			mesh.localRotation += Vector3.Up*15f;
			Invalidate();
		}

		private void Form1_Paint(object sender, PaintEventArgs e)
		{
			Bitmap img = new Bitmap(600, 600);
			var zb = zbb.BuildBuffer(new Vector2Int(600, 600), new List<MeshTransform>() { mesh }, cam);
			for (int x = 0; x < zb.GetLength(0); x++)
				for (int y = 0; y < zb.GetLength(1); y++)
				{
					zb[x, y] = MathF.Min(255, 512/zb[x, y]);
					img.SetPixel(x, y, Color.FromArgb((int)zb[x, y], (int)zb[x, y], (int)zb[x, y]));
				}

			/*Rasterizer rst = new Rasterizer();
			var tri = rst.RasterTriangle(new Data.Triangle2D(new Vector2(0, 0), new Vector2(1, 1), new Vector2(0.6f, 0.4f), 0, 0, 0), 600, 600);
			var zb = new float[600, 600];
			for (int x = 0; x < zb.GetLength(0); x++)
				for (int y = 0; y < zb.GetLength(1); y++)
				{
					if (tri.bitMask[x, y])
						zb[x, y] = 255;
					img.SetPixel(x, y, Color.FromArgb((int)zb[x, y], (int)zb[x, y], (int)zb[x, y]));
				}*/
			/*
			var rstrzr = new AltRasterizer();
			foreach (var tri in planar.tris)
			{
				var raster = rstrzr.RasterTriangle(tri, 600, 600);
				for (int x = 0; x < raster.bitMask.GetLength(0); x++)
					for (int y = 0; y < raster.bitMask.GetLength(1); y++)
					{
						if (raster.bitMask[x, y])
							img.SetPixel(x + raster.x, y + raster.y, Color.Black);
					}
			}*/
			e.Graphics.DrawImage(img, 0, 0);
			/*
			var planar = new MeshProjector().Project(mesh.DataToWorldSpace(), cam);
			foreach (var tri in planar.tris)
			{
				e.Graphics.DrawLine(new Pen(Color.Blue), (int)(tri.verts[0].x*600), (int)(tri.verts[0].y * 600), 
					(int)(tri.verts[1].x * 600), (int)(tri.verts[1].y * 600));
				e.Graphics.DrawLine(new Pen(Color.Blue), (int)(tri.verts[2].x * 600), (int)(tri.verts[2].y * 600),
					(int)(tri.verts[1].x * 600), (int)(tri.verts[1].y * 600));
				e.Graphics.DrawLine(new Pen(Color.Blue), (int)(tri.verts[2].x * 600), (int)(tri.verts[2].y * 600),
					(int)(tri.verts[0].x * 600), (int)(tri.verts[0].y * 600));
			}*/
		}
	}
}
