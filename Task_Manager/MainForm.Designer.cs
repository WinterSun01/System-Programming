namespace TaskManager
{
    partial class MainForm
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
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenuFileRun = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mainMenuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenuViewTopmost = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenuViewHide = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mainMenuViewColumns = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mainMenuViewRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenuViewRefreshRate = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenuViewRateHight = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenuViewRateNormal = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenuViewRateLow = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelProcessCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageProcesses = new System.Windows.Forms.TabPage();
            this.listViewProcesses = new System.Windows.Forms.ListView();
            this.columnPID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnProcessName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuProcList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemOpenFileLocation = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemDestroy = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPagePerformance = new System.Windows.Forms.TabPage();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.mainMenu.SuspendLayout();
            this.statusStripMain.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPageProcesses.SuspendLayout();
            this.contextMenuProcList.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(1067, 28);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainMenuFileRun,
            this.toolStripSeparator1,
            this.mainMenuFileExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // mainMenuFileRun
            // 
            this.mainMenuFileRun.Name = "mainMenuFileRun";
            this.mainMenuFileRun.Size = new System.Drawing.Size(117, 26);
            this.mainMenuFileRun.Text = "Run";
            this.mainMenuFileRun.Click += new System.EventHandler(this.mainMenuFileRun_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(114, 6);
            // 
            // mainMenuFileExit
            // 
            this.mainMenuFileExit.Name = "mainMenuFileExit";
            this.mainMenuFileExit.Size = new System.Drawing.Size(117, 26);
            this.mainMenuFileExit.Text = "Exit";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainMenuViewTopmost,
            this.mainMenuViewHide,
            this.toolStripSeparator2,
            this.mainMenuViewColumns,
            this.toolStripSeparator3,
            this.mainMenuViewRefresh,
            this.mainMenuViewRefreshRate});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // mainMenuViewTopmost
            // 
            this.mainMenuViewTopmost.CheckOnClick = true;
            this.mainMenuViewTopmost.Name = "mainMenuViewTopmost";
            this.mainMenuViewTopmost.Size = new System.Drawing.Size(237, 26);
            this.mainMenuViewTopmost.Text = "Topmost";
            // 
            // mainMenuViewHide
            // 
            this.mainMenuViewHide.CheckOnClick = true;
            this.mainMenuViewHide.Name = "mainMenuViewHide";
            this.mainMenuViewHide.Size = new System.Drawing.Size(237, 26);
            this.mainMenuViewHide.Text = "Hide when minimized";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(234, 6);
            // 
            // mainMenuViewColumns
            // 
            this.mainMenuViewColumns.Name = "mainMenuViewColumns";
            this.mainMenuViewColumns.Size = new System.Drawing.Size(237, 26);
            this.mainMenuViewColumns.Text = "Select columns";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(234, 6);
            // 
            // mainMenuViewRefresh
            // 
            this.mainMenuViewRefresh.Name = "mainMenuViewRefresh";
            this.mainMenuViewRefresh.Size = new System.Drawing.Size(237, 26);
            this.mainMenuViewRefresh.Text = "Refresh";
            // 
            // mainMenuViewRefreshRate
            // 
            this.mainMenuViewRefreshRate.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainMenuViewRateHight,
            this.mainMenuViewRateNormal,
            this.mainMenuViewRateLow});
            this.mainMenuViewRefreshRate.Name = "mainMenuViewRefreshRate";
            this.mainMenuViewRefreshRate.Size = new System.Drawing.Size(237, 26);
            this.mainMenuViewRefreshRate.Text = "Refresh rate";
            // 
            // mainMenuViewRateHight
            // 
            this.mainMenuViewRateHight.Name = "mainMenuViewRateHight";
            this.mainMenuViewRateHight.Size = new System.Drawing.Size(142, 26);
            this.mainMenuViewRateHight.Text = "High";
            // 
            // mainMenuViewRateNormal
            // 
            this.mainMenuViewRateNormal.Name = "mainMenuViewRateNormal";
            this.mainMenuViewRateNormal.Size = new System.Drawing.Size(142, 26);
            this.mainMenuViewRateNormal.Text = "Normal";
            // 
            // mainMenuViewRateLow
            // 
            this.mainMenuViewRateLow.Name = "mainMenuViewRateLow";
            this.mainMenuViewRateLow.Size = new System.Drawing.Size(142, 26);
            this.mainMenuViewRateLow.Text = "Low";
            // 
            // statusStripMain
            // 
            this.statusStripMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelProcessCount});
            this.statusStripMain.Location = new System.Drawing.Point(0, 528);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStripMain.Size = new System.Drawing.Size(1067, 26);
            this.statusStripMain.TabIndex = 1;
            this.statusStripMain.Text = "statusStrip1";
            // 
            // toolStripStatusLabelProcessCount
            // 
            this.toolStripStatusLabelProcessCount.Name = "toolStripStatusLabelProcessCount";
            this.toolStripStatusLabelProcessCount.Size = new System.Drawing.Size(231, 20);
            this.toolStripStatusLabelProcessCount.Text = "toolStripStatusLabelProcessCount";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageProcesses);
            this.tabControl.Controls.Add(this.tabPagePerformance);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 28);
            this.tabControl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1067, 500);
            this.tabControl.TabIndex = 2;
            // 
            // tabPageProcesses
            // 
            this.tabPageProcesses.Controls.Add(this.listViewProcesses);
            this.tabPageProcesses.Location = new System.Drawing.Point(4, 25);
            this.tabPageProcesses.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPageProcesses.Name = "tabPageProcesses";
            this.tabPageProcesses.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPageProcesses.Size = new System.Drawing.Size(1059, 471);
            this.tabPageProcesses.TabIndex = 0;
            this.tabPageProcesses.Text = "Processes";
            this.tabPageProcesses.UseVisualStyleBackColor = true;
            // 
            // listViewProcesses
            // 
            this.listViewProcesses.AllowColumnReorder = true;
            this.listViewProcesses.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnProcessName,
            this.columnPID});
            this.listViewProcesses.ContextMenuStrip = this.contextMenuProcList;
            this.listViewProcesses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewProcesses.FullRowSelect = true;
            this.listViewProcesses.HideSelection = false;
            this.listViewProcesses.Location = new System.Drawing.Point(4, 4);
            this.listViewProcesses.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listViewProcesses.MultiSelect = false;
            this.listViewProcesses.Name = "listViewProcesses";
            this.listViewProcesses.Size = new System.Drawing.Size(1051, 463);
            this.listViewProcesses.TabIndex = 0;
            this.listViewProcesses.UseCompatibleStateImageBehavior = false;
            this.listViewProcesses.View = System.Windows.Forms.View.Details;
            this.listViewProcesses.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewProcesses_ColumnClick);
            // 
            // columnPID
            // 
            this.columnPID.Text = "PID";
            // 
            // columnProcessName
            // 
            this.columnProcessName.Text = "Name";
            // 
            // contextMenuProcList
            // 
            this.contextMenuProcList.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuProcList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemOpenFileLocation,
            this.toolStripSeparator4,
            this.toolStripMenuItemDestroy});
            this.contextMenuProcList.Name = "contextMenuProcList";
            this.contextMenuProcList.Size = new System.Drawing.Size(198, 58);
            this.contextMenuProcList.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuProcList_Opening);
            // 
            // toolStripMenuItemOpenFileLocation
            // 
            this.toolStripMenuItemOpenFileLocation.Name = "toolStripMenuItemOpenFileLocation";
            this.toolStripMenuItemOpenFileLocation.Size = new System.Drawing.Size(197, 24);
            this.toolStripMenuItemOpenFileLocation.Text = "Open file location";
            this.toolStripMenuItemOpenFileLocation.Click += new System.EventHandler(this.toolStripMenuItemOpenFileLocation_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(194, 6);
            // 
            // toolStripMenuItemDestroy
            // 
            this.toolStripMenuItemDestroy.Name = "toolStripMenuItemDestroy";
            this.toolStripMenuItemDestroy.Size = new System.Drawing.Size(197, 24);
            this.toolStripMenuItemDestroy.Text = "Destroy";
            this.toolStripMenuItemDestroy.Click += new System.EventHandler(this.destroyToolStripMenuItem_Click);
            // 
            // tabPagePerformance
            // 
            this.tabPagePerformance.Location = new System.Drawing.Point(4, 25);
            this.tabPagePerformance.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPagePerformance.Name = "tabPagePerformance";
            this.tabPagePerformance.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPagePerformance.Size = new System.Drawing.Size(1059, 468);
            this.tabPagePerformance.TabIndex = 1;
            this.tabPagePerformance.Text = "Performance";
            this.tabPagePerformance.UseVisualStyleBackColor = true;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.statusStripMain);
            this.Controls.Add(this.mainMenu);
            this.MainMenuStrip = this.mainMenu;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainForm";
            this.Text = "TaskManagerPD_311";
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.statusStripMain.ResumeLayout(false);
            this.statusStripMain.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabPageProcesses.ResumeLayout(false);
            this.contextMenuProcList.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mainMenuFileRun;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mainMenuFileExit;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mainMenuViewTopmost;
        private System.Windows.Forms.ToolStripMenuItem mainMenuViewHide;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mainMenuViewColumns;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem mainMenuViewRefresh;
        private System.Windows.Forms.ToolStripMenuItem mainMenuViewRefreshRate;
        private System.Windows.Forms.StatusStrip statusStripMain;
        private System.Windows.Forms.ToolStripMenuItem mainMenuViewRateHight;
        private System.Windows.Forms.ToolStripMenuItem mainMenuViewRateNormal;
        private System.Windows.Forms.ToolStripMenuItem mainMenuViewRateLow;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelProcessCount;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageProcesses;
        private System.Windows.Forms.TabPage tabPagePerformance;
        private System.Windows.Forms.ListView listViewProcesses;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ColumnHeader columnProcessName;
        private System.Windows.Forms.ColumnHeader columnPID;
        private System.Windows.Forms.ContextMenuStrip contextMenuProcList;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpenFileLocation;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDestroy;
    }
}
