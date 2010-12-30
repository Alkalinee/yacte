using System;
using TextLibrary;

namespace yacte
{
	internal class Program
	{
		#region Constants
		//Constants here, in UPPERCASE
		//private const string _AUTHORS = "Fuskare01 and Vijfhoek";
		private const string _TITLE = "YACTE - Yet Another Console Text Editor";
		#endregion

		static void Main(string[] args)
		{
			var tt = new TextTool();
			var comSys = new CommandSystem(args);

			string version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

			Console.Title = _TITLE + " | Version: " + version;

			tt.PrintLogo();
			Console.WriteLine("Welcome to YACTE! For a list of commands, type :l\n"
							 +"Commands are preceeded by a colon (:).\n"
							 +"To add text to a file, simply type something without a colon at the beginning.\n"
							 +"If you want to write a colon at the start of the line, escape it with '\\'\n"
							 +"i.e: \"\\:myLabel\"");

			while (true)
			{
				Console.Write("> ");
				string line = Console.ReadLine();
				Console.WriteLine();
				comSys.HandleInput(line);
			}
		// ReSharper disable FunctionNeverReturns
		}
		// ReSharper restore FunctionNeverReturns
	}
}
