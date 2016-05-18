using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SearchTextApp.Controls;
using SearchTextApp.Helper;
using SearchTextApp.Models;
using SearchTextApp.Support;

namespace SearchTextApp
{
    public partial class MainFrm : BaseFrm
    {
        private const string TAG_SEARCH = "SEARCH";

        public MainFrm()
        {
            this.InitializeComponent();
            this.InitializeGrid();
            this.InitializeControls();
            this.AttachEventHandler();


            this.InitializeVariables();

        }

        private void InitializeVariables()
        {
            string strRootDirectory = String.Empty;
            string[] arrRootDirectories = null;
            string fileNameFilter =String.Empty;
            string keyword = String.Empty;
#if DEBUG
            strRootDirectory = @"D:\webapps;c:\inetpub";
            fileNameFilter = "web.config";
            keyword = "system.web>";
#else
            strRootDirectory = ConfigurationManager.AppSettings["Search.Root"];
            fileNameFilter = ConfigurationManager.AppSettings["Search.Filename"];
            keyword = ConfigurationManager.AppSettings["Search.Keyword"];
#endif
            
            if (!String.IsNullOrEmpty(strRootDirectory))
            {
                if (strRootDirectory.Contains(";"))
                {
                    arrRootDirectories = strRootDirectory.Split(';');
                    if (arrRootDirectories.Length > 0)
                    {
                        foreach (var root in arrRootDirectories)
                        {
                            if (Directory.Exists(root))
                            {
                                this.RootDirectoriesListBox.Items.Add(root);
                            }
                        }
                    }
                }
                else
                {
                    if (Directory.Exists(strRootDirectory))
                    {
                        this.RootDirectoriesListBox.Items.Add(strRootDirectory);
                    }
                }
            }

            this.filenameTextBox.Text = fileNameFilter;
            this.searchStringTextBox.Text = keyword;

            this.ControlRemoveButton();
        }

        private void InitializeGrid()
        {
            this.fileListGridView.Columns.Clear();
            BindingSource bs = null;
            DataGridViewColumn colTemplate = null;

            //
            // FilePath Column
            //
            colTemplate = new DataGridViewTextBoxColumn();
            colTemplate.Name = "filePathCol";
            colTemplate.DataPropertyName = "FilePath";
            colTemplate.HeaderText = "FilePath";
            colTemplate.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colTemplate.Visible = false;
            
            this.fileListGridView.Columns.Add(colTemplate);

            //
            // Path Column
            //
            colTemplate = new DataGridViewTextBoxColumn();
            colTemplate.Name = "pathCol";
            colTemplate.DataPropertyName = "Path";
            colTemplate.HeaderText = "Path";
            colTemplate.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            this.fileListGridView.Columns.Add(colTemplate);

            //
            // Filename Column
            //
            colTemplate = new DataGridViewTextBoxColumn();
            colTemplate.Name = "filenameCol";
            colTemplate.HeaderText = "Filename";
            colTemplate.DataPropertyName = "Filename";
            colTemplate.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colTemplate.Width = 120;

            this.fileListGridView.Columns.Add(colTemplate);

            if (this.BindingSourceList.ContainsKey(this.fileListGridView.Name))
            {
                bs = this.BindingSourceList[this.fileListGridView.Name];
            }
            else
            {
                bs = this.AddBindingSource(this.fileListGridView.Name);
            }
            bs.DataSource = this.ResultFilesList;
            
            this.fileListGridView.DataSource = bs;

            this.fileListGridView.AllowUserToResizeRows = false;
        }

        private void InitializeControls()
        {
            this.RootDirectoriesListBox.SelectionMode = SelectionMode.MultiExtended;
            this.RootDirectoriesListBox.HorizontalScrollbar = true;
            this.RootDirectoriesListBox.ScrollAlwaysVisible = true;
            this.RootDirectoriesListBox.Items.Clear();

            this.RemoveButton.Enabled = false;

            this.messageLabel.Text = "준비";
            this.searchProgress.Maximum = 100;
            this.searchProgress.Minimum = 0;
            this.searchProgress.Value = 0;

            this.progressLabel.Text = String.Empty;

            this.splitContainer2.Panel2Collapsed = true;

            this.CanExport(false);
        }

        private void AttachEventHandler()
        {
            //
            // 추가 버튼 클릭
            //
            this.addButton.Click += (s, e) =>
            {
                string selectedDirectory = String.Empty;
                try
                {
                    FolderBrowserDialog dialog = new FolderBrowserDialog();
                    dialog.ShowNewFolderButton = false;
                    dialog.Description = "검색할 디렉터리를 선택합니다.";
                    if (DialogResult.OK == dialog.ShowDialog())
                    {
                        selectedDirectory = dialog.SelectedPath;
                        if (this.RootDirectoriesListBox.Items.Contains(selectedDirectory))
                        {

                        }
                        else
                        {
                            this.RootDirectoriesListBox.Items.Add(selectedDirectory);
                        }
                    }
                }
                finally
                {
                    this.ControlRemoveButton();
                }
            };

            //
            // 제거 버튼 클릭
            //
            this.RemoveButton.Click += (s, e) =>
            {
                try
                {
                    if (this.RootDirectoriesListBox.Items.Count > 0)
                    {
                        for (int i = this.RootDirectoriesListBox.SelectedItems.Count - 1; i >= 0; i--)
                        {
                            this.RootDirectoriesListBox.Items.Remove(this.RootDirectoriesListBox.SelectedItems[i]);
                        }
                    }
                }
                finally
                {
                    this.ControlRemoveButton();
                }
            };

            //
            // BackgroundWorker 생성
            //
            BackgroundWorker worker = this.AddBackgroundWorker(TAG_SEARCH);
            
            //
            // DoWork 비동기실행 
            //
            worker.DoWork += (s, e) =>
            {
                this.SearchAsync((BackgroundWorker)s, e);
            };

            //
            // ProgressChanged 비동기 실행 메세지 전달
            //
            worker.ProgressChanged += (s, e) =>
            {
                string message = String.Empty;

                if (e.UserState is SearchWorker)
                {
                    SearchWorker searchWorker = e.UserState as SearchWorker;

                    switch (searchWorker.State)
                    {
                        case SearchWorkerState.Error:
                            // 오류
                            this.messageLabel.Text = searchWorker.Message;
                            this.AppendLog("[Error]");
                            this.AppendLog(searchWorker.Exception);
                            break;
                        case SearchWorkerState.Cancel:
                            // 취소
                            this.messageLabel.Text = searchWorker.Message;

                            this.AppendLog("[Canceled]");
                            break;
                        case SearchWorkerState.Completed:
                            // 완료
                            this.messageLabel.Text = searchWorker.Message;

                            this.AppendLog("[Completed]");
                            break;
                        case SearchWorkerState.Resolve:
                            this.searchProgress.Maximum = 100;
                            this.searchProgress.Minimum = 0;
                            this.progressLabel.Text = searchWorker.DisplayText;
                            this.messageLabel.Text = searchWorker.Message;

                            this.AppendLog($"[Resolved] {searchWorker.TotalCount:n0} file{(searchWorker.TotalCount > 1 ? "s" : String.Empty)} found.");
                            // 파일 검색
                            break;
                        case SearchWorkerState.Searching:
                        default:
                            // 문자열 검색
                            this.searchProgress.Value = (int)(searchWorker.Current / searchWorker.TotalCount * 100.0);
                            this.progressLabel.Text = searchWorker.DisplayText;
                            this.messageLabel.Text = searchWorker.Message;
                            message = searchWorker.Path;
                            if (searchWorker.Hit)
                            {
                                // 
                                // 문자열이 있는 경우
                                //
                                this.ResultFilesList.Add(new ResultFile() { FilePath = searchWorker.Path });

                                //this.BindingSourceList[this.fileListGridView.Name].Add(new ResultFile() { FilePath = searchWorker.Path });
                                message += " => Found.";

                            }
                            this.AppendLog(message);
                            break;
                    }
                }
            };

            //
            // RunWorkerCompleted 비동기 실행 종료
            //
            worker.RunWorkerCompleted += (s, e) =>
            {
                try
                {
                    if (e.Error != null)
                    {

                    }
                    else if (e.Cancelled)
                    {

                    }
                    else
                    {

                    }
                }
                finally
                {
                    if (this.ResultFilesList.Count > 0)
                    {
                        this.BindingSourceList[this.fileListGridView.Name].CurrencyManager.Refresh();
                    }
                    this.fileCountLabel.Text = $"검색된 파일: {this.fileListGridView.Rows.Count:n0}";

                    this.ControlSearchControl(true);
                    this.CanExport(this.fileListGridView.Rows.Count > 0);
                    this.Cursor = Cursors.Default;
                }

            };

            //
            // 검색 버튼 클릭
            //
            this.searchButton.Click += (s, e) =>
            {
                this.AppendLog("[Click] Search button");

                this.ClearError();
                if (this.RootDirectoriesListBox.Items.Count == 0)
                {
                    this.SetError(this.RootDirectoriesListBox, "검색할 디렉터리를 추가하세요.");
                    this.addButton.Select();
                    this.addButton.Focus();
                }
                else if (this.filenameTextBox.TextLength == 0)
                {
                    this.SetError(this.filenameTextBox, "검색할 파일이름을 입력하세요.");
                    this.filenameTextBox.Select();
                    this.filenameTextBox.Focus();
                }
                else if (this.searchStringTextBox.TextLength == 0)
                {
                    this.SetError(this.searchStringTextBox, "검색할 문자열을 입력하세요.");
                    this.searchStringTextBox.Select();
                    this.searchStringTextBox.Focus();
                }
                else {

                    this.ResultFilesList.Clear();
                    this.fileListGridView.Rows.Clear();

                    SearchCondition searchCondition = new SearchCondition();
                    foreach (var item in this.RootDirectoriesListBox.Items)
                    {
                        searchCondition.RootDirectories.Add(item.ToString());
                    }
                    searchCondition.FilterForFilename = this.filenameTextBox.Text.Trim();
                    searchCondition.SearchKeywork = this.searchStringTextBox.Text.Trim();
                    searchCondition.NestedSearch = this.nestedSearchCheckBox.Checked;

                    this.Cursor = Cursors.WaitCursor;
                    this.ControlSearchControl(false);
                    this.AppendLog("[Searching]");
                    this.BackgroundWorkerList[TAG_SEARCH].RunWorkerAsync(searchCondition);
                }
            };

            //
            // 내보내기 csv
            //
            this.csvToolStripMenuItem.Click += (s, e) =>
            {
                FileHelper fileHelper = new FileHelper();
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.AutoUpgradeEnabled = true;
                dialog.DefaultExt = ".csv";
                dialog.SupportMultiDottedExtensions = true;
                dialog.Filter = "CSV 파일 (*.csv)|*.csv";
                if (DialogResult.OK == dialog.ShowDialog())
                {
                    string strMessage = fileHelper.ExportCsv(dialog.FileName, this.fileListGridView, new string[] { "FilePath" });
                    if (String.IsNullOrEmpty(strMessage))
                    {
                        this.AppendLog($"[Saved] at {dialog.FileName}");
                    }
                    else
                    {
                        this.AppendLog(strMessage);
                    }

                }
            };

            //
            // 내보내기 텍스트 파일(탭으로 분리)
            //
            this.textFileWithTabToolStripMenuItem.Click += (s, e) =>
            {
                FileHelper fileHelper = new FileHelper();
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.AutoUpgradeEnabled = true;
                dialog.DefaultExt = ".txt";
                dialog.SupportMultiDottedExtensions = true;
                dialog.Filter = "탭으로 구분된 Text 파일 (*.txt)|*.txt";
                if (DialogResult.OK == dialog.ShowDialog())
                {
                    string strMessage = fileHelper.ExportTextFileWithTabSeperator(dialog.FileName, this.fileListGridView, new string[]{ "FilePath"});
                    if (String.IsNullOrEmpty(strMessage))
                    {
                        this.AppendLog($"[Saved] at {dialog.FileName}");
                    }
                    else
                    {
                        this.AppendLog(strMessage);
                    }

                }
            };

            //
            // Console 창 제어
            //
            this.consoleToolStripMenuItem.Click += (s, e) => {
                ToolStripMenuItem item = s as ToolStripMenuItem;
                if (item != null) {
                    item.Checked = !item.Checked;
                }

                this.splitContainer2.Panel2Collapsed = !item.Checked;
            };

            //
            // About 창 열기
            //
            this.aboutToolStripMenuItem.Enabled = false;
            this.aboutToolStripMenuItem.Click += (s, e) => {
               // 사용되지 않습니다.
            };

            //
            // Grid Cell Click
            //
            this.fileListGridView.CellDoubleClick += (s, e) =>
            {
                string columnKey = String.Empty;
                string editorPath = String.Empty;
                string cellValue = String.Empty;
                string filePath = String.Empty;

                if (e.RowIndex < 0) { return; }
                ListDataGridView grid = s as ListDataGridView;
                if(grid != null)
                {
                    columnKey = grid.Columns[e.ColumnIndex].DataPropertyName;
                    cellValue = $"{grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value}";
                    filePath = $"{grid.Rows[e.RowIndex].Cells["filePathCol"].Value}";
                    if (!String.IsNullOrEmpty(cellValue))
                    {
                        if (columnKey.Equals("Filename"))
                        {
                            // File Name Column : 편집기 실행
                            editorPath = ConfigurationManager.AppSettings["TextEditor"];
                            if (String.IsNullOrEmpty(editorPath))
                            {
                                Process.Start(filePath);
                            }
                            else
                            {
                                Process.Start(editorPath, filePath);
                            }
                        }

                        if (columnKey.Equals("Path"))
                        {
                            // Path Column : 탐색기 실행
                            Process.Start(cellValue);
                        }
                    }
                    
                }
            };

            this.helpToolStripMenuItem.Click += (s, e) =>
            {
                HelpFrm frm = new HelpFrm();
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
            };

            this.exitToolStripMenuItem.Click += (s, e) => {
                this.Close();
            };

            this.FormClosing += (s, e) => {
                bool isBusy = false;
                foreach (var bgw in this.BackgroundWorkerList)
                {
                    if (bgw.Value.IsBusy)
                    {
                        isBusy = true; break;
                    }
                }

                if (isBusy)
                {
                    if (DialogResult.Yes == MessageBox.Show("검색이 진행중입니다. 검색을 중지하시겠습니까?\r\n\r\n> 작업 취소는 시간이 소요될 수 있으므로 잠시후 다시 종료를 시도하세요.", "확인", MessageBoxButtons.YesNo))
                    {
                        foreach (var bgw in this.BackgroundWorkerList)
                        {
                            if (bgw.Value.IsBusy)
                            {
                                bgw.Value.CancelAsync();
                            }
                        }
                    }

                    e.Cancel = true;

                }
            };
        }

        public void ControlRemoveButton()
        {
            this.RemoveButton.Enabled = this.RootDirectoriesListBox.Items.Count > 0;
        }

        public void ControlSearchControl(bool enabled)
        {
            this.splitContainer1.Panel1.Enabled = enabled;
        }

        private void SearchAsync(BackgroundWorker worker, DoWorkEventArgs e)
        {
            SearchCondition searchCondition = null;
            FileHelper fileHelper = null;
            long total = 0L;        // 전체
            long current = 0L;      // 현재
            long hitCount = 0L;     // 포함
            bool hit = false;       // 문자열 존재 여부
            string path = String.Empty;

            try
            {
                if (e.Argument is SearchCondition)
                {
                    searchCondition = e.Argument as SearchCondition;
                }

                if (searchCondition == null)
                {
                    worker.ReportProgress(0, new SearchWorker
                    {
                        State = SearchWorkerState.Error,
                        Message = "검색 조건를 찾을 수 없습니다."
                    });
                }
                else
                {
                    fileHelper = new FileHelper();

                    List<string> files = fileHelper.FindFile(searchCondition);
                    total = files.Count;

                    worker.ReportProgress(0, new SearchWorker
                    {
                        State = SearchWorkerState.Resolve,
                        Message = $"{total:n0} file{(total > 1 ? "(s)": String.Empty)} found.",
                        DisplayText = $"0/{total:n0}",
                        TotalCount = total,
                        Current = 0
                    });

                    foreach (string file in files)
                    {
                        current++;

                        path = String.Empty;
                        hit = false;
                        path = file;    // 문자열을 검색할 파일 경로

                        if (worker.CancellationPending)
                        {
                            worker.ReportProgress(0, new SearchWorker
                            {
                                State = SearchWorkerState.Cancel,
                                Message = $"취소됨",
                                DisplayText = $"취소됨",
                                TotalCount = total,
                                Current = current
                            });
                            break;
                        }

                        if (fileHelper.FindString(file, searchCondition.SearchKeywork))
                        {
                            // found
                            hit = true;
                            hitCount++;
                        }

                        worker.ReportProgress(50, new SearchWorker
                        {
                            State = SearchWorkerState.Searching,
                            Message = $"처리중",
                            DisplayText = $"{current:n0}/{total:n0} Found{hitCount:n0}",
                            TotalCount = total,
                            Current = current,
                            Path = path,
                            HitCount = hitCount,
                            Hit = hit
                        });
                    }

                    worker.ReportProgress(100, new SearchWorker
                    {
                        State = SearchWorkerState.Completed,
                        Message = $"완료",
                        DisplayText = $"{current:n0}/{total:n0} Found {hitCount:n0}",
                        TotalCount = total,
                        Current = current,
                        HitCount = hitCount
                    });
                }
            }
            catch (Exception ex)
            {
                worker.ReportProgress(0, new SearchWorker
                {
                    State = SearchWorkerState.Error,
                    Message = $"오류",
                    DisplayText = $"{current:n0}/{total:n0} Found{hitCount:n0}",
                    TotalCount = total,
                    Current = current,
                    HitCount = hitCount,
                    Exception = ex
                });

            }
        }

        public void AppendLog(string format, params object[] args)
        {
            this.logTextBox.AppendText(String.Format(format, args));
            this.logTextBox.AppendText("\r\n");
        }

        public void AppendLog(string message)
        {
            this.AppendLog("{0}", message);
        }

        private void AppendLog(Exception ex)
        {
            this.AppendLog("[Error] ---------------------------");
            this.AppendLog(ex.Message);
            this.AppendLog(ex.StackTrace);
        }

        public void ClearLog()
        {
            this.logTextBox.Clear();
        }

        public void CanExport(bool yes)
        {
            this.csvToolStripMenuItem.Enabled = yes;
            this.textFileWithTabToolStripMenuItem.Enabled = yes;
        }

        private List<ResultFile> ResultFilesList
        {
            get
            {
                if(this._ResultFilesList == null) { this._ResultFilesList = new List<ResultFile>(); }
                return _ResultFilesList;
            }
        }

        private List<ResultFile> _ResultFilesList;
    }
}
