using System;
using System.IO;

namespace yacte
{
	internal class Program
	{
		private const string authors = "Fuskare01 and Vijfhoek";

		static void Main(string[] args)
		{
			TextTool TT = new TextTool();

			//Just making something to test SVN
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
					Console.WriteLine("Contents:\n" + SR.ReadLine());
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
				fileContent += Console.ReadLine();
				TT.PrintSeparator();
				Console.WriteLine("New content:\n\n" + fileContent);
				TT.PrintSeparator();
				Console.WriteLine("Do you want to save this? (Y/n)");
				//TODO: Null-checks
				string choice = Console.ReadLine().ToUpper();
				if (choice == "Y" || choice == "")
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
					//TODO: Null-checks
					choice = Console.ReadLine().ToUpper();
					if (choice == "Y")
						loopMenu = false;
				}
			} while (loopMenu);
		}
	}
}
