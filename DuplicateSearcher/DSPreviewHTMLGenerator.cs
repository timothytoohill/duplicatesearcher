using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DuplicateSearcher {
    /* HTML struct */
    public class DSHTML {
        /* holds references */
        private string fitHTML;
        private string normalHTML;

        /* props */
        public string FitHTML { get { return fitHTML; } set { fitHTML = value; } }
        public string NormalHTML { get { return normalHTML; } set { normalHTML = value; } }

        /* constructor */
        public DSHTML() {
        }
        public DSHTML(string fitHTML, string normalHTML) {
            this.fitHTML = fitHTML;
            this.normalHTML = normalHTML;
        }
    }

    /* should generate the html for a given file */
    public class DSPreviewHTMLGenerator {
        //private members
        /* consts */
        private const string beginHTML = "<html><body onload=\"javascript:loadBody();\" style=\"background-color:#BBBBBB; margin:0 0 0 0; padding:0 0 0 0; text-align:center; \"><table id=\"contentTable\" width=\"100%\" height=\"100%\" style=\"border-width: 0px 0px 0px 0px; border-spacing: 0px; padding: 0 0 0 0; margin: 0 0 0 0;\"><tr><td id=\"contentCell\" style=\"border-width: 0px 0px 0px 0px;padding: 0px 0px 0px 0px; margin: 0 0 0 0;  font-size:80%; font-family:'Lucida Grande', Tahoma, sans-serif;\" valign=\"middle\" align=\"center\">";
        private const string endHTML = "</td></tr></table></body><script type=\"text/javascript\">function loadBody() { var img = document.getElementById(\"contentImg\"); if (img != null) img.style.visibility = 'visible'; return 0; }</script></html>";
        private const string imageResizingScript = "<script type=\"text/javascript\">function loadBody() {var contentContainer = document.body; var img = document.getElementById(\"contentImg\"); if (img.width > img.height) {var newWidth = contentContainer.clientWidth; img.height = (((newWidth * img.height) / img.width) - 30); img.width = (newWidth - 30);} else {var newHeight = contentContainer.clientHeight; img.width = (((newHeight * img.width) / img.height) - 30); img.height = (newHeight - 30); } img.style.visibility = 'visible'; return 0;}</script>";
        private const string endHTMLWithImageResizingScript = "</td></tr></table></body>" + imageResizingScript + "</html>";
        private const string defaultPreviewHTML = beginHTML + "Preview Window" + endHTML;
        private const string notSupportedHTML = beginHTML + "Not supported for preview" + endHTML;
        
        /* these are the types of files supported and the string to return (a replace is performed on the _PATH_ string within the html) */
        private Dictionary<string, DSHTML> ExtensionToHTMLRelationships = new Dictionary<string, DSHTML>(); //will always be empty; represents types that can be opened
        private Dictionary<string, DSHTML> MIMEToHTMLRelationships = new Dictionary<string, DSHTML>();
        private DSHTML defaultPreview = null;
        private DSHTML notSupported = null;
        private DSHTML imageHTML = null;
        private DSHTML videoHTML = null;
        private DSHTML audioHTML = null;


        //public properties
        /* default html */
        public DSHTML DefaultPreviewHTML { get { return defaultPreview; } }
        public DSHTML NotSupportedHTML { get { return notSupported; } }


        //public methods
        /* constructor */
        public DSPreviewHTMLGenerator() {
            LoadHTML(); //so that the strings only have to be constructed once
            LoadRelationships(); //so that they are only loaded once
        }

        /* returns whether or not the file has HTML associated with it */
        public bool HasHTML(FileSystemInfo fsi) {
            /* by default, dirs not supported */
            if (fsi is DirectoryInfo) 
                return false;

            /* get the basic mime type and see if its in ther */
            string basicMIME = GetBasicMIMEType(DSUtilities.GetFileMIMEInfo(fsi.FullName));

            if (MIMEToHTMLRelationships.ContainsKey(basicMIME))
                if (MIMEToHTMLRelationships[basicMIME] != null) //then there is some html
                    return true;

            /* get the extension and see if its they have it */
            string ext = fsi.Extension.ToLower();

            if (ExtensionToHTMLRelationships.ContainsKey(ext))
                if (ExtensionToHTMLRelationships[ext] != null) //then there is html
                    return true;

            return false;
        }

        /* returns whether the fsi should be opened by the webcontrol */
        public bool ShouldOpen(FileSystemInfo fsi) {
            /* by default, dirs should be opened */
            if (fsi is DirectoryInfo)
                return true;

            /* get the basic mime type and see if its in ther */
            string basicMIME = GetBasicMIMEType(DSUtilities.GetFileMIMEInfo(fsi.FullName));

            if (MIMEToHTMLRelationships.ContainsKey(basicMIME))
                if (MIMEToHTMLRelationships[basicMIME] == null) //then there is some html
                    return true;

            /* get the extension and see if its they have it */
            string ext = fsi.Extension.ToLower();

            if (ExtensionToHTMLRelationships.ContainsKey(ext))
                if (ExtensionToHTMLRelationships[ext] == null) //then there is html
                    return true;

            return false;
        }

        /* returns the HTML for a normal rendering of the file; NOTE that extensions override mimes IF ANY MIME OR EXTENTION IS RELATED TO NULLL, IT IS TO BE DIRECTLY OPENED */
        public DSHTML GetHTML(FileSystemInfo fsi) {
            DSHTML results = new DSHTML(); // WILL ALWAYS return HTML
            DSHTML toBeReplaced = imageHTML; //default
            string ext = fsi.Extension.ToLower();
            string basicMIME = GetBasicMIMEType(DSUtilities.GetFileMIMEInfo(fsi.FullName));

            /* EXTENSIONS OVERRIDE MIME */
            if (ExtensionToHTMLRelationships.ContainsKey(ext)) {
                toBeReplaced = ExtensionToHTMLRelationships[ext];
            } else if (MIMEToHTMLRelationships.ContainsKey(basicMIME)) {
                toBeReplaced = MIMEToHTMLRelationships[basicMIME];
            }

            /* ensure a nuller was not added to the dictionaries */
            if (toBeReplaced != null) {
                /* replace the _PATH_ */
                results.FitHTML = toBeReplaced.FitHTML.Replace("_PATH_", fsi.FullName);
                results.NormalHTML = toBeReplaced.NormalHTML.Replace("_PATH_", fsi.FullName);
            }

            return results;
        }


        //private methods
        /* loads all of the type/html relationships; EXTENSIONS MUST BE LOWER CASE; MIMES MUST BE THE FIRST PART (i.e. "audio/Winamp" the 'audio' part) */
        private void LoadRelationships() {
            /* load the mime relationships */
            MIMEToHTMLRelationships.Add("image", imageHTML);
            MIMEToHTMLRelationships.Add("video", videoHTML);
            MIMEToHTMLRelationships.Add("audio", audioHTML);
            MIMEToHTMLRelationships.Add("text", null);//default to open

            /* load the extension relationships */
            //images
            AssociateExtensionsWithHTML(GetFileExentionsForBuiltinCriteria("PICTURES.INI"), imageHTML);
            //video
            //AssociateExtensionsWithHTML(GetFileExentionsForBuiltinCriteria("VIDEO.INI"), videoHTML);
            //music
            //AssociateExtensionsWithHTML(GetFileExentionsForBuiltinCriteria("MUSIC.INI"), audioHTML);
            //text based
            ExtensionToHTMLRelationships.Add(".txt", null);
            ExtensionToHTMLRelationships.Add(".config", null);
            ExtensionToHTMLRelationships.Add(".xml", null);
            ExtensionToHTMLRelationships.Add(".c", null);
            //AssociateExtensionsWithHTML(GetFileExentionsForBuiltinCriteria("DOCUMENTS.INI"), imageHTML);
            //AssociateExtensionsWithHTML(GetFileExentionsForBuiltinCriteria("DEVELOPERSFILES.INI"), imageHTML);
        }

        /* loads all of the html that are supported; NOTE: the strings should be referenced by the class so that they do not need to be reconstructed all the time */
        private void LoadHTML() {
            /* load the defaults */
            defaultPreview = new DSHTML(defaultPreviewHTML, defaultPreviewHTML);
            notSupported = new DSHTML(notSupportedHTML, notSupportedHTML);

            /* generic for images */
            imageHTML = new DSHTML();
            imageHTML.NormalHTML = beginHTML + "<img style=\"visibility:hidden\" id=\"contentImg\" alt=\"Preview of '_PATH_' is not available.\" src=\"_PATH_\" />" + endHTML;
            imageHTML.FitHTML = beginHTML + "<img style=\"visibility:hidden\" id=\"contentImg\" alt=\"Preview of '_PATH_' is not available.\" src=\"_PATH_\" />" + endHTMLWithImageResizingScript;
            
            /* generic for video */
            videoHTML = new DSHTML();
            videoHTML.NormalHTML = beginHTML + "<OBJECT id=\"WMPlayer\" width=\"100%\" height=\"100%\" style=\"position:absolute; left:0;top:0;\" CLASSID=\"CLSID:6BF52A52-394A-11d3-B153-00C04F79FAA6\" type=\"application/x-oleobject\"><PARAM NAME=\"URL\" VALUE=\"_PATH_\"><PARAM NAME=\"AutoStart\" VALUE=\"True\"><PARAM name=\"uiMode\" value=\"full\"><PARAM name=\"PlayCount\" value=\"1\"></OBJECT>" + endHTML;
            videoHTML.FitHTML = beginHTML + "<OBJECT id=\"WMPlayer\" width=\"100%\" height=\"100%\" style=\"position:absolute; left:0;top:0;\" CLASSID=\"CLSID:6BF52A52-394A-11d3-B153-00C04F79FAA6\" type=\"application/x-oleobject\"><PARAM NAME=\"URL\" VALUE=\"_PATH_\"><PARAM NAME=\"AutoStart\" VALUE=\"True\"><PARAM name=\"uiMode\" value=\"full\"><PARAM name=\"PlayCount\" value=\"1\"></OBJECT>" + endHTML;

            audioHTML = new DSHTML();
            audioHTML.NormalHTML = beginHTML + "<OBJECT id=\"WMPlayer\" width=\"100%\" height=\"100%\" style=\"position:absolute; left:0;top:0;\" CLASSID=\"CLSID:6BF52A52-394A-11d3-B153-00C04F79FAA6\" type=\"application/x-oleobject\"><PARAM NAME=\"URL\" VALUE=\"_PATH_\"><PARAM NAME=\"AutoStart\" VALUE=\"True\"><PARAM name=\"uiMode\" value=\"full\"><PARAM name=\"PlayCount\" value=\"1\"></OBJECT>" + endHTML;
            audioHTML.FitHTML = beginHTML + "<OBJECT id=\"WMPlayer\" width=\"100%\" height=\"100%\" style=\"position:absolute; left:0;top:0;\" CLASSID=\"CLSID:6BF52A52-394A-11d3-B153-00C04F79FAA6\" type=\"application/x-oleobject\"><PARAM NAME=\"URL\" VALUE=\"_PATH_\"><PARAM NAME=\"AutoStart\" VALUE=\"True\"><PARAM name=\"uiMode\" value=\"full\"><PARAM name=\"PlayCount\" value=\"1\"></OBJECT>" + endHTML;
        }

        /* returns the basic type in the MIME type of a file */
        private string GetBasicMIMEType(string MIMEStr) {
            string[] types = MIMEStr.Split('/');
            if (types.Length > 0)
                return types[0];
            return MIMEStr;
        }

        /* gets extensions from buildin criteria */
        private string[] GetFileExentionsForBuiltinCriteria(string criteriaFileName) {
            string all = DSUtilities.GetEmbeddedResourceString("Resources.Criteria." + criteriaFileName.ToUpper());
            string[] extensionList = new string[] { };

            StringReader reader = new StringReader(all);

            /* get the extensions out of the 'fileincludefilters' */
            string line = "";
            while ((line = reader.ReadLine()) != null) {
                if (line.Contains("FileIncludeFilters")) {
                    string[] filters = line.Split(new char[] { '=' });
                    string extensions = "";

                    if (filters.Length == 2) {
                        extensions = filters[1];
                        extensions = extensions.Replace("*", "");

                        extensionList = extensions.Split(new char[] { ';' });
                    }
                }
            }

            /* release reader */
            reader.Close();

            return extensionList;
        }

        /* associates the file extnesions with the necessary html */
        private void AssociateExtensionsWithHTML(string[] extensions, DSHTML HTML) {
            foreach (string extension in extensions)
                if (!ExtensionToHTMLRelationships.ContainsKey(extension))
                    ExtensionToHTMLRelationships.Add(extension, HTML);
        }
    }




    /// <summary>
    /// Methods to remove HTML from strings.
    /// </summary>
    public static class HtmlRemoval {
        /// <summary>
        /// Remove HTML from string with Regex.
        /// </summary>
        public static string StripTagsRegex(string source) {
            return Regex.Replace(source, "<.*?>", string.Empty);
        }

        /// <summary>
        /// Compiled regular expression for performance.
        /// </summary>
        static Regex _htmlRegex = new Regex("<.*?>", RegexOptions.Compiled);

        /// <summary>
        /// Remove HTML from string with compiled Regex.
        /// </summary>
        public static string StripTagsRegexCompiled(string source) {
            return _htmlRegex.Replace(source, string.Empty);
        }

        /// <summary>
        /// Remove HTML tags from string using char array.
        /// </summary>
        public static string StripTagsCharArray(string source) {
            char[] array = new char[source.Length];
            int arrayIndex = 0;
            bool inside = false;

            for (int i = 0; i < source.Length; i++) {
                char let = source[i];
                if (let == '<') {
                    inside = true;
                    continue;
                }
                if (let == '>') {
                    inside = false;
                    continue;
                }
                if (!inside) {
                    array[arrayIndex] = let;
                    arrayIndex++;
                }
            }
            return new string(array, 0, arrayIndex);
        }
    }
}
