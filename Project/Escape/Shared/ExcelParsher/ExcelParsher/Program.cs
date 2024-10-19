using ExcelDataTable.MonsterInfoTableBasicMonster;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;

using static ExcelParsher.ExcelAdapter;

namespace ExcelParsher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NPOIAdapter excelParsher = NPOIAdapter.GetInstance();
            excelParsher.Init();
            excelParsher.UpdateExcelSheetInfos(CSFileWrite.Update);
        }
    }
}
