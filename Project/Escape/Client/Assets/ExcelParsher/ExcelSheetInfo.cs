using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelParsher
{
    class ExcelSheetInfo
    {
        public ExcelSheetInfo()
        {
            FileName = null;
            SheetName = null;
            SheetIndex = 0;
            RowBegin = 0;
            RowEnd = 0;
            List<string> DataTypes = new List<string>(); 
            List<string> DataNames = new List<string>();
        }

        public string FileName { get; set; }
        public string SheetName { get; set; }
        public int SheetIndex { get; set; }
        public int RowBegin { get; set; }
        public int RowEnd { get; set; }
        public List<string> DataTypes { get; set; }
        public List<string> DataNames { get; set; }
    }
}
