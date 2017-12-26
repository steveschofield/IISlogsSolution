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
	/// This type stores configuration information for the smtp component.
	/// WARNING: If you turn on logging the caller must have proper permissions
	/// and the log file will grow very quickly if a lot of email messages are 
	/// being sent. PLEASE USE THE LOGGING FEATURE FOR DEBUGGING ONLY.
	/// </summary>
	public class SmtpConfig
	{
		private SmtpConfig()
		{}
		
		///<value>Stores the default SMTP host</value>
		public static string 	SmtpHost 			= "localhost";

		///<value>Stores the default SMTP port</value>
		public static int 		SmtpPort 			= 25;

		///<value>Flag used for turning on and off logging to a text file.
		/// The caller must have proper permissions for this to work</value>
		public static bool		LogToText			= false;

		///<value>Path to use when logging to a text file. 
		/// The caller must have proper permissions for this to work</value>
		public static string 	LogPath 			= @"../logs/SmtpLog.txt";

		public static long		LogMaxSize			= 1048576; // one meg
		
		///<value>Path used to store temp files used when sending email messages.
		/// The default value is the temp directory specified in the Environment variables.</value>
		public static string	TempPath 			= Path.GetTempPath();
		
		///<value>Flag used to turn on and off address format verification.
		/// If it is turned on all addresses must meet RFC 822 format.
		/// The default value is false.
		/// WARNING: Turning this on will decrease performance.</value>
		public static bool		VerifyAddresses		= false;
		
		///<value>Version of this OpenSmtp SMTP .Net component</value>
		public static readonly string Version		= "OpenSmtp.net version 01.09.7";
		
		///<value>Mailer header added to each message sent</value>
		internal static string 	X_MAILER_HEADER		= "X-Mailer: OpenSmtp.net";
	}
}