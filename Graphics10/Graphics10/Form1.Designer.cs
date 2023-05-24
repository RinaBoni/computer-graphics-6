namespace Graphics10
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonRedraw = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxMSize = new System.Windows.Forms.TextBox();
            this.buttonLoadimg = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxAlpha = new System.Windows.Forms.TextBox();
            this.buttonFilter1 = new System.Windows.Forms.Button();
            this.buttonFilter2 = new System.Windows.Forms.Button();
            this.buttonFilter3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(13, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(379, 329);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(409, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(379, 329);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(13, 348);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 20;
            this.dataGridView1.Size = new System.Drawing.Size(240, 150);
            this.dataGridView1.TabIndex = 2;
            // 
            // buttonRedraw
            // 
            this.buttonRedraw.Location = new System.Drawing.Point(477, 364);
            this.buttonRedraw.Name = "buttonRedraw";
            this.buttonRedraw.Size = new System.Drawing.Size(75, 23);
            this.buttonRedraw.TabIndex = 3;
            this.buttonRedraw.Text = "Redraw";
            this.buttonRedraw.UseVisualStyleBackColor = true;
            this.buttonRedraw.Click += new System.EventHandler(this.buttonRedraw_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(267, 351);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Matrix size";
            // 
            // textBoxMSize
            // 
            this.textBoxMSize.Location = new System.Drawing.Point(270, 367);
            this.textBoxMSize.Name = "textBoxMSize";
            this.textBoxMSize.Size = new System.Drawing.Size(100, 20);
            this.textBoxMSize.TabIndex = 9;
            this.textBoxMSize.Text = "4";
            // 
            // buttonLoadimg
            // 
            this.buttonLoadimg.Location = new System.Drawing.Point(477, 393);
            this.buttonLoadimg.Name = "buttonLoadimg";
            this.buttonLoadimg.Size = new System.Drawing.Size(75, 23);
            this.buttonLoadimg.TabIndex = 11;
            this.buttonLoadimg.Text = "Load image";
            this.buttonLoadimg.UseVisualStyleBackColor = true;
            this.buttonLoadimg.Click += new System.EventHandler(this.buttonLoadimg_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(267, 390);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Alpha";
            // 
            // textBoxAlpha
            // 
            this.textBoxAlpha.Location = new System.Drawing.Point(270, 406);
            this.textBoxAlpha.Name = "textBoxAlpha";
            this.textBoxAlpha.Size = new System.Drawing.Size(100, 20);
            this.textBoxAlpha.TabIndex = 12;
            this.textBoxAlpha.Text = "5";
            // 
            // buttonFilter1
            // 
            this.buttonFilter1.Location = new System.Drawing.Point(396, 365);
            this.buttonFilter1.Name = "buttonFilter1";
            this.buttonFilter1.Size = new System.Drawing.Size(75, 23);
            this.buttonFilter1.TabIndex = 14;
            this.buttonFilter1.Text = "Чёткость";
            this.buttonFilter1.UseVisualStyleBackColor = true;
            this.buttonFilter1.Click += new System.EventHandler(this.buttonFilter1_Click);
            // 
            // buttonFilter2
            // 
            this.buttonFilter2.Location = new System.Drawing.Point(396, 393);
            this.buttonFilter2.Name = "buttonFilter2";
            this.buttonFilter2.Size = new System.Drawing.Size(75, 23);
            this.buttonFilter2.TabIndex = 15;
            this.buttonFilter2.Text = "Размытие";
            this.buttonFilter2.UseVisualStyleBackColor = true;
            this.buttonFilter2.Click += new System.EventHandler(this.buttonFilter2_Click);
            // 
            // buttonFilter3
            // 
            this.buttonFilter3.Location = new System.Drawing.Point(396, 422);
            this.buttonFilter3.Name = "buttonFilter3";
            this.buttonFilter3.Size = new System.Drawing.Size(75, 23);
            this.buttonFilter3.TabIndex = 16;
            this.buttonFilter3.Text = "Тиснение";
            this.buttonFilter3.UseVisualStyleBackColor = true;
            this.buttonFilter3.Click += new System.EventHandler(this.buttonFilter3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 514);
            this.Controls.Add(this.buttonFilter3);
            this.Controls.Add(this.buttonFilter2);
            this.Controls.Add(this.buttonFilter1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxAlpha);
            this.Controls.Add(this.buttonLoadimg);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxMSize);
            this.Controls.Add(this.buttonRedraw);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonRedraw;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxMSize;
        private System.Windows.Forms.Button buttonLoadimg;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxAlpha;
        private System.Windows.Forms.Button buttonFilter1;
        private System.Windows.Forms.Button buttonFilter2;
        private System.Windows.Forms.Button buttonFilter3;
    }
}

