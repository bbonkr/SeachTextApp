using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace SearchTextApp
{
    public partial class HelpFrm : SearchTextApp.Controls.BaseFrm
    {
        public HelpFrm()
        {
            InitializeComponent();

            this.Load += (s, e) =>
            {
                // ******************************************************
                // 포함 리소스를 처리합니다.
                // /Documents/Manaual.rtf
                // ******************************************************

                string manualName = "SearchTextApp.Documents.Manual.rtf";
                string content = String.Empty;
                // 이름 확인
                //string[] names=Assembly.GetExecutingAssembly().GetManifestResourceNames();
                //foreach (var name in names)
                //{
                //    Console.WriteLine(name);
                //}
                // SearchTextApp.Documents.Manual.rtf

                using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(manualName))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        content = reader.ReadToEnd();
                        reader.Close();
                    }
                    stream.Close();
                }

                this.manualTextBox.Rtf = content;
            };
        }
    }
}
