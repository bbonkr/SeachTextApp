using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using SearchTextApp.Support;

namespace SearchTextApp.Helper
{
    /// <summary>
    /// 파일 처리
    /// </summary>
    public class FileHelper
    {
        /// <summary>
        /// 지정된 디렉터리에서 파일을 찾습니다.
        /// </summary>
        /// <param name="searchRootDirectory">탐색할 디렉터리</param>
        /// <param name="nestedSearch">하위 디렉터리 탐색 여부</param>
        /// <param name="filterForFile">파일이름 필터</param>
        /// <returns></returns>
        public List<string> FindFile(List<string> searchRootDirectory, bool nestedSearch, string filterForFile)
        {
            List<string> foundFilesList = new List<string>();

            if(searchRootDirectory == null || searchRootDirectory.Count == 0)
            {
                throw new Exception("검색할 디렉터리를 하나 이상 입력해야 합니다.");
            }

            if(String.IsNullOrEmpty( filterForFile))
            {
                throw new Exception("검색할 파일 이름 필터를 입력해야 합니다.");
            }

            SearchOption option = nestedSearch ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;

            foreach (string rootDirectory in searchRootDirectory)
            {
                if (Directory.Exists(rootDirectory))
                {
                    this.FindFile(rootDirectory, nestedSearch, filterForFile, ref foundFilesList);
                }
                else
                {
                    // TODO error: $"Could not find a part of the path '{rootDirectory}'.";
                }
            }

            return foundFilesList;
        }

        /// <summary>
        /// 지정된 디렉터리에서 파일을 찾습니다.
        /// </summary>
        /// <param name="parent">탐색할 디렉터리</param>
        /// <param name="nestedSearch">하위 디렉터리 탐색여부</param>
        /// <param name="filterForFile">파일이름 필터</param>
        /// <param name="filesList">찾은 파일 경로을 저장할 리스트</param>
        private void FindFile(string parent, bool nestedSearch, string filterForFile, ref List<string> filesList)
        {
            /* ------------------------------------------------------
            Directory.GetFiles 메서드를 사용하면 간단하게 탐색할 수 있지만, 
            접근권한이 없는 디렉터리가 입력되는 경우 예외가 발생합나다.
            권한관련 예외를 회피하기 위해 중첩 호출을 사용합니다.
            ------------------------------------------------------ */
            if (filesList == null) { filesList = new List<string>(); }
            try
            {
                
                if (Directory.Exists(parent))
                {
                    filesList.AddRange(Directory.GetFiles(parent, filterForFile));

                    string[] children = Directory.GetDirectories(parent);

                    if (nestedSearch && children.Length > 0)
                    {
                        foreach (string path in children)
                        {
                            // 하위 디렉터리 탐색
                            this.FindFile(path, nestedSearch, filterForFile, ref filesList);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                   
            }
        }

        /// <summary>
        /// 지정된 디렉터리에서 파일을 찾습니다.
        /// </summary>
        /// <param name="cond">탐색 조건</param>
        /// <returns></returns>
        public List<string> FindFile(SearchCondition cond)
        {
            return this.FindFile(cond.RootDirectories, cond.NestedSearch, cond.FilterForFilename);
        }

        /// <summary>
        /// 파일을 열고, 문자열을 검색하여 문자열 존재여부를 확인합니다.
        /// </summary>
        /// <param name="filepath">파일의 경로</param>
        /// <param name="keyword">검색할 문자열</param>
        /// <returns>문자열 존재여부</returns>
        public bool FindString(string filepath, string keyword)
        {
            string[] allLines = null;

            if (!File.Exists(filepath)) { throw new Exception($"파일일 존재하지 않습니다. (File: {filepath})"); }

            try
            {
                allLines = File.ReadAllLines(filepath);
            }
            catch (Exception ex)
            {
                // TODO error
                allLines = null;
            }


            if (allLines != null)
            {
                // 대소문자 구분하지 않음
                return allLines.Where(l => !String.IsNullOrEmpty(l) && l.ToUpper().Contains(keyword.ToUpper())).Count() > 0;
            }

            return false;
        }

        /// <summary>
        /// DataGridView의 내용을 텍스트 파일로 저장합니다.
        /// </summary>
        /// <param name="path">저장할 파일경로</param>
        /// <param name="delimiter">자료 구분자</param>
        /// <param name="grid">내용을 포함한 DataGridView</param>
        /// <param name="columnNames">내보낼 열의 참조; DataPropertyName 을 입력</param>
        /// <returns>메세지</returns>
        private string ExportTextFile(string path, char delimiter, Controls.ListDataGridView grid, string[] columnNames)
        {
            StringBuilder csvDataSource = new StringBuilder();
            string strMessage = String.Empty;
            string strTmp = String.Empty;
            bool exportShownDataOnly = (columnNames == null || columnNames.Length == 0);
            if (grid.Rows.Count > 0)
            {
                foreach(System.Windows.Forms.DataGridViewRow row in grid.Rows)
                {

                    foreach (System.Windows.Forms.DataGridViewCell cell in row.Cells)
                    {
                        strTmp = String.Empty;
                        if (exportShownDataOnly)
                        {
                            if (cell.Visible)
                            {
                                strTmp = $"{cell.Value}";
                            }
                        }
                        else
                        {
                            if (columnNames.Contains(cell.OwningColumn.DataPropertyName))
                            {
                                strTmp = $"{cell.Value}";
                            }
                        }

                        if (!String.IsNullOrEmpty(strTmp))
                        {

                            csvDataSource.AppendFormat("{0}{1}", strTmp, delimiter);
                        }
                    }

                    if (csvDataSource.Length > 0)
                    {
                        csvDataSource.Remove(csvDataSource.Length - 1, 1);
                        csvDataSource.AppendLine();
                    }
                }
            }
            else
            {
                strMessage = "내보내기 대상 자료가 존재하지 않습니다. [Data count: 0]";
            }

            if(csvDataSource.Length > 0)
            {
                try {
                    File.WriteAllText(path, csvDataSource.ToString());
                }catch(Exception ex)
                {
                    strMessage = ex.Message;
                }
            }
            else
            {
                strMessage = "수집된 자료가 존재하지 않습니다. [String Length: 0]";
            }

            return strMessage;
        }

        /// <summary>
        /// DataGridView의 내용을 CSV 텍스트 파일로 저장합니다.
        /// </summary>
        /// <param name="path">저장할 파일경로</param>
        /// <param name="grid">내용을 포함한 DataGridView</param>
        /// <param name="columnNames">내보낼 열의 참조; DataPropertyName 을 입력</param>
        /// <returns></returns>
        public string ExportCsv(string path, Controls.ListDataGridView grid, string[] columnNames)
        {
            char delimiter = ',';

            return ExportTextFile(path, delimiter, grid, columnNames);
        }

        /// <summary>
        /// DataGridView의 내용을 탭으로 분리된 텍스트 파일로 저장합니다.
        /// </summary>
        /// <param name="path">저장할 파일경로</param>
        /// <param name="grid">내용을 포함한 DataGridView</param>
        /// <param name="columnNames">내보낼 열의 참조; DataPropertyName 을 입력</param>
        /// <returns></returns>
        public string ExportTextFileWithTabSeperator(string path, Controls.ListDataGridView grid, string[] columnNames)
        {
            char delimiter = '\t';

            return ExportTextFile(path, delimiter, grid, columnNames);
        }
    }
}
