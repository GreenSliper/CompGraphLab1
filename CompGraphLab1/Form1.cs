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
		IMeshProjector meshProjector = new MeshProjector();
		MeshTransform mesh;
		public Form1()
		{
			InitializeComponent();
			cam = new Camera() { localPosition = Vector3.Zero, horizontalAngle = 60, verticalAngle = 60, renderPlaneDistance = 1f};
			mesh = new MeshTransform()
			{
				localPosition = Vector3.Forward * 3,
				localScale = Vector3.One,
				objData = new Data.ObjData()
				{
					tris = new List<Data.Triangle3D>()
					{
						new Data.Triangle3D(new Vector3(0, 0, 0), new Vector3(1, 0, 0), new Vector3(1, 1, 0))
					}
				}
			};
		}

		private void Ticker_Tick(object sender, EventArgs e)
		{
			mesh.localRotation += Vector3.Up*10;
			Invalidate();
		}

		private void Form1_Paint(object sender, PaintEventArgs e)
		{
			var planar = meshProjector.Project(mesh.DataToWorldSpace(), cam);
			foreach (var tri in planar.tris)
			{
				e.Graphics.DrawLine(new Pen(Color.Black), (int)(tri.verts[0].x*600), (int)(tri.verts[0].y * 600), 
					(int)(tri.verts[1].x * 600), (int)(tri.verts[1].y * 600));
				e.Graphics.DrawLine(new Pen(Color.Black), (int)(tri.verts[2].x * 600), (int)(tri.verts[2].y * 600),
					(int)(tri.verts[1].x * 600), (int)(tri.verts[1].y * 600));
				e.Graphics.DrawLine(new Pen(Color.Black), (int)(tri.verts[2].x * 600), (int)(tri.verts[2].y * 600),
					(int)(tri.verts[0].x * 600), (int)(tri.verts[0].y * 600));
			}
		}
	}
}
