using CompGraphLab1.Data;
using CompGraphLab1.Rendering;
using CompGraphLab1.Scene;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace CompGraphLab1
{
    public partial class BezierSurfaceManagerForm : Form
    {
        public BezierSurfaceManagerForm(BezierSurfaceData data)
        {
            InitializeComponent();
            this.data = data;
            newControlPoints = new Vector3[16];
            Array.Copy(data.controlPoints, newControlPoints, 16);
            newGridResolution = data.gridResolution;
            isDiffuseColor = data.isDiffuseColor;
            isPatchRasterizer = data.isPatchRasterizer;
            triangleShader = data.mesh.triangleShader;
            constrolPointsTextBoxes = new TextBox[16];
            GridResolutionTextBox.Text = newGridResolution.ToString();
            for (int i = 0; i < 16; ++i)
            {
                constrolPointsTextBoxes[i] = (TextBox)GetType().
                    GetField("constrolPointsTextBox" + (i + 1).ToString(),
                    BindingFlags.NonPublic | BindingFlags.Instance).GetValue(this);
                constrolPointsTextBoxes[i].Text = newControlPoints[i].ToString();
            }
            renderEntireObjCheckBox.CheckState = (!isPatchRasterizer) ? CheckState.Checked : CheckState.Unchecked ;
            diffuseColorCheckBox.CheckState = (isDiffuseColor) ? CheckState.Checked : CheckState.Unchecked;
        }

        private void setControlPointsButton_Click(object sender, EventArgs e)
        {
            bool isError = false;
            for (int i = 0; i < 16; ++i)
            {
                try
                {
                    newControlPoints[i] = StringToVector3(constrolPointsTextBoxes[i].Text);
                    constrolPointsTextBoxes[i].BackColor = Color.White;
                }
                catch (Exception)
                {
                    isError = true;
                    constrolPointsTextBoxes[i].BackColor = Color.Salmon;
                }
            }
            if (isError)
                MessageBox.Show("You have entered incorrect data", "Error");
        }

        private void setGridResolutionButton_Click(object sender, EventArgs e)
        {
            try
            {
                int gridResolution = int.Parse(GridResolutionTextBox.Text);
                if (gridResolution < 16 || gridResolution > 512)
                    throw new Exception();
                newGridResolution = gridResolution;
            }
            catch (Exception)
            {
                GridResolutionTextBox.Text = newGridResolution.ToString();
                MessageBox.Show("You have entered incorrect data", "Error");
            }
        }

        private void renderEntireObjCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            isPatchRasterizer = !renderEntireObjCheckBox.Checked;
        }

        private void diffuseColorCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            isDiffuseColor = diffuseColorCheckBox.Checked;
            if (isDiffuseColor)
                triangleShader = Shaders.DiffuseColor;
            else
                triangleShader = (mesh, tlg, light) => Color.White;
        }

        private void ConfirmChangesButton_Click(object sender, EventArgs e)
        {
            data.controlPoints = newControlPoints;
            data.gridResolution = newGridResolution;
            data.isPatchRasterizer = isPatchRasterizer;
            data.isDiffuseColor = isDiffuseColor;
            data.mesh.triangleShader = triangleShader;
            BezierSurfaceObjCreator.Create(data);
            this.Close();
        }

        private Vector3 StringToVector3(string s)
        {
            Vector3 v = new Vector3();
            var subs = s.Split(';');
            v.x = (float)Convert.ToDouble(subs[0]);
            v.y = (float)Convert.ToDouble(subs[1]);
            v.z = (float)Convert.ToDouble(subs[2]);
            return v;
        }

        private BezierSurfaceData data;
        private Vector3[] newControlPoints;
        private int newGridResolution;
        private TextBox[] constrolPointsTextBoxes;
        private bool isPatchRasterizer;
        private bool isDiffuseColor;
        private Func<MeshTransform, Triangle3D, DirectionalLight, Color> triangleShader;
    }
}
