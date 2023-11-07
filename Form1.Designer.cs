namespace IntNetViewer
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.urlTextBox = new System.Windows.Forms.TextBox();
            this.back = new System.Windows.Forms.Button();
            this.forward = new System.Windows.Forms.Button();
            this.refresh = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.launchIntNetViewerWithTabbedViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.devsOnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chromiumWebBrowser1 = new CefSharp.WinForms.ChromiumWebBrowser();
            this.searchEngineComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.labelSecurity = new System.Windows.Forms.Label();
            this.pictureBoxFavicon = new System.Windows.Forms.PictureBox();
            this.pictureBoxLoading = new System.Windows.Forms.PictureBox();
            this.loadingTimer = new System.Windows.Forms.Timer(this.components);
            this.progressBarDownload = new System.Windows.Forms.ProgressBar();
            this.label4 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFavicon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLoading)).BeginInit();
            this.SuspendLayout();
            // 
            // urlTextBox
            // 
            this.urlTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.urlTextBox.Location = new System.Drawing.Point(64, 82);
            this.urlTextBox.Name = "urlTextBox";
            this.urlTextBox.Size = new System.Drawing.Size(932, 20);
            this.urlTextBox.TabIndex = 1;
            this.urlTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textbox_KeyDown);
            // 
            // back
            // 
            this.back.Location = new System.Drawing.Point(15, 31);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(76, 26);
            this.back.TabIndex = 2;
            this.back.Text = "Back";
            this.back.UseVisualStyleBackColor = true;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // forward
            // 
            this.forward.Location = new System.Drawing.Point(97, 31);
            this.forward.Name = "forward";
            this.forward.Size = new System.Drawing.Size(75, 26);
            this.forward.TabIndex = 3;
            this.forward.Text = "Forward";
            this.forward.UseVisualStyleBackColor = true;
            this.forward.Click += new System.EventHandler(this.forward_Click);
            // 
            // refresh
            // 
            this.refresh.Location = new System.Drawing.Point(259, 31);
            this.refresh.Name = "refresh";
            this.refresh.Size = new System.Drawing.Size(75, 26);
            this.refresh.TabIndex = 4;
            this.refresh.Text = "Refresh";
            this.refresh.UseVisualStyleBackColor = true;
            this.refresh.Click += new System.EventHandler(this.refresh_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem1,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1008, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem1
            // 
            this.fileToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.toolStripSeparator2,
            this.launchIntNetViewerWithTabbedViewToolStripMenuItem,
            this.devsOnlyToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
            this.fileToolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem1.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(279, 22);
            this.newToolStripMenuItem.Text = "&New Window";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(276, 6);
            // 
            // launchIntNetViewerWithTabbedViewToolStripMenuItem
            // 
            this.launchIntNetViewerWithTabbedViewToolStripMenuItem.Name = "launchIntNetViewerWithTabbedViewToolStripMenuItem";
            this.launchIntNetViewerWithTabbedViewToolStripMenuItem.Size = new System.Drawing.Size(279, 22);
            this.launchIntNetViewerWithTabbedViewToolStripMenuItem.Text = "Launch IntNetViewer with Tabbed View";
            this.launchIntNetViewerWithTabbedViewToolStripMenuItem.Click += new System.EventHandler(this.launchIntNetViewerWithTabbedViewToolStripMenuItem_Click);
            // 
            // devsOnlyToolStripMenuItem
            // 
            this.devsOnlyToolStripMenuItem.Name = "devsOnlyToolStripMenuItem";
            this.devsOnlyToolStripMenuItem.Size = new System.Drawing.Size(279, 22);
            this.devsOnlyToolStripMenuItem.Text = "Launch AudioGroove";
            this.devsOnlyToolStripMenuItem.Click += new System.EventHandler(this.devsOnlyToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(279, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.aboutToolStripMenuItem.Text = "&About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Go To:";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(178, 31);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 26);
            this.button4.TabIndex = 15;
            this.button4.Text = "Home";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // searchTextBox
            // 
            this.searchTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchTextBox.Location = new System.Drawing.Point(763, 35);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(233, 20);
            this.searchTextBox.TabIndex = 17;
            this.searchTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchTextBox_KeyDown);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(698, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Search for:";
            // 
            // chromiumWebBrowser1
            // 
            this.chromiumWebBrowser1.ActivateBrowserOnCreation = false;
            this.chromiumWebBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chromiumWebBrowser1.Location = new System.Drawing.Point(0, 108);
            this.chromiumWebBrowser1.Name = "chromiumWebBrowser1";
            this.chromiumWebBrowser1.Size = new System.Drawing.Size(1008, 593);
            this.chromiumWebBrowser1.TabIndex = 20;
            this.chromiumWebBrowser1.FrameLoadEnd += new System.EventHandler<CefSharp.FrameLoadEndEventArgs>(this.chromiumWebBrowser1_FrameLoadEnd);
            this.chromiumWebBrowser1.LoadingStateChanged += new System.EventHandler<CefSharp.LoadingStateChangedEventArgs>(this.chromiumWebBrowser1_LoadingStateChanged);
            // 
            // searchEngineComboBox
            // 
            this.searchEngineComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchEngineComboBox.FormattingEnabled = true;
            this.searchEngineComboBox.Location = new System.Drawing.Point(571, 35);
            this.searchEngineComboBox.Name = "searchEngineComboBox";
            this.searchEngineComboBox.Size = new System.Drawing.Size(121, 21);
            this.searchEngineComboBox.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(499, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Search with:";
            // 
            // labelSecurity
            // 
            this.labelSecurity.AutoSize = true;
            this.labelSecurity.Location = new System.Drawing.Point(42, 66);
            this.labelSecurity.Name = "labelSecurity";
            this.labelSecurity.Size = new System.Drawing.Size(51, 13);
            this.labelSecurity.TabIndex = 23;
            this.labelSecurity.Text = "unloaded";
            // 
            // pictureBoxFavicon
            // 
            this.pictureBoxFavicon.Location = new System.Drawing.Point(12, 58);
            this.pictureBoxFavicon.Name = "pictureBoxFavicon";
            this.pictureBoxFavicon.Size = new System.Drawing.Size(24, 24);
            this.pictureBoxFavicon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxFavicon.TabIndex = 24;
            this.pictureBoxFavicon.TabStop = false;
            // 
            // pictureBoxLoading
            // 
            this.pictureBoxLoading.Location = new System.Drawing.Point(341, 31);
            this.pictureBoxLoading.Name = "pictureBoxLoading";
            this.pictureBoxLoading.Size = new System.Drawing.Size(26, 26);
            this.pictureBoxLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxLoading.TabIndex = 25;
            this.pictureBoxLoading.TabStop = false;
            // 
            // loadingTimer
            // 
            this.loadingTimer.Enabled = true;
            // 
            // progressBarDownload
            // 
            this.progressBarDownload.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarDownload.Location = new System.Drawing.Point(157, 71);
            this.progressBarDownload.Name = "progressBarDownload";
            this.progressBarDownload.Size = new System.Drawing.Size(839, 10);
            this.progressBarDownload.TabIndex = 26;
            this.progressBarDownload.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(155, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 7);
            this.label4.TabIndex = 27;
            this.label4.Text = "Downloading progress:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(1008, 701);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.progressBarDownload);
            this.Controls.Add(this.pictureBoxLoading);
            this.Controls.Add(this.pictureBoxFavicon);
            this.Controls.Add(this.labelSecurity);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.searchEngineComboBox);
            this.Controls.Add(this.chromiumWebBrowser1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.refresh);
            this.Controls.Add(this.forward);
            this.Controls.Add(this.back);
            this.Controls.Add(this.urlTextBox);
            this.Controls.Add(this.menuStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1024, 740);
            this.Name = "Form1";
            this.Text = "IntNetViewer";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFavicon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLoading)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox urlTextBox;
        private System.Windows.Forms.Button back;
        private System.Windows.Forms.Button forward;
        private System.Windows.Forms.Button refresh;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Label label2;
        private CefSharp.WinForms.ChromiumWebBrowser chromiumWebBrowser1;
        private System.Windows.Forms.ComboBox searchEngineComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem devsOnlyToolStripMenuItem;
        private System.Windows.Forms.Label labelSecurity;
        private System.Windows.Forms.PictureBox pictureBoxFavicon;
        private System.Windows.Forms.PictureBox pictureBoxLoading;
        private System.Windows.Forms.Timer loadingTimer;
        private System.Windows.Forms.ProgressBar progressBarDownload;
        private System.Windows.Forms.ToolStripMenuItem launchIntNetViewerWithTabbedViewToolStripMenuItem;
        private System.Windows.Forms.Label label4;
    }
}

