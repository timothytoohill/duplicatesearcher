using System;
using System.Text;

namespace DuplicateSearcher {
    public class DSSoundEx {
        //public statics
        /* calculates the soundex */
        public static string CalculateSoundEx(string text) {
            KnuthEd2SoundEx soundex = new KnuthEd2SoundEx();

            return soundex.GenerateSoundEx(text);
        }


        //private classes for implementation
        /* knuth implemtnatio */
        private class KnuthEd2SoundEx : DSISoundEx {
            public override string GenerateSoundEx(string s) {
                StringBuilder output = new StringBuilder();

                if (s.Length > 0) {
                    output.Append(Char.ToUpper(s[0]));
                    for (int i = 1; i < s.Length && output.Length < 4; i++) {
                        string c = EncodeChar(s[i]);

                        switch (Char.ToLower(s[i - 1])) {
                            case 'a':
                            case 'e':
                            case 'i':
                            case 'o':
                            case 'u':
                                output.Append(c);
                                break;
                            case 'h':
                            case 'w':
                            default:
                                if (output.Length == 1) {
                                    if (EncodeChar(output[output.Length - 1]) != c)
                                        output.Append(c);
                                } else {
                                    if (output[output.Length - 1].ToString() != c)
                                        output.Append(c);
                                }

                                break;
                        }
                    }

                    for (int i = output.Length; i < 4; i++) {
                        output.Append("0");
                    }
                }

                return output.ToString();
            }
        }

        /* used by sql server */
        private class SQLServerSoundEx : DSISoundEx {
            public override string GenerateSoundEx(string s) {
                StringBuilder output = new StringBuilder();

                if (s.Length > 0) {

                    output.Append(Char.ToUpper(s[0]));

                    for (int i = 1; i < s.Length && output.Length < 4; i++) {
                        string c = EncodeChar(s[i]);

                        if (i == 1) {
                            output.Append(c);
                        } else if (c != EncodeChar(s[i - 1])) {
                            output.Append(c);
                        }
                    }

                    for (int i = output.Length; i < 4; i++) {
                        output.Append("0");
                    }
                }

                return output.ToString();
            }
        }

        /* simple implementation */
        private class SimplifiedSoundEx : DSISoundEx {
            public override string GenerateSoundEx(string s) {
                StringBuilder output = new StringBuilder();

                if (s.Length > 0) {

                    output.Append(Char.ToUpper(s[0]));

                    for (int i = 1; i < s.Length && output.Length < 4; i++) {
                        string c = EncodeChar(s[i]);

                        if (c != EncodeChar(s[i - 1])) {
                            output.Append(c);
                        }
                    }

                    for (int i = output.Length; i < 4; i++) {
                        output.Append("0");
                    }
                }

                return output.ToString();
            }
        }

        /* miracode implementation */
        private class MiracodeSoundEx : DSISoundEx {
            public override string GenerateSoundEx(string s) {
                StringBuilder output = new StringBuilder();

                if (s.Length > 0) {
                    output.Append(Char.ToUpper(s[0]));
                    for (int i = 1; i < s.Length && output.Length < 4; i++) {
                        string c = EncodeChar(s[i]);
                        switch (Char.ToLower(s[i - 1])) {
                            case 'h':
                            case 'w':
                                break;
                            case 'a':
                            case 'e':
                            case 'i':
                            case 'o':
                            case 'u':
                                output.Append(c);
                                break;
                            default:
                                if (output.Length == 1) {
                                    if (EncodeChar(output[output.Length - 1]) != c)
                                        output.Append(c);
                                } else {
                                    if (output[output.Length - 1].ToString() != c)
                                        output.Append(c);
                                }

                                break;
                        }
                    }

                    for (int i = output.Length; i < 4; i++) {
                        output.Append("0");
                    }
                }

                return output.ToString();
            }
        }

        /* root interface */
        private abstract class DSISoundEx {
            public abstract string GenerateSoundEx(string s);

            /* encode a char based on its value */
            protected virtual string EncodeChar(char c) {
                switch (Char.ToLower(c)) {
                    case 'b':
                    case 'f':
                    case 'p':
                    case 'v':
                        return "1";
                    case 'c':
                    case 'g':
                    case 'j':
                    case 'k':
                    case 'q':
                    case 's':
                    case 'x':
                    case 'z':
                        return "2";
                    case 'd':
                    case 't':
                        return "3";
                    case 'l':
                        return "4";
                    case 'm':
                    case 'n':
                        return "5";
                    case 'r':
                        return "6";
                    default:
                        return string.Empty;
                }
            }
        }
    }
}
