using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SearchTextApp.Support
{
    public enum SearchWorkerState
    {
        /// <summary>
        /// 파일 검색
        /// </summary>
        Resolve,  
        /// <summary>
        /// 문자열 검색
        /// </summary>       
        Searching,
        /// <summary>
        /// 완료
        /// </summary>
        Completed,
        /// <summary>
        /// 오류
        /// </summary>
        Error,
        /// <summary>
        /// 취소됨
        /// </summary>
        Cancel
    }
}
