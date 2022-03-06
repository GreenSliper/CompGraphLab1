
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
			this.SuspendLayout();
			// 
			// RedrawButton
			// 
			this.RedrawButton.Location = new System.Drawing.Point(12, 12);
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
			this.OXLabel.Location = new System.Drawing.Point(112, 16);
			this.OXLabel.Name = "OXLabel";
			this.OXLabel.Size = new System.Drawing.Size(29, 20);
			this.OXLabel.TabIndex = 1;
			this.OXLabel.Text = "OX";
			// 
			// OXAngleRotationTextBox
			// 
			this.OXAngleRotationTextBox.Location = new System.Drawing.Point(147, 13);
			this.OXAngleRotationTextBox.Name = "OXAngleRotationTextBox";
			this.OXAngleRotationTextBox.Size = new System.Drawing.Size(58, 27);
			this.OXAngleRotationTextBox.TabIndex = 2;
			this.OXAngleRotationTextBox.Text = "0";
			// 
			// OYLabel
			// 
			this.OYLabel.AutoSize = true;
			this.OYLabel.Location = new System.Drawing.Point(211, 16);
			this.OYLabel.Name = "OYLabel";
			this.OYLabel.Size = new System.Drawing.Size(28, 20);
			this.OYLabel.TabIndex = 3;
			this.OYLabel.Text = "OY";
			// 
			// OYAngleRotationTextBox
			// 
			this.OYAngleRotationTextBox.Location = new System.Drawing.Point(245, 13);
			this.OYAngleRotationTextBox.Name = "OYAngleRotationTextBox";
			this.OYAngleRotationTextBox.Size = new System.Drawing.Size(58, 27);
			this.OYAngleRotationTextBox.TabIndex = 4;
			this.OYAngleRotationTextBox.Text = "30";
			// 
			// OZLabel
			// 
			this.OZLabel.AutoSize = true;
			this.OZLabel.Location = new System.Drawing.Point(309, 16);
			this.OZLabel.Name = "OZLabel";
			this.OZLabel.Size = new System.Drawing.Size(29, 20);
			this.OZLabel.TabIndex = 5;
			this.OZLabel.Text = "OZ";
			// 
			// OZAngleRotationTextBox
			// 
			this.OZAngleRotationTextBox.Location = new System.Drawing.Point(344, 13);
			this.OZAngleRotationTextBox.Name = "OZAngleRotationTextBox";
			this.OZAngleRotationTextBox.Size = new System.Drawing.Size(58, 27);
			this.OZAngleRotationTextBox.TabIndex = 6;
			this.OZAngleRotationTextBox.Text = "0";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(582, 553);
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
    }
}

