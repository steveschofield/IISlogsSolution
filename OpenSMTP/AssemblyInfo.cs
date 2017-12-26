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
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;


// Mark the framework assembly as CLS compliant
[assembly:CLSCompliant(true)]

//
// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
//
[assembly:AssemblyTitle("OpenSmtp SMTP .Net Component")]
[assembly:AssemblyDescription("Open Source SMTP .Net Component")]
[assembly:AssemblyConfiguration("")]
[assembly:AssemblyCompany("")]
[assembly:AssemblyProduct("")]
[assembly:AssemblyCopyright("Copyright (c) 2004 Ian Stallings")]
[assembly:AssemblyTrademark("")]
[assembly:AssemblyCulture("")]

//
// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Revision
//      Build Number
//
// You can specify all the value or you can default the Revision and Build Numbers 
// by using the '*' as shown below:

[assembly:AssemblyVersion("01.09.7.1")]

//
// In order to sign your assembly you must specify a key to use. Refer to the 
// Microsoft .NET Framework documentation for more information on assembly signing.
//
// Use the attributes below to control which key is used for signing. 
//
// Notes: 
//   (*) If no key is specified - the assembly cannot be signed.
//   (*) KeyName refers to a key that has been installed in the Crypto Service
//       Provider (CSP) on your machine. 
//   (*) If the key file and a key name attributes are both specified, the 
//       following processing occurs:
//       (1) If the KeyName can be found in the CSP - that key is used.
//       (2) If the KeyName does not exist and the KeyFile does exist, the key 
//           in the file is installed into the CSP and used.
//   (*) Delay Signing is an advanced option - see the Microsoft .NET Framework
//       documentation for more information on this.
//
//[assembly: AssemblyDelaySign(false)]
//[assembly: AssemblyKeyFile(@"..\..\..\..\File.key")]
//[assembly: AssemblyKeyName("")]

[assembly: AssemblyDelaySign(false)]
#if STRONG
[assembly: AssemblyKeyFile(@"..\OpenSmtp.Key")]
#endif
[assembly: AssemblyKeyName("")]

[assembly: ComVisibleAttribute(false)]
