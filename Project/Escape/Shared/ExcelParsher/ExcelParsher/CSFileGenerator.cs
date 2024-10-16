using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

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
            contents = WriteNameSpaceBegin(contents, path, fileName);

            contents = WriteClassBegin(contents, sheetInfo.sheetName + "Data");
            contents = WriteDataClassProperties(contents, sheetInfo);
            contents = WriteClassEnd(contents);
            contents += "\n\n";
            contents = WriteClassBegin(contents, sheetInfo.sheetName + "Table");
            contents = WriteTableClassProperties(contents, sheetInfo);
            contents = WriteClassEnd(contents);

            contents = WriteNameSpaceEnd(contents);
            File.WriteAllText(path, contents);
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
            if (sheetInfo.dataTypes.Count != sheetInfo.dataNames.Count)
            {
                Debug.Assert(sheetInfo.dataTypes.Count != sheetInfo.dataNames.Count, "miss match data type and name count");
                return contents;
            }

            for (int i = 0; i < sheetInfo.dataTypes.Count; ++i)
            {
                if (string.IsNullOrEmpty(sheetInfo.dataNames[i]))
                    continue;

                var noneBlankDataName = sheetInfo.dataNames[i].Replace(" ", "");
                var dataName = char.ToUpper(noneBlankDataName[0]) + noneBlankDataName.Substring(1).ToLower();

                contents +=
                    "\t\t" + "public " + sheetInfo.dataTypes[i] + " " + dataName + " { get; set; }\n";
            }

            return contents;
        }

        private string WriteTableClassProperties(string contents, ExcelSheetInfo sheetInfo)
        {
            if (sheetInfo.dataTypes.Count != sheetInfo.dataNames.Count)
            {
                Debug.Assert(sheetInfo.dataTypes.Count != sheetInfo.dataNames.Count, "miss match data type and name count");
                return contents;
            }

            string result = sheetInfo.dataNames.Find(name => name.Equals("uid", StringComparison.OrdinalIgnoreCase));
            if (result is null)
            {
                contents +=
                    "\t\t" + "public List<" + sheetInfo.sheetName + "Data> " + "DataTable " + " { get; set; }\n";
            }
            else
            {
                contents +=
                    "\t\t" + "public Dictionary<int, " + sheetInfo.sheetName + "Data> " + "DataTable " + " { get; set; }\n";
            }

            return contents;
        }

        private string WriteClassEnd(string contents)
        {
            contents += "\n\t}";
            return contents;
        }
    }
}