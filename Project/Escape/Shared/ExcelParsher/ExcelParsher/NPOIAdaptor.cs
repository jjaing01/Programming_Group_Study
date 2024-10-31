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
    internal class NPOIAdaptor : ExcelAdaptor
    {
        private Dictionary<string, IWorkbook> workbooks;
        private static NPOIAdaptor instance = null;
        private static readonly object _lock = new object();

        public static NPOIAdaptor GetInstance()
        {
            if (instance is null)
            {
                lock(_lock)
                {
                    instance = new NPOIAdaptor();
                }
            }

            return instance;
        }

        private NPOIAdaptor()
        {
            workbooks = new Dictionary<string, IWorkbook>();
        }

        public override void Init() 
        {
            var dirInfo = new DirectoryInfo(Constants.TableDirPath);
            foreach (var File in dirInfo.GetFiles())
            {
                if (File.Extension != ".xlsx")
                    continue;

                string relativePath = Constants.TableDirPath + @"\" + File.Name;
                var filePath = Path.GetFullPath(relativePath);

                // 파일 스트림으로 엑셀 파일 열기
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    LoadExcel(fileStream);
                }
            }
        }

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
                    ISheet sheet = workbook.Value.GetSheetAt(i);

                    // 데이터 타입 파싱
                    var info = new ExcelSheetInfo();

                    info.FileName = workbook.Key;
                    info.SheetName = sheet.SheetName;
                    info.SheetIndex = i;
                    info.RowBegin = Constants.DataStartRow;
                    info.RowEnd = sheet.LastRowNum;
                    info.DataNames = MakeDataLits(sheet, Constants.DataNameRow);
                    info.DataTypes = MakeDataLits(sheet, Constants.DataTypeRow);

                    var keyName = workbook.Key + @"+" + sheet.SheetName;
                    AddSheetInfo(keyName, info);
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

        public IWorkbook GetExcelWorkBook(string key)
        {
            IWorkbook value = null;

            if (false == workbooks.TryGetValue(key, out value))
                return null;
            else
                return value;
        }

        public ISheet GetExcelSheet(string key, int sheetIndex)
        {
            IWorkbook workBook = GetExcelWorkBook(key);
            if (workBook == null) 
                return null;

            return workBook.GetSheetAt(sheetIndex);
        }
    }
}
