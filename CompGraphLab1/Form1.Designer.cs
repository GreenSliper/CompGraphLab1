
namespace CompGraphLab1
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.RedrawButton = new System.Windows.Forms.Button();
			this.OXLabel = new System.Windows.Forms.Label();
			this.OXAngleRotationTextBox = new System.Windows.Forms.TextBox();
			this.OYLabel = new System.Windows.Forms.Label();
			this.OYAngleRotationTextBox = new System.Windows.Forms.TextBox();
			this.OZLabel = new System.Windows.Forms.Label();
			this.OZAngleRotationTextBox = new System.Windows.Forms.TextBox();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// RedrawButton
			// 
			this.RedrawButton.Location = new System.Drawing.Point(12, 28);
			this.RedrawButton.Name = "RedrawButton";
			this.RedrawButton.Size = new System.Drawing.Size(94, 29);
			this.RedrawButton.TabIndex = 0;
			this.RedrawButton.Text = "Redraw";
			this.RedrawButton.UseVisualStyleBackColor = true;
			this.RedrawButton.Click += new System.EventHandler(this.button1_Click);
			// 
			// OXLabel
			// 
			this.OXLabel.AutoSize = true;
			this.OXLabel.Location = new System.Drawing.Point(112, 32);
			this.OXLabel.Name = "OXLabel";
			this.OXLabel.Size = new System.Drawing.Size(29, 20);
			this.OXLabel.TabIndex = 1;
			this.OXLabel.Text = "OX";
			// 
			// OXAngleRotationTextBox
			// 
			this.OXAngleRotationTextBox.Location = new System.Drawing.Point(147, 29);
			this.OXAngleRotationTextBox.Name = "OXAngleRotationTextBox";
			this.OXAngleRotationTextBox.Size = new System.Drawing.Size(58, 27);
			this.OXAngleRotationTextBox.TabIndex = 2;
			this.OXAngleRotationTextBox.Text = "0";
			// 
			// OYLabel
			// 
			this.OYLabel.AutoSize = true;
			this.OYLabel.Location = new System.Drawing.Point(211, 32);
			this.OYLabel.Name = "OYLabel";
			this.OYLabel.Size = new System.Drawing.Size(28, 20);
			this.OYLabel.TabIndex = 3;
			this.OYLabel.Text = "OY";
			// 
			// OYAngleRotationTextBox
			// 
			this.OYAngleRotationTextBox.Location = new System.Drawing.Point(245, 29);
			this.OYAngleRotationTextBox.Name = "OYAngleRotationTextBox";
			this.OYAngleRotationTextBox.Size = new System.Drawing.Size(58, 27);
			this.OYAngleRotationTextBox.TabIndex = 4;
			this.OYAngleRotationTextBox.Text = "30";
			// 
			// OZLabel
			// 
			this.OZLabel.AutoSize = true;
			this.OZLabel.Location = new System.Drawing.Point(309, 32);
			this.OZLabel.Name = "OZLabel";
			this.OZLabel.Size = new System.Drawing.Size(29, 20);
			this.OZLabel.TabIndex = 5;
			this.OZLabel.Text = "OZ";
			// 
			// OZAngleRotationTextBox
			// 
			this.OZAngleRotationTextBox.Location = new System.Drawing.Point(344, 29);
			this.OZAngleRotationTextBox.Name = "OZAngleRotationTextBox";
			this.OZAngleRotationTextBox.Size = new System.Drawing.Size(58, 27);
			this.OZAngleRotationTextBox.TabIndex = 6;
			this.OZAngleRotationTextBox.Text = "0";
			// 
			// toolStrip1
			// 
			this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(582, 27);
			this.toolStrip1.TabIndex = 7;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// toolStripButton1
			// 
			this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton1.Image = global::CompGraphLab1.Properties.Resources.add_icon;
			this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton1.Name = "toolStripButton1";
			this.toolStripButton1.Size = new System.Drawing.Size(29, 24);
			this.toolStripButton1.Text = "Add model";
			this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
			// 
			// toolStripButton2
			// 
			this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton2.Image = global::CompGraphLab1.Properties.Resources.delete_icon1;
			this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton2.Name = "toolStripButton2";
			this.toolStripButton2.Size = new System.Drawing.Size(29, 24);
			this.toolStripButton2.Text = "Remove model";
			this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
			// 
			// toolStripButton3
			// 
			this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton3.Image = global::CompGraphLab1.Properties.Resources.amogus_icon;
			this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton3.Name = "toolStripButton3";
			this.toolStripButton3.Size = new System.Drawing.Size(29, 24);
			this.toolStripButton3.Text = "Sussy baka";
			this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(582, 553);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.OZAngleRotationTextBox);
			this.Controls.Add(this.OZLabel);
			this.Controls.Add(this.OYAngleRotationTextBox);
			this.Controls.Add(this.OYLabel);
			this.Controls.Add(this.OXAngleRotationTextBox);
			this.Controls.Add(this.OXLabel);
			this.Controls.Add(this.RedrawButton);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
        private System.Windows.Forms.Button RedrawButton;
        private System.Windows.Forms.Label OXLabel;
        private System.Windows.Forms.TextBox OXAngleRotationTextBox;
        private System.Windows.Forms.Label OYLabel;
        private System.Windows.Forms.TextBox OYAngleRotationTextBox;
        private System.Windows.Forms.Label OZLabel;
        private System.Windows.Forms.TextBox OZAngleRotationTextBox;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
    }
}

