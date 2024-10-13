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

        public void MakeDataTableFile(string fileName)
        {
            string path = Constants.TableDirPath + @"\" + fileName + @".cs";
            string contents = "";

            contents = WriteUsing(contents);

            File.WriteAllText(path, contents);
        }

        public string WriteUsing(string contents)
        {
            string output = "";

            output += "using System;\n";
            output += "using System.Collections.Generic;\n";
            output += "using System.Linq;\n";
            output += "using System.Text;\n";
            output += "using System.Threading.Tasks;\n";
            output += "using System.IO;\n";

            return contents + output;
        }
    }
}
