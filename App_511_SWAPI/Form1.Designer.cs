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
            progressBar1 = new ProgressBar();
            labelName = new Label();
            labelPlanet = new Label();
            labelBirthDate = new Label();
            pictureBox1 = new RoundedPictureBox();
            labelTransport = new Label();
            buttonSave = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // listBoxPersons
            // 
            listBoxPersons.FormattingEnabled = true;
            listBoxPersons.Location = new Point(14, 14);
            listBoxPersons.Margin = new Padding(5);
            listBoxPersons.Name = "listBoxPersons";
            listBoxPersons.Size = new Size(442, 836);
            listBoxPersons.TabIndex = 1;
            listBoxPersons.SelectedIndexChanged += listBoxPersons_SelectedIndexChanged;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(1, 870);
            progressBar1.Margin = new Padding(5);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(875, 15);
            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.TabIndex = 4;
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelName.ForeColor = SystemColors.HotTrack;
            labelName.Location = new Point(473, 25);
            labelName.Margin = new Padding(5, 0, 5, 0);
            labelName.Name = "labelName";
            labelName.Size = new Size(0, 45);
            labelName.TabIndex = 5;
            // 
            // labelPlanet
            // 
            labelPlanet.AutoSize = true;
            labelPlanet.ForeColor = SystemColors.HotTrack;
            labelPlanet.Location = new Point(469, 560);
            labelPlanet.Margin = new Padding(5, 0, 5, 0);
            labelPlanet.Name = "labelPlanet";
            labelPlanet.Size = new Size(0, 32);
            labelPlanet.TabIndex = 6;
            // 
            // labelBirthDate
            // 
            labelBirthDate.AutoSize = true;
            labelBirthDate.ForeColor = SystemColors.HotTrack;
            labelBirthDate.Location = new Point(470, 612);
            labelBirthDate.Margin = new Padding(5, 0, 5, 0);
            labelBirthDate.Name = "labelBirthDate";
            labelBirthDate.Size = new Size(0, 32);
            labelBirthDate.TabIndex = 8;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Location = new Point(473, 90);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(400, 460);
            pictureBox1.TabIndex = 12;
            pictureBox1.TabStop = false;
            // 
            // labelTransport
            // 
            labelTransport.ForeColor = SystemColors.HotTrack;
            labelTransport.Location = new Point(469, 660);
            labelTransport.Name = "labelTransport";
            labelTransport.Size = new Size(400, 153);
            labelTransport.TabIndex = 13;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(770, 816);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(99, 46);
            buttonSave.TabIndex = 14;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.AppWorkspace;
            ClientSize = new Size(887, 890);
            Controls.Add(buttonSave);
            Controls.Add(labelTransport);
            Controls.Add(pictureBox1);
            Controls.Add(labelBirthDate);
            Controls.Add(labelPlanet);
            Controls.Add(labelName);
            Controls.Add(progressBar1);
            Controls.Add(listBoxPersons);
            Margin = new Padding(5);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ListBox listBoxPersons;
        private ProgressBar progressBar1;
        private Label labelName;
        private Label labelPlanet;
        private Label labelBirthDate;
        private RoundedPictureBox pictureBox1;
        private Label labelTransport;
        private Button buttonSave;
    }
}
