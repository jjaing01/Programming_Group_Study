using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using ExcelParsher;
using NPOI.SS.Formula.Functions;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace ExcelDataTable.UserInfoTableSheet1
{
	public class Sheet1Data
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int Age { get; set; }
		public int Sex { get; set; }

	}

	public class Sheet1Table
	{
		public List<Sheet1Data> DataTable = new List<Sheet1Data>();

		public const string ExcelFileName = "UserInfoTable";
		public const int ExcelSheetIndex = 0;
		public const int SheetRowBegin = 2;
		public const int SheetRowEnd = 5;

		public bool LoadSheetDatasAll()
		{
			var excelAdapter = NPOIAdapter.GetInstance();
			var sheet = excelAdapter.GetExcelSheet(ExcelFileName, ExcelSheetIndex);
			if (sheet is null)
				return false;

			for (int i = SheetRowBegin; i < SheetRowEnd; ++i)
			{
				var row = sheet.GetRow(i);
				if (row is null)
					continue;

				Sheet1Data data = new Sheet1Data();
				data.Id = (int)row.GetCell(0).NumericCellValue;
				data.Name = row.GetCell(1).StringCellValue;
				data.Age = (int)row.GetCell(2).NumericCellValue;
				data.Sex = (int)row.GetCell(3).NumericCellValue;

				DataTable.Add(data);
			}
			
			return true;
		}

	}
}
