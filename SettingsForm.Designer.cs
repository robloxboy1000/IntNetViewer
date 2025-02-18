namespace IntNetViewer
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.textBoxHomePage = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxUA = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBoxDarkMode = new System.Windows.Forms.CheckBox();
            this.checkBoxHome = new System.Windows.Forms.CheckBox();
            this.checkBoxGPUAccel = new System.Windows.Forms.CheckBox();
            this.checkBoxShowFPS = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.checkBoxWarn = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxHomePage
            // 
            this.textBoxHomePage.Location = new System.Drawing.Point(84, 52);
            this.textBoxHomePage.Name = "textBoxHomePage";
            this.textBoxHomePage.Size = new System.Drawing.Size(174, 20);
            this.textBoxHomePage.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(74, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "Settings";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Home page:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(96, 415);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // textBoxUA
            // 
            this.textBoxUA.Location = new System.Drawing.Point(84, 79);
            this.textBoxUA.Name = "textBoxUA";
            this.textBoxUA.Size = new System.Drawing.Size(174, 20);
            this.textBoxUA.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "User agent:";
            // 
            // checkBoxDarkMode
            // 
            this.checkBoxDarkMode.AutoSize = true;
            this.checkBoxDarkMode.Location = new System.Drawing.Point(16, 105);
            this.checkBoxDarkMode.Name = "checkBoxDarkMode";
            this.checkBoxDarkMode.Size = new System.Drawing.Size(79, 17);
            this.checkBoxDarkMode.TabIndex = 8;
            this.checkBoxDarkMode.Text = "Dark Mode";
            this.checkBoxDarkMode.UseVisualStyleBackColor = true;
            // 
            // checkBoxHome
            // 
            this.checkBoxHome.AutoSize = true;
            this.checkBoxHome.Location = new System.Drawing.Point(16, 128);
            this.checkBoxHome.Name = "checkBoxHome";
            this.checkBoxHome.Size = new System.Drawing.Size(115, 17);
            this.checkBoxHome.TabIndex = 9;
            this.checkBoxHome.Text = "Show home button";
            this.checkBoxHome.UseVisualStyleBackColor = true;
            // 
            // checkBoxGPUAccel
            // 
            this.checkBoxGPUAccel.AutoSize = true;
            this.checkBoxGPUAccel.Location = new System.Drawing.Point(16, 166);
            this.checkBoxGPUAccel.Name = "checkBoxGPUAccel";
            this.checkBoxGPUAccel.Size = new System.Drawing.Size(111, 17);
            this.checkBoxGPUAccel.TabIndex = 10;
            this.checkBoxGPUAccel.Text = "GPU Acceleration";
            this.checkBoxGPUAccel.UseVisualStyleBackColor = true;
            // 
            // checkBoxShowFPS
            // 
            this.checkBoxShowFPS.AutoSize = true;
            this.checkBoxShowFPS.Location = new System.Drawing.Point(16, 190);
            this.checkBoxShowFPS.Name = "checkBoxShowFPS";
            this.checkBoxShowFPS.Size = new System.Drawing.Size(184, 17);
            this.checkBoxShowFPS.TabIndex = 11;
            this.checkBoxShowFPS.Text = "Show FPS Counter (WebGL only)";
            this.checkBoxShowFPS.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Location = new System.Drawing.Point(13, 152);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(245, 1);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // checkBoxWarn
            // 
            this.checkBoxWarn.AutoSize = true;
            this.checkBoxWarn.Location = new System.Drawing.Point(16, 214);
            this.checkBoxWarn.Name = "checkBoxWarn";
            this.checkBoxWarn.Size = new System.Drawing.Size(95, 17);
            this.checkBoxWarn.TabIndex = 13;
            this.checkBoxWarn.Text = "Warn on close";
            this.checkBoxWarn.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 450);
            this.Controls.Add(this.checkBoxWarn);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.checkBoxShowFPS);
            this.Controls.Add(this.checkBoxGPUAccel);
            this.Controls.Add(this.checkBoxHome);
            this.Controls.Add(this.checkBoxDarkMode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxUA);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxHomePage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsForm";
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxHomePage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxUA;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBoxDarkMode;
        private System.Windows.Forms.CheckBox checkBoxHome;
        private System.Windows.Forms.CheckBox checkBoxGPUAccel;
        private System.Windows.Forms.CheckBox checkBoxShowFPS;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox checkBoxWarn;
    }
}