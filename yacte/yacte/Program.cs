using System;
using TextLibrary;

namespace yacte
{
	internal class Program
	{
		#region Constants
		//Constants here, in UPPERCASE
		private const string _AUTHORS = "Fuskare01 and Vijfhoek";
		private const string _TITLE = "YACTE - Yet Another Console Text Editor";
		#endregion

		static void Main(string[] args)
		{
			var tt = new TextTool();
			var comSys = new CommandSystem(args);

			string _VERSION = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

			Console.Title = _TITLE + " | Version: " + _VERSION;

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
