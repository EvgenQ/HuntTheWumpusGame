using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuntTheWumpus
{
	class SizeMap
	{
		public int X { get; set; }
		public int Y { get; set; }
		public SizeMap()
		{
			Random rnd = new();
			X = rnd.Next(12, 21);
			while (X != Y)
			{
				Y = rnd.Next(12, 21);
			}
		}
		public SizeMap(int x, int y)
		{
			if (x < 10) X = 10;
			else X = x;
			if (y < 10) Y = 10;
			else Y = y;
		}
	}
}
