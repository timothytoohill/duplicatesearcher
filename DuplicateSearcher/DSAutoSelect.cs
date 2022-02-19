using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DuplicateSearcher {
    public partial class DSAutoSelect : Form {
        private DSGUI parent = null;
        private bool isRunning = false;

        /* construct */
        public DSAutoSelect(DSGUI parent) {
            InitializeComponent();

            /* set parent */
            this.parent = parent;

            /* load origs */
            string origs = DSSettings.GetSetting(Name + ".OriginalsLocations", "");
            if (origs.Length > 0) {
                string[] ors = origs.Split(';');
                foreach (string x in ors) {
                    ListViewItem item = OriginalsLocationsList.Items.Add(x);
                    item.Checked = true;
                }
            }

            /* first set default, then load pos */
            DSUtilities.CenterControlOnParent(this, parent);
            DSSettings.GetControlSizeAndPos(this);
        }

        /* selects all listview items related to the comparables in the group, except those belonging to the given directory */
        private void SelectAllButOriginals(DSMatchGroup group) {
            /* iterate over the comparables in the group */
            for (int i = 0; i < group.Matches.Count; i++) {
                DSComparable comp = group.Matches[i];

                /* see if we need to ignore dirs */
                if ((!IgnoreDirectories.Checked) || (!(comp.FSI is DirectoryInfo))) {
                    string cpath = comp.FSI.FullName.ToUpper();

                    /* get the item inquest and select if not an original */
                    if (comp.Tag is ListViewItem) {
                        ListViewItem item = (ListViewItem)comp.Tag;
                        
                        /* iterate over every original and determine if selection shoudl be made */
                        bool select = true;
                        for (int y = 0; y < OriginalsLocationsList.CheckedItems.Count; y++) {
                            string path = OriginalsLocationsList.CheckedItems[y].Text.ToUpper();
                            if (cpath.IndexOf(path) == 0) {
                                select = false;
                                break;
                            }
                        }

                        item.Selected = select;
                    }
                }
            }
        }

        /* actually performs the autoselection */
        public void AutoSelect() {
            if (isRunning) {
                isRunning = false;
            } else {
                parent.IsAutoSelecting = true;
                isRunning = true;
                PerformSelectionButton.Text = "Stop Selecting";
                
                /* clear all selections */
                StatusLabel.Text = "Clearing selections...";
                Application.DoEvents();
                while (parent.SelectedResultsList.SelectedItems.Count > 0)
                    parent.SelectedResultsList.SelectedItems[0].Selected = false;

                /* use a dictionary to determine if it has already been looked at */
                Dictionary<ListViewItem, Object> doneItems = new Dictionary<ListViewItem, object>();

                /* iterate over every item and perform selections */
                for (int i = 0; ((i < parent.SelectedResultsList.Items.Count) && (isRunning)); i++) {
                    ListViewItem currentItem = parent.SelectedResultsList.Items[i];

                    /* update the status */
                    StatusLabel.Text = "Performing auto selection... " + i.ToString() + "/" + parent.SelectedResultsList.Items.Count.ToString();

                    /* allow for control updates */
                    Application.DoEvents();
                
                    /* ensure we have not looked at it already */
                    if (doneItems.ContainsKey(currentItem)) {
                        //do something?
                    } else {
                        /* now get the item's group and iterate over all of the comparables within */
                        DSComparable itemComparable = (DSComparable)currentItem.Tag;
                        DSMatchGroup group = itemComparable.ParentGroup;

                        /* check to see if tehre are any to compare */
                        if (group.Matches.Count > 0) {
                            /* check to see if we are using original locations */
                            if (OriginalsLocationsList.CheckedItems.Count > 0) {
                                for (int c = 0; c < OriginalsLocationsList.CheckedItems.Count; c++) {
                                    ListViewItem origItem = OriginalsLocationsList.CheckedItems[c];
                                    SelectAllButOriginals(group);
                                }
                            }

                            /* declare vars for the biggest and bestest */
                            DSComparable latest = null;
                            DSComparable largest = null;

                            /* begin a loop to iterate over the group's comparables looking for the longest, or latest file - in the least we need to add all comparables that have a listitem as their tag to the doneItems dictionary so that they are not looked at again */
                            for (int y = 0; y < group.Matches.Count; y++) {
                                DSComparable comparable = group.Matches[y];

                                /* ensure it has a listview item and move on */
                                if (comparable.Tag is ListViewItem) {
                                    ListViewItem item = (ListViewItem)comparable.Tag;

                                    /* add the item to the list so that we do not compare it again */
                                    doneItems.Add(item, null);

                                    /* ensure it is not already selected */
                                    if (!item.Selected) {
                                        /* ensure we are not comparing dirs when ignoredirecotries */
                                        if ((!IgnoreDirectories.Checked) || (!(comparable.FSI is DirectoryInfo))) {
                                            /* compare sizes */
                                            if (Largest.Checked) {
                                                try {
                                                    if (largest == null) {
                                                        largest = comparable;
                                                    } else {
                                                        if (comparable.GetSizeLong() >= largest.GetSizeLong()) {
                                                            ListViewItem oldItem = (ListViewItem)largest.Tag;
                                                            oldItem.Selected = true;
                                                            largest = comparable;
                                                            item.Selected = false;
                                                        } else {
                                                            item.Selected = true;
                                                        }
                                                    }
                                                } catch { } //assume access denied
                                            }

                                            /* compare dates */
                                            if (LastModified.Checked) {
                                                if (latest == null) {
                                                    latest = comparable;
                                                } else {
                                                    if (comparable.FSI.LastWriteTime.CompareTo(latest.FSI.LastWriteTime) >= 0) {
                                                        ListViewItem oldItem = (ListViewItem)latest.Tag;
                                                        oldItem.Selected = true;
                                                        latest = comparable;
                                                        item.Selected = false;
                                                    } else {
                                                        item.Selected = true;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                PerformSelectionButton.Text = "Perform Selection";
                StatusLabel.Text = "Ready.";

                parent.IsAutoSelecting = false;
                parent.Focus();
                parent.SelectedResultsList.Focus();
                isRunning = false;
            }
        }

        /* saves to the registry */
        private void SaveOriginalsLocations() {
            string all = "";
            foreach (ListViewItem item in OriginalsLocationsList.CheckedItems)
                if (all.Length > 0)
                    all += ";" + item.Text;
                else
                    all += item.Text;
            DSSettings.SaveSetting(Name + ".OriginalsLocations", all);
        }

        /* adds an originals location */
        private void AddOriginalsLocation() {
            ListViewItem item = null;
            DirectoryBrowserDialog.Description = "Select a location that you would like DuplicateSearcher to find duplicates in.";
            if (DirectoryBrowserDialog.ShowDialog(this) == DialogResult.OK) {
                item = new ListViewItem(DirectoryBrowserDialog.SelectedPath);
                item.Checked = true;
                OriginalsLocationsList.Items.Add(item);
            }
        }

        /* remove serach locations */
        private void RemoveSelectedOriginalsLocations() {
            while (OriginalsLocationsList.SelectedItems.Count > 0)
                OriginalsLocationsList.Items.Remove(OriginalsLocationsList.SelectedItems[0]);
        }

        /* add orig */
        private void AddOriginalsLocationButton_Click(object sender, EventArgs e) {
            try {
                AddOriginalsLocation();
            } catch (Exception ex) {
                DSUtilities.Msg(ex);
            }
        }

        /* remove */
        private void RemoveOriginalsLocationButton_Click(object sender, EventArgs e) {
            try {
                RemoveSelectedOriginalsLocations();
            } catch (Exception ex) {
                DSUtilities.Msg(ex);
            }
        }

        /* go */
        private void PerformSelectionButton_Click(object sender, EventArgs e) {
            try {
                AutoSelect();
            } catch (Exception ex) {
                DSUtilities.Msg(ex);
            }
        }

        /* perform close */
        private void CloseButton_Click(object sender, EventArgs e) {
            try {
                SaveOriginalsLocations();
                Hide();
            } catch (Exception ex) {
                DSUtilities.Msg(ex);
            }
        }

        /* only hide */
        private void DSAutoSelect_FormClosing(object sender, FormClosingEventArgs e) {
            try {
                if (e.CloseReason == CloseReason.UserClosing) {
                    SaveOriginalsLocations();
                    e.Cancel = true;
                    Hide();
                }
            } catch (Exception ex) {
                DSUtilities.Msg(ex);
            }
        }

        /* throw in the tb */
        private void OriginalsLocationsList_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e) {
            try {
                OriginalsLocationTxt.Text = e.Item.Text;
            } catch (Exception ex) {
                DSUtilities.Msg(ex);
            }
        }
    }
}
