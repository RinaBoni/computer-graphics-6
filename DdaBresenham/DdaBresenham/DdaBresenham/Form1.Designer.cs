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
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DdaPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BresenhamPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // x1TextBox
            // 
            this.x1TextBox.Location = new System.Drawing.Point(72, 88);
            this.x1TextBox.Name = "x1TextBox";
            this.x1TextBox.Size = new System.Drawing.Size(100, 22);
            this.x1TextBox.TabIndex = 0;
            // 
            // y1TextBox
            // 
            this.y1TextBox.Location = new System.Drawing.Point(72, 138);
            this.y1TextBox.Name = "y1TextBox";
            this.y1TextBox.Size = new System.Drawing.Size(100, 22);
            this.y1TextBox.TabIndex = 1;
            // 
            // x2TextBox
            // 
            this.x2TextBox.Location = new System.Drawing.Point(72, 211);
            this.x2TextBox.Name = "x2TextBox";
            this.x2TextBox.Size = new System.Drawing.Size(100, 22);
            this.x2TextBox.TabIndex = 2;
            // 
            // y2TextBox
            // 
            this.y2TextBox.Location = new System.Drawing.Point(72, 260);
            this.y2TextBox.Name = "y2TextBox";
            this.y2TextBox.Size = new System.Drawing.Size(100, 22);
            this.y2TextBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "X1:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Y1:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 217);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "X2:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 266);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Y2:";
            // 
            // DdaPictureBox
            // 
            this.DdaPictureBox.Location = new System.Drawing.Point(220, 88);
            this.DdaPictureBox.Name = "DdaPictureBox";
            this.DdaPictureBox.Size = new System.Drawing.Size(400, 400);
            this.DdaPictureBox.TabIndex = 8;
            this.DdaPictureBox.TabStop = false;
            // 
            // BresenhamPictureBox
            // 
            this.BresenhamPictureBox.Location = new System.Drawing.Point(722, 88);
            this.BresenhamPictureBox.Name = "BresenhamPictureBox";
            this.BresenhamPictureBox.Size = new System.Drawing.Size(400, 400);
            this.BresenhamPictureBox.TabIndex = 9;
            this.BresenhamPictureBox.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(220, 541);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(147, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Построить график";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(719, 512);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Брезенхем";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(217, 512);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 16);
            this.label6.TabIndex = 12;
            this.label6.Text = "ЦДА";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(722, 541);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(147, 23);
            this.button2.TabIndex = 13;
            this.button2.Text = "Построить график";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(172, 16);
            this.label7.TabIndex = 14;
            this.label7.Text = "Вводите значения до 299\r\n";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1169, 633);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BresenhamPictureBox);
            this.Controls.Add(this.DdaPictureBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.y2TextBox);
            this.Controls.Add(this.x2TextBox);
            this.Controls.Add(this.y1TextBox);
            this.Controls.Add(this.x1TextBox);
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label7;
    }
}

