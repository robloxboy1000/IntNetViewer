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
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkBxUseAppDataAsCache = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.txtBxProxyPort = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtBxProxy = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbBxHost = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chkBxEnableProxy = new System.Windows.Forms.CheckBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.chkBxAllowCustomTheme = new System.Windows.Forms.CheckBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.checkBoxWarn = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.checkBoxShowFPS = new System.Windows.Forms.CheckBox();
            this.checkBoxGPUAccel = new System.Windows.Forms.CheckBox();
            this.checkBoxHome = new System.Windows.Forms.CheckBox();
            this.checkBoxDarkMode = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxUA = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxHomePage = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBxBGColor = new System.Windows.Forms.TextBox();
            this.txtBxFGColor = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
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
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.txtBxFGColor);
            this.panel1.Controls.Add(this.txtBxBGColor);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.chkBxUseAppDataAsCache);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.pictureBox4);
            this.panel1.Controls.Add(this.txtBxProxyPort);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtBxProxy);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.cbBxHost);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.chkBxEnableProxy);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.chkBxAllowCustomTheme);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.checkBoxWarn);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.checkBoxShowFPS);
            this.panel1.Controls.Add(this.checkBoxGPUAccel);
            this.panel1.Controls.Add(this.checkBoxHome);
            this.panel1.Controls.Add(this.checkBoxDarkMode);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textBoxUA);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBoxHomePage);
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(269, 409);
            this.panel1.TabIndex = 15;
            // 
            // chkBxUseAppDataAsCache
            // 
            this.chkBxUseAppDataAsCache.AutoSize = true;
            this.chkBxUseAppDataAsCache.Location = new System.Drawing.Point(15, 146);
            this.chkBxUseAppDataAsCache.Name = "chkBxUseAppDataAsCache";
            this.chkBxUseAppDataAsCache.Size = new System.Drawing.Size(147, 17);
            this.chkBxUseAppDataAsCache.TabIndex = 46;
            this.chkBxUseAppDataAsCache.Text = "Use \"AppData\" as cache";
            this.chkBxUseAppDataAsCache.UseVisualStyleBackColor = true;
            this.chkBxUseAppDataAsCache.CheckedChanged += new System.EventHandler(this.chkBxUseAppDataAsCache_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(93, 594);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 13);
            this.label9.TabIndex = 42;
            this.label9.Text = "#unfinished";
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Black;
            this.pictureBox4.Location = new System.Drawing.Point(13, 481);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(226, 1);
            this.pictureBox4.TabIndex = 41;
            this.pictureBox4.TabStop = false;
            // 
            // txtBxProxyPort
            // 
            this.txtBxProxyPort.Enabled = false;
            this.txtBxProxyPort.Location = new System.Drawing.Point(83, 451);
            this.txtBxProxyPort.Name = "txtBxProxyPort";
            this.txtBxProxyPort.Size = new System.Drawing.Size(155, 20);
            this.txtBxProxyPort.TabIndex = 40;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 454);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 13);
            this.label8.TabIndex = 39;
            this.label8.Text = "Port:";
            // 
            // txtBxProxy
            // 
            this.txtBxProxy.Enabled = false;
            this.txtBxProxy.Location = new System.Drawing.Point(83, 423);
            this.txtBxProxy.Name = "txtBxProxy";
            this.txtBxProxy.Size = new System.Drawing.Size(155, 20);
            this.txtBxProxy.TabIndex = 38;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 426);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 37;
            this.label7.Text = "Host:";
            // 
            // cbBxHost
            // 
            this.cbBxHost.Enabled = false;
            this.cbBxHost.FormattingEnabled = true;
            this.cbBxHost.Items.AddRange(new object[] {
            "http",
            "https",
            "socks4",
            "socks5"});
            this.cbBxHost.Location = new System.Drawing.Point(83, 394);
            this.cbBxHost.Name = "cbBxHost";
            this.cbBxHost.Size = new System.Drawing.Size(155, 21);
            this.cbBxHost.TabIndex = 36;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 397);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 35;
            this.label6.Text = "Type:";
            // 
            // chkBxEnableProxy
            // 
            this.chkBxEnableProxy.AutoSize = true;
            this.chkBxEnableProxy.Location = new System.Drawing.Point(15, 371);
            this.chkBxEnableProxy.Name = "chkBxEnableProxy";
            this.chkBxEnableProxy.Size = new System.Drawing.Size(87, 17);
            this.chkBxEnableProxy.TabIndex = 34;
            this.chkBxEnableProxy.Text = "Enable proxy";
            this.chkBxEnableProxy.UseVisualStyleBackColor = true;
            this.chkBxEnableProxy.CheckedChanged += new System.EventHandler(this.chkBxEnableProxy_CheckedChanged);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Black;
            this.pictureBox3.Location = new System.Drawing.Point(13, 359);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(226, 1);
            this.pictureBox3.TabIndex = 33;
            this.pictureBox3.TabStop = false;
            // 
            // chkBxAllowCustomTheme
            // 
            this.chkBxAllowCustomTheme.AutoSize = true;
            this.chkBxAllowCustomTheme.Location = new System.Drawing.Point(15, 274);
            this.chkBxAllowCustomTheme.Name = "chkBxAllowCustomTheme";
            this.chkBxAllowCustomTheme.Size = new System.Drawing.Size(120, 17);
            this.chkBxAllowCustomTheme.TabIndex = 32;
            this.chkBxAllowCustomTheme.Text = "Allow custom theme";
            this.chkBxAllowCustomTheme.UseVisualStyleBackColor = true;
            this.chkBxAllowCustomTheme.CheckedChanged += new System.EventHandler(this.chkBxAllowCustomTheme_CheckedChanged);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Black;
            this.pictureBox2.Location = new System.Drawing.Point(12, 258);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(226, 1);
            this.pictureBox2.TabIndex = 26;
            this.pictureBox2.TabStop = false;
            // 
            // checkBoxWarn
            // 
            this.checkBoxWarn.AutoSize = true;
            this.checkBoxWarn.Location = new System.Drawing.Point(15, 231);
            this.checkBoxWarn.Name = "checkBoxWarn";
            this.checkBoxWarn.Size = new System.Drawing.Size(95, 17);
            this.checkBoxWarn.TabIndex = 25;
            this.checkBoxWarn.Text = "Warn on close";
            this.checkBoxWarn.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Location = new System.Drawing.Point(12, 169);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(226, 1);
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            // 
            // checkBoxShowFPS
            // 
            this.checkBoxShowFPS.AutoSize = true;
            this.checkBoxShowFPS.Location = new System.Drawing.Point(15, 207);
            this.checkBoxShowFPS.Name = "checkBoxShowFPS";
            this.checkBoxShowFPS.Size = new System.Drawing.Size(184, 17);
            this.checkBoxShowFPS.TabIndex = 23;
            this.checkBoxShowFPS.Text = "Show FPS Counter (WebGL only)";
            this.checkBoxShowFPS.UseVisualStyleBackColor = true;
            // 
            // checkBoxGPUAccel
            // 
            this.checkBoxGPUAccel.AutoSize = true;
            this.checkBoxGPUAccel.Location = new System.Drawing.Point(15, 183);
            this.checkBoxGPUAccel.Name = "checkBoxGPUAccel";
            this.checkBoxGPUAccel.Size = new System.Drawing.Size(111, 17);
            this.checkBoxGPUAccel.TabIndex = 22;
            this.checkBoxGPUAccel.Text = "GPU Acceleration";
            this.checkBoxGPUAccel.UseVisualStyleBackColor = true;
            // 
            // checkBoxHome
            // 
            this.checkBoxHome.AutoSize = true;
            this.checkBoxHome.Location = new System.Drawing.Point(15, 123);
            this.checkBoxHome.Name = "checkBoxHome";
            this.checkBoxHome.Size = new System.Drawing.Size(115, 17);
            this.checkBoxHome.TabIndex = 21;
            this.checkBoxHome.Text = "Show home button";
            this.checkBoxHome.UseVisualStyleBackColor = true;
            // 
            // checkBoxDarkMode
            // 
            this.checkBoxDarkMode.AutoSize = true;
            this.checkBoxDarkMode.Location = new System.Drawing.Point(15, 100);
            this.checkBoxDarkMode.Name = "checkBoxDarkMode";
            this.checkBoxDarkMode.Size = new System.Drawing.Size(79, 17);
            this.checkBoxDarkMode.TabIndex = 20;
            this.checkBoxDarkMode.Text = "Dark Mode";
            this.checkBoxDarkMode.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "User agent:";
            // 
            // textBoxUA
            // 
            this.textBoxUA.Location = new System.Drawing.Point(83, 74);
            this.textBoxUA.Name = "textBoxUA";
            this.textBoxUA.Size = new System.Drawing.Size(155, 20);
            this.textBoxUA.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Home page:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(73, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 29);
            this.label1.TabIndex = 16;
            this.label1.Text = "Settings";
            // 
            // textBoxHomePage
            // 
            this.textBoxHomePage.Location = new System.Drawing.Point(83, 47);
            this.textBoxHomePage.Name = "textBoxHomePage";
            this.textBoxHomePage.Size = new System.Drawing.Size(155, 20);
            this.textBoxHomePage.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 298);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 47;
            this.label4.Text = "BG Color in hex";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 322);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 48;
            this.label5.Text = "FG Color in hex";
            // 
            // txtBxBGColor
            // 
            this.txtBxBGColor.Location = new System.Drawing.Point(101, 295);
            this.txtBxBGColor.Name = "txtBxBGColor";
            this.txtBxBGColor.Size = new System.Drawing.Size(137, 20);
            this.txtBxBGColor.TabIndex = 49;
            // 
            // txtBxFGColor
            // 
            this.txtBxFGColor.Location = new System.Drawing.Point(101, 319);
            this.txtBxFGColor.Name = "txtBxFGColor";
            this.txtBxFGColor.Size = new System.Drawing.Size(137, 20);
            this.txtBxFGColor.TabIndex = 50;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.CheckBox checkBoxWarn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox checkBoxShowFPS;
        private System.Windows.Forms.CheckBox checkBoxGPUAccel;
        private System.Windows.Forms.CheckBox checkBoxHome;
        private System.Windows.Forms.CheckBox checkBoxDarkMode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxUA;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxHomePage;
        private System.Windows.Forms.CheckBox chkBxAllowCustomTheme;
        private System.Windows.Forms.CheckBox chkBxEnableProxy;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.ComboBox cbBxHost;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBxProxyPort;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtBxProxy;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.CheckBox chkBxUseAppDataAsCache;
        private System.Windows.Forms.TextBox txtBxFGColor;
        private System.Windows.Forms.TextBox txtBxBGColor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
    }
}