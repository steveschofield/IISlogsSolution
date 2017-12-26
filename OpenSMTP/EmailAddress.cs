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
	using System.Text.RegularExpressions;

	/// <summary>This enumeration stores the Address type</summary>
	/// <example>
	/// <code>
	/// msg.AddRecipient(ccAddress, AddressType.Cc);
	/// msg.AddRecipient(bccAddress, AddressType.Bcc);
	/// </code>
	/// </example>
	public enum AddressType
	{
	   To = 1,
	   Cc = 2,
	   Bcc = 3
	}

	/// <summary>This Type stores a rfc822 email address and a name for that
	/// particular address (Example: "John Smith, jsmith@nowhere.com")
	/// </summary>
	/// <example>
	/// <code>
	/// EmailAddress from = new EmailAddress("user@url.com", "John Smith");
	/// EmailAddress to = new EmailAddress("support@OpenSmtp.com");
	/// MailMessage msg = new MailMessage(from, to);
	/// </code>
	/// </example>
	public class EmailAddress
	{
		internal 	string 	address;
		internal 	string 	name;
		internal 	string 	mailbox;
		internal	string 	localpart;
		private		string 	domain;
		private 	string 	quotedstr;
		private 	bool 	isvalid = false;

		private static Regex oRegex;
		private const string Escape		= @"\\";
		private const string Period		= @"\.";
		private const string Space		= @"\040";
		private const string Tab		= @"\t";
		private const string OpenBr		= @"\[";
		private const string CloseBr	= @"\]";
		private const string OpenParen	= @"\(";
		private const string CloseParen = @"\)";
		private const string NonAscii	= @"\x80-\xff";
		private const string Ctrl		= @"\000-\037";
		private const string CRList		= @"\n\015";
		

		/// <summary>Constructor using RFC 822 formatted email mesage</summary>
		/// <example>
		/// <code>EmailAddress a = new EmailAddress("support@OpenSmtp.com");</code>
		/// </example>
		public EmailAddress(string address)
		{
			if (SmtpConfig.VerifyAddresses)
			{
				initregex();		
				Parse(address);
			}

			this.address = address;
		}
		
		/// <summary>Constructor using RFC 822 formatted email mesage and a friendly 
		/// name associated with that email address</summary>
		/// <example>
		/// <code>EmailAddress a = new EmailAddress("support@OpenSmtp.com", "John Smith");</code>
		/// </example>
		public EmailAddress(string address, string name)
		{
			if (SmtpConfig.VerifyAddresses)
			{
				initregex();
				Parse(address);
			}
			
			this.address = address;
			this.name 	 = name;
		}

		/// <value>Stores a RFC 822 formatted message</value>
		/// <seealso cref="SmtpConfig.VerifyAddresses"/>
		/// <example>"support@OpenSmtp.com"</example>
		public string Address
		{
			get { return(this.address); }
			set { 
					if (SmtpConfig.VerifyAddresses)
					{ Parse(value); }
					this.address = value; 
				}
		}

		/// <value>Stores a name associated with the Address</value>
		/// <example>"John Smith"</example>
		public string Name
		{
			get { return(this.name); }
			set { this.name = value; }
		}
		
		public string LocalPart
		{
			get { return localpart; }
		}

		public string Domain
		{
			get { return domain; }
		}

		public string QuotedString
		{
			get { return quotedstr; }
		}

		public string Mailbox
		{
			get { return mailbox; }
		}

		public bool IsValid
		{
			get { return isvalid; }
		}

		public bool Parse(string email)
		{
			// Match against the regex...
			Match m = EmailAddress.oRegex.Match(email);

			this.isvalid = m.Success;
			this.domain = m.Groups["domain"].ToString();
			this.localpart = m.Groups["localpart"].ToString();
			this.mailbox = m.Groups["mailbox"].ToString();
			this.quotedstr = m.Groups["quotedstr"].ToString();
			this.name = m.Groups["quotedstr"].ToString();

			if (!this.isvalid)
			{	
				throw new MalformedAddressException("Supplied email address is invalid: " + address);
			}

			return this.isvalid;
		}


		/// <summary>
		/// Initialize the regex and compiles it so that it runs a little faster.
		/// </summary>
		private void initregex()
		{
		
			// for within "";
			string qtext = @"[^" + EmailAddress.Escape + 
				EmailAddress.NonAscii + 
				EmailAddress.CRList + "\"]";
			string dtext = @"[^" + EmailAddress.Escape + 
				EmailAddress.NonAscii + 
				EmailAddress.CRList + 
				EmailAddress.OpenBr + 
				EmailAddress.CloseBr + "\"]";

			string quoted_pair = " " + EmailAddress.Escape + " [^" + EmailAddress.NonAscii + "] ";

			// *********************************************
			// comments.
			// Impossible to do properly with a regex, I make do by allowing at most 
			// one level of nesting.
			string ctext = @" [^" + EmailAddress.Escape + 
				EmailAddress.NonAscii + 
				EmailAddress.CRList + "()] ";
			
			// Nested quoted Pairs
			string Cnested = "";
			Cnested += EmailAddress.OpenParen;
			Cnested += ctext + "*";
			Cnested += "(?:" + quoted_pair + " " + ctext + "*)*";
			Cnested += EmailAddress.CloseParen;

			// A Comment Usually 
			string comment = "";
			comment += EmailAddress.OpenParen;
			comment += ctext + "*";
			comment += "(?:";
			comment += "(?: " + quoted_pair + " | " + Cnested + ")";
			comment += ctext + "*";
			comment += ")*";
			comment += EmailAddress.CloseParen;
			
			// *********************************************
			// X is optional whitespace/comments
			string X = "";
			X += "[" + EmailAddress.Space + EmailAddress.Tab + "]*";
			X += "(?: " + comment + " [" + EmailAddress.Space + EmailAddress.Tab + "]* )*";
			
			// an email address atom... it's not nuclear ;)
			string atom_char = @"[^(" + EmailAddress.Space + ")<>\\@,;:\\\"." + EmailAddress.Escape + EmailAddress.OpenBr + 
				EmailAddress.CloseBr +
				EmailAddress.Ctrl +
				EmailAddress.NonAscii + "]";
			string atom = "";
				atom += atom_char + "+";
				atom += "(?!" + atom_char + ")";

			// doublequoted string, unrolled.
			string quoted_str = "(?'quotedstr'";
				quoted_str += "\\\"";
				quoted_str += qtext + " *";
				quoted_str += "(?: " + quoted_pair + qtext + " * )*";
				quoted_str += "\\\")";

			// A word is an atom or quoted string
			string word = "";
				word += "(?:";
				word += atom;
				word += "|";
				word += quoted_str;
				word += ")";
			
			// A domain-ref is just an atom
			string domain_ref = atom;

			// A domain-literal is like a quoted string, but [...] instead of "..."
			string domain_lit = "";
				domain_lit += EmailAddress.OpenBr;
				domain_lit += "(?: " + dtext + " | " + quoted_pair + " )*";
				domain_lit += EmailAddress.CloseBr;

			// A sub-domain is a domain-ref or a domain-literal
			string  sub_domain = "";
				sub_domain += "(?:";
				sub_domain += domain_ref;
				sub_domain += "|";
				sub_domain += domain_lit;
				sub_domain += ")";
			sub_domain += X;

			// a domain is a list of subdomains separated by dots
			string domain = "(?'domain'";
				domain += sub_domain;
				domain += "(:?";
				domain += EmailAddress.Period + " " + X + " " + sub_domain;
				domain += ")*)";

			// a a route. A bunch of "@ domain" separated by commas, followed by a colon.
			string route = "";
				route += "\\@ " + X + " " + domain;
				route += "(?: , " + X + " \\@ " + X + " " + domain + ")*";
				route += ":";
				route += X;
				
			// a local-part is a bunch of 'word' separated by periods
			string local_part = "(?'localpart'";
				local_part += word + " " + X;
				local_part += "(?:";
				local_part += EmailAddress.Period + " " + X + " " + word + " " + X;
				local_part += ")*)";

			// an addr-spec is local@domain
			string addr_spec = local_part + " \\@ " + X + " " + domain;
            
			// a route-addr is <route? addr-spec>
			string route_addr = "";
				route_addr += "< " + X;
				route_addr += "(?: " + route + " )?";
				route_addr += addr_spec;
				route_addr += ">";

			// a phrase........
			string phrase_ctrl = @"\000-\010\012-\037";

			// Like atom-char, but without listing space, and uses phrase_ctrl.
			string phrase_char = "[^()<>\\@,;:\\\"." + EmailAddress.Escape + 
				EmailAddress.OpenBr +
				EmailAddress.CloseBr + 
				EmailAddress.NonAscii + 
				phrase_ctrl + "]";
			
			string phrase = "";
				phrase += word;
				phrase += phrase_char;
				phrase += "(?:";
				phrase += "(?: " + comment + " | " + quoted_str + " )";
				phrase += phrase_char + " *";
				phrase += ")*";
			
			// A mailbox is an addr_spec or a phrase/route_addr
			string mailbox = "";
				mailbox += X;
				mailbox += "(?'mailbox'";
				mailbox += addr_spec;
				mailbox += "|";
				mailbox += phrase + " " + route_addr;
				mailbox += ")";
			
			EmailAddress.oRegex = new Regex(mailbox,RegexOptions.Compiled | RegexOptions.IgnorePatternWhitespace);
		}

	}
}