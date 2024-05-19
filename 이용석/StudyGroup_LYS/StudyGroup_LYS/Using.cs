using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGroup_LYS
{
    class Using
    {
        public static void Main()
        {
            FileStream fs = new FileStream("A.txt", FileMode.CreateNew);

            try
            {

            }
            finally
            {
                fs.Dispose();
            }

            using (FileStream fs2 = new FileStream("A.txt", FileMode.CreateNew))
            {

            }
        }
    }
}
