﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelParsher
{
    class ExcelAdapter
    {
        private Dictionary<string, ExcelSheetInfo> sheetInfos;

        public enum CSFileWrite
        {
            None,
            Update,
        }

        public ExcelAdapter()
        {
            sheetInfos = new Dictionary<string, ExcelSheetInfo>();
        }

        public virtual void Init() { }
        public virtual void LoadExcel(FileStream fileStream) { }
        public virtual void UpdateExcelSheetInfos(CSFileWrite WriteType) { }
        public void AddSheetInfo(string key, ExcelSheetInfo value)
        {
            if (sheetInfos.ContainsKey(key))
            {
                Debug.Assert(sheetInfos[key] != null, key + " is duplicated");
                return;
            }

            sheetInfos.Add(key, value);
        }
    }
}
