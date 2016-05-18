using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SearchTextApp.Helper;

namespace SearchTextApp.Test
{
    [TestClass]
    public class FileHelperTest
    {
        FileHelper fileHelper = new FileHelper();

        /// <summary>
        /// 파일 검색 테스트
        /// </summary>
        [TestMethod]
        public void TestMethod1()
        {
            // ******************************************************
            // 인터넷 정보 서비스가 동작중이라면, 하나 이상은 나와야 정상으로 테스트합니다.
            // [테스트 Test 메뉴 > 실행 > 모든 테스트] 를 실행합니다.
            // ******************************************************

            List<string> rootDirectories = new List<string>();
            rootDirectories.Add(@"c:\inetpub");
            rootDirectories.Add(@"d:\webapps");
            rootDirectories.Add(@"e:\");

            string filterForFilename = "web.config";

            List<string> foundFiles = fileHelper.FindFile(rootDirectories, true, filterForFilename);

            Assert.IsNotNull(foundFiles);
            Assert.AreNotEqual(0, foundFiles.Count);
        }
    }
}
