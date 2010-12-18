using System;
using System.IO;

namespace yacte
{
	internal class Program
	{
		#region Constants
		//Constants here, in UPPERCASE
		private const string AUTHORS = "Fuskare01 and Vijfhoek";
		private const double VERSION = 0.10;
		#endregion

		static void Main(string[] args)
		{
			TextTool TT = new TextTool();

			int numArgs = args.Length;
			string fileName = "";
			string fileContent = "";
			bool loopMenu = true;
			if (numArgs <= 0)
			{
				do
				{
					Console.Write("Please specify a file (relative to the exe dir): ");
					fileName = Console.ReadLine().Trim();
				} while (string.IsNullOrEmpty(fileName));
			}
			else
			{
				fileName = args[1]; //We assume the filename is the first argument.
			}
			Console.WriteLine("File: " + fileName);
			TextReader SR;
			if (File.Exists(fileName))
			{
				try
				{
                    SR = new StreamReader(fileName);
					TT.PrintSeparator();
					fileContent = SR.ReadToEnd();
					Console.WriteLine("Contents:\n" + fileContent);
					TT.PrintSeparator();
                    SR.Close();     
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
            TextWriter SW;
			do
			{
				Console.WriteLine("What do you want to write?");
				fileContent = Console.ReadLine();
				TT.PrintSeparator();
				Console.WriteLine("New content:\n\n" + fileContent);
				TT.PrintSeparator();
				Console.WriteLine("Do you want to save this? (Y/n)");
                string choice = Console.ReadLine();
				choice = !string.IsNullOrEmpty(choice) ? choice.ToUpper() : "";
                if (choice == "" || choice == "Y")
				{
					try
					{
                        SW = new StreamWriter(fileName, true);
						SW.WriteLine(fileContent);
                        SW.Flush();
                        SW.Close();
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
