using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//NPOI
using NPOI.SS.Formula.Functions;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel; // for .xlsx files

namespace ExcelParsher
{
    internal class NPOIAdapter : ExcelParsherAdapter
    {
        public NPOIAdapter()
        {
            workbooks = new Dictionary<string, IWorkbook>();
        }

        private Dictionary<string, IWorkbook> workbooks;

        public override void LoadExcel(FileStream fileStream)
        {
            base.LoadExcel(fileStream);

            var fileName = Path.GetFileNameWithoutExtension(fileStream.Name);

            IWorkbook workbook = new XSSFWorkbook(fileStream);  // XSSFWorkbook은 .xlsx 형식 지원
            workbooks.Add(fileName, workbook);
        }

        public override void UpdateExcelSheetInfos()
        {
            base.UpdateExcelSheetInfos();

            foreach (var workbook in workbooks)
            {
                if (workbook.Value is null)
                    continue;

                var sheetCnt = workbook.Value.NumberOfSheets;
                for (var i = 0; i < sheetCnt; ++i)
                {
                    ISheet sheet = workbook.Value.GetSheetAt(i);  // 첫 번째 시트 가져오기

                    // 데이터 타입 파싱
                    var info = new ExcelSheetInfo();
                    info.dataNames = MakeDataLits(sheet, Constants.DataNameRow);
                    info.dataTypes = MakeDataLits(sheet, Constants.DataTypeRow);

                    string keyName = workbook.Key + sheet.SheetName;
                    AddSheetInfo(keyName, info);

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

        private List<string> MakeDataLits(ISheet sheet, int _row)
        {
            List<string> types = new List<string>();

            IRow row = sheet.GetRow(_row);
            int cell = 0;

            while (true)
            {
                if (row is null || row.GetCell(cell) is null)
                    break;

                string type = row.GetCell(cell).StringCellValue;
                types.Add(type);

                ++cell;
            }

            return types;
        }
    }
}
