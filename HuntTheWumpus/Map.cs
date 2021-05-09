using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuntTheWumpus
{
	class Map
	{
		private const string _Map = "[ ]";
		public readonly SizeMap Axis;
		public CoordinatePlayers Players;
		(string, (int, int))[] CoordPlayers;
		int[] CoordInConsole;
		int[] CoordInConsoleFor;
		public Map()
		{
			Axis = new SizeMap();
			DrawMap();
			PosPlayersOnMap();
		}
		public Map(int wampus,int bat,int pit,bool showEnemies = false)
		{
			if (showEnemies) 
			{
				Players = new CoordinatePlayers();
				Axis = new SizeMap();
				DrawMap();
				PosPlayersOnMapInvizible(wampus, bat, pit);
			}
			else
			{
				Players = new CoordinatePlayers();
				Axis = new SizeMap();
				DrawMap();
				PosPlayersOnMap(wampus, bat, pit);
			}
			
		}
		private SizeMap DrawMap() 
		{
			int y = 0;
			int x = 0;
			int index = 0;
			int index2 = 0;
			CoordInConsole = new int[Axis.X];
			CoordInConsoleFor = new int[_Map.Length * Axis.Y];
			int stop = _Map.Length * Axis.Y;
			for (int i = 0; i < Axis.X; i++)
			{
				for (int j = 0; j < Axis.Y; j++)
				{
					for (int k = 0; k < _Map.Length; k++)
					{
						if (_Map[k] == ' ')
						{
							CoordInConsoleFor[index2] = y;
							if(index2 < _Map.Length * Axis.Y -1)
								index2++;
							if (x < stop)
							{
								CoordInConsole[index] = x;
								index++;
							}
						}
						x++;
						y++;
					}
					Console.Write(_Map);
				}
				y = 0;
				Console.WriteLine();
			}
			return Axis;
		}
		private void PosPlayersOnMap() 
		{
			Random rnd = new();
			bool exit = true;
			Console.SetCursorPosition(0, 0);
			(int, int) posPlayer = (CoordInConsole[rnd.Next(Axis.Y - 1)], rnd.Next(Axis.Y));
			(int, int) posWampus = (CoordInConsole[rnd.Next(Axis.Y - 1)], rnd.Next(Axis.Y));
			(int, int) posBat = (CoordInConsole[rnd.Next(Axis.Y - 1)], rnd.Next(Axis.Y));
			(int, int) posPit = (CoordInConsole[rnd.Next(Axis.Y - 1)], rnd.Next(Axis.Y));

			while (exit)
			{
				if ((posPlayer == posWampus) || (posPlayer == posBat) || (posPlayer == posPit)) 
				{
					posPlayer = (CoordInConsole[rnd.Next(Axis.Y - 1)], rnd.Next(Axis.Y));
				}
				else
				{
					Console.SetCursorPosition(posPlayer.Item1, posPlayer.Item2);
					Console.Write(Player._Player);
					exit = false;
				}
			}
			exit = true;
			while (exit)
			{
				if ((posWampus == posPlayer) || (posWampus == posBat) || (posWampus == posPit))
				{
					posWampus = (CoordInConsole[rnd.Next(Axis.Y - 1)], rnd.Next(Axis.Y));
				}
				else
				{
					Console.SetCursorPosition(posWampus.Item1, posWampus.Item2);
					Console.Write(Wampus._Wampus);
					exit = false;
				}
			}
			exit = true;
			while (exit)
			{
				if ((posBat == posPlayer) || (posBat == posWampus) || (posBat == posPit))
				{
					posBat = (CoordInConsole[rnd.Next(Axis.Y - 1)], rnd.Next(Axis.Y));
				}
				else
				{
					Console.SetCursorPosition(posBat.Item1, posBat.Item2);
					Console.Write(Bat._Bat);
					exit = false;
				}
			}
			exit = true;
			while (exit)
			{
				if ((posPit == posPlayer) || (posPit == posWampus) || (posPit == posBat))
				{
					posPit = (CoordInConsole[rnd.Next(Axis.Y - 1)], rnd.Next(Axis.Y));
				}
				else
				{
					Console.SetCursorPosition(posPit.Item1, posPit.Item2);
					Console.Write(Pit._Pit);
					exit = false;
				}
			}
		}
		private void PosPlayersOnMap(int wampus,int bat,int pit)
		{
			int bullet = 1;
			int numberOfPlayers = wampus + bat + pit + bullet;
			Players.GetNumberOfPlayers(numberOfPlayers);
			Random rnd = new();
			bool exit = true;
			Console.SetCursorPosition(0, 0);
			(int, int) posPlayer = (CoordInConsole[rnd.Next(Axis.Y - 1)], rnd.Next(Axis.Y));
			(int, int) posWampus = (CoordInConsole[rnd.Next(Axis.Y - 1)], rnd.Next(Axis.Y));
			(int, int) posBat = (CoordInConsole[rnd.Next(Axis.Y - 1)], rnd.Next(Axis.Y));
			(int, int) posPit = (CoordInConsole[rnd.Next(Axis.Y - 1)], rnd.Next(Axis.Y));
			(int, int) posBullet = posPlayer;
			while (exit)
			{
				if ((posPlayer == posWampus) || (posPlayer == posBat) || (posPlayer == posPit))
				{
					posPlayer = (CoordInConsole[rnd.Next(Axis.Y - 1)], rnd.Next(Axis.Y));
				}
				else
				{
					Console.SetCursorPosition(posPlayer.Item1, posPlayer.Item2);
					Console.Write(Player._Player);
					Players.GetCoordPlayers(Player._Player, posPlayer);
					exit = false;
				}
			}
			exit = true;
			while (exit)
			{
				if ((posWampus == posPlayer) || (posWampus == posBat) || (posWampus == posPit))
				{
					posWampus = (CoordInConsole[rnd.Next(Axis.Y - 1)], rnd.Next(Axis.Y));
				}
				else
				{
					Console.SetCursorPosition(posWampus.Item1, posWampus.Item2);
					Console.Write(Wampus._Wampus);
					wampus--;
					Players.GetCoordPlayers(Wampus._Wampus, posWampus);
					posWampus = (CoordInConsole[rnd.Next(Axis.Y - 1)], rnd.Next(Axis.Y));
				}
				if (wampus == 0)
				{
					exit = false;
				}
			}
			exit = true;
			while (exit)
			{
				if ((posBat == posPlayer) || (posBat == posWampus) || (posBat == posPit))
				{
					posBat = (CoordInConsole[rnd.Next(Axis.Y - 1)], rnd.Next(Axis.Y));
				}
				else
				{
					Console.SetCursorPosition(posBat.Item1, posBat.Item2);
					Console.Write(Bat._Bat);
					Players.GetCoordPlayers(Bat._Bat, posBat);
					bat--;
					posBat = (CoordInConsole[rnd.Next(Axis.Y - 1)], rnd.Next(Axis.Y));
				}
				if(bat == 0)
					exit = false;
			}
			exit = true;
			while (exit)
			{
				if ((posPit == posPlayer) || (posPit == posWampus) || (posPit == posBat))
				{
					posPit = (CoordInConsole[rnd.Next(Axis.Y - 1)], rnd.Next(Axis.Y));
				}
				else
				{
					Console.SetCursorPosition(posPit.Item1, posPit.Item2);
					Console.Write(Pit._Pit);
					Players.GetCoordPlayers(Pit._Pit, posPit);
					pit--;
					posPit = (CoordInConsole[rnd.Next(Axis.Y - 1)], rnd.Next(Axis.Y));
				}
				if(pit == 0)
					exit = false;
			}
			exit = true;
			while (exit)
			{
				
				Players.GetCoordPlayers(Bullet._Bullet, posBullet);
				exit = false;
				
			}
		}
		private void PosPlayersOnMapInvizible(int wampus, int bat, int pit)
		{
			int bullet = 1;
			int numberOfPlayers = wampus + bat + pit + bullet;
			Players.GetNumberOfPlayers(numberOfPlayers);
			Random rnd = new();
			bool exit = true;
			Console.SetCursorPosition(0, 0);
			(int, int) posPlayer = (CoordInConsole[rnd.Next(Axis.Y - 1)], rnd.Next(Axis.Y));
			(int, int) posWampus = (CoordInConsole[rnd.Next(Axis.Y - 1)], rnd.Next(Axis.Y));
			(int, int) posBat = (CoordInConsole[rnd.Next(Axis.Y - 1)], rnd.Next(Axis.Y));
			(int, int) posPit = (CoordInConsole[rnd.Next(Axis.Y - 1)], rnd.Next(Axis.Y));
			(int, int) posBullet = posPlayer;
			while (exit)
			{
				if ((posPlayer == posWampus) || (posPlayer == posBat) || (posPlayer == posPit))
				{
					posPlayer = (CoordInConsole[rnd.Next(Axis.Y - 1)], rnd.Next(Axis.Y));
				}
				else
				{
					Console.SetCursorPosition(posPlayer.Item1, posPlayer.Item2);
					Console.Write(Player._Player);
					Players.GetCoordPlayers(Player._Player, posPlayer);
					exit = false;
				}
			}
			exit = true;
			while (exit)
			{
				if ((posWampus == posPlayer) || (posWampus == posBat) || (posWampus == posPit))
				{
					posWampus = (CoordInConsole[rnd.Next(Axis.Y - 1)], rnd.Next(Axis.Y));
				}
				else
				{
					Console.SetCursorPosition(posWampus.Item1, posWampus.Item2);
					//Console.Write(Wampus._Wampus);
					wampus--;
					Players.GetCoordPlayers(Wampus._Wampus, posWampus);
					posWampus = (CoordInConsole[rnd.Next(Axis.Y - 1)], rnd.Next(Axis.Y));
				}
				if (wampus == 0)
				{
					exit = false;
				}
			}
			exit = true;
			while (exit)
			{
				if ((posBat == posPlayer) || (posBat == posWampus) || (posBat == posPit))
				{
					posBat = (CoordInConsole[rnd.Next(Axis.Y - 1)], rnd.Next(Axis.Y));
				}
				else
				{
					Console.SetCursorPosition(posBat.Item1, posBat.Item2);
					//Console.Write(Bat._Bat);
					Players.GetCoordPlayers(Bat._Bat, posBat);
					bat--;
					posBat = (CoordInConsole[rnd.Next(Axis.Y - 1)], rnd.Next(Axis.Y));
				}
				if (bat == 0)
					exit = false;
			}
			exit = true;
			while (exit)
			{
				if ((posPit == posPlayer) || (posPit == posWampus) || (posPit == posBat))
				{
					posPit = (CoordInConsole[rnd.Next(Axis.Y - 1)], rnd.Next(Axis.Y));
				}
				else
				{
					Console.SetCursorPosition(posPit.Item1, posPit.Item2);
					//Console.Write(Pit._Pit);
					Players.GetCoordPlayers(Pit._Pit, posPit);
					pit--;
					posPit = (CoordInConsole[rnd.Next(Axis.Y - 1)], rnd.Next(Axis.Y));
				}
				if (pit == 0)
					exit = false;
			}
			exit = true;
			while (exit)
			{

				Players.GetCoordPlayers(Bullet._Bullet, posBullet);
				exit = false;

			}
		}

	}
}
