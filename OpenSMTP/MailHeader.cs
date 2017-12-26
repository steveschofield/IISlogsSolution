namespace OpenSmtp.Mail {

using System;

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

	/// <summary>
	/// This Type is used to store Mail Headers
	/// <seealso cref="MailMessage"/>
	/// </summary>
	public class MailHeader 
	{ 
		internal string name; 
		internal string body;
		
		public MailHeader(string headerName, string headerBody)
		{
			this.name = headerName;
			this.body = headerBody;
		}

		public string Name 
		{ 
		get { return this.name; } 
		set { this.name = value; } 
		} 

		public string Body 
		{ 
			get { return this.body; } 
			set { this.body = value; } 
		} 

	}


}