namespace IntNetViewer
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.checkForUpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.toolStripLocation = new System.Windows.Forms.ToolStrip();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripBtnBack = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnFwd = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnReload = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnHome = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnStop = new System.Windows.Forms.ToolStripButton();
            this.toolStripControls = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripBookmarks = new System.Windows.Forms.ToolStrip();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.menuStrip1.SuspendLayout();
            this.toolStripLocation.SuspendLayout();
            this.toolStripControls.SuspendLayout();
            this.toolStripBookmarks.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem1,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(624, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem1
            // 
            this.fileToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkForUpdateToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
            this.fileToolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem1.Text = "&File";
            // 
            // checkForUpdateToolStripMenuItem
            // 
            this.checkForUpdateToolStripMenuItem.Name = "checkForUpdateToolStripMenuItem";
            this.checkForUpdateToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.checkForUpdateToolStripMenuItem.Text = "Check for update";
            this.checkForUpdateToolStripMenuItem.Click += new System.EventHandler(this.checkForUpdateToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(0, 101);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(624, 317);
            this.webBrowser1.TabIndex = 59;
            // 
            // toolStripLocation
            // 
            this.toolStripLocation.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox1});
            this.toolStripLocation.Location = new System.Drawing.Point(0, 49);
            this.toolStripLocation.Name = "toolStripLocation";
            this.toolStripLocation.Size = new System.Drawing.Size(624, 25);
            this.toolStripLocation.TabIndex = 61;
            this.toolStripLocation.Text = "toolStrip2";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 419);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(624, 22);
            this.statusStrip1.TabIndex = 63;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripBtnBack
            // 
            this.toolStripBtnBack.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnBack.Image")));
            this.toolStripBtnBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnBack.Name = "toolStripBtnBack";
            this.toolStripBtnBack.Size = new System.Drawing.Size(52, 22);
            this.toolStripBtnBack.Text = "Back";
            this.toolStripBtnBack.Click += new System.EventHandler(this.toolStripBtnBack_Click);
            // 
            // toolStripBtnFwd
            // 
            this.toolStripBtnFwd.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnFwd.Image")));
            this.toolStripBtnFwd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnFwd.Name = "toolStripBtnFwd";
            this.toolStripBtnFwd.Size = new System.Drawing.Size(70, 22);
            this.toolStripBtnFwd.Text = "Forward";
            this.toolStripBtnFwd.Click += new System.EventHandler(this.toolStripBtnFwd_Click);
            // 
            // toolStripBtnReload
            // 
            this.toolStripBtnReload.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnReload.Image")));
            this.toolStripBtnReload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnReload.Name = "toolStripBtnReload";
            this.toolStripBtnReload.Size = new System.Drawing.Size(63, 22);
            this.toolStripBtnReload.Text = "Reload";
            this.toolStripBtnReload.Click += new System.EventHandler(this.toolStripBtnReload_Click);
            // 
            // toolStripBtnHome
            // 
            this.toolStripBtnHome.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnHome.Image")));
            this.toolStripBtnHome.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnHome.Name = "toolStripBtnHome";
            this.toolStripBtnHome.Size = new System.Drawing.Size(60, 22);
            this.toolStripBtnHome.Text = "Home";
            this.toolStripBtnHome.Click += new System.EventHandler(this.toolStripBtnHome_Click);
            // 
            // toolStripBtnStop
            // 
            this.toolStripBtnStop.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnStop.Image")));
            this.toolStripBtnStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnStop.Name = "toolStripBtnStop";
            this.toolStripBtnStop.Size = new System.Drawing.Size(51, 22);
            this.toolStripBtnStop.Text = "Stop";
            this.toolStripBtnStop.Click += new System.EventHandler(this.toolStripBtnStop_Click);
            // 
            // toolStripControls
            // 
            this.toolStripControls.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripBtnBack,
            this.toolStripBtnFwd,
            this.toolStripBtnReload,
            this.toolStripBtnHome,
            this.toolStripBtnStop});
            this.toolStripControls.Location = new System.Drawing.Point(0, 24);
            this.toolStripControls.Name = "toolStripControls";
            this.toolStripControls.Size = new System.Drawing.Size(624, 25);
            this.toolStripControls.TabIndex = 60;
            this.toolStripControls.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(139, 22);
            this.toolStripLabel1.Text = "Bookmarks coming soon";
            // 
            // toolStripBookmarks
            // 
            this.toolStripBookmarks.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1});
            this.toolStripBookmarks.Location = new System.Drawing.Point(0, 74);
            this.toolStripBookmarks.Name = "toolStripBookmarks";
            this.toolStripBookmarks.Size = new System.Drawing.Size(624, 25);
            this.toolStripBookmarks.TabIndex = 62;
            this.toolStripBookmarks.Text = "toolStrip3";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 25);
            this.toolStripTextBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toolStripTextBox1_KeyDown);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStripBookmarks);
            this.Controls.Add(this.toolStripLocation);
            this.Controls.Add(this.toolStripControls);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.menuStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(320, 240);
            this.Name = "MainWindow";
            this.Text = "IntNetViewer";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStripLocation.ResumeLayout(false);
            this.toolStripLocation.PerformLayout();
            this.toolStripControls.ResumeLayout(false);
            this.toolStripControls.PerformLayout();
            this.toolStripBookmarks.ResumeLayout(false);
            this.toolStripBookmarks.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkForUpdateToolStripMenuItem;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.ToolStrip toolStripLocation;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripButton toolStripBtnBack;
        private System.Windows.Forms.ToolStripButton toolStripBtnFwd;
        private System.Windows.Forms.ToolStripButton toolStripBtnReload;
        private System.Windows.Forms.ToolStripButton toolStripBtnHome;
        private System.Windows.Forms.ToolStripButton toolStripBtnStop;
        private System.Windows.Forms.ToolStrip toolStripControls;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStrip toolStripBookmarks;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
    }
}

