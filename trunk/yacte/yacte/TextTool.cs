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
		private readonly int CONSOLE_WIDTH = Console.WindowWidth;
		public int p_CONSOLE_WIDTH
		{
			get { return CONSOLE_WIDTH; }
		}

		private readonly int CONSOLE_HEIGHT = Console.WindowHeight;
		public int p_CONSOLE_HEIGHT
		{
			get { return CONSOLE_HEIGHT; }
		}

		public void PrintLine()
		{
			for(int i = 0; i < CONSOLE_WIDTH; i++)
			{
				Console.Write("-");
			}
			Console.WriteLine();
		}
	}
}
