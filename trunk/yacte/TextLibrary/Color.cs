using System;

namespace TextLibrary
{
	public static class Color
	{
		#region Constants
		//Put constants here
		#endregion

		#region Color Constants
		//DO NOT MODIFY
		private const ConsoleColor _FOREGROUND = ConsoleColor.Gray;
		private const ConsoleColor _BACKGROUND = ConsoleColor.Black;
		public const ConsoleColor Black = ConsoleColor.Black;
		public const ConsoleColor DarkBlue = ConsoleColor.DarkBlue;
		public const ConsoleColor DarkGreen = ConsoleColor.DarkGreen;
		public const ConsoleColor DarkCyan = ConsoleColor.DarkCyan;
		public const ConsoleColor DarkRed = ConsoleColor.DarkRed;
		public const ConsoleColor DarkMagenta = ConsoleColor.DarkMagenta;
		public const ConsoleColor DarkYellow = ConsoleColor.DarkYellow;
		public const ConsoleColor Gray = ConsoleColor.Gray;
		public const ConsoleColor DarkGray = ConsoleColor.DarkGray;
		public const ConsoleColor Blue = ConsoleColor.Blue;
		public const ConsoleColor Green = ConsoleColor.Green;
		public const ConsoleColor Cyan = ConsoleColor.Cyan;
		public const ConsoleColor Red = ConsoleColor.Red;
		public const ConsoleColor Magenta = ConsoleColor.Magenta;
		public const ConsoleColor Yellow = ConsoleColor.Yellow;
		public const ConsoleColor White = ConsoleColor.White;
		#endregion

		/// <summary>
		/// Set the color of the foreground (text) in the console.
		/// </summary>
		/// <param name="foreGround">Color to use (Color.[COLOR])</param>
		public static void Set(ConsoleColor foreGround)
		{
			Set(foreGround, _BACKGROUND);
		}

		/// <summary>
		/// Set the color of the console.
		/// </summary>
		/// <param name="foreGround">Foreground color to use (Color.[COLOR])</param>
		/// <param name="backGround">Background color to use (Color.[COLOR])</param>
		public static void Set(ConsoleColor foreGround, ConsoleColor backGround)
		{
			Console.ForegroundColor = foreGround;
			Console.BackgroundColor = backGround;
		}

		public static void Reset()
		{
			Console.ResetColor();
		}
	}
}
