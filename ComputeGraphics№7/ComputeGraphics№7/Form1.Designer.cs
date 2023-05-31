namespace ComputeGraphics_7
{
    partial class MainForm
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
            buttonCreate = new Button();
            pBox = new PictureBox();
            textBoxN = new TextBox();
            trackBarX = new TrackBar();
            trackBarY = new TrackBar();
            trackBarZ = new TrackBar();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)pBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarX).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarY).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarZ).BeginInit();
            SuspendLayout();
            // 
            // buttonCreate
            // 
            buttonCreate.Location = new Point(146, 248);
            buttonCreate.Margin = new Padding(2);
            buttonCreate.Name = "buttonCreate";
            buttonCreate.Size = new Size(96, 28);
            buttonCreate.TabIndex = 0;
            buttonCreate.Text = "Расположить";
            buttonCreate.UseVisualStyleBackColor = true;
            buttonCreate.Click += buttonCreate_Click;
            // 
            // pBox
            // 
            pBox.BackColor = Color.White;
            pBox.Location = new Point(8, 7);
            pBox.Margin = new Padding(2);
            pBox.Name = "pBox";
            pBox.Size = new Size(678, 232);
            pBox.TabIndex = 1;
            pBox.TabStop = false;
            // 
            // textBoxN
            // 
            textBoxN.Location = new Point(8, 265);
            textBoxN.Margin = new Padding(2);
            textBoxN.Name = "textBoxN";
            textBoxN.Size = new Size(113, 23);
            textBoxN.TabIndex = 2;
            textBoxN.Text = "7";
            // 
            // trackBarX
            // 
            trackBarX.AutoSize = false;
            trackBarX.Location = new Point(276, 242);
            trackBarX.Margin = new Padding(2);
            trackBarX.Maximum = 360;
            trackBarX.Name = "trackBarX";
            trackBarX.Size = new Size(410, 26);
            trackBarX.TabIndex = 3;
            trackBarX.Scroll += trackBarX_Scroll;
            // 
            // trackBarY
            // 
            trackBarY.AutoSize = false;
            trackBarY.Location = new Point(276, 272);
            trackBarY.Margin = new Padding(2);
            trackBarY.Maximum = 360;
            trackBarY.Name = "trackBarY";
            trackBarY.Size = new Size(410, 26);
            trackBarY.TabIndex = 4;
            trackBarY.Scroll += trackBarY_Scroll;
            // 
            // trackBarZ
            // 
            trackBarZ.AutoSize = false;
            trackBarZ.Location = new Point(276, 301);
            trackBarZ.Margin = new Padding(2);
            trackBarZ.Maximum = 360;
            trackBarZ.Name = "trackBarZ";
            trackBarZ.Size = new Size(410, 26);
            trackBarZ.TabIndex = 5;
            trackBarZ.Scroll += trackBarZ_Scroll;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 248);
            label1.Name = "label1";
            label1.Size = new Size(113, 15);
            label1.TabIndex = 6;
            label1.Text = "Количество граней";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(266, 248);
            label2.Name = "label2";
            label2.Size = new Size(16, 15);
            label2.TabIndex = 7;
            label2.Text = "x:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(265, 272);
            label3.Name = "label3";
            label3.Size = new Size(16, 15);
            label3.TabIndex = 8;
            label3.Text = "y:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(266, 301);
            label4.Name = "label4";
            label4.Size = new Size(15, 15);
            label4.TabIndex = 9;
            label4.Text = "z:";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(697, 347);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(trackBarZ);
            Controls.Add(trackBarY);
            Controls.Add(trackBarX);
            Controls.Add(textBoxN);
            Controls.Add(pBox);
            Controls.Add(buttonCreate);
            Margin = new Padding(2);
            Name = "MainForm";
            Text = "Вращение пирамиды";
            ((System.ComponentModel.ISupportInitialize)pBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarX).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarY).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarZ).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonCreate;
        private PictureBox pBox;
        private TextBox textBoxN;
        private TrackBar trackBarX;
        private TrackBar trackBarY;
        private TrackBar trackBarZ;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}