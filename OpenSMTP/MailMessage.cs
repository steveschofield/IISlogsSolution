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
using System.Collections;
using System.Collections.Specialized;
using System.IO;
using System.Text;

	/// <summary>
	/// This Type stores the addresses, attachments, body, subject,
	/// and properties of the email message. There can be many
	/// attachments and email addresses in each MailMessage.
	/// <seealso cref="EmailAddress"/>
	/// <seealso cref="Attachment"/>
	/// </summary>
	/// <remarks>
	/// This Type stores the addresses, attachments, body, subject,
	/// and properties of the email message. There can be many
	/// attachments and email addresses in each MailMessage.
	/// <seealso cref="EmailAddress"/>
	/// <seealso cref="Attachment"/>
	/// </remarks>
	/// <example>
	/// <code>
	///		from 			= new EmailAddress("support@OpenSmtp.com", "Support");
	///		to				= new EmailAddress("recipient@OpenSmtp.com", "Joe Smith");
	///		cc				= new EmailAddress("cc@OpenSmtp.com", "CC Name");
	///
	///		msg 			= new MailMessage(from, to);
	///		msg.AddRecipient(cc, AddressType.Cc);
	///		msg.AddRecipient("bcc@OpenSmtp.com", AddressType.Bcc);
	///
	///		msg.Subject 	= "Testing OpenSmtp .Net SMTP component";
	///		msg.Body 		= "Hello Joe Smith.";
	///		msg.HtmlBody 	= "<html><body>Hello Joe Smith.</body></html>";
	///
	///		// mail message properties
	///		msg.Charset		= "ISO-8859-1";
	///		msg.Priority 	= MailPriority.High;
	///		msg.Notification = true;
	///
	///		// add custom headers
	///		msg.AddCustomHeader("X-CustomHeader", "Value");
	///		msg.AddCustomHeader("X-CompanyName", "Value");
	///
	///		// add attachments
	///		msg.AddAttachment(@"..\attachments\test.jpg");
	///		msg.AddAttachment(@"..\attachments\test.htm");
	/// </code>
	/// </example>
	public class MailMessage
	{
		internal EmailAddress			from;
		internal EmailAddress			replyTo;
		internal ArrayList				recipientList;
		internal ArrayList				ccList;
		internal ArrayList				bccList;
		internal ArrayList				attachments;
		internal string					subject;
		internal string					body;
		internal string					htmlBody;
		internal string					mixedBoundary;
		internal string					altBoundary;
		internal string					relatedBoundary;
		internal string					charset = "ISO-8859-1";
		internal bool					notification;
		internal string					priority;
		internal ArrayList				customHeaders;
		internal ArrayList				images;

		public MailMessage()
		{
			recipientList = new ArrayList();
			ccList = new ArrayList();
			bccList = new ArrayList();
			attachments = new ArrayList();
			images = new ArrayList();
			customHeaders = new ArrayList();
			mixedBoundary = MailMessage.generateMixedMimeBoundary();
            altBoundary = MailMessage.generateAltMimeBoundary();
			relatedBoundary = MailMessage.generateRelatedMimeBoundary();
         }

		/// <summary>Constructor using EmailAddress type</summary>
		/// <example>
		/// <code>
		/// 	EmailAddress from 	= new EmailAddress("support@OpenSmtp.com", "Support");
		/// 	EmailAddress to 	= new EmailAddress("recipient@OpenSmtp.com", "Joe Smith");
		/// 	MailMessage msg 	= new MailMessage(from, to);
		/// </code>
		/// </example>
		public MailMessage(EmailAddress sender, EmailAddress recipient):this()
		{
			from = sender;
			recipientList.Add(recipient);
		}

		/// <summary>Constructor using string email addresses</summary>
		/// <example>
		/// <code>
		/// 	MailMessage msg = new MailMessage("support@OpenSmtp.com", "recipient@OpenSmtp.com");
		/// </code>
		/// </example>
		public MailMessage(string senderAddress, string recipientAddress):this(new EmailAddress(senderAddress), new EmailAddress(recipientAddress))
		{}


		// -------------------------- Properties --------------------------

		/// <value>Stores the EmailAddress to Reply-To.
		/// If no EmailAddress is specified the From address is used.</value>
		public EmailAddress ReplyTo
		{
			get { return replyTo != null ? replyTo : from; }
			set { replyTo = value; }
		}

		/// <value>Stores the EmailAddress of the sender</value>
		public EmailAddress From
		{
			get { return from; }
			set { from = value; }
		}

		/// <value>Stores the EmailAddress of the recipient</value>
		public ArrayList To
		{
			get { return recipientList; }
			set { recipientList = value; }
		}

		/// <value>Stores the subject of the MailMessage</value>
		public string Subject
		{
			get { return subject; }
			set { subject = value; }
		}

		/// <value>Stores the text body of the MailMessage</value>
		public string Body
		{
			get { return body; }
			set { body = value; }
		}

		/// <value>Stores the HTML body of the MailMessage</value>
		public string HtmlBody
		{
			get { return htmlBody; }
			set { htmlBody = value; }
		}

		/// <value>Stores Mail Priority value</value>
		/// <seealso>MailPriority</seealso>
		public string Priority
		{
			get { return priority; }
			set { priority = value; }
		}


		/// <value>Stores the Read Confirmation Reciept</value>
		public bool Notification
		{
			get { return notification; }
			set { notification = value; }
		}

		/// <value>Stores an ArrayList of CC EmailAddresses</value>
		public ArrayList CC
		{
			get { return ccList; }
			set { ccList = value; }
		}

		/// <value>Stores an ArrayList of BCC EmailAddresses</value>
		public ArrayList BCC
		{
			get { return bccList; }
			set { bccList = value; }
		}

		/// <value>Stores the character set of the MailMessage</value>
		public string Charset
		{
			get { return charset; }
			set { charset = value; }
		}

		/// <value>Stores a list of Attachments</value>
		public ArrayList Attachments
		{
			get { return attachments; }
			set { attachments = value; }
		}

		/// <value>Stores a NameValueCollection of custom headers</value>
		public ArrayList CustomHeaders
		{
			get { return customHeaders; }
			set { customHeaders = value; }
		}

		/// <value>Stores the string boundary used between MIME parts</value>
		internal string AltBoundary
		{
			get { return altBoundary; }
			set { altBoundary = value; }
		}

         /// <value>Stores the string boundary used between MIME parts</value>
         internal string MixedBoundary
         {
             get { return mixedBoundary; }
             set { mixedBoundary = value; }
         }

         /// <summary>Adds a recipient EmailAddress to the MailMessage</summary>
		/// <param name="address">EmailAddress that you want to add to the MailMessage</param>
		/// <param name="type">AddressType of the address</param>
		/// <example>
		/// <code>
		/// 	MailMessage msg = new MailMessage("support@OpenSmtp.com", "recipient@OpenSmtp.com");
		///		EmailAddress cc = new EmailAddress("cc@OpenSmtp.com");
		///		msg.AddRecipient(cc, AddressType.Cc);
		/// </code>
		/// </example>
		public void AddRecipient(EmailAddress address, AddressType type)
		{
			try
			{
				switch(type)
				{
					case AddressType.To:
						recipientList.Add(address);
						break;
					case AddressType.Cc:
						ccList.Add(address);
						break;
					case AddressType.Bcc:
						bccList.Add(address);
						break;
				}
			}
			catch(Exception e)
			{
				throw new SmtpException("Exception in AddRecipient: " + e.ToString());
			}
		}

		/// <summary>Adds a recipient RFC 822 formatted email address to the MailMessage</summary>
		/// <param name="address">RFC 822 formatted email address that you want to add to the MailMessage</param>
		/// <param name="type">AddressType of the email address</param>
		/// <example>
		/// <code>
		/// 	MailMessage msg = new MailMessage("support@OpenSmtp.com", "recipient@OpenSmtp.com");
		///		msg.AddRecipient("cc@OpenSmtp.com", AddressType.Cc);
		/// </code>
		/// </example>
		public void AddRecipient(string address, AddressType type)
		{
			EmailAddress email = new EmailAddress(address);
			AddRecipient(email, type);
		}


		/// <summary>Adds an Attachment to the MailMessage using a file path</summary>
		/// <param name="filepath">File path to the file you want to attach to the MailMessage</param>
		/// <example>
		/// <code>
		/// 	MailMessage msg = new MailMessage("support@OpenSmtp.com", "recipient@OpenSmtp.com");
		///		msg.AddAttachment(@"C:\file.jpg");
		/// </code>
		/// </example>
		// start added/modified by mb
		public void AddAttachment(string filepath)
		{
			AddAttachment(filepath, NewCid());
		}

		/// <summary>Adds an included image to the MailMessage using a file path</summary>
		/// <param name="filepath">File path to the file you want to attach to the MailMessage</param>
		/// <example>
		/// <code>
		/// 	MailMessage msg = new MailMessage("support@OpenSmtp.com", "recipient@OpenSmtp.com");
		///		msg.AddImage(@"C:\file.jpg");
		/// </code>
		/// </example>
		// start added/modified by mb
		public void AddImage(string filepath)
		{
			AddImage(filepath, NewCid());
		}

		public void AddImage(string filepath, string cid) 
		{
			if (filepath != null)
			{
				Attachment image = new Attachment(filepath);
				image.contentid=cid;
				images.Add(image);
			}			
		}
	
	
		/// <summary>
		/// Generate a content id
		/// </summary>
		/// <returns></returns>
		private string NewCid() 
		{
			int attachmentid=attachments.Count+images.Count+1;
			return "att"+attachmentid;
		}

		public void AddAttachment(string filepath, string cid) 
		{
			if (filepath != null)
			{
				Attachment attachment = new Attachment(filepath);
				attachment.contentid=cid;
				attachments.Add(attachment);
			}			
		}
		// end added by mb

		/// <summary>Adds an Attachment to the MailMessage using an Attachment instance</summary>
		/// <param name="attachment">Attachment you want to attach to the MailMessage</param>
		/// <example>
		/// <code>
		/// 	MailMessage msg = new MailMessage("support@OpenSmtp.com", "recipient@OpenSmtp.com");
		///		Attachment att = new Attachment(@"C:\file.jpg");
		///		msg.AddAttachment(att);
		/// </code>
		/// </example>
		public void AddAttachment(Attachment attachment)
		{
			if (attachment != null)
			{
                 attachments.Add(attachment);
             }
		}

		/// <summary>Adds an Attachment to the MailMessage using a provided Stream</summary>
		/// <param name="stream">stream you want to attach to the MailMessage</param>
		/// <example>
		/// <code>
		/// 	MailMessage msg = new MailMessage("support@OpenSmtp.com", "recipient@OpenSmtp.com");
		///		Attachment att = new Attachment(new FileStream(@"C:\File.jpg", FileMode.Open, FileAccess.Read), "Test Name");
		///		msg.AddAttachment(att);
		/// </code>
		/// </example>
		public void AddAttachment(Stream stream)
		{
			if (stream != null)
			{
                 attachments.Add(stream);
             }
		}


		/// <summary>
		/// Adds an custom header to the MailMessage.
		///	NOTE: some SMTP servers will reject improper custom headers
		///</summary>
		/// <param name="name">Name of the custom header</param>
		/// <param name="body">Value of the custom header</param>
		/// <example>
		/// <code>
		/// 	MailMessage msg = new MailMessage("support@OpenSmtp.com", "recipient@OpenSmtp.com");
		///		msg.AddCustomHeader("X-Something", "HeaderValue");
		/// </code>
		/// </example>
		public void AddCustomHeader(string name, string body)
		{
			if (name != null && body != null)
			{
                 AddCustomHeader(new MailHeader(name, body));
             }
		}

		/// <summary>
		/// Adds an custom header to the MailMessage.
		///	NOTE: some SMTP servers will reject improper custom headers
		///</summary>
		/// <param name="mailheader">MailHeader instance</param>
		/// <example>
		/// <code>
		/// 	MailMessage msg = new MailMessage("support@OpenSmtp.com", "recipient@OpenSmtp.com");
		///		MailHeader header = new MailHeader("X-Something", "HeaderValue");		
		///		msg.AddCustomHeader(header);
		/// </code>
		/// </example>
		public void AddCustomHeader(MailHeader mailheader)
		{
			if (mailheader.name != null && mailheader.body != null)
			{
                 customHeaders.Add(mailheader);
             }
		}

		/// <summary>Populates the Body property of the MailMessage from a text file</summary>
		/// <param name="filePath">Path to the file containing the MailMessage body</param>
		/// <example>
		/// <code>
		/// 	MailMessage msg = new MailMessage("support@OpenSmtp.com", "recipient@OpenSmtp.com");
		///		msg.GetBodyFromFile(@"C:\body.txt");
		/// </code>
		/// </example>
		public void GetBodyFromFile(string filePath)
		{
			this.body = GetFileAsString(filePath);
		}

		/// <summary>Populates the HtmlBody property of the MailMessage from a HTML file</summary>
		/// <param name="filePath">Path to the file containing the MailMessage html body</param>
		/// <example>
		/// <code>
		/// 	MailMessage msg = new MailMessage("support@OpenSmtp.com", "recipient@OpenSmtp.com");
		///		msg.GetHtmlBodyFromFile(@"C:\htmlbody.html");
		/// </code>
		/// </example>
		public void GetHtmlBodyFromFile(string filePath)
		{
			// add extension
			this.htmlBody = GetFileAsString(filePath);
		}

		/// <summary>Resets all of the MailMessage properties</summary>
		/// <example>
		/// <code>
		/// 	MailMessage msg = new MailMessage("support@OpenSmtp.com", "recipient@OpenSmtp.com");
		///		msg.Reset();
		/// </code>
		/// </example>
		public void Reset()
		{
			from = null;
			replyTo = null;
			recipientList.Clear();
			ccList.Clear();
			bccList.Clear();
			customHeaders.Clear();
			attachments.Clear();
			subject = null;
			body = null;
			htmlBody = null;
			priority = null;
			mixedBoundary = null;
             altBoundary = null;
             charset = null;
			notification = false;
		}

		/// <summary>Saves the MailMessage as a RFC 822 formatted message</summary>
		/// <param name="filePath">Specifies the file path to save the message</param>
		/// <example>
		/// <code>
		/// 	MailMessage msg = new MailMessage("support@OpenSmtp.com", recipient@OpenSmtp.com");
		///		msg.Body = "body";
		///		msg.Subject = "subject";
		///		msg.Save(@"C:\email.txt");
		/// </code>
		/// </example>
		public void Save(string filePath)
		{
			StreamWriter sw = File.CreateText(filePath);
			sw.Write(this.ToString());
			sw.Close();
		}

		/// <summary>Returns the MailMessage as a RFC 822 formatted message</summary>
		/// <example>
		/// <code>
		/// 	MailMessage msg = new MailMessage("support@OpenSmtp.com", "recipient@OpenSmtp.com");
		///		msg.Body = "body";
		///		msg.Subject = "subject";
		///		string message = msg.ToString();
		/// </code>
		/// </example>
		/// <returns>Mailmessage as RFC 822 formatted string</returns>
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();

			if (ReplyTo.name != null && ReplyTo.name.Length != 0)
             {
                 sb.Append("Reply-To: " + MailEncoder.ConvertHeaderToQP(ReplyTo.name, charset) + " <" + ReplyTo.address + ">\r\n");
             }
			else
			{
                 sb.Append("Reply-To: <" + ReplyTo.address + ">\r\n");
             }

			if (from.name != null && from.name.Length != 0)
             {
                 sb.Append("From: " + MailEncoder.ConvertHeaderToQP(from.name, charset) + " <" + from.address + ">\r\n");
	         }
			else
			{
                 sb.Append("From: <" + from.address + ">\r\n");
             }

			sb.Append("To: " + CreateAddressList(recipientList) + "\r\n");

			if (ccList.Count != 0)
			{
                 sb.Append("CC: " + CreateAddressList(ccList) + "\r\n");
             }

			if (subject != null && subject.Length > 0)
             {
                 sb.Append("Subject: " + MailEncoder.ConvertHeaderToQP(subject, charset) + "\r\n");
             }

			sb.Append("Date: " + DateTime.Now.ToUniversalTime().ToString("R") + "\r\n");
			sb.Append(SmtpConfig.X_MAILER_HEADER + "\r\n");

			if (notification)
			{
				if (ReplyTo.name != null && ReplyTo.name.Length != 0)
                 {
                     sb.Append("Disposition-Notification-To: " + MailEncoder.ConvertHeaderToQP(ReplyTo.name, charset) + " <" + ReplyTo.address + ">\r\n");
                 }
				else
				{
                     sb.Append("Disposition-Notification-To: <" + ReplyTo.address + ">\r\n");
                 }
			}

			if (priority != null)
			{
                 sb.Append("X-Priority: " + priority + "\r\n");
             }

			if (customHeaders != null)
			{

				for (IEnumerator i = customHeaders.GetEnumerator(); i.MoveNext();)
				{
					MailHeader m = (MailHeader)i.Current;

					if (m.name.Length >= 0 && m.body.Length >= 0)
					{
						sb.Append(m.name + ":" + MailEncoder.ConvertHeaderToQP(m.body, charset) + "\r\n");
					}
					else
					{
						// TODO: Check if below is within RFC spec.
						sb.Append(m.name + ":\r\n");
					}

				}

				/*
				for (int i=0; i < customHeaders.Count; i++)
				{
					sb.Append(customHeaders.Keys[i]);
                     sb.Append(": ");
                     sb.Append(MailEncoder.ConvertHeaderToQP(customHeaders[customHeaders.Keys[i]], charset));
                     sb.Append("\r\n");
				}
				*/
			}

             sb.Append("MIME-Version: 1.0\r\n");
             sb.Append(GetMessageBody());

			return sb.ToString();
		}

		/// <summary>Returns a clone of this message</summary>
		/// <example>
		/// <code>
		/// 	MailMessage msg = new MailMessage("support@OpenSmtp.com", "recipient@OpenSmtp.com");
		///		msg.Body = "body";
		///		msg.Subject = "subject";
		///
		///		msg2 = msg.Copy();
		/// </code>
		/// </example>
		/// <returns>Mailmessage</returns>
		public MailMessage Copy()
		{
			return (MailMessage)this.MemberwiseClone();
		}

		/// Internal/Private methods below
		// ------------------------------------------------------

		private string GetFileAsString(string filePath)
		{
			FileStream 	fin 	= new FileStream(filePath, FileMode.Open, FileAccess.Read);
			byte[] 		bin		= new byte[fin.Length];
			long 		rdlen	= 0;
			int len;

			StringBuilder sb = new StringBuilder();

			while(rdlen < fin.Length)
			{
				len = fin.Read(bin, 0, (int)fin.Length);
				sb.Append(Encoding.UTF7.GetString(bin, 0, len));
				rdlen = (rdlen + len);
			}

			fin.Close();
			return sb.ToString();
		}


		/// <summary>
		/// Determines the format of the message and adds the
		/// appropriate mime containers.
		/// 
		/// This will return the html and/or text and/or 
		/// embedded images and/or attachments.
		/// </summary>
		/// <returns></returns>
		private String GetMessageBody() 
		{
			StringBuilder sb=new StringBuilder();

			if (attachments.Count>0) 
			{
				sb.Append("Content-Type: multipart/mixed;");
				sb.Append("boundary=\"" + mixedBoundary + "\"");
				sb.Append("\r\n\r\nThis is a multi-part message in MIME format.");
				sb.Append("\r\n\r\n--" + mixedBoundary + "\r\n");
			}

			sb.Append(GetInnerMessageBody());

			if (attachments.Count>0) 
			{
				foreach (Attachment attachment in attachments) 
				{
					sb.Append("\r\n\r\n--" + mixedBoundary + "\r\n");
					sb.Append(attachment.ToMime());
				}
				sb.Append("\r\n\r\n--" + mixedBoundary + "--\r\n");
			}
			return sb.ToString();

		}

		/// <summary>
		/// Get the html and/or text and/or images.
		/// </summary>
		/// <returns></returns>

		private string GetInnerMessageBody()
		{
			StringBuilder sb=new StringBuilder();
			if (images.Count > 0)
			{
				sb.Append("Content-Type: multipart/related;");
				sb.Append("boundary=\"" + relatedBoundary + "\"");
				sb.Append("\r\n\r\n--" + relatedBoundary + "\r\n");
			}

			sb.Append(GetReadableMessageBody());

			if (images.Count > 0)
			{
				foreach (Attachment image in images) 
				{
					sb.Append("\r\n\r\n--" + relatedBoundary + "\r\n");
					sb.Append(image.ToMime());
				}
				sb.Append("\r\n\r\n--" + relatedBoundary + "--\r\n");
			}
			return sb.ToString();
		}

		private String GetReadableMessageBody() {

			StringBuilder sb=new StringBuilder();

			if (htmlBody == null)
			{
				sb.Append(GetTextMessageBody(body, "text/plain"));
			}
			else if (body == null)
			{
				sb.Append(GetTextMessageBody(htmlBody, "text/html"));
			}
			else
			{
				sb.Append(GetAltMessageBody(
					GetTextMessageBody(body, "text/plain"),
					GetTextMessageBody(htmlBody, "text/html")));
			}

			return sb.ToString();

		}


         private string GetTextMessageBody(string messageBody, string textType)
         {
             StringBuilder sb = new StringBuilder();

             sb.Append("Content-Type: " + textType + ";\r\n");
             sb.Append(" charset=\""+ charset + "\"\r\n");
             sb.Append("Content-Transfer-Encoding: quoted-printable\r\n\r\n");
             sb.Append(MailEncoder.ConvertToQP(messageBody, charset));

             return sb.ToString();
         }

         private string GetAltMessageBody(string messageBody1, string messageBody2)
         {
             StringBuilder sb = new StringBuilder();

             sb.Append("Content-Type: multipart/alternative;");
             sb.Append("boundary=\"" + altBoundary + "\"");

             sb.Append("\r\n\r\nThis is a multi-part message in MIME format.");

             sb.Append("\r\n\r\n--" + altBoundary + "\r\n");
             sb.Append(messageBody1);
             sb.Append("\r\n\r\n--" + altBoundary + "\r\n");
             sb.Append(messageBody2);
             sb.Append("\r\n\r\n--" + altBoundary + "--\r\n");

             return sb.ToString();
         }


		// creates comma separated address list from to: and cc:
		private string CreateAddressList(ArrayList msgList)
		{
			StringBuilder sb = new StringBuilder();

			int index = 1;
			int msgCount = msgList.Count;

			for (IEnumerator i = msgList.GetEnumerator(); i.MoveNext(); index++)
			{
				EmailAddress a = (EmailAddress)i.Current;

				// if the personal name exists, add it to the address sent. IE: "Ian Stallings" <istallings@mail.com>
				if (a.name != null && a.name.Length > 0)
				{					
					//sb.Append("=?" + charset + "?Q?" + MailEncoder.ConvertToQP(a.name, charset) + "?= <" + a.address + ">");
					sb.Append(MailEncoder.ConvertHeaderToQP(a.name, charset) + " <" + a.address + ">");
				}
				else
				{
					sb.Append("<" + a.address + ">");
				}

				// if it's not the last address add a semi-colon:
				if (msgCount != index)
				{
					sb.Append(";");
				}
			}

			return sb.ToString();
		}

		private static string generateMixedMimeBoundary()
		{
			// Below generates uniqe boundary for each message. These are used to separate mime parts in a message.
			return "Part." + Convert.ToString(new Random(unchecked((int)DateTime.Now.Ticks)).Next()) + "." + Convert.ToString(new Random(~unchecked((int)DateTime.Now.Ticks)).Next());
		}

         private static string generateAltMimeBoundary()
         {
             // Below generates uniqe boundary for each message. These are used to separate mime parts in a message.
             return "Part." + Convert.ToString(new Random(~unchecked((int)DateTime.Now.AddDays(1).Ticks)).Next()) + "." + Convert.ToString(new Random(unchecked((int)DateTime.Now.AddDays(1).Ticks)).Next());
         }

		private static string generateRelatedMimeBoundary()
		{
			// Below generates uniqe boundary for each message. These are used to separate mime parts in a message.
			return "Part." + Convert.ToString(new Random(~unchecked((int)DateTime.Now.AddDays(2).Ticks)).Next()) + "." + Convert.ToString(new Random(unchecked((int)DateTime.Now.AddDays(1).Ticks)).Next());
		}

     }
}

