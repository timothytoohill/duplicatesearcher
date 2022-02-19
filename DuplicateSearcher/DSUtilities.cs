using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Reflection;
using System.Diagnostics;

namespace DuplicateSearcher {
    public class DSUtilities {
        //constants
        /* for shgetfileinfo */
        private const uint SHGFI_ICON = 0x100;
        private const uint SHGFI_LARGEICON = 0x0;
        private const uint SHGFI_SMALLICON = 0x1;
        private const uint SHGFI_USEFILEATTRIBUTES = 0x000000010;     // use passed dwFileAttribute
        private const uint SHGFI_OPENICON = 0x000000002;     // get open icon
        private const int MAX_PATH = 256;
        private const uint SHGFI_LINKOVERLAY = 0x000008000;     // put a link overlay on icon
        private const uint FILE_ATTRIBUTE_NORMAL = 0x00000080;
        private const uint FILE_ATTRIBUTE_DIRECTORY = 0x00000010;
        private const uint ICC_USEREX_CLASSES = 0x200;
        private const int LVM_FIRST = 0x1000;
        private const int LVM_SETIMAGELIST = (LVM_FIRST + 3);
        private const int LVSIL_NORMAL = 0;
        private const int LVSIL_SMALL = 1;
        private const int SHGFI_SYSICONINDEX = 0x000004000;
        private const uint SHGFI_TYPENAME = 0x400;
        private const int FO_MOVE = 0x0001;
        private const int FO_COPY =                   0x0002;
        private const int FO_DELETE =                 0x0003;
        private const int FO_RENAME =                 0x0004;
        private const int FOF_MULTIDESTFILES =        0x0001;
        private const int FOF_CONFIRMMOUSE    =       0x0002;
        private const int FOF_SILENT           =      0x0004;  // don't display progress UI (confirm prompts may be displayed still)
        private const int FOF_RENAMEONCOLLISION =     0x0008;  // automatically rename the source files to avoid the collisions
        private const int FOF_NOCONFIRMATION     =    0x0010;  // don't display confirmation UI, assume "yes" for cases that can be bypassed, "no" for those that can not
        private const int FOF_WANTMAPPINGHANDLE   =   0x0020;  // Fill in SHFILEOPSTRUCT.hNameMappings
        private const int FOF_ALLOWUNDO            =  0x0040;  // enable undo including Recycle behavior for IFileOperation::Delete()
        private const int FOF_WANTNUKEWARNING = 0x4000;  // during delete operation, warn if nuking instead of recycling (partially overrides FOF_NOCONFIRMATION)
        private const int FOF_NOCONFIRMMKDIR = 0x0200;  // don't dispplay confirmatino UI before making any needed directories, assume "Yes" in these cases


        //structs
        /* structure for icons */
        [StructLayout(LayoutKind.Sequential)]
        public struct SHFILEINFO {
            public const int NAMESIZE = 80;
            public IntPtr hIcon;
            public int iIcon;
            public uint dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NAMESIZE)]
            public string szTypeName;
        };

        /* structure for file ops */
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto, Pack = 1)]
        public struct SHFILEOPSTRUCT {
            public IntPtr hwnd;
            [MarshalAs(UnmanagedType.U4)]
            public int wFunc;
            public string pFrom;
            public string pTo;
            public short fFlags;
            [MarshalAs(UnmanagedType.Bool)]
            public bool fAnyOperationsAborted;
            public IntPtr hNameMappings;
            public string lpszProgressTitle;
        } 

        /* structure for enabling visual styles */
        [StructLayout(LayoutKind.Sequential)]
        public struct StructInitCommonControlsEx {
            public long lngSize;
            public long lngICC;
        }

        //private static members
        private static Random randomNumberGenerator = new Random();
        private static string appPath = null;
        private static string bestOutputPath = null;

        //private methods
        /* perform file op */
        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        private static extern int SHFileOperation(ref SHFILEOPSTRUCT FileOp);

        /* gets a file info */
        [DllImport("Shell32.dll", CharSet=CharSet.Ansi)]
        private static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, int cbFileInfo, uint uFlags);

        /* destroys icon */
        [DllImport("User32.dll")]
        private static extern int DestroyIcon(IntPtr hIcon);

        /* inits visual styles */
        [DllImport("comctl32.dll")]
        private static extern bool InitCommonControlsEx(StructInitCommonControlsEx structInit);

        /* send message */
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SendMessage(IntPtr hWnd, int wMsg, int wParam, IntPtr lParam);


        //public methods
        /* set the listviews image list */
        public static int SetLargeSystemImageList(ListView lv) {
            IntPtr ipLargeSystemImageList = GetLargeSystemImageList();
            /* Associate the System image list with the ListView */
            return SendMessage(lv.Handle, LVM_SETIMAGELIST, LVSIL_NORMAL, ipLargeSystemImageList);
        }

        /* sets the small listviews image list */
        public static int SetSmallSystemImageList(ListView lv) {
            IntPtr ipSmallSystemImageList = GetSmallSystemImageList();
            /* Associate the System image list with the ListView */
            return SendMessage(lv.Handle, LVM_SETIMAGELIST, LVSIL_SMALL, ipSmallSystemImageList);
        }

        /* gets the large icon system imarege list */
        public static IntPtr GetLargeSystemImageList() {
            uint uFlags = SHGFI_SYSICONINDEX | SHGFI_LARGEICON | SHGFI_USEFILEATTRIBUTES;

            SHFILEINFO shfi = new SHFILEINFO();
            IntPtr ipLargeSystemImageList = SHGetFileInfo(@"c:\Temp\*.txt", 0, ref shfi, Marshal.SizeOf(typeof(SHFILEINFO)), uFlags);

            if (shfi.hIcon != IntPtr.Zero)
                DestroyIcon(shfi.hIcon);

            return ipLargeSystemImageList;
        }

        /* gets the small system icon image list */
        public static IntPtr GetSmallSystemImageList() {
            uint uFlags = SHGFI_SYSICONINDEX | SHGFI_SMALLICON | SHGFI_USEFILEATTRIBUTES;

            SHFILEINFO shfi = new SHFILEINFO();
            IntPtr ipSmallSystemImageList = SHGetFileInfo(@"c:\Temp\*.txt", 0, ref shfi, Marshal.SizeOf(typeof(SHFILEINFO)), uFlags);

            if (shfi.hIcon != IntPtr.Zero)
                DestroyIcon(shfi.hIcon);

            return ipSmallSystemImageList;
        }

        /* returns the index into the system icon list for the file */
        public static int GetFileIconIndex(string file, bool smallIcon, bool folderIcon) {
            uint uFlags = SHGFI_SYSICONINDEX | SHGFI_USEFILEATTRIBUTES;
            uint attrib = 0;
            if (smallIcon) uFlags |= SHGFI_SMALLICON; else uFlags |= SHGFI_LARGEICON;
            if (folderIcon) attrib = FILE_ATTRIBUTE_DIRECTORY;

            SHFILEINFO shfi = new SHFILEINFO();
            SHGetFileInfo(file, attrib, ref shfi, Marshal.SizeOf(typeof(SHFILEINFO)), uFlags);

            if (shfi.hIcon != IntPtr.Zero) {
                DestroyIcon(shfi.hIcon);
            }

            return shfi.iIcon;
        }

        /* gets the icon for a file */
        public static System.Drawing.Icon GetFileIcon(string name, bool smallIcon, bool folderIcon, bool openFolder, bool linkOverlay) {
            SHFILEINFO shfi = new SHFILEINFO();
            uint flags = SHGFI_ICON | SHGFI_USEFILEATTRIBUTES;
            uint attrib = 0;

            if (true == linkOverlay) flags += SHGFI_LINKOVERLAY;
            if (folderIcon) {
                attrib = FILE_ATTRIBUTE_DIRECTORY;
                if (openFolder)
                    flags += SHGFI_OPENICON;
            } else {
                attrib = FILE_ATTRIBUTE_NORMAL;
            }

            /* Check the size specified for return. */
            if (smallIcon) flags += SHGFI_SMALLICON; else flags += SHGFI_LARGEICON;

            SHGetFileInfo(name, attrib, ref shfi, System.Runtime.InteropServices.Marshal.SizeOf(shfi), flags);

            // Copy (clone) the returned icon to a new object, thus allowing us to clean-up properly
            System.Drawing.Icon icon = (System.Drawing.Icon)System.Drawing.Icon.FromHandle(shfi.hIcon).Clone();
            DestroyIcon(shfi.hIcon);		// Cleanup

            return icon;
        }

        /* gets the type info of a file */
        public static string GetFileTypeInfo(string name, bool isDirectory, bool includeMIME) {
            string description = "";
            string mime = "";

            if (isDirectory) {
                description = "Directory";
            } else {
                string ext = System.IO.Path.GetExtension(name).ToLower();

                if (ext.Length > 0) {
                    Microsoft.Win32.RegistryKey regKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);

                    if (regKey != null) {
                        /* try to get the mime */
                        if ((regKey.GetValue("Content Type") != null) && (includeMIME)) {
                            mime = " (" + regKey.GetValue("Content Type").ToString() + ")";
                        }

                        /* now try to get the desc */
                        if (regKey.GetValue("") != null) {
                            Microsoft.Win32.RegistryKey descKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(regKey.GetValue("").ToString());
                            if (descKey != null) {
                                if (descKey.GetValue("") != null)
                                    description = descKey.GetValue("").ToString();
                                descKey.Close();
                            }
                        }

                        regKey.Close();
                    } else {
                        description = "unknown";
                    }
                } else {
                    description = "None";
                }
            }
 
            return description + mime;
        }

        /* gets the type info of a file */
        public static string GetFileMIMEInfo(string name) {
            string description = "";
            string ext = System.IO.Path.GetExtension(name).ToLower();

            /* checks the extension */
            if (ext.Length > 0) {
                Microsoft.Win32.RegistryKey regKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);

                if (regKey != null) {
                    /* try to get the mime */
                    if (regKey.GetValue("Content Type") != null) {
                        description = regKey.GetValue("Content Type").ToString();
                    } 

                    regKey.Close();
                }
            } 

            return description;
        }

        /* mvoe a file to the recycle bin */
        public static void RecycleFile(string path) {
            SHFILEOPSTRUCT shf = new SHFILEOPSTRUCT();
            shf.wFunc = FO_DELETE;
            shf.fFlags = FOF_ALLOWUNDO | FOF_NOCONFIRMATION | FOF_WANTNUKEWARNING | FOF_SILENT;
            shf.pFrom = path;
            shf.lpszProgressTitle = "Recycling '" + path + "'...";
            SHFileOperation(ref shf);
        }

        /* move a file or folder */
        public static bool MoveFile(string from, string to) {
            SHFILEOPSTRUCT shf = new SHFILEOPSTRUCT();
            shf.wFunc = FO_MOVE;
            shf.fFlags = FOF_NOCONFIRMATION | FOF_RENAMEONCOLLISION | FOF_NOCONFIRMMKDIR | FOF_SILENT;
            shf.pFrom = from;
            shf.pTo = to;
            shf.lpszProgressTitle = "Moving...";
            SHFileOperation(ref shf);

            return shf.fAnyOperationsAborted;
        }

        /* disables/enables all controls within a controls collection except the one passed in */
        public static void EnableDisableAllExcept(Control exceptThisControl, bool enableFlag, Control.ControlCollection controls) {
            /* iterate over all and set the enabled flag */
            foreach (Control c in controls)
                if (c != exceptThisControl)
                    c.Enabled = enableFlag;
        }

        /* returns/sets a numericupdown/combo box for file size info; return value is always in bytes  */
        public static decimal GetFileSizeControlValue(NumericUpDown nud, ComboBox cb) {
            decimal multiplier = 1;

            /* get the multiplier */
            for (int i = 0; i < cb.SelectedIndex; i++)
                multiplier *= 1000;

            return nud.Value * multiplier;
        }

        /* sets a file size control value (see above) */
        public static void SetFileSizeControlValue(NumericUpDown nud, ComboBox cb, decimal setValue) {
            long multiplier = 1;
            int power = 0;

            /* find out which it is and set the multiplier */
            char[] data = setValue.ToString().ToCharArray();
            int counter = 0;
            for (int i = (data.Length - 1); i > -1; i--) {
                if (data[i] == '0') {
                    counter++;
                    if (counter == 3) {
                        multiplier *= 1000;
                        counter = 0;
                        power++;
                    }
                } else {
                    break;
                }
            }

            /* set the control values */
            nud.Value = (setValue / multiplier);
            cb.SelectedIndex = power;
        }

        /* shows an error with the message box */
        public static void Msg(Exception ex) {
            Msg(ex.Message, "Issue/Caveat");
        }

        /* shows a message box */
        public static void Msg(string message) { Msg(message, "DuplicateSearcher"); }
        public static void Msg(string message, string caption) {
            DSDebug.PrintLine(caption + ": " + message);
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /* conditional return */
        public static object IIF(bool condition, object valWhenTrue, object valWhenFalse) {
            if (condition)
                return valWhenTrue;
            else
                return valWhenFalse;
        }

        /* modifies a file/dir name for comparison; removeNonAlpha will take out nonalpha chars; maxRepeatCharCount will remove chars that repeat for that many times */
        public static string CustomProcessFileName(string name, bool removeNonAlpha, bool removeNumbers, int maxRepeatCharCount) {
            string retStr = name;
            StringBuilder sb = new StringBuilder();

            /* check flags and exit if nothing to be done - try to optimize by putting all operations in one loop */
            if ((removeNonAlpha) || (maxRepeatCharCount != 0) || (removeNumbers)) {
                char[] nameArray = name.ToCharArray();
                int len = nameArray.Length;

                /* iterate over each char */
                for (int i = 0; i < len; i++) {
                    char c = nameArray[i];

                    if (removeNonAlpha && (!removeNumbers)) {
                        if (char.IsLetterOrDigit(c))
                            sb.Append(c);
                    } else if (removeNonAlpha && removeNumbers) {
                        if (char.IsLetter(c))
                            sb.Append(c);
                    } else if ((!removeNonAlpha) && removeNumbers) {
                        if (!char.IsDigit(c))
                            sb.Append(c);
                    } else {
                        sb.Append(c);
                    }
                }

                /* set our return value */
                retStr = sb.ToString();
            }

            return retStr;
        }

        /* computes the header for a given file/dir */
        public static string GetHeader(DSComparable comparable, int byteCount) {
            string retVal = "";

            /* catch access denied */
            try {
                if (comparable.FSI is FileInfo) {
                    FileInfo fi = (FileInfo)comparable.FSI;

                    /* ensure we are not reading too much */
                    if (byteCount > fi.Length)
                        byteCount = Convert.ToInt32(fi.Length);

                    /* ensure the file was not zero length */
                    if (byteCount > 0) {
                        /* open for read - error for access denied probably thrown here */
                        FileStream fs = fi.OpenRead();
                        byte[] data = new byte[byteCount];

                        /* ensure we were able to read the whole header, and if so, convert to base64 */
                        int totalRead = 0;
                        while (totalRead < byteCount)
                            totalRead += fs.Read(data, totalRead, (byteCount - totalRead));

                        /* convert to b64 */
                        retVal += Convert.ToBase64String(data);

                        /* close */
                        fs.Close();
                    }
                } else if (comparable.FSI is DirectoryInfo) {
                    retVal = GetHash(comparable, true);
                } else {
                }
            } catch { } //assume it's an access denied error

            return retVal;
        }

        /* computes the footer for a given file/dir */
        public static string GetFooter(DSComparable comparable, int byteCount, int headerByteCount) {
            string retVal = "";

            /* catch access denied */
            try {
                if (comparable.FSI is FileInfo) {
                    FileInfo fi = (FileInfo)comparable.FSI;

                    /* ensure we are not reading too much */
                    if ((byteCount + headerByteCount) > fi.Length)
                        byteCount = (Convert.ToInt32(fi.Length) - headerByteCount);

                    /* ensure the file was not zero length */
                    if (byteCount > 0) {
                        /* open for read - error for access denied probably thrown here */
                        FileStream fs = fi.OpenRead();
                        byte[] data = new byte[byteCount];

                        /* seek to end */
                        fs.Seek((byteCount * -1), SeekOrigin.End);

                        /* ensure we were able to read the whole footer, and if so, convert to base64 */
                        int totalRead = 0;
                        while (totalRead < byteCount)
                            totalRead += fs.Read(data, totalRead, (byteCount - totalRead));

                        /* conver to b64 */
                        retVal += Convert.ToBase64String(data);

                        /* close */
                        fs.Close();
                    }
                } else if (comparable.FSI is DirectoryInfo) {
                    //nothing
                } else {
                    //nothing
                }
            } catch { } //assume it's an access denied error

            return retVal;
        }

        /* computes the hash for a given file/dir */
        public static string GetHash(DSComparable comparable) { return GetHash(comparable, false); }
        public static string GetHash(DSComparable comparable, bool computeForDir) {
            string retVal = "";
            SHA1Managed hasher = new SHA1Managed();
            byte[] hash = null;

            /* catch access denied */
            try {
                /* for file, read whole thing */
                if (comparable.FSI is FileInfo) {
                    FileInfo fi = (FileInfo)comparable.FSI;
                    /* open for read - error for access denied probably thrown here */
                    FileStream fs = fi.OpenRead();
                    hash = hasher.ComputeHash(fs);
                    /* close shit */
                    fs.Close();
                } else if (comparable.FSI is DirectoryInfo) {
                    /* if we are to compute the hash for the dir contents */
                    if (computeForDir) {
                        string compiledContents = "";

                        /* check to ensure there are contents */
                        if ((comparable.FileArray.Length == 0) && (comparable.DirectoryArray.Length == 0)) {
                            compiledContents = "EmptyHash"; //so that we can distinguis from those that throw and access denied error
                        } else {
                            /* sort the files and dirs */
                            comparable.LoadSortedFiles();
                            comparable.LoadSortedDirectories();

                            /* concat the names */
                            for (int i = 0; i < comparable.SortedDirectories.Keys.Count; i++)
                                compiledContents += comparable.SortedDirectories.Keys[i];
                            for (int i = 0; i < comparable.SortedFiles.Keys.Count; i++)
                                compiledContents += comparable.SortedFiles.Keys[i];
                        }

                        /* produce the hash */
                        hash = hasher.ComputeHash(Encoding.UTF8.GetBytes(compiledContents));
                    }
                } else {
                }
            } catch { } //assume it's an access denied error

            /* convert to b64 */
            if (hash != null)
                retVal += Convert.ToBase64String(hash);

            return retVal;
        }

        /* returns the string file/dir size */
        public static string GetSizeString(DSComparable comparable) {
            string retVal = "";

            /* catch access denied */
            try {
                /* could be expensive to get the file and dir count like this */
                if (comparable.FSI is FileInfo) {
                    FileInfo fi = (FileInfo)comparable.FSI;
                    retVal = fi.Length.ToString();
                } else if (comparable.FSI is DirectoryInfo) {
                    retVal = "F:" + comparable.FileArray.LongLength.ToString() + "-D:" + comparable.DirectoryArray.LongLength.ToString();
                } else {
                    retVal = "";
                }
            } catch { } //assume it's access denied

            return retVal;
        }

        /* returns a contatenation with the seperator */
        public static string DSConcat(string seperator, string[] values) {
            string retVal = "";
            string sep = "";

            for (int i = 0; i < values.Length; i++) {
                if (values[i].Length > 0) {
                    retVal += sep + values[i];
                    sep = seperator;
                }
            }

            return retVal;
        }

        /* centers a control */
        public static void CenterControlOnParent(Control control, Control parent) {
            control.Location = new Point(((parent.Location.X + (parent.Size.Width / 2)) - (control.Size.Width / 2)), ((parent.Location.Y + (parent.Size.Height / 2)) - (control.Size.Height / 2)));
        }

        /* tests if a number is prime */
        public static bool IsPrime(int candidate) {
            // Test whether the parameter is a prime number.
            if ((candidate & 1) == 0) {
                if (candidate == 2) {
                    return true;
                } else {
                    return false;
                }
            }

            for (int i = 3; (i * i) <= candidate; i += 2) {
                if ((candidate % i) == 0) {
                    return false;
                }
            }
            
            return candidate != 1;
        }

        /* returns an embedded resource as a string */
        public static string GetEmbeddedResourceString(string resourcePath) {
            Assembly a = Assembly.GetExecutingAssembly();
            Stream s = a.GetManifestResourceStream(Application.ProductName + "." + resourcePath);
            string all = "";
            if (s == null) {
                throw new Exception("Unable to extract resource: " + resourcePath + "; could not instantiate read stream.");
            } else {
                StreamReader sr = new StreamReader(s);
                all = sr.ReadToEnd();
                sr.Close();
                s.Close();
            }

            return all;
        }

        /* fires the link pointed to by a linklabel */
        public static void HandleLinkLabelClicked(object sender) {
            LinkLabel ll = (LinkLabel)sender;
            Launch(ll.Text);
        }

        /* returns a random number */
        public static int GetRandomNumber() {
            return randomNumberGenerator.Next();
        }

        /* launches a link or file or whatever */
        public static int Launch(string whatToLaunch) { return Launch(whatToLaunch, null); }
        public static int Launch(string whatToLaunch, string parameters) {
            Process p = null;
            if (parameters == null)
                p = System.Diagnostics.Process.Start(whatToLaunch);
            else
                p = System.Diagnostics.Process.Start(whatToLaunch, parameters);

            if (p != null)
                return p.Id;

            return -1;
        }
    
        /* recursively delete a dir */
        public static void DeleteDirectoryRecursively(string dirpath) {
            string[] ficheros = Directory.GetFiles(dirpath);
            foreach (string fichero in ficheros) File.Delete(fichero);
            string[] directorios = Directory.GetDirectories(dirpath);
            foreach (string directorio in directorios) {
                DeleteDirectoryRecursively(directorio);
            }
            Directory.Delete(dirpath);
        }

        /* returns the settings file path */
        public static string GetSettingsFilePath() {
            string path = GetBestWritableOutputPath();
            path += "\\DSSettings.ini";
            return path;
        }

        /* returns the current application's directory */
        public static string GetApplicationPath() {
            if (appPath == null) {
                string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
                FileInfo fi = new FileInfo(path);
                path = fi.DirectoryName;

                appPath = path;
            }

            return appPath;
        }

        /* returns a path that can be used for reading and writing */
        public static string GetBestWritableOutputPath() {
            if (bestOutputPath == null) {
                if (IsDirectoryAccessible(GetApplicationPath())) {
                    bestOutputPath = GetApplicationPath();
                } else if (IsDirectoryAccessible(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData))) {
                    bestOutputPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                } else {
                     bestOutputPath = System.IO.Path.GetTempPath();
                }
            }

            return bestOutputPath;
        }

        /* checks to see if a directory is writable and readable */
        public static bool IsDirectoryAccessible(string path) {
            DirectoryInfo di = new DirectoryInfo(path);
            string testFileName = di.FullName + "\\" + GetRandomNumber().ToString() + ".txt";
            string testDirName = GetRandomNumber().ToString();
            StreamWriter sw = null;
            StreamReader sr = null;
            bool isAccessible = true;

            /* try read and write and delete */
            try {
                /* test write */
                sw = File.CreateText(testFileName);
                sw.WriteLine(testFileName);
                sw.Close(); sw = null;

                /* test read */
                sr = File.OpenText(testFileName);
                if (sr.ReadLine().Equals(testFileName)) {
                } else {
                    isAccessible = false;
                }
                sr.Close(); sr = null;
            } catch {
                isAccessible = false;
            } 

            /* try to do the cleanup */
            try {
                if (sw != null) sw.Close();
                if (sr != null) sr.Close();
            } catch { }

            /* and finally delete if it exists */
            try {
                /* and test delete */
                File.Delete(testFileName);
            } catch {
                isAccessible = false;
            }

            return isAccessible;
        }
        
        /* copies from one dir to another */
        public static void CopyDirectory(string Src, string Dst, bool overwrite) {
            String[] Files;

            if (Dst[Dst.Length - 1] != Path.DirectorySeparatorChar)
                Dst += Path.DirectorySeparatorChar;

            if (!Directory.Exists(Dst)) 
                Directory.CreateDirectory(Dst);

            Files = Directory.GetFileSystemEntries(Src);

            foreach (string Element in Files) {
                // Sub directories
                if (Directory.Exists(Element))
                    CopyDirectory(Element, Dst + Path.GetFileName(Element), overwrite);
                else //files
                    File.Copy(Element, Dst + Path.GetFileName(Element), overwrite);
            }
        }
    }
}
