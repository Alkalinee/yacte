using System;
using System.IO;

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
			var comSys = new CommandSystem();

			Console.Title = _TITLE;

			tt.PrintLogo();

			int numArgs = args.Length;
			string fileName;
			string fileContent = "";
			string oldFileContent = "";
			bool loopMenu = true;
			if (numArgs <= 0)
			{
				do
				{
					Console.Write("Please specify a file (relative to the exe dir): ");
					fileName = Console.ReadLine();
					if (!string.IsNullOrEmpty(fileName))
						fileName = fileName.Trim();
				} while (string.IsNullOrEmpty(fileName));
			}
			else
			{
				fileName = args[1]; //We assume the filename is the first argument.
			}
			Console.WriteLine("File: " + fileName);
			TextReader sr;
			if (File.Exists(fileName))
			{
				try
				{
					sr = new StreamReader(fileName);
					tt.PrintSeparator();
					oldFileContent = sr.ReadToEnd();
					Console.WriteLine("Contents:\n" + oldFileContent);
					tt.PrintSeparator();
					sr.Close();     
				}
				catch (Exception ex)
				{
					Console.WriteLine("Error reading file, exception: " + ex.Message + "\n==" + ex.Source + "==");
				}
			}
			else
			{
				Console.WriteLine("File does not exist, file will be created when you save.");
			}
			TextWriter sw;
			do
			{
				Console.WriteLine("What do you want to write?");
				fileContent += Console.ReadLine();
				tt.PrintSeparator();
				Console.WriteLine("New content:\n\n" + oldFileContent + fileContent);
				tt.PrintSeparator();
				Console.WriteLine("Do you want to save this? (Y/n)");
				string choice = Console.ReadLine();
				choice = !string.IsNullOrEmpty(choice) ? choice.ToUpper() : "";
				if (choice == "" || choice == "Y")
				{
					try
					{
						Console.WriteLine("Do you want to overwrite the current file? (y/N)");
						string owChoice = Console.ReadLine();
						owChoice = !string.IsNullOrEmpty(owChoice) ? owChoice.ToUpper() : "N";
						bool append = owChoice.Equals("N");
						sw = new StreamWriter(fileName, append);
						sw.WriteLine(fileContent);
						sw.Flush();
						sw.Close();
					}
					catch (Exception ex)
					{
						Console.WriteLine("Error writing to file, exception:\n" + ex.Message + "\n==" + ex.Source + "==");
					}
					Console.WriteLine("Successfully wrote to file!");
					Console.WriteLine("Do you want to exit? (y/N)");
					choice = Console.ReadLine();
					choice = !string.IsNullOrEmpty(choice) ? choice.ToUpper() : "";
					if (choice == "Y")
						loopMenu = false;
				}
			} while (loopMenu);
		}
	}
}
