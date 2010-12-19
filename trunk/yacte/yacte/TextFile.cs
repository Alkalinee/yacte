using System;
using System.IO;
using TextLibrary;

namespace yacte
{
	class TextFile
	{
		private bool IsReading;
		private bool IsWriting;
		private string fileContent = "";
		private TextReader _fileRead;
		private TextWriter _fileWrite;

		private void LoadFile(bool writeMode, string fileName, bool append)
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
						return;
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
						return;
					}
				}
				Console.WriteLine("Successfully opened file!");
			}
			catch(Exception ex)
			{
				Console.WriteLine("Error opening file: " + ex.Message + "\n==" + ex.Source + "==");
			}
		}

		private void CloseFile()
		{
			try
			{
				if (IsReading && IsWriting)
				{
					_fileRead.Close();
					_fileWrite.Flush();
					_fileWrite.Close();
					IsReading = false;
					IsWriting = false;
					return;
				}
				if (IsReading)
				{
					_fileRead.Close();
					IsReading = false;
					return;
				}
				if (IsWriting)
				{
					_fileWrite.Flush();
					_fileWrite.Close();
					IsWriting = false;
					return;
				}
				Console.WriteLine("No files open.");
				return;
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error closing file: " + ex.Message + "\n==" + ex.Source + "==");
				return;
			}
		}

		public void WriteContent(string content, bool append)
		{
			try
			{
				if (append)
					fileContent += Environment.NewLine + content;
				else
					fileContent = content;
				Console.WriteLine("Successfully added text!");
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error adding text: " + ex.Message + "\n==" + ex.Source + "==");
			}
		}

		public void SaveFile(string fileName, bool append)
		{
			try
			{
				if (IsReading)
				{
					Console.WriteLine("File is open for reading, please close it before writing.");
					return;
				}
				LoadFile(true, fileName, append);
				_fileWrite.Write(fileContent);
				CloseFile();
				Console.WriteLine("Successfully wrote to file!");
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error writing to file: " + ex.Message + "\n==" + ex.Source + "==");
			}
		}

		public void ReadContent()
		{
			Console.WriteLine(fileContent);
		}

		public void ReadFile(string fileName)
		{
			if (IsWriting)
			{
				Console.WriteLine("File is open for writing, please close it before reading.");
				return;
			}
			try
			{
				TextTool tt = new TextTool();
				LoadFile(false, fileName, true);
				fileContent = _fileRead.ReadToEnd();
				CloseFile();
				tt.PrintSeparator();
				Console.WriteLine(fileContent);
				tt.PrintSeparator();
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error when reading file: " + ex.Message + "\n==" + ex.Source + "==");
			}
		}

		public void Wipe()
		{
			fileContent = "";
		}
	}
}
