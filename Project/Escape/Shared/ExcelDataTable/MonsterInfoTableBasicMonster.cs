using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ExcelDataTable.MonsterInfoTableBasicMonster
{
	public class BasicMonsterData
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Grade { get; set; }
		public int Hp { get; set; }
		public int Mp { get; set; }
		public int Attack { get; set; }
		public float Attackspeed { get; set; }
		public int Defence { get; set; }
		public float Speed { get; set; }
		public string Element { get; set; }
		public string Weakness { get; set; }
		public string Abilities { get; set; }
		public string Loot { get; set; }
		public string Imagepath { get; set; }

	}

	public class BasicMonsterTable
	{
		public List<BasicMonsterData> DataTable  { get; set; }

	}
}
