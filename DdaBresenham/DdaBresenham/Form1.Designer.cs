namespace DdaBresenham
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.x1TextBox = new System.Windows.Forms.TextBox();
            this.y1TextBox = new System.Windows.Forms.TextBox();
            this.x2TextBox = new System.Windows.Forms.TextBox();
            this.y2TextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.DdaPictureBox = new System.Windows.Forms.PictureBox();
            this.BresenhamPictureBox = new System.Windows.Forms.PictureBox();
            this.buttonDda = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonBres = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DdaPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BresenhamPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // x1TextBox
            // 
            this.x1TextBox.Location = new System.Drawing.Point(54, 72);
            this.x1TextBox.Margin = new System.Windows.Forms.Padding(2);
            this.x1TextBox.Name = "x1TextBox";
            this.x1TextBox.Size = new System.Drawing.Size(76, 20);
            this.x1TextBox.TabIndex = 0;
            // 
            // y1TextBox
            // 
            this.y1TextBox.Location = new System.Drawing.Point(54, 112);
            this.y1TextBox.Margin = new System.Windows.Forms.Padding(2);
            this.y1TextBox.Name = "y1TextBox";
            this.y1TextBox.Size = new System.Drawing.Size(76, 20);
            this.y1TextBox.TabIndex = 1;
            // 
            // x2TextBox
            // 
            this.x2TextBox.Location = new System.Drawing.Point(54, 151);
            this.x2TextBox.Margin = new System.Windows.Forms.Padding(2);
            this.x2TextBox.Name = "x2TextBox";
            this.x2TextBox.Size = new System.Drawing.Size(76, 20);
            this.x2TextBox.TabIndex = 2;
            // 
            // y2TextBox
            // 
            this.y2TextBox.Location = new System.Drawing.Point(54, 191);
            this.y2TextBox.Margin = new System.Windows.Forms.Padding(2);
            this.y2TextBox.Name = "y2TextBox";
            this.y2TextBox.Size = new System.Drawing.Size(76, 20);
            this.y2TextBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 76);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "X1:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 117);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Y1:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 156);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "X2:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 196);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Y2:";
            // 
            // DdaPictureBox
            // 
            this.DdaPictureBox.Location = new System.Drawing.Point(134, 11);
            this.DdaPictureBox.Margin = new System.Windows.Forms.Padding(2);
            this.DdaPictureBox.Name = "DdaPictureBox";
            this.DdaPictureBox.Size = new System.Drawing.Size(227, 308);
            this.DdaPictureBox.TabIndex = 8;
            this.DdaPictureBox.TabStop = false;
            // 
            // BresenhamPictureBox
            // 
            this.BresenhamPictureBox.Location = new System.Drawing.Point(362, 11);
            this.BresenhamPictureBox.Margin = new System.Windows.Forms.Padding(2);
            this.BresenhamPictureBox.Name = "BresenhamPictureBox";
            this.BresenhamPictureBox.Size = new System.Drawing.Size(227, 308);
            this.BresenhamPictureBox.TabIndex = 9;
            this.BresenhamPictureBox.TabStop = false;
            // 
            // buttonDda
            // 
            this.buttonDda.Location = new System.Drawing.Point(134, 336);
            this.buttonDda.Margin = new System.Windows.Forms.Padding(2);
            this.buttonDda.Name = "buttonDda";
            this.buttonDda.Size = new System.Drawing.Size(110, 27);
            this.buttonDda.TabIndex = 10;
            this.buttonDda.Text = "Построить ЦДА";
            this.buttonDda.UseVisualStyleBackColor = true;
            this.buttonDda.Click += new System.EventHandler(this.buttonDda_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(381, 321);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Брезенхем";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(131, 321);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "ЦДА";
            // 
            // buttonBres
            // 
            this.buttonBres.Location = new System.Drawing.Point(384, 336);
            this.buttonBres.Margin = new System.Windows.Forms.Padding(2);
            this.buttonBres.Name = "buttonBres";
            this.buttonBres.Size = new System.Drawing.Size(131, 28);
            this.buttonBres.TabIndex = 10;
            this.buttonBres.Text = "Построить Брезенхем";
            this.buttonBres.UseVisualStyleBackColor = true;
            this.buttonBres.Click += new System.EventHandler(this.buttonDda_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 11);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Введите координаты";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(0, 35);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(124, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "макс 227 по x, 308 по y";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonBres);
            this.Controls.Add(this.buttonDda);
            this.Controls.Add(this.BresenhamPictureBox);
            this.Controls.Add(this.DdaPictureBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.y2TextBox);
            this.Controls.Add(this.x2TextBox);
            this.Controls.Add(this.y1TextBox);
            this.Controls.Add(this.x1TextBox);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.DdaPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BresenhamPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox x1TextBox;
        private System.Windows.Forms.TextBox y1TextBox;
        private System.Windows.Forms.TextBox x2TextBox;
        private System.Windows.Forms.TextBox y2TextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox DdaPictureBox;
        private System.Windows.Forms.PictureBox BresenhamPictureBox;
        private System.Windows.Forms.Button buttonDda;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonBres;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}

