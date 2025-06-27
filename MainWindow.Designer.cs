using System.Windows.Forms;

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.holdTimer = new System.Windows.Forms.Timer(this.components);
            this.cefToolTipStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.urlPanel = new System.Windows.Forms.Panel();
            this.addressComboBox = new System.Windows.Forms.ComboBox();
            this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newTabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bookmarksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.devToolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fullscreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.legacyModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.writeLineToConsoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.writeLineToConsoleDifferentMethodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notificationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testErrorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importantNotificationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dlWithoutChromiumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getAppPathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hangUiThreadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testVideoPlayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.repopulateBookmarksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitWithoutCallingFormClosingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listHistoryToConsoleDebugOnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listHistoryToMessageBoxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newIETabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newCefSharpTabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.borderlessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.applyThemeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getProcessNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newNotificationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newNotificationyesPriorityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addBookmarkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openDownloadsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resizeWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.x2160ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x1440ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x1080ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x900ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x768ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x720ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x480ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.x2400ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x1536ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x1200ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x1050ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x960ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x864ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x768ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.x600ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x480ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.x200ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.checkForUpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
            this.menuStripContainer = new System.Windows.Forms.ToolStripContainer();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.pixlPlaya5OnYouTubeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pixlPlaya5OnGitHubToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backButton = new System.Windows.Forms.Button();
            this.forwardButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.refreshButton = new System.Windows.Forms.Button();
            this.labelLoading = new System.Windows.Forms.Label();
            this.homeToolStripButton = new System.Windows.Forms.Button();
            this.navPanel = new System.Windows.Forms.Panel();
            this.mainCefPanel = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.bkmkTSCtn = new System.Windows.Forms.ToolStripContainer();
            this.historyMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.statusStrip1.SuspendLayout();
            this.urlPanel.SuspendLayout();
            this.menuStripContainer.TopToolStripPanel.SuspendLayout();
            this.menuStripContainer.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.navPanel.SuspendLayout();
            this.bkmkTSCtn.TopToolStripPanel.SuspendLayout();
            this.bkmkTSCtn.SuspendLayout();
            this.SuspendLayout();
            // 
            // holdTimer
            // 
            this.holdTimer.Interval = 50;
            this.holdTimer.Tick += new System.EventHandler(this.HoldTimer_Tick);
            // 
            // cefToolTipStatusLabel
            // 
            this.cefToolTipStatusLabel.Name = "cefToolTipStatusLabel";
            this.cefToolTipStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cefToolTipStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 539);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(784, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "URL:";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(679, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(29, 20);
            this.button1.TabIndex = 2;
            this.button1.Text = "Go";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.GoButton_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(716, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(65, 20);
            this.button2.TabIndex = 3;
            this.button2.Text = "New Tab";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.NewTabButton_Click);
            // 
            // urlPanel
            // 
            this.urlPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.urlPanel.Controls.Add(this.addressComboBox);
            this.urlPanel.Controls.Add(this.button2);
            this.urlPanel.Controls.Add(this.button1);
            this.urlPanel.Controls.Add(this.label1);
            this.urlPanel.Location = new System.Drawing.Point(0, 50);
            this.urlPanel.Name = "urlPanel";
            this.urlPanel.Size = new System.Drawing.Size(784, 21);
            this.urlPanel.TabIndex = 2;
            // 
            // addressComboBox
            // 
            this.addressComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addressComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.addressComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.addressComboBox.FormattingEnabled = true;
            this.addressComboBox.Location = new System.Drawing.Point(43, 0);
            this.addressComboBox.Name = "addressComboBox";
            this.addressComboBox.Size = new System.Drawing.Size(630, 21);
            this.addressComboBox.TabIndex = 4;
            this.addressComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.addressComboBox_KeyDown);
            // 
            // BottomToolStripPanel
            // 
            this.BottomToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.BottomToolStripPanel.Name = "BottomToolStripPanel";
            this.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.BottomToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.BottomToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // TopToolStripPanel
            // 
            this.TopToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.TopToolStripPanel.Name = "TopToolStripPanel";
            this.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.TopToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.TopToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newWindowToolStripMenuItem,
            this.newTabToolStripMenuItem,
            this.moreToolStripMenuItem,
            this.checkForUpdateToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newWindowToolStripMenuItem
            // 
            this.newWindowToolStripMenuItem.Name = "newWindowToolStripMenuItem";
            this.newWindowToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newWindowToolStripMenuItem.Text = "New window";
            this.newWindowToolStripMenuItem.Click += new System.EventHandler(this.NewWindowToolStripMenuItem_Click);
            // 
            // newTabToolStripMenuItem
            // 
            this.newTabToolStripMenuItem.Name = "newTabToolStripMenuItem";
            this.newTabToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newTabToolStripMenuItem.Text = "New tab";
            this.newTabToolStripMenuItem.Click += new System.EventHandler(this.NewTabToolStripMenuItem_Click);
            // 
            // moreToolStripMenuItem
            // 
            this.moreToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.historyToolStripMenuItem,
            this.bookmarksToolStripMenuItem,
            this.debugToolStripMenuItem,
            this.clearHistoryToolStripMenuItem,
            this.addBookmarkToolStripMenuItem,
            this.openDownloadsToolStripMenuItem,
            this.resizeWindowToolStripMenuItem});
            this.moreToolStripMenuItem.Name = "moreToolStripMenuItem";
            this.moreToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.moreToolStripMenuItem.Text = "More items";
            // 
            // historyToolStripMenuItem
            // 
            this.historyToolStripMenuItem.Name = "historyToolStripMenuItem";
            this.historyToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.historyToolStripMenuItem.Text = "History";
            this.historyToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.HistoryToolStripMenuItem_DropDownItemClicked);
            this.historyToolStripMenuItem.Click += new System.EventHandler(this.HistoryToolStripMenuItem_Click);
            this.historyToolStripMenuItem.MouseEnter += new System.EventHandler(this.HistoryToolStripMenuItem_MouseEnter);
            // 
            // bookmarksToolStripMenuItem
            // 
            this.bookmarksToolStripMenuItem.Name = "bookmarksToolStripMenuItem";
            this.bookmarksToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.bookmarksToolStripMenuItem.Text = "Bookmarks";
            this.bookmarksToolStripMenuItem.Click += new System.EventHandler(this.BookmarksToolStripMenuItem_Click);
            // 
            // debugToolStripMenuItem
            // 
            this.debugToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.devToolsToolStripMenuItem,
            this.fullscreenToolStripMenuItem,
            this.legacyModeToolStripMenuItem,
            this.writeLineToConsoleToolStripMenuItem,
            this.writeLineToConsoleDifferentMethodToolStripMenuItem,
            this.notificationToolStripMenuItem,
            this.testErrorToolStripMenuItem,
            this.importantNotificationToolStripMenuItem,
            this.dlWithoutChromiumToolStripMenuItem,
            this.getAppPathToolStripMenuItem,
            this.hangUiThreadToolStripMenuItem,
            this.testVideoPlayerToolStripMenuItem,
            this.restartToolStripMenuItem,
            this.repopulateBookmarksToolStripMenuItem,
            this.exitWithoutCallingFormClosingToolStripMenuItem,
            this.listHistoryToConsoleDebugOnlyToolStripMenuItem,
            this.listHistoryToMessageBoxToolStripMenuItem,
            this.newIETabToolStripMenuItem,
            this.newCefSharpTabToolStripMenuItem,
            this.borderlessToolStripMenuItem,
            this.applyThemeToolStripMenuItem,
            this.getProcessNameToolStripMenuItem,
            this.newNotificationToolStripMenuItem,
            this.newNotificationyesPriorityToolStripMenuItem});
            this.debugToolStripMenuItem.Name = "debugToolStripMenuItem";
            this.debugToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.debugToolStripMenuItem.Text = "Debug";
            this.debugToolStripMenuItem.Visible = false;
            // 
            // devToolsToolStripMenuItem
            // 
            this.devToolsToolStripMenuItem.Name = "devToolsToolStripMenuItem";
            this.devToolsToolStripMenuItem.Size = new System.Drawing.Size(282, 22);
            this.devToolsToolStripMenuItem.Text = "DevTools";
            this.devToolsToolStripMenuItem.Click += new System.EventHandler(this.DevToolsToolStripMenuItem_Click);
            // 
            // fullscreenToolStripMenuItem
            // 
            this.fullscreenToolStripMenuItem.Name = "fullscreenToolStripMenuItem";
            this.fullscreenToolStripMenuItem.Size = new System.Drawing.Size(282, 22);
            this.fullscreenToolStripMenuItem.Text = "Fullscreen";
            this.fullscreenToolStripMenuItem.Click += new System.EventHandler(this.FullscreenToolStripMenuItem_Click);
            // 
            // legacyModeToolStripMenuItem
            // 
            this.legacyModeToolStripMenuItem.Name = "legacyModeToolStripMenuItem";
            this.legacyModeToolStripMenuItem.Size = new System.Drawing.Size(282, 22);
            this.legacyModeToolStripMenuItem.Text = "legacy mode";
            this.legacyModeToolStripMenuItem.Click += new System.EventHandler(this.LegacyModeToolStripMenuItem_Click);
            // 
            // writeLineToConsoleToolStripMenuItem
            // 
            this.writeLineToConsoleToolStripMenuItem.Name = "writeLineToConsoleToolStripMenuItem";
            this.writeLineToConsoleToolStripMenuItem.Size = new System.Drawing.Size(282, 22);
            this.writeLineToConsoleToolStripMenuItem.Text = "write line to console";
            this.writeLineToConsoleToolStripMenuItem.Click += new System.EventHandler(this.WriteLineToConsoleToolStripMenuItem_Click);
            // 
            // writeLineToConsoleDifferentMethodToolStripMenuItem
            // 
            this.writeLineToConsoleDifferentMethodToolStripMenuItem.Name = "writeLineToConsoleDifferentMethodToolStripMenuItem";
            this.writeLineToConsoleDifferentMethodToolStripMenuItem.Size = new System.Drawing.Size(282, 22);
            this.writeLineToConsoleDifferentMethodToolStripMenuItem.Text = "write line to console (Different method)";
            this.writeLineToConsoleDifferentMethodToolStripMenuItem.Click += new System.EventHandler(this.WriteLineToConsoleDifferentMethodToolStripMenuItem_Click);
            // 
            // notificationToolStripMenuItem
            // 
            this.notificationToolStripMenuItem.Name = "notificationToolStripMenuItem";
            this.notificationToolStripMenuItem.Size = new System.Drawing.Size(282, 22);
            this.notificationToolStripMenuItem.Text = "notification";
            this.notificationToolStripMenuItem.Click += new System.EventHandler(this.NotificationToolStripMenuItem_Click);
            // 
            // testErrorToolStripMenuItem
            // 
            this.testErrorToolStripMenuItem.Name = "testErrorToolStripMenuItem";
            this.testErrorToolStripMenuItem.Size = new System.Drawing.Size(282, 22);
            this.testErrorToolStripMenuItem.Text = "Test error";
            this.testErrorToolStripMenuItem.Click += new System.EventHandler(this.TestErrorToolStripMenuItem_Click);
            // 
            // importantNotificationToolStripMenuItem
            // 
            this.importantNotificationToolStripMenuItem.Name = "importantNotificationToolStripMenuItem";
            this.importantNotificationToolStripMenuItem.Size = new System.Drawing.Size(282, 22);
            this.importantNotificationToolStripMenuItem.Text = "important notification";
            this.importantNotificationToolStripMenuItem.Click += new System.EventHandler(this.ImportantNotificationToolStripMenuItem_Click);
            // 
            // dlWithoutChromiumToolStripMenuItem
            // 
            this.dlWithoutChromiumToolStripMenuItem.Name = "dlWithoutChromiumToolStripMenuItem";
            this.dlWithoutChromiumToolStripMenuItem.Size = new System.Drawing.Size(282, 22);
            this.dlWithoutChromiumToolStripMenuItem.Text = "dl without chromium";
            this.dlWithoutChromiumToolStripMenuItem.Click += new System.EventHandler(this.DlWithoutChromiumToolStripMenuItem_Click);
            // 
            // getAppPathToolStripMenuItem
            // 
            this.getAppPathToolStripMenuItem.Name = "getAppPathToolStripMenuItem";
            this.getAppPathToolStripMenuItem.Size = new System.Drawing.Size(282, 22);
            this.getAppPathToolStripMenuItem.Text = "get app path";
            this.getAppPathToolStripMenuItem.Click += new System.EventHandler(this.GetAppPathToolStripMenuItem_Click);
            // 
            // hangUiThreadToolStripMenuItem
            // 
            this.hangUiThreadToolStripMenuItem.Name = "hangUiThreadToolStripMenuItem";
            this.hangUiThreadToolStripMenuItem.Size = new System.Drawing.Size(282, 22);
            this.hangUiThreadToolStripMenuItem.Text = "hang ui thread (Doesn\'t work)";
            this.hangUiThreadToolStripMenuItem.Click += new System.EventHandler(this.HangUiThreadToolStripMenuItem_Click);
            // 
            // testVideoPlayerToolStripMenuItem
            // 
            this.testVideoPlayerToolStripMenuItem.Name = "testVideoPlayerToolStripMenuItem";
            this.testVideoPlayerToolStripMenuItem.Size = new System.Drawing.Size(282, 22);
            this.testVideoPlayerToolStripMenuItem.Text = "test video player";
            this.testVideoPlayerToolStripMenuItem.Click += new System.EventHandler(this.TestVideoPlayerToolStripMenuItem_Click);
            // 
            // restartToolStripMenuItem
            // 
            this.restartToolStripMenuItem.Name = "restartToolStripMenuItem";
            this.restartToolStripMenuItem.Size = new System.Drawing.Size(282, 22);
            this.restartToolStripMenuItem.Text = "restart";
            this.restartToolStripMenuItem.Click += new System.EventHandler(this.RestartToolStripMenuItem_Click);
            // 
            // repopulateBookmarksToolStripMenuItem
            // 
            this.repopulateBookmarksToolStripMenuItem.Name = "repopulateBookmarksToolStripMenuItem";
            this.repopulateBookmarksToolStripMenuItem.Size = new System.Drawing.Size(282, 22);
            this.repopulateBookmarksToolStripMenuItem.Text = "repopulate bookmarks";
            this.repopulateBookmarksToolStripMenuItem.Click += new System.EventHandler(this.RepopulateBookmarksToolStripMenuItem_Click);
            // 
            // exitWithoutCallingFormClosingToolStripMenuItem
            // 
            this.exitWithoutCallingFormClosingToolStripMenuItem.Name = "exitWithoutCallingFormClosingToolStripMenuItem";
            this.exitWithoutCallingFormClosingToolStripMenuItem.Size = new System.Drawing.Size(282, 22);
            this.exitWithoutCallingFormClosingToolStripMenuItem.Text = "Exit without calling FormClosing";
            this.exitWithoutCallingFormClosingToolStripMenuItem.Click += new System.EventHandler(this.ExitWithoutCallingFormClosingToolStripMenuItem_Click);
            // 
            // listHistoryToConsoleDebugOnlyToolStripMenuItem
            // 
            this.listHistoryToConsoleDebugOnlyToolStripMenuItem.Name = "listHistoryToConsoleDebugOnlyToolStripMenuItem";
            this.listHistoryToConsoleDebugOnlyToolStripMenuItem.Size = new System.Drawing.Size(282, 22);
            this.listHistoryToConsoleDebugOnlyToolStripMenuItem.Text = "List history to console (Debug only)";
            this.listHistoryToConsoleDebugOnlyToolStripMenuItem.Click += new System.EventHandler(this.ListHistoryToConsoleDebugOnlyToolStripMenuItem_Click);
            // 
            // listHistoryToMessageBoxToolStripMenuItem
            // 
            this.listHistoryToMessageBoxToolStripMenuItem.Name = "listHistoryToMessageBoxToolStripMenuItem";
            this.listHistoryToMessageBoxToolStripMenuItem.Size = new System.Drawing.Size(282, 22);
            this.listHistoryToMessageBoxToolStripMenuItem.Text = "List History to MessageBox";
            this.listHistoryToMessageBoxToolStripMenuItem.Click += new System.EventHandler(this.ListHistoryToMessageBoxToolStripMenuItem_Click);
            // 
            // newIETabToolStripMenuItem
            // 
            this.newIETabToolStripMenuItem.Name = "newIETabToolStripMenuItem";
            this.newIETabToolStripMenuItem.Size = new System.Drawing.Size(282, 22);
            this.newIETabToolStripMenuItem.Text = "New IE Tab";
            this.newIETabToolStripMenuItem.Click += new System.EventHandler(this.newIETabToolStripMenuItem_Click);
            // 
            // newCefSharpTabToolStripMenuItem
            // 
            this.newCefSharpTabToolStripMenuItem.Name = "newCefSharpTabToolStripMenuItem";
            this.newCefSharpTabToolStripMenuItem.Size = new System.Drawing.Size(282, 22);
            this.newCefSharpTabToolStripMenuItem.Text = "New CefSharp Tab";
            this.newCefSharpTabToolStripMenuItem.Click += new System.EventHandler(this.newCefSharpTabToolStripMenuItem_Click);
            // 
            // borderlessToolStripMenuItem
            // 
            this.borderlessToolStripMenuItem.Name = "borderlessToolStripMenuItem";
            this.borderlessToolStripMenuItem.Size = new System.Drawing.Size(282, 22);
            this.borderlessToolStripMenuItem.Text = "borderless";
            this.borderlessToolStripMenuItem.Click += new System.EventHandler(this.borderlessToolStripMenuItem_Click);
            // 
            // applyThemeToolStripMenuItem
            // 
            this.applyThemeToolStripMenuItem.Name = "applyThemeToolStripMenuItem";
            this.applyThemeToolStripMenuItem.Size = new System.Drawing.Size(282, 22);
            this.applyThemeToolStripMenuItem.Text = "apply theme";
            this.applyThemeToolStripMenuItem.Click += new System.EventHandler(this.applyThemeToolStripMenuItem_Click);
            // 
            // getProcessNameToolStripMenuItem
            // 
            this.getProcessNameToolStripMenuItem.Name = "getProcessNameToolStripMenuItem";
            this.getProcessNameToolStripMenuItem.Size = new System.Drawing.Size(282, 22);
            this.getProcessNameToolStripMenuItem.Text = "Get process name";
            this.getProcessNameToolStripMenuItem.Click += new System.EventHandler(this.getProcessNameToolStripMenuItem_Click);
            // 
            // newNotificationToolStripMenuItem
            // 
            this.newNotificationToolStripMenuItem.Name = "newNotificationToolStripMenuItem";
            this.newNotificationToolStripMenuItem.Size = new System.Drawing.Size(282, 22);
            this.newNotificationToolStripMenuItem.Text = "new notification (no priority)";
            this.newNotificationToolStripMenuItem.Click += new System.EventHandler(this.newNotificationToolStripMenuItem_Click);
            // 
            // newNotificationyesPriorityToolStripMenuItem
            // 
            this.newNotificationyesPriorityToolStripMenuItem.Name = "newNotificationyesPriorityToolStripMenuItem";
            this.newNotificationyesPriorityToolStripMenuItem.Size = new System.Drawing.Size(282, 22);
            this.newNotificationyesPriorityToolStripMenuItem.Text = "new notification (yes priority)";
            this.newNotificationyesPriorityToolStripMenuItem.Click += new System.EventHandler(this.newNotificationyesPriorityToolStripMenuItem_Click);
            // 
            // clearHistoryToolStripMenuItem
            // 
            this.clearHistoryToolStripMenuItem.Name = "clearHistoryToolStripMenuItem";
            this.clearHistoryToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.clearHistoryToolStripMenuItem.Text = "Clear History";
            this.clearHistoryToolStripMenuItem.Click += new System.EventHandler(this.ClearHistoryToolStripMenuItem_Click);
            // 
            // addBookmarkToolStripMenuItem
            // 
            this.addBookmarkToolStripMenuItem.Name = "addBookmarkToolStripMenuItem";
            this.addBookmarkToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.addBookmarkToolStripMenuItem.Text = "Add Bookmark";
            this.addBookmarkToolStripMenuItem.Click += new System.EventHandler(this.AddBookmarkToolStripMenuItem_Click);
            // 
            // openDownloadsToolStripMenuItem
            // 
            this.openDownloadsToolStripMenuItem.Name = "openDownloadsToolStripMenuItem";
            this.openDownloadsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openDownloadsToolStripMenuItem.Text = "Open downloads";
            this.openDownloadsToolStripMenuItem.Click += new System.EventHandler(this.BtnDownloads_Click);
            // 
            // resizeWindowToolStripMenuItem
            // 
            this.resizeWindowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripSeparator2,
            this.x2160ToolStripMenuItem,
            this.x1440ToolStripMenuItem,
            this.x1080ToolStripMenuItem,
            this.x900ToolStripMenuItem,
            this.x768ToolStripMenuItem,
            this.x720ToolStripMenuItem,
            this.x480ToolStripMenuItem,
            this.toolStripSeparator3,
            this.toolStripMenuItem3,
            this.toolStripSeparator4,
            this.x2400ToolStripMenuItem,
            this.x1536ToolStripMenuItem,
            this.x1200ToolStripMenuItem,
            this.x1050ToolStripMenuItem,
            this.x960ToolStripMenuItem,
            this.x864ToolStripMenuItem,
            this.x768ToolStripMenuItem1,
            this.x600ToolStripMenuItem,
            this.x480ToolStripMenuItem1,
            this.toolStripSeparator5,
            this.x200ToolStripMenuItem,
            this.toolStripMenuItem1});
            this.resizeWindowToolStripMenuItem.Name = "resizeWindowToolStripMenuItem";
            this.resizeWindowToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.resizeWindowToolStripMenuItem.Text = "Resize window";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Enabled = false;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(202, 22);
            this.toolStripMenuItem2.Text = "16:9";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(199, 6);
            // 
            // x2160ToolStripMenuItem
            // 
            this.x2160ToolStripMenuItem.Name = "x2160ToolStripMenuItem";
            this.x2160ToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.x2160ToolStripMenuItem.Text = "3840x2160";
            this.x2160ToolStripMenuItem.Click += new System.EventHandler(this.x2160ToolStripMenuItem_Click);
            // 
            // x1440ToolStripMenuItem
            // 
            this.x1440ToolStripMenuItem.Name = "x1440ToolStripMenuItem";
            this.x1440ToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.x1440ToolStripMenuItem.Text = "2560x1440";
            this.x1440ToolStripMenuItem.Click += new System.EventHandler(this.x1440ToolStripMenuItem_Click);
            // 
            // x1080ToolStripMenuItem
            // 
            this.x1080ToolStripMenuItem.Name = "x1080ToolStripMenuItem";
            this.x1080ToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.x1080ToolStripMenuItem.Text = "1920x1080";
            this.x1080ToolStripMenuItem.Click += new System.EventHandler(this.x1080ToolStripMenuItem_Click);
            // 
            // x900ToolStripMenuItem
            // 
            this.x900ToolStripMenuItem.Name = "x900ToolStripMenuItem";
            this.x900ToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.x900ToolStripMenuItem.Text = "1600x900";
            this.x900ToolStripMenuItem.Click += new System.EventHandler(this.x900ToolStripMenuItem_Click);
            // 
            // x768ToolStripMenuItem
            // 
            this.x768ToolStripMenuItem.Name = "x768ToolStripMenuItem";
            this.x768ToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.x768ToolStripMenuItem.Text = "1366x768";
            this.x768ToolStripMenuItem.Click += new System.EventHandler(this.x768ToolStripMenuItem_Click);
            // 
            // x720ToolStripMenuItem
            // 
            this.x720ToolStripMenuItem.Name = "x720ToolStripMenuItem";
            this.x720ToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.x720ToolStripMenuItem.Text = "1280x720";
            this.x720ToolStripMenuItem.Click += new System.EventHandler(this.x720ToolStripMenuItem_Click);
            // 
            // x480ToolStripMenuItem
            // 
            this.x480ToolStripMenuItem.Name = "x480ToolStripMenuItem";
            this.x480ToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.x480ToolStripMenuItem.Text = "854x480";
            this.x480ToolStripMenuItem.Click += new System.EventHandler(this.x480ToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(199, 6);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Enabled = false;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(202, 22);
            this.toolStripMenuItem3.Text = "4:3";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(199, 6);
            // 
            // x2400ToolStripMenuItem
            // 
            this.x2400ToolStripMenuItem.Name = "x2400ToolStripMenuItem";
            this.x2400ToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.x2400ToolStripMenuItem.Text = "3200x2400";
            this.x2400ToolStripMenuItem.Click += new System.EventHandler(this.x2400ToolStripMenuItem_Click);
            // 
            // x1536ToolStripMenuItem
            // 
            this.x1536ToolStripMenuItem.Name = "x1536ToolStripMenuItem";
            this.x1536ToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.x1536ToolStripMenuItem.Text = "2048x1536";
            this.x1536ToolStripMenuItem.Click += new System.EventHandler(this.x1536ToolStripMenuItem_Click);
            // 
            // x1200ToolStripMenuItem
            // 
            this.x1200ToolStripMenuItem.Name = "x1200ToolStripMenuItem";
            this.x1200ToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.x1200ToolStripMenuItem.Text = "1600x1200";
            this.x1200ToolStripMenuItem.Click += new System.EventHandler(this.x1200ToolStripMenuItem_Click);
            // 
            // x1050ToolStripMenuItem
            // 
            this.x1050ToolStripMenuItem.Name = "x1050ToolStripMenuItem";
            this.x1050ToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.x1050ToolStripMenuItem.Text = "1400x1050";
            this.x1050ToolStripMenuItem.Click += new System.EventHandler(this.x1050ToolStripMenuItem_Click);
            // 
            // x960ToolStripMenuItem
            // 
            this.x960ToolStripMenuItem.Name = "x960ToolStripMenuItem";
            this.x960ToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.x960ToolStripMenuItem.Text = "1280x960";
            this.x960ToolStripMenuItem.Click += new System.EventHandler(this.x960ToolStripMenuItem_Click);
            // 
            // x864ToolStripMenuItem
            // 
            this.x864ToolStripMenuItem.Name = "x864ToolStripMenuItem";
            this.x864ToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.x864ToolStripMenuItem.Text = "1152x864";
            this.x864ToolStripMenuItem.Click += new System.EventHandler(this.x864ToolStripMenuItem_Click);
            // 
            // x768ToolStripMenuItem1
            // 
            this.x768ToolStripMenuItem1.Name = "x768ToolStripMenuItem1";
            this.x768ToolStripMenuItem1.Size = new System.Drawing.Size(202, 22);
            this.x768ToolStripMenuItem1.Text = "1024x768";
            this.x768ToolStripMenuItem1.Click += new System.EventHandler(this.x768ToolStripMenuItem1_Click);
            // 
            // x600ToolStripMenuItem
            // 
            this.x600ToolStripMenuItem.Name = "x600ToolStripMenuItem";
            this.x600ToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.x600ToolStripMenuItem.Text = "800x600";
            this.x600ToolStripMenuItem.Click += new System.EventHandler(this.x600ToolStripMenuItem_Click);
            // 
            // x480ToolStripMenuItem1
            // 
            this.x480ToolStripMenuItem1.Name = "x480ToolStripMenuItem1";
            this.x480ToolStripMenuItem1.Size = new System.Drawing.Size(202, 22);
            this.x480ToolStripMenuItem1.Text = "640x480";
            this.x480ToolStripMenuItem1.Click += new System.EventHandler(this.x480ToolStripMenuItem1_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(199, 6);
            // 
            // x200ToolStripMenuItem
            // 
            this.x200ToolStripMenuItem.Name = "x200ToolStripMenuItem";
            this.x200ToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.x200ToolStripMenuItem.Text = "400x200 (minimum size)";
            this.x200ToolStripMenuItem.Click += new System.EventHandler(this.x200ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(202, 22);
            // 
            // checkForUpdateToolStripMenuItem
            // 
            this.checkForUpdateToolStripMenuItem.Name = "checkForUpdateToolStripMenuItem";
            this.checkForUpdateToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.checkForUpdateToolStripMenuItem.Text = "Check for update";
            this.checkForUpdateToolStripMenuItem.Click += new System.EventHandler(this.CheckForUpdateToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.SettingsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // RightToolStripPanel
            // 
            this.RightToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.RightToolStripPanel.Name = "RightToolStripPanel";
            this.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.RightToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.RightToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // LeftToolStripPanel
            // 
            this.LeftToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftToolStripPanel.Name = "LeftToolStripPanel";
            this.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.LeftToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.LeftToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // ContentPanel
            // 
            this.ContentPanel.Size = new System.Drawing.Size(784, 1);
            // 
            // menuStripContainer
            // 
            this.menuStripContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // menuStripContainer.ContentPanel
            // 
            this.menuStripContainer.ContentPanel.Size = new System.Drawing.Size(784, 0);
            this.menuStripContainer.Location = new System.Drawing.Point(0, 0);
            this.menuStripContainer.Name = "menuStripContainer";
            this.menuStripContainer.Size = new System.Drawing.Size(784, 24);
            this.menuStripContainer.TabIndex = 6;
            this.menuStripContainer.Text = "toolStripContainer3";
            // 
            // menuStripContainer.TopToolStripPanel
            // 
            this.menuStripContainer.TopToolStripPanel.Controls.Add(this.menuStrip1);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.toolStripSeparator1,
            this.pixlPlaya5OnYouTubeToolStripMenuItem,
            this.pixlPlaya5OnGitHubToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(190, 6);
            // 
            // pixlPlaya5OnYouTubeToolStripMenuItem
            // 
            this.pixlPlaya5OnYouTubeToolStripMenuItem.Name = "pixlPlaya5OnYouTubeToolStripMenuItem";
            this.pixlPlaya5OnYouTubeToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.pixlPlaya5OnYouTubeToolStripMenuItem.Text = "PixlPlaya5 on YouTube";
            this.pixlPlaya5OnYouTubeToolStripMenuItem.Click += new System.EventHandler(this.PixlPlaya5OnYouTubeToolStripMenuItem_Click);
            // 
            // pixlPlaya5OnGitHubToolStripMenuItem
            // 
            this.pixlPlaya5OnGitHubToolStripMenuItem.Name = "pixlPlaya5OnGitHubToolStripMenuItem";
            this.pixlPlaya5OnGitHubToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.pixlPlaya5OnGitHubToolStripMenuItem.Text = "PixlPlaya5 on GitHub";
            this.pixlPlaya5OnGitHubToolStripMenuItem.Click += new System.EventHandler(this.PixlPlaya5OnGitHubToolStripMenuItem_Click);
            // 
            // backButton
            // 
            this.backButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.backButton.Location = new System.Drawing.Point(8, 3);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 20);
            this.backButton.TabIndex = 0;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.BackButton_Click);
            this.backButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BackButton_MouseDown);
            this.backButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BackButton_MouseUp);
            // 
            // forwardButton
            // 
            this.forwardButton.Location = new System.Drawing.Point(89, 3);
            this.forwardButton.Name = "forwardButton";
            this.forwardButton.Size = new System.Drawing.Size(75, 20);
            this.forwardButton.TabIndex = 1;
            this.forwardButton.Text = "Forward";
            this.forwardButton.UseVisualStyleBackColor = true;
            this.forwardButton.Click += new System.EventHandler(this.ForwardButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(170, 4);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 20);
            this.stopButton.TabIndex = 2;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(170, 3);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(75, 20);
            this.refreshButton.TabIndex = 3;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // labelLoading
            // 
            this.labelLoading.AutoSize = true;
            this.labelLoading.Location = new System.Drawing.Point(332, 7);
            this.labelLoading.Name = "labelLoading";
            this.labelLoading.Size = new System.Drawing.Size(50, 13);
            this.labelLoading.TabIndex = 4;
            this.labelLoading.Text = "loading...";
            // 
            // homeToolStripButton
            // 
            this.homeToolStripButton.Location = new System.Drawing.Point(251, 3);
            this.homeToolStripButton.Name = "homeToolStripButton";
            this.homeToolStripButton.Size = new System.Drawing.Size(75, 20);
            this.homeToolStripButton.TabIndex = 5;
            this.homeToolStripButton.Text = "Home";
            this.homeToolStripButton.UseVisualStyleBackColor = true;
            this.homeToolStripButton.Click += new System.EventHandler(this.HomeToolStripButton_Click);
            // 
            // navPanel
            // 
            this.navPanel.Controls.Add(this.homeToolStripButton);
            this.navPanel.Controls.Add(this.labelLoading);
            this.navPanel.Controls.Add(this.refreshButton);
            this.navPanel.Controls.Add(this.stopButton);
            this.navPanel.Controls.Add(this.forwardButton);
            this.navPanel.Controls.Add(this.backButton);
            this.navPanel.Location = new System.Drawing.Point(0, 24);
            this.navPanel.Name = "navPanel";
            this.navPanel.Size = new System.Drawing.Size(784, 26);
            this.navPanel.TabIndex = 7;
            // 
            // mainCefPanel
            // 
            this.mainCefPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainCefPanel.Location = new System.Drawing.Point(0, 95);
            this.mainCefPanel.Name = "mainCefPanel";
            this.mainCefPanel.Size = new System.Drawing.Size(784, 443);
            this.mainCefPanel.TabIndex = 8;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(111, 25);
            this.toolStrip1.TabIndex = 0;
            // 
            // bkmkTSCtn
            // 
            this.bkmkTSCtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bkmkTSCtn.BottomToolStripPanelVisible = false;
            // 
            // bkmkTSCtn.ContentPanel
            // 
            this.bkmkTSCtn.ContentPanel.Size = new System.Drawing.Size(784, 1);
            this.bkmkTSCtn.LeftToolStripPanelVisible = false;
            this.bkmkTSCtn.Location = new System.Drawing.Point(0, 71);
            this.bkmkTSCtn.Name = "bkmkTSCtn";
            this.bkmkTSCtn.RightToolStripPanelVisible = false;
            this.bkmkTSCtn.Size = new System.Drawing.Size(784, 26);
            this.bkmkTSCtn.TabIndex = 9;
            this.bkmkTSCtn.Text = "toolStripContainer1";
            // 
            // bkmkTSCtn.TopToolStripPanel
            // 
            this.bkmkTSCtn.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // historyMenu
            // 
            this.historyMenu.Name = "contextMenuStrip1";
            this.historyMenu.Size = new System.Drawing.Size(61, 4);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.bkmkTSCtn);
            this.Controls.Add(this.mainCefPanel);
            this.Controls.Add(this.navPanel);
            this.Controls.Add(this.menuStripContainer);
            this.Controls.Add(this.urlPanel);
            this.Controls.Add(this.statusStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(8192, 4320);
            this.MinimumSize = new System.Drawing.Size(400, 200);
            this.Name = "MainWindow";
            this.Text = "IntNetViewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.Shown += new System.EventHandler(this.MainWindow_Shown);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.urlPanel.ResumeLayout(false);
            this.urlPanel.PerformLayout();
            this.menuStripContainer.TopToolStripPanel.ResumeLayout(false);
            this.menuStripContainer.TopToolStripPanel.PerformLayout();
            this.menuStripContainer.ResumeLayout(false);
            this.menuStripContainer.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.navPanel.ResumeLayout(false);
            this.navPanel.PerformLayout();
            this.bkmkTSCtn.TopToolStripPanel.ResumeLayout(false);
            this.bkmkTSCtn.TopToolStripPanel.PerformLayout();
            this.bkmkTSCtn.ResumeLayout(false);
            this.bkmkTSCtn.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Timer holdTimer;
        private ToolStripStatusLabel cefToolTipStatusLabel;
        private StatusStrip statusStrip1;
        private Label label1;
        private Button button1;
        private Button button2;
        private Panel urlPanel;
        private ToolStripPanel BottomToolStripPanel;
        private ToolStripPanel TopToolStripPanel;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem newWindowToolStripMenuItem;
        private ToolStripMenuItem newTabToolStripMenuItem;
        private ToolStripMenuItem checkForUpdateToolStripMenuItem;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripPanel RightToolStripPanel;
        private ToolStripPanel LeftToolStripPanel;
        private ToolStripContentPanel ContentPanel;
        private ToolStripContainer menuStripContainer;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem pixlPlaya5OnYouTubeToolStripMenuItem;
        private ToolStripMenuItem pixlPlaya5OnGitHubToolStripMenuItem;
        private Button backButton;
        private Button forwardButton;
        private Button stopButton;
        private Button refreshButton;
        private Label labelLoading;
        private Button homeToolStripButton;
        private Panel navPanel;
        private Panel mainCefPanel;
        private ToolStrip toolStrip1;
        private ToolStripContainer bkmkTSCtn;
        private ContextMenuStrip historyMenu;
        private ComboBox addressComboBox;
        private ToolStripMenuItem moreToolStripMenuItem;
        private ToolStripMenuItem historyToolStripMenuItem;
        private ToolStripMenuItem bookmarksToolStripMenuItem;
        private ToolStripMenuItem debugToolStripMenuItem;
        private ToolStripMenuItem devToolsToolStripMenuItem;
        private ToolStripMenuItem fullscreenToolStripMenuItem;
        private ToolStripMenuItem legacyModeToolStripMenuItem;
        private ToolStripMenuItem writeLineToConsoleToolStripMenuItem;
        private ToolStripMenuItem writeLineToConsoleDifferentMethodToolStripMenuItem;
        private ToolStripMenuItem notificationToolStripMenuItem;
        private ToolStripMenuItem testErrorToolStripMenuItem;
        private ToolStripMenuItem importantNotificationToolStripMenuItem;
        private ToolStripMenuItem dlWithoutChromiumToolStripMenuItem;
        private ToolStripMenuItem getAppPathToolStripMenuItem;
        private ToolStripMenuItem hangUiThreadToolStripMenuItem;
        private ToolStripMenuItem testVideoPlayerToolStripMenuItem;
        private ToolStripMenuItem restartToolStripMenuItem;
        private ToolStripMenuItem repopulateBookmarksToolStripMenuItem;
        private ToolStripMenuItem exitWithoutCallingFormClosingToolStripMenuItem;
        private ToolStripMenuItem listHistoryToConsoleDebugOnlyToolStripMenuItem;
        private ToolStripMenuItem listHistoryToMessageBoxToolStripMenuItem;
        private ToolStripMenuItem newIETabToolStripMenuItem;
        private ToolStripMenuItem newCefSharpTabToolStripMenuItem;
        private ToolStripMenuItem borderlessToolStripMenuItem;
        private ToolStripMenuItem applyThemeToolStripMenuItem;
        private ToolStripMenuItem clearHistoryToolStripMenuItem;
        private ToolStripMenuItem addBookmarkToolStripMenuItem;
        private ToolStripMenuItem openDownloadsToolStripMenuItem;
        private ToolStripMenuItem resizeWindowToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem x2160ToolStripMenuItem;
        private ToolStripMenuItem x1440ToolStripMenuItem;
        private ToolStripMenuItem x1080ToolStripMenuItem;
        private ToolStripMenuItem x900ToolStripMenuItem;
        private ToolStripMenuItem x768ToolStripMenuItem;
        private ToolStripMenuItem x720ToolStripMenuItem;
        private ToolStripMenuItem x480ToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem x2400ToolStripMenuItem;
        private ToolStripMenuItem x1536ToolStripMenuItem;
        private ToolStripMenuItem x1200ToolStripMenuItem;
        private ToolStripMenuItem x1050ToolStripMenuItem;
        private ToolStripMenuItem x960ToolStripMenuItem;
        private ToolStripMenuItem x864ToolStripMenuItem;
        private ToolStripMenuItem x768ToolStripMenuItem1;
        private ToolStripMenuItem x600ToolStripMenuItem;
        private ToolStripMenuItem x480ToolStripMenuItem1;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripMenuItem x200ToolStripMenuItem;
        private ToolStripMenuItem getProcessNameToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem newNotificationToolStripMenuItem;
        private ToolStripMenuItem newNotificationyesPriorityToolStripMenuItem;
    }
}

