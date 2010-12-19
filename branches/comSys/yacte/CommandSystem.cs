using System;
using System.Text;

namespace yacte
{
	class CommandSystem
	{
		private const char _PREFIX = ':';

		private const string _QUIT = "q";
		private const string _OPEN = "o";
		private const string _SAVE = "s";
		private const string _REPLACE = "r";

		public bool IsCommand(string line)
		{
			if (line.StartsWith(_PREFIX.ToString()))
				return true;
			return false;
		}

		public void HandleCommand(string command)
		{
			command = command.TrimStart(_PREFIX);
			string args = command.Substring(1);
			command = command.Substring(0, 1);

			switch (command)
			{
				case _QUIT:
					Console.WriteLine("kthxbai");
					Environment.Exit(0);
					break;
				case _SAVE:
					//Add save code here
					break;
				case _REPLACE:
					//Add replace code here
					break;
				case _OPEN:
					//Add open code here
					break;
				default:
					//Print a list of commands
					Console.WriteLine("Invalid command: \"" + command + "\"");
					break;
			}
		}
	}
}
