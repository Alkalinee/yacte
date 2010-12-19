using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace yacte
{
	class TextFile
	{
		private bool IsReading = false;
		private bool IsWriting = false;
		private TextReader _fileRead;
		private TextWriter _fileWrite;

		public bool LoadFile(bool writeMode, string fileName, bool append)
		{
			Console.WriteLine("Opening file \"" + fileName + "\" for " + (writeMode ? "writing" : "reading"));
			try
			{
				if (!writeMode)
				{
					if (!IsWriting)
					{
						_fileRead = new StreamReader(fileName);
						IsReading = true;
					}
					else
					{
						Console.WriteLine("File is open for writing. Please close it first.");
						return false;
					}
				}
				else
				{
					if (!IsReading)
					{
						_fileWrite = new StreamWriter(fileName, append);
						IsWriting = true;
					}
					else
					{
						Console.WriteLine("File is open for reading. Please close it first.");
						return false;
					}
				}
				Console.WriteLine("Successfully opened file!");
				return true;
			}
			catch(Exception ex)
			{
				Console.WriteLine("Error opening file: " + ex.Message + "\n==" + ex.Source + "==");
				return false;
			}
		}

		public bool CloseFile()
		{
			try
			{
				if (IsReading && IsWriting)
				{
					_fileRead.Close();
					_fileWrite.Flush();
					_fileWrite.Close();
					return true;
				}
				if (IsReading)
				{
					_fileRead.Close();
					return true;
				}
				if (IsWriting)
				{
					_fileWrite.Flush();
					_fileWrite.Close();
					return true;
				}
				Console.WriteLine("No files open.");
				return false;
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error closing file: " + ex.Message + "\n==" + ex.Source + "==");
				return false;
			}
		}
	}
}
