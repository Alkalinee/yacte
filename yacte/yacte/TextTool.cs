using System;

namespace yacte
{
	/// <summary>
	/// Provides various methods to manipulate text.
	/// </summary>
	class TextTool
	{
		/// <summary>
		/// The width of the console (the number of "columns")
		/// </summary>
		private readonly int CONSOLE_WIDTH = Console.WindowWidth;

		/*This is never used, commented.
		/// <summary>
		/// The height of the console (the number of "rows")
		/// </summary>
		private readonly int CONSOLE_HEIGHT = Console.WindowHeight;
		 */

		public void PrintLogo()
		{
			const int logoWidth = 51;
			int margin = (int)Math.Ceiling((double)(CONSOLE_WIDTH - logoWidth) / 2);
			var logo = new[]
			{
				"Y       Y    A          CCCCC  TTTTTTTTT  EEEEEEE",
				" Y     Y    A A        C           T      E      ",
				"  Y   Y    A   A      C            T      E      ",
				"   Y Y    A     A    C             T      EEEE   ",
				"    Y    AAAAAAAAA    C            T      E      ",
				"    Y   A         A    C           T      E      ",
				"    Y  A           A    CCCCC      T      EEEEEEE",
				"---------Yet Another Console Text Editor---------"
			};
			Console.WriteLine();
			for (int n = 0; n < 8; n++)
			{
				char spacer = (n == 7) ? '-' : ' ';

				for (int i = 0; i < margin; i++)
				{
					Console.Write(spacer);
				}
				Console.Write(logo[n]);
				for (int i = 0; i < margin; i++)
				{
					Console.Write(spacer);
				}
				Console.WriteLine();
			}
			Console.WriteLine();
		}

		/// <summary>
		/// Prints a horizontal line.
		/// </summary>
		public void PrintSeparator()
		{
			PrintSeparator(0, '-');
		}

		/// <summary>
		/// Prints a horizontal line.
		/// </summary>
		/// <param name="separator">The character to use as separator.</param>
		public void PrintSeparator(char separator)
		{
			PrintSeparator(0, separator);
		}

		/// <summary>
		/// Prints a horizontal line.
		/// </summary>
		/// <param name="width">The width of the line.</param>
		public void PrintSeparator(int width)
		{
			PrintSeparator(width, '-');
		}

		/// <summary>
		/// Prints a horizontal line.
		/// </summary>
		/// <param name="width">The width of the line. (0 for auto-width)</param>
		/// <param name="separator">The character to use as separator.</param>
		public void PrintSeparator(int width, char separator)
		{
			if (width <= 0 || width >= CONSOLE_WIDTH) // To prevent it being splitted over 2 lines
				width = CONSOLE_WIDTH;

			for (int i = 0; i < width; i++)
				Console.Write(separator);

			if (width < CONSOLE_WIDTH)
				Console.WriteLine();
		}

		/// <summary>
		/// Replaces a word or string with another string.
		/// </summary>
		/// <param name="content">The string to be replaced.</param>
		/// <param name="search">Original string.</param>
		/// <param name="replace">The string to replace all current occurrences of "search".</param>
		/// <returns>The new string with replaced strings if successful, null if failed.</returns>
		public string Replace(string content, string search, string replace)
		{
			Console.WriteLine("Replacing \"" + search + "\" with \"" + replace + "\".");
			if (content.Contains(search))
			{
				try
				{
					content = content.Replace(search, replace);
					Console.WriteLine("Successfully replaced word!");
					return content;
				}
				catch (Exception ex)
				{
					Console.WriteLine("Error replacing text, exception: " + ex.Message + "\n==" + ex.Source + "==");
				}
			}
			return null;
		}
	}
}
