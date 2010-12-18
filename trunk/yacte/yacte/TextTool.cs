using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
		public int p_CONSOLE_WIDTH
		{
			get { return CONSOLE_WIDTH; }
		}

		/// <summary>
		/// The height of the console (the number of "rows")
		/// </summary>
		private readonly int CONSOLE_HEIGHT = Console.WindowHeight;
		public int p_CONSOLE_HEIGHT
		{
			get { return CONSOLE_HEIGHT; }
		}

		/// <summary>
		/// Prints a horizontal line (----) with a newline.
		/// </summary>
		public void PrintSeparator()
		{
			for(int i = 0; i < CONSOLE_WIDTH; i++)
				Console.Write("-");
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
