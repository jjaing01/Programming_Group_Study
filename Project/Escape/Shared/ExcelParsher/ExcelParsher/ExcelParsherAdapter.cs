using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelParsher
{
    class ExcelParsherAdapter
    {
        public ExcelParsherAdapter()
        {
            sheetInfos = new Dictionary<string, ExcelSheetInfo>();
        }

        public virtual void LoadExcel(FileStream fileStream) { }
        public virtual void UpdateExcelSheetInfos() { }
        public void AddSheetInfo(string key, ExcelSheetInfo value)
        {
            sheetInfos.Add(key, value);
        }

        private Dictionary<string, ExcelSheetInfo> sheetInfos;
    }
}
