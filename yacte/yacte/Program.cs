using System;
using System.IO;

namespace yacte
{
	internal class Program
	{
		private const string authors = "Fuskare01 and Vijfhoek";
		static void Main(string[] args)
		{
			//Just making something to test SVN
			int numArgs = args.Length;
			string fileName = "";
			string fileContent = "";
			bool loopMenu = true;
			if (numArgs <= 0)
			{
				Console.Write("Please specify a file (relative to the exe dir):");
				//TODO: Null-checks on fileName
				fileName = Console.ReadLine();
			}
			else
			{
				fileName = args[1]; //We assume the filename is the first argument.
			}
			Console.WriteLine("File: " + fileName);
			TextReader SR;
			if (File.Exists(fileName))
			{
				SR = new StreamReader(fileName);
				try
				{
					Console.WriteLine("Contents:\n" + SR.ReadLine());
				}
				catch (Exception ex)
				{
					Console.WriteLine("Error reading file, exception: " + ex.Message + "\n==" + ex.Source + "==");
				}
				SR.Close();
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
				Console.WriteLine("New content:\n\n" + fileContent);
				Console.WriteLine("Do you want to save this? (Y/n)");
				//TODO: Null-checks
				string choice = Console.ReadLine().ToUpper();
				if (choice == "Y" || choice == "")
				{
					try
					{
                        SW = new StreamWriter(fileName);
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
