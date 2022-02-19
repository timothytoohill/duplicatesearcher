using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Reflection;

namespace DuplicateSearcher {
    /* form class shit */
    public partial class DSGUI : Form {
        //consts 
        private Color color1 = Color.AntiqueWhite;
        private Color color2 = Color.Thistle;
        private Color nonexistentColor = Color.FromArgb(255, 100, 100);
        private string removedIndication = "REMOVED: ";

        //private members
        private DSModel model = null;
        private DSConsole console = null;
        private DSSearchComplete searchCompleteDialog = null;
        private DSAutoSelect autoSelectDialog = null;
        private DSDocumentation documentationDialog = null;
        private Queue<DSMatch> newMatches = new Queue<DSMatch>();
        private bool isClosing = false;
        private bool isStarted = false;
        private bool isPaused = false;
        private bool alreadyInUpdateResults = false;
        private bool alreadyInUpdateStatus = false; //seems like those timers are on seperate threads, so ensuring they can not execute the updatestatus/updateresults functions more than once
        private bool finishedCompletely = false;
        private ListView selectedResultsList = null;
        private Image defaultDetailIcon = null;
        private string lastCriteriaFile = "";
        private DSPreviewHTMLGenerator previewHTMLGenerator = new DSPreviewHTMLGenerator();
        private string previousPreviewHTML = "";
        private string previousPreviewURL = "";
        private bool isAutoSelecting = false;
        private bool isUpdating = false;
        private int resultListDeselectCount = 0; //determines if we have deslected too many times


        //public properties 
        /* allows access to the selected listview (basic or grouped */
        public ListView SelectedResultsList { get { return selectedResultsList; } }

        /* causes the gui to not perform selection logic */
        public bool IsAutoSelecting { get { return isAutoSelecting; } set { isAutoSelecting = value; } }


        //public methods--------------------------------------------------
        /* constructor */
        public DSGUI(DSModel model, DSConsole console) {
            try {
                /* set model and console */
                this.model = model;
                this.console = console;

                /* auto made from designer */
                InitializeComponent();
            } catch (Exception ex) {
                ShowError(ex);
            }
        }


        //private event handlers--------------------------------------------------
        /* upon load */
        private void DSGUI_Load(object sender, EventArgs e) {
            try {
                /* further init */
                InitializeControls();

                /* set defaults */
                int defaultWidth = Screen.PrimaryScreen.WorkingArea.Width * 4 / 8;
                int defaultHeight = Screen.PrimaryScreen.WorkingArea.Height * 4 / 8;
                if (defaultHeight < MinimumSize.Height) defaultHeight = MinimumSize.Height;
                if (defaultWidth < MinimumSize.Width) defaultWidth = MinimumSize.Width;
                
                /* set the size and pose */
                DSSettings.GetControlSizeAndPos(this, defaultWidth, defaultHeight);
                WindowState = DSSettings.GetWindowState(this);
                
                /* load last settings that the user had before */
                LoadLastSettings();

                /* set gui controls */
                LoadGUIFromModelAndConsole();

                /* update details */
                UpdateDetails();
            } catch (Exception ex) {
                ShowError(ex);
            }
        }

        /* upon activate */
        private void DSGUI_Activated(object sender, EventArgs e) {
            try {
                DSMain.StopSplash();
            } catch (Exception ex) {
                DSUtilities.Msg(ex);
            }
        }

        /* upon closing of the window */
        private void DSGUI_FormClosing(object sender, FormClosingEventArgs e) {
            try {
                /* flag */
                isClosing = true;

                /* stop all */
                Stop();

                /* save for next startup */
                SaveLastSettings();

                /* save window shizzle */
                DSSettings.SaveWindowState(this);
                WindowState = FormWindowState.Normal;
                DSSettings.SaveControlSizeAndPos(this);
            } catch (Exception ex) {
                ShowError(ex);
                isClosing = false;
            }
        }

        /* in case resize need to be handled */
        private void DSGUI_Resize(object sender, EventArgs e) {

        }

        /* paint for the crap */
        private void DSGUI_Paint(object sender, PaintEventArgs e) {

        }

        /* paint the search results */
        private void SearchResultsFrame_Paint(object sender, PaintEventArgs e) {
        }

        /* handle clicking the label */
        private void SelectedResultCountLabel_Click(object sender, EventArgs e) {
            try {
                if (!DSLicensing.IsRegistered)
                    DSLicensing.ShowRegistrationWindow();
            } catch (Exception ex) {
                DSUtilities.Msg(ex);
            }
        }

        /* open */
        private void DetailIcon_Click(object sender, EventArgs e) {
            try {
                OpenSelectedResults();
            } catch (Exception ex) {
                ShowError(ex);
            }
        }

        /* special case */
        private void CCModeAllContents_CheckedChanged(object sender, EventArgs e) {
            try {
                if (CCModeAllContents.Checked && (!isUpdating)) {
                    DSUtilities.Msg("WARNING: For large files, comparing the entire contents during the search process can take a long time.");
                    UpdateControls();
                }
            } catch (Exception ex) {
                DSUtilities.Msg(ex);
            }
        }

        /* refresh as necessary */
        private void MainSplit_Panel1_SizeChanged(object sender, EventArgs e) {
            SearchMode.Refresh();
        }

        /* update the controls when selected */
        private void SearchLocationsList_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e) {
            try {
                SearchLocationTxt.Text = e.Item.Text;
                UpdateControls();
            } catch (Exception ex) {
                ShowError(ex);
            }
        }

        /* handle key inputs */
        private void SearchLocationsList_KeyDown(object sender, KeyEventArgs e) {
            try {
                if (e.KeyCode == Keys.Delete) {
                    RemoveSelectedSearchLocations();
                    e.Handled = true;
                }
            } catch (Exception ex) {
                ShowError(ex);
            }
        }

        /* adds a new file include filter */
        private void AddFileIncludeFilterButton_Click(object sender, EventArgs e) {
            try {
                if (NewFileIncludeFilter.Text.Length > 0) {
                    ListViewItem i = new ListViewItem(NewFileIncludeFilter.Text);
                    i.Checked = true;
                    FileIncludeFilterList.Items.Add(i);
                    NewFileIncludeFilter.Text = "";
                } else {
                    NewFileIncludeFilter.Focus();
                }
            } catch (Exception ex) {
                ShowError(ex);
            }
        }

        /* removes a file include filter */
        private void RemoveFileIncludeFilterButton_Click(object sender, EventArgs e) {
            try {
                while (FileIncludeFilterList.SelectedItems.Count > 0)
                    FileIncludeFilterList.Items.Remove(FileIncludeFilterList.SelectedItems[0]);
                UpdateControls();
            } catch (Exception ex) {
                ShowError(ex);
            }
        }

        /* adds a new file exclude filter */
        private void AddFileExcludeFilterButton_Click(object sender, EventArgs e) {
            try {
                if (NewFileExcludeFilter.Text.Length > 0) {
                    ListViewItem i = new ListViewItem(NewFileExcludeFilter.Text);
                    i.Checked = true;
                    FileExcludeFilterList.Items.Add(i);
                    NewFileExcludeFilter.Text = "";
                } else {
                    NewFileExcludeFilter.Focus();
                }
            } catch (Exception ex) {
                ShowError(ex);
            }
        }

        /* removes the file exclude filters */
        private void RemoveFileExcludeFilterButton_Click(object sender, EventArgs e) {
            try {
                while (FileExcludeFilterList.SelectedItems.Count > 0)
                    FileExcludeFilterList.Items.Remove(FileExcludeFilterList.SelectedItems[0]);
                UpdateControls();
            } catch (Exception ex) {
                ShowError(ex);
            }
        }

        /* adds a new dir filter */
        private void AddDirectoryIncludeFilterButton_Click(object sender, EventArgs e) {
            try {
                if (NewDirIncludeFilter.Text.Length > 0) {
                    ListViewItem i = new ListViewItem(NewDirIncludeFilter.Text);
                    i.Checked = true;
                    DirectoryIncludeFilterList.Items.Add(i);
                    NewDirIncludeFilter.Text = "";
                } else {
                    NewDirIncludeFilter.Focus();
                }
            } catch (Exception ex) {
                ShowError(ex);
            }
        }

        /* removes the selected dir s*/
        private void RemoveDirectoryIncludeFilterButton_Click(object sender, EventArgs e) {
            try {
                while (DirectoryIncludeFilterList.SelectedItems.Count > 0)
                    DirectoryIncludeFilterList.Items.Remove(DirectoryIncludeFilterList.SelectedItems[0]);
                UpdateControls();
            } catch (Exception ex) {
                ShowError(ex);
            }
        }

        /* adds a directory exclude filter */
        private void AddDirectoryExcludeFilterButton_Click(object sender, EventArgs e) {
            try {
                if (NewDirExcludeFilter.Text.Length > 0) {
                    ListViewItem i = new ListViewItem(NewDirExcludeFilter.Text);
                    i.Checked = true;
                    DirectoryExcludeFilterList.Items.Add(i);
                    NewDirExcludeFilter.Text = "";
                } else {
                    NewDirExcludeFilter.Focus();
                }
            } catch (Exception ex) {
                ShowError(ex);
            }
        }

        /* removes selcted dirs */
        private void RemoveDirectoryExcludeFilterButton_Click(object sender, EventArgs e) {
            try {
                while (DirectoryExcludeFilterList.SelectedItems.Count > 0)
                    DirectoryExcludeFilterList.Items.Remove(DirectoryExcludeFilterList.SelectedItems[0]);
                UpdateControls();
            } catch (Exception ex) {
                ShowError(ex);
            }
        }

        /* handle keydown */
        private void FileIncludeFilterList_KeyDown(object sender, KeyEventArgs e) {
            try {
                if (e.KeyCode == Keys.Delete) {
                    RemoveFileIncludeFilterButton.PerformClick();
                    e.Handled = true;
                }
            } catch (Exception ex) {
                ShowError(ex);
            }
        }

        /* handle key inputs */
        private void FileExcludeFilterList_KeyDown(object sender, KeyEventArgs e) {
            try {
                if (e.KeyCode == Keys.Delete) {
                    RemoveFileExcludeFilterButton.PerformClick();
                    e.Handled = true;
                }
            } catch (Exception ex) {
                ShowError(ex);
            }
        }

        /* handle key inputs */
        private void DirectoryIncludeFilterList_KeyDown(object sender, KeyEventArgs e) {
            try {
                if (e.KeyCode == Keys.Delete) {
                    RemoveDirectoryIncludeFilterButton.PerformClick();
                    e.Handled = true;
                }
            } catch (Exception ex) {
                ShowError(ex);
            }
        }

        /* handle key inputs */
        private void DirectoryExcludeFilterList_KeyDown(object sender, KeyEventArgs e) {
            try {
                if (e.KeyCode == Keys.Delete) {
                    RemoveDirectoryExcludeFilterButton.PerformClick();
                    e.Handled = true;
                }
            } catch (Exception ex) {
                ShowError(ex);
            }
        }

        /* update the text box which updates the controls */
        private void FileIncludeFilterList_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e) {
            try {
                NewFileIncludeFilter.Text = e.Item.Text;
                UpdateControls();
            } catch (Exception ex) {
                ShowError(ex);
            }
        }

        /* update the text box which updates the controls */
        private void FileExcludeFilterList_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e) {
            try {
                NewFileExcludeFilter.Text = e.Item.Text;
                UpdateControls();
            } catch (Exception ex) {
                ShowError(ex);
            }
        }

        /* update the text box which updates the controls */
        private void DirectoryIncludeFilterList_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e) {
            try {
                NewDirIncludeFilter.Text = e.Item.Text;
                UpdateControls();
            } catch (Exception ex) {
                ShowError(ex);
            }
        }

        /* update */
        private void DirectoryExcludeFilterList_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e) {
            try {
                NewDirExcludeFilter.Text = e.Item.Text;
                UpdateControls();
            } catch (Exception ex) {
                ShowError(ex);
            }
        }

        /* launch website */
        private void UnisoftLogo_Click(object sender, EventArgs e) {
            try {
                LaunchUnisoftWebsite();
            } catch (Exception ex) {
                ShowError(ex);
            }
        }

        /* launch DS website or reg window */
        private void RegistrationLbl_Click(object sender, EventArgs e) {
            try {
                if (DSLicensing.IsRegistered)
                    LaunchDSWebsite();
                else
                    DSLicensing.ShowRegistrationWindow();
            } catch (Exception ex) {
                ShowError(ex);
            }
        }

        /* add search location */
        private void AddSearchLocationToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                AddSearchLocation();
            } catch (Exception ex) {
                ShowError(ex);
            }

        }

        /* remove serach location */
        private void RemoveSearchLocationsToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                RemoveSelectedSearchLocations();
            } catch (Exception ex) {
                ShowError(ex);
            }
        }

        /* save the criteria */
        private void SaveCriteriaToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                SaveCriteria();
            } catch (Exception ex) {
                ShowError(ex);
            }
        }

        /* load criteria */
        private void LoadCriteriaToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                LoadCriteria();
            } catch (Exception ex) {
                ShowError(ex);
            }
        }

        /* called when exit selected from menu */
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                Close();
            } catch (Exception ex) {
                ShowError(ex);
            }
        }

        /* handle EULA */
        private void EndUserLicenseAgreementToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                if (!DSLicensing.ForceCheckEULA())
                    Close();
            } catch (Exception ex) {
                ShowError(ex);
            }
        }

        /* handle registration */
        private void RegisterToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                DSLicensing.ShowRegistrationWindow();
            } catch (Exception ex) {
                ShowError(ex);
            }
        }

        /* check for update */
        private void CheckForUpdatesNowToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                DSUpdate.StartUpdate(true);
            } catch (Exception ex) {
                DSUtilities.Msg(ex);
            }
        }

        /* change auto updates */
        private void AutomaticallyCheckForUpdatesToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                DSUpdate.AutomaticallyUpdate = !DSUpdate.AutomaticallyUpdate;
                UpdateControls();
            } catch (Exception ex) {
                DSUtilities.Msg(ex);
            }
        }

        /* launches */
        private void DuplicateSearcherWebsiteToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                LaunchDSWebsite();
            } catch (Exception ex) {
                ShowError(ex);
            }
        }

        /* launch unisoft website */
        private void UnisoftWebsiteToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                LaunchUnisoftWebsite();
            } catch (Exception ex) {
                DSUtilities.Msg(ex);
            }
        }

        /* start the search */
        private void StartSearchingToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                Start();
            } catch (Exception ex) {
                ShowError(ex);

                /* attempt to reset everything to normal */
                try {
                    Stop();
                } catch (Exception ex2) {
                    DSUtilities.Msg(ex2);
                }
            }
        }

        /* stop the search */
        private void StopSearchingToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                Stop();
            } catch (Exception ex) {
                ShowError(ex);
            }
        }

        /* pause the searcch */
        private void PauseSearchingToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                Pause();
            } catch (Exception ex) {
                ShowError(ex);
            }
        }

        /* resume the search */
        private void ResumeSearchingToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                Resume();
            } catch (Exception ex) {
                ShowError(ex);
            }
        }

        /* open the documentation */
        private void DocumentationToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                OpenDocumentation();
            } catch (Exception ex) {
                ShowError(ex);
            }
        }

        /* show compare contents dialog */
        private void CompareContentsToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                CompareSelectedResultsContents();
            } catch (Exception ex) {
                ShowError(ex);
            }
        }

        /* show the debug window */
        private void ViewDebugToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                DSDebug.ShowDebug();
            } catch (Exception ex) {
                ShowError(ex);
            }
        }

        /* show the about */
        private void AboutToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                ShowAbout();
            } catch (Exception ex) {
                ShowError(ex);
            }
        }

        /* browses for a place to move the files */
        private void MoveToBrowseToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                MoveSelectedResultsToBrowse();
            } catch (Exception ex) {
                ShowError(ex);
            }
        }

        /* open */
        private void OpenToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                OpenSelectedResults();
            } catch (Exception ex) {
                ShowError(ex);
            }
        }

        /* delete perm */
        private void DeletePermenantlyToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                DeleteSelectedResults();
            } catch (Exception ex) {
                ShowError(ex);
            }
        }

        /* open containing Directory */
        private void OpenContainingDirectoryToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                OpenContainingDirectory();
            } catch (Exception ex) {
                ShowError(ex);
            }
        }

        /* move selected results to recycler */
        private void MoveToRecycleBinToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                RecycleSelectedResults();
            } catch (Exception ex) {
                ShowError(ex);
            }
        }

        /* refrehs the results */
        private void RefreshToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                RefreshResults();
            } catch (Exception ex) {
                ShowError(ex);
            }
        }

        /* open auto select */
        private void AutoSelectToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                OpenAutoSelect();
            } catch (Exception ex) {
                ShowError(ex);
            }
        }

        /* sets the output file text box */
        private void OutputFileBrowseButton_Click(object sender, EventArgs e) {
            try {
                BrowseTextBox(OutputFile, "Text Files (*.txt)|*.txt|All Files (*.*)|*.*", false);
            } catch (Exception ex) {
                ShowError(ex);
            }
        }

        /* sets the log file */
        private void LogFileBrowseButton_Click(object sender, EventArgs e) {
            try {
                BrowseTextBox(LogFile, "Log Files (*.log)|*.log|All Files (*.*)|*.*", false);
            } catch (Exception ex) {
                ShowError(ex);
            }
        }

        /* handle key press */
        private void BasicResultsList_KeyPress(object sender, KeyPressEventArgs e) {
            try {
                if (e.KeyChar == 13) {
                    OpenSelectedResults();
                    e.Handled = true;
                }
            } catch (Exception ex) {
                ShowError(ex);
            }
        }

        /* time to update the details */
        private void BasicResultsList_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e) {
            try {
                /* update */
                if (!isAutoSelecting) {
                    DSComparable comparable = (DSComparable)e.Item.Tag;

                    if (e.IsSelected) {
                        resultListDeselectCount = 0;
                        selectedResultsList.Tag = e.Item;
                        UpdateDetails(e.Item);
                    } else {
                        if (resultListDeselectCount < 1) {
                            resultListDeselectCount++;
                            selectedResultsList.Tag = null;
                            UpdateDetails();
                        }
                    }
                    
                    /* update based on availablity */
                    UpdateListViewItem(e.Item);
                    if (comparable.Exists()) {
                    } else {
                        e.Item.Selected = false;
                    }
                }
                
                /* gotta update */
                UpdateControls();
            } catch (Exception ex) {
                ShowError(ex);
            }
        }

        /* handle the shizle */
        private void GroupResultsList_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                LoadResultGroupList();
                UpdateDetails();
                UpdateControls();
            } catch (Exception ex) {
                ShowError(ex);
            }
        }

        /* set the correct selectedResultsList */
        private void SearchResultsTabs_Selecting(object sender, TabControlCancelEventArgs e) {
            try {
                if (e.Action == TabControlAction.Selecting) {
                    /* set the selected listview */
                    selectedResultsList = (e.TabPage == SearchResultsBasicTab) ? BasicResultsList : ResultGroupList;

                    /* god damn updating shit */
                    UpdateDetails();
                    UpdateControls();
                    UpdateStatus();
                }
            } catch (Exception ex) {
                ShowError(ex);
            }
        }

        /* update */
        private void DetailViewPreview_CheckedChanged(object sender, EventArgs e) {
            try {
                UpdateDetails();
                UpdateControls();
            } catch (Exception ex) {
                ShowError(ex);
            }
        }

        /* update */
        private void DetailFitToWindow_CheckedChanged(object sender, EventArgs e) {
            try {
                UpdateDetails();
                UpdateControls();
            } catch (Exception ex) {
                ShowError(ex);
            }
        }

        /* update the status */
        private void UpdateStatusTimer_Tick(object sender, EventArgs e) {
            try {
                UpdateStatus();
            } catch (Exception ex) {
                ShowError(ex);
            }
        }

        /* updates the restuls */
        private void UpdateResultsTimer_Tick(object sender, EventArgs e) {
            try {
                UpdateResults();
            } catch (Exception ex) {
                ShowError(ex);
            }
        }

        /* handle registration timer */
        private void CheckRegisterTimer_Tick(object sender, EventArgs e) {
            try {
                string message = "UNREGISTERED - Only " + DSLicensing.TrialMaxMatches.ToString() + " matches shown per search. Click here to register.";

                /* if there are matches shown */
                if (model.TotalMatchedCount > 0) {
                    /* and if not registered */
                    if (DSLicensing.IsRegistered) {
                        SelectedResultCountLabel.Cursor = Cursors.Default;
                    } else {
                        SelectedResultCountLabel.Cursor = Cursors.Hand;

                        if (SelectedResultCountLabel.Text.Equals(message)) {
                            SelectedResultCountLabel.Text = (string)SelectedResultCountLabel.Tag;
                            SelectedResultCountLabel.Tag = null;
                            SelectedResultCountLabel.ForeColor = Color.Black;
                            CheckRegisterTimer.Interval = 6000;
                        } else {
                            SelectedResultCountLabel.Tag = SelectedResultCountLabel.Text;
                            SelectedResultCountLabel.Text = message;
                            SelectedResultCountLabel.ForeColor = Color.Red;
                            CheckRegisterTimer.Interval = 3000;
                        }
                    }
                }
            } catch (Exception ex) {
                DSUtilities.Msg(ex);
            }
        }

        /* handle paint for menu */
        private void MainMenu_Paint(object sender, PaintEventArgs e) {
            try {
                //e.Graphics.DrawImage(UnisoftLogo.Image, UnisoftLogo.Location);
                e.Graphics.DrawString(RegistrationLbl.Text, RegistrationLbl.Font, Brushes.Black, RegistrationLbl.Location);
            } catch (Exception ex) {
                DSDebug.PrintException(ex);
            }
        }

        /* for handling the click event for various reaons */
        private void MainMenu_MouseClick(object sender, MouseEventArgs e) {
            try {
                if (UnisoftLogo.RectangleToScreen(UnisoftLogo.DisplayRectangle).Contains(PointToScreen(e.Location)))
                    UnisoftLogo_Click(this, null);
                else if (RegistrationLbl.RectangleToScreen(RegistrationLbl.DisplayRectangle).Contains(PointToScreen(e.Location)))
                    RegistrationLbl_Click(this, null);
            } catch (Exception ex) {
                DSDebug.PrintException(ex);
            }
        }

        /* handle mouse move - primarily to change cursor for unisoft logo */
        private void MainMenu_MouseMove(object sender, MouseEventArgs e) {
            try {
                if (UnisoftLogo.RectangleToScreen(UnisoftLogo.DisplayRectangle).Contains(PointToScreen(e.Location)))
                    MainMenu.Cursor = System.Windows.Forms.Cursors.Hand;
                else if (RegistrationLbl.RectangleToScreen(RegistrationLbl.DisplayRectangle).Contains(PointToScreen(e.Location)))
                    MainMenu.Cursor = System.Windows.Forms.Cursors.Hand;
                else
                    MainMenu.Cursor = System.Windows.Forms.Cursors.Default;
            } catch (Exception ex) {
                DSDebug.PrintException(ex);
            }
        }

        /* open the item */
        private void BasicResultsList_DoubleClick(object sender, EventArgs e) {
            try {
                if (selectedResultsList.SelectedItems.Count == 1) {
                    if (selectedResultsList.Tag != null) {
                        ListViewItem item = (ListViewItem)selectedResultsList.Tag;
                        DSComparable comp = (DSComparable)item.Tag;
                        DSUtilities.Launch(comp.FSI.FullName);
                    }
                }
            } catch (Exception ex) {
                ShowError(ex);
            }
        }

        /* add to list */
        private void NewFileIncludeFilter_KeyPress(object sender, KeyPressEventArgs e) {
            try {
                if (e.KeyChar == '\r') {
                    e.Handled = true;
                    AddFileIncludeFilterButton.PerformClick();
                    NewFileIncludeFilter.Focus();
                }
            } catch (Exception ex) {
                ShowError(ex);
            }
        }

        /* yep */
        private void NewFileExcludeFilter_KeyPress(object sender, KeyPressEventArgs e) {
            try {
                if (e.KeyChar == '\r') {
                    e.Handled = true;
                    AddFileExcludeFilterButton.PerformClick();
                    NewFileExcludeFilter.Focus();
                }
            } catch (Exception ex) {
                ShowError(ex);
            }
        }

        /* yep */
        private void NewDirIncludeFilter_KeyPress(object sender, KeyPressEventArgs e) {
            try {
                if (e.KeyChar == '\r') {
                    e.Handled = true;
                    AddDirectoryIncludeFilterButton.PerformClick();
                    NewDirIncludeFilter.Focus();
                }
            } catch (Exception ex) {
                ShowError(ex);
            }
        }

        /* exclude filter */
        private void NewDirExcludeFilter_KeyPress(object sender, KeyPressEventArgs e) {
            try {
                if (e.KeyChar == '\r') {
                    e.Handled = true;
                    AddDirectoryExcludeFilterButton.PerformClick();
                    NewDirExcludeFilter.Focus();
                }
            } catch (Exception ex) {
                ShowError(ex);
            }
        }

        /* handle all of the builtin criteria */
        private void GeneralBuiltinCriteriaToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                ToolStripMenuItem item = (ToolStripMenuItem)sender;
                if (item.Tag == null) {
                    FileIncludeFilterList.Items.Clear();
                    FileExcludeFilterList.Items.Clear();
                    DirectoryIncludeFilterList.Items.Clear();
                    DirectoryExcludeFilterList.Items.Clear();
                } else {
                    LoadBuiltinCriteria(item.Tag.ToString());
                }
                AddAllDrives();
            } catch (Exception ex) {
                ShowError(ex);
            }
        }

        /* load criteria */
        private void SearchForButton_Click(object sender, EventArgs e) {
            try {
                BuiltInCriteriaMenuStrip.Show(SearchForButton, new Point(0, SearchForButton.Height));
            } catch (Exception ex) {
                DSUtilities.Msg(ex);
            }
        }

        /* update the controls when selected */
        private void General_ItemChecked(object sender, ItemCheckedEventArgs e) {
            try {
                UpdateControls();
            } catch (Exception ex) {
                ShowError(ex);
            }
        }

        /* upon change */
        private void General_TextChanged(object sender, EventArgs e) {
            try {
                UpdateControls();
            } catch (Exception ex) {
                ShowError(ex);
            }
        }

        /* checked */
        private void General_CheckedChanged(object sender, EventArgs e) {
            try {
                UpdateControls();
            } catch (Exception ex) {
                ShowError(ex);
            }
        }


        //private methods-----------------------------------------------
        /* to be called when the form is constructed */
        private void InitializeControls() {
            /* try to fix the context menu */
            ResultsContextMenu.Show(this, 100, 100);
            ResultsContextMenu.Close();
            BuiltInCriteriaMenuStrip.Show(this, 100, 100);
            BuiltInCriteriaMenuStrip.Close();

            /* initial detail image */
            defaultDetailIcon = DetailIcon.Image;

            /* set initial results list */
            selectedResultsList = (SearchResultsTabs.SelectedTab == SearchResultsBasicTab) ? BasicResultsList : ResultGroupList;

            /* set values that can not be set during design */
            MainSplit.Panel1MinSize = 262;
            MainSplit.Panel2MinSize = 350;
            SearchCriteriaBasicSplitter.Panel1MinSize = 130;
            SearchCriteriaBasicSplitter.Panel2MinSize = 280;
            SearchResultsGroupedTabSplitter.Panel1MinSize = 150;
            SearchResultsGroupedTabSplitter.Panel2MinSize = 150;
            SearchResultsSplitter.Panel1MinSize = 200;
            SearchResultsSplitter.Panel2MinSize = 150;
            DetailSplitter.Panel1MinSize = 150;
            DetailSplitter.Panel2MinSize = 150;

            /* set image lists */
            DSUtilities.SetLargeSystemImageList(BasicResultsList);
            DSUtilities.SetSmallSystemImageList(BasicResultsList);
            DSUtilities.SetLargeSystemImageList(ResultGroupList);
            DSUtilities.SetSmallSystemImageList(ResultGroupList);

            /* perform initial updates */
            Text = Application.ProductName + " " + Application.ProductVersion;
        }

        /* resets all of the results if there are any */
        private void Reset() {
            /* clear model */
            model.Reset();

            /* clear console */
            console.Reset();

            /* reset collections */
            newMatches.Clear();

            /* close any open dialogs */
            CloseSearchCompleteDialog();
            CloseAutoSelectDialog();
            
            /* reset basic */
            BasicResultsList.Items.Clear();
            /* reset group results */
            GroupResultsList.Items.Clear();
            /* reset match group */
            ResultGroupList.Items.Clear();

            /* set flags */
            isPaused = false;
            finishedCompletely = false;
        }

        /* starts the search */
        private void Start() {
            /* let user know it might be a while */
            OverallStatus.Text = "Starting, please wait...";
            Application.DoEvents();

            /* clear all memory */
            Reset();
            
            /* keep footprint small hopefully */
            GC.Collect();

            /* load settings to model */
            LoadModelAndConsoleFromGUI();

            /* opens the log and output files as necessar */
            OpenFiles();

            /* start model */
            model.Start();

            /* indicate started */
            isStarted = true;

            /* update controls and details */
            UpdateDetails();
            UpdateControls();
        }

        /* stops the search */
        private void Stop() {
            /* THIS SHOULD BE THE ONLY POINT WHERE isStarted is sET TO FALSE */
            if (isStarted) {
                /* signal stop */
                isStarted = false;

                /* notify */
                OverallStatus.Text = "Stopping, please wait...";
                Application.DoEvents();

                /* stop model */
                model.Stop();

                /* update final results */
                UpdateResults(true);

                /* clear results */
                model.ClearNewMatches(); //clear the new matches queue

                /* writes the output file if necessary */
                if (UseOutputFile.Checked)
                    WriteOutputFile();

                /* close log and output files */
                CloseFiles();

                /* reflect in controls */
                UpdateControls();

                /* final status update */
                UpdateStatus(true);
            }
        }

        /* pauses the operation */
        private void Pause() {
            isPaused = true;
            if (model.IsStarted)
                model.Pause();
            UpdateControls();
        }

        /* resumes the operation */
        private void Resume() {
            if (model.IsStarted)
                model.Resume();
            isPaused = false;
            UpdateControls();
        }

        /* called when the search is complete */
        private void SearchComplete() {
            ProgressBar.Value = ProgressBar.Minimum;
            ProgressBar.Maximum = 100;

            CloseSearchCompleteDialog();

            if (!isClosing) {
                searchCompleteDialog = new DSSearchComplete(model, this);
                searchCompleteDialog.Show();
            }
        }

        /* opens the log and output files as necessary */
        private void OpenFiles() {
            /* output file */
            if (UseOutputFile.Checked) {
                if (OutputFile.Text.Length > 0) {
                } else {
                    throw new Exception("An output file must be specified if it is going to be used.");
                }
            }

            /* log file */
            if (UseLogFile.Checked) {
                if (LogFile.Text.Length > 0) {
                } else {
                    throw new Exception("A log file must be specified if it is going to be used.");
                }
            }
        }

        /* closes the log and output files */
        private void CloseFiles() {
            console.CloseLogFile();
            console.CloseOutputFile();
        }

        /* writes the output file */
        private void WriteOutputFile() {
            if (model.MatchGroups.Count > 0) {
                OverallStatus.Text = "Writing output file...";
                Application.DoEvents();

                console.WriteLine("Showing grouped matches:");
                DSAVLBST<DSMatchGroup>.AscendingOrderEnumerator groups = model.MatchGroups.GetEnumerator();
                while (groups.MoveNext())
                    console.WriteMatchGroup(groups.Current);
            }
        }

        /* updates all of the controls on the forms as necessary */
        private void UpdateControls() {
            /* ensure we are not trying to save time */
            if (!isUpdating) {
                /* set enable/disable flags of search controls */
                SearchResultsFrame.Enabled = ((!isStarted) || ((!(UseOutputFile.Checked && OnlyOutputFile.Checked)) && (MatchFiles.Checked || MatchDirectories.Checked) && (SearchLocationsList.CheckedItems.Count > 0)));
                SearchForButton.Enabled = (!isStarted);
                RemoveSearchLocationButton.Enabled = (SearchLocationsList.SelectedItems.Count > 0);
                RemoveFileExcludeFilterButton.Enabled = (FileExcludeFilterList.SelectedItems.Count > 0);
                RemoveFileIncludeFilterButton.Enabled = (FileIncludeFilterList.SelectedItems.Count > 0);
                RemoveDirectoryExcludeFilterButton.Enabled = (DirectoryExcludeFilterList.SelectedItems.Count > 0);
                RemoveDirectoryIncludeFilterButton.Enabled = (DirectoryIncludeFilterList.SelectedItems.Count > 0);
                MatchOnNameORContent.Enabled = (MatchContents.Checked && MatchNames.Checked);
                MatchFilesToDirectories.Enabled = (MatchDirectories.Checked && MatchFiles.Checked);
                DSUtilities.EnableDisableAllExcept(null, ((!isStarted) && (model.NewMatchCount == 0)), SearchCriteriaBasicTab.Controls);
                DSUtilities.EnableDisableAllExcept(null, ((!isStarted) && (model.NewMatchCount == 0)), SearchCriteriaAdvancedTab.Controls);
                DetailSplitter.Panel2Collapsed = (!DetailViewPreview.Checked);
                DetailFitToWindow.Enabled = (DetailPreview.Tag == null);
                MinFileSizeLbl.Enabled = MatchFiles.Checked;
                MaxFileSizeLbl.Enabled = MatchFiles.Checked;
                MinFileSize.Enabled = MatchFiles.Checked;
                MaxFileSize.Enabled = MatchFiles.Checked;
                MinFileSizeUnits.Enabled = MatchFiles.Checked;
                MaxFileSizeUnits.Enabled = MatchFiles.Checked;

                /* start/stop/pause/resume buttons */
                PauseButton.Enabled = ((isStarted || (model.NewMatchCount > 0)) && (!isPaused));
                ResumeButton.Enabled = isPaused;
                StartButton.Enabled = ((!isStarted) && (model.NewMatchCount == 0) && (SearchLocationsList.CheckedItems.Count > 0));
                StopButton.Enabled = ((isStarted && (SearchLocationsList.CheckedItems.Count > 0)) || (model.NewMatchCount > 0));

                /* enable disable menus */
                AddSearchLocationToolStripMenuItem.Enabled = AddSearchLocationButton.Enabled;
                RemoveSearchLocationsToolStripMenuItem.Enabled = RemoveSearchLocationButton.Enabled;
                AboutToolStripMenuItem.Enabled = (!isStarted);
                SaveCriteriaToolStripMenuItem.Enabled = (!isStarted);
                LoadCriteriaToolStripMenuItem.Enabled = (!isStarted);
                LoadBuiltinCriteriaToolStripMenuItem.Enabled = (!isStarted);
                PauseSearchingToolStripMenuItem.Enabled = PauseButton.Enabled;
                ResumeSearchingToolStripMenuItem.Enabled = ResumeButton.Enabled;
                StopSearchingToolStripMenuItem.Enabled = StopButton.Enabled;
                StartSearchingToolStripMenuItem.Enabled = StartButton.Enabled;

                /* result context menu items */
                AutoSelectToolStripMenuItem.Enabled = (selectedResultsList.Items.Count > 0);
                OpenToolStripMenuItem.Enabled = (selectedResultsList.SelectedItems.Count > 0);
                DeletePermenantlyToolStripMenuItem.Enabled = (selectedResultsList.SelectedItems.Count > 0);
                CompareContentsToolStripMenuItem.Enabled = (selectedResultsList.SelectedItems.Count == 2);
                MoveToToolStripMenuItem.Enabled = (selectedResultsList.SelectedItems.Count > 0);
                MoveToBrowseToolStripMenuItem.Enabled = (selectedResultsList.SelectedItems.Count > 0);
                MoveToRecycleBinToolStripMenuItem.Enabled = (selectedResultsList.SelectedItems.Count > 0);
                OpenContainingDirectoryToolStripMenuItem.Enabled = (selectedResultsList.SelectedItems.Count > 0);
                RefreshToolStripMenuItem.Enabled = (selectedResultsList.Items.Count > 0);

                /* auto update */
                AutomaticallyCheckForUpdatesToolStripMenuItem.Checked = DSUpdate.AutomaticallyUpdate;

                /* enable disable button */
                DetailAutoSelectButton.Enabled = AutoSelectToolStripMenuItem.Enabled;
                DetailOpenResultButton.Enabled = OpenToolStripMenuItem.Enabled;
                DetailDeletePermenantlyResultButton.Enabled = DeletePermenantlyToolStripMenuItem.Enabled;
                DetailCompareContentsButton.Enabled = CompareContentsToolStripMenuItem.Enabled;
                DetailMoveToButton.Enabled = MoveToToolStripMenuItem.Enabled;
                DetailOpenContainingDirectoryButton.Enabled = OpenContainingDirectoryToolStripMenuItem.Enabled;
                DetailRefreshButton.Enabled = RefreshToolStripMenuItem.Enabled;

                /* group boxes */
                DSUtilities.EnableDisableAllExcept(UseOutputFile, UseOutputFile.Checked, OutputFileFrame.Controls);
                DSUtilities.EnableDisableAllExcept(UseLogFile, UseLogFile.Checked, LogFileFrame.Controls);
                DSUtilities.EnableDisableAllExcept(MatchNames, MatchNames.Checked, CompareNamesFrame.Controls);
                DSUtilities.EnableDisableAllExcept(MatchContents, MatchContents.Checked, CompareContentsFrame.Controls);

                /* we modify the status here if there are no search locations specified (knowing that a search could not have been started */
                if (isStarted) {
                } else {
                    if (SearchLocationsList.Items.Count == 0) {
                        OverallStatus.Text = "Add a search location.";
                    } else if (finishedCompletely) {
                        OverallStatus.Text = "Ready. Search Complete.";
                    } else {
                        if (StartButton.Enabled)
                            OverallStatus.Text = "Ready. Click 'Start' to begin search.";
                        else
                            OverallStatus.Text = "Ready.";
                    }
                }

                /* update the criteria description */
                UpdateCriteriaDescription();
            }
        }

        /* updates the status */
        private void UpdateStatus() { UpdateStatus(false); }
        private void UpdateStatus(bool forceUpdate) {
            /* ensure we do not execute more than once at a time */
            if (alreadyInUpdateStatus && (!forceUpdate)) {
                //then just blow out of here
            } else {
                /* ensure no reentry */
                alreadyInUpdateStatus = true;

                /* update registration status */
                UpdateRegistrationStatus();

                /* ensure we have started */
                if (isStarted || forceUpdate) {
                    /* update status bar text */
                    if (model.IsStarted) { //if it is started
                        if (model.IsRunning) { //and running
                            /* now set the status text */
                            if (model.CurrentSearchLocation == null)
                                OverallStatus.Text = "Search Complete. Comparing: " + model.CurrentComparison;
                            else
                                OverallStatus.Text = "Searching: " + model.CurrentSearchLocation;
                        } else { //else if not running, but it is started, then it is paused
                            OverallStatus.Text = "Paused.";
                        }
                    } else if ((model.NewMatchCount > 0) || (newMatches.Count > 0)) { //if not started, but there are still new matches to be had, then we are still loading them
                        if (isPaused)
                            OverallStatus.Text = "Paused.";
                        else
                            OverallStatus.Text = "Loading results: " + BasicResultsList.Items.Count.ToString() + " / " + model.TotalMatchedCount.ToString();
                    } else { //else we have completely stopped and are done.
                        /* set flags for status indication */
                        finishedCompletely = true;
                        isPaused = false;

                        /* ensure this does not get called until next start */
                        Stop();

                        /* call the final search complete functin */
                        SearchComplete();
                    }

                    /* update the progress bar */
                    if (model.IsStarted) {
                        if (model.IsRunning) {
                            if (ProgressBar.MarqueeAnimationSpeed == 0) {
                                ProgressBar.MarqueeAnimationSpeed = 50;
                                ProgressBar.Visible = true;
                            }
                        } else {
                            if (ProgressBar.MarqueeAnimationSpeed > 0) {
                                ProgressBar.MarqueeAnimationSpeed = 0;
                                ProgressBar.Visible = true;
                            }
                        }
                    } else {
                        ProgressBar.MarqueeAnimationSpeed = 0;
                        ProgressBar.Visible = false;
                    }

                    /* update the rest of the statuses */
                    TotalFilesComparedStatus.Text = "Files Compared: " + model.TotalFilesCompared.ToString();
                    TotalDirectoriesComparedStatus.Text = "Dirs Compared: " + model.TotalDirectoriesCompared.ToString();
                    TotalMatchesStatus.Text = "Matches: " + model.TotalNewMatchCount.ToString();
                    TotalMatchGroupsStatus.Text = "Groups: " + model.TotalMatchedGroupCount.ToString();

                    /* update the selected result count label */
                    string countLabel = "Hold CTRL to select multiple results. Selected Results: " + selectedResultsList.SelectedItems.Count.ToString() + "/" + selectedResultsList.Items.Count.ToString();
                    if (SelectedResultCountLabel.Tag == null)
                        SelectedResultCountLabel.Text = countLabel;
                    else
                        SelectedResultCountLabel.Tag = countLabel;
                }

                /* allow reentry */
                alreadyInUpdateStatus = false;
            }
        }

        /* updates the results */
        private void UpdateResults() { UpdateResults(false); }
        private void UpdateResults(bool forceUpdate) {
            /* we might be entering this from a DoEvents - ensure there's no funny business */
            if (alreadyInUpdateResults && (!forceUpdate)) {
                //just exit the function
            } else {
                /* do not allow further entry -- because DoEvents is called */
                alreadyInUpdateResults = true;

                /* only go into if it was started or forceUpdate is true */
                if (isStarted || forceUpdate) {
                    /* check to see if there is anything to update */
                    if (model.NewMatchCount > 0) {
                        if (newMatches.Count == 0)
                            newMatches = model.GetNewMatches(100); // get the latest matches (limit to a certain amount so that this function exits periodically ) 

                        /* iterate over all new matches, get the group, and update the gui */
                        while ((newMatches.Count > 0) && (!isPaused) && (isStarted || forceUpdate)) {
                            /* get the next match and assign to a group */
                            DSMatch match = newMatches.Dequeue();

                            /* check to see if we are supposed to use the gui */
                            if (UseOutputFile.Checked && OnlyOutputFile.Checked) {
                            } else {
                                /* add the match to the results */
                                AddMatchToResults(match);
                            }

                            /* check to see if we need to be writing to the log */
                            if (UseLogFile.Checked) 
                                console.WriteLog(model);

                            /* call doevents every certain amount to ensure a smooth gui */
                            if ((newMatches.Count % 20) == 0) {
                                Application.DoEvents();
                            }
                        }
                    }
                }

                /* allow reentry */
                alreadyInUpdateResults = false;
            }
        }

        /* update the criteria descriptoin */
        private void UpdateCriteriaDescription() {
            string desc = GetCriteriaDescription();
            if (CriteriaDescription.Text.CompareTo(desc) != 0) {
                CriteriaDescription.Text = desc;
            }
        }

        /* update the registration status info */
        private void UpdateRegistrationStatus() {
            string status = "";

            if (DSLicensing.IsRegistered)
                status = "Registered to: " + DSLicensing.RegisteredUserName;
            else
                status = "UNREGISTERED";

            if (!RegistrationLbl.Text.Equals(status)) {
                RegistrationLbl.Text = status;
                RegistrationLbl.Location = new Point((UnisoftLogo.Location.X - RegistrationLbl.Width) - 5, RegistrationLbl.Location.Y);
                MainMenu.Invalidate();
            }
        }

        /* add a match to the restuls */
        private void AddMatchToResults(DSMatch match) {
            AddMatchToBasicResults(match);
            AddMatchToGroupedResults(match);
        }

        /* adds a match to the basic results */
        private void AddMatchToBasicResults(DSMatch match) {
            DSMatchGroup matchGroup = match.ParentGroup;

            /* add to the relationships if it was not already added */
            if (matchGroup.FirstComparable.Tag == null) {
                /* add the matched since this is a new group */
                AddComparableToBasicResultsList(matchGroup.FirstComparable);
            }

            /* matchedTo should be already added since it is the FirstComparable, but maake sure */
            if (match.MatchedTo.Tag == null)
                AddComparableToBasicResultsList(match.MatchedTo);

            /* add the match */
            if (match.Matched.Tag == null)
                AddComparableToBasicResultsList(match.Matched);
        }

        /* adds a new item based on fsi and group */
        private void AddComparableToBasicResultsList(DSComparable comparable) {
            int index = 0;

            /* get the index for the new item */
            if (comparable.ParentGroup.FirstComparable.Tag == null) {
                index = BasicResultsList.Items.Count;
            } else {
                ListViewItem item = (ListViewItem)comparable.ParentGroup.FirstComparable.Tag;
                index = item.Index;
            }

            /* get a new lv item */
            ListViewItem newItem = CreateListViewItemFromComparable(comparable);

            /* set the tag of the comparable */
            comparable.Tag = newItem;

            /* insert the item */
            BasicResultsList.Items.Insert(index, newItem);
        }

        /* adds a match to the advanced results */
        private void AddMatchToGroupedResults(DSMatch match) {
            /* add to the relationships if it was not already added */
            if (match.ParentGroup.Tag == null) {
                ListViewItem newItem = GroupResultsList.Items.Add(match.ParentGroup.UniqueValue);
                
                /* set references */
                newItem.Tag = match.ParentGroup;
                match.ParentGroup.Tag = newItem;

                /* add detail nodes */
                newItem.SubItems.Add(match.ParentGroup.Matches.Count.ToString());
                newItem.SubItems.Add(match.ParentGroup.GetFileMatchCount().ToString());
                newItem.SubItems.Add(match.ParentGroup.GetDirectoryMatchCount().ToString());
            } else {
                /* update the matchgroup details */
                ListViewItem item = (ListViewItem)match.ParentGroup.Tag;
                item.SubItems[1].Text = match.ParentGroup.Matches.Count.ToString();
                item.SubItems[2].Text = match.ParentGroup.GetFileMatchCount().ToString();
                item.SubItems[3].Text = match.ParentGroup.GetDirectoryMatchCount().ToString();
            }
        }

        /* loads the ResultGroupList, part of the Grouped shit */
        private void LoadResultGroupList() {
            ResultGroupList.Items.Clear();
            if (GroupResultsList.SelectedItems.Count == 1) {
                DSMatchGroup matchGroup = (DSMatchGroup)GroupResultsList.SelectedItems[0].Tag;
                /* add to the list */
                foreach (DSComparable comparable in matchGroup.Matches) 
                    ResultGroupList.Items.Add(CreateListViewItemFromComparable(comparable));
            }
        }

        /* returns a listviewitem generated from a comparable */
        private ListViewItem CreateListViewItemFromComparable(DSComparable comparable) {
            /* create the new item */
            ListViewItem newItem = new ListViewItem();
            newItem.Tag = comparable;

            /* add initial subitems */
            newItem.Text = "";
            foreach (ColumnHeader header in BasicResultsList.Columns) {
                if (header.Index >= newItem.SubItems.Count) {
                    ListViewItem.ListViewSubItem subItem = new ListViewItem.ListViewSubItem();
                    newItem.SubItems.Add(subItem);
                }
                newItem.SubItems[header.Index].Name = header.Name;
            }

            /* update the item with the comparables shit */
            UpdateListViewItem(newItem);

            return newItem;
        }

        /* updates the lst view item with the deailts of the dscomparable */
        private void UpdateListViewItem(ListViewItem item) {
            DSComparable comparable = (DSComparable)item.Tag;
            DSMatchGroup matchGroup = comparable.ParentGroup;
            string name = "";
            string path = "";
            string size = "";
            string fileSizeFormat = "#,##0";
            string dirSizeFormat = "#,##0";
            string type = "";
            Color backcolor = ((matchGroup.Index % 2) == 0) ? color1 : color2;

            /* get the name and path */
            int slashIndex = comparable.FSI.FullName.LastIndexOf('\\');
            if (slashIndex > 0) {
                path = comparable.FSI.FullName.Substring(0, slashIndex);
                name = comparable.FSI.FullName.Substring(slashIndex + 1);
            } else {
                path = comparable.FSI.FullName;
                name = comparable.FSI.FullName;
            }

            /* get the size and load new icon if necessary */
            if (comparable.FSI is FileInfo) {
                FileInfo fi = (FileInfo)comparable.FSI;
                size = fi.Length.ToString(fileSizeFormat);
                type = DSUtilities.GetFileTypeInfo(comparable.FSI.FullName, false, true);
            } else if (comparable.FSI is DirectoryInfo) {
                try {
                    size = "Files: " + comparable.FileArray.LongLength.ToString(dirSizeFormat) + ", Dirs: " + comparable.DirectoryArray.LongLength.ToString(dirSizeFormat);
                } catch {
                    size = "Access denied.";
                }
                type = DSUtilities.GetFileTypeInfo(comparable.FSI.FullName, true, true);
            } else {
                size = "";
            }

            /* see if exists */
            if (comparable.Exists()) {
                if (name.IndexOf(removedIndication) == 0)
                    name = name.Substring(removedIndication.Length);
            } else {
                name = removedIndication + name;
                backcolor = nonexistentColor;
            }

            /* set the subitem shit */
            item.SubItems["Type"].Text = type;
            item.SubItems["Path"].Text = path;
            item.SubItems["Name"].Text = name;
            item.SubItems["Size"].Text = size;
            item.SubItems["LastModifiedDate"].Text = comparable.FSI.LastWriteTime.ToString();
            item.SubItems["CreationDate"].Text = comparable.FSI.CreationTime.ToString();
            item.SubItems["MatchGroupID"].Text = matchGroup.UniqueValue;
            item.ImageIndex = GetIconIndex(comparable.FSI);
            item.BackColor = backcolor;

            /* ensure we are calling from the basicresult list */
            if (comparable.Tag != null)
                if (comparable.Tag != item) //then we are not using the item from the basicresultslist and neeed to update that one too 
                    UpdateListViewItem((ListViewItem)comparable.Tag);
        }

        /* updates the details for a match */
        private void UpdateDetails() {
            int count = selectedResultsList.SelectedItems.Count;
            ListViewItem selectedResultItem = (ListViewItem)selectedResultsList.Tag;
            if (count > 0) {
                /* update with item */
                if (selectedResultItem == null)
                    UpdateDetails(selectedResultsList.SelectedItems[(count - 1)]);
                else
                    UpdateDetails(selectedResultItem);
            } else {
                ClearDetails();
            }
            
        }
        private void UpdateDetails(ListViewItem lvi) {
            if (lvi == null) {
                ClearDetails();
            } else {
                DSComparable comparable = (DSComparable)lvi.Tag;

                /* set icon and type*/
                if (comparable.FSI is FileInfo) {
                    DetailIcon.Image = DSUtilities.GetFileIcon(comparable.FSI.FullName, false, false, false, false).ToBitmap();
                    DetailNameAndType.Text = comparable.FSI.Name;
                    DetailNameAndType.Text += "\r\n" + DSUtilities.GetFileTypeInfo(comparable.FSI.FullName, false, true);
                } else if (comparable.FSI is DirectoryInfo) {
                    DetailIcon.Image = DSUtilities.GetFileIcon("", false, true, false, false).ToBitmap();
                    DetailNameAndType.Text = comparable.FSI.Name;
                    DetailNameAndType.Text = "\r\n" + DSUtilities.GetFileTypeInfo(comparable.FSI.FullName, true, true);
                }

                /* set match count */
                DetailMatchCount.Text = "Matches: " + comparable.ParentGroup.Matches.Count.ToString();

                /* set details */
                DetailMatchGroup.Text = GetMatchGroupDetails(comparable);

                /* set preview */
                if (DetailViewPreview.Checked)
                    SetDetailPreview(comparable.FSI);
                else
                    SetDetailPreview(null);
            }
        }

        /* clears the preview and all other file details */
        private void ClearDetails() {
            DetailNameAndType.Text = "Selected Match Info";
            DetailMatchCount.Text = "Matches: ";
            DetailMatchGroup.Text = "Full Path:\r\n\r\nMatched To:\r\n";
            DetailIcon.Image = defaultDetailIcon;
            SetDetailPreview(null);
            Application.DoEvents();
        }

        /* show the about */
        private void ShowAbout() {
            DSAbout about = new DSAbout();
            about.ShowDialog();
        }

        /* loads the settings from the GUI to the model */
        private void LoadModelAndConsoleFromGUI() {
            /* load teh search paths */
            model.ClearInitialSearchPaths();
            foreach (ListViewItem item in SearchLocationsList.CheckedItems) {
                try {
                    model.AddInitialSearchPath(item.Text);
                } catch { }
            }
            
            /* set values for model */
            model.MatchDirectories = MatchDirectories.Checked;
            model.MatchFiles = MatchFiles.Checked;
            model.MatchFilesToDirectories = MatchFilesToDirectories.Checked;
            model.ContentComparisonMode = GetContentComparisonMode();
            model.HeaderAndFooterByteCount = (int)HeaderFooterSize.Value;
            model.KeepLog = UseLogFile.Checked;
            model.MaxFileSize = (long)DSUtilities.GetFileSizeControlValue(MaxFileSize, MaxFileSizeUnits);
            model.MergeFilters = MergeFilters.Checked;
            model.MinFileSize = (long)DSUtilities.GetFileSizeControlValue(MinFileSize, MinFileSizeUnits);
            model.NameComparisonMode = GetNameComparisonMode();
            model.RemoveNonAlphaCharsFromName = RemoveNonalpha.Checked;
            model.RemoveNumberCharsFromName = RemoveNumbers.Checked;
            model.SearchMode = (DSSearchModes)SearchMode.SelectedIndex;
            model.SearchSubdirectories = SearchSubdirectories.Checked;
            model.TrackNewMatches = true;
            model.MatchSizes = MatchSizes.Checked;
            model.UseDefaultFilters = UseDefaultFilters.Checked;
            model.MatchtNameORContent = MatchOnNameORContent.Checked;
            model.PreLoadContents = PreloadContent.Checked;
            model.MatchDirectoryContents = CompareDirectoryContents.Checked;
            model.IgnoreExtensions = IgnoreExtensions.Checked;
            model.KeepLog = UseLogFile.Checked;
            model.ThreadCount = (int)MaxSearchThreads.Value;

            /* set values for console */
            console.LogFilePath = UseLogFile.Checked ? LogFile.Text : "";
            console.OnlyOutputFile = OnlyOutputFile.Checked;
            console.OutputFilePath = UseOutputFile.Checked ? OutputFile.Text : "";
            console.AppendLogFile = AppendLogFile.Checked;
            console.AppendOutputFile = AppendOutputFile.Checked;

            /* load the filters */
            model.FileNameExcludeFilters.Clear();
            model.FileNameIncludeFilters.Clear();
            model.DirNameExcludeFilters.Clear();
            model.DirNameIncludeFilters.Clear();
            foreach (ListViewItem item in FileExcludeFilterList.CheckedItems)
                model.FileNameExcludeFilters.Add(item.Text);
            foreach (ListViewItem item in FileIncludeFilterList.CheckedItems)
                model.FileNameIncludeFilters.Add(item.Text);
            foreach (ListViewItem item in DirectoryExcludeFilterList.CheckedItems)
                model.DirNameExcludeFilters.Add(item.Text);
            foreach (ListViewItem item in DirectoryIncludeFilterList.CheckedItems)
                model.DirNameIncludeFilters.Add(item.Text);

            /* this must always be set for the gui */
            model.NewMatchesToAllInMatchGroup = false;
        }

        /* loads the GUI from the model */
        private void LoadGUIFromModelAndConsole() {
            /* ensure we save time */
            isUpdating = true;

            /* load the search paths */
            string[] paths = model.GetInitialSearchPaths();
            SearchLocationsList.Items.Clear();
            foreach (string path in paths) {
                ListViewItem item = new ListViewItem(path);
                item.Checked = true;
                SearchLocationsList.Items.Add(item);
            }

            /* set control values from model */
            MatchContents.Checked = (model.ContentComparisonMode != DSContentComparisonMode.None);
            CCModeHeader.Checked = ((model.ContentComparisonMode == DSContentComparisonMode.Header) || (model.ContentComparisonMode == DSContentComparisonMode.None));
            CCModeAllContents.Checked = (model.ContentComparisonMode == DSContentComparisonMode.Full);
            CCModeHeaderAndFooter.Checked = (model.ContentComparisonMode == DSContentComparisonMode.HeaderAndFooter);
            MatchNames.Checked = (model.NameComparisonMode != DSNameComparisonMode.None);
            NCModeExact.Checked = ((model.NameComparisonMode == DSNameComparisonMode.Exact) || (model.NameComparisonMode == DSNameComparisonMode.None));
            NCModeSoundEx.Checked = (model.NameComparisonMode == DSNameComparisonMode.SoundEx);
            MatchDirectories.Checked = model.MatchDirectories;
            MatchFiles.Checked = model.MatchFiles;
            MatchFilesToDirectories.Checked = model.MatchFilesToDirectories;
            HeaderFooterSize.Value = model.HeaderAndFooterByteCount;
            UseOutputFile.Checked = console.OutputFilePath.Length > 0 ? true : false;
            UseLogFile.Checked = model.KeepLog;
            MergeFilters.Checked = model.MergeFilters;
            RemoveNonalpha.Checked = model.RemoveNonAlphaCharsFromName;
            RemoveNumbers.Checked = model.RemoveNumberCharsFromName;
            SearchMode.SelectedIndex = (int)model.SearchMode;
            SearchSubdirectories.Checked = model.SearchSubdirectories;
            MatchSizes.Checked = model.MatchSizes;
            UseDefaultFilters.Checked = model.UseDefaultFilters;
            MatchOnNameORContent.Checked = model.MatchtNameORContent;
            PreloadContent.Checked = model.PreLoadContents;
            CompareDirectoryContents.Checked = model.MatchDirectoryContents;
            IgnoreExtensions.Checked = model.IgnoreExtensions;
            MaxSearchThreads.Value = model.ThreadCount;

            /* set controls values from console */
            LogFile.Text = console.LogFilePath;
            OnlyOutputFile.Checked = console.OnlyOutputFile;
            OutputFile.Text = console.OutputFilePath;
            AppendLogFile.Checked = console.AppendLogFile;
            AppendOutputFile.Checked = console.AppendOutputFile;

            /* load min and max file sizes */
            DSUtilities.SetFileSizeControlValue(MinFileSize, MinFileSizeUnits, model.MinFileSize);
            DSUtilities.SetFileSizeControlValue(MaxFileSize, MaxFileSizeUnits, model.MaxFileSize);

            /* load the filters */
            FileExcludeFilterList.Items.Clear();
            FileIncludeFilterList.Items.Clear();
            DirectoryIncludeFilterList.Items.Clear();
            DirectoryExcludeFilterList.Items.Clear();
            foreach (string s in model.FileNameExcludeFilters) {
                ListViewItem i = new ListViewItem(s);
                i.Checked = true;
                FileExcludeFilterList.Items.Add(i);
            }
            foreach (string s in model.FileNameIncludeFilters) {
                ListViewItem i = new ListViewItem(s);
                i.Checked = true;
                FileIncludeFilterList.Items.Add(i);
            }
            foreach (string s in model.DirNameExcludeFilters) {
                ListViewItem i = new ListViewItem(s);
                i.Checked = true;
                DirectoryExcludeFilterList.Items.Add(i);
            }
            foreach (string s in model.DirNameIncludeFilters) {
                ListViewItem i = new ListViewItem(s);
                i.Checked = true;
                DirectoryIncludeFilterList.Items.Add(i);
            }

            /* ensure we save time */
            Application.DoEvents();
            isUpdating = false;

            /* now update the controls */
            UpdateControls();
        }

        /* gets the content comparison mode */
        private DSContentComparisonMode GetContentComparisonMode() {
            if (MatchContents.Checked) {
                if (CCModeAllContents.Checked)
                    return DSContentComparisonMode.Full;
                else if (CCModeHeader.Checked)
                    return DSContentComparisonMode.Header;
                else if (CCModeHeaderAndFooter.Checked)
                    return DSContentComparisonMode.HeaderAndFooter;

                return DSContentComparisonMode.None;
            } else {
                return DSContentComparisonMode.None;
            }
        }

        /* returns the name comparison mode */
        private DSNameComparisonMode GetNameComparisonMode() {
            if (MatchNames.Checked) {
                if (NCModeExact.Checked)
                    return DSNameComparisonMode.Exact;
                else if (NCModeSoundEx.Checked)
                    return DSNameComparisonMode.SoundEx;

                return DSNameComparisonMode.None;
            } else {
                return DSNameComparisonMode.None;
            }
        }

        /* loads the icon if not loaded and returns the index */
        private int GetIconIndex(FileSystemInfo fsi) {
            int index = 0;

            if (fsi is DirectoryInfo)
                index = DSUtilities.GetFileIconIndex(fsi.FullName, true, true);
            else
                index = DSUtilities.GetFileIconIndex(fsi.FullName, true, false);

            return index;
        }

        /* browses for a file */
        private string Browse(string startFile, string filter, bool isOpening) {
            if (isOpening) {
                OpenFileDialog.CheckFileExists = isOpening;
                OpenFileDialog.CheckPathExists = true;
                OpenFileDialog.Filter = filter;
                OpenFileDialog.FilterIndex = 0;
                OpenFileDialog.Title = "Choose a file to open";
                OpenFileDialog.FileName = startFile;
                if (OpenFileDialog.ShowDialog(this) == DialogResult.OK)
                    return OpenFileDialog.FileName;
            } else {
                SaveFileDialog.CheckFileExists = isOpening;
                SaveFileDialog.CheckPathExists = true;
                SaveFileDialog.CreatePrompt = (!isOpening);
                SaveFileDialog.OverwritePrompt = (!isOpening);
                SaveFileDialog.Filter = filter;
                SaveFileDialog.FilterIndex = 0;
                SaveFileDialog.Title = "Choose a file or specify a new file";
                SaveFileDialog.FileName = startFile;
                if (SaveFileDialog.ShowDialog(this) == DialogResult.OK)
                    return SaveFileDialog.FileName;
            }

            return null;
        }

        /* uses the savefiledialog to set a text box */
        private void BrowseTextBox(TextBox tb, string filter, bool isOpening) {
            string path = Browse(tb.Text, filter, isOpening);
            if (path != null)
                tb.Text = path;
        }

        /* launches the unisoft website */
        private void LaunchUnisoftWebsite() {
            DSUtilities.Launch("http://www.unisoftdevelopments.com/");
        }

        /* launches the ds website */
        private void LaunchDSWebsite() {
            DSUtilities.Launch("http://www.duplicatesearcher.com/");
        }

        /* closes the search results window */
        private void CloseSearchCompleteDialog() {
            if (searchCompleteDialog != null)
                if (!searchCompleteDialog.IsDisposed)
                    searchCompleteDialog.Close();
            searchCompleteDialog = null;
        }

        /* closes the autoselect dialog */
        private void CloseAutoSelectDialog() {
            if (autoSelectDialog != null)
                if (!autoSelectDialog.IsDisposed)
                    autoSelectDialog.Hide();
                else
                    autoSelectDialog = null;
        }

        /* closes the documentation dialog */
        private void CloseDocumentationDialog() {
            if (documentationDialog != null)
                if (!documentationDialog.IsDisposed)
                    documentationDialog.Hide();
                else
                    documentationDialog = null;
        }

        /* starts the compare contentsg */
        private void CompareSelectedResultsContents() {
            /* can only compare two at once */
            if (selectedResultsList.SelectedItems.Count == 2) {
                /* only the files for comparison */
                foreach (ListViewItem item in selectedResultsList.SelectedItems) {
                    DSComparable comparable = (DSComparable)item.Tag;
                    if (!(comparable.FSI is FileInfo)) {
                        DSUtilities.Msg("DuplicateSearcher will only compare the contents of files. Please select only two files for content comparison.");
                        return;
                    }
                }

                /* check to see if the sizes are the same */
                long size = 0;
                for (int i = 0; i < selectedResultsList.SelectedItems.Count; i++) {
                    DSComparable comparable = (DSComparable)selectedResultsList.SelectedItems[i].Tag;
                    if (size == 0)
                        size = comparable.GetSizeLong();
                    else
                        if (size != comparable.GetSizeLong()) {
                            DSUtilities.Msg("The files do not have the same contents because their sizes do not match.");
                            return;
                        }
                }

                /* let user know */
                if (MessageBox.Show("If the files are large in size, it may take DuplicateSearcher a long time to compare them. Please be patient.", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK) {
                    /* update status */
                    OverallStatus.Text = "Comparing the selected files. Please wait...";
                    Application.DoEvents();
                    
                    /* get hashes and comparison */
                    int i = 0;
                    string lastHash = "";
                    for (i = 0; i < selectedResultsList.SelectedItems.Count; i++) {
                        DSComparable comparable = (DSComparable)selectedResultsList.SelectedItems[i].Tag;
                        string hash = comparable.Hash; //this can take forever
                        if (lastHash.Length > 0) {
                            if (lastHash.CompareTo(hash) != 0)
                                break;
                        }
                        lastHash = hash;
                    }

                    /* show message box now */
                    if (i == selectedResultsList.SelectedItems.Count)
                        MessageBox.Show("The files have the same contents.", "Comparison Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("The files do not have the same contents.", "Comparison Complete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                UpdateControls();
            } else {
                DSUtilities.Msg("You must select only two files for content comparison.");
            }
        }

        /* opens the autoselect dialog */
        private void OpenAutoSelect() {
            if (autoSelectDialog == null)
                autoSelectDialog = new DSAutoSelect(this);
            else if (autoSelectDialog.IsDisposed)
                autoSelectDialog = new DSAutoSelect(this);
            autoSelectDialog.Show(this);
        }

        /* launches the docs */
        private void OpenDocumentation() {
            if (documentationDialog == null)
                documentationDialog = new DSDocumentation(this);
            else if (documentationDialog.IsDisposed)
                documentationDialog = new DSDocumentation(this);
            documentationDialog.Show(this);
        }

        /* open containing Directory */
        private void OpenContainingDirectory() {
            if (selectedResultsList.SelectedItems.Count > 1)
                if (MessageBox.Show("Are you sure you want to open the containing directories for " + selectedResultsList.SelectedItems.Count.ToString() + " files/folders?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

            foreach (ListViewItem item in selectedResultsList.SelectedItems) {
                DSComparable comparable = (DSComparable)item.Tag; 
                int pos = comparable.FSI.FullName.LastIndexOf('\\');
                if (pos > 0)
                    DSUtilities.Launch(comparable.FSI.FullName.Substring(0, pos));
                else
                    throw new Exception("Could not open '" + comparable.FSI.FullName.Substring(0, pos) + "'.");
            }
        }

        /* opens the selected matches */
        private void OpenSelectedResults() {
            if (selectedResultsList.SelectedItems.Count > 1)
                if (MessageBox.Show("Are you sure you want to open " + selectedResultsList.SelectedItems.Count.ToString() + " files/folders?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

            foreach (ListViewItem item in selectedResultsList.SelectedItems) {
                DSComparable comparable = (DSComparable)item.Tag;
                DSUtilities.Launch(comparable.FSI.FullName);
            }
        }

        /* move to */
        private void MoveSelectedResultsToBrowse() {
            DirectoryBrowserDialog.Description = "Select a location that you would like DuplicateSearcher to move the selected results to.";
            if (DirectoryBrowserDialog.ShowDialog(this) == DialogResult.OK) {
                /* let user know */
                if (MessageBox.Show("If the files/dirs are large in size, or if many files/dirs are selected, it may take DuplicateSearcher a long time to move them. Please be patient.", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK) {
                    /* release any open crap */
                    ClearDetails();

                    /* iterate over the itesm */
                    foreach (ListViewItem item in selectedResultsList.SelectedItems) {
                        DSComparable comparable = (DSComparable)item.Tag;
                        FileSystemInfo newFSI = null;
                        bool success = false;

                        /* notify user */
                        OverallStatus.Text = "Moving '" + comparable.FSI.Name + "' to '" + DirectoryBrowserDialog.SelectedPath + "'...";
                        Application.DoEvents();

                        /* move the file */
                        if (comparable.FSI is FileInfo) {
                            newFSI = new FileInfo(DirectoryBrowserDialog.SelectedPath + "\\" + comparable.FSI.Name);
                            File.Move(comparable.FSI.FullName, newFSI.FullName);
                            success = true;
                        } else if (comparable.FSI is DirectoryInfo) {
                            newFSI = new DirectoryInfo(DirectoryBrowserDialog.SelectedPath + "\\" + comparable.FSI.Name);
                            success = DSUtilities.MoveFile(comparable.FSI.FullName, newFSI.FullName);
                        }

                        /* ensure we made the move */
                        if (success) {
                            /* set the tags and update */
                            DSComparable newComparable = new DSComparable(newFSI, comparable.Model, comparable.ParentGroup);
                            ListViewItem oldItem = (ListViewItem)comparable.Tag;
                            item.Tag = newComparable;
                            if (oldItem == item) {
                                newComparable.Tag = item;
                            } else {
                                oldItem.Tag = newComparable;
                                newComparable.Tag = oldItem;
                            }

                            /* remove it from the group and add the new item */
                            comparable.ParentGroup.Matches.Remove(comparable);
                            comparable.ParentGroup.Matches.Add(newComparable);
                        }

                        /* update item info */
                        UpdateListViewItem(item);
                    }

                    UpdateControls();
                }
            }
        }

        /* delete results */
        private void DeleteSelectedResults() {
            /* let user know */
            if (MessageBox.Show("Are you sure you wish to permanently delete the selected item(s) from your file system?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes) {
                /* release any open crap */
                ClearDetails();

                /* copy selected items to our own array - not sure if SelectedItems changes when setting isselected to false */
                ListViewItem[] items = new ListViewItem[selectedResultsList.SelectedItems.Count];
                for (int i = 0; i < selectedResultsList.SelectedItems.Count; i++)
                    items[i] = selectedResultsList.SelectedItems[i];

                /* iterate over the itesm */
                for (int i = 0; i < items.Length; i++) {
                    ListViewItem item = items[0];
                    DSComparable comparable = (DSComparable)item.Tag;

                    /* notify user */
                    OverallStatus.Text = "Permanently deleting '" + comparable.FSI.Name + "'...";
                    Application.DoEvents();

                    /* del the shizzle */
                    comparable.FSI.Delete();

                    /* deselect item */
                    item.Selected = false;

                    /* update the shizzle */
                    UpdateListViewItem(item);
                }

                UpdateControls();
            }
        }

        /* recylce results */
        private void RecycleSelectedResults() {
            /* let user know */
            if (MessageBox.Show("If the files/dirs are large in size, or if many files/dirs are selected, it may take DuplicateSearcher a long time to move them to the recycle bin. Please be patient.\r\n\r\nAre you sure you wish to move the selected item(s) to the recycle bin?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes) {
                /* clear any open crap */
                ClearDetails();

                /* copy selected items to our own array - not sure if SelectedItems changes when setting isselected to false */
                ListViewItem[] items = new ListViewItem[selectedResultsList.SelectedItems.Count];
                for (int i = 0; i < selectedResultsList.SelectedItems.Count; i++) 
                    items[i] = selectedResultsList.SelectedItems[i];

                /* iterate over the itesm */
                for (int i = 0; i < items.Length; i++) {
                    ListViewItem item = items[i];
                    DSComparable comparable = (DSComparable)item.Tag;

                    /* notify user */
                    OverallStatus.Text = "Recycling '" + comparable.FSI.Name + "'...";
                    Application.DoEvents();

                    /* recycle the shizzle */
                    DSUtilities.RecycleFile(comparable.FSI.FullName);

                    /* deselect item */
                    item.Selected = false;

                    /* update the shizzle */
                    UpdateListViewItem(item);
                }

                UpdateControls();
            }
        }

        /* refreshes the results */
        private void RefreshResults() {
            OverallStatus.Text = "Refreshing; please wait...";
            Application.DoEvents();
            for (int i = 0; i < selectedResultsList.Items.Count; i++)
                UpdateListViewItem(selectedResultsList.Items[i]);
            UpdateDetails();
            UpdateControls();
        }

        /* adds a search location */
        private void AddSearchLocation() {
            string path = SearchLocationTxt.Text;
            ListViewItem item = null;

            /* show tb */
            DirectoryBrowserDialog.Description = "Select a location that you would like DuplicateSearcher to find duplicates in.";
            DirectoryBrowserDialog.SelectedPath = path;
            if (DirectoryBrowserDialog.ShowDialog(this) == DialogResult.OK) 
                path = DirectoryBrowserDialog.SelectedPath;
            else
                return;

            /* add item */
            item = new ListViewItem(path);
            item.Checked = true;
            SearchLocationsList.Items.Add(item);
            UpdateControls();
        }

        /* remove serach locations */
        private void RemoveSelectedSearchLocations() {
            while (SearchLocationsList.SelectedItems.Count > 0) 
                SearchLocationsList.Items.Remove(SearchLocationsList.SelectedItems[0]);
            
            UpdateControls();
        }
        
        /* saves the criteria */
        private void SaveCriteria() {
            string path = Browse(lastCriteriaFile, "Criteria Files (*.ini)|*.ini|Text Files (*.txt)|*.txt|All Files (*.*)|*.*", false);
            if (path != null) {
                lastCriteriaFile = path;
                LoadModelAndConsoleFromGUI();
                console.SaveCriteria(model, path);
            }
        }

        /* loads the criteria */
        private void LoadCriteria() {
            string path = Browse(lastCriteriaFile, "Criteria Files (*.ini)|*.ini|Text Files (*.txt)|*.txt|All Files (*.*)|*.*", true);
            if (path != null) {
                lastCriteriaFile = path;
                model.ClearInitialSearchPaths();
                console.LoadCriteria(model, path);
                LoadGUIFromModelAndConsole();
            }
        }

        /* returns a list of the match and what it matched to */
        private string GetMatchGroupDetails(DSComparable comparable) {
            string details = "Full Path:\r\n" + comparable.FSI.FullName + "\r\n\r\nMatched To:";
            foreach (DSComparable comp in comparable.ParentGroup.Matches) {
                if (comparable.FSI.FullName.CompareTo(comp.FSI.FullName) != 0)
                    details += "\r\n - " + comp.FSI.FullName;
            }

            return details;
        }

        /* sets the preview for a webbrowser */
        private void SetDetailPreview(FileSystemInfo fsi) {
            string html = null;
            string url = null;

            /* reset disable the fit to window */
            DetailPreview.Tag = null;

            /* get the html or the url */
            if (fsi == null) {
                html = previewHTMLGenerator.DefaultPreviewHTML.FitHTML;
            } else {
                /* check to see if anything is available, and if not, just try to open it and hope for the best */
                if (previewHTMLGenerator.HasHTML(fsi)) {
                    DSHTML htmlObj = previewHTMLGenerator.GetHTML(fsi);
                    if (DetailFitToWindow.Checked)
                        html = htmlObj.FitHTML;
                    else
                        html = htmlObj.NormalHTML;
                } else if (previewHTMLGenerator.ShouldOpen(fsi)) { //the try to open
                    url = fsi.FullName;
                    DetailPreview.Tag = "";//reset the fit to window
                } else {
                    html = previewHTMLGenerator.NotSupportedHTML.FitHTML;
                }
            }

            /* now set the html or the url - ONLY IF THEY ARE DIFFERENT FROM WHAT IS ALREADY SET */
            if (html != null) {
                if (html.CompareTo(previousPreviewHTML) != 0) {
                    previousPreviewHTML = html;
                    previousPreviewURL = "";
                    DetailPreview.Stop();
                    DetailPreview.DocumentText = html;
                }
            } else if (url != null) {
                if (url.CompareTo(previousPreviewURL) != 0) {
                    previousPreviewURL = url;
                    previousPreviewHTML = "";
                    Uri uri = new Uri(url);
                    DetailPreview.Stop();
                    DetailPreview.Navigate(url);
                }
            }
        }

        /* adds all of the drives to the search locations list */
        private void AddAllDrives() {
            SearchLocationsList.Items.Clear();

            DriveInfo[] dis = DriveInfo.GetDrives();
            foreach (DriveInfo di in dis) {
                ListViewItem item = SearchLocationsList.Items.Add(di.RootDirectory.FullName);
                item.Checked = true;
            }
        }

        /* loads the specified builtin criteria */
        private void LoadBuiltinCriteria(string name) {
            /* load */
            model.ClearInitialSearchPaths();  
            console.LoadBuiltinCriteria(model, name);
            LoadGUIFromModelAndConsole();
            SearchForButton.Text = "Search For: " + name.Replace(".ini","");
        }

        /* returns a description of the current criteria */
        private string GetCriteriaDescription() {
            string desc = "DuplicateSearcher will consider _fds_ that meet the following criteria:\r\n";
            int counter = 0;

            /* locations */
            desc += (++counter).ToString() + ". The _fds_ are in the following locations:\r\n";
            foreach (ListViewItem item in SearchLocationsList.CheckedItems) {
                desc += "\t- " + item.Text;
                /* sub dirs */
                if (SearchSubdirectories.Checked)
                    desc += ", including subdirectories";
                desc += "\r\n";
            }

            /* sizes */
            if (MatchFiles.Checked)
                desc += (++counter).ToString() + ". The file size is greater than " + MinFileSize.Value.ToString() + " " + MinFileSizeUnits.Text + " and less than " + MaxFileSize.Value.ToString() + " " + MaxFileSizeUnits.Text + ".\r\n";

            /* filters */
            if (MatchFiles.Checked) {
                if (FileIncludeFilterList.CheckedItems.Count > 0) {
                    desc += (++counter).ToString() + ". Files must pass the following inclusion filters:\r\n";
                    foreach (ListViewItem item in FileIncludeFilterList.CheckedItems)
                        desc += "\t" + item.Text + "\r\n";
                }
                if (FileExcludeFilterList.CheckedItems.Count > 0) {
                    desc += (++counter).ToString() + ". Files must pass the following exclusion filters:\r\n";
                    foreach (ListViewItem item in FileExcludeFilterList.CheckedItems)
                        desc += "\t" + item.Text + "\r\n";
                }
            }
            if (MatchDirectories.Checked) {
                if (DirectoryIncludeFilterList.CheckedItems.Count > 0) {
                    desc += (++counter).ToString() + ". Directories must pass the following inclusion filters:\r\n";
                    foreach (ListViewItem item in DirectoryIncludeFilterList.CheckedItems)
                        desc += "\t" + item.Text + "\r\n";
                }
                if (DirectoryExcludeFilterList.CheckedItems.Count > 0) {
                    desc += (++counter).ToString() + ". Directories must pass the following exclusion filters:\r\n";
                    foreach (ListViewItem item in DirectoryExcludeFilterList.CheckedItems)
                        desc += "\t" + item.Text + "\r\n";
                }
            }

            /* default dirs */
            if (UseDefaultFilters.Checked)
                desc += (++counter).ToString() + ". _FDS_ must pass the default inclusion and exclusion filters.\r\n";

            desc += "\r\nDuplicateSearcher will use the following settings to match _fds_.\r\n";
            counter = 0;

            /* merge dirs */
            if (MergeFilters.Checked)
                desc += (++counter).ToString() + ". File and directory filters are merged, which means any directory include/exclude filters will apply to files, and any file include/exclude filters will apply to directories.\r\n";

            /* match sizes */
            if (MatchSizes.Checked)
                desc += (++counter).ToString() + ". The size of the _fds_ must match.\r\n";

            /* match files to dirs */
            if (MatchFiles.Checked && MatchDirectories.Checked && MatchFilesToDirectories.Checked)
                desc += (++counter).ToString() + ". Files and directories are matched to each other where possible (typically only by name).\r\n";

            /* compare names */
            if (MatchNames.Checked) {
                desc += (++counter).ToString() + ". _FD_ names are matched";
                if (NCModeSoundEx.Checked)
                    desc += " when their SOUNDEX is the same.\r\n";
                else if (NCModeExact.Checked)
                    desc += " when their names are exactly the same.\r\n";
                else
                    desc += ".\r\n";

                if (RemoveNonalpha.Checked) desc += (++counter).ToString() + ". Nonalpha characters are ignored in the _fd_ names before matching.\r\n";
                if (RemoveNumbers.Checked) desc += (++counter).ToString() + ". Number characters are ignored in the _fd_ names before matching.\r\n";
                if (IgnoreExtensions.Checked) desc += (++counter).ToString() + ". The extensions of the _fds_ are ignored before matching.\r\n";
            }

            /* compare contents */
            if (MatchContents.Checked) {
                if (MatchFiles.Checked) {
                    desc += (++counter).ToString() + ". File contents are matched according to ";
                    if (CCModeHeader.Checked) desc += "the first " + HeaderFooterSize.Value.ToString() + " bytes.";
                    if (CCModeAllContents.Checked) desc += "the entire contents.";
                    if (CCModeHeaderAndFooter.Checked) desc += "the first and last " + HeaderFooterSize.Value.ToString() + " bytes.";

                    /* pre load */
                    if (PreloadContent.Checked)
                        desc += " Header and footer contents are preloaded on seperate threads during the search process, which makes comparisons faster.";
                    
                    desc += "\r\n";
                }

                if (MatchDirectories.Checked) {
                    if (CompareDirectoryContents.Checked) {
                        desc += (++counter).ToString() + ". Directory contents are matched according to contained subdirectory names and file names.\r\n";
                    }
                }
            }

            /* match on name or content */
            if (MatchNames.Checked && MatchContents.Checked)
                if (MatchOnNameORContent.Checked)
                    desc += (++counter).ToString() + ". _FDS_ will be considered a match if their content OR their names match.\r\n";
                else
                    desc += (++counter).ToString() + ". _FDS_ will be consider a match if their content AND their names match.\r\n";

            /* search mode */
            if (SearchSubdirectories.Checked)
                if (SearchMode.SelectedIndex == (int)DSSearchModes.BottomUp)
                    desc += (++counter).ToString() + ". _FDS_ will be searched from the deepest directories up to the root of the specified search locations.\r\n";
                else
                    desc += (++counter).ToString() + ". _FDS_ will be searched from the root of the specified search locations down to the deepest sub directory.\r\n";

            /* output file */
            if (UseOutputFile.Checked) {
                if (AppendOutputFile.Checked)
                    desc += (++counter).ToString() + ". Output will be appended to '" + OutputFile.Text + "'.";
                else
                    desc += (++counter).ToString() + ". Output will be written to '" + OutputFile.Text + "'.";
                if (OnlyOutputFile.Checked) desc += " Output will ONLY be directed to the file.";
                desc += "\r\n";
            }

            /* log file */
            if (UseLogFile.Checked) {
                if (AppendLogFile.Checked)
                    desc += (++counter).ToString() + ". Log information will be appended to '" + LogFile.Text + "'.\r\n";
                else
                    desc += (++counter).ToString() + ". Log information will be written to '" + LogFile.Text + "'.\r\n";
            }

            /* show the max threads */
            if (MaxSearchThreads.Value == 0)
                desc += (++counter).ToString() + ". The number of threads used to search for _fds_ will be automatically determined.";
            else
                desc += (++counter).ToString() + ". A maximum of " + MaxSearchThreads.Value.ToString() + " threads will be used to search for _fds_.";

            /* set whether it's files/directories */
            if (MatchDirectories.Checked && MatchFiles.Checked) {
                desc = desc.Replace("_fds_", "files and directories");
                desc = desc.Replace("_fd_", "file and directory");
                desc = desc.Replace("_FDS_", "Files and directories");
                desc = desc.Replace("_FD_", "File and directory");
            } else if (MatchDirectories.Checked) {
                desc = desc.Replace("_fds_", "directories");
                desc = desc.Replace("_fd_", "directory");
                desc = desc.Replace("_FDS_", "Directories");
                desc = desc.Replace("_FD_", "Directory");
            } else if (MatchFiles.Checked) {
                desc = desc.Replace("_fds_", "files");
                desc = desc.Replace("_fd_", "file");
                desc = desc.Replace("_FDS_", "Files");
                desc = desc.Replace("_FD_", "File");
            } else {
                desc = desc.Replace("_fds_", "??");
                desc = desc.Replace("_fd_", "??");
                desc = desc.Replace("_FDS_", "??");
                desc = desc.Replace("_FD_", "??");
            }

            return desc;
        }

        /* loads the last settings from the registry */
        private void LoadLastSettings() {
            string all = DSSettings.GetSetting("LastSettings", "");
            StringReader r = new StringReader(all);
            string lines = "";

            if (all.Length > 0) {
                string line = "";
                while ((line = r.ReadLine()) != null)
                    if (lines.Length > 0)
                        lines += "\n" + line;
                    else
                        lines += line;
                console.LoadCriteria(model, lines.Split(new char[] {'\n'}));
            }
        }

        /* saves the current settings to the registry for next starte up */
        private void SaveLastSettings() {
            LoadModelAndConsoleFromGUI();
            string all = console.GetAllCriteria(model);
            DSSettings.SaveSetting("LastSettings", all);
        }

        /* shows an error and then performs an update */
        private void ShowError(Exception ex) {
            try {
                DSUtilities.Msg(ex);
                UpdateControls();
            } catch { } //if we can't so much as do this, then forget it
        }

        private void SearchForButton_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {

        }
    }
}
