//NPOI
using NPOI.SS.Formula.Functions;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel; // for .xlsx files
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
            var tableCommonInfos = new Dictionary<string, TableCommonInfo>();
            var di = new DirectoryInfo(Constants.TableDirPath);

            foreach (var File in di.GetFiles())
            {
                string relativePath = Constants.TableDirPath + @"\" + File.Name;
                var filePath = Path.GetFullPath(relativePath);

                // 파일 스트림으로 엑셀 파일 열기
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    // 엑셀 파일의 Workbook 로드
                    IWorkbook workbook = new XSSFWorkbook(fileStream);  // XSSFWorkbook은 .xlsx 형식 지원
                    var sheetCnt = workbook.NumberOfSheets;
                    for (var i = 0; i < sheetCnt; ++i)
                    {
                        ISheet sheet = workbook.GetSheetAt(i);  // 첫 번째 시트 가져오기

                        // 데이터 타입 파싱
                        TableCommonInfo info = new TableCommonInfo();
                        info.dataTypes = makeDataLits(sheet, Constants.DataTypeRow);
                        info.dataNames = makeDataLits(sheet, Constants.DataNameRow);

                        var fileName = Path.GetFileNameWithoutExtension(File.Name);
                        tableCommonInfos.Add(fileName, info);

                    //// 첫 번째 행 (헤더) 건너뛰기 위해 1부터 시작
                    //for (int row = 2; row <= sheet.LastRowNum; row++)
                    //{
                    //    IRow currentRow = sheet.GetRow(row);

                    //    // 각 셀의 값 읽기
                    //    int monsterId = (int)currentRow.GetCell(0).NumericCellValue; // Monster ID
                    //    string monsterName = currentRow.GetCell(1).StringCellValue;  // Monster Name
                    //    int hp = (int)currentRow.GetCell(2).NumericCellValue;  // HP
                    //    int mp = (int)currentRow.GetCell(3).NumericCellValue;  // MP
                    //    int attack = (int)currentRow.GetCell(4).NumericCellValue;  // Attack
                    //    double attackSpeed = currentRow.GetCell(5).NumericCellValue;  // Attack Speed
                    //    double speed = currentRow.GetCell(6).NumericCellValue;  // Speed
                    //    string imagePath = currentRow.GetCell(7).StringCellValue;  // Image Path

                    //    // 데이터를 출력
                    //    Console.WriteLine($"ID: {monsterId}, Name: {monsterName}, HP: {hp}, MP: {mp}, Attack: {attack}, Attack Speed: {attackSpeed}, Speed: {speed}, Image Path: {imagePath}");
                    //}
                    }
                }
            }
        }

        static List<string> makeDataLits(ISheet sheet, int _row)
        {
            List<string> types = new List<string>();

            IRow row = sheet.GetRow(_row);
            int cell = 0;

            while (true)
            {
                if (row.GetCell(cell) is null)
                    break;

                string type = row.GetCell(cell).StringCellValue;
                types.Add(type);

                ++cell;
            }

            return types;
        }
    }
}
