using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SearchTextApp.Support
{
    public class SearchCondition
    {
        public List<string> RootDirectories
        {
            get
            {
                if (this._RootDirectories == null) { this._RootDirectories = new List<string>(); }
                return this._RootDirectories;
            }
        }

        public bool NestedSearch { get; set; }

        public string FilterForFilename { get; set; }

        public string SearchKeywork { get; set; }

        private List<string> _RootDirectories = null;
    }
}
