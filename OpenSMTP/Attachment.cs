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
	using Microsoft.Win32;
	using System.Text;

	/// <summary>
	/// This Type stores a file attachment. There can be many attachments in each MailMessage
	/// <seealso cref="MailMessage"/>
	/// </summary>
	/// <example>
	/// <code>
	/// MailMessage msg = new MailMessage();
	/// Attachment a = new Attachment("C:\\file.jpg");
	/// msg.AddAttachment(a);
	/// </code>
	/// </example>
	public class Attachment: IComparable
	{

		internal string 	name;
		internal string 	mimeType;
		internal string 	encoding = "base64";
		internal string 	filePath;
		internal int		size = 0;
		internal string 	encodedFilePath;
		// start added by mb
		internal string		contentid=null;
		// end added by mb

		/// <summary>Constructor using a file path</summary>
		/// <example>
		/// <code>Attachment a = new Attachment("C:\\file.jpg");</code>
		/// </example>
		public Attachment(string filePath)
		{
			this.filePath = filePath;

			if (filePath.Length > 0)
			{
				try
				{
					FileInfo fileInfo = new FileInfo(filePath);		
					if (fileInfo.Exists)
					{
						this.mimeType = getMimeType(fileInfo.Extension);
						this.name = fileInfo.Name;
						this.size = (int)fileInfo.Length;

						string encodedTempFile = Path.GetTempFileName();
						MailEncoder.ConvertToBase64(filePath, encodedTempFile);
						this.encodedFilePath = encodedTempFile;
					}
				}
				catch(ArgumentNullException)
				{
					throw new SmtpException("Attachment file does not exist or path is incorrect.");
				}
			}	
		}

		/// <summary>Constructor using a provided Stream</summary>
		/// <example>
		/// <code>Attachment a = new Attachment(new FileStrema(@"C:\file.jpg", FileMode.Open, FileAccess.Read), "file.jpg");</code>
		/// </example>
		public Attachment(Stream stream, string fileName)
		{
			try
			{
				this.mimeType = "unknown/application";
				this.name = fileName;
				this.size = (int)stream.Length;

				string encodedTempFile = Path.GetTempFileName();
				MailEncoder.ConvertToBase64(stream, encodedTempFile);
				this.encodedFilePath = encodedTempFile;
			}
			catch(ArgumentNullException)
			{
				throw new SmtpException("Attachment file does not exist or path is incorrect.");
			}
		}

	
		~Attachment()
		{
			// delete temp file used for temp encoding of large files
			try
			{
				if (this.encodedFilePath != null)
				{
					FileInfo fileInfo = new FileInfo(this.encodedFilePath);
					if (fileInfo.Exists) { fileInfo.Delete(); }
				}
			}
			catch(ArgumentNullException)
			{ }
		}

		/// <value> Stores the Attachment Name</value>
		public string Name
		{
			get { return(this.name); }
			set { this.name = value; }
		}

		public string ContentId
		{
			get { return(this.contentid); }
			set { this.contentid = value; }
		}


		/// <value> Stores the MIME content-type of the attachment</value>
		public string MimeType
		{
			get { return(this.mimeType); }
			set { this.mimeType = value; }
		}

		/// <value> Returns the MIME content-encoding type of the attachment</value>
		public string Encoding
		{
			get { return(this.encoding); }
		}
		
		/// <value> Returns the path of an attached file</value>
		public string FilePath
		{
			get { return(this.filePath); }
		}

		/// <value> Returns the attachment size in bytes</value>
		public int Size
		{
			get { return(this.size); }
		}
		
		/// <value>When the file is encoded it is stored in temp directory until sendMail() method is called.
		/// This property retrieves the path to that temp file.</value>
		internal string EncodedFilePath
		{
			get { return(this.encodedFilePath) ; }
		}
		
		/// <summary>Returns the MIME content-type for the supplied file extension</summary>
		/// <returns>String MIME type (Example: \"text/plain\")</returns>
		private string getMimeType(string fileExtension)
		{
			try
			{
				RegistryKey extKey = Registry.ClassesRoot.OpenSubKey(fileExtension);
				string contentType = (string)extKey.GetValue("Content Type");

				if (contentType.ToString() != null)
				{	
					return contentType.ToString(); 
				}
				else
				{ return "application/octet-stream"; }
			}
			catch(System.Exception)
			{ return "application/octet-stream"; }
		}
		
		public int CompareTo(object attachment)        
		{ 
			// Order instances based on the Date         
			return (this.Name.CompareTo(((Attachment)(attachment)).Name));        
		}	

		/// <summary>returns the file name from a parsed file path</summary>
		/// <param name="filePath">UNC file path to file (IE: "C:\file.txt")</param>
		/// <returns>string file name (Example: \"test.zip\")</returns>
		private string getFileName(string filePath)
		{
			return filePath.Substring(filePath.LastIndexOf("\\")+1);
		}

		/// <summary>
		/// Encode the file for inclusion as a mime attachment.
		/// The boundaries are not provided.
		/// </summary>
		/// <returns></returns>
		
		public String ToMime() 
		{
			StringBuilder sb=new StringBuilder();
			if (ContentId!=null) 
			{
				sb.Append("Content-ID: <" + ContentId + ">\r\n");
			}
			sb.Append("Content-Type: " + mimeType + ";\r\n");
			sb.Append(" name=\"" + name + "\"\r\n");
			sb.Append("Content-Transfer-Encoding: " + encoding + "\r\n");
			sb.Append("Content-Disposition: attachment;\r\n");
			sb.Append(" filename=\"" + name + "\"\r\n\r\n");
					
			FileStream fin = new FileStream(encodedFilePath, FileMode.Open, FileAccess.Read);

			byte[] bin;

			while (fin.Position != fin.Length)
			{
				bin = new byte[76];
				int len = fin.Read(bin, 0, 76);
				sb.Append(System.Text.Encoding.UTF8.GetString(bin , 0, len)+"\r\n");
			}

			fin.Close();
			return sb.ToString();
		}

	}
}
