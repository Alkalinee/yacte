using System;

namespace yacte
{
	internal class Program
	{
		#region Constants
		//Constants here, in UPPERCASE
		private const string _AUTHORS = "Fuskare01 and Vijfhoek";
		private const double _VERSION = 0.10;
		private const string _TITLE = "YACTE - Yet Another Console Text Editor";
		#endregion

		static void Main(string[] args)
		{
			var tt = new TextTool();
			var comSys = new CommandSystem(args);

			Console.Title = _TITLE;

			tt.PrintLogo();

			Console.WriteLine("Welcome to YACTE! For a list of commands, type :l");

			while (true)
			{
				Console.Write("> ");
				string line = Console.ReadLine();
				Console.WriteLine();
				comSys.HandleInput(line);
			}
		}
	}
}
