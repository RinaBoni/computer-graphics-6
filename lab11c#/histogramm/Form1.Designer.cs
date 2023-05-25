namespace histogramm
{
    partial class Lab11
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
            this.pictureBoxImage = new System.Windows.Forms.PictureBox();
            this.buttonLoadimage = new System.Windows.Forms.Button();
            this.buttonCreatehistograms = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.pictureBoxRG = new System.Windows.Forms.PictureBox();
            this.pictureBoxGG = new System.Windows.Forms.PictureBox();
            this.pictureBoxBG = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.pictureBoxNImage = new System.Windows.Forms.PictureBox();
            this.pictureBoxRNG = new System.Windows.Forms.PictureBox();
            this.pictureBoxGNG = new System.Windows.Forms.PictureBox();
            this.pictureBoxBNG = new System.Windows.Forms.PictureBox();
            this.buttonRedraw = new System.Windows.Forms.Button();
            this.buttonFlagRed = new System.Windows.Forms.Button();
            this.buttonFlagGreen = new System.Windows.Forms.Button();
            this.buttonFlagBlue = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRNG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGNG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBNG)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxImage
            // 
            this.pictureBoxImage.Location = new System.Drawing.Point(14, 12);
            this.pictureBoxImage.Name = "pictureBoxImage";
            this.pictureBoxImage.Size = new System.Drawing.Size(558, 393);
            this.pictureBoxImage.TabIndex = 1;
            this.pictureBoxImage.TabStop = false;
            // 
            // buttonLoadimage
            // 
            this.buttonLoadimage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonLoadimage.Location = new System.Drawing.Point(1023, 416);
            this.buttonLoadimage.Name = "buttonLoadimage";
            this.buttonLoadimage.Size = new System.Drawing.Size(113, 23);
            this.buttonLoadimage.TabIndex = 2;
            this.buttonLoadimage.Text = "Load image";
            this.buttonLoadimage.UseVisualStyleBackColor = true;
            this.buttonLoadimage.Click += new System.EventHandler(this.buttonLoadimage_Click);
            // 
            // buttonCreatehistograms
            // 
            this.buttonCreatehistograms.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCreatehistograms.Location = new System.Drawing.Point(1023, 445);
            this.buttonCreatehistograms.Name = "buttonCreatehistograms";
            this.buttonCreatehistograms.Size = new System.Drawing.Size(113, 23);
            this.buttonCreatehistograms.TabIndex = 3;
            this.buttonCreatehistograms.Text = "Create histograms";
            this.buttonCreatehistograms.UseVisualStyleBackColor = true;
            this.buttonCreatehistograms.Click += new System.EventHandler(this.buttonCreatehistograms_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // pictureBoxRG
            // 
            this.pictureBoxRG.Location = new System.Drawing.Point(14, 411);
            this.pictureBoxRG.Name = "pictureBoxRG";
            this.pictureBoxRG.Size = new System.Drawing.Size(256, 80);
            this.pictureBoxRG.TabIndex = 0;
            this.pictureBoxRG.TabStop = false;
            // 
            // pictureBoxGG
            // 
            this.pictureBoxGG.Location = new System.Drawing.Point(277, 411);
            this.pictureBoxGG.Name = "pictureBoxGG";
            this.pictureBoxGG.Size = new System.Drawing.Size(256, 80);
            this.pictureBoxGG.TabIndex = 4;
            this.pictureBoxGG.TabStop = false;
            // 
            // pictureBoxBG
            // 
            this.pictureBoxBG.Location = new System.Drawing.Point(540, 411);
            this.pictureBoxBG.Name = "pictureBoxBG";
            this.pictureBoxBG.Size = new System.Drawing.Size(256, 80);
            this.pictureBoxBG.TabIndex = 5;
            this.pictureBoxBG.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1026, 507);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Scale:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1123, 507);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "%";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(1068, 503);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(51, 20);
            this.numericUpDown1.TabIndex = 9;
            this.numericUpDown1.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // pictureBoxNImage
            // 
            this.pictureBoxNImage.Location = new System.Drawing.Point(578, 12);
            this.pictureBoxNImage.Name = "pictureBoxNImage";
            this.pictureBoxNImage.Size = new System.Drawing.Size(558, 393);
            this.pictureBoxNImage.TabIndex = 10;
            this.pictureBoxNImage.TabStop = false;
            // 
            // pictureBoxRNG
            // 
            this.pictureBoxRNG.Location = new System.Drawing.Point(14, 497);
            this.pictureBoxRNG.Name = "pictureBoxRNG";
            this.pictureBoxRNG.Size = new System.Drawing.Size(256, 80);
            this.pictureBoxRNG.TabIndex = 11;
            this.pictureBoxRNG.TabStop = false;
            this.pictureBoxRNG.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxRNG_MouseMove);
            // 
            // pictureBoxGNG
            // 
            this.pictureBoxGNG.Location = new System.Drawing.Point(277, 496);
            this.pictureBoxGNG.Name = "pictureBoxGNG";
            this.pictureBoxGNG.Size = new System.Drawing.Size(256, 80);
            this.pictureBoxGNG.TabIndex = 12;
            this.pictureBoxGNG.TabStop = false;
            this.pictureBoxGNG.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxGNG_MouseMove);
            // 
            // pictureBoxBNG
            // 
            this.pictureBoxBNG.Location = new System.Drawing.Point(540, 497);
            this.pictureBoxBNG.Name = "pictureBoxBNG";
            this.pictureBoxBNG.Size = new System.Drawing.Size(256, 80);
            this.pictureBoxBNG.TabIndex = 13;
            this.pictureBoxBNG.TabStop = false;
            this.pictureBoxBNG.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxBNG_MouseMove);
            // 
            // buttonRedraw
            // 
            this.buttonRedraw.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonRedraw.Location = new System.Drawing.Point(1023, 474);
            this.buttonRedraw.Name = "buttonRedraw";
            this.buttonRedraw.Size = new System.Drawing.Size(113, 23);
            this.buttonRedraw.TabIndex = 14;
            this.buttonRedraw.Text = "Redraw";
            this.buttonRedraw.UseVisualStyleBackColor = true;
            this.buttonRedraw.Click += new System.EventHandler(this.buttonRedraw_Click);
            // 
            // buttonFlagRed
            // 
            this.buttonFlagRed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonFlagRed.Location = new System.Drawing.Point(904, 416);
            this.buttonFlagRed.Name = "buttonFlagRed";
            this.buttonFlagRed.Size = new System.Drawing.Size(113, 23);
            this.buttonFlagRed.TabIndex = 15;
            this.buttonFlagRed.Text = "Red";
            this.buttonFlagRed.UseVisualStyleBackColor = true;
            this.buttonFlagRed.Click += new System.EventHandler(this.buttonFlagRed_Click);
            // 
            // buttonFlagGreen
            // 
            this.buttonFlagGreen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonFlagGreen.Location = new System.Drawing.Point(904, 445);
            this.buttonFlagGreen.Name = "buttonFlagGreen";
            this.buttonFlagGreen.Size = new System.Drawing.Size(113, 23);
            this.buttonFlagGreen.TabIndex = 16;
            this.buttonFlagGreen.Text = "Green";
            this.buttonFlagGreen.UseVisualStyleBackColor = true;
            this.buttonFlagGreen.Click += new System.EventHandler(this.buttonFlagGreen_Click);
            // 
            // buttonFlagBlue
            // 
            this.buttonFlagBlue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonFlagBlue.Location = new System.Drawing.Point(904, 474);
            this.buttonFlagBlue.Name = "buttonFlagBlue";
            this.buttonFlagBlue.Size = new System.Drawing.Size(113, 23);
            this.buttonFlagBlue.TabIndex = 17;
            this.buttonFlagBlue.Text = "Blue";
            this.buttonFlagBlue.UseVisualStyleBackColor = true;
            this.buttonFlagBlue.Click += new System.EventHandler(this.buttonFlagBlue_Click);
            // 
            // Lab11
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 584);
            this.Controls.Add(this.buttonFlagBlue);
            this.Controls.Add(this.buttonFlagGreen);
            this.Controls.Add(this.buttonFlagRed);
            this.Controls.Add(this.buttonRedraw);
            this.Controls.Add(this.pictureBoxBNG);
            this.Controls.Add(this.pictureBoxGNG);
            this.Controls.Add(this.pictureBoxRNG);
            this.Controls.Add(this.pictureBoxNImage);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBoxBG);
            this.Controls.Add(this.pictureBoxGG);
            this.Controls.Add(this.buttonCreatehistograms);
            this.Controls.Add(this.buttonLoadimage);
            this.Controls.Add(this.pictureBoxImage);
            this.Controls.Add(this.pictureBoxRG);
            this.Name = "Lab11";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRNG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGNG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBNG)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBoxImage;
        private System.Windows.Forms.Button buttonLoadimage;
        private System.Windows.Forms.Button buttonCreatehistograms;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox pictureBoxRG;
        private System.Windows.Forms.PictureBox pictureBoxGG;
        private System.Windows.Forms.PictureBox pictureBoxBG;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.PictureBox pictureBoxNImage;
        private System.Windows.Forms.PictureBox pictureBoxRNG;
        private System.Windows.Forms.PictureBox pictureBoxGNG;
        private System.Windows.Forms.PictureBox pictureBoxBNG;
        private System.Windows.Forms.Button buttonRedraw;
        private System.Windows.Forms.Button buttonFlagRed;
        private System.Windows.Forms.Button buttonFlagGreen;
        private System.Windows.Forms.Button buttonFlagBlue;
    }
}

