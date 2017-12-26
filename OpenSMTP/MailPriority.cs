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

	/// <summary>
	/// This Type stores different priority values used for a MailMessage
	/// <seealso cref="MailMessage"/>
	/// </summary>
	/// <example>
	/// <code>
	///		from = new EmailAddress("support@OpenSmtp.com", "Support");
	///		to = new EmailAddress("recipient@OpenSmtp.com", "Joe Smith");
	///		msg = new MailMessage(from, to);
	///		msg.Priority = MailPriority.High;
	/// </code>
	/// </example>
	public class MailPriority
	{

		public static readonly string Highest 	= 	"1";
		public static readonly string High		= 	"2";
		public static readonly string Normal	= 	"3";
		public static readonly string Low   	=	"4";
		public static readonly string Lowest	=	"5";
	
		private MailPriority() 
		{}
	
	}
}
	
