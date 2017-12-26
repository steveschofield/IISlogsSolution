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
	/// This Type is used to store known SMTP responses specified by RFC 821 and 2821
	/// </summary>
	internal class ReplyConstants
	{
		private ReplyConstants()
		{}

		public static readonly string SYSTEM_STATUS					= "211";
		public static readonly string HELP_MSG						= "214";
		public static readonly string HELO_REPLY 					= "220";
		public static readonly string QUIT 							= "221";
		public static readonly string AUTH_SUCCESSFUL 				= "235";
		public static readonly string OK 							= "250";
		public static readonly string NOT_LOCAL_WILL_FORWARD		= "251";
		public static readonly string SERVER_CHALLENGE				= "334";
		public static readonly string START_INPUT 					= "354";
		public static readonly string SERVICE_NOT_AVAILABLE			= "421";
		public static readonly string MAILBOX_BUSY 					= "450";
		public static readonly string ERROR_PROCESSING				= "451";
		public static readonly string INSUFFICIENT_STORAGE			= "452";
		public static readonly string UNKNOWN 						= "500";
		public static readonly string SYNTAX_ERROR					= "501";
		public static readonly string CMD_NOT_IMPLEMENTED			= "502";
		public static readonly string BAD_SEQUENCE					= "503";
		public static readonly string NOT_IMPLEMENTED				= "504";
		public static readonly string SECURITY_ERROR 				= "505";
		public static readonly string ACTION_NOT_TAKEN 				= "550";
		public static readonly string NOT_LOCAL_PLEASE_FORWARD 		= "551";
		public static readonly string EXCEEDED_STORAGE_ALLOWANCE	= "552";
		public static readonly string MAILBOX_NAME_NOT_ALLOWED		= "553";
		public static readonly string TRANSACTION_FAILED			= "554";

		public static readonly string PIPELINING					= "PIPELINING";

	}
}