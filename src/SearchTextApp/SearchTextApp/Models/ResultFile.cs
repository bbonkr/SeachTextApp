using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SearchTextApp.Models
{
   public class ResultFile
    {
        public string FilePath { get; set; }

        public string Path
        {
            get
            {
                string path = String.Empty;
                if (!String.IsNullOrEmpty(this.FilePath))
                {
                    try
                    {
                        path = System.IO.Path.GetDirectoryName(this.FilePath);
                    }
                    catch (Exception ex)
                    {
                        // TODO Error
                    }
                }
                return path;
            }
        }

        public string Filename
        {
            get
            {
                string path = String.Empty;
                if (!String.IsNullOrEmpty(this.FilePath))
                {
                    try
                    {
                        path = System.IO.Path.GetFileName(this.FilePath);
                    }
                    catch (Exception ex)
                    {
                        // TODO Error
                    }
                }
                return path;
            }
        }
    }
}
