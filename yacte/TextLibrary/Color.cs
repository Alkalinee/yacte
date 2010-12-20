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
		/// <summary>
		/// The default foreground color (Gray).
		/// </summary>
		private const ConsoleColor _FOREGROUND = ConsoleColor.Gray;
		/// <summary>
		/// The default background color (Black).
		/// </summary>
		private const ConsoleColor _BACKGROUND = ConsoleColor.Black;
		/// <summary>
		/// The color black (Default background).
		/// </summary>
		public const ConsoleColor Black = ConsoleColor.Black;
		/// <summary>
		/// The color Dark Blue.
		/// </summary>
		public const ConsoleColor DarkBlue = ConsoleColor.DarkBlue;
		/// <summary>
		/// The color Dark Green.
		/// </summary>
		public const ConsoleColor DarkGreen = ConsoleColor.DarkGreen;
		/// <summary>
		/// The color Dark Cyan.
		/// </summary>
		public const ConsoleColor DarkCyan = ConsoleColor.DarkCyan;
		/// <summary>
		/// The color Dark Red.
		/// </summary>
		public const ConsoleColor DarkRed = ConsoleColor.DarkRed;
		/// <summary>
		/// The color Dark Magenta.
		/// </summary>
		public const ConsoleColor DarkMagenta = ConsoleColor.DarkMagenta;
		/// <summary>
		/// The color Dark Yellow (Ochra).
		/// </summary>
		public const ConsoleColor DarkYellow = ConsoleColor.DarkYellow;
		/// <summary>
		/// The color Gray (Default foreground).
		/// </summary>
		public const ConsoleColor Gray = ConsoleColor.Gray;
		/// <summary>
		/// The color Dark Gray.
		/// </summary>
		public const ConsoleColor DarkGray = ConsoleColor.DarkGray;
		/// <summary>
		/// The color Blue.
		/// </summary>
		public const ConsoleColor Blue = ConsoleColor.Blue;
		/// <summary>
		/// The color Green.
		/// </summary>
		public const ConsoleColor Green = ConsoleColor.Green;
		/// <summary>
		/// The color Cyan.
		/// </summary>
		public const ConsoleColor Cyan = ConsoleColor.Cyan;
		/// <summary>
		/// The color Red.
		/// </summary>
		public const ConsoleColor Red = ConsoleColor.Red;
		/// <summary>
		/// The color Magenta.
		/// </summary>
		public const ConsoleColor Magenta = ConsoleColor.Magenta;
		/// <summary>
		/// The color Yellow.
		/// </summary>
		public const ConsoleColor Yellow = ConsoleColor.Yellow;
		/// <summary>
		/// The color White.
		/// </summary>
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
