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
		Renderer zbb = new Renderer();
		IObjLoader loader = new ObjLoader();
		MeshTransform mesh, mesh1;
		public Form1()
		{
			InitializeComponent();
			cam = new Camera() { localPosition = Vector3.Zero, horizontalAngle = 60, verticalAngle = 60, renderPlaneDistance = 1f};
			mesh = new MeshTransform()
			{
				localPosition = Vector3.Forward * 5,
				localScale = Vector3.One,
				localRotation = Vector3.Up*30,
				objData = loader.LoadFile(@"C:\Users\Igor\Desktop\amogus.obj"),
				baseColor = new Vector3(1, 0, 0)
			};
			mesh1 = new MeshTransform()
			{
				localPosition = Vector3.Forward * 5,
				localScale = Vector3.One,
				localRotation = Vector3.Up * 30,
				objData = loader.LoadFile(@"C:\Users\Igor\Desktop\amogus_visor.obj"),
				baseColor = new Vector3(0, 0, 1)
			};
		}

		private void Ticker_Tick(object sender, EventArgs e)
		{
			//mesh.localRotation += Vector3.Up*15f;
			//Invalidate();
		}
		
		private Color Lerp(Color c1, Color c2, float t)
		{
			return Color.FromArgb(c1.R + (int)MathF.Round((c2.R - c1.R) * t), 
				c1.G + (int)MathF.Round((c2.G - c1.G) * t), 
				c1.B + (int)MathF.Round((c2.B - c1.B) * t));
		}

		DirectionalLight light = new DirectionalLight() { localRotation = new Vector3(-60, 180, 0) };
		Bitmap img = new Bitmap(600, 600);
		private void Form1_Paint(object sender, PaintEventArgs e)
		{
			var render = new Color[600, 600];
			var zb = zbb.RenderZBufferFillPoly(new Vector2Int(600, 600), new List<MeshTransform>() { mesh, mesh1 }, cam, 
				(msh, tri)=>SimpleLightShader.GetTriangleColor(msh, tri, light), render);
			for (int x = 0; x < zb.GetLength(0); x++)
				for (int y = 0; y < zb.GetLength(1); y++)
				{
					if (zb[x, y] != float.MaxValue)
					{
						float t = MathF.Pow(zb[x, y], 4) / 1000;
						zb[x, y] = MathF.Min(255, 512 / zb[x, y]);
						int z = (int)MathF.Round(zb[x, y]);
						img.SetPixel(x, y, Lerp(render[x, y], Color.FromArgb(z/2, z/4, z), t));
					}
					else
						img.SetPixel(x, y, Color.Black);
				}
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
