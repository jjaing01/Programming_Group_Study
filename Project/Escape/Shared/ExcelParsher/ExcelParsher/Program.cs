using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace ExcelParsher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dirInfo = new DirectoryInfo(Constants.TableDirPath);
            NPOIAdapter excelParsher = NPOIAdapter.GetInstance();

            foreach (var File in dirInfo.GetFiles())
            {
                if (File.Extension != ".xlsx")
                    continue;

                string relativePath = Constants.TableDirPath + @"\" + File.Name;
                var filePath = Path.GetFullPath(relativePath);

                // 파일 스트림으로 엑셀 파일 열기
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    excelParsher.LoadExcel(fileStream);
                }
            }

            excelParsher.UpdateExcelSheetInfos();
        }
    }
}
