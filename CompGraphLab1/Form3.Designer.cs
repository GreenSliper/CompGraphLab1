
namespace CompGraphLab1
{
    partial class Form3
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.addButton = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.visiableChangeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Текущий цвет: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(152, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "label2";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(29, 111);
            this.listBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(137, 124);
            this.listBox1.TabIndex = 2;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Цвет кривой";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 240);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Цвет опорных точек";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 260);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "Текущий цвет:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(152, 260);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "label6";
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 20;
            this.listBox2.Location = new System.Drawing.Point(29, 284);
            this.listBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(137, 124);
            this.listBox2.TabIndex = 7;
            this.listBox2.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(291, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(205, 20);
            this.label7.TabIndex = 8;
            this.label7.Text = "Координаты опорных точек";
            // 
            // listBox3
            // 
            this.listBox3.FormattingEnabled = true;
            this.listBox3.ItemHeight = 20;
            this.listBox3.Location = new System.Drawing.Point(291, 111);
            this.listBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(137, 124);
            this.listBox3.TabIndex = 9;
            this.listBox3.SelectedIndexChanged += new System.EventHandler(this.listBox3_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(291, 260);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(198, 20);
            this.label8.TabIndex = 11;
            this.label8.Text = "Изменение опорных точек";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(291, 284);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(114, 27);
            this.textBox1.TabIndex = 12;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(291, 319);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 31);
            this.button1.TabIndex = 13;
            this.button1.Text = "Изменить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(152, 491);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(183, 31);
            this.button2.TabIndex = 14;
            this.button2.Text = "Применить изменения";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(221, 36);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 20);
            this.label9.TabIndex = 15;
            this.label9.Text = "label9";
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(434, 111);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(94, 29);
            this.addButton.TabIndex = 16;
            this.addButton.Text = "Добавить";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(434, 146);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(94, 32);
            this.button4.TabIndex = 17;
            this.button4.Text = "Удалить";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // visiableChangeButton
            // 
            this.visiableChangeButton.Location = new System.Drawing.Point(29, 415);
            this.visiableChangeButton.Name = "visiableChangeButton";
            this.visiableChangeButton.Size = new System.Drawing.Size(173, 41);
            this.visiableChangeButton.TabIndex = 18;
            this.visiableChangeButton.Text = "button3";
            this.visiableChangeButton.UseVisualStyleBackColor = true;
            this.visiableChangeButton.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 600);
            this.Controls.Add(this.visiableChangeButton);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.listBox3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form3";
            this.Text = "Form3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox listBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button visiableChangeButton;
    }
}