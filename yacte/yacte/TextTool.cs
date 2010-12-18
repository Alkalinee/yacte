using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace yacte
{
	/// <summary>
	/// Provides various methods to print horizontal lines and other "ascii-art".
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
			{
				Console.Write("-");
			}
		}
	}
}
