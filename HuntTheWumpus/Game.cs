using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuntTheWumpus
{
	class Game
	{
		public static void Start() 
		{
			Console.SetCursorPosition(0,0);
			Map _ = new(3,3,3,true);
			ControlPlayer controlPlayer = new(_.Players.CoordPlayers, _.Axis.X,true);
			Console.ReadLine();
		}

		internal static void Stop(string message)
		{
			
			bool exit = false;
			Console.Clear();
			Console.Write(message);
			Console.Write(" Хотите сыграть еще? Y-Да / N-Нет");
			do
			{
				Console.SetCursorPosition(10, 5);
				ConsoleKeyInfo key = Console.ReadKey(true);
				Console.SetCursorPosition(10, 6);
				if (key.Key == ConsoleKey.Y)
				{
					exit = true;
					Console.Clear();
					Start();
				}
				else
				{
					Console.WriteLine("Вы ввели что - то не то попробуйте еще раз Y-Да / N-Нет");
				}
			} while (exit);

		}
	}
}
