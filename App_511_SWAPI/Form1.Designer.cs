namespace App_511_SWAPI
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
            listBoxPersons = new ListBox();
            pictureBox1 = new PictureBox();
            progressBar1 = new ProgressBar();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // listBoxPersons
            // 
            listBoxPersons.FormattingEnabled = true;
            listBoxPersons.Location = new Point(12, 17);
            listBoxPersons.Name = "listBoxPersons";
            listBoxPersons.Size = new Size(274, 424);
            listBoxPersons.TabIndex = 1;
            listBoxPersons.SelectedIndexChanged += listBoxPersons_SelectedIndexChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(318, 69);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(292, 256);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(11, 472);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(608, 15);
            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.Location = new Point(318, 17);
            label1.Name = "label1";
            label1.Size = new Size(96, 28);
            label1.TabIndex = 5;
            label1.Text = "<Name>";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(319, 342);
            label2.Name = "label2";
            label2.Size = new Size(86, 20);
            label2.TabIndex = 6;
            label2.Text = "<param_1>";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(318, 378);
            label3.Name = "label3";
            label3.Size = new Size(86, 20);
            label3.TabIndex = 7;
            label3.Text = "<param_2>";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(319, 412);
            label4.Name = "label4";
            label4.Size = new Size(86, 20);
            label4.TabIndex = 8;
            label4.Text = "<param_3>";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.AppWorkspace;
            ClientSize = new Size(634, 499);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(progressBar1);
            Controls.Add(pictureBox1);
            Controls.Add(listBoxPersons);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ListBox listBoxPersons;
        private PictureBox pictureBox1;
        private ProgressBar progressBar1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}
