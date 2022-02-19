using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace DuplicateSearcher {
    public class DSConsole {
        /* private members */
        private bool showHelp = false; //determines whether instructions are shown
        private bool showBreaks = false; //determines whether breaks are used in the help
        private int lineNum = 0; //the current line number (used for breaks)
        private bool showMatchGroups = false;
        private StreamWriter outputFile = null;
        private StreamWriter logFile = null;
        private bool onlyOutputFile = false;
        private bool appendOutputFile = true;
        private string outputFilePath = "";
        private string logFilePath = "";
        private bool appendLogFile = true;
        private static ConsoleKeyInfo nullKey = new ConsoleKeyInfo('\0', ConsoleKey.Backspace, false, false, false);
        private ConsoleKeyInfo lastKey = nullKey;
        private bool isGUI = false;
        private int currentMatchGroupTotal = 0;


        //properties
        /* the ones necessary */
        public bool ShowHelp { get { return showHelp; } set { showHelp = value; } }
        public string OutputFilePath { get { return outputFilePath; } set { outputFilePath = value; } }
        public bool OnlyOutputFile { get { return onlyOutputFile; } set { onlyOutputFile = value; } }
        public bool AppendOutputFile { get { return appendOutputFile; } set { appendOutputFile = value; } }
        public bool ShowBreaks { get { return showBreaks; } set { showBreaks = value; } }
        public bool ShowMatchGroups { get { return showMatchGroups; } set { showMatchGroups = value; } }
        public string LogFilePath { get { return logFilePath; } set { logFilePath = value; } }
        public bool AppendLogFile { get { return appendLogFile; } set { appendLogFile = value; } }
        public bool IsGUI { get { return !DSMain.IsConsole; } }

        
        //public methods
        /* constructure */
        public DSConsole() {
        }

        /* Runs the model and outputs the results */
        public void Go(string[] args, DSModel model) {
            bool paused = false; //indicates the user has paused
            bool userAborted = false; //flag indicating the user quit
            IEnumerator<DSMatchGroup> matchGroups = null; //all groups of matches
            bool finishedShowingMatchGroups = false; //indicates that the main loop has finished showing the matches

            /* on error, show error, then exit */
            try {
                /* check to make sure we have params */
                if (args.Length == 0) {
                    OutputReadme(false, model);
                    return;
                }

                /* after parsing the cmd line, run the model */
                if (ParseCmdArgs(model, args)) {
                    /* if the help switch was used, then forget about execution */
                    if (showHelp) {
                        OutputReadme(true, model);
                    } else {
                        /* checks all passed in params and throws error if there is a problem */
                        VerifyParameters();

                        /* output header */
                        WriteLine("DuplicateSearcher search started at " + DateTime.Now.ToString() + ".");

                        /* begin searching */
                        model.Start();

                        /* see if there are any matches at first */
                        Queue<DSMatch> newMatches = model.GetNewMatches();

                        /* loop if it is still started */
                        while ((!Environment.HasShutdownStarted) && (!userAborted) && (model.IsStarted || (newMatches.Count > 0) || (showMatchGroups && (!finishedShowingMatchGroups)))) {
                            /* if we are not running, the user paused and we should add a delay */
                            if (paused) {
                                PerformSleep();
                            } else {
                                /* if the user wants to see match groups, then we must show them after the search is complete */
                                if (showMatchGroups && (!model.IsStarted) && (newMatches.Count == 0) && (!finishedShowingMatchGroups)) {
                                    /* get the enumerator */
                                    if (matchGroups == null) {
                                        WriteLine("");
                                        WriteLine("Showing grouped matches:");
                                        matchGroups = model.MatchGroups.GetEnumerator();
                                    }

                                    /* iterate over all groups and output */
                                    if (matchGroups.MoveNext()) {
                                        DSMatchGroup group = matchGroups.Current;

                                        /* if groups.Current is null, then we are done */
                                        if (group == null) {
                                            matchGroups = null;
                                            finishedShowingMatchGroups = true;
                                            currentMatchGroupTotal = 0;
                                        } else {
                                            WriteMatchGroup(group);
                                        }
                                    } else {
                                        matchGroups = null;
                                        finishedShowingMatchGroups = true;
                                        currentMatchGroupTotal = 0;
                                    }
                                } else {
                                    /* if the user wants to see the matches as they are found */
                                    if (model.TrackNewMatches) {
                                        /* see if we already showed all of the matches, and if not, to display them */
                                        if (newMatches.Count > 0) {
                                            DSMatch match = newMatches.Dequeue();
                                            WriteLine("");
                                            WriteLine("Match " + (match.Index + 1).ToString() + " (" + match.ParentGroup.UniqueValue + "):");
                                            WriteLine(match.Matched.FSI.FullName);
                                            WriteLine(match.MatchedTo.FSI.FullName);
                                        } else {
                                            /* get next batch of matches to be displayed */
                                            if (model.NewMatchCount > 0) {
                                                newMatches = model.GetNewMatches();
                                            } else {
                                                newMatches.Clear();
                                            }

                                            /* !! main thread sleeper that makes sure loop does not peg the processor !! */
                                            if (newMatches.Count <= 0)
                                                PerformSleep();
                                        }
                                    }
                                }
                            }

                            /* scan for keystrokes */
                            ConsoleKeyInfo cki = nullKey;
                            if (!isGUI) {
                                if (Console.KeyAvailable) {
                                    cki = Console.ReadKey(true);
                                } else if (lastKey != nullKey) {
                                    cki = lastKey;
                                    lastKey = nullKey;
                                }
                            }
                            
                            /* handle keystroke */
                            if (cki != nullKey) {
                                switch (cki.Key) {
                                    case ConsoleKey.P: //for pausing
                                        if (paused) {
                                            if (model.IsStarted)
                                                model.Resume();
                                            paused = false;
                                        } else {
                                            if (model.IsRunning)
                                                model.Pause();
                                            paused = true;
                                            WriteLine(false, "Searching and comparisons have been paused (" + DateTime.Now.ToString() + ").");
                                            WriteLine(false, "Press 'P' to pause/continue. Press 'Q' or 'Esc' to quit.");
                                        }
                                        break;

                                    case ConsoleKey.Q: //for quitting
                                    case ConsoleKey.Escape:
                                        model.Stop();
                                        newMatches.Clear();
                                        userAborted = true;
                                        break;

                                    default:
                                        break;
                                }
                            }

                            /* output log */
                            WriteLog(model);
                        } //main loop

                        /* show end */
                        WriteLine("");
                        if (userAborted)
                            WriteLine("DuplicateSearcher aborted by user at " + DateTime.Now.ToString());
                        else
                            WriteLine("DuplicateSearcher search completed at " + DateTime.Now.ToString());
                        WriteLine("Total files compared: " + model.TotalFilesCompared.ToString() + "; total dirs compared: " + model.TotalDirectoriesCompared.ToString());
                        if (model.TrackNewMatches)
                            WriteLine("Total new matches: " + model.TotalNewMatchCount.ToString());
                        WriteLine("Total matching directories/files: " + model.TotalMatchedCount.ToString());
                        WriteLine("Total match groups: " + model.TotalMatchedGroupCount.ToString());

                        /* clear the model */
                        model.MatchGroups.Clear();
                    }
                }
            } catch (Exception ex) {
                /* output the error and return false */
                WriteLine("");
                WriteLine(true, "Error: " + ex.Message, true);
                WriteLine(false, "");
                OutputReadmeHelp();
                model.Stop();
            }

            /* if we have an output file, close it */
            CloseOutputFile();

            /* closes the log file */
            CloseLogFile();
        }

        /* parases the command line to set the model's options and run, or to list the readme */
        public bool ParseCmdArgs(DSModel model, string[] args) {
            /* iterate over the arguments and combine as necessary */
            string param = "";
            for (int i = 0; i < args.Length; i++) {
                string arg = args[i];

                if ((arg.IndexOf('+') == 0) || (arg.IndexOf('=') > 0) || (arg.IndexOf('/') == 0)) {
                    if (param.Length > 0)
                        ProcessParam(model, param);
                    param = arg;
                } else {
                    param += " " + arg;
                }
            }

            /* run a remaining param */
            if (param.Length > 0)
                ProcessParam(model, param);

            return true;
        }

        /* closes the log file */
        public void CloseLogFile() {
            if (logFile != null)
                logFile.Close();
            logFile = null;
        }

        /* outputs to a log file if one is available */
        public void WriteLog(DSModel model) {
            if (logFilePath.Length > 0) {
                if (logFile == null) {
                    if (appendLogFile)
                        logFile = new StreamWriter(File.Open(logFilePath, FileMode.Append));
                    else
                        logFile = new StreamWriter(File.Open(logFilePath, FileMode.Create));
                }

                /* write line to log file */
                string[] logs = model.GetNewLogItems();
                for (int i = 0; i < logs.Length; i++) 
                    logFile.WriteLine(logs[i]);
            }
        }

        /* closes the output file */
        public void CloseOutputFile() {
            if (outputFile != null)
                outputFile.Close();
            outputFile = null;
        }

        /* outputs a match group */
        public void WriteMatchGroup(DSMatchGroup group) {
            /* check to see if there are more than one matches */
            if (group.Matches.Count > 1) { //then output the list of files
                WriteLine("");
                WriteLine("Match Group " + (++currentMatchGroupTotal).ToString() + ", grouped by: " + group.Value);
                for (int i = 0; ((i < group.Matches.Count) && ((lastKey.Key != ConsoleKey.Q) && (lastKey.Key != ConsoleKey.Escape))); i++)
                    WriteLine(group.Matches[i].FSI.FullName);
            }
        }

        /* perform a reset of various state */
        public void Reset() {
            currentMatchGroupTotal = 0;
        }

        /* static general method for ouput of the program to file and/or console */
        public void WriteLine(string line) { WriteLine(true, line); }
        public void WriteLine(bool toFile, string line) { WriteLine(toFile, line, false); }
        public void WriteLine(bool toFile, string line, bool forceConsoleWrite) {
            const int messHeight = 1; //height of the press any key message

            /* see if we only wanted file output */
            if ((!onlyOutputFile) || (forceConsoleWrite)) {
                /* if our current line number advances beyond the console window, output a message and wait for keystroke */
                lineNum++; //increment to the line number we will be on
                if (showBreaks) {
                    if (lineNum % (Console.WindowHeight - messHeight) == 0) {
                        WriteLine(false, "<press any key to continue...>");
                        if (!isGUI) lastKey = Console.ReadKey(true); //set last key to be handled by the main loop
                    }
                }

                /* output the line */
                if (!isGUI) Console.WriteLine(line);
            }

            /* if we want to write to a file */
            if (toFile) {
                if (outputFilePath.Length > 0) {
                    if (outputFile == null) {
                        if (appendOutputFile)
                            outputFile = new StreamWriter(File.Open(outputFilePath, FileMode.Append));
                        else
                            outputFile = new StreamWriter(File.Open(outputFilePath, FileMode.Create));
                    }
                    outputFile.WriteLine(line);
                }
            }
        }


        //private methods
        /* manipulates the model based on passed in params */
        private void ProcessParam(DSModel model, string param) {
            /* determine if add dir or set a value */
            if (param.IndexOf('+') == 0) {
                string dirname = param.Substring(1);
                if (Directory.Exists(dirname))
                    model.AddInitialSearchPath(dirname);
                else
                    throw new DSCantFindPath("Could not find path: " + dirname + ".");
            } else if (param.IndexOf('=') > 0) {
                string[] ps = param.Split(new char[1] { '=' });
                string setname = ps[0].ToUpper();
                string val = ps[1];

                /* switch the set name */
                switch (setname) {
                    case "CRITERIAFILE":
                        LoadCriteria(model, val);
                        break;
                    case "BUILTINCRITERIA":
                        LoadBuiltinCriteria(model, val);
                        break;
                    case "LOGFILE":
                        logFilePath = val;
                        model.KeepLog = logFilePath.Length > 0 ? true : false;
                        break;
                    case "APPENDLF":
                        appendLogFile = bool.Parse(val);
                        break;
                    case "MATCHDIRS":
                        model.MatchDirectories = bool.Parse(val);
                        break;
                    case "MATCHFILES":
                        model.MatchFiles = bool.Parse(val);
                        break;
                    case "MINFILESIZE":
                        model.MinFileSize = long.Parse(val);
                        break;
                    case "MAXFILESIZE":
                        model.MaxFileSize = long.Parse(val);
                        break;
                    case "REMOVENONALPHA":
                        model.RemoveNonAlphaCharsFromName = bool.Parse(val);
                        break;
                    case "REMOVENUMBERS":
                        model.RemoveNumberCharsFromName = bool.Parse(val);
                        break;
                    case "SEARCHSUBDIRS":
                        model.SearchSubdirectories = Boolean.Parse(val);
                        break;
                    case "SEARCHMODE":
                        model.SearchMode = (DSSearchModes)int.Parse(val);
                        break;
                    case "NCMODE":
                        model.NameComparisonMode = (DSNameComparisonMode)int.Parse(val);
                        break;
                    case "CCMODE":
                        model.ContentComparisonMode = (DSContentComparisonMode)int.Parse(val);
                        break;
                    case "HEADERFOOTERSIZE":
                        model.HeaderAndFooterByteCount = Int32.Parse(val);
                        break;
                    case "SHOWNEWMATCHES":
                        model.TrackNewMatches = bool.Parse(val);
                        break;
                    case "SHOWMATCHGROUPS":
                        showMatchGroups = bool.Parse(val);
                        break;
                    case "OUTPUTFILE":
                        outputFilePath = val;
                        break;
                    case "ONLYOUTPUTFILE":
                        onlyOutputFile = bool.Parse(val);
                        break;
                    case "APPENDOF":
                        appendOutputFile = bool.Parse(val);
                        break;
                    case "DEFAULTFILTERS":
                        model.UseDefaultFilters = bool.Parse(val);
                        break;
                    case "FILEINCLUDEFILTERS":
                        string[] includeFileFilters = val.Split(';');
                        model.FileNameIncludeFilters.Clear();
                        foreach (string ifilter in includeFileFilters) { model.FileNameIncludeFilters.Add(ifilter); }
                        break;
                    case "FILEEXCLUDEFILTERS":
                        string[] excludeFileFilters = val.Split(';');
                        model.FileNameExcludeFilters.Clear();
                        foreach (string efilter in excludeFileFilters) { model.FileNameExcludeFilters.Add(efilter); }
                        break;
                    case "DIRINCLUDEFILTERS":
                        string[] includeDirFilters = val.Split(';');
                        model.DirNameIncludeFilters.Clear();
                        foreach (string ifilter in includeDirFilters) { model.DirNameIncludeFilters.Add(ifilter); }
                        break;
                    case "DIREXCLUDEFILTERS":
                        string[] excludeDirFilters = val.Split(';');
                        model.DirNameExcludeFilters.Clear();
                        foreach (string efilter in excludeDirFilters) { model.DirNameExcludeFilters.Add(efilter); }
                        break;
                    case "MERGEFILTERS":
                        model.MergeFilters = bool.Parse(val);
                        break;
                    case "MATCHSIZES":
                        model.MatchSizes = bool.Parse(val);
                        break;
                    case "MATCHNAMEORCONTENT":
                        model.MatchtNameORContent = bool.Parse(val);
                        break;
                    case "ONLYGROUPMATCH":
                        model.NewMatchesToAllInMatchGroup = (!bool.Parse(val));
                        break;
                    case "MATCHFILESTODIRS":
                        model.MatchFilesToDirectories = bool.Parse(val);
                        break;
                    case "MATCHDIRCONTENTS":
                        model.MatchDirectoryContents = bool.Parse(val);
                        break;
                    case "IGNOREEXTENSION":
                        model.IgnoreExtensions = bool.Parse(val);
                        break;
                    case "MAXSEARCHTHREADS":
                        model.ThreadCount = int.Parse(val);
                        break;
                    default:
                        throw new Exception("Unrecognized criterion/value parameter: " + setname + "=" + val + ".");
                }
            } else if (param.IndexOf('/') == 0) {
                string switchName = param.Substring(1);

                /* determine which switch and execute */
                switch (switchName.ToUpper()) {
                    case "?":
                    case "HELP":
                        showHelp = true;
                        break;
                    case "BREAKS":
                        showBreaks = true;
                        break;
                    default:
                        throw new Exception("Unrecognized switch: /" + switchName + ".");
                }
            } else if (param.Trim().Length > 0) {
                throw new Exception("Incorrect syntax.");
            } else {
                throw new Exception("Unknown error while parsing criteria.");
            }
        }

        /* lists the command line options */
        private void OutputReadme(bool showInstructions, DSModel model) {
            /* start writing the readme */
            WriteLine(false, "DuplicateSearcher by Timothy Toohill.");
            WriteLine(false, "Visit www.duplicatesearcher.com for more information, updates, and help.");
            WriteLine(false, "(C) Copyright 2006-2008 Timothy Toohill");
            if (showInstructions) {
                WriteLine(false, "");
                WriteLine(false, "Instructions:");
                WriteLine(false, "DuplicateSearcher finds duplicate files or directories within specified");
                WriteLine(false, "locations. Because the criteria for DuplicateSearcher are extensive, they");
                WriteLine(false, "can also be stored within a text file and supplied to DuplicateSearcher via");
                WriteLine(false, "the 'CriteriaFile' option (see the examples below). Note that items within the");
                WriteLine(false, "brackets ('[' and ']') are optional. Use the '+' character followed by a");
                WriteLine(false, "directory name to add it to the list of directories to search. During the");
                WriteLine(false, "search process, press the 'Q' or 'Esc' key to quit and the 'P' key to pause.");
            }
            WriteLine(false, "");
            WriteLine(false, "Criterion     (default) Description");
            WriteLine(false, "-------------------------------------------------------------------------------");
            WriteLine(false, "CriteriaFile     (none) Text file that contains program switches/criteria.");
            WriteLine(false, "BuiltinCriteria  (none) Name of built-in criteria to use.");
            WriteLine(false, "\t\t\tOnly the following values are available:");
            WriteLine(false, "\t\t\tEverything.ini: Compares all files/dirs.");
            WriteLine(false, "\t\t\tAllMedia.ini: Only media files are compared.");
            WriteLine(false, "\t\t\tVideo.ini: Only video files are compared.");
            WriteLine(false, "\t\t\tMusic.ini: Only music files are compared.");
            WriteLine(false, "\t\t\tPictures.ini: Only image files are compared.");
            WriteLine(false, "\t\t\tDocuments.ini: Only document files are compared.");
            WriteLine(false, "\t\t\tDevelopersFiles.ini: Development-related files.");
            WriteLine(false, "LogFile          (none) Text file that contains logs of events.");
            WriteLine(false, "AppendLF         (" + appendLogFile.ToString() + ") AppendLogFile. Determines if the specified log file");
            WriteLine(false, "\t\t\tis appended (if false, the file is overwritten).");
            WriteLine(false, "OutputFile       (none) Text file that contains the results of the search.");
            WriteLine(false, "OnlyOutputFile  (" + onlyOutputFile.ToString() + ") Determines if output is only added to the output file");
            WriteLine(false, "\t\t\t(does not output to the console).");
            WriteLine(false, "\t\t\tValid values are 'true' or 'false'.");
            WriteLine(false, "AppendOF         (" + appendOutputFile.ToString() + ") AppendOutputFile. Determines if the specified output");
            WriteLine(false, "\t\t\tfile is appended (if false, the file is overwritten).");
            WriteLine(false, "SearchMode          (" + ((int)model.SearchMode).ToString() + ") Determines how the search is performed.");
            WriteLine(false, "\t\t\tValid values are 0 and 1.");
            WriteLine(false, "\t\t\tValue 0: Top down; starts at topmost dir and goes down.");
            WriteLine(false, "\t\t\tValue 1: Bottom up; starts at deepest dir and goes up.");
            WriteLine(false, "SearchSubDirs    (" + model.SearchSubdirectories.ToString() + ") Determines whether subdirectories are searched.");
            WriteLine(false, "MatchDirs       (" + model.MatchDirectories.ToString() + ") Determines whether directories are compared to others.");
            WriteLine(false, "MatchFiles       (" + model.MatchFiles.ToString() + ") Determines whether files are compared to each other.");
            WriteLine(false, "MatchFilesToDirs (" + model.MatchFilesToDirectories.ToString() + ") Determines whether files are matched to dirs.");
            WriteLine(false, "RemoveNonAlpha  (" + model.RemoveNonAlphaCharsFromName.ToString() + ") Removes non-alphanumeric chars from the name before");
            WriteLine(false, "\t\t\tmaking comparisons.");
            WriteLine(false, "RemoveNumbers   (" + model.RemoveNonAlphaCharsFromName.ToString() + ") Removes number characters from the file name before");
            WriteLine(false, "\t\t\tmaking comparisons.");
            WriteLine(false, "IgnoreExtension (" + model.IgnoreExtensions.ToString() + ") Determines if file extensions are ignored while");
            WriteLine(false, "\t\t\tcomparing files and directories.");
            WriteLine(false, "MinFileSize         (" + model.MinFileSize.ToString() + ") Files less than this size (in bytes) are filtered.");
            WriteLine(false, "MaxFileSize      (" + model.MaxFileSize.ToString("0e00") + ") Files greater than this size (in bytes) are filtered.");
            WriteLine(false, "NCMode              (" + ((int)model.NameComparisonMode).ToString() + ") Name Comparison Mode.");
            WriteLine(false, "\t\t\tValid values are: 0, 1, or 2.");
            WriteLine(false, "\t\t\tValue 0: the names are not to be compared.");
            WriteLine(false, "\t\t\tValue 1: the names must completely match.");
            WriteLine(false, "\t\t\tValue 2: the SOUNDEX is used to match names.");
            WriteLine(false, "CCMode              (" + ((int)model.ContentComparisonMode).ToString() + ") Content Comparison Mode.");
            WriteLine(false, "\t\t\tValid values are: 0, 1, 2, or 3.");
            WriteLine(false, "\t\t\tValue 0: the contents are not to be compared.");
            WriteLine(false, "\t\t\tValue 1: the entire contents are to be compared.");
            WriteLine(false, "\t\t\tValue 2: the first " + DSModel.defaultHeaderAndFooterByteCount.ToString() + " bytes are compared.");
            WriteLine(false, "\t\t\tValue 3: the first and last " + DSModel.defaultHeaderAndFooterByteCount.ToString() + " bytes are compared.");
            WriteLine(false, "MatchDirContents (" + model.MatchDirectoryContents.ToString() + ") Determines if the top-level contents of a directory are");
            WriteLine(false, "\t\t\tused to compare directories.");
            WriteLine(false, "HeaderFooterSize  (" + model.HeaderAndFooterByteCount.ToString() + ") Determines size of the header and footer (in bytes)");
            WriteLine(false, "\t\t\tthat is used for content comparison.");
            WriteLine(false, "NameORContent   (" + model.MatchtNameORContent.ToString() + ") Determines if a match occurs on name OR content. Only");
            WriteLine(false, "\t\t\tapplies when both NCMode and CCMode are not 0.");
            WriteLine(false, "MatchSizes       (" + model.MatchSizes.ToString() + ") Determines whether file sizes are compared. Used");
            WriteLine(false, "\t\t\teven if CCMode and/or NCMode are 0.");
            WriteLine(false, "ShowNewMatches   (" + model.TrackNewMatches.ToString() + ") Determines whether matches are shown as they are found.");
            WriteLine(false, "\t\t\tSetting to 'true' slows performance.");
            WriteLine(false, "OnlyGroupMatch  (" + model.NewMatchesToAllInMatchGroup.ToString() + ") Determines if new matches occur only to the group.");
            WriteLine(false, "ShowMatchGroups (" + showMatchGroups.ToString() + ") Determines whether all groups of matches are shown.");
            WriteLine(false, "\t\t\tGroups are shown AFTER the search is complete.");
            WriteLine(false, "\t\t\tThere will be a delay while the search is completed.");
            WriteLine(false, "DefaultFilters   (" + model.UseDefaultFilters.ToString() + ") Determines whether default name filters are used.");
            WriteLine(false, "\t\t\tDefault filters exclude system files.");
            WriteLine(false, "FileIncludeFilters   () Semicolon-seperated list of inclusion filters.");
            WriteLine(false, "\t\t\tFilters are applied to file names.");
            WriteLine(false, "FileExcludeFilters   () Semicolon-seperated list of exclusion filters.");
            WriteLine(false, "\t\t\tFilters are applied to file names.");
            WriteLine(false, "DirIncludeFilters    () Semicolon-seperated list of inclusion filters.");
            WriteLine(false, "\t\t\tFilters are applied to directory names.");
            WriteLine(false, "DirExcludeFilters    () Semicolon-seperated list of exclusion filters.");
            WriteLine(false, "\t\t\tFilters are applied to directory names.");
            WriteLine(false, "MergeFilters    (" + model.MergeFilters.ToString() + ") Determines if the file filters also apply to the dir");
            WriteLine(false, "\t\t\tfilters and visa versa.");
            WriteLine(false, "MaxSearchThreads    (" + model.ThreadCount.ToString() + ") Determines the number of threads used to search for");
            WriteLine(false, "\t\t\tfiles/dirs. Value of 0 means thread count is automatic.");
            WriteLine(false, "-------------------------------------------------------------------------------");
            WriteLine(false, "");
            WriteLine(false, "Syntax:");
            WriteLine(false, "\tdsc.exe [/switch] +dir1 [+dir2] [+dirX] [<criterion>=<value>]");
            WriteLine(false, "");
            WriteLine(false, "Examples:");
            WriteLine(false, "\tdsc.exe /? /breaks");
            WriteLine(false, "\tdsc.exe +c:\\");
            WriteLine(false, "\tdsc.exe +c:\\ +d:\\ BuiltinCriteria=Music.ini");
            WriteLine(false, "\tdsc.exe CompareDir=false +C:\\Music +D:\\Downloads\\Music +E:\\");
            WriteLine(false, "\tdsc.exe /breaks CriteriaFile=C:\\DSCriteria.ini ShowMatchGroups=true");
            WriteLine(false, "\tdsc.exe +c:\\ ExcludeFilters=*.cpp;*.c OutputFilePath=c:\\duplicates.txt");
            WriteLine(false, "");
            WriteLine(false, "Switches:");
            WriteLine(false, "\t/?, /help : Shows instructions in the help.");
            WriteLine(false, "\t/breaks   : Uses screen breaks during output.");
        }

        /* outputs a quick note about how to see commandline options */
        private void OutputReadmeHelp() {
            WriteLine(false, "To see the command line options, you can use the /? or /help switches:");
            WriteLine(false, "\tdsc.exe /?");
            WriteLine(false, "\tdsc.exe /help");
        }

        /* check passed in parameters */
        private void VerifyParameters() {
            /* check the onlyOutputFile flag and outputFile var */
            if (outputFilePath.Length == 0)
                if (onlyOutputFile)
                    throw new Exception("You must specify an OutputFile if output is only going to be directed to a file.");
        }

        /* loads criteria form a file */
        public void LoadCriteria(DSModel model, string fileName) { LoadCriteria(model, File.ReadAllLines(fileName)); }
        public void LoadCriteria(DSModel model, string[] lines) {
            /* clear the model */
            model.FileNameExcludeFilters.Clear();
            model.FileNameIncludeFilters.Clear();
            model.DirNameExcludeFilters.Clear();
            model.DirNameIncludeFilters.Clear();
            
            /* load the whole file */
            string[] pars = lines;

            /* iterate through every line */
            for (int i = 0; i < pars.Length; i++)
                if (pars[i].ToUpper().IndexOf("CRITERIAFILE") >= 0)
                    throw new Exception("The 'CriteriaFile' criterion can not be specified in a criteria file.");
            ParseCmdArgs(model, pars);
        }

        /* loads criteria from a built-in resource */
        public void LoadBuiltinCriteria(DSModel model, string name) {
            string all = DSUtilities.GetEmbeddedResourceString("Resources.Criteria." + name.ToUpper());

            all = all.Replace("\r\n", "\n"); //just one char to divide lines

            /* load it */
            LoadCriteria(model, all.Split(new char[] { '\n' }));
        }

        /* saves all settings from the model to a file */
        public void SaveCriteria(DSModel model, string fileName) {
            StreamWriter file = new StreamWriter(File.Open(fileName, FileMode.Create));
            string allCriteria = GetAllCriteria(model);
            file.Write(allCriteria);
            file.Close();
        }

        /* gets the entire criteria string */
        public string GetAllCriteria(DSModel model) {
            StringWriter sw = new StringWriter();
            string result = "";

            /* write the settings */
            string[] locations = model.GetInitialSearchPaths();
            for (int i = 0; i < locations.Length; i++)
                sw.WriteLine("+" + locations[i]);
            sw.WriteLine("LogFile=" + logFilePath);
            sw.WriteLine("AppendLF=" + appendLogFile.ToString());
            sw.WriteLine("MatchDirs=" + model.MatchDirectories.ToString());
            sw.WriteLine("MatchFiles=" + model.MatchFiles.ToString());
            sw.WriteLine("MinFileSize=" + model.MinFileSize.ToString());
            sw.WriteLine("MaxFileSize=" + model.MaxFileSize.ToString());
            sw.WriteLine("IgnoreExtension=" + model.IgnoreExtensions.ToString());
            sw.WriteLine("RemoveNonAlpha=" + model.RemoveNonAlphaCharsFromName.ToString());
            sw.WriteLine("RemoveNumbers=" + model.RemoveNumberCharsFromName.ToString());
            sw.WriteLine("SearchSubDirs=" + model.SearchSubdirectories.ToString());
            sw.WriteLine("SearchMode=" + ((int)model.SearchMode).ToString());
            sw.WriteLine("NCMode=" + ((int)model.NameComparisonMode).ToString());
            sw.WriteLine("CCMode=" + ((int)model.ContentComparisonMode).ToString());
            sw.WriteLine("HeaderFooterSize=" + model.HeaderAndFooterByteCount.ToString());
            sw.WriteLine("ShowNewMatches=" + model.TrackNewMatches.ToString());
            sw.WriteLine("ShowMatchGroups=" + showMatchGroups.ToString());
            sw.WriteLine("OutputFile=" + outputFilePath);
            sw.WriteLine("OnlyOutputFile=" + onlyOutputFile.ToString());
            sw.WriteLine("AppendOF=" + appendOutputFile.ToString());
            sw.WriteLine("DefaultFilters=" + model.UseDefaultFilters.ToString());
            if (model.FileNameIncludeFilters.Count > 0)
                sw.WriteLine("FileIncludeFilters=" + DSUtilities.DSConcat(";", model.FileNameIncludeFilters.ToArray()));
            if (model.FileNameExcludeFilters.Count > 0)
                sw.WriteLine("FileExcludeFilters=" + DSUtilities.DSConcat(";", model.FileNameExcludeFilters.ToArray()));
            if (model.DirNameIncludeFilters.Count > 0)
                sw.WriteLine("DirIncludeFilters=" + DSUtilities.DSConcat(";", model.DirNameIncludeFilters.ToArray()));
            if (model.DirNameExcludeFilters.Count > 0)
                sw.WriteLine("DirExcludeFilters=" + DSUtilities.DSConcat(";", model.DirNameExcludeFilters.ToArray()));
            sw.WriteLine("MergeFilters=" + model.MergeFilters.ToString());
            sw.WriteLine("MatchSizes=" + model.MatchSizes.ToString());
            sw.WriteLine("MatchNameOrContent=" + model.MatchtNameORContent.ToString());
            sw.WriteLine("OnlyGroupMatch=" + (!model.NewMatchesToAllInMatchGroup).ToString());
            sw.WriteLine("MatchFilesToDirs=" + model.MatchFilesToDirectories.ToString());
            sw.WriteLine("MatchDirContents=" + model.MatchDirectoryContents.ToString());
            sw.WriteLine("MaxSearchThreads=" + model.ThreadCount.ToString());

            /* write the switches */
            if (showBreaks)
                sw.WriteLine("/breaks");
            if (showHelp)
                sw.WriteLine("/?");

            /* get the result */
            result = sw.GetStringBuilder().ToString();

            /* close file and return */
            sw.Close();

            return result;
        }

        /* thread pacer */
        private void PerformSleep() {
            Thread.Sleep(100);
            Application.DoEvents();
        }
    }
}
