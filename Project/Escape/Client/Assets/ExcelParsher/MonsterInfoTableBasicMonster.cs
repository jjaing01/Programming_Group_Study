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

namespace ExcelDataTable.MonsterInfoTableBasicMonster
{
	public class BasicMonsterData
	{
		public int Uid { get; set; }
		public string Name { get; set; }
		public string Grade { get; set; }
		public int Hp { get; set; }
		public int Defence { get; set; }
		public float Speed { get; set; }

	}

	public class BasicMonsterTable : IExcelTable
	{
		public Dictionary<int, BasicMonsterData> DataTable = new Dictionary<int, BasicMonsterData>();

		public const string ExcelFileName = "MonsterInfoTable";
		public const int ExcelSheetIndex = 0;
		public const int SheetRowBegin = 2;
		public const int SheetRowEnd = 5;

		public bool LoadSheetDatasAll()
		{
			var excelAdaptor = NPOIAdaptor.GetInstance();
			var sheet = excelAdaptor.GetExcelSheet(ExcelFileName, ExcelSheetIndex);
			if (sheet is null)
				return false;

			for (int i = SheetRowBegin; i < SheetRowEnd; ++i)
			{
				var row = sheet.GetRow(i);
				if (row is null)
					continue;

				BasicMonsterData data = new BasicMonsterData();
				data.Uid = (int)row.GetCell(0).NumericCellValue;
				data.Name = row.GetCell(1).StringCellValue;
				data.Grade = row.GetCell(2).StringCellValue;
				data.Hp = (int)row.GetCell(3).NumericCellValue;
				data.Defence = (int)row.GetCell(4).NumericCellValue;
				data.Speed = (float)row.GetCell(5).NumericCellValue;

				DataTable.Add(data.Uid, data);
			}
			
			return true;
		}

		public BasicMonsterData LoadSheetData(int rowIndex)
		{
			if (rowIndex < SheetRowBegin || rowIndex >= SheetRowEnd)
				return null;

			var excelAdaptor = NPOIAdaptor.GetInstance();
			var sheet = excelAdaptor.GetExcelSheet(ExcelFileName, ExcelSheetIndex);
			if (sheet is null)
				return null;

			var row = sheet.GetRow(rowIndex);
			if (null != row)
			{
				BasicMonsterData data = new BasicMonsterData();
				data.Uid = (int)row.GetCell(0).NumericCellValue;
				data.Name = row.GetCell(1).StringCellValue;
				data.Grade = row.GetCell(2).StringCellValue;
				data.Hp = (int)row.GetCell(3).NumericCellValue;
				data.Defence = (int)row.GetCell(4).NumericCellValue;
				data.Speed = (float)row.GetCell(5).NumericCellValue;

				return data;
			}

			return null;
		}

	}
}
