using System;
using System.IO;
using TextLibrary;

namespace yacte
{
	class CommandSystem
	{
		readonly TextFile textFile = new TextFile();
		readonly TextTool tt = new TextTool();

		#region Constants
		//Constants here in UPPERCASE
		private const char _PREFIX = ':';
		private const char _ESCAPE = '\\';
		private const string _QUIT = "q";
		private const string _OPEN = "o";
		private const string _SAVE = "s";
		private const string _REPLACE = "r";
		private const string _LIST = "l";
		private const string _SAVEQUIT = "x";
		#endregion

		private string fileName;

		public CommandSystem(string[] clArgs)
		{
			int numArgs = clArgs.Length;
			fileName = "";
			if (numArgs > 0)
				if (!string.IsNullOrEmpty(clArgs[0]))
					fileName = clArgs[0];
		}

		public bool IsCommand(string line)
		{
			if (line.StartsWith(_PREFIX.ToString()))
				return true;
			return false;
		}

		public void HandleInput(string line)
		{
			if (IsCommand(line))
			{
				line = line.TrimStart(_PREFIX);
				string args = line.Substring(1);
				string command = line.Substring(0, 1);

				switch (command)
				{
					case _QUIT:
						if (textFile.IsModified(fileName) && string.IsNullOrEmpty(args))
						{
							Console.WriteLine("File has been modified, do you want to save? (Y/n)");
							string choice;
							do
							{
								Console.Write("> ");
								choice = Console.ReadLine();
								if (!string.IsNullOrEmpty(choice))
									choice = choice.Substring(0, 1).ToUpper();
							} while (string.IsNullOrEmpty(choice));
							if (choice == "" || choice == "Y")
								textFile.SaveFile(fileName.Trim(), false);
						}
						else
						{
							Console.WriteLine("kthxbai");
							Environment.Exit(0);
						}
						break;
					case _SAVE:
						if (!string.IsNullOrEmpty(fileName))
							textFile.SaveFile(fileName.Trim(), false);
						else
							Console.WriteLine("Error: No file is open, please open a file with \":o <fileName>\" before saving.");
						break;
					case _SAVEQUIT:
						if (!string.IsNullOrEmpty(fileName))
							textFile.SaveFile(fileName.Trim(), false);
						Console.WriteLine("kthxbai");
						Environment.Exit(0);
						break;
					case _REPLACE:
						//TODO: Add replace code here
						break;
					case _OPEN:
						textFile.Wipe();
						if (!string.IsNullOrEmpty(args))
						{
							fileName = args.Trim();
							if (File.Exists(fileName))
							{
								textFile.ReadFile(fileName);
							}
							else
							{
								Console.WriteLine("File \"" + fileName + "\" does not exist. It will be created when you save.");
							}
						}
						else
						{
							Console.WriteLine("Error: No filename specified.");
						}
						break;
					case _LIST:
						//TODO: List commands here
						Console.WriteLine("Command listing coming soon!");
						break;
					default:
						//TODO: Print a list of commands
						Console.WriteLine("Invalid command: \"" + command + "\"");
						break;
				}
			}
			else
			{
				if (!string.IsNullOrEmpty(fileName))
				{
					if (line.StartsWith(_ESCAPE.ToString()))
						line = line.TrimStart(_ESCAPE);
					textFile.WriteContent(line, true);
					tt.PrintSeparator();
					textFile.ReadContent();
					tt.PrintSeparator();
				}
				else
				{
					Console.WriteLine("Please open a file with \":o <fileName>\" before trying to write.");
				}
			}
		}
	}
}
