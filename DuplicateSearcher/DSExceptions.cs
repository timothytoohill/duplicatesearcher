using System;
using System.Collections.Generic;
using System.Text;

namespace DuplicateSearcher {
    public class DSCantFindPath : Exception {
        public DSCantFindPath(string message) : base(message) { }
    }
}
