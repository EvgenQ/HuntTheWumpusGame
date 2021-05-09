using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuntTheWumpus
{
	class CoordinatePlayers
	{
		public (string Icon, (int column, int row))[] CoordPlayers { get; set; }
		public CoordinatePlayers()
		{

		}
		public CoordinatePlayers((string, (int, int))[] coord)
		{
			CoordPlayers = coord;
		}
		
		public (string, (int, int))[] GetNumberOfPlayers(int numberOfPlayers) 
		{
			CoordPlayers = new (string, (int, int))[numberOfPlayers+1]; 
			return CoordPlayers;
		}
		public (string, (int, int))[] GetCoordPlayers(string iconPlayers, (int, int) coord) 
		{
			int count = 0;
			bool exit = true;
			while (exit)
			{
				if (CoordPlayers[count] == (null, (0, 0)))
				{
					CoordPlayers[count] = (iconPlayers, (coord.Item1, coord.Item2));
					exit = false;
				}
				else
				{
					if(count<CoordPlayers.Length-1)
						count++;
				}
			}
			return CoordPlayers;
		}
	}
}
