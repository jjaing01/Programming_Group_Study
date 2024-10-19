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
		public int Mp { get; set; }
		public int Attack { get; set; }
		public float Attackspeed { get; set; }
		public int Defence { get; set; }
		public float Speed { get; set; }
		public string Element { get; set; }
		public string Weakness { get; set; }
		public string Abilities { get; set; }
		public string Loot { get; set; }
		public string Imagepath { get; set; }

	}

	public class BasicMonsterTable
	{
		public Dictionary<int, BasicMonsterData> DataTable = new Dictionary<int, BasicMonsterData>();

		public const string ExcelFileName = "MonsterInfoTable";
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

				BasicMonsterData data = new BasicMonsterData();
				data.Uid = (int)row.GetCell(0).NumericCellValue;
				data.Name = row.GetCell(1).StringCellValue;
				data.Grade = row.GetCell(2).StringCellValue;
				data.Hp = (int)row.GetCell(3).NumericCellValue;
				data.Mp = (int)row.GetCell(4).NumericCellValue;
				data.Attack = (int)row.GetCell(5).NumericCellValue;
				data.Attackspeed = (float)row.GetCell(6).NumericCellValue;
				data.Defence = (int)row.GetCell(7).NumericCellValue;
				data.Speed = (float)row.GetCell(8).NumericCellValue;
				data.Element = row.GetCell(9).StringCellValue;
				data.Weakness = row.GetCell(10).StringCellValue;
				data.Abilities = row.GetCell(11).StringCellValue;
				data.Loot = row.GetCell(12).StringCellValue;
				data.Imagepath = row.GetCell(13).StringCellValue;

				DataTable.Add(data.Uid, data);
			}
			
			return true;
		}

		public BasicMonsterData LoadSheetData(int rowIndex)
		{
			if (rowIndex < SheetRowBegin || rowIndex >= SheetRowEnd)
				return null;

			var excelAdapter = NPOIAdapter.GetInstance();
			var sheet = excelAdapter.GetExcelSheet(ExcelFileName, ExcelSheetIndex);
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
				data.Mp = (int)row.GetCell(4).NumericCellValue;
				data.Attack = (int)row.GetCell(5).NumericCellValue;
				data.Attackspeed = (float)row.GetCell(6).NumericCellValue;
				data.Defence = (int)row.GetCell(7).NumericCellValue;
				data.Speed = (float)row.GetCell(8).NumericCellValue;
				data.Element = row.GetCell(9).StringCellValue;
				data.Weakness = row.GetCell(10).StringCellValue;
				data.Abilities = row.GetCell(11).StringCellValue;
				data.Loot = row.GetCell(12).StringCellValue;
				data.Imagepath = row.GetCell(13).StringCellValue;

				return data;
			}

			return null;
		}

	}
}
