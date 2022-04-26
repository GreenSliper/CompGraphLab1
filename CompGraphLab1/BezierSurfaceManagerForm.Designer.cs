
using System.Collections.Generic;

namespace CompGraphLab1
{
    partial class BezierSurfaceManagerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gridResolutionLabel = new System.Windows.Forms.Label();
            this.GridResolutionTextBox = new System.Windows.Forms.TextBox();
            this.controlPointsLabel1 = new System.Windows.Forms.Label();
            this.constrolPointsTextBox1 = new System.Windows.Forms.TextBox();
            this.renderEntireObjCheckBox = new System.Windows.Forms.CheckBox();
            this.diffuseColorCheckBox = new System.Windows.Forms.CheckBox();
            this.controlPointsLabel5 = new System.Windows.Forms.Label();
            this.constrolPointsTextBox5 = new System.Windows.Forms.TextBox();
            this.constrolPointsTextBox9 = new System.Windows.Forms.TextBox();
            this.constrolPointsTextBox13 = new System.Windows.Forms.TextBox();
            this.controlPointsLabel2 = new System.Windows.Forms.Label();
            this.constrolPointsTextBox2 = new System.Windows.Forms.TextBox();
            this.constrolPointsTextBox6 = new System.Windows.Forms.TextBox();
            this.constrolPointsTextBox10 = new System.Windows.Forms.TextBox();
            this.constrolPointsTextBox14 = new System.Windows.Forms.TextBox();
            this.controlPointsLabel3 = new System.Windows.Forms.Label();
            this.constrolPointsTextBox3 = new System.Windows.Forms.TextBox();
            this.constrolPointsTextBox7 = new System.Windows.Forms.TextBox();
            this.constrolPointsTextBox11 = new System.Windows.Forms.TextBox();
            this.constrolPointsTextBox15 = new System.Windows.Forms.TextBox();
            this.controlPointsLabel4 = new System.Windows.Forms.Label();
            this.constrolPointsTextBox4 = new System.Windows.Forms.TextBox();
            this.constrolPointsTextBox8 = new System.Windows.Forms.TextBox();
            this.constrolPointsTextBox12 = new System.Windows.Forms.TextBox();
            this.constrolPointsTextBox16 = new System.Windows.Forms.TextBox();
            this.controlPointsLabel6 = new System.Windows.Forms.Label();
            this.controlPointsLabel9 = new System.Windows.Forms.Label();
            this.controlPointsLabel13 = new System.Windows.Forms.Label();
            this.controlPointsLabel14 = new System.Windows.Forms.Label();
            this.controlPointsLabel15 = new System.Windows.Forms.Label();
            this.controlPointsLabel16 = new System.Windows.Forms.Label();
            this.controlPointsLabel10 = new System.Windows.Forms.Label();
            this.controlPointsLabel11 = new System.Windows.Forms.Label();
            this.controlPointsLabel12 = new System.Windows.Forms.Label();
            this.controlPointsLabel7 = new System.Windows.Forms.Label();
            this.controlPointsLabel8 = new System.Windows.Forms.Label();
            this.ConfirmChangesButton = new System.Windows.Forms.Button();
            this.setGridResolutionButton = new System.Windows.Forms.Button();
            this.setControlPointsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // gridResolutionLabel
            // 
            this.gridResolutionLabel.AutoSize = true;
            this.gridResolutionLabel.Location = new System.Drawing.Point(547, 15);
            this.gridResolutionLabel.Name = "gridResolutionLabel";
            this.gridResolutionLabel.Size = new System.Drawing.Size(114, 20);
            this.gridResolutionLabel.TabIndex = 0;
            this.gridResolutionLabel.Text = "Grid Resolution:";
            // 
            // GridResolutionTextBox
            // 
            this.GridResolutionTextBox.Location = new System.Drawing.Point(667, 12);
            this.GridResolutionTextBox.Name = "GridResolutionTextBox";
            this.GridResolutionTextBox.Size = new System.Drawing.Size(76, 27);
            this.GridResolutionTextBox.TabIndex = 1;
            // 
            // controlPointsLabel1
            // 
            this.controlPointsLabel1.AutoSize = true;
            this.controlPointsLabel1.Location = new System.Drawing.Point(23, 49);
            this.controlPointsLabel1.Name = "controlPointsLabel1";
            this.controlPointsLabel1.Size = new System.Drawing.Size(17, 20);
            this.controlPointsLabel1.TabIndex = 5;
            this.controlPointsLabel1.Text = "1";
            // 
            // constrolPointsTextBox1
            // 
            this.constrolPointsTextBox1.Location = new System.Drawing.Point(46, 46);
            this.constrolPointsTextBox1.Name = "constrolPointsTextBox1";
            this.constrolPointsTextBox1.Size = new System.Drawing.Size(94, 27);
            this.constrolPointsTextBox1.TabIndex = 6;
            // 
            // renderEntireObjCheckBox
            // 
            this.renderEntireObjCheckBox.AutoSize = true;
            this.renderEntireObjCheckBox.Location = new System.Drawing.Point(608, 45);
            this.renderEntireObjCheckBox.Name = "renderEntireObjCheckBox";
            this.renderEntireObjCheckBox.Size = new System.Drawing.Size(191, 24);
            this.renderEntireObjCheckBox.TabIndex = 8;
            this.renderEntireObjCheckBox.Text = "Render the entire object";
            this.renderEntireObjCheckBox.UseVisualStyleBackColor = true;
            this.renderEntireObjCheckBox.CheckedChanged += new System.EventHandler(this.renderEntireObjCheckBox_CheckedChanged);
            // 
            // diffuseColorCheckBox
            // 
            this.diffuseColorCheckBox.AutoSize = true;
            this.diffuseColorCheckBox.Location = new System.Drawing.Point(608, 75);
            this.diffuseColorCheckBox.Name = "diffuseColorCheckBox";
            this.diffuseColorCheckBox.Size = new System.Drawing.Size(190, 24);
            this.diffuseColorCheckBox.TabIndex = 9;
            this.diffuseColorCheckBox.Text = "Use diffuse color shader";
            this.diffuseColorCheckBox.UseVisualStyleBackColor = true;
            this.diffuseColorCheckBox.CheckedChanged += new System.EventHandler(this.diffuseColorCheckBox_CheckedChanged);
            // 
            // controlPointsLabel5
            // 
            this.controlPointsLabel5.AutoSize = true;
            this.controlPointsLabel5.Location = new System.Drawing.Point(23, 82);
            this.controlPointsLabel5.Name = "controlPointsLabel5";
            this.controlPointsLabel5.Size = new System.Drawing.Size(17, 20);
            this.controlPointsLabel5.TabIndex = 10;
            this.controlPointsLabel5.Text = "5";
            // 
            // constrolPointsTextBox5
            // 
            this.constrolPointsTextBox5.Location = new System.Drawing.Point(46, 79);
            this.constrolPointsTextBox5.Name = "constrolPointsTextBox5";
            this.constrolPointsTextBox5.Size = new System.Drawing.Size(94, 27);
            this.constrolPointsTextBox5.TabIndex = 11;
            // 
            // constrolPointsTextBox9
            // 
            this.constrolPointsTextBox9.Location = new System.Drawing.Point(46, 112);
            this.constrolPointsTextBox9.Name = "constrolPointsTextBox9";
            this.constrolPointsTextBox9.Size = new System.Drawing.Size(94, 27);
            this.constrolPointsTextBox9.TabIndex = 12;
            // 
            // constrolPointsTextBox13
            // 
            this.constrolPointsTextBox13.Location = new System.Drawing.Point(46, 145);
            this.constrolPointsTextBox13.Name = "constrolPointsTextBox13";
            this.constrolPointsTextBox13.Size = new System.Drawing.Size(94, 27);
            this.constrolPointsTextBox13.TabIndex = 13;
            // 
            // controlPointsLabel2
            // 
            this.controlPointsLabel2.AutoSize = true;
            this.controlPointsLabel2.Location = new System.Drawing.Point(154, 52);
            this.controlPointsLabel2.Name = "controlPointsLabel2";
            this.controlPointsLabel2.Size = new System.Drawing.Size(17, 20);
            this.controlPointsLabel2.TabIndex = 14;
            this.controlPointsLabel2.Text = "2";
            // 
            // constrolPointsTextBox2
            // 
            this.constrolPointsTextBox2.Location = new System.Drawing.Point(177, 46);
            this.constrolPointsTextBox2.Name = "constrolPointsTextBox2";
            this.constrolPointsTextBox2.Size = new System.Drawing.Size(94, 27);
            this.constrolPointsTextBox2.TabIndex = 15;
            // 
            // constrolPointsTextBox6
            // 
            this.constrolPointsTextBox6.Location = new System.Drawing.Point(177, 79);
            this.constrolPointsTextBox6.Name = "constrolPointsTextBox6";
            this.constrolPointsTextBox6.Size = new System.Drawing.Size(94, 27);
            this.constrolPointsTextBox6.TabIndex = 16;
            // 
            // constrolPointsTextBox10
            // 
            this.constrolPointsTextBox10.Location = new System.Drawing.Point(177, 112);
            this.constrolPointsTextBox10.Name = "constrolPointsTextBox10";
            this.constrolPointsTextBox10.Size = new System.Drawing.Size(94, 27);
            this.constrolPointsTextBox10.TabIndex = 17;
            // 
            // constrolPointsTextBox14
            // 
            this.constrolPointsTextBox14.Location = new System.Drawing.Point(177, 145);
            this.constrolPointsTextBox14.Name = "constrolPointsTextBox14";
            this.constrolPointsTextBox14.Size = new System.Drawing.Size(94, 27);
            this.constrolPointsTextBox14.TabIndex = 18;
            // 
            // controlPointsLabel3
            // 
            this.controlPointsLabel3.AutoSize = true;
            this.controlPointsLabel3.Location = new System.Drawing.Point(285, 51);
            this.controlPointsLabel3.Name = "controlPointsLabel3";
            this.controlPointsLabel3.Size = new System.Drawing.Size(17, 20);
            this.controlPointsLabel3.TabIndex = 19;
            this.controlPointsLabel3.Text = "3";
            // 
            // constrolPointsTextBox3
            // 
            this.constrolPointsTextBox3.Location = new System.Drawing.Point(308, 46);
            this.constrolPointsTextBox3.Name = "constrolPointsTextBox3";
            this.constrolPointsTextBox3.Size = new System.Drawing.Size(94, 27);
            this.constrolPointsTextBox3.TabIndex = 20;
            // 
            // constrolPointsTextBox7
            // 
            this.constrolPointsTextBox7.Location = new System.Drawing.Point(308, 79);
            this.constrolPointsTextBox7.Name = "constrolPointsTextBox7";
            this.constrolPointsTextBox7.Size = new System.Drawing.Size(94, 27);
            this.constrolPointsTextBox7.TabIndex = 21;
            // 
            // constrolPointsTextBox11
            // 
            this.constrolPointsTextBox11.Location = new System.Drawing.Point(308, 112);
            this.constrolPointsTextBox11.Name = "constrolPointsTextBox11";
            this.constrolPointsTextBox11.Size = new System.Drawing.Size(94, 27);
            this.constrolPointsTextBox11.TabIndex = 22;
            // 
            // constrolPointsTextBox15
            // 
            this.constrolPointsTextBox15.Location = new System.Drawing.Point(308, 145);
            this.constrolPointsTextBox15.Name = "constrolPointsTextBox15";
            this.constrolPointsTextBox15.Size = new System.Drawing.Size(94, 27);
            this.constrolPointsTextBox15.TabIndex = 23;
            // 
            // controlPointsLabel4
            // 
            this.controlPointsLabel4.AutoSize = true;
            this.controlPointsLabel4.Location = new System.Drawing.Point(416, 52);
            this.controlPointsLabel4.Name = "controlPointsLabel4";
            this.controlPointsLabel4.Size = new System.Drawing.Size(17, 20);
            this.controlPointsLabel4.TabIndex = 24;
            this.controlPointsLabel4.Text = "4";
            // 
            // constrolPointsTextBox4
            // 
            this.constrolPointsTextBox4.Location = new System.Drawing.Point(439, 47);
            this.constrolPointsTextBox4.Name = "constrolPointsTextBox4";
            this.constrolPointsTextBox4.Size = new System.Drawing.Size(94, 27);
            this.constrolPointsTextBox4.TabIndex = 25;
            // 
            // constrolPointsTextBox8
            // 
            this.constrolPointsTextBox8.Location = new System.Drawing.Point(439, 79);
            this.constrolPointsTextBox8.Name = "constrolPointsTextBox8";
            this.constrolPointsTextBox8.Size = new System.Drawing.Size(94, 27);
            this.constrolPointsTextBox8.TabIndex = 26;
            // 
            // constrolPointsTextBox12
            // 
            this.constrolPointsTextBox12.Location = new System.Drawing.Point(439, 112);
            this.constrolPointsTextBox12.Name = "constrolPointsTextBox12";
            this.constrolPointsTextBox12.Size = new System.Drawing.Size(94, 27);
            this.constrolPointsTextBox12.TabIndex = 27;
            // 
            // constrolPointsTextBox16
            // 
            this.constrolPointsTextBox16.Location = new System.Drawing.Point(439, 145);
            this.constrolPointsTextBox16.Name = "constrolPointsTextBox16";
            this.constrolPointsTextBox16.Size = new System.Drawing.Size(94, 27);
            this.constrolPointsTextBox16.TabIndex = 28;
            // 
            // controlPointsLabel6
            // 
            this.controlPointsLabel6.AutoSize = true;
            this.controlPointsLabel6.Location = new System.Drawing.Point(154, 86);
            this.controlPointsLabel6.Name = "controlPointsLabel6";
            this.controlPointsLabel6.Size = new System.Drawing.Size(17, 20);
            this.controlPointsLabel6.TabIndex = 29;
            this.controlPointsLabel6.Text = "6";
            // 
            // controlPointsLabel9
            // 
            this.controlPointsLabel9.AutoSize = true;
            this.controlPointsLabel9.Location = new System.Drawing.Point(23, 115);
            this.controlPointsLabel9.Name = "controlPointsLabel9";
            this.controlPointsLabel9.Size = new System.Drawing.Size(17, 20);
            this.controlPointsLabel9.TabIndex = 30;
            this.controlPointsLabel9.Text = "9";
            // 
            // controlPointsLabel13
            // 
            this.controlPointsLabel13.AutoSize = true;
            this.controlPointsLabel13.Location = new System.Drawing.Point(15, 148);
            this.controlPointsLabel13.Name = "controlPointsLabel13";
            this.controlPointsLabel13.Size = new System.Drawing.Size(25, 20);
            this.controlPointsLabel13.TabIndex = 31;
            this.controlPointsLabel13.Text = "13";
            // 
            // controlPointsLabel14
            // 
            this.controlPointsLabel14.AutoSize = true;
            this.controlPointsLabel14.Location = new System.Drawing.Point(146, 151);
            this.controlPointsLabel14.Name = "controlPointsLabel14";
            this.controlPointsLabel14.Size = new System.Drawing.Size(25, 20);
            this.controlPointsLabel14.TabIndex = 32;
            this.controlPointsLabel14.Text = "14";
            // 
            // controlPointsLabel15
            // 
            this.controlPointsLabel15.AutoSize = true;
            this.controlPointsLabel15.Location = new System.Drawing.Point(277, 150);
            this.controlPointsLabel15.Name = "controlPointsLabel15";
            this.controlPointsLabel15.Size = new System.Drawing.Size(25, 20);
            this.controlPointsLabel15.TabIndex = 33;
            this.controlPointsLabel15.Text = "15";
            // 
            // controlPointsLabel16
            // 
            this.controlPointsLabel16.AutoSize = true;
            this.controlPointsLabel16.Location = new System.Drawing.Point(408, 150);
            this.controlPointsLabel16.Name = "controlPointsLabel16";
            this.controlPointsLabel16.Size = new System.Drawing.Size(25, 20);
            this.controlPointsLabel16.TabIndex = 34;
            this.controlPointsLabel16.Text = "16";
            // 
            // controlPointsLabel10
            // 
            this.controlPointsLabel10.AutoSize = true;
            this.controlPointsLabel10.Location = new System.Drawing.Point(146, 118);
            this.controlPointsLabel10.Name = "controlPointsLabel10";
            this.controlPointsLabel10.Size = new System.Drawing.Size(25, 20);
            this.controlPointsLabel10.TabIndex = 35;
            this.controlPointsLabel10.Text = "10";
            // 
            // controlPointsLabel11
            // 
            this.controlPointsLabel11.AutoSize = true;
            this.controlPointsLabel11.Location = new System.Drawing.Point(277, 117);
            this.controlPointsLabel11.Name = "controlPointsLabel11";
            this.controlPointsLabel11.Size = new System.Drawing.Size(25, 20);
            this.controlPointsLabel11.TabIndex = 36;
            this.controlPointsLabel11.Text = "11";
            // 
            // controlPointsLabel12
            // 
            this.controlPointsLabel12.AutoSize = true;
            this.controlPointsLabel12.Location = new System.Drawing.Point(408, 117);
            this.controlPointsLabel12.Name = "controlPointsLabel12";
            this.controlPointsLabel12.Size = new System.Drawing.Size(25, 20);
            this.controlPointsLabel12.TabIndex = 37;
            this.controlPointsLabel12.Text = "12";
            // 
            // controlPointsLabel7
            // 
            this.controlPointsLabel7.AutoSize = true;
            this.controlPointsLabel7.Location = new System.Drawing.Point(285, 84);
            this.controlPointsLabel7.Name = "controlPointsLabel7";
            this.controlPointsLabel7.Size = new System.Drawing.Size(17, 20);
            this.controlPointsLabel7.TabIndex = 38;
            this.controlPointsLabel7.Text = "7";
            // 
            // controlPointsLabel8
            // 
            this.controlPointsLabel8.AutoSize = true;
            this.controlPointsLabel8.Location = new System.Drawing.Point(416, 85);
            this.controlPointsLabel8.Name = "controlPointsLabel8";
            this.controlPointsLabel8.Size = new System.Drawing.Size(17, 20);
            this.controlPointsLabel8.TabIndex = 39;
            this.controlPointsLabel8.Text = "8";
            // 
            // ConfirmChangesButton
            // 
            this.ConfirmChangesButton.Location = new System.Drawing.Point(608, 105);
            this.ConfirmChangesButton.Name = "ConfirmChangesButton";
            this.ConfirmChangesButton.Size = new System.Drawing.Size(190, 29);
            this.ConfirmChangesButton.TabIndex = 40;
            this.ConfirmChangesButton.Text = "Confirm changes";
            this.ConfirmChangesButton.UseVisualStyleBackColor = true;
            this.ConfirmChangesButton.Click += new System.EventHandler(this.ConfirmChangesButton_Click);
            // 
            // setGridResolutionButton
            // 
            this.setGridResolutionButton.Location = new System.Drawing.Point(749, 11);
            this.setGridResolutionButton.Name = "setGridResolutionButton";
            this.setGridResolutionButton.Size = new System.Drawing.Size(50, 29);
            this.setGridResolutionButton.TabIndex = 41;
            this.setGridResolutionButton.Text = "Set";
            this.setGridResolutionButton.UseVisualStyleBackColor = true;
            this.setGridResolutionButton.Click += new System.EventHandler(this.setGridResolutionButton_Click);
            // 
            // setControlPointsButton
            // 
            this.setControlPointsButton.Location = new System.Drawing.Point(15, 11);
            this.setControlPointsButton.Name = "setControlPointsButton";
            this.setControlPointsButton.Size = new System.Drawing.Size(156, 29);
            this.setControlPointsButton.TabIndex = 42;
            this.setControlPointsButton.Text = "Set control points";
            this.setControlPointsButton.UseVisualStyleBackColor = true;
            this.setControlPointsButton.Click += new System.EventHandler(this.setControlPointsButton_Click);
            // 
            // BezierSurfaceManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 186);
            this.Controls.Add(this.setControlPointsButton);
            this.Controls.Add(this.setGridResolutionButton);
            this.Controls.Add(this.ConfirmChangesButton);
            this.Controls.Add(this.controlPointsLabel8);
            this.Controls.Add(this.controlPointsLabel7);
            this.Controls.Add(this.controlPointsLabel12);
            this.Controls.Add(this.controlPointsLabel11);
            this.Controls.Add(this.controlPointsLabel10);
            this.Controls.Add(this.controlPointsLabel16);
            this.Controls.Add(this.controlPointsLabel15);
            this.Controls.Add(this.controlPointsLabel14);
            this.Controls.Add(this.controlPointsLabel13);
            this.Controls.Add(this.controlPointsLabel9);
            this.Controls.Add(this.controlPointsLabel6);
            this.Controls.Add(this.constrolPointsTextBox16);
            this.Controls.Add(this.constrolPointsTextBox12);
            this.Controls.Add(this.constrolPointsTextBox8);
            this.Controls.Add(this.constrolPointsTextBox4);
            this.Controls.Add(this.controlPointsLabel4);
            this.Controls.Add(this.constrolPointsTextBox15);
            this.Controls.Add(this.constrolPointsTextBox11);
            this.Controls.Add(this.constrolPointsTextBox7);
            this.Controls.Add(this.constrolPointsTextBox3);
            this.Controls.Add(this.controlPointsLabel3);
            this.Controls.Add(this.constrolPointsTextBox14);
            this.Controls.Add(this.constrolPointsTextBox10);
            this.Controls.Add(this.constrolPointsTextBox6);
            this.Controls.Add(this.constrolPointsTextBox2);
            this.Controls.Add(this.controlPointsLabel2);
            this.Controls.Add(this.constrolPointsTextBox13);
            this.Controls.Add(this.constrolPointsTextBox9);
            this.Controls.Add(this.constrolPointsTextBox5);
            this.Controls.Add(this.controlPointsLabel5);
            this.Controls.Add(this.diffuseColorCheckBox);
            this.Controls.Add(this.renderEntireObjCheckBox);
            this.Controls.Add(this.constrolPointsTextBox1);
            this.Controls.Add(this.controlPointsLabel1);
            this.Controls.Add(this.GridResolutionTextBox);
            this.Controls.Add(this.gridResolutionLabel);
            this.Name = "BezierSurfaceManagerForm";
            this.Text = "BezierSurfaceManager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label gridResolutionLabel;
        private System.Windows.Forms.TextBox GridResolutionTextBox;
        private System.Windows.Forms.Label controlPointsLabel1;
        private System.Windows.Forms.TextBox constrolPointsTextBox1;
        private System.Windows.Forms.CheckBox renderEntireObjCheckBox;
        private System.Windows.Forms.CheckBox diffuseColorCheckBox;
        private System.Windows.Forms.Label controlPointsLabel5;
        private System.Windows.Forms.TextBox constrolPointsTextBox5;
        private System.Windows.Forms.TextBox constrolPointsTextBox9;
        private System.Windows.Forms.TextBox constrolPointsTextBox13;
        private System.Windows.Forms.Label controlPointsLabel2;
        private System.Windows.Forms.TextBox constrolPointsTextBox2;
        private System.Windows.Forms.TextBox constrolPointsTextBox6;
        private System.Windows.Forms.TextBox constrolPointsTextBox10;
        private System.Windows.Forms.TextBox constrolPointsTextBox14;
        private System.Windows.Forms.Label controlPointsLabel3;
        private System.Windows.Forms.TextBox constrolPointsTextBox3;
        private System.Windows.Forms.TextBox constrolPointsTextBox7;
        private System.Windows.Forms.TextBox constrolPointsTextBox11;
        private System.Windows.Forms.TextBox constrolPointsTextBox15;
        private System.Windows.Forms.Label controlPointsLabel4;
        private System.Windows.Forms.TextBox constrolPointsTextBox4;
        private System.Windows.Forms.TextBox constrolPointsTextBox8;
        private System.Windows.Forms.TextBox constrolPointsTextBox12;
        private System.Windows.Forms.TextBox constrolPointsTextBox16;
        private System.Windows.Forms.Label controlPointsLabel6;
        private System.Windows.Forms.Label controlPointsLabel9;
        private System.Windows.Forms.Label controlPointsLabel13;
        private System.Windows.Forms.Label controlPointsLabel14;
        private System.Windows.Forms.Label controlPointsLabel15;
        private System.Windows.Forms.Label controlPointsLabel16;
        private System.Windows.Forms.Label controlPointsLabel10;
        private System.Windows.Forms.Label controlPointsLabel11;
        private System.Windows.Forms.Label controlPointsLabel12;
        private System.Windows.Forms.Label controlPointsLabel7;
        private System.Windows.Forms.Label controlPointsLabel8;
        private System.Windows.Forms.Button ConfirmChangesButton;
        private System.Windows.Forms.Button setGridResolutionButton;
        private System.Windows.Forms.Button setControlPointsButton;
    }
}