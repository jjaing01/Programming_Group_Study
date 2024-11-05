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

namespace ExcelDataTable.MonsterInfoTableBossMonster
{
	public class BossMonsterData
	{
		public string Name { get; set; }
		public string Grade { get; set; }
		public int Hp { get; set; }
		public int Mp { get; set; }
		public int Attack { get; set; }
		public float Attackspeed { get; set; }
		public int Defence { get; set; }
		public float Speed { get; set; }

	}

	public class BossMonsterTable : IExcelTable
	{
		public List<BossMonsterData> DataTable = new List<BossMonsterData>();

		public const string ExcelFileName = "MonsterInfoTable";
		public const int ExcelSheetIndex = 1;
		public const int SheetRowBegin = 2;
		public const int SheetRowEnd = 4;

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

				BossMonsterData data = new BossMonsterData();
				data.Name = row.GetCell(0).StringCellValue;
				data.Grade = row.GetCell(1).StringCellValue;
				data.Hp = (int)row.GetCell(2).NumericCellValue;
				data.Mp = (int)row.GetCell(3).NumericCellValue;
				data.Attack = (int)row.GetCell(4).NumericCellValue;
				data.Attackspeed = (float)row.GetCell(5).NumericCellValue;
				data.Defence = (int)row.GetCell(6).NumericCellValue;
				data.Speed = (float)row.GetCell(7).NumericCellValue;

				DataTable.Add(data);
			}
			
			return true;
		}

		public BossMonsterData LoadSheetData(int rowIndex)
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
				BossMonsterData data = new BossMonsterData();
				data.Name = row.GetCell(0).StringCellValue;
				data.Grade = row.GetCell(1).StringCellValue;
				data.Hp = (int)row.GetCell(2).NumericCellValue;
				data.Mp = (int)row.GetCell(3).NumericCellValue;
				data.Attack = (int)row.GetCell(4).NumericCellValue;
				data.Attackspeed = (float)row.GetCell(5).NumericCellValue;
				data.Defence = (int)row.GetCell(6).NumericCellValue;
				data.Speed = (float)row.GetCell(7).NumericCellValue;

				return data;
			}

			return null;
		}

	}
}
