using CompGraphLab1.Load;
using CompGraphLab1.Rendering;
using CompGraphLab1.Scene;
using CompGraphLab1.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompGraphLab1
{
	public partial class Form1 : Form
	{
		System.Media.SoundPlayer player = new System.Media.SoundPlayer();
		Camera cam;
		Renderer zbb = new Renderer();
		IObjLoader loader = new ObjLoader();
		List<MeshTransform> meshes = new List<MeshTransform>();
		MeshTransform[] axises;
		BezierSurfaceData bezierSurfaceData;
		bool bezierSurfaceMode;

		public Form1()
		{
			InitializeComponent();
			this.KeyPreview = true;
			player.SoundLocation = @"..\..\..\Sources\sus.wav";
			//player.PlayLooping();
			cam = new Camera()
			{
				localPosition = Vector3.Right*0,
				localRotation = Vector3.Up*0,
				horizontalAngle = 60,
				verticalAngle = 60,
				renderPlaneDistance = .1f
			};
			axises = new MeshTransform[3]
				{
					//x
					new MeshTransform()
					{
						localPosition = Vector3.Forward * 5 + Vector3.Up*2,
						localScale = Vector3.One,
						localRotation = Vector3.Forward * 90,
						triangleShader = Shaders.UnlitColor,
						objData = loader.LoadFile(@"..\..\..\Sources\axis.obj"),
						baseColor = new Vector3(1, 0, 0)
					},
					//y
					new MeshTransform()
					{
						localPosition = Vector3.Forward * 5 + Vector3.Up*2,
						localScale = Vector3.One,
						localRotation = Vector3.Right*180,
						triangleShader = Shaders.UnlitColor,
						objData = loader.LoadFile(@"..\..\..\Sources\axis.obj"),
						baseColor = new Vector3(0, 1, 0)
					},
					//z
					new MeshTransform()
					{
						localPosition = Vector3.Forward * 5 + Vector3.Up*2,
						localScale = Vector3.One,
						localRotation = Vector3.Right*270,
						triangleShader = Shaders.UnlitColor,
						objData = loader.LoadFile(@"..\..\..\Sources\axis.obj"),
						baseColor = new Vector3(0, 0, 1)
					}
				};
			bezierSurfaceMode = false;
			bezierSurfaceData = new BezierSurfaceData();
			Random rand = new Random();
			for (int i = 0; i < 16; ++i)
				bezierSurfaceData.controlPoints[i] =
					new Vector3(rand.Next(-30, 30) / 10f, rand.Next(-10, 30) / 10f, rand.Next(-15, 25) / 10f);
			BezierSurfaceObjCreator.Create(bezierSurfaceData);

			CreateImage();
		}

		private Color Lerp(Color c1, Color c2, float t)
		{
			return Color.FromArgb(c1.R + (int)MathF.Round((c2.R - c1.R) * t),
				c1.G + (int)MathF.Round((c2.G - c1.G) * t),
				c1.B + (int)MathF.Round((c2.B - c1.B) * t));
		}

		int xSz = 1000, ySz = 1000;

		private void button1_Click(object sender, EventArgs e)
		{
			string[] AngleRotationStr = new string[] {
				OXAngleRotationTextBox.Text,
				OYAngleRotationTextBox.Text,
				OZAngleRotationTextBox.Text
			};
			try
			{
				int[] AngleRotation = new int[AngleRotationStr.GetLength(0)];
				for (int i = 0; i < AngleRotation.GetLength(0); ++i)
				{
					AngleRotation[i] = int.Parse(AngleRotationStr[i]);
					if (Math.Abs(AngleRotation[i]) > 180)
						throw new ArgumentOutOfRangeException();
				}
				Vector3 eulerAngles = new Vector3(AngleRotation[0], AngleRotation[1], AngleRotation[2]);
				if (!bezierSurfaceMode)
					foreach (var _mesh in meshes)
						_mesh.localRotation = eulerAngles;
				else
					bezierSurfaceData.mesh.localRotation = eulerAngles;
				CreateImage();
				Invalidate();
			}
			catch (Exception)
			{
				MessageBox.Show(@"You have entered incorrect data", @"Error");
			}
		}

		DirectionalLight light = new DirectionalLight() { localRotation = new Vector3(-60, 180, 0) };

		private void toolStripButton1_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.InitialDirectory = "c:\\";
			ofd.Filter = "obj files (*.obj)|*.obj";
			ofd.FilterIndex = 2;
			ofd.RestoreDirectory = true;
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				var filePath = ofd.FileName;
				try
				{
					var loadObjData = loader.LoadFile(filePath);
					meshes.Add(new MeshTransform()
					{
						localPosition = Vector3.Forward * 5,
						localScale = Vector3.One,
						localRotation = Vector3.Zero,
						objData = loadObjData,
						// baseColor = new Vector3(1, 0, 0) ???
					});
					CreateImage();
					Invalidate();
				}
				catch (Exception)
				{
					MessageBox.Show(@"Something went wrong! Try again", @"Error");
				}
			}
		}

		private void toolStripButton2_Click(object sender, EventArgs e)
		{
			meshes.Clear();
			CreateImage();
			Invalidate();
		}

		private void toolStripButton3_Click(object sender, EventArgs e)
		{
			meshes.Add(new MeshTransform()
			{
				localPosition = Vector3.Forward * 5,
				localScale = Vector3.One,
				localRotation = Vector3.Zero,
				objData = loader.LoadFile(@"..\..\..\Sources\amogus.obj"),
				baseColor = new Vector3(1, 0, 0)
			});
            meshes.Add(new MeshTransform()
            {
                localPosition = Vector3.Forward * 5,
                localScale = Vector3.One,
                localRotation = Vector3.Zero,
                objData = loader.LoadFile(@"..\..\..\Sources\amogus_visor.obj"),
                baseColor = new Vector3(0, 0, 1)
            });
            meshes.Add(new MeshTransform()
            {
                localPosition = Vector3.Forward * 5,
                localScale = Vector3.One,
                localRotation = Vector3.Zero,
                objData = loader.LoadFile(@"..\..\..\Sources\Letters.obj"),
                baseColor = new Vector3(1, 0, 1)
            });
            CreateImage();
			Invalidate();
		}

		Bitmap img = new Bitmap(1000, 1000);

		private void CreateImage()
		{
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			var render = new Color[xSz, ySz];
			float[,] zb = null;
			if (!bezierSurfaceMode)
				zb = zbb.RenderZBufferFillPoly(new Vector2Int(xSz, ySz), meshes.Concat(axises), light, cam, render);
			else
				zb = zbb.BezierSurfaceRenderZBufferFillPoly(new Vector2Int(xSz, ySz), bezierSurfaceData, axises, light, cam, render);
			for (int x = 0; x < zb.GetLength(0); x++)
				for (int y = 0; y < zb.GetLength(1); y++)
				{
					if (zb[x, y] != float.MaxValue)
					{
						float t = MathF.Min(1, MathF.Max(0, MathF.Pow(zb[x, y], 4) / 2000));
						zb[x, y] = MathF.Min(255, 512 / zb[x, y]);
						int z = (int)MathF.Round(zb[x, y]);
						img.SetPixel(x, y, Lerp(render[x, y], Color.FromArgb(z / 2, z / 4, z), t));
					}
					else
						img.SetPixel(x, y, Color.Black);
				}
			stopwatch.Stop();
			var time = stopwatch.ElapsedMilliseconds;
		}

		private void Form1_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.DrawImage(img, 0, 0);
		}

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
			Form2 form2 = new Form2();
			form2.ShowDialog();
        }

        private void controlPointsStripButton_Click(object sender, EventArgs e)
        {
			BezierSurfaceManagerForm form = new BezierSurfaceManagerForm(bezierSurfaceData);
			form.ShowDialog();
			CreateImage();
			Invalidate();
		}

        private void changeInterfaceStripButton_Click(object sender, EventArgs e)
        {
			toolStripButton1.Visible = !toolStripButton1.Visible;
			toolStripButton2.Visible = !toolStripButton2.Visible;
			toolStripButton3.Visible = !toolStripButton3.Visible;
			controlPointsStripButton.Visible = !controlPointsStripButton.Visible;
			bezierSurfaceMode = !bezierSurfaceMode;
			CreateImage();
			Invalidate();
		}

        private void DrawWireframeObjectNative(MeshTransform mesh, PaintEventArgs e)
		{
			var meshProj = new MeshProjector();
			meshProj.InitCameraState(cam);
			var planar = meshProj.Project(mesh.DataToWorldSpace());
			foreach (var tri in planar.tris)
			{
				e.Graphics.DrawLine(new Pen(Color.Blue), (int)(tri.verts[0].x * 600), (int)(tri.verts[0].y * 600),
					(int)(tri.verts[1].x * 600), (int)(tri.verts[1].y * 600));
				e.Graphics.DrawLine(new Pen(Color.Blue), (int)(tri.verts[2].x * 600), (int)(tri.verts[2].y * 600),
					(int)(tri.verts[1].x * 600), (int)(tri.verts[1].y * 600));
				e.Graphics.DrawLine(new Pen(Color.Blue), (int)(tri.verts[2].x * 600), (int)(tri.verts[2].y * 600),
					(int)(tri.verts[0].x * 600), (int)(tri.verts[0].y * 600));
			}
		}


		private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
			if (meshes.Count() != 0)
			{
				switch (e.KeyCode)
				{
					case Keys.S:
						meshes.Last().localPosition += Vector3.Forward;
						e.Handled = true;
						break;
					case Keys.W:
						meshes.Last().localPosition += Vector3.Backward;
						e.Handled = true;
						break;
					case Keys.A:
						meshes.Last().localPosition += Vector3.Left;
						e.Handled = true;
						break;
					case Keys.D:
						meshes.Last().localPosition += Vector3.Right;
						e.Handled = true;
						break;
					case Keys.E:
						meshes.Last().localPosition += Vector3.Up;
						e.Handled = true;
						break;
					case Keys.Q:
						meshes.Last().localPosition += Vector3.Down;
						e.Handled = true;
						break;
				}
				CreateImage();
				Invalidate();
			}
		}
	}
}