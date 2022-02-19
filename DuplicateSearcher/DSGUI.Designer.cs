namespace DuplicateSearcher {
    partial class DSGUI {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DSGUI));
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddSearchLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveSearchLocationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.SaveCriteriaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadCriteriaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.LoadBuiltinCriteriaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BuiltInCriteriaMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.EverythingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AllMediaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.VideoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MusicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DocumentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PicturesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DevelopersFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ActionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StartSearchingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StopSearchingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PauseSearchingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ResumeSearchingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ResultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ResultsContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.OpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenContainingDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MoveToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MoveToContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MoveToRecycleBinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MoveToBrowseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DetailMoveToButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.DeletePermenantlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CompareContentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AutoSelectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RefreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.updatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CheckForUpdatesNowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AutomaticallyCheckForUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DocumentationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DuplicateSearcherWebsiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UnisoftWebsiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EndUserLicenseAgreementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RegisterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewDebugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainStatus = new System.Windows.Forms.StatusStrip();
            this.OverallStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.TotalFilesComparedStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.TotalDirectoriesComparedStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.TotalMatchesStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.TotalMatchGroupsStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.ProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.DirectoryBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.MainSplit = new System.Windows.Forms.SplitContainer();
            this.SearchCriteriaFrame = new System.Windows.Forms.GroupBox();
            this.SearchForButton = new System.Windows.Forms.LinkLabel();
            this.StartButton = new System.Windows.Forms.Button();
            this.PauseButton = new System.Windows.Forms.Button();
            this.ResumeButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.SearchCriteriaTabs = new System.Windows.Forms.TabControl();
            this.SearchCriteriaBasicTab = new System.Windows.Forms.TabPage();
            this.SearchCriteriaBasicSplitter = new System.Windows.Forms.SplitContainer();
            this.SearchLocationsFrame = new System.Windows.Forms.GroupBox();
            this.SearchLocationsList = new System.Windows.Forms.ListView();
            this.SearchLocationsListNameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RemoveSearchLocationButton = new System.Windows.Forms.Button();
            this.SearchLocationTxt = new System.Windows.Forms.TextBox();
            this.AddSearchLocationButton = new System.Windows.Forms.Button();
            this.SearchOptionsFrame = new System.Windows.Forms.GroupBox();
            this.MatchDirectories = new System.Windows.Forms.CheckBox();
            this.MatchFiles = new System.Windows.Forms.CheckBox();
            this.SearchSubdirectories = new System.Windows.Forms.CheckBox();
            this.MatchSizes = new System.Windows.Forms.CheckBox();
            this.MatchFilesToDirectories = new System.Windows.Forms.CheckBox();
            this.MinFileSizeUnits = new System.Windows.Forms.ComboBox();
            this.MinFileSizeLbl = new System.Windows.Forms.Label();
            this.MinFileSize = new System.Windows.Forms.NumericUpDown();
            this.MaxFileSizeUnits = new System.Windows.Forms.ComboBox();
            this.MaxFileSizeLbl = new System.Windows.Forms.Label();
            this.MaxFileSize = new System.Windows.Forms.NumericUpDown();
            this.IncludeExcludeTabs = new System.Windows.Forms.TabControl();
            this.FileFiltersTab = new System.Windows.Forms.TabPage();
            this.FileFiltersTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.FileExcludeFiltersFrame = new System.Windows.Forms.GroupBox();
            this.NewFileExcludeFilter = new System.Windows.Forms.TextBox();
            this.RemoveFileExcludeFilterButton = new System.Windows.Forms.Button();
            this.AddFileExcludeFilterButton = new System.Windows.Forms.Button();
            this.FileExcludeFilterList = new System.Windows.Forms.ListView();
            this.FileExcludeFilterColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FileIncludeFiltersFrame = new System.Windows.Forms.GroupBox();
            this.NewFileIncludeFilter = new System.Windows.Forms.TextBox();
            this.RemoveFileIncludeFilterButton = new System.Windows.Forms.Button();
            this.AddFileIncludeFilterButton = new System.Windows.Forms.Button();
            this.FileIncludeFilterList = new System.Windows.Forms.ListView();
            this.FileIncludeFilterColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DirectoryFiltersTab = new System.Windows.Forms.TabPage();
            this.DirectoryFiltersTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.DirectoryIncludeFiltersFrame = new System.Windows.Forms.GroupBox();
            this.NewDirIncludeFilter = new System.Windows.Forms.TextBox();
            this.RemoveDirectoryIncludeFilterButton = new System.Windows.Forms.Button();
            this.AddDirectoryIncludeFilterButton = new System.Windows.Forms.Button();
            this.DirectoryIncludeFilterList = new System.Windows.Forms.ListView();
            this.DirIncludeFilterColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DirectoryExcludeFiltersFrame = new System.Windows.Forms.GroupBox();
            this.NewDirExcludeFilter = new System.Windows.Forms.TextBox();
            this.RemoveDirectoryExcludeFilterButton = new System.Windows.Forms.Button();
            this.AddDirectoryExcludeFilterButton = new System.Windows.Forms.Button();
            this.DirectoryExcludeFilterList = new System.Windows.Forms.ListView();
            this.DirExcludeFilterColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SearchCriteriaAdvancedTab = new System.Windows.Forms.TabPage();
            this.MiscFrame = new System.Windows.Forms.GroupBox();
            this.MaxSearchThreads = new System.Windows.Forms.NumericUpDown();
            this.MaxSearchThreadsLabel = new System.Windows.Forms.Label();
            this.SearchMode = new System.Windows.Forms.ComboBox();
            this.UseDefaultFilters = new System.Windows.Forms.CheckBox();
            this.MergeFilters = new System.Windows.Forms.CheckBox();
            this.PreloadContent = new System.Windows.Forms.CheckBox();
            this.MatchOnNameORContent = new System.Windows.Forms.CheckBox();
            this.SearchModeLabel = new System.Windows.Forms.Label();
            this.OutputFileFrame = new System.Windows.Forms.GroupBox();
            this.AppendOutputFile = new System.Windows.Forms.CheckBox();
            this.OnlyOutputFile = new System.Windows.Forms.CheckBox();
            this.UseOutputFile = new System.Windows.Forms.CheckBox();
            this.OutputFileBrowseButton = new System.Windows.Forms.Button();
            this.OutputFile = new System.Windows.Forms.TextBox();
            this.OutputFileLabel = new System.Windows.Forms.Label();
            this.LogFileFrame = new System.Windows.Forms.GroupBox();
            this.LogFile = new System.Windows.Forms.TextBox();
            this.AppendLogFile = new System.Windows.Forms.CheckBox();
            this.UseLogFile = new System.Windows.Forms.CheckBox();
            this.LogFileBrowseButton = new System.Windows.Forms.Button();
            this.LogFileLabel = new System.Windows.Forms.Label();
            this.CompareContentsFrame = new System.Windows.Forms.GroupBox();
            this.CompareDirectoryContents = new System.Windows.Forms.CheckBox();
            this.HeaderFooterSizeBytesLabel = new System.Windows.Forms.Label();
            this.HeaderFooterSize = new System.Windows.Forms.NumericUpDown();
            this.HeaderFooterSizeLabel = new System.Windows.Forms.Label();
            this.CCModeFrame = new System.Windows.Forms.GroupBox();
            this.CCModeHeaderAndFooter = new System.Windows.Forms.RadioButton();
            this.CCModeHeader = new System.Windows.Forms.RadioButton();
            this.CCModeAllContents = new System.Windows.Forms.RadioButton();
            this.MatchContents = new System.Windows.Forms.CheckBox();
            this.CompareNamesFrame = new System.Windows.Forms.GroupBox();
            this.RemoveNonalpha = new System.Windows.Forms.CheckBox();
            this.RemoveNumbers = new System.Windows.Forms.CheckBox();
            this.IgnoreExtensions = new System.Windows.Forms.CheckBox();
            this.NCModeFrame = new System.Windows.Forms.GroupBox();
            this.NCModeSoundEx = new System.Windows.Forms.RadioButton();
            this.NCModeExact = new System.Windows.Forms.RadioButton();
            this.MatchNames = new System.Windows.Forms.CheckBox();
            this.SearchResultsFrame = new System.Windows.Forms.GroupBox();
            this.SearchResultsSplitter = new System.Windows.Forms.SplitContainer();
            this.SelectedResultCountLabel = new System.Windows.Forms.Label();
            this.DetailToolbar = new System.Windows.Forms.ToolStrip();
            this.DetailAutoSelectButton = new System.Windows.Forms.ToolStripButton();
            this.DetailOpenResultButton = new System.Windows.Forms.ToolStripButton();
            this.DetailOpenContainingDirectoryButton = new System.Windows.Forms.ToolStripButton();
            this.DetailCompareContentsButton = new System.Windows.Forms.ToolStripButton();
            this.DetailDeletePermenantlyResultButton = new System.Windows.Forms.ToolStripButton();
            this.DetailRefreshButton = new System.Windows.Forms.ToolStripButton();
            this.SearchResultsTabs = new System.Windows.Forms.TabControl();
            this.SearchResultsBasicTab = new System.Windows.Forms.TabPage();
            this.SearchResultsGroupedTab = new System.Windows.Forms.TabPage();
            this.SearchResultsGroupedTabSplitter = new System.Windows.Forms.SplitContainer();
            this.GroupResultsList = new System.Windows.Forms.ListView();
            this.GroupResultsListGroupIDColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.GroupResultsListTotalMatchesColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.GroupResultsListTotalFilesColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.GroupResultsListTotalDirectoriesColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.GroupResultsListLabel = new System.Windows.Forms.Label();
            this.ResultGroupListLabel = new System.Windows.Forms.Label();
            this.DetailsTabs = new System.Windows.Forms.TabControl();
            this.MatchDetailsTab = new System.Windows.Forms.TabPage();
            this.DetailSplitter = new System.Windows.Forms.SplitContainer();
            this.DetailMatchGroup = new System.Windows.Forms.TextBox();
            this.DetailViewPreview = new System.Windows.Forms.CheckBox();
            this.DetailMatchCount = new System.Windows.Forms.Label();
            this.DetailNameAndType = new System.Windows.Forms.Label();
            this.DetailIcon = new System.Windows.Forms.PictureBox();
            this.DetailPreview = new System.Windows.Forms.WebBrowser();
            this.DetailFitToWindow = new System.Windows.Forms.CheckBox();
            this.DetailPreviewLabel = new System.Windows.Forms.Label();
            this.CriteriaDescriptionDetailsTab = new System.Windows.Forms.TabPage();
            this.CriteriaDescription = new System.Windows.Forms.TextBox();
            this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.UpdateStatusTimer = new System.Windows.Forms.Timer(this.components);
            this.UpdateResultsTimer = new System.Windows.Forms.Timer(this.components);
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.UnisoftLogo = new System.Windows.Forms.PictureBox();
            this.CheckRegisterTimer = new System.Windows.Forms.Timer(this.components);
            this.RegistrationLbl = new System.Windows.Forms.Label();
            this.BasicResultsList = new DuplicateSearcher.DSResultsList();
            this.ResultGroupList = new DuplicateSearcher.DSResultsList();
            this.MainMenu.SuspendLayout();
            this.BuiltInCriteriaMenuStrip.SuspendLayout();
            this.ResultsContextMenu.SuspendLayout();
            this.MoveToContextMenu.SuspendLayout();
            this.MainStatus.SuspendLayout();
            this.MainSplit.Panel1.SuspendLayout();
            this.MainSplit.Panel2.SuspendLayout();
            this.MainSplit.SuspendLayout();
            this.SearchCriteriaFrame.SuspendLayout();
            this.SearchCriteriaTabs.SuspendLayout();
            this.SearchCriteriaBasicTab.SuspendLayout();
            this.SearchCriteriaBasicSplitter.Panel1.SuspendLayout();
            this.SearchCriteriaBasicSplitter.Panel2.SuspendLayout();
            this.SearchCriteriaBasicSplitter.SuspendLayout();
            this.SearchLocationsFrame.SuspendLayout();
            this.SearchOptionsFrame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MinFileSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxFileSize)).BeginInit();
            this.IncludeExcludeTabs.SuspendLayout();
            this.FileFiltersTab.SuspendLayout();
            this.FileFiltersTablePanel.SuspendLayout();
            this.FileExcludeFiltersFrame.SuspendLayout();
            this.FileIncludeFiltersFrame.SuspendLayout();
            this.DirectoryFiltersTab.SuspendLayout();
            this.DirectoryFiltersTablePanel.SuspendLayout();
            this.DirectoryIncludeFiltersFrame.SuspendLayout();
            this.DirectoryExcludeFiltersFrame.SuspendLayout();
            this.SearchCriteriaAdvancedTab.SuspendLayout();
            this.MiscFrame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxSearchThreads)).BeginInit();
            this.OutputFileFrame.SuspendLayout();
            this.LogFileFrame.SuspendLayout();
            this.CompareContentsFrame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HeaderFooterSize)).BeginInit();
            this.CCModeFrame.SuspendLayout();
            this.CompareNamesFrame.SuspendLayout();
            this.NCModeFrame.SuspendLayout();
            this.SearchResultsFrame.SuspendLayout();
            this.SearchResultsSplitter.Panel1.SuspendLayout();
            this.SearchResultsSplitter.Panel2.SuspendLayout();
            this.SearchResultsSplitter.SuspendLayout();
            this.DetailToolbar.SuspendLayout();
            this.SearchResultsTabs.SuspendLayout();
            this.SearchResultsBasicTab.SuspendLayout();
            this.SearchResultsGroupedTab.SuspendLayout();
            this.SearchResultsGroupedTabSplitter.Panel1.SuspendLayout();
            this.SearchResultsGroupedTabSplitter.Panel2.SuspendLayout();
            this.SearchResultsGroupedTabSplitter.SuspendLayout();
            this.DetailsTabs.SuspendLayout();
            this.MatchDetailsTab.SuspendLayout();
            this.DetailSplitter.Panel1.SuspendLayout();
            this.DetailSplitter.Panel2.SuspendLayout();
            this.DetailSplitter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DetailIcon)).BeginInit();
            this.CriteriaDescriptionDetailsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UnisoftLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.ActionToolStripMenuItem,
            this.HelpToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(873, 24);
            this.MainMenu.TabIndex = 0;
            this.MainMenu.Text = "menuStrip1";
            this.MainMenu.Paint += new System.Windows.Forms.PaintEventHandler(this.MainMenu_Paint);
            this.MainMenu.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MainMenu_MouseClick);
            this.MainMenu.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainMenu_MouseMove);
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddSearchLocationToolStripMenuItem,
            this.RemoveSearchLocationsToolStripMenuItem,
            this.ToolStripSeparator3,
            this.SaveCriteriaToolStripMenuItem,
            this.LoadCriteriaToolStripMenuItem,
            this.ToolStripSeparator4,
            this.LoadBuiltinCriteriaToolStripMenuItem,
            this.ToolStripSeparator1,
            this.ExitToolStripMenuItem});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.FileToolStripMenuItem.Text = "File";
            // 
            // AddSearchLocationToolStripMenuItem
            // 
            this.AddSearchLocationToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("AddSearchLocationToolStripMenuItem.Image")));
            this.AddSearchLocationToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.AddSearchLocationToolStripMenuItem.Name = "AddSearchLocationToolStripMenuItem";
            this.AddSearchLocationToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.AddSearchLocationToolStripMenuItem.Size = new System.Drawing.Size(254, 22);
            this.AddSearchLocationToolStripMenuItem.Text = "Add Search Location";
            this.AddSearchLocationToolStripMenuItem.Click += new System.EventHandler(this.AddSearchLocationToolStripMenuItem_Click);
            // 
            // RemoveSearchLocationsToolStripMenuItem
            // 
            this.RemoveSearchLocationsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("RemoveSearchLocationsToolStripMenuItem.Image")));
            this.RemoveSearchLocationsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.RemoveSearchLocationsToolStripMenuItem.Name = "RemoveSearchLocationsToolStripMenuItem";
            this.RemoveSearchLocationsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.RemoveSearchLocationsToolStripMenuItem.Size = new System.Drawing.Size(254, 22);
            this.RemoveSearchLocationsToolStripMenuItem.Text = "Remove Search Locations";
            this.RemoveSearchLocationsToolStripMenuItem.Click += new System.EventHandler(this.RemoveSearchLocationsToolStripMenuItem_Click);
            // 
            // ToolStripSeparator3
            // 
            this.ToolStripSeparator3.Name = "ToolStripSeparator3";
            this.ToolStripSeparator3.Size = new System.Drawing.Size(251, 6);
            // 
            // SaveCriteriaToolStripMenuItem
            // 
            this.SaveCriteriaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("SaveCriteriaToolStripMenuItem.Image")));
            this.SaveCriteriaToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.SaveCriteriaToolStripMenuItem.Name = "SaveCriteriaToolStripMenuItem";
            this.SaveCriteriaToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.SaveCriteriaToolStripMenuItem.Size = new System.Drawing.Size(254, 22);
            this.SaveCriteriaToolStripMenuItem.Text = "Save Criteria To File";
            this.SaveCriteriaToolStripMenuItem.Click += new System.EventHandler(this.SaveCriteriaToolStripMenuItem_Click);
            // 
            // LoadCriteriaToolStripMenuItem
            // 
            this.LoadCriteriaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("LoadCriteriaToolStripMenuItem.Image")));
            this.LoadCriteriaToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.LoadCriteriaToolStripMenuItem.Name = "LoadCriteriaToolStripMenuItem";
            this.LoadCriteriaToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.LoadCriteriaToolStripMenuItem.Size = new System.Drawing.Size(254, 22);
            this.LoadCriteriaToolStripMenuItem.Text = "Load Criteria From File";
            this.LoadCriteriaToolStripMenuItem.Click += new System.EventHandler(this.LoadCriteriaToolStripMenuItem_Click);
            // 
            // ToolStripSeparator4
            // 
            this.ToolStripSeparator4.Name = "ToolStripSeparator4";
            this.ToolStripSeparator4.Size = new System.Drawing.Size(251, 6);
            // 
            // LoadBuiltinCriteriaToolStripMenuItem
            // 
            this.LoadBuiltinCriteriaToolStripMenuItem.DropDown = this.BuiltInCriteriaMenuStrip;
            this.LoadBuiltinCriteriaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("LoadBuiltinCriteriaToolStripMenuItem.Image")));
            this.LoadBuiltinCriteriaToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.LoadBuiltinCriteriaToolStripMenuItem.Name = "LoadBuiltinCriteriaToolStripMenuItem";
            this.LoadBuiltinCriteriaToolStripMenuItem.Size = new System.Drawing.Size(254, 22);
            this.LoadBuiltinCriteriaToolStripMenuItem.Text = "Load Built-in Criteria";
            // 
            // BuiltInCriteriaMenuStrip
            // 
            this.BuiltInCriteriaMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EverythingToolStripMenuItem,
            this.AllMediaToolStripMenuItem,
            this.VideoToolStripMenuItem,
            this.MusicToolStripMenuItem,
            this.DocumentsToolStripMenuItem,
            this.PicturesToolStripMenuItem,
            this.DevelopersFilesToolStripMenuItem});
            this.BuiltInCriteriaMenuStrip.Name = "BuiltInCriteriaMenuStrip";
            this.BuiltInCriteriaMenuStrip.OwnerItem = this.LoadBuiltinCriteriaToolStripMenuItem;
            this.BuiltInCriteriaMenuStrip.Size = new System.Drawing.Size(162, 158);
            // 
            // EverythingToolStripMenuItem
            // 
            this.EverythingToolStripMenuItem.Name = "EverythingToolStripMenuItem";
            this.EverythingToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.EverythingToolStripMenuItem.Tag = "Everything.ini";
            this.EverythingToolStripMenuItem.Text = "Everything";
            this.EverythingToolStripMenuItem.Click += new System.EventHandler(this.GeneralBuiltinCriteriaToolStripMenuItem_Click);
            // 
            // AllMediaToolStripMenuItem
            // 
            this.AllMediaToolStripMenuItem.Name = "AllMediaToolStripMenuItem";
            this.AllMediaToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.AllMediaToolStripMenuItem.Tag = "AllMedia.ini";
            this.AllMediaToolStripMenuItem.Text = "All Media";
            this.AllMediaToolStripMenuItem.Click += new System.EventHandler(this.GeneralBuiltinCriteriaToolStripMenuItem_Click);
            // 
            // VideoToolStripMenuItem
            // 
            this.VideoToolStripMenuItem.Name = "VideoToolStripMenuItem";
            this.VideoToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.VideoToolStripMenuItem.Tag = "Video.ini";
            this.VideoToolStripMenuItem.Text = "Video";
            this.VideoToolStripMenuItem.Click += new System.EventHandler(this.GeneralBuiltinCriteriaToolStripMenuItem_Click);
            // 
            // MusicToolStripMenuItem
            // 
            this.MusicToolStripMenuItem.Name = "MusicToolStripMenuItem";
            this.MusicToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.MusicToolStripMenuItem.Tag = "Music.ini";
            this.MusicToolStripMenuItem.Text = "Music";
            this.MusicToolStripMenuItem.Click += new System.EventHandler(this.GeneralBuiltinCriteriaToolStripMenuItem_Click);
            // 
            // DocumentsToolStripMenuItem
            // 
            this.DocumentsToolStripMenuItem.Name = "DocumentsToolStripMenuItem";
            this.DocumentsToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.DocumentsToolStripMenuItem.Tag = "Documents.ini";
            this.DocumentsToolStripMenuItem.Text = "Documents";
            this.DocumentsToolStripMenuItem.Click += new System.EventHandler(this.GeneralBuiltinCriteriaToolStripMenuItem_Click);
            // 
            // PicturesToolStripMenuItem
            // 
            this.PicturesToolStripMenuItem.Name = "PicturesToolStripMenuItem";
            this.PicturesToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.PicturesToolStripMenuItem.Tag = "Pictures.ini";
            this.PicturesToolStripMenuItem.Text = "Pictures";
            this.PicturesToolStripMenuItem.Click += new System.EventHandler(this.GeneralBuiltinCriteriaToolStripMenuItem_Click);
            // 
            // DevelopersFilesToolStripMenuItem
            // 
            this.DevelopersFilesToolStripMenuItem.Name = "DevelopersFilesToolStripMenuItem";
            this.DevelopersFilesToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.DevelopersFilesToolStripMenuItem.Tag = "DevelopersFiles.ini";
            this.DevelopersFilesToolStripMenuItem.Text = "Developer\'s Files";
            this.DevelopersFilesToolStripMenuItem.Click += new System.EventHandler(this.GeneralBuiltinCriteriaToolStripMenuItem_Click);
            // 
            // ToolStripSeparator1
            // 
            this.ToolStripSeparator1.Name = "ToolStripSeparator1";
            this.ToolStripSeparator1.Size = new System.Drawing.Size(251, 6);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ExitToolStripMenuItem.Image")));
            this.ExitToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(254, 22);
            this.ExitToolStripMenuItem.Text = "Exit";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // ActionToolStripMenuItem
            // 
            this.ActionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StartSearchingToolStripMenuItem,
            this.StopSearchingToolStripMenuItem,
            this.PauseSearchingToolStripMenuItem,
            this.ResumeSearchingToolStripMenuItem,
            this.ToolStripSeparator2,
            this.ResultsToolStripMenuItem,
            this.ToolStripSeparator5,
            this.updatesToolStripMenuItem});
            this.ActionToolStripMenuItem.Name = "ActionToolStripMenuItem";
            this.ActionToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.ActionToolStripMenuItem.Text = "Action";
            // 
            // StartSearchingToolStripMenuItem
            // 
            this.StartSearchingToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("StartSearchingToolStripMenuItem.Image")));
            this.StartSearchingToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.StartSearchingToolStripMenuItem.Name = "StartSearchingToolStripMenuItem";
            this.StartSearchingToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.StartSearchingToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.StartSearchingToolStripMenuItem.Text = "Start Searching";
            this.StartSearchingToolStripMenuItem.Click += new System.EventHandler(this.StartSearchingToolStripMenuItem_Click);
            // 
            // StopSearchingToolStripMenuItem
            // 
            this.StopSearchingToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("StopSearchingToolStripMenuItem.Image")));
            this.StopSearchingToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.StopSearchingToolStripMenuItem.Name = "StopSearchingToolStripMenuItem";
            this.StopSearchingToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.StopSearchingToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.StopSearchingToolStripMenuItem.Text = "Stop Searching";
            this.StopSearchingToolStripMenuItem.Click += new System.EventHandler(this.StopSearchingToolStripMenuItem_Click);
            // 
            // PauseSearchingToolStripMenuItem
            // 
            this.PauseSearchingToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("PauseSearchingToolStripMenuItem.Image")));
            this.PauseSearchingToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.PauseSearchingToolStripMenuItem.Name = "PauseSearchingToolStripMenuItem";
            this.PauseSearchingToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F7;
            this.PauseSearchingToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.PauseSearchingToolStripMenuItem.Text = "Pause Searching";
            this.PauseSearchingToolStripMenuItem.Click += new System.EventHandler(this.PauseSearchingToolStripMenuItem_Click);
            // 
            // ResumeSearchingToolStripMenuItem
            // 
            this.ResumeSearchingToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ResumeSearchingToolStripMenuItem.Image")));
            this.ResumeSearchingToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ResumeSearchingToolStripMenuItem.Name = "ResumeSearchingToolStripMenuItem";
            this.ResumeSearchingToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.ResumeSearchingToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.ResumeSearchingToolStripMenuItem.Text = "Resume Searching";
            this.ResumeSearchingToolStripMenuItem.Click += new System.EventHandler(this.ResumeSearchingToolStripMenuItem_Click);
            // 
            // ToolStripSeparator2
            // 
            this.ToolStripSeparator2.Name = "ToolStripSeparator2";
            this.ToolStripSeparator2.Size = new System.Drawing.Size(187, 6);
            // 
            // ResultsToolStripMenuItem
            // 
            this.ResultsToolStripMenuItem.DropDown = this.ResultsContextMenu;
            this.ResultsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ResultsToolStripMenuItem.Image")));
            this.ResultsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ResultsToolStripMenuItem.Name = "ResultsToolStripMenuItem";
            this.ResultsToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.ResultsToolStripMenuItem.Text = "Results";
            // 
            // ResultsContextMenu
            // 
            this.ResultsContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenToolStripMenuItem,
            this.OpenContainingDirectoryToolStripMenuItem,
            this.MoveToToolStripMenuItem,
            this.DeletePermenantlyToolStripMenuItem,
            this.CompareContentsToolStripMenuItem,
            this.AutoSelectToolStripMenuItem,
            this.RefreshToolStripMenuItem});
            this.ResultsContextMenu.Name = "ResultsContextMenu";
            this.ResultsContextMenu.OwnerItem = this.ResultsToolStripMenuItem;
            this.ResultsContextMenu.Size = new System.Drawing.Size(220, 172);
            // 
            // OpenToolStripMenuItem
            // 
            this.OpenToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("OpenToolStripMenuItem.Image")));
            this.OpenToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
            this.OpenToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D1)));
            this.OpenToolStripMenuItem.Size = new System.Drawing.Size(219, 24);
            this.OpenToolStripMenuItem.Text = "Open";
            this.OpenToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // OpenContainingDirectoryToolStripMenuItem
            // 
            this.OpenContainingDirectoryToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("OpenContainingDirectoryToolStripMenuItem.Image")));
            this.OpenContainingDirectoryToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.OpenContainingDirectoryToolStripMenuItem.Name = "OpenContainingDirectoryToolStripMenuItem";
            this.OpenContainingDirectoryToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D2)));
            this.OpenContainingDirectoryToolStripMenuItem.Size = new System.Drawing.Size(219, 24);
            this.OpenContainingDirectoryToolStripMenuItem.Text = "Open Location";
            this.OpenContainingDirectoryToolStripMenuItem.Click += new System.EventHandler(this.OpenContainingDirectoryToolStripMenuItem_Click);
            // 
            // MoveToToolStripMenuItem
            // 
            this.MoveToToolStripMenuItem.DropDown = this.MoveToContextMenu;
            this.MoveToToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("MoveToToolStripMenuItem.Image")));
            this.MoveToToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MoveToToolStripMenuItem.Name = "MoveToToolStripMenuItem";
            this.MoveToToolStripMenuItem.Size = new System.Drawing.Size(219, 24);
            this.MoveToToolStripMenuItem.Text = "Move To";
            // 
            // MoveToContextMenu
            // 
            this.MoveToContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MoveToRecycleBinToolStripMenuItem,
            this.MoveToBrowseToolStripMenuItem});
            this.MoveToContextMenu.Name = "MoveToContextMenu";
            this.MoveToContextMenu.OwnerItem = this.DetailMoveToButton;
            this.MoveToContextMenu.Size = new System.Drawing.Size(177, 52);
            // 
            // MoveToRecycleBinToolStripMenuItem
            // 
            this.MoveToRecycleBinToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("MoveToRecycleBinToolStripMenuItem.Image")));
            this.MoveToRecycleBinToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MoveToRecycleBinToolStripMenuItem.Name = "MoveToRecycleBinToolStripMenuItem";
            this.MoveToRecycleBinToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D3)));
            this.MoveToRecycleBinToolStripMenuItem.Size = new System.Drawing.Size(176, 24);
            this.MoveToRecycleBinToolStripMenuItem.Text = "Rec&ycle Bin";
            this.MoveToRecycleBinToolStripMenuItem.Click += new System.EventHandler(this.MoveToRecycleBinToolStripMenuItem_Click);
            // 
            // MoveToBrowseToolStripMenuItem
            // 
            this.MoveToBrowseToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("MoveToBrowseToolStripMenuItem.Image")));
            this.MoveToBrowseToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MoveToBrowseToolStripMenuItem.Name = "MoveToBrowseToolStripMenuItem";
            this.MoveToBrowseToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D4)));
            this.MoveToBrowseToolStripMenuItem.Size = new System.Drawing.Size(176, 24);
            this.MoveToBrowseToolStripMenuItem.Text = "&Browse...";
            this.MoveToBrowseToolStripMenuItem.Click += new System.EventHandler(this.MoveToBrowseToolStripMenuItem_Click);
            // 
            // DetailMoveToButton
            // 
            this.DetailMoveToButton.DropDown = this.MoveToContextMenu;
            this.DetailMoveToButton.Image = ((System.Drawing.Image)(resources.GetObject("DetailMoveToButton.Image")));
            this.DetailMoveToButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.DetailMoveToButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DetailMoveToButton.Name = "DetailMoveToButton";
            this.DetailMoveToButton.Size = new System.Drawing.Size(80, 22);
            this.DetailMoveToButton.Text = "&Move To";
            // 
            // DeletePermenantlyToolStripMenuItem
            // 
            this.DeletePermenantlyToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("DeletePermenantlyToolStripMenuItem.Image")));
            this.DeletePermenantlyToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.DeletePermenantlyToolStripMenuItem.Name = "DeletePermenantlyToolStripMenuItem";
            this.DeletePermenantlyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D5)));
            this.DeletePermenantlyToolStripMenuItem.Size = new System.Drawing.Size(219, 24);
            this.DeletePermenantlyToolStripMenuItem.Text = "Delete Permenantly";
            this.DeletePermenantlyToolStripMenuItem.Click += new System.EventHandler(this.DeletePermenantlyToolStripMenuItem_Click);
            // 
            // CompareContentsToolStripMenuItem
            // 
            this.CompareContentsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("CompareContentsToolStripMenuItem.Image")));
            this.CompareContentsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.CompareContentsToolStripMenuItem.Name = "CompareContentsToolStripMenuItem";
            this.CompareContentsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D6)));
            this.CompareContentsToolStripMenuItem.Size = new System.Drawing.Size(219, 24);
            this.CompareContentsToolStripMenuItem.Text = "Compare Contents";
            this.CompareContentsToolStripMenuItem.Click += new System.EventHandler(this.CompareContentsToolStripMenuItem_Click);
            // 
            // AutoSelectToolStripMenuItem
            // 
            this.AutoSelectToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("AutoSelectToolStripMenuItem.Image")));
            this.AutoSelectToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.AutoSelectToolStripMenuItem.Name = "AutoSelectToolStripMenuItem";
            this.AutoSelectToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D7)));
            this.AutoSelectToolStripMenuItem.Size = new System.Drawing.Size(219, 24);
            this.AutoSelectToolStripMenuItem.Text = "Auto Select";
            this.AutoSelectToolStripMenuItem.Click += new System.EventHandler(this.AutoSelectToolStripMenuItem_Click);
            // 
            // RefreshToolStripMenuItem
            // 
            this.RefreshToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("RefreshToolStripMenuItem.Image")));
            this.RefreshToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem";
            this.RefreshToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D8)));
            this.RefreshToolStripMenuItem.Size = new System.Drawing.Size(219, 24);
            this.RefreshToolStripMenuItem.Text = "Refresh";
            this.RefreshToolStripMenuItem.Click += new System.EventHandler(this.RefreshToolStripMenuItem_Click);
            // 
            // ToolStripSeparator5
            // 
            this.ToolStripSeparator5.Name = "ToolStripSeparator5";
            this.ToolStripSeparator5.Size = new System.Drawing.Size(187, 6);
            // 
            // updatesToolStripMenuItem
            // 
            this.updatesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CheckForUpdatesNowToolStripMenuItem,
            this.AutomaticallyCheckForUpdatesToolStripMenuItem});
            this.updatesToolStripMenuItem.Image = global::DuplicateSearcher.Properties.Resources.refresh2;
            this.updatesToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.updatesToolStripMenuItem.Name = "updatesToolStripMenuItem";
            this.updatesToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.updatesToolStripMenuItem.Text = "Updates";
            // 
            // CheckForUpdatesNowToolStripMenuItem
            // 
            this.CheckForUpdatesNowToolStripMenuItem.Image = global::DuplicateSearcher.Properties.Resources.globe2;
            this.CheckForUpdatesNowToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.CheckForUpdatesNowToolStripMenuItem.Name = "CheckForUpdatesNowToolStripMenuItem";
            this.CheckForUpdatesNowToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.CheckForUpdatesNowToolStripMenuItem.Text = "Check For Updates Now";
            this.CheckForUpdatesNowToolStripMenuItem.Click += new System.EventHandler(this.CheckForUpdatesNowToolStripMenuItem_Click);
            // 
            // AutomaticallyCheckForUpdatesToolStripMenuItem
            // 
            this.AutomaticallyCheckForUpdatesToolStripMenuItem.CheckOnClick = true;
            this.AutomaticallyCheckForUpdatesToolStripMenuItem.Name = "AutomaticallyCheckForUpdatesToolStripMenuItem";
            this.AutomaticallyCheckForUpdatesToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.AutomaticallyCheckForUpdatesToolStripMenuItem.Text = "Automatically Check For Updates";
            this.AutomaticallyCheckForUpdatesToolStripMenuItem.Click += new System.EventHandler(this.AutomaticallyCheckForUpdatesToolStripMenuItem_Click);
            // 
            // HelpToolStripMenuItem
            // 
            this.HelpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AboutToolStripMenuItem,
            this.DocumentationToolStripMenuItem,
            this.DuplicateSearcherWebsiteToolStripMenuItem,
            this.UnisoftWebsiteToolStripMenuItem,
            this.EndUserLicenseAgreementToolStripMenuItem,
            this.RegisterToolStripMenuItem,
            this.ViewDebugToolStripMenuItem});
            this.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
            this.HelpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.HelpToolStripMenuItem.Text = "Help";
            // 
            // AboutToolStripMenuItem
            // 
            this.AboutToolStripMenuItem.Image = global::DuplicateSearcher.Properties.Resources.info;
            this.AboutToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            this.AboutToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F12;
            this.AboutToolStripMenuItem.Size = new System.Drawing.Size(234, 24);
            this.AboutToolStripMenuItem.Text = "About";
            this.AboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // DocumentationToolStripMenuItem
            // 
            this.DocumentationToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("DocumentationToolStripMenuItem.Image")));
            this.DocumentationToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.DocumentationToolStripMenuItem.Name = "DocumentationToolStripMenuItem";
            this.DocumentationToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.DocumentationToolStripMenuItem.Size = new System.Drawing.Size(234, 24);
            this.DocumentationToolStripMenuItem.Text = "Documentation";
            this.DocumentationToolStripMenuItem.Click += new System.EventHandler(this.DocumentationToolStripMenuItem_Click);
            // 
            // DuplicateSearcherWebsiteToolStripMenuItem
            // 
            this.DuplicateSearcherWebsiteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("DuplicateSearcherWebsiteToolStripMenuItem.Image")));
            this.DuplicateSearcherWebsiteToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.DuplicateSearcherWebsiteToolStripMenuItem.Name = "DuplicateSearcherWebsiteToolStripMenuItem";
            this.DuplicateSearcherWebsiteToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.DuplicateSearcherWebsiteToolStripMenuItem.Size = new System.Drawing.Size(234, 24);
            this.DuplicateSearcherWebsiteToolStripMenuItem.Text = "DuplicateSearcher Website";
            this.DuplicateSearcherWebsiteToolStripMenuItem.Click += new System.EventHandler(this.DuplicateSearcherWebsiteToolStripMenuItem_Click);
            // 
            // UnisoftWebsiteToolStripMenuItem
            // 
            this.UnisoftWebsiteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("UnisoftWebsiteToolStripMenuItem.Image")));
            this.UnisoftWebsiteToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.UnisoftWebsiteToolStripMenuItem.Name = "UnisoftWebsiteToolStripMenuItem";
            this.UnisoftWebsiteToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.UnisoftWebsiteToolStripMenuItem.Size = new System.Drawing.Size(234, 24);
            this.UnisoftWebsiteToolStripMenuItem.Text = "Unisoft Website";
            this.UnisoftWebsiteToolStripMenuItem.Visible = false;
            this.UnisoftWebsiteToolStripMenuItem.Click += new System.EventHandler(this.UnisoftWebsiteToolStripMenuItem_Click);
            // 
            // EndUserLicenseAgreementToolStripMenuItem
            // 
            this.EndUserLicenseAgreementToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("EndUserLicenseAgreementToolStripMenuItem.Image")));
            this.EndUserLicenseAgreementToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.EndUserLicenseAgreementToolStripMenuItem.Name = "EndUserLicenseAgreementToolStripMenuItem";
            this.EndUserLicenseAgreementToolStripMenuItem.Size = new System.Drawing.Size(234, 24);
            this.EndUserLicenseAgreementToolStripMenuItem.Text = "End User License Agreement";
            this.EndUserLicenseAgreementToolStripMenuItem.Visible = false;
            this.EndUserLicenseAgreementToolStripMenuItem.Click += new System.EventHandler(this.EndUserLicenseAgreementToolStripMenuItem_Click);
            // 
            // RegisterToolStripMenuItem
            // 
            this.RegisterToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("RegisterToolStripMenuItem.Image")));
            this.RegisterToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.RegisterToolStripMenuItem.Name = "RegisterToolStripMenuItem";
            this.RegisterToolStripMenuItem.Size = new System.Drawing.Size(234, 24);
            this.RegisterToolStripMenuItem.Text = "Register";
            this.RegisterToolStripMenuItem.Visible = false;
            this.RegisterToolStripMenuItem.Click += new System.EventHandler(this.RegisterToolStripMenuItem_Click);
            // 
            // ViewDebugToolStripMenuItem
            // 
            this.ViewDebugToolStripMenuItem.Image = global::DuplicateSearcher.Properties.Resources.calulator;
            this.ViewDebugToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ViewDebugToolStripMenuItem.Name = "ViewDebugToolStripMenuItem";
            this.ViewDebugToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F9;
            this.ViewDebugToolStripMenuItem.Size = new System.Drawing.Size(234, 24);
            this.ViewDebugToolStripMenuItem.Text = "View Debug";
            this.ViewDebugToolStripMenuItem.Click += new System.EventHandler(this.ViewDebugToolStripMenuItem_Click);
            // 
            // MainStatus
            // 
            this.MainStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OverallStatus,
            this.TotalFilesComparedStatus,
            this.TotalDirectoriesComparedStatus,
            this.TotalMatchesStatus,
            this.TotalMatchGroupsStatus,
            this.ProgressBar});
            this.MainStatus.Location = new System.Drawing.Point(0, 595);
            this.MainStatus.Name = "MainStatus";
            this.MainStatus.Size = new System.Drawing.Size(873, 24);
            this.MainStatus.TabIndex = 1;
            this.MainStatus.Text = "Ready.";
            // 
            // OverallStatus
            // 
            this.OverallStatus.Name = "OverallStatus";
            this.OverallStatus.Size = new System.Drawing.Size(558, 19);
            this.OverallStatus.Spring = true;
            this.OverallStatus.Text = "Ready.";
            this.OverallStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TotalFilesComparedStatus
            // 
            this.TotalFilesComparedStatus.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)(((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.TotalFilesComparedStatus.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.TotalFilesComparedStatus.Name = "TotalFilesComparedStatus";
            this.TotalFilesComparedStatus.Size = new System.Drawing.Size(96, 19);
            this.TotalFilesComparedStatus.Text = "Files Compared:";
            this.TotalFilesComparedStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TotalDirectoriesComparedStatus
            // 
            this.TotalDirectoriesComparedStatus.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Top | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.TotalDirectoriesComparedStatus.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.TotalDirectoriesComparedStatus.Name = "TotalDirectoriesComparedStatus";
            this.TotalDirectoriesComparedStatus.Size = new System.Drawing.Size(93, 19);
            this.TotalDirectoriesComparedStatus.Text = "Dirs Compared:";
            this.TotalDirectoriesComparedStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TotalMatchesStatus
            // 
            this.TotalMatchesStatus.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Top | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.TotalMatchesStatus.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.TotalMatchesStatus.Name = "TotalMatchesStatus";
            this.TotalMatchesStatus.Size = new System.Drawing.Size(59, 19);
            this.TotalMatchesStatus.Text = "Matches:";
            this.TotalMatchesStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TotalMatchGroupsStatus
            // 
            this.TotalMatchGroupsStatus.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)(((System.Windows.Forms.ToolStripStatusLabelBorderSides.Top | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.TotalMatchGroupsStatus.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.TotalMatchGroupsStatus.Name = "TotalMatchGroupsStatus";
            this.TotalMatchGroupsStatus.Size = new System.Drawing.Size(52, 19);
            this.TotalMatchGroupsStatus.Text = "Groups:";
            this.TotalMatchGroupsStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ProgressBar
            // 
            this.ProgressBar.MarqueeAnimationSpeed = 0;
            this.ProgressBar.Maximum = 1000;
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(80, 18);
            this.ProgressBar.Step = 1;
            this.ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.ProgressBar.Visible = false;
            // 
            // DirectoryBrowserDialog
            // 
            this.DirectoryBrowserDialog.ShowNewFolderButton = false;
            // 
            // MainSplit
            // 
            this.MainSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainSplit.Location = new System.Drawing.Point(0, 24);
            this.MainSplit.Name = "MainSplit";
            // 
            // MainSplit.Panel1
            // 
            this.MainSplit.Panel1.Controls.Add(this.SearchCriteriaFrame);
            this.MainSplit.Panel1.SizeChanged += new System.EventHandler(this.MainSplit_Panel1_SizeChanged);
            // 
            // MainSplit.Panel2
            // 
            this.MainSplit.Panel2.Controls.Add(this.SearchResultsFrame);
            this.MainSplit.Size = new System.Drawing.Size(873, 571);
            this.MainSplit.SplitterDistance = 299;
            this.MainSplit.SplitterWidth = 7;
            this.MainSplit.TabIndex = 4;
            this.MainSplit.TabStop = false;
            // 
            // SearchCriteriaFrame
            // 
            this.SearchCriteriaFrame.Controls.Add(this.SearchForButton);
            this.SearchCriteriaFrame.Controls.Add(this.StartButton);
            this.SearchCriteriaFrame.Controls.Add(this.PauseButton);
            this.SearchCriteriaFrame.Controls.Add(this.ResumeButton);
            this.SearchCriteriaFrame.Controls.Add(this.StopButton);
            this.SearchCriteriaFrame.Controls.Add(this.SearchCriteriaTabs);
            this.SearchCriteriaFrame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SearchCriteriaFrame.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchCriteriaFrame.Location = new System.Drawing.Point(0, 0);
            this.SearchCriteriaFrame.Name = "SearchCriteriaFrame";
            this.SearchCriteriaFrame.Size = new System.Drawing.Size(299, 571);
            this.SearchCriteriaFrame.TabIndex = 3;
            this.SearchCriteriaFrame.TabStop = false;
            this.SearchCriteriaFrame.Text = "Search Criteria:";
            // 
            // SearchForButton
            // 
            this.SearchForButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchForButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchForButton.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.SearchForButton.Location = new System.Drawing.Point(120, 20);
            this.SearchForButton.Name = "SearchForButton";
            this.SearchForButton.Size = new System.Drawing.Size(168, 17);
            this.SearchForButton.TabIndex = 5;
            this.SearchForButton.TabStop = true;
            this.SearchForButton.Text = "Search For...";
            this.SearchForButton.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.SearchForButton.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.SearchForButton_LinkClicked);
            this.SearchForButton.Click += new System.EventHandler(this.SearchForButton_Click);
            // 
            // StartButton
            // 
            this.StartButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.StartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartButton.Image = ((System.Drawing.Image)(resources.GetObject("StartButton.Image")));
            this.StartButton.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.StartButton.Location = new System.Drawing.Point(6, 539);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(60, 26);
            this.StartButton.TabIndex = 1;
            this.StartButton.Text = "&Start";
            this.StartButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartSearchingToolStripMenuItem_Click);
            // 
            // PauseButton
            // 
            this.PauseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PauseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PauseButton.Image = ((System.Drawing.Image)(resources.GetObject("PauseButton.Image")));
            this.PauseButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.PauseButton.Location = new System.Drawing.Point(71, 539);
            this.PauseButton.Name = "PauseButton";
            this.PauseButton.Size = new System.Drawing.Size(61, 26);
            this.PauseButton.TabIndex = 3;
            this.PauseButton.Text = "&Pause";
            this.PauseButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.PauseButton.UseVisualStyleBackColor = true;
            this.PauseButton.Click += new System.EventHandler(this.PauseSearchingToolStripMenuItem_Click);
            // 
            // ResumeButton
            // 
            this.ResumeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ResumeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResumeButton.Image = ((System.Drawing.Image)(resources.GetObject("ResumeButton.Image")));
            this.ResumeButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ResumeButton.Location = new System.Drawing.Point(166, 539);
            this.ResumeButton.Name = "ResumeButton";
            this.ResumeButton.Size = new System.Drawing.Size(61, 26);
            this.ResumeButton.TabIndex = 4;
            this.ResumeButton.Text = "&Resume";
            this.ResumeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ResumeButton.UseVisualStyleBackColor = true;
            this.ResumeButton.Click += new System.EventHandler(this.ResumeSearchingToolStripMenuItem_Click);
            // 
            // StopButton
            // 
            this.StopButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.StopButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StopButton.Image = ((System.Drawing.Image)(resources.GetObject("StopButton.Image")));
            this.StopButton.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.StopButton.Location = new System.Drawing.Point(232, 539);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(60, 26);
            this.StopButton.TabIndex = 2;
            this.StopButton.Text = "Sto&p";
            this.StopButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopSearchingToolStripMenuItem_Click);
            // 
            // SearchCriteriaTabs
            // 
            this.SearchCriteriaTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchCriteriaTabs.Controls.Add(this.SearchCriteriaBasicTab);
            this.SearchCriteriaTabs.Controls.Add(this.SearchCriteriaAdvancedTab);
            this.SearchCriteriaTabs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchCriteriaTabs.HotTrack = true;
            this.SearchCriteriaTabs.ItemSize = new System.Drawing.Size(180, 18);
            this.SearchCriteriaTabs.Location = new System.Drawing.Point(6, 20);
            this.SearchCriteriaTabs.Multiline = true;
            this.SearchCriteriaTabs.Name = "SearchCriteriaTabs";
            this.SearchCriteriaTabs.SelectedIndex = 0;
            this.SearchCriteriaTabs.Size = new System.Drawing.Size(286, 515);
            this.SearchCriteriaTabs.TabIndex = 0;
            // 
            // SearchCriteriaBasicTab
            // 
            this.SearchCriteriaBasicTab.Controls.Add(this.SearchCriteriaBasicSplitter);
            this.SearchCriteriaBasicTab.Location = new System.Drawing.Point(4, 22);
            this.SearchCriteriaBasicTab.Name = "SearchCriteriaBasicTab";
            this.SearchCriteriaBasicTab.Padding = new System.Windows.Forms.Padding(3);
            this.SearchCriteriaBasicTab.Size = new System.Drawing.Size(278, 489);
            this.SearchCriteriaBasicTab.TabIndex = 0;
            this.SearchCriteriaBasicTab.Text = "Basic";
            this.SearchCriteriaBasicTab.UseVisualStyleBackColor = true;
            // 
            // SearchCriteriaBasicSplitter
            // 
            this.SearchCriteriaBasicSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SearchCriteriaBasicSplitter.Location = new System.Drawing.Point(3, 3);
            this.SearchCriteriaBasicSplitter.Name = "SearchCriteriaBasicSplitter";
            this.SearchCriteriaBasicSplitter.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SearchCriteriaBasicSplitter.Panel1
            // 
            this.SearchCriteriaBasicSplitter.Panel1.Controls.Add(this.SearchLocationsFrame);
            // 
            // SearchCriteriaBasicSplitter.Panel2
            // 
            this.SearchCriteriaBasicSplitter.Panel2.Controls.Add(this.SearchOptionsFrame);
            this.SearchCriteriaBasicSplitter.Size = new System.Drawing.Size(272, 483);
            this.SearchCriteriaBasicSplitter.SplitterDistance = 165;
            this.SearchCriteriaBasicSplitter.TabIndex = 10;
            this.SearchCriteriaBasicSplitter.TabStop = false;
            // 
            // SearchLocationsFrame
            // 
            this.SearchLocationsFrame.Controls.Add(this.SearchLocationsList);
            this.SearchLocationsFrame.Controls.Add(this.RemoveSearchLocationButton);
            this.SearchLocationsFrame.Controls.Add(this.SearchLocationTxt);
            this.SearchLocationsFrame.Controls.Add(this.AddSearchLocationButton);
            this.SearchLocationsFrame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SearchLocationsFrame.Location = new System.Drawing.Point(0, 0);
            this.SearchLocationsFrame.Name = "SearchLocationsFrame";
            this.SearchLocationsFrame.Size = new System.Drawing.Size(272, 165);
            this.SearchLocationsFrame.TabIndex = 1;
            this.SearchLocationsFrame.TabStop = false;
            this.SearchLocationsFrame.Text = "Search Locations:";
            // 
            // SearchLocationsList
            // 
            this.SearchLocationsList.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.SearchLocationsList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchLocationsList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SearchLocationsList.CheckBoxes = true;
            this.SearchLocationsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.SearchLocationsListNameColumn});
            this.SearchLocationsList.FullRowSelect = true;
            this.SearchLocationsList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.SearchLocationsList.HideSelection = false;
            this.SearchLocationsList.Location = new System.Drawing.Point(7, 43);
            this.SearchLocationsList.Name = "SearchLocationsList";
            this.SearchLocationsList.Size = new System.Drawing.Size(259, 114);
            this.SearchLocationsList.TabIndex = 3;
            this.SearchLocationsList.UseCompatibleStateImageBehavior = false;
            this.SearchLocationsList.View = System.Windows.Forms.View.Details;
            this.SearchLocationsList.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.General_ItemChecked);
            this.SearchLocationsList.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.SearchLocationsList_ItemSelectionChanged);
            this.SearchLocationsList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchLocationsList_KeyDown);
            // 
            // SearchLocationsListNameColumn
            // 
            this.SearchLocationsListNameColumn.Text = "Path";
            this.SearchLocationsListNameColumn.Width = 1000;
            // 
            // RemoveSearchLocationButton
            // 
            this.RemoveSearchLocationButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RemoveSearchLocationButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.RemoveSearchLocationButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemoveSearchLocationButton.Location = new System.Drawing.Point(217, 19);
            this.RemoveSearchLocationButton.Name = "RemoveSearchLocationButton";
            this.RemoveSearchLocationButton.Size = new System.Drawing.Size(49, 20);
            this.RemoveSearchLocationButton.TabIndex = 2;
            this.RemoveSearchLocationButton.Text = "Remo&ve";
            this.RemoveSearchLocationButton.UseVisualStyleBackColor = true;
            this.RemoveSearchLocationButton.Click += new System.EventHandler(this.RemoveSearchLocationsToolStripMenuItem_Click);
            // 
            // SearchLocationTxt
            // 
            this.SearchLocationTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchLocationTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SearchLocationTxt.Location = new System.Drawing.Point(59, 19);
            this.SearchLocationTxt.Name = "SearchLocationTxt";
            this.SearchLocationTxt.ReadOnly = true;
            this.SearchLocationTxt.Size = new System.Drawing.Size(155, 20);
            this.SearchLocationTxt.TabIndex = 11;
            // 
            // AddSearchLocationButton
            // 
            this.AddSearchLocationButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AddSearchLocationButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddSearchLocationButton.Location = new System.Drawing.Point(7, 19);
            this.AddSearchLocationButton.Name = "AddSearchLocationButton";
            this.AddSearchLocationButton.Size = new System.Drawing.Size(49, 20);
            this.AddSearchLocationButton.TabIndex = 1;
            this.AddSearchLocationButton.Text = "A&dd";
            this.AddSearchLocationButton.UseVisualStyleBackColor = true;
            this.AddSearchLocationButton.Click += new System.EventHandler(this.AddSearchLocationToolStripMenuItem_Click);
            // 
            // SearchOptionsFrame
            // 
            this.SearchOptionsFrame.Controls.Add(this.MatchDirectories);
            this.SearchOptionsFrame.Controls.Add(this.MatchFiles);
            this.SearchOptionsFrame.Controls.Add(this.SearchSubdirectories);
            this.SearchOptionsFrame.Controls.Add(this.MatchSizes);
            this.SearchOptionsFrame.Controls.Add(this.MatchFilesToDirectories);
            this.SearchOptionsFrame.Controls.Add(this.MinFileSizeUnits);
            this.SearchOptionsFrame.Controls.Add(this.MinFileSizeLbl);
            this.SearchOptionsFrame.Controls.Add(this.MinFileSize);
            this.SearchOptionsFrame.Controls.Add(this.MaxFileSizeUnits);
            this.SearchOptionsFrame.Controls.Add(this.MaxFileSizeLbl);
            this.SearchOptionsFrame.Controls.Add(this.MaxFileSize);
            this.SearchOptionsFrame.Controls.Add(this.IncludeExcludeTabs);
            this.SearchOptionsFrame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SearchOptionsFrame.Location = new System.Drawing.Point(0, 0);
            this.SearchOptionsFrame.Name = "SearchOptionsFrame";
            this.SearchOptionsFrame.Size = new System.Drawing.Size(272, 314);
            this.SearchOptionsFrame.TabIndex = 0;
            this.SearchOptionsFrame.TabStop = false;
            this.SearchOptionsFrame.Text = "Search Options:";
            // 
            // MatchDirectories
            // 
            this.MatchDirectories.AutoSize = true;
            this.MatchDirectories.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.MatchDirectories.Location = new System.Drawing.Point(6, 15);
            this.MatchDirectories.Name = "MatchDirectories";
            this.MatchDirectories.Size = new System.Drawing.Size(107, 17);
            this.MatchDirectories.TabIndex = 4;
            this.MatchDirectories.Text = "Match Directories";
            this.MatchDirectories.UseVisualStyleBackColor = true;
            this.MatchDirectories.CheckedChanged += new System.EventHandler(this.General_CheckedChanged);
            // 
            // MatchFiles
            // 
            this.MatchFiles.AutoSize = true;
            this.MatchFiles.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.MatchFiles.Location = new System.Drawing.Point(142, 15);
            this.MatchFiles.Name = "MatchFiles";
            this.MatchFiles.Size = new System.Drawing.Size(78, 17);
            this.MatchFiles.TabIndex = 5;
            this.MatchFiles.Text = "Match Files";
            this.MatchFiles.UseVisualStyleBackColor = true;
            this.MatchFiles.CheckedChanged += new System.EventHandler(this.General_CheckedChanged);
            // 
            // SearchSubdirectories
            // 
            this.SearchSubdirectories.AutoSize = true;
            this.SearchSubdirectories.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SearchSubdirectories.Location = new System.Drawing.Point(6, 32);
            this.SearchSubdirectories.Name = "SearchSubdirectories";
            this.SearchSubdirectories.Size = new System.Drawing.Size(128, 17);
            this.SearchSubdirectories.TabIndex = 6;
            this.SearchSubdirectories.Text = "Search Subdirectories";
            this.SearchSubdirectories.UseVisualStyleBackColor = true;
            this.SearchSubdirectories.CheckedChanged += new System.EventHandler(this.General_CheckedChanged);
            // 
            // MatchSizes
            // 
            this.MatchSizes.AutoSize = true;
            this.MatchSizes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.MatchSizes.Location = new System.Drawing.Point(142, 32);
            this.MatchSizes.Name = "MatchSizes";
            this.MatchSizes.Size = new System.Drawing.Size(82, 17);
            this.MatchSizes.TabIndex = 7;
            this.MatchSizes.Text = "Match Sizes";
            this.MatchSizes.UseVisualStyleBackColor = true;
            this.MatchSizes.CheckedChanged += new System.EventHandler(this.General_CheckedChanged);
            // 
            // MatchFilesToDirectories
            // 
            this.MatchFilesToDirectories.AutoSize = true;
            this.MatchFilesToDirectories.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.MatchFilesToDirectories.Location = new System.Drawing.Point(6, 49);
            this.MatchFilesToDirectories.Name = "MatchFilesToDirectories";
            this.MatchFilesToDirectories.Size = new System.Drawing.Size(147, 17);
            this.MatchFilesToDirectories.TabIndex = 8;
            this.MatchFilesToDirectories.Text = "Match Files To Directories";
            this.MatchFilesToDirectories.UseVisualStyleBackColor = true;
            this.MatchFilesToDirectories.CheckedChanged += new System.EventHandler(this.General_TextChanged);
            // 
            // MinFileSizeUnits
            // 
            this.MinFileSizeUnits.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MinFileSizeUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MinFileSizeUnits.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.MinFileSizeUnits.ItemHeight = 13;
            this.MinFileSizeUnits.Items.AddRange(new object[] {
            "bytes",
            "KB",
            "MB",
            "GB",
            "TB",
            "PB",
            "EB"});
            this.MinFileSizeUnits.Location = new System.Drawing.Point(217, 69);
            this.MinFileSizeUnits.Name = "MinFileSizeUnits";
            this.MinFileSizeUnits.Size = new System.Drawing.Size(49, 21);
            this.MinFileSizeUnits.TabIndex = 10;
            this.MinFileSizeUnits.SelectedIndexChanged += new System.EventHandler(this.General_TextChanged);
            // 
            // MinFileSizeLbl
            // 
            this.MinFileSizeLbl.AutoSize = true;
            this.MinFileSizeLbl.Location = new System.Drawing.Point(6, 72);
            this.MinFileSizeLbl.Name = "MinFileSizeLbl";
            this.MinFileSizeLbl.Size = new System.Drawing.Size(69, 13);
            this.MinFileSizeLbl.TabIndex = 43;
            this.MinFileSizeLbl.Text = "Min File Size:";
            // 
            // MinFileSize
            // 
            this.MinFileSize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MinFileSize.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MinFileSize.Location = new System.Drawing.Point(81, 71);
            this.MinFileSize.Maximum = new decimal(new int[] {
            268435455,
            1042612833,
            542101086,
            0});
            this.MinFileSize.Name = "MinFileSize";
            this.MinFileSize.Size = new System.Drawing.Size(130, 16);
            this.MinFileSize.TabIndex = 9;
            this.MinFileSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.MinFileSize.ThousandsSeparator = true;
            this.MinFileSize.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.MinFileSize.ValueChanged += new System.EventHandler(this.General_TextChanged);
            // 
            // MaxFileSizeUnits
            // 
            this.MaxFileSizeUnits.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MaxFileSizeUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MaxFileSizeUnits.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.MaxFileSizeUnits.ItemHeight = 13;
            this.MaxFileSizeUnits.Items.AddRange(new object[] {
            "bytes",
            "KB",
            "MB",
            "GB",
            "TB",
            "PB",
            "EB"});
            this.MaxFileSizeUnits.Location = new System.Drawing.Point(217, 93);
            this.MaxFileSizeUnits.Name = "MaxFileSizeUnits";
            this.MaxFileSizeUnits.Size = new System.Drawing.Size(49, 21);
            this.MaxFileSizeUnits.TabIndex = 12;
            this.MaxFileSizeUnits.SelectedIndexChanged += new System.EventHandler(this.General_TextChanged);
            // 
            // MaxFileSizeLbl
            // 
            this.MaxFileSizeLbl.AutoSize = true;
            this.MaxFileSizeLbl.Location = new System.Drawing.Point(6, 96);
            this.MaxFileSizeLbl.Name = "MaxFileSizeLbl";
            this.MaxFileSizeLbl.Size = new System.Drawing.Size(72, 13);
            this.MaxFileSizeLbl.TabIndex = 46;
            this.MaxFileSizeLbl.Text = "Max File Size:";
            // 
            // MaxFileSize
            // 
            this.MaxFileSize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MaxFileSize.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MaxFileSize.Location = new System.Drawing.Point(81, 96);
            this.MaxFileSize.Maximum = new decimal(new int[] {
            268435455,
            1042612833,
            542101086,
            0});
            this.MaxFileSize.Name = "MaxFileSize";
            this.MaxFileSize.Size = new System.Drawing.Size(130, 16);
            this.MaxFileSize.TabIndex = 11;
            this.MaxFileSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.MaxFileSize.ThousandsSeparator = true;
            this.MaxFileSize.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.MaxFileSize.ValueChanged += new System.EventHandler(this.General_TextChanged);
            // 
            // IncludeExcludeTabs
            // 
            this.IncludeExcludeTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.IncludeExcludeTabs.Controls.Add(this.FileFiltersTab);
            this.IncludeExcludeTabs.Controls.Add(this.DirectoryFiltersTab);
            this.IncludeExcludeTabs.HotTrack = true;
            this.IncludeExcludeTabs.Location = new System.Drawing.Point(6, 117);
            this.IncludeExcludeTabs.Name = "IncludeExcludeTabs";
            this.IncludeExcludeTabs.SelectedIndex = 0;
            this.IncludeExcludeTabs.Size = new System.Drawing.Size(260, 191);
            this.IncludeExcludeTabs.TabIndex = 0;
            // 
            // FileFiltersTab
            // 
            this.FileFiltersTab.Controls.Add(this.FileFiltersTablePanel);
            this.FileFiltersTab.Location = new System.Drawing.Point(4, 22);
            this.FileFiltersTab.Name = "FileFiltersTab";
            this.FileFiltersTab.Size = new System.Drawing.Size(252, 165);
            this.FileFiltersTab.TabIndex = 0;
            this.FileFiltersTab.Text = "File Name Filters";
            this.FileFiltersTab.UseVisualStyleBackColor = true;
            // 
            // FileFiltersTablePanel
            // 
            this.FileFiltersTablePanel.ColumnCount = 2;
            this.FileFiltersTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.FileFiltersTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.FileFiltersTablePanel.Controls.Add(this.FileExcludeFiltersFrame, 0, 0);
            this.FileFiltersTablePanel.Controls.Add(this.FileIncludeFiltersFrame, 0, 0);
            this.FileFiltersTablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FileFiltersTablePanel.Location = new System.Drawing.Point(0, 0);
            this.FileFiltersTablePanel.Name = "FileFiltersTablePanel";
            this.FileFiltersTablePanel.RowCount = 1;
            this.FileFiltersTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.FileFiltersTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 165F));
            this.FileFiltersTablePanel.Size = new System.Drawing.Size(252, 165);
            this.FileFiltersTablePanel.TabIndex = 0;
            // 
            // FileExcludeFiltersFrame
            // 
            this.FileExcludeFiltersFrame.Controls.Add(this.NewFileExcludeFilter);
            this.FileExcludeFiltersFrame.Controls.Add(this.RemoveFileExcludeFilterButton);
            this.FileExcludeFiltersFrame.Controls.Add(this.AddFileExcludeFilterButton);
            this.FileExcludeFiltersFrame.Controls.Add(this.FileExcludeFilterList);
            this.FileExcludeFiltersFrame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FileExcludeFiltersFrame.Location = new System.Drawing.Point(129, 3);
            this.FileExcludeFiltersFrame.Name = "FileExcludeFiltersFrame";
            this.FileExcludeFiltersFrame.Size = new System.Drawing.Size(120, 159);
            this.FileExcludeFiltersFrame.TabIndex = 2;
            this.FileExcludeFiltersFrame.TabStop = false;
            this.FileExcludeFiltersFrame.Text = "Exclude:";
            // 
            // NewFileExcludeFilter
            // 
            this.NewFileExcludeFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NewFileExcludeFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NewFileExcludeFilter.Location = new System.Drawing.Point(39, 18);
            this.NewFileExcludeFilter.Name = "NewFileExcludeFilter";
            this.NewFileExcludeFilter.Size = new System.Drawing.Size(42, 20);
            this.NewFileExcludeFilter.TabIndex = 6;
            this.NewFileExcludeFilter.TextChanged += new System.EventHandler(this.General_TextChanged);
            this.NewFileExcludeFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NewFileExcludeFilter_KeyPress);
            // 
            // RemoveFileExcludeFilterButton
            // 
            this.RemoveFileExcludeFilterButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RemoveFileExcludeFilterButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.RemoveFileExcludeFilterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemoveFileExcludeFilterButton.Location = new System.Drawing.Point(84, 18);
            this.RemoveFileExcludeFilterButton.Name = "RemoveFileExcludeFilterButton";
            this.RemoveFileExcludeFilterButton.Size = new System.Drawing.Size(30, 20);
            this.RemoveFileExcludeFilterButton.TabIndex = 7;
            this.RemoveFileExcludeFilterButton.Text = "Del";
            this.RemoveFileExcludeFilterButton.UseVisualStyleBackColor = true;
            this.RemoveFileExcludeFilterButton.Click += new System.EventHandler(this.RemoveFileExcludeFilterButton_Click);
            // 
            // AddFileExcludeFilterButton
            // 
            this.AddFileExcludeFilterButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AddFileExcludeFilterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddFileExcludeFilterButton.Location = new System.Drawing.Point(6, 18);
            this.AddFileExcludeFilterButton.Name = "AddFileExcludeFilterButton";
            this.AddFileExcludeFilterButton.Size = new System.Drawing.Size(30, 20);
            this.AddFileExcludeFilterButton.TabIndex = 5;
            this.AddFileExcludeFilterButton.Text = "Add";
            this.AddFileExcludeFilterButton.UseVisualStyleBackColor = true;
            this.AddFileExcludeFilterButton.Click += new System.EventHandler(this.AddFileExcludeFilterButton_Click);
            // 
            // FileExcludeFilterList
            // 
            this.FileExcludeFilterList.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.FileExcludeFilterList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FileExcludeFilterList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FileExcludeFilterList.CheckBoxes = true;
            this.FileExcludeFilterList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.FileExcludeFilterColumn});
            this.FileExcludeFilterList.FullRowSelect = true;
            this.FileExcludeFilterList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.FileExcludeFilterList.HideSelection = false;
            this.FileExcludeFilterList.Location = new System.Drawing.Point(6, 42);
            this.FileExcludeFilterList.Name = "FileExcludeFilterList";
            this.FileExcludeFilterList.Size = new System.Drawing.Size(108, 111);
            this.FileExcludeFilterList.TabIndex = 8;
            this.FileExcludeFilterList.UseCompatibleStateImageBehavior = false;
            this.FileExcludeFilterList.View = System.Windows.Forms.View.Details;
            this.FileExcludeFilterList.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.General_ItemChecked);
            this.FileExcludeFilterList.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.FileExcludeFilterList_ItemSelectionChanged);
            this.FileExcludeFilterList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FileExcludeFilterList_KeyDown);
            // 
            // FileExcludeFilterColumn
            // 
            this.FileExcludeFilterColumn.Width = 300;
            // 
            // FileIncludeFiltersFrame
            // 
            this.FileIncludeFiltersFrame.Controls.Add(this.NewFileIncludeFilter);
            this.FileIncludeFiltersFrame.Controls.Add(this.RemoveFileIncludeFilterButton);
            this.FileIncludeFiltersFrame.Controls.Add(this.AddFileIncludeFilterButton);
            this.FileIncludeFiltersFrame.Controls.Add(this.FileIncludeFilterList);
            this.FileIncludeFiltersFrame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FileIncludeFiltersFrame.Location = new System.Drawing.Point(3, 3);
            this.FileIncludeFiltersFrame.Name = "FileIncludeFiltersFrame";
            this.FileIncludeFiltersFrame.Size = new System.Drawing.Size(120, 159);
            this.FileIncludeFiltersFrame.TabIndex = 1;
            this.FileIncludeFiltersFrame.TabStop = false;
            this.FileIncludeFiltersFrame.Text = "Include:";
            // 
            // NewFileIncludeFilter
            // 
            this.NewFileIncludeFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NewFileIncludeFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NewFileIncludeFilter.Location = new System.Drawing.Point(39, 18);
            this.NewFileIncludeFilter.Name = "NewFileIncludeFilter";
            this.NewFileIncludeFilter.Size = new System.Drawing.Size(42, 20);
            this.NewFileIncludeFilter.TabIndex = 2;
            this.NewFileIncludeFilter.TextChanged += new System.EventHandler(this.General_TextChanged);
            this.NewFileIncludeFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NewFileIncludeFilter_KeyPress);
            // 
            // RemoveFileIncludeFilterButton
            // 
            this.RemoveFileIncludeFilterButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RemoveFileIncludeFilterButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.RemoveFileIncludeFilterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemoveFileIncludeFilterButton.Location = new System.Drawing.Point(84, 18);
            this.RemoveFileIncludeFilterButton.Name = "RemoveFileIncludeFilterButton";
            this.RemoveFileIncludeFilterButton.Size = new System.Drawing.Size(30, 20);
            this.RemoveFileIncludeFilterButton.TabIndex = 3;
            this.RemoveFileIncludeFilterButton.Text = "Del";
            this.RemoveFileIncludeFilterButton.UseVisualStyleBackColor = true;
            this.RemoveFileIncludeFilterButton.Click += new System.EventHandler(this.RemoveFileIncludeFilterButton_Click);
            // 
            // AddFileIncludeFilterButton
            // 
            this.AddFileIncludeFilterButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AddFileIncludeFilterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddFileIncludeFilterButton.Location = new System.Drawing.Point(6, 18);
            this.AddFileIncludeFilterButton.Name = "AddFileIncludeFilterButton";
            this.AddFileIncludeFilterButton.Size = new System.Drawing.Size(30, 20);
            this.AddFileIncludeFilterButton.TabIndex = 1;
            this.AddFileIncludeFilterButton.Text = "Add";
            this.AddFileIncludeFilterButton.UseVisualStyleBackColor = true;
            this.AddFileIncludeFilterButton.Click += new System.EventHandler(this.AddFileIncludeFilterButton_Click);
            // 
            // FileIncludeFilterList
            // 
            this.FileIncludeFilterList.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.FileIncludeFilterList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FileIncludeFilterList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FileIncludeFilterList.CheckBoxes = true;
            this.FileIncludeFilterList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.FileIncludeFilterColumn});
            this.FileIncludeFilterList.FullRowSelect = true;
            this.FileIncludeFilterList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.FileIncludeFilterList.HideSelection = false;
            this.FileIncludeFilterList.Location = new System.Drawing.Point(6, 42);
            this.FileIncludeFilterList.Name = "FileIncludeFilterList";
            this.FileIncludeFilterList.Size = new System.Drawing.Size(108, 111);
            this.FileIncludeFilterList.TabIndex = 4;
            this.FileIncludeFilterList.UseCompatibleStateImageBehavior = false;
            this.FileIncludeFilterList.View = System.Windows.Forms.View.Details;
            this.FileIncludeFilterList.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.General_ItemChecked);
            this.FileIncludeFilterList.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.FileIncludeFilterList_ItemSelectionChanged);
            this.FileIncludeFilterList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FileIncludeFilterList_KeyDown);
            // 
            // FileIncludeFilterColumn
            // 
            this.FileIncludeFilterColumn.Text = "Filter";
            this.FileIncludeFilterColumn.Width = 300;
            // 
            // DirectoryFiltersTab
            // 
            this.DirectoryFiltersTab.Controls.Add(this.DirectoryFiltersTablePanel);
            this.DirectoryFiltersTab.Location = new System.Drawing.Point(4, 22);
            this.DirectoryFiltersTab.Name = "DirectoryFiltersTab";
            this.DirectoryFiltersTab.Size = new System.Drawing.Size(252, 165);
            this.DirectoryFiltersTab.TabIndex = 1;
            this.DirectoryFiltersTab.Text = "Dir Name Filters";
            this.DirectoryFiltersTab.UseVisualStyleBackColor = true;
            // 
            // DirectoryFiltersTablePanel
            // 
            this.DirectoryFiltersTablePanel.ColumnCount = 2;
            this.DirectoryFiltersTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.DirectoryFiltersTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.DirectoryFiltersTablePanel.Controls.Add(this.DirectoryIncludeFiltersFrame, 0, 0);
            this.DirectoryFiltersTablePanel.Controls.Add(this.DirectoryExcludeFiltersFrame, 1, 0);
            this.DirectoryFiltersTablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DirectoryFiltersTablePanel.Location = new System.Drawing.Point(0, 0);
            this.DirectoryFiltersTablePanel.Name = "DirectoryFiltersTablePanel";
            this.DirectoryFiltersTablePanel.RowCount = 1;
            this.DirectoryFiltersTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 192F));
            this.DirectoryFiltersTablePanel.Size = new System.Drawing.Size(252, 165);
            this.DirectoryFiltersTablePanel.TabIndex = 0;
            // 
            // DirectoryIncludeFiltersFrame
            // 
            this.DirectoryIncludeFiltersFrame.Controls.Add(this.NewDirIncludeFilter);
            this.DirectoryIncludeFiltersFrame.Controls.Add(this.RemoveDirectoryIncludeFilterButton);
            this.DirectoryIncludeFiltersFrame.Controls.Add(this.AddDirectoryIncludeFilterButton);
            this.DirectoryIncludeFiltersFrame.Controls.Add(this.DirectoryIncludeFilterList);
            this.DirectoryIncludeFiltersFrame.Location = new System.Drawing.Point(3, 3);
            this.DirectoryIncludeFiltersFrame.Name = "DirectoryIncludeFiltersFrame";
            this.DirectoryIncludeFiltersFrame.Size = new System.Drawing.Size(120, 160);
            this.DirectoryIncludeFiltersFrame.TabIndex = 2;
            this.DirectoryIncludeFiltersFrame.TabStop = false;
            this.DirectoryIncludeFiltersFrame.Text = "Include:";
            // 
            // NewDirIncludeFilter
            // 
            this.NewDirIncludeFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NewDirIncludeFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NewDirIncludeFilter.Location = new System.Drawing.Point(39, 18);
            this.NewDirIncludeFilter.Name = "NewDirIncludeFilter";
            this.NewDirIncludeFilter.Size = new System.Drawing.Size(42, 20);
            this.NewDirIncludeFilter.TabIndex = 1;
            this.NewDirIncludeFilter.TextChanged += new System.EventHandler(this.General_TextChanged);
            this.NewDirIncludeFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NewDirIncludeFilter_KeyPress);
            // 
            // RemoveDirectoryIncludeFilterButton
            // 
            this.RemoveDirectoryIncludeFilterButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RemoveDirectoryIncludeFilterButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.RemoveDirectoryIncludeFilterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemoveDirectoryIncludeFilterButton.Location = new System.Drawing.Point(84, 18);
            this.RemoveDirectoryIncludeFilterButton.Name = "RemoveDirectoryIncludeFilterButton";
            this.RemoveDirectoryIncludeFilterButton.Size = new System.Drawing.Size(30, 20);
            this.RemoveDirectoryIncludeFilterButton.TabIndex = 2;
            this.RemoveDirectoryIncludeFilterButton.Text = "Del";
            this.RemoveDirectoryIncludeFilterButton.UseVisualStyleBackColor = true;
            this.RemoveDirectoryIncludeFilterButton.Click += new System.EventHandler(this.RemoveDirectoryIncludeFilterButton_Click);
            // 
            // AddDirectoryIncludeFilterButton
            // 
            this.AddDirectoryIncludeFilterButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AddDirectoryIncludeFilterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddDirectoryIncludeFilterButton.Location = new System.Drawing.Point(6, 18);
            this.AddDirectoryIncludeFilterButton.Name = "AddDirectoryIncludeFilterButton";
            this.AddDirectoryIncludeFilterButton.Size = new System.Drawing.Size(30, 20);
            this.AddDirectoryIncludeFilterButton.TabIndex = 0;
            this.AddDirectoryIncludeFilterButton.Text = "Add";
            this.AddDirectoryIncludeFilterButton.UseVisualStyleBackColor = true;
            this.AddDirectoryIncludeFilterButton.Click += new System.EventHandler(this.AddDirectoryIncludeFilterButton_Click);
            // 
            // DirectoryIncludeFilterList
            // 
            this.DirectoryIncludeFilterList.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.DirectoryIncludeFilterList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DirectoryIncludeFilterList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DirectoryIncludeFilterList.CheckBoxes = true;
            this.DirectoryIncludeFilterList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.DirIncludeFilterColumn});
            this.DirectoryIncludeFilterList.FullRowSelect = true;
            this.DirectoryIncludeFilterList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.DirectoryIncludeFilterList.HideSelection = false;
            this.DirectoryIncludeFilterList.Location = new System.Drawing.Point(6, 42);
            this.DirectoryIncludeFilterList.Name = "DirectoryIncludeFilterList";
            this.DirectoryIncludeFilterList.Size = new System.Drawing.Size(108, 112);
            this.DirectoryIncludeFilterList.TabIndex = 3;
            this.DirectoryIncludeFilterList.UseCompatibleStateImageBehavior = false;
            this.DirectoryIncludeFilterList.View = System.Windows.Forms.View.Details;
            this.DirectoryIncludeFilterList.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.General_ItemChecked);
            this.DirectoryIncludeFilterList.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.DirectoryIncludeFilterList_ItemSelectionChanged);
            this.DirectoryIncludeFilterList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DirectoryIncludeFilterList_KeyDown);
            // 
            // DirIncludeFilterColumn
            // 
            this.DirIncludeFilterColumn.Width = 300;
            // 
            // DirectoryExcludeFiltersFrame
            // 
            this.DirectoryExcludeFiltersFrame.Controls.Add(this.NewDirExcludeFilter);
            this.DirectoryExcludeFiltersFrame.Controls.Add(this.RemoveDirectoryExcludeFilterButton);
            this.DirectoryExcludeFiltersFrame.Controls.Add(this.AddDirectoryExcludeFilterButton);
            this.DirectoryExcludeFiltersFrame.Controls.Add(this.DirectoryExcludeFilterList);
            this.DirectoryExcludeFiltersFrame.Location = new System.Drawing.Point(129, 3);
            this.DirectoryExcludeFiltersFrame.Name = "DirectoryExcludeFiltersFrame";
            this.DirectoryExcludeFiltersFrame.Size = new System.Drawing.Size(120, 160);
            this.DirectoryExcludeFiltersFrame.TabIndex = 3;
            this.DirectoryExcludeFiltersFrame.TabStop = false;
            this.DirectoryExcludeFiltersFrame.Text = "Exclude:";
            // 
            // NewDirExcludeFilter
            // 
            this.NewDirExcludeFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NewDirExcludeFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NewDirExcludeFilter.Location = new System.Drawing.Point(39, 18);
            this.NewDirExcludeFilter.Name = "NewDirExcludeFilter";
            this.NewDirExcludeFilter.Size = new System.Drawing.Size(42, 20);
            this.NewDirExcludeFilter.TabIndex = 5;
            this.NewDirExcludeFilter.TextChanged += new System.EventHandler(this.General_TextChanged);
            this.NewDirExcludeFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NewDirExcludeFilter_KeyPress);
            // 
            // RemoveDirectoryExcludeFilterButton
            // 
            this.RemoveDirectoryExcludeFilterButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RemoveDirectoryExcludeFilterButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.RemoveDirectoryExcludeFilterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemoveDirectoryExcludeFilterButton.Location = new System.Drawing.Point(84, 18);
            this.RemoveDirectoryExcludeFilterButton.Name = "RemoveDirectoryExcludeFilterButton";
            this.RemoveDirectoryExcludeFilterButton.Size = new System.Drawing.Size(30, 20);
            this.RemoveDirectoryExcludeFilterButton.TabIndex = 8;
            this.RemoveDirectoryExcludeFilterButton.Text = "Del";
            this.RemoveDirectoryExcludeFilterButton.UseVisualStyleBackColor = true;
            this.RemoveDirectoryExcludeFilterButton.Click += new System.EventHandler(this.RemoveDirectoryExcludeFilterButton_Click);
            // 
            // AddDirectoryExcludeFilterButton
            // 
            this.AddDirectoryExcludeFilterButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AddDirectoryExcludeFilterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddDirectoryExcludeFilterButton.Location = new System.Drawing.Point(6, 18);
            this.AddDirectoryExcludeFilterButton.Name = "AddDirectoryExcludeFilterButton";
            this.AddDirectoryExcludeFilterButton.Size = new System.Drawing.Size(30, 20);
            this.AddDirectoryExcludeFilterButton.TabIndex = 4;
            this.AddDirectoryExcludeFilterButton.Text = "Add";
            this.AddDirectoryExcludeFilterButton.UseVisualStyleBackColor = true;
            this.AddDirectoryExcludeFilterButton.Click += new System.EventHandler(this.AddDirectoryExcludeFilterButton_Click);
            // 
            // DirectoryExcludeFilterList
            // 
            this.DirectoryExcludeFilterList.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.DirectoryExcludeFilterList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DirectoryExcludeFilterList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DirectoryExcludeFilterList.CheckBoxes = true;
            this.DirectoryExcludeFilterList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.DirExcludeFilterColumn});
            this.DirectoryExcludeFilterList.FullRowSelect = true;
            this.DirectoryExcludeFilterList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.DirectoryExcludeFilterList.HideSelection = false;
            this.DirectoryExcludeFilterList.Location = new System.Drawing.Point(6, 42);
            this.DirectoryExcludeFilterList.Name = "DirectoryExcludeFilterList";
            this.DirectoryExcludeFilterList.Size = new System.Drawing.Size(108, 112);
            this.DirectoryExcludeFilterList.TabIndex = 9;
            this.DirectoryExcludeFilterList.UseCompatibleStateImageBehavior = false;
            this.DirectoryExcludeFilterList.View = System.Windows.Forms.View.Details;
            this.DirectoryExcludeFilterList.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.General_ItemChecked);
            this.DirectoryExcludeFilterList.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.DirectoryExcludeFilterList_ItemSelectionChanged);
            this.DirectoryExcludeFilterList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DirectoryExcludeFilterList_KeyDown);
            // 
            // DirExcludeFilterColumn
            // 
            this.DirExcludeFilterColumn.Text = "Filter";
            this.DirExcludeFilterColumn.Width = 300;
            // 
            // SearchCriteriaAdvancedTab
            // 
            this.SearchCriteriaAdvancedTab.AutoScroll = true;
            this.SearchCriteriaAdvancedTab.Controls.Add(this.MiscFrame);
            this.SearchCriteriaAdvancedTab.Controls.Add(this.OutputFileFrame);
            this.SearchCriteriaAdvancedTab.Controls.Add(this.LogFileFrame);
            this.SearchCriteriaAdvancedTab.Controls.Add(this.CompareContentsFrame);
            this.SearchCriteriaAdvancedTab.Controls.Add(this.CompareNamesFrame);
            this.SearchCriteriaAdvancedTab.Location = new System.Drawing.Point(4, 22);
            this.SearchCriteriaAdvancedTab.Name = "SearchCriteriaAdvancedTab";
            this.SearchCriteriaAdvancedTab.Padding = new System.Windows.Forms.Padding(3);
            this.SearchCriteriaAdvancedTab.Size = new System.Drawing.Size(278, 489);
            this.SearchCriteriaAdvancedTab.TabIndex = 1;
            this.SearchCriteriaAdvancedTab.Text = "Advanced";
            this.SearchCriteriaAdvancedTab.UseVisualStyleBackColor = true;
            // 
            // MiscFrame
            // 
            this.MiscFrame.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MiscFrame.Controls.Add(this.MaxSearchThreads);
            this.MiscFrame.Controls.Add(this.MaxSearchThreadsLabel);
            this.MiscFrame.Controls.Add(this.SearchMode);
            this.MiscFrame.Controls.Add(this.UseDefaultFilters);
            this.MiscFrame.Controls.Add(this.MergeFilters);
            this.MiscFrame.Controls.Add(this.PreloadContent);
            this.MiscFrame.Controls.Add(this.MatchOnNameORContent);
            this.MiscFrame.Controls.Add(this.SearchModeLabel);
            this.MiscFrame.Location = new System.Drawing.Point(0, 357);
            this.MiscFrame.Name = "MiscFrame";
            this.MiscFrame.Size = new System.Drawing.Size(275, 129);
            this.MiscFrame.TabIndex = 44;
            this.MiscFrame.TabStop = false;
            this.MiscFrame.Text = "Misc:";
            // 
            // MaxSearchThreads
            // 
            this.MaxSearchThreads.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MaxSearchThreads.Location = new System.Drawing.Point(167, 85);
            this.MaxSearchThreads.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.MaxSearchThreads.Name = "MaxSearchThreads";
            this.MaxSearchThreads.Size = new System.Drawing.Size(58, 16);
            this.MaxSearchThreads.TabIndex = 53;
            this.MaxSearchThreads.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.MaxSearchThreads.ThousandsSeparator = true;
            this.MaxSearchThreads.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.MaxSearchThreads.ValueChanged += new System.EventHandler(this.General_CheckedChanged);
            // 
            // MaxSearchThreadsLabel
            // 
            this.MaxSearchThreadsLabel.AutoSize = true;
            this.MaxSearchThreadsLabel.Location = new System.Drawing.Point(6, 87);
            this.MaxSearchThreadsLabel.Name = "MaxSearchThreadsLabel";
            this.MaxSearchThreadsLabel.Size = new System.Drawing.Size(161, 13);
            this.MaxSearchThreadsLabel.TabIndex = 52;
            this.MaxSearchThreadsLabel.Text = "Max. Search Threads (0 is auto):";
            // 
            // SearchMode
            // 
            this.SearchMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SearchMode.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SearchMode.ItemHeight = 13;
            this.SearchMode.Items.AddRange(new object[] {
            "0: Top-down",
            "1: Bottom-up"});
            this.SearchMode.Location = new System.Drawing.Point(86, 13);
            this.SearchMode.Name = "SearchMode";
            this.SearchMode.Size = new System.Drawing.Size(182, 21);
            this.SearchMode.TabIndex = 46;
            this.SearchMode.SelectedIndexChanged += new System.EventHandler(this.General_TextChanged);
            // 
            // UseDefaultFilters
            // 
            this.UseDefaultFilters.AutoSize = true;
            this.UseDefaultFilters.Checked = true;
            this.UseDefaultFilters.CheckState = System.Windows.Forms.CheckState.Checked;
            this.UseDefaultFilters.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.UseDefaultFilters.Location = new System.Drawing.Point(9, 35);
            this.UseDefaultFilters.Name = "UseDefaultFilters";
            this.UseDefaultFilters.Size = new System.Drawing.Size(176, 17);
            this.UseDefaultFilters.TabIndex = 48;
            this.UseDefaultFilters.Text = "Use Default File/Directory Filters";
            this.UseDefaultFilters.UseVisualStyleBackColor = true;
            this.UseDefaultFilters.CheckedChanged += new System.EventHandler(this.General_CheckedChanged);
            // 
            // MergeFilters
            // 
            this.MergeFilters.AutoSize = true;
            this.MergeFilters.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.MergeFilters.Location = new System.Drawing.Point(9, 51);
            this.MergeFilters.Name = "MergeFilters";
            this.MergeFilters.Size = new System.Drawing.Size(84, 17);
            this.MergeFilters.TabIndex = 49;
            this.MergeFilters.Text = "Merge Filters";
            this.MergeFilters.UseVisualStyleBackColor = true;
            this.MergeFilters.CheckedChanged += new System.EventHandler(this.General_CheckedChanged);
            // 
            // PreloadContent
            // 
            this.PreloadContent.AutoSize = true;
            this.PreloadContent.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.PreloadContent.Location = new System.Drawing.Point(108, 51);
            this.PreloadContent.Name = "PreloadContent";
            this.PreloadContent.Size = new System.Drawing.Size(60, 17);
            this.PreloadContent.TabIndex = 51;
            this.PreloadContent.Text = "Preload";
            this.PreloadContent.UseVisualStyleBackColor = true;
            this.PreloadContent.CheckedChanged += new System.EventHandler(this.General_CheckedChanged);
            // 
            // MatchOnNameORContent
            // 
            this.MatchOnNameORContent.AutoSize = true;
            this.MatchOnNameORContent.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.MatchOnNameORContent.Location = new System.Drawing.Point(9, 67);
            this.MatchOnNameORContent.Name = "MatchOnNameORContent";
            this.MatchOnNameORContent.Size = new System.Drawing.Size(161, 17);
            this.MatchOnNameORContent.TabIndex = 50;
            this.MatchOnNameORContent.Text = "Match On Name OR Content";
            this.MatchOnNameORContent.UseVisualStyleBackColor = true;
            this.MatchOnNameORContent.CheckedChanged += new System.EventHandler(this.General_CheckedChanged);
            // 
            // SearchModeLabel
            // 
            this.SearchModeLabel.AutoSize = true;
            this.SearchModeLabel.Location = new System.Drawing.Point(6, 16);
            this.SearchModeLabel.Name = "SearchModeLabel";
            this.SearchModeLabel.Size = new System.Drawing.Size(74, 13);
            this.SearchModeLabel.TabIndex = 47;
            this.SearchModeLabel.Text = "Search Mode:";
            // 
            // OutputFileFrame
            // 
            this.OutputFileFrame.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OutputFileFrame.Controls.Add(this.AppendOutputFile);
            this.OutputFileFrame.Controls.Add(this.OnlyOutputFile);
            this.OutputFileFrame.Controls.Add(this.UseOutputFile);
            this.OutputFileFrame.Controls.Add(this.OutputFileBrowseButton);
            this.OutputFileFrame.Controls.Add(this.OutputFile);
            this.OutputFileFrame.Controls.Add(this.OutputFileLabel);
            this.OutputFileFrame.Location = new System.Drawing.Point(0, 232);
            this.OutputFileFrame.Name = "OutputFileFrame";
            this.OutputFileFrame.Size = new System.Drawing.Size(275, 59);
            this.OutputFileFrame.TabIndex = 43;
            this.OutputFileFrame.TabStop = false;
            // 
            // AppendOutputFile
            // 
            this.AppendOutputFile.AutoSize = true;
            this.AppendOutputFile.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AppendOutputFile.Location = new System.Drawing.Point(108, 39);
            this.AppendOutputFile.Name = "AppendOutputFile";
            this.AppendOutputFile.Size = new System.Drawing.Size(115, 17);
            this.AppendOutputFile.TabIndex = 29;
            this.AppendOutputFile.Text = "Append Output File";
            this.AppendOutputFile.UseVisualStyleBackColor = true;
            this.AppendOutputFile.CheckedChanged += new System.EventHandler(this.General_CheckedChanged);
            // 
            // OnlyOutputFile
            // 
            this.OnlyOutputFile.AutoSize = true;
            this.OnlyOutputFile.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.OnlyOutputFile.Location = new System.Drawing.Point(9, 39);
            this.OnlyOutputFile.Name = "OnlyOutputFile";
            this.OnlyOutputFile.Size = new System.Drawing.Size(99, 17);
            this.OnlyOutputFile.TabIndex = 28;
            this.OnlyOutputFile.Text = "Only Output File";
            this.OnlyOutputFile.UseVisualStyleBackColor = true;
            this.OnlyOutputFile.CheckedChanged += new System.EventHandler(this.General_CheckedChanged);
            // 
            // UseOutputFile
            // 
            this.UseOutputFile.AutoSize = true;
            this.UseOutputFile.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.UseOutputFile.Location = new System.Drawing.Point(9, -1);
            this.UseOutputFile.Name = "UseOutputFile";
            this.UseOutputFile.Size = new System.Drawing.Size(100, 17);
            this.UseOutputFile.TabIndex = 27;
            this.UseOutputFile.Text = "Use Output File:";
            this.UseOutputFile.UseVisualStyleBackColor = true;
            this.UseOutputFile.CheckedChanged += new System.EventHandler(this.General_CheckedChanged);
            // 
            // OutputFileBrowseButton
            // 
            this.OutputFileBrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.OutputFileBrowseButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.OutputFileBrowseButton.Location = new System.Drawing.Point(218, 19);
            this.OutputFileBrowseButton.Name = "OutputFileBrowseButton";
            this.OutputFileBrowseButton.Size = new System.Drawing.Size(51, 20);
            this.OutputFileBrowseButton.TabIndex = 26;
            this.OutputFileBrowseButton.Text = "Browse";
            this.OutputFileBrowseButton.UseVisualStyleBackColor = true;
            this.OutputFileBrowseButton.Click += new System.EventHandler(this.OutputFileBrowseButton_Click);
            // 
            // OutputFile
            // 
            this.OutputFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OutputFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.OutputFile.Location = new System.Drawing.Point(73, 19);
            this.OutputFile.Name = "OutputFile";
            this.OutputFile.Size = new System.Drawing.Size(139, 20);
            this.OutputFile.TabIndex = 25;
            this.OutputFile.TextChanged += new System.EventHandler(this.General_TextChanged);
            // 
            // OutputFileLabel
            // 
            this.OutputFileLabel.AutoSize = true;
            this.OutputFileLabel.Location = new System.Drawing.Point(6, 22);
            this.OutputFileLabel.Name = "OutputFileLabel";
            this.OutputFileLabel.Size = new System.Drawing.Size(61, 13);
            this.OutputFileLabel.TabIndex = 24;
            this.OutputFileLabel.Text = "Output File:";
            // 
            // LogFileFrame
            // 
            this.LogFileFrame.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LogFileFrame.Controls.Add(this.LogFile);
            this.LogFileFrame.Controls.Add(this.AppendLogFile);
            this.LogFileFrame.Controls.Add(this.UseLogFile);
            this.LogFileFrame.Controls.Add(this.LogFileBrowseButton);
            this.LogFileFrame.Controls.Add(this.LogFileLabel);
            this.LogFileFrame.Location = new System.Drawing.Point(0, 295);
            this.LogFileFrame.Name = "LogFileFrame";
            this.LogFileFrame.Size = new System.Drawing.Size(275, 58);
            this.LogFileFrame.TabIndex = 42;
            this.LogFileFrame.TabStop = false;
            // 
            // LogFile
            // 
            this.LogFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LogFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LogFile.Location = new System.Drawing.Point(73, 18);
            this.LogFile.Name = "LogFile";
            this.LogFile.Size = new System.Drawing.Size(139, 20);
            this.LogFile.TabIndex = 25;
            this.LogFile.TextChanged += new System.EventHandler(this.General_TextChanged);
            // 
            // AppendLogFile
            // 
            this.AppendLogFile.AutoSize = true;
            this.AppendLogFile.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AppendLogFile.Location = new System.Drawing.Point(9, 38);
            this.AppendLogFile.Name = "AppendLogFile";
            this.AppendLogFile.Size = new System.Drawing.Size(101, 17);
            this.AppendLogFile.TabIndex = 28;
            this.AppendLogFile.Text = "Append Log File";
            this.AppendLogFile.UseVisualStyleBackColor = true;
            this.AppendLogFile.CheckedChanged += new System.EventHandler(this.General_CheckedChanged);
            // 
            // UseLogFile
            // 
            this.UseLogFile.AutoSize = true;
            this.UseLogFile.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.UseLogFile.Location = new System.Drawing.Point(9, -1);
            this.UseLogFile.Name = "UseLogFile";
            this.UseLogFile.Size = new System.Drawing.Size(86, 17);
            this.UseLogFile.TabIndex = 27;
            this.UseLogFile.Text = "Use Log File:";
            this.UseLogFile.UseVisualStyleBackColor = true;
            this.UseLogFile.CheckedChanged += new System.EventHandler(this.General_CheckedChanged);
            // 
            // LogFileBrowseButton
            // 
            this.LogFileBrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LogFileBrowseButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.LogFileBrowseButton.Location = new System.Drawing.Point(218, 18);
            this.LogFileBrowseButton.Name = "LogFileBrowseButton";
            this.LogFileBrowseButton.Size = new System.Drawing.Size(51, 20);
            this.LogFileBrowseButton.TabIndex = 26;
            this.LogFileBrowseButton.Text = "Browse";
            this.LogFileBrowseButton.UseVisualStyleBackColor = true;
            this.LogFileBrowseButton.Click += new System.EventHandler(this.LogFileBrowseButton_Click);
            // 
            // LogFileLabel
            // 
            this.LogFileLabel.AutoSize = true;
            this.LogFileLabel.Location = new System.Drawing.Point(6, 21);
            this.LogFileLabel.Name = "LogFileLabel";
            this.LogFileLabel.Size = new System.Drawing.Size(47, 13);
            this.LogFileLabel.TabIndex = 24;
            this.LogFileLabel.Text = "Log File:";
            // 
            // CompareContentsFrame
            // 
            this.CompareContentsFrame.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CompareContentsFrame.Controls.Add(this.CompareDirectoryContents);
            this.CompareContentsFrame.Controls.Add(this.HeaderFooterSizeBytesLabel);
            this.CompareContentsFrame.Controls.Add(this.HeaderFooterSize);
            this.CompareContentsFrame.Controls.Add(this.HeaderFooterSizeLabel);
            this.CompareContentsFrame.Controls.Add(this.CCModeFrame);
            this.CompareContentsFrame.Controls.Add(this.MatchContents);
            this.CompareContentsFrame.Location = new System.Drawing.Point(0, 115);
            this.CompareContentsFrame.Name = "CompareContentsFrame";
            this.CompareContentsFrame.Size = new System.Drawing.Size(275, 113);
            this.CompareContentsFrame.TabIndex = 33;
            this.CompareContentsFrame.TabStop = false;
            // 
            // CompareDirectoryContents
            // 
            this.CompareDirectoryContents.AutoSize = true;
            this.CompareDirectoryContents.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CompareDirectoryContents.Location = new System.Drawing.Point(9, 74);
            this.CompareDirectoryContents.Name = "CompareDirectoryContents";
            this.CompareDirectoryContents.Size = new System.Drawing.Size(211, 17);
            this.CompareDirectoryContents.TabIndex = 37;
            this.CompareDirectoryContents.Text = "Compare Root-Level Directory Contents";
            this.CompareDirectoryContents.UseVisualStyleBackColor = true;
            this.CompareDirectoryContents.CheckedChanged += new System.EventHandler(this.General_CheckedChanged);
            // 
            // HeaderFooterSizeBytesLabel
            // 
            this.HeaderFooterSizeBytesLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.HeaderFooterSizeBytesLabel.AutoSize = true;
            this.HeaderFooterSizeBytesLabel.Location = new System.Drawing.Point(173, 92);
            this.HeaderFooterSizeBytesLabel.Name = "HeaderFooterSizeBytesLabel";
            this.HeaderFooterSizeBytesLabel.Size = new System.Drawing.Size(32, 13);
            this.HeaderFooterSizeBytesLabel.TabIndex = 36;
            this.HeaderFooterSizeBytesLabel.Text = "bytes";
            // 
            // HeaderFooterSize
            // 
            this.HeaderFooterSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.HeaderFooterSize.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.HeaderFooterSize.Increment = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.HeaderFooterSize.Location = new System.Drawing.Point(111, 92);
            this.HeaderFooterSize.Maximum = new decimal(new int[] {
            -1981284353,
            -1966660860,
            0,
            0});
            this.HeaderFooterSize.Name = "HeaderFooterSize";
            this.HeaderFooterSize.Size = new System.Drawing.Size(58, 16);
            this.HeaderFooterSize.TabIndex = 35;
            this.HeaderFooterSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.HeaderFooterSize.ThousandsSeparator = true;
            this.HeaderFooterSize.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.HeaderFooterSize.ValueChanged += new System.EventHandler(this.General_TextChanged);
            // 
            // HeaderFooterSizeLabel
            // 
            this.HeaderFooterSizeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.HeaderFooterSizeLabel.AutoSize = true;
            this.HeaderFooterSizeLabel.Location = new System.Drawing.Point(6, 93);
            this.HeaderFooterSizeLabel.Name = "HeaderFooterSizeLabel";
            this.HeaderFooterSizeLabel.Size = new System.Drawing.Size(103, 13);
            this.HeaderFooterSizeLabel.TabIndex = 34;
            this.HeaderFooterSizeLabel.Text = "Header/Footer Size:";
            // 
            // CCModeFrame
            // 
            this.CCModeFrame.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CCModeFrame.Controls.Add(this.CCModeHeaderAndFooter);
            this.CCModeFrame.Controls.Add(this.CCModeHeader);
            this.CCModeFrame.Controls.Add(this.CCModeAllContents);
            this.CCModeFrame.Location = new System.Drawing.Point(9, 19);
            this.CCModeFrame.Name = "CCModeFrame";
            this.CCModeFrame.Size = new System.Drawing.Size(260, 51);
            this.CCModeFrame.TabIndex = 33;
            this.CCModeFrame.TabStop = false;
            this.CCModeFrame.Text = "Content Comparison Mode:";
            // 
            // CCModeHeaderAndFooter
            // 
            this.CCModeHeaderAndFooter.AutoSize = true;
            this.CCModeHeaderAndFooter.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.CCModeHeaderAndFooter.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CCModeHeaderAndFooter.Location = new System.Drawing.Point(67, 14);
            this.CCModeHeaderAndFooter.Name = "CCModeHeaderAndFooter";
            this.CCModeHeaderAndFooter.Size = new System.Drawing.Size(113, 17);
            this.CCModeHeaderAndFooter.TabIndex = 33;
            this.CCModeHeaderAndFooter.TabStop = true;
            this.CCModeHeaderAndFooter.Text = "Header and Footer";
            this.CCModeHeaderAndFooter.UseVisualStyleBackColor = true;
            this.CCModeHeaderAndFooter.CheckedChanged += new System.EventHandler(this.General_CheckedChanged);
            // 
            // CCModeHeader
            // 
            this.CCModeHeader.AutoSize = true;
            this.CCModeHeader.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.CCModeHeader.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CCModeHeader.Location = new System.Drawing.Point(15, 30);
            this.CCModeHeader.Name = "CCModeHeader";
            this.CCModeHeader.Size = new System.Drawing.Size(59, 17);
            this.CCModeHeader.TabIndex = 32;
            this.CCModeHeader.TabStop = true;
            this.CCModeHeader.Text = "Header";
            this.CCModeHeader.UseVisualStyleBackColor = true;
            this.CCModeHeader.CheckedChanged += new System.EventHandler(this.General_CheckedChanged);
            // 
            // CCModeAllContents
            // 
            this.CCModeAllContents.AutoSize = true;
            this.CCModeAllContents.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.CCModeAllContents.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CCModeAllContents.Location = new System.Drawing.Point(15, 14);
            this.CCModeAllContents.Name = "CCModeAllContents";
            this.CCModeAllContents.Size = new System.Drawing.Size(35, 17);
            this.CCModeAllContents.TabIndex = 31;
            this.CCModeAllContents.TabStop = true;
            this.CCModeAllContents.Text = "All";
            this.CCModeAllContents.UseVisualStyleBackColor = true;
            this.CCModeAllContents.CheckedChanged += new System.EventHandler(this.CCModeAllContents_CheckedChanged);
            // 
            // MatchContents
            // 
            this.MatchContents.AutoSize = true;
            this.MatchContents.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.MatchContents.Location = new System.Drawing.Point(9, -1);
            this.MatchContents.Name = "MatchContents";
            this.MatchContents.Size = new System.Drawing.Size(102, 17);
            this.MatchContents.TabIndex = 27;
            this.MatchContents.Text = "Match Contents:";
            this.MatchContents.UseVisualStyleBackColor = true;
            this.MatchContents.CheckedChanged += new System.EventHandler(this.General_CheckedChanged);
            // 
            // CompareNamesFrame
            // 
            this.CompareNamesFrame.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CompareNamesFrame.Controls.Add(this.RemoveNonalpha);
            this.CompareNamesFrame.Controls.Add(this.RemoveNumbers);
            this.CompareNamesFrame.Controls.Add(this.IgnoreExtensions);
            this.CompareNamesFrame.Controls.Add(this.NCModeFrame);
            this.CompareNamesFrame.Controls.Add(this.MatchNames);
            this.CompareNamesFrame.Location = new System.Drawing.Point(0, 0);
            this.CompareNamesFrame.Name = "CompareNamesFrame";
            this.CompareNamesFrame.Size = new System.Drawing.Size(275, 111);
            this.CompareNamesFrame.TabIndex = 31;
            this.CompareNamesFrame.TabStop = false;
            // 
            // RemoveNonalpha
            // 
            this.RemoveNonalpha.AutoSize = true;
            this.RemoveNonalpha.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.RemoveNonalpha.Location = new System.Drawing.Point(10, 58);
            this.RemoveNonalpha.Name = "RemoveNonalpha";
            this.RemoveNonalpha.Size = new System.Drawing.Size(204, 17);
            this.RemoveNonalpha.TabIndex = 31;
            this.RemoveNonalpha.Text = "Remove Nonalphanumeric Characters";
            this.RemoveNonalpha.UseVisualStyleBackColor = true;
            this.RemoveNonalpha.CheckedChanged += new System.EventHandler(this.General_CheckedChanged);
            // 
            // RemoveNumbers
            // 
            this.RemoveNumbers.AutoSize = true;
            this.RemoveNumbers.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.RemoveNumbers.Location = new System.Drawing.Point(10, 75);
            this.RemoveNumbers.Name = "RemoveNumbers";
            this.RemoveNumbers.Size = new System.Drawing.Size(158, 17);
            this.RemoveNumbers.TabIndex = 32;
            this.RemoveNumbers.Text = "Remove Number Characters";
            this.RemoveNumbers.UseVisualStyleBackColor = true;
            this.RemoveNumbers.CheckedChanged += new System.EventHandler(this.General_CheckedChanged);
            // 
            // IgnoreExtensions
            // 
            this.IgnoreExtensions.AutoSize = true;
            this.IgnoreExtensions.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.IgnoreExtensions.Location = new System.Drawing.Point(10, 91);
            this.IgnoreExtensions.Name = "IgnoreExtensions";
            this.IgnoreExtensions.Size = new System.Drawing.Size(127, 17);
            this.IgnoreExtensions.TabIndex = 34;
            this.IgnoreExtensions.Text = "Ignore File Extensions";
            this.IgnoreExtensions.UseVisualStyleBackColor = true;
            this.IgnoreExtensions.CheckedChanged += new System.EventHandler(this.General_CheckedChanged);
            // 
            // NCModeFrame
            // 
            this.NCModeFrame.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NCModeFrame.Controls.Add(this.NCModeSoundEx);
            this.NCModeFrame.Controls.Add(this.NCModeExact);
            this.NCModeFrame.Location = new System.Drawing.Point(9, 19);
            this.NCModeFrame.Name = "NCModeFrame";
            this.NCModeFrame.Size = new System.Drawing.Size(260, 36);
            this.NCModeFrame.TabIndex = 33;
            this.NCModeFrame.TabStop = false;
            this.NCModeFrame.Text = "Name Comparison Mode:";
            // 
            // NCModeSoundEx
            // 
            this.NCModeSoundEx.AutoSize = true;
            this.NCModeSoundEx.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.NCModeSoundEx.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.NCModeSoundEx.Location = new System.Drawing.Point(67, 16);
            this.NCModeSoundEx.Name = "NCModeSoundEx";
            this.NCModeSoundEx.Size = new System.Drawing.Size(77, 17);
            this.NCModeSoundEx.TabIndex = 32;
            this.NCModeSoundEx.TabStop = true;
            this.NCModeSoundEx.Text = "SOUNDEX";
            this.NCModeSoundEx.UseVisualStyleBackColor = true;
            this.NCModeSoundEx.CheckedChanged += new System.EventHandler(this.General_CheckedChanged);
            // 
            // NCModeExact
            // 
            this.NCModeExact.AutoSize = true;
            this.NCModeExact.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.NCModeExact.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.NCModeExact.Location = new System.Drawing.Point(15, 16);
            this.NCModeExact.Name = "NCModeExact";
            this.NCModeExact.Size = new System.Drawing.Size(51, 17);
            this.NCModeExact.TabIndex = 31;
            this.NCModeExact.TabStop = true;
            this.NCModeExact.Text = "Exact";
            this.NCModeExact.UseVisualStyleBackColor = true;
            this.NCModeExact.CheckedChanged += new System.EventHandler(this.General_CheckedChanged);
            // 
            // MatchNames
            // 
            this.MatchNames.AutoSize = true;
            this.MatchNames.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.MatchNames.Location = new System.Drawing.Point(9, -1);
            this.MatchNames.Name = "MatchNames";
            this.MatchNames.Size = new System.Drawing.Size(159, 17);
            this.MatchNames.TabIndex = 27;
            this.MatchNames.Text = "Match File/Directory Names:";
            this.MatchNames.UseVisualStyleBackColor = true;
            this.MatchNames.CheckedChanged += new System.EventHandler(this.General_CheckedChanged);
            // 
            // SearchResultsFrame
            // 
            this.SearchResultsFrame.Controls.Add(this.SearchResultsSplitter);
            this.SearchResultsFrame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SearchResultsFrame.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchResultsFrame.Location = new System.Drawing.Point(0, 0);
            this.SearchResultsFrame.Name = "SearchResultsFrame";
            this.SearchResultsFrame.Size = new System.Drawing.Size(567, 571);
            this.SearchResultsFrame.TabIndex = 5;
            this.SearchResultsFrame.TabStop = false;
            this.SearchResultsFrame.Text = "Search Results:";
            this.SearchResultsFrame.Paint += new System.Windows.Forms.PaintEventHandler(this.SearchResultsFrame_Paint);
            // 
            // SearchResultsSplitter
            // 
            this.SearchResultsSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SearchResultsSplitter.Location = new System.Drawing.Point(3, 17);
            this.SearchResultsSplitter.Name = "SearchResultsSplitter";
            this.SearchResultsSplitter.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SearchResultsSplitter.Panel1
            // 
            this.SearchResultsSplitter.Panel1.Controls.Add(this.SelectedResultCountLabel);
            this.SearchResultsSplitter.Panel1.Controls.Add(this.DetailToolbar);
            this.SearchResultsSplitter.Panel1.Controls.Add(this.SearchResultsTabs);
            // 
            // SearchResultsSplitter.Panel2
            // 
            this.SearchResultsSplitter.Panel2.Controls.Add(this.DetailsTabs);
            this.SearchResultsSplitter.Size = new System.Drawing.Size(561, 551);
            this.SearchResultsSplitter.SplitterDistance = 308;
            this.SearchResultsSplitter.TabIndex = 0;
            // 
            // SelectedResultCountLabel
            // 
            this.SelectedResultCountLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectedResultCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectedResultCountLabel.Location = new System.Drawing.Point(130, -5);
            this.SelectedResultCountLabel.Name = "SelectedResultCountLabel";
            this.SelectedResultCountLabel.Size = new System.Drawing.Size(427, 25);
            this.SelectedResultCountLabel.TabIndex = 3;
            this.SelectedResultCountLabel.Text = "Hold CTRL to select multiple results. Selected Results:";
            this.SelectedResultCountLabel.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.SelectedResultCountLabel.Click += new System.EventHandler(this.SelectedResultCountLabel_Click);
            // 
            // DetailToolbar
            // 
            this.DetailToolbar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DetailToolbar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.DetailToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DetailAutoSelectButton,
            this.DetailOpenResultButton,
            this.DetailMoveToButton,
            this.DetailOpenContainingDirectoryButton,
            this.DetailCompareContentsButton,
            this.DetailDeletePermenantlyResultButton,
            this.DetailRefreshButton});
            this.DetailToolbar.Location = new System.Drawing.Point(0, 283);
            this.DetailToolbar.Name = "DetailToolbar";
            this.DetailToolbar.Size = new System.Drawing.Size(561, 25);
            this.DetailToolbar.TabIndex = 2;
            // 
            // DetailAutoSelectButton
            // 
            this.DetailAutoSelectButton.Image = ((System.Drawing.Image)(resources.GetObject("DetailAutoSelectButton.Image")));
            this.DetailAutoSelectButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.DetailAutoSelectButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DetailAutoSelectButton.Name = "DetailAutoSelectButton";
            this.DetailAutoSelectButton.Size = new System.Drawing.Size(84, 22);
            this.DetailAutoSelectButton.Text = "&Auto Select";
            this.DetailAutoSelectButton.Click += new System.EventHandler(this.AutoSelectToolStripMenuItem_Click);
            // 
            // DetailOpenResultButton
            // 
            this.DetailOpenResultButton.Image = ((System.Drawing.Image)(resources.GetObject("DetailOpenResultButton.Image")));
            this.DetailOpenResultButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.DetailOpenResultButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DetailOpenResultButton.Name = "DetailOpenResultButton";
            this.DetailOpenResultButton.Size = new System.Drawing.Size(54, 22);
            this.DetailOpenResultButton.Text = "&Open";
            this.DetailOpenResultButton.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // DetailOpenContainingDirectoryButton
            // 
            this.DetailOpenContainingDirectoryButton.Image = ((System.Drawing.Image)(resources.GetObject("DetailOpenContainingDirectoryButton.Image")));
            this.DetailOpenContainingDirectoryButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.DetailOpenContainingDirectoryButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DetailOpenContainingDirectoryButton.Name = "DetailOpenContainingDirectoryButton";
            this.DetailOpenContainingDirectoryButton.Size = new System.Drawing.Size(104, 22);
            this.DetailOpenContainingDirectoryButton.Text = "Ope&n Location";
            this.DetailOpenContainingDirectoryButton.Click += new System.EventHandler(this.OpenContainingDirectoryToolStripMenuItem_Click);
            // 
            // DetailCompareContentsButton
            // 
            this.DetailCompareContentsButton.Image = ((System.Drawing.Image)(resources.GetObject("DetailCompareContentsButton.Image")));
            this.DetailCompareContentsButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.DetailCompareContentsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DetailCompareContentsButton.Name = "DetailCompareContentsButton";
            this.DetailCompareContentsButton.Size = new System.Drawing.Size(123, 22);
            this.DetailCompareContentsButton.Text = "Co&mpare Contents";
            this.DetailCompareContentsButton.Click += new System.EventHandler(this.CompareContentsToolStripMenuItem_Click);
            // 
            // DetailDeletePermenantlyResultButton
            // 
            this.DetailDeletePermenantlyResultButton.Image = ((System.Drawing.Image)(resources.GetObject("DetailDeletePermenantlyResultButton.Image")));
            this.DetailDeletePermenantlyResultButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.DetailDeletePermenantlyResultButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DetailDeletePermenantlyResultButton.Name = "DetailDeletePermenantlyResultButton";
            this.DetailDeletePermenantlyResultButton.Size = new System.Drawing.Size(132, 22);
            this.DetailDeletePermenantlyResultButton.Text = "D&elete Permenantly";
            this.DetailDeletePermenantlyResultButton.Click += new System.EventHandler(this.DeletePermenantlyToolStripMenuItem_Click);
            // 
            // DetailRefreshButton
            // 
            this.DetailRefreshButton.Image = ((System.Drawing.Image)(resources.GetObject("DetailRefreshButton.Image")));
            this.DetailRefreshButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.DetailRefreshButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DetailRefreshButton.Name = "DetailRefreshButton";
            this.DetailRefreshButton.Size = new System.Drawing.Size(64, 19);
            this.DetailRefreshButton.Text = "Re&fresh";
            this.DetailRefreshButton.Click += new System.EventHandler(this.RefreshToolStripMenuItem_Click);
            // 
            // SearchResultsTabs
            // 
            this.SearchResultsTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchResultsTabs.Controls.Add(this.SearchResultsBasicTab);
            this.SearchResultsTabs.Controls.Add(this.SearchResultsGroupedTab);
            this.SearchResultsTabs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchResultsTabs.HotTrack = true;
            this.SearchResultsTabs.ItemSize = new System.Drawing.Size(180, 18);
            this.SearchResultsTabs.Location = new System.Drawing.Point(3, 3);
            this.SearchResultsTabs.Name = "SearchResultsTabs";
            this.SearchResultsTabs.SelectedIndex = 0;
            this.SearchResultsTabs.Size = new System.Drawing.Size(554, 277);
            this.SearchResultsTabs.TabIndex = 1;
            this.SearchResultsTabs.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.SearchResultsTabs_Selecting);
            // 
            // SearchResultsBasicTab
            // 
            this.SearchResultsBasicTab.Controls.Add(this.BasicResultsList);
            this.SearchResultsBasicTab.Location = new System.Drawing.Point(4, 22);
            this.SearchResultsBasicTab.Name = "SearchResultsBasicTab";
            this.SearchResultsBasicTab.Padding = new System.Windows.Forms.Padding(3);
            this.SearchResultsBasicTab.Size = new System.Drawing.Size(546, 251);
            this.SearchResultsBasicTab.TabIndex = 0;
            this.SearchResultsBasicTab.Text = "Basic";
            this.SearchResultsBasicTab.UseVisualStyleBackColor = true;
            // 
            // SearchResultsGroupedTab
            // 
            this.SearchResultsGroupedTab.Controls.Add(this.SearchResultsGroupedTabSplitter);
            this.SearchResultsGroupedTab.Location = new System.Drawing.Point(4, 22);
            this.SearchResultsGroupedTab.Name = "SearchResultsGroupedTab";
            this.SearchResultsGroupedTab.Padding = new System.Windows.Forms.Padding(3);
            this.SearchResultsGroupedTab.Size = new System.Drawing.Size(546, 251);
            this.SearchResultsGroupedTab.TabIndex = 1;
            this.SearchResultsGroupedTab.Text = "Grouped";
            this.SearchResultsGroupedTab.UseVisualStyleBackColor = true;
            // 
            // SearchResultsGroupedTabSplitter
            // 
            this.SearchResultsGroupedTabSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SearchResultsGroupedTabSplitter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchResultsGroupedTabSplitter.Location = new System.Drawing.Point(3, 3);
            this.SearchResultsGroupedTabSplitter.Name = "SearchResultsGroupedTabSplitter";
            // 
            // SearchResultsGroupedTabSplitter.Panel1
            // 
            this.SearchResultsGroupedTabSplitter.Panel1.Controls.Add(this.GroupResultsList);
            this.SearchResultsGroupedTabSplitter.Panel1.Controls.Add(this.GroupResultsListLabel);
            // 
            // SearchResultsGroupedTabSplitter.Panel2
            // 
            this.SearchResultsGroupedTabSplitter.Panel2.Controls.Add(this.ResultGroupList);
            this.SearchResultsGroupedTabSplitter.Panel2.Controls.Add(this.ResultGroupListLabel);
            this.SearchResultsGroupedTabSplitter.Size = new System.Drawing.Size(540, 245);
            this.SearchResultsGroupedTabSplitter.SplitterDistance = 203;
            this.SearchResultsGroupedTabSplitter.TabIndex = 3;
            this.SearchResultsGroupedTabSplitter.TabStop = false;
            // 
            // GroupResultsList
            // 
            this.GroupResultsList.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.GroupResultsList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupResultsList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GroupResultsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.GroupResultsListGroupIDColumn,
            this.GroupResultsListTotalMatchesColumn,
            this.GroupResultsListTotalFilesColumn,
            this.GroupResultsListTotalDirectoriesColumn});
            this.GroupResultsList.FullRowSelect = true;
            this.GroupResultsList.GridLines = true;
            this.GroupResultsList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.GroupResultsList.HideSelection = false;
            this.GroupResultsList.Location = new System.Drawing.Point(0, 22);
            this.GroupResultsList.MultiSelect = false;
            this.GroupResultsList.Name = "GroupResultsList";
            this.GroupResultsList.ShowGroups = false;
            this.GroupResultsList.Size = new System.Drawing.Size(200, 223);
            this.GroupResultsList.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.GroupResultsList.TabIndex = 6;
            this.GroupResultsList.UseCompatibleStateImageBehavior = false;
            this.GroupResultsList.View = System.Windows.Forms.View.Details;
            this.GroupResultsList.SelectedIndexChanged += new System.EventHandler(this.GroupResultsList_SelectedIndexChanged);
            // 
            // GroupResultsListGroupIDColumn
            // 
            this.GroupResultsListGroupIDColumn.Text = "Group ID";
            this.GroupResultsListGroupIDColumn.Width = 76;
            // 
            // GroupResultsListTotalMatchesColumn
            // 
            this.GroupResultsListTotalMatchesColumn.Text = "Total Matches";
            this.GroupResultsListTotalMatchesColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.GroupResultsListTotalMatchesColumn.Width = 84;
            // 
            // GroupResultsListTotalFilesColumn
            // 
            this.GroupResultsListTotalFilesColumn.Text = "Total Files";
            this.GroupResultsListTotalFilesColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.GroupResultsListTotalFilesColumn.Width = 75;
            // 
            // GroupResultsListTotalDirectoriesColumn
            // 
            this.GroupResultsListTotalDirectoriesColumn.Text = "Total Directories";
            this.GroupResultsListTotalDirectoriesColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.GroupResultsListTotalDirectoriesColumn.Width = 100;
            // 
            // GroupResultsListLabel
            // 
            this.GroupResultsListLabel.AutoSize = true;
            this.GroupResultsListLabel.Location = new System.Drawing.Point(0, 3);
            this.GroupResultsListLabel.Name = "GroupResultsListLabel";
            this.GroupResultsListLabel.Size = new System.Drawing.Size(77, 13);
            this.GroupResultsListLabel.TabIndex = 5;
            this.GroupResultsListLabel.Text = "Match Groups:";
            // 
            // ResultGroupListLabel
            // 
            this.ResultGroupListLabel.AutoSize = true;
            this.ResultGroupListLabel.Location = new System.Drawing.Point(0, 3);
            this.ResultGroupListLabel.Name = "ResultGroupListLabel";
            this.ResultGroupListLabel.Size = new System.Drawing.Size(51, 13);
            this.ResultGroupListLabel.TabIndex = 6;
            this.ResultGroupListLabel.Text = "Matches:";
            // 
            // DetailsTabs
            // 
            this.DetailsTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DetailsTabs.Controls.Add(this.MatchDetailsTab);
            this.DetailsTabs.Controls.Add(this.CriteriaDescriptionDetailsTab);
            this.DetailsTabs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DetailsTabs.Location = new System.Drawing.Point(3, 3);
            this.DetailsTabs.Name = "DetailsTabs";
            this.DetailsTabs.SelectedIndex = 0;
            this.DetailsTabs.Size = new System.Drawing.Size(554, 233);
            this.DetailsTabs.TabIndex = 0;
            // 
            // MatchDetailsTab
            // 
            this.MatchDetailsTab.Controls.Add(this.DetailSplitter);
            this.MatchDetailsTab.Location = new System.Drawing.Point(4, 22);
            this.MatchDetailsTab.Name = "MatchDetailsTab";
            this.MatchDetailsTab.Padding = new System.Windows.Forms.Padding(3);
            this.MatchDetailsTab.Size = new System.Drawing.Size(546, 207);
            this.MatchDetailsTab.TabIndex = 0;
            this.MatchDetailsTab.Text = "Details";
            this.MatchDetailsTab.UseVisualStyleBackColor = true;
            // 
            // DetailSplitter
            // 
            this.DetailSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DetailSplitter.Location = new System.Drawing.Point(3, 3);
            this.DetailSplitter.Name = "DetailSplitter";
            // 
            // DetailSplitter.Panel1
            // 
            this.DetailSplitter.Panel1.Controls.Add(this.DetailMatchGroup);
            this.DetailSplitter.Panel1.Controls.Add(this.DetailViewPreview);
            this.DetailSplitter.Panel1.Controls.Add(this.DetailMatchCount);
            this.DetailSplitter.Panel1.Controls.Add(this.DetailNameAndType);
            this.DetailSplitter.Panel1.Controls.Add(this.DetailIcon);
            // 
            // DetailSplitter.Panel2
            // 
            this.DetailSplitter.Panel2.Controls.Add(this.DetailPreview);
            this.DetailSplitter.Panel2.Controls.Add(this.DetailFitToWindow);
            this.DetailSplitter.Panel2.Controls.Add(this.DetailPreviewLabel);
            this.DetailSplitter.Size = new System.Drawing.Size(540, 201);
            this.DetailSplitter.SplitterDistance = 283;
            this.DetailSplitter.TabIndex = 28;
            // 
            // DetailMatchGroup
            // 
            this.DetailMatchGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DetailMatchGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(187)))), ((int)(((byte)(187)))));
            this.DetailMatchGroup.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DetailMatchGroup.HideSelection = false;
            this.DetailMatchGroup.Location = new System.Drawing.Point(0, 71);
            this.DetailMatchGroup.Multiline = true;
            this.DetailMatchGroup.Name = "DetailMatchGroup";
            this.DetailMatchGroup.ReadOnly = true;
            this.DetailMatchGroup.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.DetailMatchGroup.Size = new System.Drawing.Size(282, 130);
            this.DetailMatchGroup.TabIndex = 29;
            this.DetailMatchGroup.WordWrap = false;
            // 
            // DetailViewPreview
            // 
            this.DetailViewPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DetailViewPreview.AutoSize = true;
            this.DetailViewPreview.Checked = true;
            this.DetailViewPreview.CheckState = System.Windows.Forms.CheckState.Checked;
            this.DetailViewPreview.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.DetailViewPreview.Location = new System.Drawing.Point(194, 51);
            this.DetailViewPreview.Margin = new System.Windows.Forms.Padding(0);
            this.DetailViewPreview.Name = "DetailViewPreview";
            this.DetailViewPreview.Size = new System.Drawing.Size(88, 17);
            this.DetailViewPreview.TabIndex = 41;
            this.DetailViewPreview.Text = "View Preview";
            this.DetailViewPreview.UseVisualStyleBackColor = true;
            this.DetailViewPreview.CheckedChanged += new System.EventHandler(this.DetailViewPreview_CheckedChanged);
            // 
            // DetailMatchCount
            // 
            this.DetailMatchCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DetailMatchCount.Location = new System.Drawing.Point(-2, 51);
            this.DetailMatchCount.Margin = new System.Windows.Forms.Padding(0);
            this.DetailMatchCount.Name = "DetailMatchCount";
            this.DetailMatchCount.Size = new System.Drawing.Size(196, 17);
            this.DetailMatchCount.TabIndex = 30;
            this.DetailMatchCount.Text = "Matches:";
            this.DetailMatchCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DetailNameAndType
            // 
            this.DetailNameAndType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DetailNameAndType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DetailNameAndType.Location = new System.Drawing.Point(48, 0);
            this.DetailNameAndType.Name = "DetailNameAndType";
            this.DetailNameAndType.Size = new System.Drawing.Size(234, 48);
            this.DetailNameAndType.TabIndex = 42;
            this.DetailNameAndType.Text = "Selected Match Info";
            this.DetailNameAndType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DetailIcon
            // 
            this.DetailIcon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DetailIcon.Image = ((System.Drawing.Image)(resources.GetObject("DetailIcon.Image")));
            this.DetailIcon.Location = new System.Drawing.Point(0, 0);
            this.DetailIcon.Name = "DetailIcon";
            this.DetailIcon.Size = new System.Drawing.Size(48, 48);
            this.DetailIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.DetailIcon.TabIndex = 27;
            this.DetailIcon.TabStop = false;
            this.DetailIcon.Click += new System.EventHandler(this.DetailIcon_Click);
            // 
            // DetailPreview
            // 
            this.DetailPreview.AllowWebBrowserDrop = false;
            this.DetailPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DetailPreview.IsWebBrowserContextMenuEnabled = false;
            this.DetailPreview.Location = new System.Drawing.Point(0, 20);
            this.DetailPreview.MinimumSize = new System.Drawing.Size(20, 20);
            this.DetailPreview.Name = "DetailPreview";
            this.DetailPreview.ScriptErrorsSuppressed = true;
            this.DetailPreview.Size = new System.Drawing.Size(253, 181);
            this.DetailPreview.TabIndex = 28;
            this.DetailPreview.WebBrowserShortcutsEnabled = false;
            // 
            // DetailFitToWindow
            // 
            this.DetailFitToWindow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DetailFitToWindow.AutoSize = true;
            this.DetailFitToWindow.Checked = true;
            this.DetailFitToWindow.CheckState = System.Windows.Forms.CheckState.Checked;
            this.DetailFitToWindow.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.DetailFitToWindow.Location = new System.Drawing.Point(160, 0);
            this.DetailFitToWindow.Name = "DetailFitToWindow";
            this.DetailFitToWindow.Size = new System.Drawing.Size(93, 17);
            this.DetailFitToWindow.TabIndex = 42;
            this.DetailFitToWindow.Text = "Fit To Window";
            this.DetailFitToWindow.UseVisualStyleBackColor = true;
            this.DetailFitToWindow.CheckedChanged += new System.EventHandler(this.DetailFitToWindow_CheckedChanged);
            // 
            // DetailPreviewLabel
            // 
            this.DetailPreviewLabel.AutoSize = true;
            this.DetailPreviewLabel.Location = new System.Drawing.Point(0, 0);
            this.DetailPreviewLabel.Name = "DetailPreviewLabel";
            this.DetailPreviewLabel.Size = new System.Drawing.Size(48, 13);
            this.DetailPreviewLabel.TabIndex = 29;
            this.DetailPreviewLabel.Text = "Preview:";
            this.DetailPreviewLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CriteriaDescriptionDetailsTab
            // 
            this.CriteriaDescriptionDetailsTab.Controls.Add(this.CriteriaDescription);
            this.CriteriaDescriptionDetailsTab.Location = new System.Drawing.Point(4, 22);
            this.CriteriaDescriptionDetailsTab.Name = "CriteriaDescriptionDetailsTab";
            this.CriteriaDescriptionDetailsTab.Padding = new System.Windows.Forms.Padding(3);
            this.CriteriaDescriptionDetailsTab.Size = new System.Drawing.Size(546, 207);
            this.CriteriaDescriptionDetailsTab.TabIndex = 1;
            this.CriteriaDescriptionDetailsTab.Text = "Criteria Description";
            this.CriteriaDescriptionDetailsTab.UseVisualStyleBackColor = true;
            // 
            // CriteriaDescription
            // 
            this.CriteriaDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CriteriaDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CriteriaDescription.HideSelection = false;
            this.CriteriaDescription.Location = new System.Drawing.Point(3, 3);
            this.CriteriaDescription.Multiline = true;
            this.CriteriaDescription.Name = "CriteriaDescription";
            this.CriteriaDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.CriteriaDescription.Size = new System.Drawing.Size(540, 201);
            this.CriteriaDescription.TabIndex = 0;
            this.CriteriaDescription.Text = "According to the specified search criteria, matches will occur when the following" +
    " conditions are met:";
            // 
            // SaveFileDialog
            // 
            this.SaveFileDialog.Filter = "Text Files|*.txt|All Files|*.*|Criteria Files|*.ini";
            this.SaveFileDialog.FilterIndex = 2;
            this.SaveFileDialog.ShowHelp = true;
            this.SaveFileDialog.SupportMultiDottedExtensions = true;
            // 
            // UpdateStatusTimer
            // 
            this.UpdateStatusTimer.Enabled = true;
            this.UpdateStatusTimer.Tick += new System.EventHandler(this.UpdateStatusTimer_Tick);
            // 
            // UpdateResultsTimer
            // 
            this.UpdateResultsTimer.Enabled = true;
            this.UpdateResultsTimer.Interval = 20;
            this.UpdateResultsTimer.Tick += new System.EventHandler(this.UpdateResultsTimer_Tick);
            // 
            // OpenFileDialog
            // 
            this.OpenFileDialog.FileName = "openFileDialog1";
            // 
            // UnisoftLogo
            // 
            this.UnisoftLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UnisoftLogo.BackColor = System.Drawing.Color.Transparent;
            this.UnisoftLogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.UnisoftLogo.Location = new System.Drawing.Point(806, 0);
            this.UnisoftLogo.Name = "UnisoftLogo";
            this.UnisoftLogo.Size = new System.Drawing.Size(67, 24);
            this.UnisoftLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.UnisoftLogo.TabIndex = 6;
            this.UnisoftLogo.TabStop = false;
            this.UnisoftLogo.Visible = false;
            this.UnisoftLogo.Click += new System.EventHandler(this.UnisoftLogo_Click);
            // 
            // CheckRegisterTimer
            // 
            this.CheckRegisterTimer.Enabled = true;
            this.CheckRegisterTimer.Interval = 2000;
            this.CheckRegisterTimer.Tick += new System.EventHandler(this.CheckRegisterTimer_Tick);
            // 
            // RegistrationLbl
            // 
            this.RegistrationLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RegistrationLbl.AutoSize = true;
            this.RegistrationLbl.Location = new System.Drawing.Point(717, 5);
            this.RegistrationLbl.Name = "RegistrationLbl";
            this.RegistrationLbl.Size = new System.Drawing.Size(77, 13);
            this.RegistrationLbl.TabIndex = 7;
            this.RegistrationLbl.Text = "Registered To:";
            this.RegistrationLbl.Visible = false;
            this.RegistrationLbl.Click += new System.EventHandler(this.RegistrationLbl_Click);
            // 
            // BasicResultsList
            // 
            this.BasicResultsList.AllowColumnReorder = true;
            this.BasicResultsList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BasicResultsList.ContextMenuStrip = this.ResultsContextMenu;
            this.BasicResultsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BasicResultsList.FullRowSelect = true;
            this.BasicResultsList.GridLines = true;
            this.BasicResultsList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.BasicResultsList.HideSelection = false;
            this.BasicResultsList.Location = new System.Drawing.Point(3, 3);
            this.BasicResultsList.Name = "BasicResultsList";
            this.BasicResultsList.Size = new System.Drawing.Size(540, 245);
            this.BasicResultsList.TabIndex = 0;
            this.BasicResultsList.UseCompatibleStateImageBehavior = false;
            this.BasicResultsList.View = System.Windows.Forms.View.Details;
            this.BasicResultsList.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.BasicResultsList_ItemSelectionChanged);
            this.BasicResultsList.DoubleClick += new System.EventHandler(this.BasicResultsList_DoubleClick);
            this.BasicResultsList.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BasicResultsList_KeyPress);
            // 
            // ResultGroupList
            // 
            this.ResultGroupList.AllowColumnReorder = true;
            this.ResultGroupList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ResultGroupList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ResultGroupList.ContextMenuStrip = this.ResultsContextMenu;
            this.ResultGroupList.FullRowSelect = true;
            this.ResultGroupList.GridLines = true;
            this.ResultGroupList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.ResultGroupList.HideSelection = false;
            this.ResultGroupList.Location = new System.Drawing.Point(3, 22);
            this.ResultGroupList.Name = "ResultGroupList";
            this.ResultGroupList.Size = new System.Drawing.Size(327, 223);
            this.ResultGroupList.TabIndex = 0;
            this.ResultGroupList.UseCompatibleStateImageBehavior = false;
            this.ResultGroupList.View = System.Windows.Forms.View.Details;
            this.ResultGroupList.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.BasicResultsList_ItemSelectionChanged);
            this.ResultGroupList.DoubleClick += new System.EventHandler(this.BasicResultsList_DoubleClick);
            this.ResultGroupList.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BasicResultsList_KeyPress);
            // 
            // DSGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 619);
            this.Controls.Add(this.RegistrationLbl);
            this.Controls.Add(this.UnisoftLogo);
            this.Controls.Add(this.MainSplit);
            this.Controls.Add(this.MainStatus);
            this.Controls.Add(this.MainMenu);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MainMenu;
            this.MinimumSize = new System.Drawing.Size(881, 646);
            this.Name = "DSGUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "DuplicateSearcher";
            this.Activated += new System.EventHandler(this.DSGUI_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DSGUI_FormClosing);
            this.Load += new System.EventHandler(this.DSGUI_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.DSGUI_Paint);
            this.Resize += new System.EventHandler(this.DSGUI_Resize);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.BuiltInCriteriaMenuStrip.ResumeLayout(false);
            this.ResultsContextMenu.ResumeLayout(false);
            this.MoveToContextMenu.ResumeLayout(false);
            this.MainStatus.ResumeLayout(false);
            this.MainStatus.PerformLayout();
            this.MainSplit.Panel1.ResumeLayout(false);
            this.MainSplit.Panel2.ResumeLayout(false);
            this.MainSplit.ResumeLayout(false);
            this.SearchCriteriaFrame.ResumeLayout(false);
            this.SearchCriteriaTabs.ResumeLayout(false);
            this.SearchCriteriaBasicTab.ResumeLayout(false);
            this.SearchCriteriaBasicSplitter.Panel1.ResumeLayout(false);
            this.SearchCriteriaBasicSplitter.Panel2.ResumeLayout(false);
            this.SearchCriteriaBasicSplitter.ResumeLayout(false);
            this.SearchLocationsFrame.ResumeLayout(false);
            this.SearchLocationsFrame.PerformLayout();
            this.SearchOptionsFrame.ResumeLayout(false);
            this.SearchOptionsFrame.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MinFileSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxFileSize)).EndInit();
            this.IncludeExcludeTabs.ResumeLayout(false);
            this.FileFiltersTab.ResumeLayout(false);
            this.FileFiltersTablePanel.ResumeLayout(false);
            this.FileExcludeFiltersFrame.ResumeLayout(false);
            this.FileExcludeFiltersFrame.PerformLayout();
            this.FileIncludeFiltersFrame.ResumeLayout(false);
            this.FileIncludeFiltersFrame.PerformLayout();
            this.DirectoryFiltersTab.ResumeLayout(false);
            this.DirectoryFiltersTablePanel.ResumeLayout(false);
            this.DirectoryIncludeFiltersFrame.ResumeLayout(false);
            this.DirectoryIncludeFiltersFrame.PerformLayout();
            this.DirectoryExcludeFiltersFrame.ResumeLayout(false);
            this.DirectoryExcludeFiltersFrame.PerformLayout();
            this.SearchCriteriaAdvancedTab.ResumeLayout(false);
            this.MiscFrame.ResumeLayout(false);
            this.MiscFrame.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxSearchThreads)).EndInit();
            this.OutputFileFrame.ResumeLayout(false);
            this.OutputFileFrame.PerformLayout();
            this.LogFileFrame.ResumeLayout(false);
            this.LogFileFrame.PerformLayout();
            this.CompareContentsFrame.ResumeLayout(false);
            this.CompareContentsFrame.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HeaderFooterSize)).EndInit();
            this.CCModeFrame.ResumeLayout(false);
            this.CCModeFrame.PerformLayout();
            this.CompareNamesFrame.ResumeLayout(false);
            this.CompareNamesFrame.PerformLayout();
            this.NCModeFrame.ResumeLayout(false);
            this.NCModeFrame.PerformLayout();
            this.SearchResultsFrame.ResumeLayout(false);
            this.SearchResultsSplitter.Panel1.ResumeLayout(false);
            this.SearchResultsSplitter.Panel1.PerformLayout();
            this.SearchResultsSplitter.Panel2.ResumeLayout(false);
            this.SearchResultsSplitter.ResumeLayout(false);
            this.DetailToolbar.ResumeLayout(false);
            this.DetailToolbar.PerformLayout();
            this.SearchResultsTabs.ResumeLayout(false);
            this.SearchResultsBasicTab.ResumeLayout(false);
            this.SearchResultsGroupedTab.ResumeLayout(false);
            this.SearchResultsGroupedTabSplitter.Panel1.ResumeLayout(false);
            this.SearchResultsGroupedTabSplitter.Panel1.PerformLayout();
            this.SearchResultsGroupedTabSplitter.Panel2.ResumeLayout(false);
            this.SearchResultsGroupedTabSplitter.Panel2.PerformLayout();
            this.SearchResultsGroupedTabSplitter.ResumeLayout(false);
            this.DetailsTabs.ResumeLayout(false);
            this.MatchDetailsTab.ResumeLayout(false);
            this.DetailSplitter.Panel1.ResumeLayout(false);
            this.DetailSplitter.Panel1.PerformLayout();
            this.DetailSplitter.Panel2.ResumeLayout(false);
            this.DetailSplitter.Panel2.PerformLayout();
            this.DetailSplitter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DetailIcon)).EndInit();
            this.CriteriaDescriptionDetailsTab.ResumeLayout(false);
            this.CriteriaDescriptionDetailsTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UnisoftLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.StatusStrip MainStatus;
        private System.Windows.Forms.ToolStripStatusLabel OverallStatus;
        private System.Windows.Forms.FolderBrowserDialog DirectoryBrowserDialog;
        private System.Windows.Forms.ToolStripMenuItem HelpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem;
        private System.Windows.Forms.SplitContainer MainSplit;
        private System.Windows.Forms.GroupBox SearchCriteriaFrame;
        private System.Windows.Forms.TabControl SearchCriteriaTabs;
        private System.Windows.Forms.TabPage SearchCriteriaBasicTab;
        private System.Windows.Forms.TabPage SearchCriteriaAdvancedTab;
        private System.Windows.Forms.GroupBox SearchResultsFrame;
        private System.Windows.Forms.SplitContainer SearchCriteriaBasicSplitter;
        private System.Windows.Forms.GroupBox SearchLocationsFrame;
        private System.Windows.Forms.ListView SearchLocationsList;
        private System.Windows.Forms.ColumnHeader SearchLocationsListNameColumn;
        private System.Windows.Forms.Button RemoveSearchLocationButton;
        private System.Windows.Forms.Button AddSearchLocationButton;
        private System.Windows.Forms.SaveFileDialog SaveFileDialog;
        private System.Windows.Forms.GroupBox CompareNamesFrame;
        private System.Windows.Forms.CheckBox MatchNames;
        private System.Windows.Forms.CheckBox RemoveNumbers;
        private System.Windows.Forms.CheckBox RemoveNonalpha;
        private System.Windows.Forms.GroupBox NCModeFrame;
        private System.Windows.Forms.RadioButton NCModeSoundEx;
        private System.Windows.Forms.RadioButton NCModeExact;
        private System.Windows.Forms.GroupBox CompareContentsFrame;
        private System.Windows.Forms.GroupBox CCModeFrame;
        private System.Windows.Forms.RadioButton CCModeHeader;
        private System.Windows.Forms.RadioButton CCModeAllContents;
        private System.Windows.Forms.CheckBox MatchContents;
        private System.Windows.Forms.RadioButton CCModeHeaderAndFooter;
        private System.Windows.Forms.Label HeaderFooterSizeLabel;
        private System.Windows.Forms.Label HeaderFooterSizeBytesLabel;
        private System.Windows.Forms.NumericUpDown HeaderFooterSize;
        private System.Windows.Forms.ToolStripProgressBar ProgressBar;
        private System.Windows.Forms.GroupBox OutputFileFrame;
        private System.Windows.Forms.CheckBox AppendOutputFile;
        private System.Windows.Forms.CheckBox OnlyOutputFile;
        private System.Windows.Forms.CheckBox UseOutputFile;
        private System.Windows.Forms.Button OutputFileBrowseButton;
        private System.Windows.Forms.Label OutputFileLabel;
        private System.Windows.Forms.GroupBox LogFileFrame;
        private System.Windows.Forms.CheckBox AppendLogFile;
        private System.Windows.Forms.CheckBox UseLogFile;
        private System.Windows.Forms.Button LogFileBrowseButton;
        private System.Windows.Forms.TextBox LogFile;
        private System.Windows.Forms.Label LogFileLabel;
        private System.Windows.Forms.TabControl IncludeExcludeTabs;
        private System.Windows.Forms.TabPage FileFiltersTab;
        private System.Windows.Forms.TableLayoutPanel FileFiltersTablePanel;
        private System.Windows.Forms.GroupBox FileExcludeFiltersFrame;
        private System.Windows.Forms.Button RemoveFileExcludeFilterButton;
        private System.Windows.Forms.Button AddFileExcludeFilterButton;
        private System.Windows.Forms.ListView FileExcludeFilterList;
        private System.Windows.Forms.GroupBox FileIncludeFiltersFrame;
        private System.Windows.Forms.Button RemoveFileIncludeFilterButton;
        private System.Windows.Forms.Button AddFileIncludeFilterButton;
        private System.Windows.Forms.ListView FileIncludeFilterList;
        private System.Windows.Forms.TabPage DirectoryFiltersTab;
        private System.Windows.Forms.TableLayoutPanel DirectoryFiltersTablePanel;
        private System.Windows.Forms.GroupBox DirectoryExcludeFiltersFrame;
        private System.Windows.Forms.Button RemoveDirectoryExcludeFilterButton;
        private System.Windows.Forms.Button AddDirectoryExcludeFilterButton;
        private System.Windows.Forms.ListView DirectoryExcludeFilterList;
        private System.Windows.Forms.GroupBox DirectoryIncludeFiltersFrame;
        private System.Windows.Forms.Button RemoveDirectoryIncludeFilterButton;
        private System.Windows.Forms.Button AddDirectoryIncludeFilterButton;
        private System.Windows.Forms.ListView DirectoryIncludeFilterList;
        private System.Windows.Forms.GroupBox SearchOptionsFrame;
        private System.Windows.Forms.CheckBox MatchFiles;
        private System.Windows.Forms.CheckBox MatchDirectories;
        private System.Windows.Forms.CheckBox SearchSubdirectories;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Button PauseButton;
        private System.Windows.Forms.TextBox NewFileIncludeFilter;
        private System.Windows.Forms.TextBox NewFileExcludeFilter;
        private System.Windows.Forms.TextBox NewDirIncludeFilter;
        private System.Windows.Forms.TextBox NewDirExcludeFilter;
        private System.Windows.Forms.ColumnHeader FileIncludeFilterColumn;
        private System.Windows.Forms.ColumnHeader FileExcludeFilterColumn;
        private System.Windows.Forms.ColumnHeader DirIncludeFilterColumn;
        private System.Windows.Forms.ColumnHeader DirExcludeFilterColumn;
        private System.Windows.Forms.Timer UpdateStatusTimer;
        private System.Windows.Forms.Button ResumeButton;
        private System.Windows.Forms.Timer UpdateResultsTimer;
        private System.Windows.Forms.SplitContainer SearchResultsSplitter;
        private System.Windows.Forms.TabControl SearchResultsTabs;
        private System.Windows.Forms.TabPage SearchResultsBasicTab;
        private System.Windows.Forms.TabPage SearchResultsGroupedTab;
        private System.Windows.Forms.SplitContainer SearchResultsGroupedTabSplitter;
        private System.Windows.Forms.TabControl DetailsTabs;
        private System.Windows.Forms.TabPage MatchDetailsTab;
        private System.Windows.Forms.TabPage CriteriaDescriptionDetailsTab;
        private System.Windows.Forms.TextBox CriteriaDescription;
        private System.Windows.Forms.CheckBox MatchSizes;
        private System.Windows.Forms.CheckBox MatchFilesToDirectories;
        private System.Windows.Forms.ToolStripStatusLabel TotalMatchGroupsStatus;
        private System.Windows.Forms.ToolStripStatusLabel TotalMatchesStatus;
        private System.Windows.Forms.ToolStripStatusLabel TotalFilesComparedStatus;
        private System.Windows.Forms.ToolStripStatusLabel TotalDirectoriesComparedStatus;
        private System.Windows.Forms.GroupBox MiscFrame;
        private System.Windows.Forms.CheckBox PreloadContent;
        private System.Windows.Forms.CheckBox MatchOnNameORContent;
        private System.Windows.Forms.CheckBox MergeFilters;
        private System.Windows.Forms.CheckBox UseDefaultFilters;
        private System.Windows.Forms.Label SearchModeLabel;
        private System.Windows.Forms.ComboBox SearchMode;
        private System.Windows.Forms.CheckBox CompareDirectoryContents;
        private System.Windows.Forms.Label GroupResultsListLabel;
        private System.Windows.Forms.Label ResultGroupListLabel;
        private System.Windows.Forms.ToolStripMenuItem ActionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DocumentationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DuplicateSearcherWebsiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveCriteriaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LoadCriteriaToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator ToolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem StartSearchingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem StopSearchingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PauseSearchingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ResumeSearchingToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip ResultsContextMenu;
        private System.Windows.Forms.ToolStripSeparator ToolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem DeletePermenantlyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MoveToToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ResultsToolStripMenuItem;
        private System.Windows.Forms.ListView GroupResultsList;
        private System.Windows.Forms.ColumnHeader GroupResultsListGroupIDColumn;
        private System.Windows.Forms.ColumnHeader GroupResultsListTotalMatchesColumn;
        private System.Windows.Forms.ColumnHeader GroupResultsListTotalFilesColumn;
        private System.Windows.Forms.ColumnHeader GroupResultsListTotalDirectoriesColumn;
        private System.Windows.Forms.TextBox OutputFile;
        private System.Windows.Forms.SplitContainer DetailSplitter;
        private System.Windows.Forms.TextBox DetailMatchGroup;
        private System.Windows.Forms.PictureBox DetailIcon;
        private System.Windows.Forms.WebBrowser DetailPreview;
        private System.Windows.Forms.Label DetailMatchCount;
        private System.Windows.Forms.CheckBox DetailViewPreview;
        private System.Windows.Forms.Label DetailNameAndType;
        private System.Windows.Forms.Label DetailPreviewLabel;
        private System.Windows.Forms.CheckBox DetailFitToWindow;
        private System.Windows.Forms.ToolStrip DetailToolbar;
        private System.Windows.Forms.ToolStripButton DetailOpenResultButton;
        private System.Windows.Forms.ToolStripButton DetailDeletePermenantlyResultButton;
        private System.Windows.Forms.ToolStripButton DetailCompareContentsButton;
        private System.Windows.Forms.ToolStripMenuItem CompareContentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton DetailAutoSelectButton;
        private System.Windows.Forms.ToolStripMenuItem AutoSelectToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton DetailMoveToButton;
        private System.Windows.Forms.ContextMenuStrip MoveToContextMenu;
        private System.Windows.Forms.ToolStripMenuItem MoveToRecycleBinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MoveToBrowseToolStripMenuItem;
        private System.Windows.Forms.Label SelectedResultCountLabel;
        private System.Windows.Forms.ToolStripMenuItem OpenContainingDirectoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton DetailOpenContainingDirectoryButton;
        private System.Windows.Forms.ToolStripMenuItem AddSearchLocationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RemoveSearchLocationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator ToolStripSeparator3;
        private System.Windows.Forms.CheckBox IgnoreExtensions;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog;
        private DSResultsList BasicResultsList;
        private DSResultsList ResultGroupList;
        private System.Windows.Forms.ToolStripMenuItem RefreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton DetailRefreshButton;
        private System.Windows.Forms.LinkLabel SearchForButton;
        private System.Windows.Forms.TextBox SearchLocationTxt;
        private System.Windows.Forms.ComboBox MaxFileSizeUnits;
        private System.Windows.Forms.Label MaxFileSizeLbl;
        private System.Windows.Forms.NumericUpDown MaxFileSize;
        private System.Windows.Forms.ComboBox MinFileSizeUnits;
        private System.Windows.Forms.Label MinFileSizeLbl;
        private System.Windows.Forms.NumericUpDown MinFileSize;
        private System.Windows.Forms.ToolStripSeparator ToolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem LoadBuiltinCriteriaToolStripMenuItem;
        private System.Windows.Forms.NumericUpDown MaxSearchThreads;
        private System.Windows.Forms.Label MaxSearchThreadsLabel;
        private System.Windows.Forms.ContextMenuStrip BuiltInCriteriaMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem EverythingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AllMediaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem VideoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MusicToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DocumentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PicturesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DevelopersFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EndUserLicenseAgreementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RegisterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ViewDebugToolStripMenuItem;
        private System.Windows.Forms.PictureBox UnisoftLogo;
        private System.Windows.Forms.ToolStripMenuItem UnisoftWebsiteToolStripMenuItem;
        private System.Windows.Forms.Timer CheckRegisterTimer;
        private System.Windows.Forms.ToolStripMenuItem updatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CheckForUpdatesNowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AutomaticallyCheckForUpdatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator ToolStripSeparator5;
        private System.Windows.Forms.Label RegistrationLbl;
    }
}