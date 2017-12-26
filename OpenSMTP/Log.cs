namespace OpenSmtp.Mail {

/******************************************************************************
	Copyright 2001-2004 Ian Stallings
	OpenSmtp.Net is free software; you can redistribute it and/or modify
	it under the terms of the Lesser GNU General Public License as published by
	the Free Software Foundation; either version 2 of the License, or
	(at your option) any later version.

	OpenSmtp.Net is distributed in the hope that it will be useful,
	but WITHOUT ANY WARRANTY; without even the implied warranty of
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
	Lesser GNU General Public License for more details.

	You should have received a copy of the Lesser GNU General Public License
	along with this program; if not, write to the Free Software
	Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
/*******************************************************************************/


using System;
using System.IO;
 
	/// <summary>
	/// This is a Log class. You can log text messages to a 
	/// text file and/or the event log
	/// </summary>
	internal class Log
	{
		
		internal Log() 
		{}
		
		/**
		* Logs string message to TextFile
		*/
		internal void logToTextFile(String path, String msg, String source)
		{
			if (path != null && msg != null && source != null)
			{
				try
				{
					// If the log file exists make sure it is not over the maximum allowable size
					if (File.Exists(path)) {	
						if (new FileInfo(path).Length < SmtpConfig.LogMaxSize) {
							WriteToFile(path, msg, source);
						}
					}
					else
					{
							WriteToFile(path, msg, source);
					}
				}
				catch(Exception e)
				{ Console.WriteLine("An exception occured in logToTextFile: " + e); }
			}
			else
			{
				throw new SmtpException("Null value supplied to Log.logToTextFile().");
			}
		}

		private void WriteToFile(string path, string msg, string source)
		{
			StreamWriter sw = new StreamWriter(path, true);
			sw.Write(source + msg);
			sw.Close();
		}
	}

}