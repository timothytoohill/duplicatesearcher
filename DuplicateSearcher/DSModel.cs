using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections.Specialized;
using System.Collections;
using System.Threading;

namespace DuplicateSearcher {
    //enums
    /* all of the types of searches that can be performed */
    public enum DSSearchModes {
        TopDown = 0,
        BottomUp = 1,
    }

    /* all of the ways that a filename can be compared */
    public enum DSNameComparisonMode {
        None = 0,
        Exact = 1,
        SoundEx = 2,
    }

    /* all of the file content comparison modes */
    public enum DSContentComparisonMode {
        None = 0,
        Full = 1, //compares all contents
        Header = 2, //compares header
        HeaderAndFooter = 3, //compares header and footer
    }


    //classes
    /* an actual match found by the model */
    public class DSMatch {
        //instance vars
        /* property members */
        private DSComparable matched = null;
        private DSComparable matchedTo = null;
        private DSMatchGroup parentGroup = null;
        private int index = 0;

        //public properties 
        /* the full path of the new file/dir that matched an existing file/dir */
        public DSComparable Matched { get { return matched; } }

        /* the full path fo the matched file/dir that matched an existing file/dir */
        public DSComparable MatchedTo { get { return matchedTo; } }
            
        /* the group to which this match belongs */
        public DSMatchGroup ParentGroup { get { return parentGroup; } set { parentGroup = value; } }

        /* get the index value */
        public int Index { get { return index; } }


        //public methods
        /* constructor */
        public DSMatch(DSComparable matched, DSComparable matchedTo, DSMatchGroup parentGroup, int index) {
            this.matched = matched;
            this.matchedTo = matchedTo;
            this.parentGroup = parentGroup;
            this.index = index;
        }
    }

    /* matches that were found during the search */
    public class DSMatchGroup : IComparable<DSMatchGroup> {
        //static vars
        /* private vars */
        private static long seedID = 0;


        //instance vars
        /* property members */
        private List<DSComparable> matches = new List<DSComparable>();
        private string value = null;
        private string name = null;
        private DSModel model = null;
        private DSComparable firstComparable = null;
        private int index = 0;
        private long uniqueID = 0;
        private object tag = null;


        //all public properties
        /* return matches */
        public List<DSComparable> Matches { get { return matches; } }
        public DSComparable FirstComparable { get { return firstComparable; } }
        public string Value { get { return value; } }
        public string Name { get { return name; } }
        public DSModel Model { get { return model; } }
        public int Index { get { return index; } set { index = value; } }
        public long UniqueID { get { return uniqueID; } }
        public string UniqueValue { get { string sep = (value.Length > 0) ? "_" : ""; return value + sep + uniqueID.ToString(); } }
        public object Tag { get { return tag; } set { tag = value; } }


        //all public methods
        /* constructor */
        public DSMatchGroup(DSModel parentModel, DSComparable firstComparable, bool preLoad) {
            /* set parent model, first FSI, and add to list of matches */
            uniqueID = seedID++;
            model = parentModel;
            this.firstComparable = firstComparable;
            firstComparable.ParentGroup = this;
            matches.Add(firstComparable);
            
            /* only necessary to load the name and value first - headers, footers, and hashes can be loaded later as necessary to save on resources */
            value = ComputeValue(firstComparable);
            name = ComputeName(firstComparable);

            /* if preload is flagged, load the header and footer at least, depending on the content comparison type */
            if (preLoad) {
                switch (model.ContentComparisonMode) {
                    case DSContentComparisonMode.Header: //load the header
                        firstComparable.ComputeHeader();
                        break;
                    case DSContentComparisonMode.HeaderAndFooter: //load the header and footer at first 
                        firstComparable.ComputeHeader();
                        firstComparable.ComputeFooter();
                        break;
                    case DSContentComparisonMode.Full: //DO NOT preload the hash - this can be done when necessary upon comparison
                        firstComparable.ComputeHeader();
                        firstComparable.ComputeFooter();
                        break;
                    case DSContentComparisonMode.None:
                        break;
                    default:
                        throw new Exception("Not a supported content comparison mode.");
                }
            }
        }

        /* compares to other classes */
        public int CompareTo(DSMatchGroup dsmg) {
            int retVal = 0;

            /* compare name values first */
            retVal = Value.CompareTo(dsmg.Value);

            /* determine what logic we should use */
            if (retVal == 0) {
                if (model.NameComparisonMode != DSNameComparisonMode.None)
                    if (model.MatchtNameORContent)
                        return retVal;

                /* if it was equal, then we need to see if we are supposed to look at contents as well. determine the value by looking at the content comparison mode */
                switch (model.ContentComparisonMode) {
                    case DSContentComparisonMode.Full:
                        if ((retVal = firstComparable.Header.CompareTo(dsmg.FirstComparable.Header)) == 0)
                            if ((retVal = firstComparable.Footer.CompareTo(dsmg.FirstComparable.Footer)) == 0)
                                retVal = firstComparable.Hash.CompareTo(dsmg.FirstComparable.Hash);
                        break;
                    case DSContentComparisonMode.Header:
                        retVal = firstComparable.Header.CompareTo(dsmg.FirstComparable.Header);
                        break;
                    case DSContentComparisonMode.HeaderAndFooter:
                        if ((retVal = firstComparable.Header.CompareTo(dsmg.FirstComparable.Header)) == 0)
                            retVal = firstComparable.Footer.CompareTo(dsmg.FirstComparable.Footer);
                        break;
                    case DSContentComparisonMode.None:
                        break;
                    default:
                        throw new Exception("Unsupported content comparison mode.");
                }
            }

            return retVal;
        }

        /* returns the number of files in the Matches collection */
        public int GetFileMatchCount() {
            int count = 0;

            for (int i = 0; i < Matches.Count; i++) 
                if (matches[i].FSI is FileInfo)
                    count++;

            return count;
        }

        /* returns the number of dirs in the Matches collection */
        public int GetDirectoryMatchCount() {
            int count = 0;

            for (int i = 0; i < Matches.Count; i++)
                if (matches[i].FSI is DirectoryInfo)
                    count++;

            return count;
        }

        /* clears as much as possible */
        public void Clear() {
            matches.Clear();
            model = null;
            firstComparable = null;
        }

        /* gets the string that represents this object */
        public override string ToString() {
            return value;
        }


        //all private methods
        /* computes the name that is to be displayed */
        private string ComputeName(DSComparable comparable) {
            string retVal = comparable.Name;

            return retVal;
        }

        /* computes the value that is to be compared */
        private string ComputeValue(DSComparable comparable) {
            string name = comparable.Name;
            string seperator = "_";
            string size = "";
            string header = "";

            /* see if we are supposed to ignore the extension */
            if (model.IgnoreExtensions) {
                string ext = comparable.FSI.Extension;
                if (ext.Length > 0) {
                    int pos = name.LastIndexOf(ext);
                    name = name.Substring(0, pos);
                }
            }

            /* set all upper case */
            name = name.ToUpper();

            /* determine part of the value by looking at the model's name comparison mode */
            switch (model.NameComparisonMode) {
                case DSNameComparisonMode.None:
                    name = "";
                    break;
                case DSNameComparisonMode.Exact:
                    name = DSUtilities.CustomProcessFileName(name, model.RemoveNonAlphaCharsFromName, model.RemoveNumberCharsFromName, 0);
                    break;
                case DSNameComparisonMode.SoundEx:
                    name = DSUtilities.CustomProcessFileName(name, model.RemoveNonAlphaCharsFromName, model.RemoveNumberCharsFromName, 0);
                    name = DSSoundEx.CalculateSoundEx(name);
                    break;
                default:
                    throw new Exception("Unsupported name comparison mode.");
            }

            /* APPENDING F_ or D_ MUST COME AFTER the processing of the file name */
            if (!model.MatchFilesToDirectories) {
                if (comparable.FSI is FileInfo)
                    header = "F";
                else if (comparable.FSI is DirectoryInfo)
                    header = "D";
                else
                    header = "";
            }

            /* determine another part if file size should be used */
            if (model.MatchSizes) 
                size = comparable.Size;
            
            /* combine all values using seperator */
            return DSUtilities.DSConcat(seperator, new string[] { header, name, size });
        }
    }

    /* wraps a comparable interface around an FSI */
    public class DSComparable : IComparable<DSComparable> {
        //private members 
        /* just crap */
        private DSModel model = null;
        private FileSystemInfo fsi = null;
        private DSMatchGroup parentGroup = null;
        private SortedList<string, DirectoryInfo> sortedDirectories = new SortedList<string, DirectoryInfo>();
        private SortedList<string, FileInfo> sortedFiles = new SortedList<string, FileInfo>();
        private FileInfo[] fileArray = null;
        private DirectoryInfo[] directoryArray = null;
        private string header = null;
        private string footer = null;
        private string hash = null;
        private string size = null;
        private object tag = null;


        //public properties
        /* more crap */
        public DSModel Model { get { return model; } set { model = value; } }
        public FileSystemInfo FSI { get { return fsi; } }
        public DSMatchGroup ParentGroup { get { return parentGroup; } set { parentGroup = value; } }
        public SortedList<string, DirectoryInfo> SortedDirectories { get { return sortedDirectories; } }
        public SortedList<string, FileInfo> SortedFiles { get { return sortedFiles; } }
        public string Value { get { return fsi.FullName; } }
        public string Name { get { return fsi.Name; } }
        public FileInfo[] FileArray { get { if (fileArray == null) fileArray = GetFiles(); return fileArray; } }
        public DirectoryInfo[] DirectoryArray { get { if (directoryArray == null) directoryArray = GetDirectories(); return directoryArray; } }
        public string Header { get { if (header == null) ComputeHeader(); return header; } }
        public string Footer { get { if (footer == null) ComputeFooter(); return footer; } }
        public string Hash { get { if (hash == null) ComputeHash(); return hash; } }
        public string Size { get { if (size == null) size = DSUtilities.GetSizeString(this); return size; } }
        public object Tag { get { return tag; } set { tag = value; } }


        //public methods
        /* constructor should be all that is necessary */
        public DSComparable(FileSystemInfo fsi, DSModel model, DSMatchGroup parentGroup) {
            this.fsi = fsi;
            this.model = model;
            this.parentGroup = parentGroup;
        }

        /* compares to another */
        public int CompareTo(DSComparable comparable) {
            return Value.CompareTo(comparable.Value);
        }

        /* loads files from an array */
        public void LoadSortedFiles() {
            if (sortedFiles.Count == 0) {
                for (int i = 0; i < FileArray.Length; i++)
                    sortedFiles.Add(FileArray[i].Name, FileArray[i]);
            }
        }

        /* loads the dirs from an array */
        public void LoadSortedDirectories() {
            if (sortedDirectories.Count == 0) {
                for (int i = 0; i < DirectoryArray.Length; i++)
                    sortedDirectories.Add(DirectoryArray[i].Name, DirectoryArray[i]);
            }
        }

        /* returns the files array, if it is a directoryinfo */
        private FileInfo[] GetFiles() { return GetFiles(null); }
        public FileInfo[] GetFiles(string filter) {
            if (fsi is DirectoryInfo) {
                DirectoryInfo di = (DirectoryInfo)fsi;
                if (filter == null) {
                    if (fileArray == null) {
                        fileArray = di.GetFiles();
                    } else {
                        fileArray = new FileInfo[] { };
                    }
                } else {
                    return di.GetFiles(filter, SearchOption.TopDirectoryOnly);
                }
            }

            return fileArray;
        }

        /* returns the dirs array, if it is a directory info */
        private DirectoryInfo[] GetDirectories() { return GetDirectories(null); }
        public DirectoryInfo[] GetDirectories(string filter) {
            if (fsi is DirectoryInfo) {
                DirectoryInfo di = (DirectoryInfo)fsi;
                if (filter == null) {
                    if (directoryArray == null) {
                        directoryArray = di.GetDirectories();
                    } else {
                        directoryArray = new DirectoryInfo[] { };
                    }
                } else {
                    return di.GetDirectories(filter, SearchOption.TopDirectoryOnly);
                }
            }

            return directoryArray;
        }

        /* returns if it exists */
        public bool Exists() {
            if (FSI is DirectoryInfo)
                return Directory.Exists(FSI.FullName);
            else if (FSI is FileInfo) 
                return File.Exists(FSI.FullName);
            else
                throw new Exception("Not supported.");
        }

        /* loads the header */
        public void ComputeHeader() {
            header = DSUtilities.GetHeader(this, model.HeaderAndFooterByteCount);
        }

        /* loads the footer */
        public void ComputeFooter() {
            footer = DSUtilities.GetFooter(this, model.HeaderAndFooterByteCount, model.HeaderAndFooterByteCount);
        }

        /* loads the hash */
        public void ComputeHash() {
            hash = DSUtilities.GetHash(this);
        }

        /* returns a size no matter if dir or file */
        public long GetSizeLong() {
            if (fsi is FileInfo)
                return ((FileInfo)fsi).Length;
            else if (fsi is DirectoryInfo)
                return GetDirectories().Length * GetFiles().Length;
            else
                return 0;
        }
    }

    /* actual model that performs the searches and comparisons */
    public class DSModel {
        //constants
        /* private */
        private const int maxThreadCount = 100;

        /* public */
        public const int defaultHeaderAndFooterByteCount = 512;


        //instance vars
        /* private members -- internal */
        private Queue<DSComparable>[] mainQueues = null;
        private Stack<DSComparable>[] mainStacks = null;
        private DSAVLBST<DSMatchGroup> matchGroups = new DSAVLBST<DSMatchGroup>();
        private Queue<DSMatch> newMatches = new Queue<DSMatch>();
        private int newMatchCount = 0;
        private int totalMatchedGroupCount = 0;
        private int totalMatchedCount = 0;
        private int totalNewMatchCount = 0;
        private int totalNewMatchesRetrieved = 0; //the number of matches that have been retreived with GetNewMatches()
        private int totalFilesCompared = 0;
        private int totalDirectoriesCompared = 0;
        private int totalComparables = 0; //for calculating the progress that is being made
        private string currentSearchLocation = null;
        private string currentComparison = null;
        private List<Thread> threadList = new List<Thread>();
        private Thread comparisonThread = null; //thread that performs all comparisons
        private Queue<DSMatchGroup> comparableGroups = new Queue<DSMatchGroup>(); //all objects (files or Directorys) that can be compared
        private int threadCount = 0; //leave zero for default
        private Queue<string> log = new Queue<string>();
        private List<DirectoryInfo> initialSearchPaths = new List<DirectoryInfo>(); //all of the initial search locations 
        private string[] defaultFileExcludeFilters = new string[] { "*.ani", "*.ann", "*.bmk", "*.cab", "*.cpl", "*.cnt", "*.cur", "*.desklink", "*.dev", "*.dss", "*.dmp", "*.drv", "*.ffa", "*.ffl", "*.grp", "*.reg", "*.key", "*.sys", "*.msi", "*.dll", "*.prf", "*.prt" };
        private string[] defaultFileIncludeFilters = new string[] { };
        private string[] defaultDirExcludeFilters = new string[] { "System32", "Windows", "Program Files", "Temporary Internet Files" };
        private string[] defaultDirIncludeFilters = new string[] { };
       
        /* private property instance vars */
        private DSSearchModes searchMode = DSSearchModes.TopDown; //settable - type of search determines which structure is used
        private bool searchSubdirectories = true;
        private bool matchDirectories = false;
        private bool matchFiles = true;
        private bool matchFilesToDirectories = true;
        private bool ignoreExtensions = false;
        private bool removeNonAlphaCharsFromName = false;
        private bool removeNumberCharsFromName = false;
        private DSContentComparisonMode contentComparisonMode = DSContentComparisonMode.None;
        private bool matchDirectoryContents = true;
        private bool matchNameORContent = false;
        private bool trackNewMatches = true;
        private bool newMatchesToAllInMatchGroup = false;
        private bool matchSizes = true;
        private long minFileSize = 0;
        private long maxFileSize = 100000000000000;
        private DSNameComparisonMode nameComparisonMode = DSNameComparisonMode.Exact;
        private DSAVLBST<string> fileNameIncludeFilters = new DSAVLBST<string>();
        private DSAVLBST<string> fileNameExcludeFilters = new DSAVLBST<string>();
        private DSAVLBST<string> dirNameIncludeFilters = new DSAVLBST<string>();
        private DSAVLBST<string> dirNameExcludeFilters = new DSAVLBST<string>();
        private bool mergeFilters = false;
        private bool useDefaultFilters = true;
        private bool preLoadContents = true;
        private bool hasStarted = false; //set to true when start()ed and false when reset()
        private bool searchCompleted = false; //true when stop was called before it was finished, false when start() is called
        private bool shouldBeRunning = false; //set to true when resume()d and false when pause()d
        private int tcount = 0; //calculated thread count
        private int headerFooterByteCount = defaultHeaderAndFooterByteCount;
        private bool keepLog = false;
        private DateTime startTime = default(DateTime);
        private DateTime endTime = default(DateTime);


        //All public properties
        /* sets the search type */
        public DSSearchModes SearchMode { 
            get { return searchMode; } 
            set {
                if (hasStarted)
                    throw new Exception("Cannot set the search type after a search has started. You must reset first.");
                searchMode = value;
            } 
        }
        
        /* sets the thread count - leave zero for default */
        public int ThreadCount { 
            get {
                if (hasStarted) //if started, return calculated thread count
                    return tcount;
                else
                    return threadCount;
            } 
            set {
                if (hasStarted)
                    throw new Exception("Cannot set thread count after a search has started. You must reset first.");
                threadCount = value; 
            } 
        }

        /* sets whether or not subdirectories are searched */
        public bool SearchSubdirectories { get { return searchSubdirectories; } set { searchSubdirectories = value; } }

        /* sets whether or not directories are compared */
        public bool MatchDirectories { get { return matchDirectories; } set { matchDirectories = value; } }

        /* sets whether or not files are compared */
        public bool MatchFiles { get { return matchFiles; } set { matchFiles = value; } }

        /* sets whether files and directories are compared to each otehr */
        public bool MatchFilesToDirectories { get { return matchFilesToDirectories; } set { matchFilesToDirectories = value; } }

        /* sets whether file extensions are ignored during comparions*/
        public bool IgnoreExtensions { get { return ignoreExtensions; } set { ignoreExtensions = value; } }

        /* sets/gets whether nonalpha chars are removed from the filename before comparison */
        public bool RemoveNonAlphaCharsFromName { get { return removeNonAlphaCharsFromName; } set { removeNonAlphaCharsFromName = value; } }

        /* sets/gets whether number chars are removed from the filename before comparison */
        public bool RemoveNumberCharsFromName { get { return removeNumberCharsFromName; } set { removeNumberCharsFromName = value; } }

        /* sets whether or not new matches are stored in a list for periodic retrieval */
        public bool TrackNewMatches { get { return trackNewMatches; } set { trackNewMatches = value; } }

        /* sets whether new matches occur to groups only, or to all files in the group */
        public bool NewMatchesToAllInMatchGroup { get { return newMatchesToAllInMatchGroup; } set { newMatchesToAllInMatchGroup = value; } }

        /* gets whether or not it has been started. note that this is set to false when the search and comparison threads are ended */
        public bool IsStarted { get { return hasStarted; } }

        /* gets whether or not it is currently running */
        public bool IsRunning { get { return shouldBeRunning; } }

        /* gets whether the search was stopped or it completed */
        public bool SearchCompleted { get { return searchCompleted; } }

        /* gets list of matches */
        public DSAVLBST<DSMatchGroup> MatchGroups { get { return matchGroups; } }

        /* gets number of new matches found */
        public int NewMatchCount { get { return newMatchCount; } } //would have returned newMatches.Count, but this causes locking/blocking issues

        /* returns the number of matches since the search was started */
        public int TotalMatchedCount { get { return totalMatchedCount; } }

        /* returns the number of match groups that contain more than one match */
        public int TotalMatchedGroupCount { get { return totalMatchedGroupCount; } }

        /* returns the total number of new matches */
        public int TotalNewMatchCount { get { return totalNewMatchCount; } }

        /* returns the total number of matches retrieved with GetNewMAtches() */
        public int TotalNewMatchesRetrieved { get { return totalNewMatchesRetrieved; } }

        /* returns the total number of files compared */
        public int TotalFilesCompared { get { return totalFilesCompared; } }

        /* returns the total number of dirs compared */
        public int TotalDirectoriesCompared { get { return totalDirectoriesCompared; } }

        /* returns the total number of comparables that had to be compared */
        public int TotalComparables { get { return totalComparables; } }

        /* returns the number of initial search directories that have been added */
        public int InitialSearchPathCount { get { return initialSearchPaths.Count; } }

        /* returns/sets the mode for comparing file/dir names */
        public DSNameComparisonMode NameComparisonMode { get { return nameComparisonMode; } set { nameComparisonMode = value; } }

        /* returns/sets the mode for the content comparison */
        public DSContentComparisonMode ContentComparisonMode { get { return contentComparisonMode; } set { contentComparisonMode = value; } }

        /* determines if the top-leve contents of a dir are used to cmopare a dir */
        public bool MatchDirectoryContents { get { return matchDirectoryContents; } set { matchDirectoryContents = value; } }

        /* determines of a match occurs when the Name or/and the Content matches */
        public bool MatchtNameORContent { get { return matchNameORContent; } set { matchNameORContent = value; } }

        /* returns the current location being searched */
        public string CurrentSearchLocation { get { return currentSearchLocation; } }

        /* returns the current file/dir being compared */
        public string CurrentComparison { get { return currentComparison; } }

        /* returns/sets whether file size is used in comparison */
        public bool MatchSizes { get { return matchSizes; } set { matchSizes = value; } }

        /* sets/returns min file size */
        public long MinFileSize { get { return minFileSize; } set { minFileSize = value; } }

        /* sets/returns max file size */
        public long MaxFileSize { get { return maxFileSize; } set { maxFileSize = value; } }

        /* gets/sets the include file filter */
        public DSAVLBST<string> FileNameIncludeFilters { get { return fileNameIncludeFilters; } set { fileNameIncludeFilters = value; } }

        /* gets/sets the exclude file filters */
        public DSAVLBST<string> FileNameExcludeFilters { get { return fileNameExcludeFilters; } set { fileNameExcludeFilters = value; } }

        /* gets/sets the include Dir filter */
        public DSAVLBST<string> DirNameIncludeFilters { get { return dirNameIncludeFilters; } set { dirNameIncludeFilters = value; } }

        /* gets/sets the exclude Dir filters */
        public DSAVLBST<string> DirNameExcludeFilters { get { return dirNameExcludeFilters; } set { dirNameExcludeFilters = value; } }

        /* determines if the dir filters also apply to the file filters and visa versa */
        public bool MergeFilters { get { return mergeFilters; } set { mergeFilters = value; } }

        /* determins if the default filters are loaded */
        public bool UseDefaultFilters { get { return useDefaultFilters; } set { useDefaultFilters = value; if (useDefaultFilters) LoadDefaultFilters(); else UnloadDefaultFilters(); } }

        /* determines how many bytes are read to compare the header and footer of a file */
        public int HeaderAndFooterByteCount { get { return headerFooterByteCount; } set { headerFooterByteCount = value; } }

        /* determines if the headers and footers are preloaded (if the content comparison mode calls for it */
        public bool PreLoadContents { get { return preLoadContents; } set { preLoadContents = value; } }

        /* determines if the log is used */
        public bool KeepLog { get { return keepLog; } set { keepLog = value; } }

        /* start itme of search */
        public DateTime StartTime { get { return startTime; } set { startTime = value; } }

        /* end time of search */
        public DateTime EndTime { get { return endTime; } set { endTime = value; } }


        //All public methods
        /* constructor */
        public DSModel() {
            if (useDefaultFilters)
                LoadDefaultFilters();
            else
                UnloadDefaultFilters();
        }

        /* returns all search paths */
        public string[] GetInitialSearchPaths() {
            string[] paths = new string[initialSearchPaths.Count];

            /* fill array */
            for (int i = 0; i < initialSearchPaths.Count; i++)
                paths[i] = initialSearchPaths[i].FullName;

            return paths;
        }

        /* adds a location to the list of search locations */
        public void AddInitialSearchPath(string fullPath) {
            string path = fullPath.ToUpper();

            /* make sure it's not already there */
            foreach (DirectoryInfo di in initialSearchPaths) {
                string fullName = di.FullName.ToUpper();

                if ((path.IndexOf(fullName) == 0) || (fullName.IndexOf(path) == 0)) {
                    /* figure out which is a subdir of the other */
                    string sub = fullPath; 
                    string par = di.FullName;
                    if (path.Length < fullName.Length) {
                        sub = di.FullName;
                        par = fullPath;
                    }

                    throw new Exception("The path: '" + sub + "' is a subdirectory of '" + par + "', which has already been added to the search list.");
                }
            }
                
            
            /* check for existence */
            if (Directory.Exists(path)) {
                /* add */
                initialSearchPaths.Add(new DirectoryInfo(path));
            } else {
                throw new Exception("The path: '" + fullPath + "' does not exist or can not be found.");
            }
        }
        
        /* removes a location to be searched */
        public void RemoveInitialSearchPath(string path) {
            /* iterate over all search paths to find the one to remove */
            for (int i = 0; i < initialSearchPaths.Count; i++) {
                DirectoryInfo di = initialSearchPaths[i];

                if (path.Equals(di.FullName, StringComparison.OrdinalIgnoreCase)) {
                    initialSearchPaths.Remove(di);
                    i--;
                }
            }
        }

        /* clears all of the initial search paths */
        public void ClearInitialSearchPaths() {
            initialSearchPaths.Clear();
        }

        /* starts a new search; performs reset in case resources need to be freed */
        public void Start() {
            /* just in case multiple threads attempt to run this crap */
            lock (this) {
                /* log event */
                LogEvent("Starting search: " + DateTime.Now.ToString());

                /* load filters */
                if (useDefaultFilters) LoadDefaultFilters();

                /* ensure all threads have ended and all queues are clear */
                Stop();

                /* check to make sure we have valid options */
                ValidateOptions();

                /* reset all other state possibly left over from last run */
                Reset();

                /* set start time and clear end time */
                startTime = DateTime.Now;
                endTime = default(DateTime);

                /* signal that it has state that it is maintaining */
                hasStarted = true;

                /* signal that the search has started but is not complete */
                searchCompleted = false;

                /* calculate thread count */
                tcount = threadCount;
                if (tcount <= 0) tcount = initialSearchPaths.Count;
                if (tcount > initialSearchPaths.Count) tcount = initialSearchPaths.Count;
                tcount = Math.Min(tcount, maxThreadCount);

                /* create the thread queues */
                mainQueues = new Queue<DSComparable>[tcount];
                for (int i = 0; i < tcount; i++) mainQueues[i] = new Queue<DSComparable>();
                mainStacks = new Stack<DSComparable>[tcount];
                for (int i = 0; i < tcount; i++) mainStacks[i] = new Stack<DSComparable>();

                /* initialize queue with the initial search locations. some queues might be initialized with more than one location if the number of location exceeds the number of threads  */
                for (int i = 0; i < initialSearchPaths.Count; i++)
                    QueueComparable((i % tcount), new DSComparable(initialSearchPaths[i], this, null));

                /* start it up */
                Resume();

                /* log event */
                LogEvent("Search started.");
            }
        }

        /* resets/stops this object by emptying the root searches */
        private void Stop(object info) { Stop(); }
        public void Stop() {
            /* just in case multiple threads attempt to run this */
            lock (this) {
                /* end all threads */
                Pause();

                /* clear all state */
                if (mainQueues != null) {
                    for (int i = 0; i < mainQueues.Length; i++) {
                        mainQueues[i].Clear();
                        mainQueues[i] = null;
                    }
                    mainQueues = null;
                }
                if (mainStacks != null) {
                    for (int i = 0; i < mainStacks.Length; i++) {
                        mainStacks[i].Clear();
                        mainStacks[i] = null;
                    }
                    mainStacks = null;
                }
                ClearComparables();

                /* signal that there is no more state being maintained */
                hasStarted = false;

                /* set the end time */
                endTime = DateTime.Now;

                /* log event */
                LogEvent("Search stopped.");
            }
        }

        /* pauses the search by signaling and waiting for the threads to stop */
        public void Pause() {
            /* for multithreading concerns */
            lock (threadList) {
                /* signal to stop */
                shouldBeRunning = false;

                /* ensure they all join */
                for (int i = 0; i < threadList.Count; i++)
                    threadList[i].Join();
                threadList.Clear();

                /* join the comparison thread too */
                if (comparisonThread != null)
                    comparisonThread.Join();
                comparisonThread = null;

                /* log event */
                LogEvent("Search paused.");
            }
        }

        /* starts the search using the current state of the queues; creates the queues and initializes them with the initialSearchPaths if they are null */
        public void Resume() {
            /* multithreading concerns */
            lock (threadList) {
                if (hasStarted) {
                    /* ensure there are no threads running */
                    Pause();

                    /* signal we are running */
                    shouldBeRunning = true;

                    /* create the threads */
                    for (int i = 0; i < tcount; i++)
                        threadList.Add(new Thread(new ThreadStart(SearchLoop)));

                    /* start all of the search threads */
                    foreach (Thread t in threadList)
                        t.Start();

                    /* start the comparison thread */
                    comparisonThread = new Thread(new ThreadStart(ComparisonLoop));
                    comparisonThread.Start();

                    /* log event */
                    LogEvent("Search resumed.");
                } else {
                    throw new Exception("You cannot resume a search that has not been started.");
                }
            }
        }

        /* performs a full stop() and resets all state. typically performed before starting again to preserve logs, results, etc. resets the matches and the match index */
        public void Reset() {
            /* ensure we stop first */
            Stop();

            /* clear the match groups */
            DSAVLBST<DSMatchGroup>.AscendingOrderEnumerator enumerator = matchGroups.GetEnumerator();
            while (enumerator.MoveNext())
                enumerator.Current.Clear();
            matchGroups.Clear();
            totalMatchedGroupCount = 0;

            /* for thread saftey */
            lock (newMatches) {
                newMatches.Clear();
            }
            newMatchCount = 0;

            /* reset the totals */
            totalMatchedCount = 0;
            totalNewMatchCount = 0;
            totalNewMatchesRetrieved = 0;
            totalFilesCompared = 0;
            totalDirectoriesCompared = 0;
            totalComparables = 0;

            /* reset the log */
            lock (log) {
                log.Clear();
            }

            /* log event */
            LogEvent("Engine reset.");

            /* set the end time */
            startTime = default(DateTime);
            endTime = default(DateTime);
        }

        /* determines if it is still searching the initial search paths */
        public bool IsSearching() {
            /* multithreading concerns */
            lock (threadList) {
                for (int i = 0; i < threadList.Count; i++)
                    if (threadList[i].IsAlive)
                        return true;
            }
            return false;
        }

        /* returns a list of only the matches that have not been returned by this function (newly found matches) (passing -1 returns all) */
        public Queue<DSMatch> GetNewMatches() { return GetNewMatches(-1); }
        public Queue<DSMatch> GetNewMatches(int count) {
            Queue<DSMatch> latest = new Queue<DSMatch>();

            /* set our count if it is less than 0 */
            if (count < 0)
                count = int.MaxValue;

            /* get the max count if we are not registered */
            count = DSLicensing.HandleMaxMatchCount(count, this);

            /* accessed by independent threads, so lock */
            lock (newMatches) {
                while ((count > 0) && (newMatches.Count > 0)) {
                    latest.Enqueue(newMatches.Dequeue());
                    totalNewMatchesRetrieved++;

                    newMatchCount--;
                    count--;
                }
            }

            return latest;
        }

        /* clears the list of new matches that have not yet been pulled out with GetNewMatches() */
        public void ClearNewMatches() {
            /* ensure we are the only one accessing */
            lock (newMatches) {
                newMatches.Clear();
                newMatchCount = 0;
            }
        }

        /* returns the next log item */
        public string[] GetNewLogItems() {
            string[] logs = new string[0];

            /* possibly accessed by threads, so lock */
            lock (log) {
                if (log.Count > 0) {
                    logs = new string[log.Count];
                    log.CopyTo(logs, 0);
                    log.Clear();
                }
            }

            return logs;
        }


        //All private methods
        /* adds a path to the main list to be worked on by threads */
        private void QueueComparable(int queueIndex, DSComparable comparable) {
            switch (searchMode) {
                case DSSearchModes.BottomUp:
                    mainStacks[queueIndex].Push(comparable);
                    break;
                case DSSearchModes.TopDown:
                    mainQueues[queueIndex].Enqueue(comparable);
                    break;
                default:
                    break;
            }
        }

        /* removes a path from the main list */
        private DSComparable DequeueComparable(int queueIndex) {
            DSComparable comparable = null;

            /* return null if there is an error (queue is empty) */
            try {
                switch (searchMode) {
                    case DSSearchModes.BottomUp:
                        comparable = mainStacks[queueIndex].Pop();
                        break;
                    case DSSearchModes.TopDown:
                        comparable = mainQueues[queueIndex].Dequeue();
                        break;
                    default:
                        comparable = null;
                        break;
                }
            } catch {
                comparable = null;
            }

            return comparable;
        }

        /* returns the index of the queue that corresponds to the calling thread */
        private int GetThreadQueueIndex() {
            for (int i = 0; i < threadList.Count; i++)
                if (threadList[i].ManagedThreadId == Thread.CurrentThread.ManagedThreadId)
                    return i;
            throw new Exception("Unable to determine thread's queue index.");
        }

        /* main loop for each thread */
        private void SearchLoop() {
            DSComparable comparable = null;
            DSComparable[] comparables = null;
            int queueIndex = GetThreadQueueIndex();

            /* loop that uses the queue/stack associated with this thread */
            while ((shouldBeRunning) && ((comparable = DequeueComparable(queueIndex)) != null) && (!DSMain.IsAppDieing)) { /* get next dir to be searched */
                currentSearchLocation = comparable.Name; //set property for updating status

                /* compare directories */
                if (matchDirectories) { // then add the dir for comparison too 
                    try { //access denied excption is possible here
                        AddComparables(new DSComparable[] { comparable });
                    } catch (Exception ex) {
                        LogEvent(ex);
                    }
                }

                /* compare files */
                if (matchFiles) {
                    try { //simply keep going if there is an exception (access denied)
                        comparables = GetComparables(comparable, true);
                        AddComparables(comparables);
                    } catch (Exception ex) {
                        LogEvent(ex);
                    }
                }

                /* queue subdirectories */
                if (searchSubdirectories) { //then add the sub directories to the queue 
                    try { //simply keep going if there is an exception 
                        comparables = GetComparables(comparable, false);
                        foreach (DSComparable comp in comparables)
                            QueueComparable(queueIndex, comp);
                    } catch (Exception ex) {
                        LogEvent(ex);
                    }
                }
            }

            /* set to null so that we can know it's done searching */
            currentSearchLocation = null;
        }

        /* comparison loop */
        private void ComparisonLoop() {
            DSMatchGroup currentComparableGroup = null;

            /* loop until either run=false or we have compared all files and Directorys and searching has finished */
            while (shouldBeRunning && (!DSMain.IsAppDieing)) { 
                if ((currentComparableGroup = GetNextComparableGroup()) != null) { //then we still have some to compare
                    DSMatchGroup existingMatchGroup = null; //in case we find a match, we can add to it

                    /* set currentComparison member so that the status can be updated */
                    currentComparison = currentComparableGroup.Name;

                    /* increment file or dir compare count */
                    if (currentComparableGroup.FirstComparable.FSI is FileInfo)
                        totalFilesCompared++;
                    else if (currentComparableGroup.FirstComparable.FSI is DirectoryInfo)
                        totalDirectoriesCompared++;

                    /* this is the meat of the model - optimize as much as possible with various data structures and algorithms */
                    if ((existingMatchGroup = matchGroups.Find(currentComparableGroup)) == null) { //see if it's already in the tree
                        matchGroups.Add(currentComparableGroup); //add to the tree if not
                    } else {
                        /* add match to the existing group */
                        AddMatch(existingMatchGroup, currentComparableGroup); 
                    }
                } else { //then we have none left to compare
                    if (IsSearching()) //then we just need to wait for more comparables to enter the comparables list
                        Thread.Sleep(100);
                    else { //then we need to stop because we compared everything and we are finished searching
                        /* log event */
                        LogEvent("Search complete; stopping...");

                        /* indicate that we successfully finished and were not manually stopped */
                        searchCompleted = true;

                        /* prepare thread to call the stop */
                        ThreadPool.QueueUserWorkItem(new WaitCallback(Stop));

                        /* make sure we exit or else there is an exception called for multiple autoEnders */
                        break; 
                    }
                }
            }

            /* set the currentComparison to null so we know we are done */
            currentComparison = null;
        }

        /* adds a match to the matches list */
        private void AddMatch(DSMatchGroup existing, DSMatchGroup newdmg) {
            /* increment the total newMatchCount */
            if (existing.Matches.Count == 1) {
                /* if the existing match group has only one fsi, then increment the group count */
                existing.Index = totalMatchedGroupCount; //we are about to add the second match, thus it is a valid group of matches (a group of 1 is not valid
                totalMatchedGroupCount++;
                totalMatchedCount += 2;
            } else {
                totalMatchedCount++;
            }

            /* if trackchanges is turned on, add it to the newMatches list */
            if (trackNewMatches) {
                /* for thread safety */
                lock (newMatches) {
                    /* check to see if we are to match to each file in the group, or just the group itself */
                    int count = 1;
                    if (newMatchesToAllInMatchGroup) {
                        count = existing.Matches.Count;
                    }

                    /* now iterate over however many was specified */
                    for (int i = 0; i < count; i++) {
                        /* add the new match with the proper index */
                        newMatches.Enqueue(new DSMatch(newdmg.FirstComparable, existing.Matches[i], existing, totalNewMatchCount));

                        /* increment the new match count */
                        newMatchCount++;

                        /* incremement the total match count */
                        totalNewMatchCount++;
                    }
                }
            }

            /* add to the existing group - MUST BE DONE AFTER the above code */
            existing.Matches.Add(newdmg.FirstComparable);
            newdmg.FirstComparable.ParentGroup = existing;
            newdmg.Clear();
        }

        /* validates the options by throwing exceptions if there is a problem */
        private void ValidateOptions() {
            /* check to see if any dirs were added */
            if (InitialSearchPathCount == 0)
                throw new Exception("At least one directory must be added to the list of directories to be searched.");

            /* check to see if at least files or dirs are being compared */
            if (!(matchFiles || matchDirectories))
                throw new Exception("Nothing to do since neither files or directores are to be matched.");

            /* check to see that we are at least comparing contents or names - the flags can be set such that nothing is compared at all */
            if ((((contentComparisonMode == DSContentComparisonMode.None) && (nameComparisonMode == DSNameComparisonMode.None)) || ((!matchFiles) && (nameComparisonMode == DSNameComparisonMode.None) && (!matchDirectoryContents))) && (!matchSizes))
                throw new Exception("Nothing to do since neither file/dir names, sizes, or contents are to be matched.");
        }

        /* adds a fileinfo or dirinfo to be comparaed */
        private void AddComparables(DSComparable[] comps) {
            /* ensure thread safety */
                /* add for comparison */
                for (int i = 0; i < comps.Length; i++) {
                    DSComparable comparable = comps[i];
                    DSMatchGroup group = new DSMatchGroup(this, comparable, preLoadContents); //essentially preloading on this thread instead of the comparison thread

                    /* ensure thread safety */
                    lock (comparableGroups) {
                        comparableGroups.Enqueue(group); 
                    }
                    
                    totalComparables++;
                }
        }

        /* returns the next comparable in the queue */
        private DSMatchGroup GetNextComparableGroup() {
            DSMatchGroup dmg = null;

            /* if none, ret null */
            if (comparableGroups.Count > 0) {
                /* ensure thread safety */
                lock (comparableGroups) {
                    dmg = comparableGroups.Dequeue();
                }
            } 

            return dmg;
        }

        /* clears the comparables queue */
        private void ClearComparables() {
            /* ensure thread safety */
            lock (comparableGroups) {
                comparableGroups.Clear();
            }
        }

        /* returns a subset of files based on the include and exclude filters */
        private DSComparable[] GetComparables(DSComparable comparable, bool getFiles) {
            Dictionary<string, FileSystemInfo> results = new Dictionary<string, FileSystemInfo>();
            DSAVLBST<string> includeFiltersBST = new DSAVLBST<string>();
            DSAVLBST<string> excludeFiltersBST = new DSAVLBST<string>();
            string[] includeFilters = null;
            string[] excludeFilters = null;

            /* load the file filter structures */
            if (getFiles || mergeFilters) {
                DSAVLBST<string>.AscendingOrderEnumerator enumerator;

                /* add file includes */
                enumerator = fileNameIncludeFilters.GetEnumerator();
                while (enumerator.MoveNext())
                    includeFiltersBST.Add(enumerator.Current);

                /* add file excludes */
                enumerator = fileNameExcludeFilters.GetEnumerator();
                while (enumerator.MoveNext())
                    excludeFiltersBST.Add(enumerator.Current);
            }
            
            /* load the dir filter structures */
            if ((!getFiles) || mergeFilters) {
                DSAVLBST<string>.AscendingOrderEnumerator enumerator;

                /* add dir includes */
                enumerator = dirNameIncludeFilters.GetEnumerator();
                while (enumerator.MoveNext())
                    includeFiltersBST.Add(enumerator.Current);

                /* add file excludes */
                enumerator = dirNameExcludeFilters.GetEnumerator();
                while (enumerator.MoveNext())
                    excludeFiltersBST.Add(enumerator.Current);
            }

            /* copy to arry and be done */
            includeFilters = includeFiltersBST.ToArray();
            excludeFilters = excludeFiltersBST.ToArray();
            includeFiltersBST.Clear();
            excludeFiltersBST.Clear();

            /* check to see if we have any include filters, and if so, they supercede the exclide */
            if (includeFilters.Length > 0) { //then combine all results of the include filters
                /* iterate over the filters and combine the results - be sure not to duplicate */
                for (int i = 0; i < includeFilters.Length; i++) {
                    FileSystemInfo[] fsis = null;
                    
                    /* see if we are getting files, and if so, check sizes too */
                    if (getFiles) {
                        fsis = GetFilesWithinSizes(comparable.GetFiles(includeFilters[i]));
                    } else {
                        fsis = comparable.GetDirectories(includeFilters[i]);
                    }

                    /* iterate over each file, see if it has been added, and if not add */
                    foreach (FileSystemInfo fsi in fsis) {
                        if (!results.ContainsKey(fsi.FullName))
                            results.Add(fsi.FullName, fsi);
                    }
                }
            } else { //load all and move on to use the set of exclusion filters 
                FileSystemInfo[] allfsis = null;

                /* see if we are getting files, and if so, check sizes too */
                if (getFiles) {
                    allfsis = GetFilesWithinSizes(comparable.FileArray);
                } else {
                    allfsis = comparable.DirectoryArray;
                }

                /* add all fsis first */
                for (int i = 0; i < allfsis.Length; i++) {
                    FileSystemInfo fsi = allfsis[i];
                    if (!results.ContainsKey(fsi.FullName))
                        results.Add(fsi.FullName, fsi);
                }
            }

            /* iterate over the exclusion filters and remove files/dirs from the results AVL as necessary */
            for (int i = 0; i < excludeFilters.Length; i++) {
                FileSystemInfo[] fsis = null;
                if (getFiles)
                    fsis = comparable.GetFiles(excludeFilters[i]); //do not need to get within sizes here because they are being checked to remove from the master list - best to use the AVL for better performance
                else
                    fsis = comparable.GetDirectories(excludeFilters[i]);
                
                /* iterate over each fsi, removing if it is found */
                foreach (FileSystemInfo fsi in fsis) {
                    if (results.ContainsKey(fsi.FullName))
                        results.Remove(fsi.FullName);
                }
            }

            /* now build the final array to return */
            DSComparable[] resultsArray = new DSComparable[results.Count];
            Dictionary<string, FileSystemInfo>.Enumerator resultsEnumerator = results.GetEnumerator();

            /* and copy the contents to the array */
            for (int i = 0; resultsEnumerator.MoveNext(); i++)
                resultsArray[i] = new DSComparable(resultsEnumerator.Current.Value, this, null);

            /* clear the trees */
            results.Clear();

            return resultsArray;
        }

        /* only returns an array of FileInfo[]s that are within the min/max size values */
        private FileInfo[] GetFilesWithinSizes(FileInfo[] files) {
            int count = 0;
            long len = 0;

            /* null the ones that don't count */
            for (int i = 0; i < files.Length; i++) {
                len = files[i].Length;
                if ((len < minFileSize) || (len > maxFileSize))
                    files[i] = null;
                else
                    count++;
            }

            /* create new array that is only the size of the filtered */
            FileInfo[] results = new FileInfo[count];

            /* iterate again if there were files */
            if (count > 0) {
                count = 0;

                /* iterate one more time to copy the remainders */
                for (int i = 0; i < files.Length; i++) {
                    if (files[i] != null) {
                        results[count++] = files[i];
                    }
                }
            }

            return results;
        }

        /* loads a set of default filters to the inclusion and exclusion filteres */
        private void LoadDefaultFilters() {
            /* load the exclude filters list */
            foreach (string def in defaultFileExcludeFilters)
                fileNameExcludeFilters.Add(def);

            /* load the include filters list */
            foreach (string dif in defaultFileIncludeFilters)
                fileNameIncludeFilters.Add(dif);

            /* load the exculde dir filters */
            foreach (string def in defaultDirExcludeFilters)
                dirNameExcludeFilters.Add(def);

            /* load the include dir filters */
            foreach (string dif in defaultDirIncludeFilters)
                dirNameIncludeFilters.Add(dif);
        }

        /* unloads the default filters from the filter lists */
        private void UnloadDefaultFilters() {
            /* load the exclude filters list */
            foreach (string def in defaultFileExcludeFilters)
                fileNameExcludeFilters.Remove(def);

            /* load the include filters list */
            foreach (string dif in defaultFileIncludeFilters)
                fileNameIncludeFilters.Remove(dif);

            /* load the exculde dir filters */
            foreach (string def in defaultDirExcludeFilters)
                dirNameExcludeFilters.Remove(def);

            /* load the include dir filters */
            foreach (string dif in defaultDirIncludeFilters)
                dirNameIncludeFilters.Remove(dif);
        }

        /* appends a string to the log queue */
        private void LogEvent(Exception ex) { LogEvent("ERROR: " + ex.GetType().Name + "; " + ex.Message); }
        private void LogEvent(string logText) {
            if (keepLog) {
                lock (log) {
                    log.Enqueue(DateTime.Now.ToString() + ": " + logText);
                }
            }
        }
    }
}
