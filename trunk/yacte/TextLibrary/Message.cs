using System;

namespace TextLibrary
{
	public static class Message
	{
		#region Constants
		private const ConsoleColor NotifyColor = Color.Cyan;
		private const ConsoleColor WarningColor = Color.Yellow;
		private const ConsoleColor ErrorColor = Color.Red;
		#endregion

		public static void Notify(string message)
		{
			Color.Set(NotifyColor);
			Console.WriteLine(message);
			Color.Reset();
		}

		public static void Warning(string message)
		{
			Color.Set(WarningColor);
			Console.WriteLine("Warning: " + message);
			Color.Reset();
		}

		public static void Error(string message)
		{
			Color.Set(ErrorColor);
			Console.WriteLine("Error: " + message);
			Color.Reset();
		}

		public static void Exception(Exception ex)
		{
			Exception(ex, null);
		}

		public static void Exception(Exception ex, string message)
		{
			var tt = new TextTool();
			Color.Set(ErrorColor);
			tt.PrintSeparator('=');
			Color.Set(Color.White);
			Console.WriteLine("Error occurred in: " + ex.TargetSite);
			Console.WriteLine("Exception: " + ex);
			Console.WriteLine("Source: " + ex.Source);
			Console.WriteLine('"' + ex.Message + '"');
			if (!string.IsNullOrEmpty(message))
				Console.WriteLine(Environment.NewLine + "Info: " + message);
			Color.Set(ErrorColor);
			tt.PrintSeparator('=');
			Color.Reset();
		}
	}
}
