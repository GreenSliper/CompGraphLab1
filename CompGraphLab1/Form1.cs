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
				objData = loader.LoadFile(@"C:\Users\Igor\Desktop\cube.obj")
			};
		}

		private void Ticker_Tick(object sender, EventArgs e)
		{
			mesh.localRotation += Vector3.Up*5;
			Invalidate();
		}

		private void Form1_Paint(object sender, PaintEventArgs e)
		{
			var zb = zbb.BuildBuffer(new Vector2Int(600, 600), new List<MeshTransform>() { mesh }, cam);
			Bitmap img = new Bitmap(600, 600);
			for (int x = 0; x < zb.GetLength(0); x++)
				for (int y = 0; y < zb.GetLength(1); y++)
					img.SetPixel(x, y, Color.FromArgb((int)zb[x, y], (int)zb[x, y], (int)zb[x, y]));
			e.Graphics.DrawImage(null, 0, 0);
			/*var planar = meshProjector.Project(mesh.DataToWorldSpace(), cam);
			foreach (var tri in planar.tris)
			{
				e.Graphics.DrawLine(new Pen(Color.Black), (int)(tri.verts[0].x*600), (int)(tri.verts[0].y * 600), 
					(int)(tri.verts[1].x * 600), (int)(tri.verts[1].y * 600));
				e.Graphics.DrawLine(new Pen(Color.Black), (int)(tri.verts[2].x * 600), (int)(tri.verts[2].y * 600),
					(int)(tri.verts[1].x * 600), (int)(tri.verts[1].y * 600));
				e.Graphics.DrawLine(new Pen(Color.Black), (int)(tri.verts[2].x * 600), (int)(tri.verts[2].y * 600),
					(int)(tri.verts[0].x * 600), (int)(tri.verts[0].y * 600));
			}*/
		}
	}
}
