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
            this.checkBoxJavaScriptEnabled = new System.Windows.Forms.CheckBox();
            this.textBoxHomePage = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxUA = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // checkBoxJavaScriptEnabled
            // 
            this.checkBoxJavaScriptEnabled.AutoSize = true;
            this.checkBoxJavaScriptEnabled.Location = new System.Drawing.Point(16, 86);
            this.checkBoxJavaScriptEnabled.Name = "checkBoxJavaScriptEnabled";
            this.checkBoxJavaScriptEnabled.Size = new System.Drawing.Size(74, 17);
            this.checkBoxJavaScriptEnabled.TabIndex = 1;
            this.checkBoxJavaScriptEnabled.Text = "Javascript";
            this.checkBoxJavaScriptEnabled.UseVisualStyleBackColor = true;
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
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxUA
            // 
            this.textBoxUA.Location = new System.Drawing.Point(84, 115);
            this.textBoxUA.Name = "textBoxUA";
            this.textBoxUA.Size = new System.Drawing.Size(174, 20);
            this.textBoxUA.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "User agent:";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxUA);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBoxJavaScriptEnabled);
            this.Controls.Add(this.textBoxHomePage);
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxJavaScriptEnabled;
        private System.Windows.Forms.TextBox textBoxHomePage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxUA;
        private System.Windows.Forms.Label label3;
    }
}