using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ExcelDataTable.UserInfoTableSheet1
{
	public class Sheet1Data
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int Age { get; set; }
		public int Sex { get; set; }

	}

	public class Sheet1Table
	{
		public List<Sheet1Data> DataTable  { get; set; }

	}
}
