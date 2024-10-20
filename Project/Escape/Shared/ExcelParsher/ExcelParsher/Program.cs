﻿using ExcelDataTable.MonsterInfoTableBasicMonster;
using NPOI.SS.UserModel;
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
            var excelParsher = NPOIAdapter.GetInstance();
            excelParsher.Init();
            excelParsher.UpdateExcelSheetInfos();

            foreach (var info in excelParsher.sheetInfos)
            {
                var csFileName = info.Value.FileName + info.Value.SheetName;
                CSFileGenerator.GetInstance().MakeDataTableFile(csFileName, info.Value);
            }
        }
    }
}
