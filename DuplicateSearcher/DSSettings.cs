using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace DuplicateSearcher {
    public class DSSettings {
        private static Dictionary<string, string> fileSettings = null;

        /* loads and saves file settings */
        private static void LoadFileSettings() {
            fileSettings = new Dictionary<string, string>();
            if (File.Exists(DSUtilities.GetSettingsFilePath())) {
                StreamReader sr = new StreamReader(DSUtilities.GetSettingsFilePath());
                string line = "";

                while ((line = sr.ReadLine()) != null) {
                    string[] keyVal = line.Split(new char['=']);
                    if (keyVal.Length == 2)
                        fileSettings.Add(keyVal[0], keyVal[1]);
                }

                sr.Close();
            } 
        }

        private static void SaveFileSettings() {
            StreamWriter sw = new StreamWriter(DSUtilities.GetSettingsFilePath(), false);
            
            foreach (string key in fileSettings.Keys) 
                sw.WriteLine(key + "=" + fileSettings[key]);
            
            sw.Close();
        }

        /* get and save file settings */
        public static string GetFileSetting(string name, string defaultValue) {
            try {
                if (fileSettings == null) LoadFileSettings();
                foreach (string key in fileSettings.Keys)
                    if (key.CompareTo(name) == 0)
                        return fileSettings[name];
                return defaultValue;
            } catch (Exception ex) {
                DSUtilities.Msg(ex);
            }

            return defaultValue;
        }

        /* save file settings */
        public static void SaveFileSetting(string name, string value) {
            try {
                if (fileSettings == null) LoadFileSettings();
                foreach (string key in fileSettings.Keys)
                    if (key.CompareTo(name) == 0) {
                        fileSettings[name] = value;
                        return;
                    }
                fileSettings.Add(name, value);
                SaveFileSettings();
            } catch (Exception ex) {
                DSUtilities.Msg(ex);
            }
        }

        /* get setting value - overridden */
        public static bool GetSetting(string name, bool defaultValue) { return bool.Parse(GetSetting(name, defaultValue.ToString())); }
        public static DateTime GetSetting(string name, DateTime defaultValue) { return DateTime.Parse(GetSetting(name, defaultValue.ToString())); }
        public static int GetSetting(string name, int defaultValue) { return int.Parse(GetSetting(name, defaultValue.ToString())); }
        public static string GetSetting(string name, string defaultValue) { return GetSetting(name, defaultValue, true); }
        public static string GetSetting(string name, string defaultValue, bool useHKCU) {
            string value = defaultValue;

            try {
                RegistryKey softwareKey = null;
                if (useHKCU)
                    softwareKey = Registry.CurrentUser.CreateSubKey("Software");
                else
                    softwareKey = Registry.LocalMachine.CreateSubKey("Software");
                RegistryKey companyKey = softwareKey; //.CreateSubKey(Application.CompanyName);
                RegistryKey appKey = companyKey.CreateSubKey(Application.ProductName);
                value = appKey.GetValue(name, defaultValue).ToString();
                appKey.Close();
                companyKey.Close();
                softwareKey.Close();
            } catch {
                return GetFileSetting(name, value);
            }

            return value;
        }

        /* save setting - overridden */
        public static void SaveSetting(string name, bool value) { SaveSetting(name, value.ToString()); }
        public static void SaveSetting(string name, int value) { SaveSetting(name, value.ToString()); }
        public static void SaveSetting(string name, DateTime value) { SaveSetting(name, value.ToString()); }
        public static void SaveSetting(string name, string value) { SaveSetting(name, value, true); }
        public static void SaveSetting(string name, string value, bool useHKCU) {
            try {
                RegistryKey softwareKey = null;
                if (useHKCU)
                    softwareKey = Registry.CurrentUser.CreateSubKey("Software");
                else
                    softwareKey = Registry.LocalMachine.CreateSubKey("Software");
                RegistryKey companyKey = softwareKey; // softwareKey.CreateSubKey(Application.CompanyName);
                RegistryKey appKey = companyKey.CreateSubKey(Application.ProductName);
                appKey.SetValue(name, value);
                appKey.Close();
                companyKey.Close();
                softwareKey.Close();
            } catch {
                SaveFileSetting(name, value);
            }
        }

        /* get control size and pos */
        public static void GetControlSizeAndPos(Control c) { GetControlSizeAndPos(c, c.Size.Width, c.Size.Height); }
        public static void GetControlSizeAndPos(Control c, int defaultWidth, int defaultHeight) {
            try {
                c.Size = new Size(int.Parse(GetSetting(c.Name + ".Width", defaultWidth.ToString())), int.Parse(GetSetting(c.Name + ".Height", defaultHeight.ToString())));

                int defaultX = ((Screen.PrimaryScreen.WorkingArea.Left + (Screen.PrimaryScreen.WorkingArea.Width / 2)) - (defaultWidth / 2));
                int defaultY = ((Screen.PrimaryScreen.WorkingArea.Top + (Screen.PrimaryScreen.WorkingArea.Height / 2)) - (defaultHeight / 2));
                
                c.Location = new Point(int.Parse(GetSetting(c.Name + ".X", defaultX.ToString())), int.Parse(GetSetting(c.Name + ".Y", defaultY.ToString())));
            } catch (Exception ex) {
                DSUtilities.Msg(ex);
            }
        }

        /* save control size and pos */
        public static void SaveControlSizeAndPos(Control c) {
            try {
                SaveSetting(c.Name + ".Height", c.Size.Height.ToString());
                SaveSetting(c.Name + ".Width", c.Size.Width.ToString());
                SaveSetting(c.Name + ".X", c.Location.X.ToString());
                SaveSetting(c.Name + ".Y", c.Location.Y.ToString());
            } catch (Exception ex) {
                DSUtilities.Msg(ex);
            }
        }

        /* gets the control val */
        public static void GetControl(Control c) {
            if (c is CheckBox) {
                CheckBox cb = (CheckBox)c;
                cb.Checked = bool.Parse(GetSetting(cb.Name, cb.Checked.ToString()));
            } else if (c is TextBox) {
                TextBox tb = (TextBox)c;
                tb.Text = GetSetting(tb.Name, tb.Text);
            } else
                throw new Exception("Control not supported for getting and saving settings values.");
        }

        /* save the control val */
        public static void SaveControl(Control c) {
            if (c is CheckBox) {
                CheckBox cb = (CheckBox)c;
                SaveSetting(cb.Name, cb.Checked.ToString());
            } else if (c is TextBox) {
                TextBox tb = (TextBox)c;
                SaveSetting(tb.Name, tb.Text);
            } else
                throw new Exception("Control not supported for getting and saving settings values.");
        }

        /* get window state */
        public static FormWindowState GetWindowState(Form frm) {
            try {
                return (FormWindowState)GetSetting(frm.Name + ".State", (int)frm.WindowState);
            } catch {
                return frm.WindowState;
            }
        }

        /* save window state */
        public static void SaveWindowState(Form frm) {
            try {
                SaveSetting(frm.Name + ".State", ((int)frm.WindowState).ToString());
            } catch (Exception ex) {
                DSUtilities.Msg(ex);
            }
        }
    }
}
