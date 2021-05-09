using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuntTheWumpus
{
	class LogicOnMap
	{
		public static (string icon, (int column, int row) coord)[] ColisionWihtEnemies((string icon, (int column, int row) coord)[] coordinate, (int, int) coordPlayerOrBullet, int sizeMap) 
		{
			(int, int) playerVisibility = FindPlayerAndEnemies(coordinate, NPC.Player);
			coordinate = CheckHitBullet(coordinate,coordPlayerOrBullet,sizeMap);
			for (int i = 0; i < coordinate.Length; i++)
			{
				int playerVisibilityC = 3;
				int playerVisibilityR = 1;
				int count = 0;
				if (count <= 3)
				{
					//do
					//{
					//	playerVisibility.Item1 += playerVisibilityC;
					//	PrintText(coordinate, playerVisibility, sizeMap);
					//	playerVisibility = FindPlayerAndEnemies(coordinate, NPC.Player);

					//	playerVisibility.Item1 -= playerVisibilityC;
					//	PrintText(coordinate, playerVisibility, sizeMap);
					//	playerVisibility = FindPlayerAndEnemies(coordinate, NPC.Player);

					//	playerVisibility.Item2 += playerVisibilityR;
					//	PrintText(coordinate, playerVisibility, sizeMap);
					//	playerVisibility = FindPlayerAndEnemies(coordinate, NPC.Player);

					//	playerVisibility.Item2 -= playerVisibilityR;
					//	PrintText(coordinate, playerVisibility, sizeMap);
					//	playerVisibility = FindPlayerAndEnemies(coordinate, NPC.Player);
					//	count++;
					//} while (count != 12);

					while (count != 3)
					{
						playerVisibility.Item1 += playerVisibilityC;
						count++;
						PrintText(coordinate, playerVisibility, sizeMap);
					}
					playerVisibility = FindPlayerAndEnemies(coordinate, NPC.Player);
					while (count != 0)
					{
						playerVisibility.Item1 -= playerVisibilityC;
						count--;
						PrintText(coordinate, playerVisibility, sizeMap);
					}
					playerVisibility = FindPlayerAndEnemies(coordinate, NPC.Player);
					while (count != 3)
					{

						playerVisibility.Item2 += playerVisibilityR;
						count++;
						PrintText(coordinate, playerVisibility, sizeMap);
					}
					playerVisibility = FindPlayerAndEnemies(coordinate, NPC.Player);
					while (count != 0)
					{
						playerVisibility.Item2 -= playerVisibilityR;
						PrintText(coordinate, playerVisibility, sizeMap);
						count--;
					}
					playerVisibility = FindPlayerAndEnemies(coordinate, NPC.Player);
					CheckIsAlive(coordinate, playerVisibility, sizeMap);
				}
			}
			return coordinate;
		}

		private static (string icon, (int column, int row) coord)[] CheckHitBullet((string icon, (int column, int row) coord)[] coordinate, (int, int) coordPlayerOrBullet,int sizeMap)
		{
			sizeMap = sizeMap * 3 + 5;
			(int, int) player = FindPlayerAndEnemies(coordinate, NPC.Player);
			if (player == coordPlayerOrBullet) 
			{
				return coordinate;
			}
			for (int i = 0; i < coordinate.Length; i++)
			{
				if (coordinate[i].coord == coordPlayerOrBullet)
				{
					if (coordinate[i].icon == Wampus._Wampus)
					{
						Console.SetCursorPosition(sizeMap, 5);
						Console.Write("Вампус мертв");
						coordinate[i].icon = null;
						coordinate[i].coord = (0, 0);
					}
					if (coordinate[i].icon == Bat._Bat)
					{
						Console.SetCursorPosition(sizeMap, 6);
						Console.Write("Вы убили кровососа");
						coordinate[i].icon = null;
						coordinate[i].coord = (0, 0);
					}
				}
			}
			return coordinate;
		}

		private static void PrintText((string icon, (int column, int row) coord)[] coordinate, (int, int) playerVisibility, int sizeMap)
		{
			sizeMap = sizeMap * 3 + 5;
			for (int i = 0; i < coordinate.Length; i++)
			{
				if (playerVisibility == coordinate[i].coord)
				{

					if (coordinate[i].icon == Wampus._Wampus)
					{
						Console.SetCursorPosition(sizeMap, 0);
						Console.Write("Вы чувствуете вонь!!!");
					}
					if (coordinate[i].icon == Bat._Bat)
					{
						Console.SetCursorPosition(sizeMap, 1);
						Console.Write("Вы слышите шелест!!!");
					}
					if (coordinate[i].icon == Pit._Pit)
					{
						Console.SetCursorPosition(sizeMap, 2);
						Console.Write("Где-то сквозит!!!");
					}
				}
			}
			Console.SetCursorPosition(sizeMap, 0);
		}
		private static void CheckIsAlive((string icon, (int column, int row) coord)[] coordinate, (int, int) coordPlayer, int sizeMap)
		{
			sizeMap = sizeMap * 3 + 5;
			for (int i = 0; i < coordinate.Length; i++)
			{
				if (coordPlayer == coordinate[i].coord)
				{
					Console.SetCursorPosition(sizeMap, i);
					if (coordinate[i].icon == Wampus._Wampus)
					{
						Console.Write("Вас поймал Вампус!!!");
						Game.Stop("Вас поймал Вампус!!!");
					}
					if (coordinate[i].icon == Bat._Bat)
					{
						Console.Write("Из вас высосали кровь!!!");
						Game.Stop("Из вас высосали кровь!!!");
					}
					if (coordinate[i].icon == Pit._Pit)
					{
						Console.Write("Вы про валились в яму!!!");
						Game.Stop("Вы про валились в яму!!!");

					}
				}
			}
			Console.SetCursorPosition(sizeMap, 0);
		}
		private static void Print(int sizeMap)
		{
			sizeMap = sizeMap * 3 + 5;
			Console.SetCursorPosition(sizeMap, 0);
			for (int i = 0; i < sizeMap; i++)
			{
				Console.SetCursorPosition(sizeMap, i);
				Console.Write("                        ");
				Console.SetCursorPosition(sizeMap, 3);
				Console.Write("************************");
				Console.SetCursorPosition(sizeMap, 4);
				Console.Write("************************");
			}
			Console.SetCursorPosition(sizeMap, 0);
		}
		private static (int, int) FindPlayerAndEnemies((string, (int, int))[] coordinate, NPC enemiesAndUser)
		{
			int x = 0;
			switch (enemiesAndUser)
			{
				case NPC.Player:
					for (int i = 0; i < coordinate.Length; i++)
					{
						if (coordinate[i].Item1 == Player._Player)
						{
							x = i;
							Console.SetCursorPosition(coordinate[i].Item2.Item1, coordinate[i].Item2.Item2);
							Console.Write(Player._Player);
							return coordinate[i].Item2;
						}
					}
					break;
				case NPC.Wampus:
					for (int i = 0; i < coordinate.Length; i++)
					{
						if (coordinate[i].Item1 == Wampus._Wampus)
						{
							x = i;
							return coordinate[i].Item2;
						}
					}
					break;
				case NPC.Bat:
					for (int i = 0; i < coordinate.Length; i++)
					{
						if (coordinate[i].Item1 == Bat._Bat)
						{
							x = i;
							return coordinate[i].Item2;
						}
					}
					break;
				case NPC.Pit:
					for (int i = 0; i < coordinate.Length; i++)
					{
						if (coordinate[i].Item1 == Pit._Pit)
						{
							x = i;
							return coordinate[i].Item2;
						}
					}
					break;
				default:
					break;
			}

			return coordinate[x].Item2;
		}
	}
}
