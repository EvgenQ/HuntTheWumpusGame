using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HuntTheWumpus
{
	class ControlPlayer
	{
		public ControlPlayer((string icon, (int column, int row) coord)[] coordinate, int sizeMap,bool showEnemies = false)
		{
			GetControl(coordinate, sizeMap);
		}
		public CoordinatePlayers Coordinate { get; set; }
		public void GetControl((string icon, (int column, int row) coord)[] coordinate, int sizeMap,bool showEnemies = false) 
		{
			int numberOfMoves = 0;
			int BulletFlightRange = 3;
			_ = FindPlayerAndEnemies(coordinate, NPC.Player); ;
			(int, int) coordBullet;
			Console.CursorVisible = true;
			Console.SetCursorPosition(1, 1);
			while(true)
			{
				ConsoleKeyInfo key = Console.ReadKey(true);
				(int, int) coordPlayer;
				if (key.Key == ConsoleKey.LeftArrow)
				{
					coordPlayer = FindPlayerAndEnemies(coordinate, NPC.Player);
					Console.SetCursorPosition(coordPlayer.Item1, coordPlayer.Item2);
					Console.Write(" ");
					coordPlayer.Item1 -= 3;
					if (coordPlayer.Item1 < 1)
					{
						coordPlayer.Item1 = 1;
					}
					Console.SetCursorPosition(coordPlayer.Item1, coordPlayer.Item2);
					Console.Write(Player._Player);
					for (int i = 0; i < coordinate.Length; i++)
					{
						if (coordinate[i].Item1 == Player._Player)
						{
							coordinate[i] = (Player._Player, (coordPlayer.Item1, coordPlayer.Item2));
							break;
						}
					}
					Console.SetCursorPosition(1, 1);
					numberOfMoves++;
				}
				if (key.Key == ConsoleKey.RightArrow)
				{
					coordPlayer = FindPlayerAndEnemies(coordinate, NPC.Player);
					Console.SetCursorPosition(coordPlayer.Item1, coordPlayer.Item2);
					Console.Write(" ");
					coordPlayer.Item1 += 3;
					if (coordPlayer.Item1 > sizeMap*3-2)
					{
						coordPlayer.Item1 = (sizeMap * 3) - 2;
					}
					Console.SetCursorPosition(coordPlayer.Item1, coordPlayer.Item2);
					Console.Write(Player._Player);
					for (int i = 0; i < coordinate.Length; i++)
					{
						if (coordinate[i].Item1 == Player._Player)
						{
							coordinate[i] = (Player._Player, (coordPlayer.Item1, coordPlayer.Item2));
							break;
						}
					}
					Console.SetCursorPosition(1, 1);
					numberOfMoves++;
				}
				if (key.Key == ConsoleKey.UpArrow)
				{
					coordPlayer = FindPlayerAndEnemies(coordinate, NPC.Player);
					Console.SetCursorPosition(coordPlayer.Item1, coordPlayer.Item2);
					Console.Write(" ");
					coordPlayer.Item2 -= 1;
					if (coordPlayer.Item2 < 0)
					{
						coordPlayer.Item2 = 0;
					}
					Console.SetCursorPosition(coordPlayer.Item1, coordPlayer.Item2);
					Console.Write(Player._Player);
					for (int i = 0; i < coordinate.Length; i++)
					{
						if (coordinate[i].Item1 == Player._Player)
						{
							coordinate[i] = (Player._Player, (coordPlayer.Item1, coordPlayer.Item2));
							break;
						}
					}
					Console.SetCursorPosition(1, 1);
					numberOfMoves++;
				}
				if (key.Key == ConsoleKey.DownArrow)
				{
					coordPlayer = FindPlayerAndEnemies(coordinate, NPC.Player);
					Console.SetCursorPosition(coordPlayer.Item1, coordPlayer.Item2);
					Console.Write(" ");
					coordPlayer.Item2 += 1;
					if (coordPlayer.Item2 > sizeMap - 1) 
					{
						coordPlayer.Item2 = sizeMap - 1;
					}
					Console.SetCursorPosition(coordPlayer.Item1, coordPlayer.Item2);
					Console.Write(Player._Player);
					for (int i = 0; i < coordinate.Length; i++)
					{
						if (coordinate[i].Item1 == Player._Player)
						{
							coordinate[i] = (Player._Player, (coordPlayer.Item1, coordPlayer.Item2));
							break;
						}
					}
					Console.SetCursorPosition(1, 1);
					numberOfMoves++;
				}
				if (key.Key == ConsoleKey.A) 
				{
					coordBullet = FindPlayerAndEnemies(coordinate, NPC.Player);
					while (true)
					{
						coordBullet.Item1 -= 3;
						if (coordBullet.Item1 < 1)
						{
							coordBullet.Item1 = 1;
						}
						Console.SetCursorPosition(coordBullet.Item1, coordBullet.Item2);
						Console.Write(Bullet._Bullet);
						for (int i = 0; i < coordinate.Length; i++)
						{
							if (coordinate[i].Item1 == Bullet._Bullet)
							{
								coordinate[i] = (Bullet._Bullet, (coordBullet.Item1, coordBullet.Item2));
							}
						}
						coordinate = LogicOnMap.ColisionWihtEnemies(coordinate, coordBullet, sizeMap);
						Thread.Sleep(150);
						Console.SetCursorPosition(coordBullet.Item1, coordBullet.Item2);
						Console.Write(" ");
						BulletFlightRange--;
						if (BulletFlightRange == 0)
						{
							BulletFlightRange = 3;
							break;
						}
					}
				}
				if (key.Key == ConsoleKey.D)
				{
					coordBullet = FindPlayerAndEnemies(coordinate, NPC.Player);
					while (true)
					{
						coordBullet.Item1 += 3;
						if (coordBullet.Item1 > sizeMap * 3 - 2)
						{
							coordBullet.Item1 = (sizeMap * 3) - 2;
						}
						Console.SetCursorPosition(coordBullet.Item1, coordBullet.Item2);
						Console.Write(Bullet._Bullet);
						for (int i = 0; i < coordinate.Length; i++)
						{
							if (coordinate[i].Item1 == Bullet._Bullet)
							{
								coordinate[i] = (Bullet._Bullet, (coordBullet.Item1, coordBullet.Item2));
							}
						}
						coordinate = LogicOnMap.ColisionWihtEnemies(coordinate, coordBullet, sizeMap);
						Thread.Sleep(150);
						Console.SetCursorPosition(coordBullet.Item1, coordBullet.Item2);
						Console.Write(" ");
						BulletFlightRange--;
						if (BulletFlightRange == 0)
						{
							BulletFlightRange = 3;
							break;
						}
					}
				}
				if (key.Key == ConsoleKey.W) 
				{
					coordBullet = FindPlayerAndEnemies(coordinate, NPC.Player);
					while (true)
					{
						coordBullet.Item2 -= 1;
						if (coordBullet.Item2 < 0)
						{
							coordBullet.Item2 = 0;
						}
						Console.SetCursorPosition(coordBullet.Item1, coordBullet.Item2);
						Console.Write(Bullet._Bullet);
						for (int i = 0; i < coordinate.Length; i++)
						{
							if (coordinate[i].Item1 == Bullet._Bullet)
							{
								coordinate[i] = (Bullet._Bullet, (coordBullet.Item1, coordBullet.Item2));
							}
						}
						coordinate = LogicOnMap.ColisionWihtEnemies(coordinate, coordBullet, sizeMap);
						Thread.Sleep(150);
						Console.SetCursorPosition(coordBullet.Item1, coordBullet.Item2);
						Console.Write(" ");
						BulletFlightRange--;
						if (BulletFlightRange == 0)
						{
							BulletFlightRange = 3;
							break;
						}
					}
				}
				if (key.Key == ConsoleKey.S) 
				{
					coordBullet = FindPlayerAndEnemies(coordinate, NPC.Player);
					while (true)
					{
						coordBullet.Item2 += 1;
						if (coordBullet.Item2 > sizeMap - 1)
						{
							coordBullet.Item2 = sizeMap - 1;
						}
						Console.SetCursorPosition(coordBullet.Item1, coordBullet.Item2);
						Console.Write(Bullet._Bullet);
						for (int i = 0; i < coordinate.Length; i++)
						{
							if (coordinate[i].Item1 == Bullet._Bullet)
							{
								coordinate[i] = (Bullet._Bullet, (coordBullet.Item1, coordBullet.Item2));
							}
						}
						coordinate = LogicOnMap.ColisionWihtEnemies(coordinate, coordBullet, sizeMap);
						Thread.Sleep(150);
						Console.SetCursorPosition(coordBullet.Item1, coordBullet.Item2);
						Console.Write(" ");
						BulletFlightRange--;
						if (BulletFlightRange == 0)
						{
							BulletFlightRange = 3;
							break;
						}
					}
				}
				if (numberOfMoves % 2 == 0) 
				{
					coordinate = RandomDirectionEnemies(coordinate, sizeMap,showEnemies);
				}
				Print(sizeMap);
				coordPlayer = FindPlayerAndEnemies(coordinate, NPC.Player);
				coordinate = LogicOnMap.ColisionWihtEnemies(coordinate, coordPlayer, sizeMap);
			}
		}

		private (string, (int, int))[] RandomDirectionEnemies((string, (int, int))[] coordinateEnemies,int sizeMap,bool showEnemies = false)
		{
			if (showEnemies)
			{
				for (int i = 0; i < coordinateEnemies.Length; i++)
				{
					if (coordinateEnemies[i].Item1 == Wampus._Wampus)
					{
						Random rnd = new();
						int randomDirectoin = rnd.Next(4);
						switch (randomDirectoin)
						{
							//DirectionLeft
							case 0:
								Console.SetCursorPosition(coordinateEnemies[i].Item2.Item1, coordinateEnemies[i].Item2.Item2);
								Console.Write(" ");
								coordinateEnemies[i].Item2.Item1 -= 3;
								if (coordinateEnemies[i].Item2.Item1 < 1)
								{
									coordinateEnemies[i].Item2.Item1 = 1;
								}
								Console.SetCursorPosition(coordinateEnemies[i].Item2.Item1, coordinateEnemies[i].Item2.Item2);
								Console.Write(Wampus._Wampus);
								Console.SetCursorPosition(1, 1);
								coordinateEnemies[i] = (Wampus._Wampus, (coordinateEnemies[i].Item2.Item1, coordinateEnemies[i].Item2.Item2));
								break;
							//DirectionRight
							case 1:
								Console.SetCursorPosition(coordinateEnemies[i].Item2.Item1, coordinateEnemies[i].Item2.Item2);
								Console.Write(" ");
								coordinateEnemies[i].Item2.Item1 += 3;
								if (coordinateEnemies[i].Item2.Item1 > sizeMap * 3 - 2)
								{
									coordinateEnemies[i].Item2.Item1 = (sizeMap * 3) - 2;
								}
								Console.SetCursorPosition(coordinateEnemies[i].Item2.Item1, coordinateEnemies[i].Item2.Item2);
								Console.Write(Wampus._Wampus);
								Console.SetCursorPosition(1, 1);
								coordinateEnemies[i] = (Wampus._Wampus, (coordinateEnemies[i].Item2.Item1, coordinateEnemies[i].Item2.Item2));
								break;
							//DirectionUp
							case 2:
								Console.SetCursorPosition(coordinateEnemies[i].Item2.Item1, coordinateEnemies[i].Item2.Item2);
								Console.Write(" ");
								coordinateEnemies[i].Item2.Item2 -= 1;
								if (coordinateEnemies[i].Item2.Item2 < 0)
								{
									coordinateEnemies[i].Item2.Item2 = 0;
								}
								Console.SetCursorPosition(coordinateEnemies[i].Item2.Item1, coordinateEnemies[i].Item2.Item2);
								Console.Write(Wampus._Wampus);
								Console.SetCursorPosition(1, 1);
								coordinateEnemies[i] = (Wampus._Wampus, (coordinateEnemies[i].Item2.Item1, coordinateEnemies[i].Item2.Item2));
								break;
							//DirectionDown
							case 3:
								Console.SetCursorPosition(coordinateEnemies[i].Item2.Item1, coordinateEnemies[i].Item2.Item2);
								Console.Write(" ");
								coordinateEnemies[i].Item2.Item2 += 1;
								if (coordinateEnemies[i].Item2.Item2 > sizeMap - 1)
								{
									coordinateEnemies[i].Item2.Item2 = sizeMap - 1;
								}
								Console.SetCursorPosition(coordinateEnemies[i].Item2.Item1, coordinateEnemies[i].Item2.Item2);
								Console.Write(Wampus._Wampus);
								Console.SetCursorPosition(1, 1);
								coordinateEnemies[i] = (Wampus._Wampus, (coordinateEnemies[i].Item2.Item1, coordinateEnemies[i].Item2.Item2));
								break;
							default:
								break;
						}
					}
					if (coordinateEnemies[i].Item1 == Bat._Bat)
					{
						Random rnd = new();
						int randomDirectoin = rnd.Next(4);
						switch (randomDirectoin)
						{
							//DirectionLeft
							case 0:
								Console.SetCursorPosition(coordinateEnemies[i].Item2.Item1, coordinateEnemies[i].Item2.Item2);
								Console.Write(" ");
								coordinateEnemies[i].Item2.Item1 -= 3;
								if (coordinateEnemies[i].Item2.Item1 < 1)
								{
									coordinateEnemies[i].Item2.Item1 = 1;
								}
								Console.SetCursorPosition(coordinateEnemies[i].Item2.Item1, coordinateEnemies[i].Item2.Item2);
								Console.Write(Bat._Bat);
								Console.SetCursorPosition(1, 1);
								coordinateEnemies[i] = (Bat._Bat, (coordinateEnemies[i].Item2.Item1, coordinateEnemies[i].Item2.Item2));
								break;
							//DirectionRight
							case 1:
								Console.SetCursorPosition(coordinateEnemies[i].Item2.Item1, coordinateEnemies[i].Item2.Item2);
								Console.Write(" ");
								coordinateEnemies[i].Item2.Item1 += 3;
								if (coordinateEnemies[i].Item2.Item1 > sizeMap * 3 - 2)
								{
									coordinateEnemies[i].Item2.Item1 = (sizeMap * 3) - 2;
								}
								Console.SetCursorPosition(coordinateEnemies[i].Item2.Item1, coordinateEnemies[i].Item2.Item2);
								Console.Write(Bat._Bat);
								Console.SetCursorPosition(1, 1);
								coordinateEnemies[i] = (Bat._Bat, (coordinateEnemies[i].Item2.Item1, coordinateEnemies[i].Item2.Item2));
								break;
							//DirectionUp
							case 2:
								Console.SetCursorPosition(coordinateEnemies[i].Item2.Item1, coordinateEnemies[i].Item2.Item2);
								Console.Write(" ");
								coordinateEnemies[i].Item2.Item2 -= 1;
								if (coordinateEnemies[i].Item2.Item2 < 0)
								{
									coordinateEnemies[i].Item2.Item2 = 0;
								}
								Console.SetCursorPosition(coordinateEnemies[i].Item2.Item1, coordinateEnemies[i].Item2.Item2);
								Console.Write(Bat._Bat);
								Console.SetCursorPosition(1, 1);
								coordinateEnemies[i] = (Bat._Bat, (coordinateEnemies[i].Item2.Item1, coordinateEnemies[i].Item2.Item2));
								break;
							//DirectionDown
							case 3:
								Console.SetCursorPosition(coordinateEnemies[i].Item2.Item1, coordinateEnemies[i].Item2.Item2);
								Console.Write(" ");
								coordinateEnemies[i].Item2.Item2 += 1;
								if (coordinateEnemies[i].Item2.Item2 > sizeMap - 1)
								{
									coordinateEnemies[i].Item2.Item2 = sizeMap - 1;
								}
								Console.SetCursorPosition(coordinateEnemies[i].Item2.Item1, coordinateEnemies[i].Item2.Item2);
								Console.Write(Bat._Bat);
								Console.SetCursorPosition(1, 1);
								coordinateEnemies[i] = (Bat._Bat, (coordinateEnemies[i].Item2.Item1, coordinateEnemies[i].Item2.Item2));
								break;
							default:
								break;
						}
					}
					if (coordinateEnemies[i].Item1 == Pit._Pit)
					{
						Random rnd = new();
						int randomDirectoin = rnd.Next(4);
						switch (randomDirectoin)
						{
							//DirectionLeft
							case 0:
								Console.SetCursorPosition(coordinateEnemies[i].Item2.Item1, coordinateEnemies[i].Item2.Item2);
								Console.Write(Pit._Pit);
								Console.SetCursorPosition(1, 1);
								coordinateEnemies[i] = (Pit._Pit, (coordinateEnemies[i].Item2.Item1, coordinateEnemies[i].Item2.Item2));
								break;
							//DirectionRight
							case 1:
								Console.SetCursorPosition(coordinateEnemies[i].Item2.Item1, coordinateEnemies[i].Item2.Item2);
								Console.Write(Pit._Pit);
								Console.SetCursorPosition(1, 1);
								coordinateEnemies[i] = (Pit._Pit, (coordinateEnemies[i].Item2.Item1, coordinateEnemies[i].Item2.Item2));
								break;
							//DirectionUp
							case 2:
								Console.SetCursorPosition(coordinateEnemies[i].Item2.Item1, coordinateEnemies[i].Item2.Item2);
								Console.Write(Pit._Pit);
								Console.SetCursorPosition(1, 1);
								coordinateEnemies[i] = (Pit._Pit, (coordinateEnemies[i].Item2.Item1, coordinateEnemies[i].Item2.Item2));
								break;
							//DirectionDown
							case 3:
								Console.SetCursorPosition(coordinateEnemies[i].Item2.Item1, coordinateEnemies[i].Item2.Item2);
								Console.Write(Pit._Pit);
								Console.SetCursorPosition(1, 1);
								coordinateEnemies[i] = (Pit._Pit, (coordinateEnemies[i].Item2.Item1, coordinateEnemies[i].Item2.Item2));
								break;
							default:
								break;
						}
					}
				}
			}
			else
			{
				for (int i = 0; i < coordinateEnemies.Length; i++)
				{
					if (coordinateEnemies[i].Item1 == Wampus._Wampus)
					{
						Random rnd = new();
						int randomDirectoin = rnd.Next(4);
						switch (randomDirectoin)
						{
							//DirectionLeft
							case 0:
								Console.SetCursorPosition(coordinateEnemies[i].Item2.Item1, coordinateEnemies[i].Item2.Item2);
								//Console.Write(" ");
								coordinateEnemies[i].Item2.Item1 -= 3;
								if (coordinateEnemies[i].Item2.Item1 < 1)
								{
									coordinateEnemies[i].Item2.Item1 = 1;
								}
								Console.SetCursorPosition(coordinateEnemies[i].Item2.Item1, coordinateEnemies[i].Item2.Item2);
								//Console.Write(Wampus._Wampus);
								Console.SetCursorPosition(1, 1);
								coordinateEnemies[i] = (Wampus._Wampus, (coordinateEnemies[i].Item2.Item1, coordinateEnemies[i].Item2.Item2));
								break;
							//DirectionRight
							case 1:
								Console.SetCursorPosition(coordinateEnemies[i].Item2.Item1, coordinateEnemies[i].Item2.Item2);
								//Console.Write(" ");
								coordinateEnemies[i].Item2.Item1 += 3;
								if (coordinateEnemies[i].Item2.Item1 > sizeMap * 3 - 2)
								{
									coordinateEnemies[i].Item2.Item1 = (sizeMap * 3) - 2;
								}
								Console.SetCursorPosition(coordinateEnemies[i].Item2.Item1, coordinateEnemies[i].Item2.Item2);
								//Console.Write(Wampus._Wampus);
								Console.SetCursorPosition(1, 1);
								coordinateEnemies[i] = (Wampus._Wampus, (coordinateEnemies[i].Item2.Item1, coordinateEnemies[i].Item2.Item2));
								break;
							//DirectionUp
							case 2:
								Console.SetCursorPosition(coordinateEnemies[i].Item2.Item1, coordinateEnemies[i].Item2.Item2);
								//Console.Write(" ");
								coordinateEnemies[i].Item2.Item2 -= 1;
								if (coordinateEnemies[i].Item2.Item2 < 0)
								{
									coordinateEnemies[i].Item2.Item2 = 0;
								}
								Console.SetCursorPosition(coordinateEnemies[i].Item2.Item1, coordinateEnemies[i].Item2.Item2);
								//Console.Write(Wampus._Wampus);
								Console.SetCursorPosition(1, 1);
								coordinateEnemies[i] = (Wampus._Wampus, (coordinateEnemies[i].Item2.Item1, coordinateEnemies[i].Item2.Item2));
								break;
							//DirectionDown
							case 3:
								Console.SetCursorPosition(coordinateEnemies[i].Item2.Item1, coordinateEnemies[i].Item2.Item2);
								//Console.Write(" ");
								coordinateEnemies[i].Item2.Item2 += 1;
								if (coordinateEnemies[i].Item2.Item2 > sizeMap - 1)
								{
									coordinateEnemies[i].Item2.Item2 = sizeMap - 1;
								}
								Console.SetCursorPosition(coordinateEnemies[i].Item2.Item1, coordinateEnemies[i].Item2.Item2);
								//Console.Write(Wampus._Wampus);
								Console.SetCursorPosition(1, 1);
								coordinateEnemies[i] = (Wampus._Wampus, (coordinateEnemies[i].Item2.Item1, coordinateEnemies[i].Item2.Item2));
								break;
							default:
								break;
						}
					}
					if (coordinateEnemies[i].Item1 == Bat._Bat)
					{
						Random rnd = new();
						int randomDirectoin = rnd.Next(4);
						switch (randomDirectoin)
						{
							//DirectionLeft
							case 0:
								Console.SetCursorPosition(coordinateEnemies[i].Item2.Item1, coordinateEnemies[i].Item2.Item2);
								//Console.Write(" ");
								coordinateEnemies[i].Item2.Item1 -= 3;
								if (coordinateEnemies[i].Item2.Item1 < 1)
								{
									coordinateEnemies[i].Item2.Item1 = 1;
								}
								Console.SetCursorPosition(coordinateEnemies[i].Item2.Item1, coordinateEnemies[i].Item2.Item2);
								//Console.Write(Bat._Bat);
								Console.SetCursorPosition(1, 1);
								coordinateEnemies[i] = (Bat._Bat, (coordinateEnemies[i].Item2.Item1, coordinateEnemies[i].Item2.Item2));
								break;
							//DirectionRight
							case 1:
								Console.SetCursorPosition(coordinateEnemies[i].Item2.Item1, coordinateEnemies[i].Item2.Item2);
								//Console.Write(" ");
								coordinateEnemies[i].Item2.Item1 += 3;
								if (coordinateEnemies[i].Item2.Item1 > sizeMap * 3 - 2)
								{
									coordinateEnemies[i].Item2.Item1 = (sizeMap * 3) - 2;
								}
								Console.SetCursorPosition(coordinateEnemies[i].Item2.Item1, coordinateEnemies[i].Item2.Item2);
								//Console.Write(Bat._Bat);
								Console.SetCursorPosition(1, 1);
								coordinateEnemies[i] = (Bat._Bat, (coordinateEnemies[i].Item2.Item1, coordinateEnemies[i].Item2.Item2));
								break;
							//DirectionUp
							case 2:
								Console.SetCursorPosition(coordinateEnemies[i].Item2.Item1, coordinateEnemies[i].Item2.Item2);
								//Console.Write(" ");
								coordinateEnemies[i].Item2.Item2 -= 1;
								if (coordinateEnemies[i].Item2.Item2 < 0)
								{
									coordinateEnemies[i].Item2.Item2 = 0;
								}
								Console.SetCursorPosition(coordinateEnemies[i].Item2.Item1, coordinateEnemies[i].Item2.Item2);
								//Console.Write(Bat._Bat);
								Console.SetCursorPosition(1, 1);
								coordinateEnemies[i] = (Bat._Bat, (coordinateEnemies[i].Item2.Item1, coordinateEnemies[i].Item2.Item2));
								break;
							//DirectionDown
							case 3:
								Console.SetCursorPosition(coordinateEnemies[i].Item2.Item1, coordinateEnemies[i].Item2.Item2);
								//Console.Write(" ");
								coordinateEnemies[i].Item2.Item2 += 1;
								if (coordinateEnemies[i].Item2.Item2 > sizeMap - 1)
								{
									coordinateEnemies[i].Item2.Item2 = sizeMap - 1;
								}
								Console.SetCursorPosition(coordinateEnemies[i].Item2.Item1, coordinateEnemies[i].Item2.Item2);
								//Console.Write(Bat._Bat);
								Console.SetCursorPosition(1, 1);
								coordinateEnemies[i] = (Bat._Bat, (coordinateEnemies[i].Item2.Item1, coordinateEnemies[i].Item2.Item2));
								break;
							default:
								break;
						}
					}
					if (coordinateEnemies[i].Item1 == Pit._Pit)
					{
						Random rnd = new();
						int randomDirectoin = rnd.Next(4);
						switch (randomDirectoin)
						{
							//DirectionLeft
							case 0:
								Console.SetCursorPosition(coordinateEnemies[i].Item2.Item1, coordinateEnemies[i].Item2.Item2);
								//Console.Write(Pit._Pit);
								Console.SetCursorPosition(1, 1);
								coordinateEnemies[i] = (Pit._Pit, (coordinateEnemies[i].Item2.Item1, coordinateEnemies[i].Item2.Item2));
								break;
							//DirectionRight
							case 1:
								Console.SetCursorPosition(coordinateEnemies[i].Item2.Item1, coordinateEnemies[i].Item2.Item2);
								//Console.Write(Pit._Pit);
								Console.SetCursorPosition(1, 1);
								coordinateEnemies[i] = (Pit._Pit, (coordinateEnemies[i].Item2.Item1, coordinateEnemies[i].Item2.Item2));
								break;
							//DirectionUp
							case 2:
								Console.SetCursorPosition(coordinateEnemies[i].Item2.Item1, coordinateEnemies[i].Item2.Item2);
								//Console.Write(Pit._Pit);
								Console.SetCursorPosition(1, 1);
								coordinateEnemies[i] = (Pit._Pit, (coordinateEnemies[i].Item2.Item1, coordinateEnemies[i].Item2.Item2));
								break;
							//DirectionDown
							case 3:
								Console.SetCursorPosition(coordinateEnemies[i].Item2.Item1, coordinateEnemies[i].Item2.Item2);
								//Console.Write(Pit._Pit);
								Console.SetCursorPosition(1, 1);
								coordinateEnemies[i] = (Pit._Pit, (coordinateEnemies[i].Item2.Item1, coordinateEnemies[i].Item2.Item2));
								break;
							default:
								break;
						}
					}
				}
			}

			return coordinateEnemies;
		}

		private (int, int) FindPlayerAndEnemies((string, (int, int))[] coordinate, NPC enemiesAndUser)
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
				case NPC.Bullet:
					for (int i = 0; i < coordinate.Length; i++)
					{
						if (coordinate[i].Item1 == Bullet._Bullet)
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
		private  void Print(int sizeMap)
		{
			sizeMap = sizeMap * 3 + 5;
			for (int i = 0; i < 6; i++)
			{
				Console.SetCursorPosition(sizeMap, i);
				Console.Write("                        ");
			}
			
			Console.SetCursorPosition(sizeMap, 0);
		}


	}
}
