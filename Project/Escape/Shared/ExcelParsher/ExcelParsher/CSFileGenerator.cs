using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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

        public void MakeDataTableFile(string fileName, string sheetName, ExcelSheetInfo sheetInfo)
        {
            string path = Constants.TableDirPath + @"\" + fileName + @".cs";
            string contents = "";

            contents = WriteUsing(contents);
            contents = WriteNameSpaceBegin(contents, path, fileName);
            contents = WriteClassBegin(contents, sheetName + "Data");

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

        private string WriteClassEnd(string contents)
        {
            contents += "\n\t}";
            return contents;
        }
    }
}
