namespace GraphicRotate
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
            buttonLine = new Button();
            buttonElips = new Button();
            buttonRotateRight = new Button();
            buttonRotateLeft = new Button();
            pictureBox1 = new PictureBox();
            buttonAutoRotate = new Button();
            textBoxGrad = new TextBox();
            labelGrad = new Label();
            labelX = new Label();
            labelY = new Label();
            labelY1 = new Label();
            labelX1 = new Label();
            button1 = new Button();
            label3 = new Label();
            label4 = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // buttonLine
            // 
            buttonLine.Location = new Point(860, 164);
            buttonLine.Name = "buttonLine";
            buttonLine.Size = new Size(75, 23);
            buttonLine.TabIndex = 0;
            buttonLine.Text = "Линия";
            buttonLine.UseVisualStyleBackColor = true;
            buttonLine.Click += buttonLine_Click;
            // 
            // buttonElips
            // 
            buttonElips.Location = new Point(974, 164);
            buttonElips.Name = "buttonElips";
            buttonElips.Size = new Size(75, 23);
            buttonElips.TabIndex = 1;
            buttonElips.Text = "Эллипс";
            buttonElips.UseVisualStyleBackColor = true;
            buttonElips.Click += buttonElips_Click;
            // 
            // buttonRotateRight
            // 
            buttonRotateRight.Location = new Point(1003, 267);
            buttonRotateRight.Name = "buttonRotateRight";
            buttonRotateRight.Size = new Size(75, 23);
            buttonRotateRight.TabIndex = 2;
            buttonRotateRight.Text = "->";
            buttonRotateRight.UseVisualStyleBackColor = true;
            buttonRotateRight.Click += buttonRotateRight_Click;
            // 
            // buttonRotateLeft
            // 
            buttonRotateLeft.Location = new Point(908, 267);
            buttonRotateLeft.Name = "buttonRotateLeft";
            buttonRotateLeft.Size = new Size(75, 23);
            buttonRotateLeft.TabIndex = 3;
            buttonRotateLeft.Text = "<-";
            buttonRotateLeft.UseVisualStyleBackColor = true;
            buttonRotateLeft.Click += buttonRotateLeft_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.BackColor = SystemColors.Window;
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(843, 536);
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            pictureBox1.MouseClick += pictureBox1MouseHover;
            pictureBox1.MouseMove += pictureBox1_MouseMove;
            // 
            // buttonAutoRotate
            // 
            buttonAutoRotate.Location = new Point(1003, 343);
            buttonAutoRotate.Name = "buttonAutoRotate";
            buttonAutoRotate.Size = new Size(75, 23);
            buttonAutoRotate.TabIndex = 5;
            buttonAutoRotate.Text = "AutoRotate";
            buttonAutoRotate.UseVisualStyleBackColor = true;
            buttonAutoRotate.Click += buttonAutoRotate_Click;
            // 
            // textBoxGrad
            // 
            textBoxGrad.Location = new Point(908, 343);
            textBoxGrad.Name = "textBoxGrad";
            textBoxGrad.Size = new Size(75, 23);
            textBoxGrad.TabIndex = 6;
            textBoxGrad.Text = "0,3";
            // 
            // labelGrad
            // 
            labelGrad.AutoSize = true;
            labelGrad.Location = new Point(908, 325);
            labelGrad.Name = "labelGrad";
            labelGrad.Size = new Size(59, 15);
            labelGrad.TabIndex = 7;
            labelGrad.Text = "Скорость";
            // 
            // labelX
            // 
            labelX.AutoSize = true;
            labelX.Location = new Point(861, 210);
            labelX.Name = "labelX";
            labelX.Size = new Size(17, 15);
            labelX.TabIndex = 8;
            labelX.Text = "X:";
            // 
            // labelY
            // 
            labelY.AutoSize = true;
            labelY.Location = new Point(861, 225);
            labelY.Name = "labelY";
            labelY.Size = new Size(17, 15);
            labelY.TabIndex = 9;
            labelY.Text = "Y:";
            // 
            // labelY1
            // 
            labelY1.AutoSize = true;
            labelY1.Location = new Point(925, 225);
            labelY1.Name = "labelY1";
            labelY1.Size = new Size(23, 15);
            labelY1.TabIndex = 11;
            labelY1.Text = "Y1:";
            // 
            // labelX1
            // 
            labelX1.AutoSize = true;
            labelX1.Location = new Point(925, 210);
            labelX1.Name = "labelX1";
            labelX1.Size = new Size(23, 15);
            labelX1.TabIndex = 10;
            labelX1.Text = "X1:";
            // 
            // button1
            // 
            button1.Location = new Point(1055, 164);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 16;
            button1.Text = "От руки";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(960, 249);
            label3.Name = "label3";
            label3.Size = new Size(64, 15);
            label3.TabIndex = 17;
            label3.Text = "Вращение";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(947, 310);
            label4.Name = "label4";
            label4.Size = new Size(92, 15);
            label4.TabIndex = 18;
            label4.Text = "Авто вращение";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(861, 195);
            label1.Name = "label1";
            label1.Size = new Size(113, 15);
            label1.TabIndex = 19;
            label1.Text = "Координаты линии";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1134, 560);
            Controls.Add(label1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(button1);
            Controls.Add(labelY1);
            Controls.Add(labelX1);
            Controls.Add(labelY);
            Controls.Add(labelX);
            Controls.Add(labelGrad);
            Controls.Add(textBoxGrad);
            Controls.Add(buttonAutoRotate);
            Controls.Add(pictureBox1);
            Controls.Add(buttonRotateLeft);
            Controls.Add(buttonRotateRight);
            Controls.Add(buttonElips);
            Controls.Add(buttonLine);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonLine;
        private Button buttonElips;
        private Button buttonRotateRight;
        private Button buttonRotateLeft;
        private PictureBox pictureBox1;
        private Button buttonAutoRotate;
        private TextBox textBoxGrad;
        private Label labelGrad;
        private Label labelX;
        private Label labelY;
        private Label labelY1;
        private Label labelX1;
        private Button button1;
        private Label label3;
        private Label label4;
        private Label label1;
    }
}