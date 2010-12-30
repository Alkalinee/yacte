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

		/// <summary>
		/// Send a notify message to the user (displayed in cyan).
		/// </summary>
		/// <param name="message">The message to send.</param>
		public static void Notify(string message)
		{
			Color.Set(NotifyColor);
			Console.WriteLine(message);
			Color.Reset();
		}

		/// <summary>
		/// Send a warning message to the user (displayed in yellow and prefixed with "Warning: ").
		/// </summary>
		/// <param name="message">The message to send.</param>
		public static void Warning(string message)
		{
			Color.Set(WarningColor);
			Console.WriteLine("Warning: " + message);
			Color.Reset();
		}

		/// <summary>
		/// Send an error message to the user (displayed in red and prefixed with "Error: ").
		/// </summary>
		/// <param name="message">The message to send.</param>
		public static void Error(string message)
		{
			Color.Set(ErrorColor);
			Console.WriteLine("Error: " + message);
			Color.Reset();
		}

		/// <summary>
		/// Print exception info.
		/// </summary>
		/// <param name="ex">The exception to use.</param>
		public static void Exception(Exception ex)
		{
			Exception(ex, null);
		}

		/// <summary>
		/// Print exception info.
		/// </summary>
		/// <param name="ex">The exception to use.</param>
		/// <param name="message">Additional info to display.</param>
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
