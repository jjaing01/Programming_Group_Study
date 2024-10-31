using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using NPOI.SS.UserModel;
using NPOI.POIFS.Crypt.Dsig;

namespace ExcelParsher
{
    internal class CSFileGenerator
    {
        private static CSFileGenerator instance = null;
        private static readonly object _lock = new object();

        public static CSFileGenerator GetInstance()
        {
            if (instance is null)
            {
                lock (_lock)
                {
                    instance = new CSFileGenerator();
                }
            }

            return instance;
        }

        public void MakeDataTableFile(string fileName, ExcelSheetInfo sheetInfo)
        {
            string path = Constants.TableDirPath + @"\" + fileName + @".cs";
            string contents = "";

            contents = WriteUsing(contents);
            contents = WriteUsingNPOI(contents);
            contents = WriteNameSpaceBegin(contents, path, fileName);

            contents = WriteClassBegin(contents, sheetInfo.SheetName + "Data");
            contents = WriteDataClassProperties(contents, sheetInfo);
            contents = WriteClassEnd(contents);
            contents += "\n\n";

            contents = WriteClassBegin(contents, sheetInfo.SheetName + "Table");
            contents = WriteTableClassProperties(contents, sheetInfo);
            contents += "\n";
            contents = WriteTableClassLoadDataAll(contents, sheetInfo);
            contents += "\n";
            contents = WriteTableClassLoadData(contents, sheetInfo);
            contents = WriteClassEnd(contents);

            contents = WriteNameSpaceEnd(contents);
            File.WriteAllText(path, contents, Encoding.UTF8);
        }

        private string WriteUsing(string contents)
        {
            contents +=
                "using System;\n" +
                "using System.Collections.Generic;\n" +
                "using System.Linq;\n" +
                "using System.Text;\n" +
                "using System.Threading.Tasks;\n" +
                "using System.IO;\n" +
                "\n";

            return contents;
        }

        private string WriteUsingNPOI(string contents)
        {
            contents +=
                "using ExcelParsher;\n" +
                "using NPOI.SS.Formula.Functions;\n" +
                "using NPOI.SS.UserModel;\n" +
                "using NPOI.XSSF.UserModel;\n" +
                "\n";

            return contents;
        }

        private string WriteNameSpaceBegin(string contents, string path, string fileName)
        {
            var directoryName = Path.GetDirectoryName(path);
            var folderName = Path.GetFileName(directoryName);

            contents +=
                "namespace " + folderName + "." + fileName + "\n" +
                "{\n";

            return contents;
        }

        private string WriteNameSpaceEnd(string contents)
        {
            contents += "\n}\n";
            return contents;
        }

        private string WriteClassBegin(string contents, string className)
        {
            contents +=
                "\t" + "public class " + className + "\n" +
                "\t" + "{\n";

            return contents;
        }

        private string WriteDataClassProperties(string contents, ExcelSheetInfo sheetInfo)
        {
            if (sheetInfo.DataTypes.Count != sheetInfo.DataNames.Count)
            {
                Debug.Assert(sheetInfo.DataTypes.Count != sheetInfo.DataNames.Count, "miss match data type and name count\n" +
                    "file name : " + sheetInfo.FileName +
                    "sheet name : " + sheetInfo.SheetName);
                return contents;
            }

            for (int i = 0; i < sheetInfo.DataTypes.Count; ++i)
            {
                if (string.IsNullOrEmpty(sheetInfo.DataNames[i]))
                    continue;

                var noneBlankDataName = sheetInfo.DataNames[i].Replace(" ", "");
                var dataName = char.ToUpper(noneBlankDataName[0]) + noneBlankDataName.Substring(1);

                contents += "\t\t" + "public " + sheetInfo.DataTypes[i] + " " + dataName + " { get; set; }\n";
            }

            return contents;
        }

        private string WriteTableClassProperties(string contents, ExcelSheetInfo sheetInfo)
        {
            if (sheetInfo.DataTypes.Count != sheetInfo.DataNames.Count)
            {
                Debug.Assert(sheetInfo.DataTypes.Count != sheetInfo.DataNames.Count
                    , "miss match data type and name count\n" +
                    "file name : " + sheetInfo.FileName +
                    "sheet name : " + sheetInfo.SheetName);
                return contents;
            }

            string result = sheetInfo.DataNames.Find(name => name.Equals("uid", StringComparison.OrdinalIgnoreCase));
            if (result is null)
            {
                contents += "\t\t" + "public List<" + sheetInfo.SheetName + "Data> " + "DataTable" + " = new List<" + sheetInfo.SheetName + "Data>();" + "\n";
            }
            else
            {
                contents += "\t\t" + "public Dictionary<int, " + sheetInfo.SheetName + "Data> " + "DataTable" + " = new Dictionary<int, " + sheetInfo.SheetName + "Data>();" + "\n";
            }

            return contents;
        }

        private string MakeNPOIDataParshing(ExcelSheetInfo sheetInfo)
        {
            string contents = "\t\t\t\t" + sheetInfo.SheetName + "Data data = new " + sheetInfo.SheetName + "Data();" + "\n";
            for (int i = 0; i < sheetInfo.DataTypes.Count; ++i)
            {
                if (string.IsNullOrEmpty(sheetInfo.DataNames[i]))
                    continue;

                var noneBlankDataName = sheetInfo.DataNames[i].Replace(" ", "");
                var dataName = char.ToUpper(noneBlankDataName[0]) + noneBlankDataName.Substring(1);
                if ("string" == sheetInfo.DataTypes[i])
                {
                    contents += "\t\t\t\t" + "data." + dataName + " = row.GetCell(" + i + ").StringCellValue;" + "\n";
                }
                else
                {
                    contents += "\t\t\t\t" + "data." + dataName + " = " + "(" + sheetInfo.DataTypes[i] + ")" + "row.GetCell(" + i + ").NumericCellValue;" + "\n";
                }
            }

            return contents;
        }

        private string WriteTableClassLoadDataAll(string contents, ExcelSheetInfo sheetInfo)
        {
            var excelAdaptor = NPOIAdaptor.GetInstance();
            var sheet = excelAdaptor.GetExcelSheet(sheetInfo.FileName, sheetInfo.SheetIndex);
            if (sheet is null)
                return contents;

            contents += "\t\t" + "public const string ExcelFileName = \"" + sheetInfo.FileName + "\";\n";
            contents += "\t\t" + "public const int ExcelSheetIndex = " + sheetInfo.SheetIndex + ";\n";
            contents += "\t\t" + "public const int SheetRowBegin = " + sheetInfo.RowBegin + ";\n";
            contents += "\t\t" + "public const int SheetRowEnd = " + sheetInfo.RowEnd + ";\n";
            contents += "\n";

            contents += "\t\t" + "public bool LoadSheetDatasAll()\n"
                + "\t\t{\n";

            contents += "\t\t\t" + "var excelAdaptor = NPOIAdaptor.GetInstance();\n";
            contents += "\t\t\t" + "var sheet = excelAdaptor.GetExcelSheet(ExcelFileName, ExcelSheetIndex);\n";
            contents += "\t\t\t" + "if (sheet is null)\n";
            contents += "\t\t\t\t" + "return false;\n";
            contents += "\n";

            contents +=
                "\t\t\t" + "for (int i = SheetRowBegin; i < SheetRowEnd; ++i)\n";
            contents += "\t\t\t" + "{" + "\n";

            contents += "\t\t\t\t" + "var row = sheet.GetRow(i);" + "\n";
            contents += "\t\t\t\t" + "if (row is null)" + "\n";
            contents += "\t\t\t\t\t" + "continue;" + "\n";
            contents += "\n";

            contents += MakeNPOIDataParshing(sheetInfo);

            contents += "\n";

            string result = sheetInfo.DataNames.Find(name => name.Equals("uid", StringComparison.OrdinalIgnoreCase));
            if (result is null)
            {
                contents += "\t\t\t\t" + "DataTable.Add(data);" + "\n";
            }
            else
            {
                contents += "\t\t\t\t" + "DataTable.Add(data.Uid, data);\n";
            }

            contents += "\t\t\t" + "}" + "\n";
            contents += "\t\t\t" + "\n";

            contents += "\t\t\t" + "return true;" + "\n";
            contents += "\t\t" + "}\n";

            return contents;
        }

        private string WriteTableClassLoadData(string contents, ExcelSheetInfo sheetInfo)
        {
            var excelAdaptor = NPOIAdaptor.GetInstance();
            var sheet = excelAdaptor.GetExcelSheet(sheetInfo.FileName, sheetInfo.SheetIndex);
            if (sheet is null)
                return contents;

            contents += "\t\t" + "public " + sheetInfo.SheetName + "Data " + "LoadSheetData(int rowIndex)\n"
                + "\t\t{\n";

            contents += "\t\t\t" + "if (rowIndex < SheetRowBegin || rowIndex >= SheetRowEnd)\n";
            contents += "\t\t\t\t" + "return null;\n";
            contents += "\n";

            contents += "\t\t\t" + "var excelAdaptor = NPOIAdaptor.GetInstance();\n";
            contents += "\t\t\t" + "var sheet = excelAdaptor.GetExcelSheet(ExcelFileName, ExcelSheetIndex);\n";
            contents += "\t\t\t" + "if (sheet is null)\n";
            contents += "\t\t\t\t" + "return null;\n";
            contents += "\n";

            contents += "\t\t\t" + "var row = sheet.GetRow(rowIndex);" + "\n";
            contents += "\t\t\t" + "if (null != row)" + "\n";
            contents += "\t\t\t" + "{" + "\n";

            contents += MakeNPOIDataParshing(sheetInfo);

            contents += "\n";
            contents += "\t\t\t\t" + "return data;" + "\n";

            contents += "\t\t\t" + "}" + "\n";
            contents += "\n";

            contents += "\t\t\t" + "return null;" + "\n";
            contents += "\t\t" + "}\n";

            return contents;
        }

        private string WriteClassEnd(string contents)
        {
            contents += "\n\t}";
            return contents;
        }
    }
}