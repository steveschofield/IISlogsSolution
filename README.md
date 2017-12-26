# IISlogsSolution

##MAKE SURE TO TEST IN A NON-PRODUCTION MACHINE BEFORE ATTEMPTING PRODUCTION##

Welcome to IISLogs Visual Studio solution.   

IISLogs was originally written in 2004 to help manage Microsoft IIS log files. There was nothing available to help manage logs at the time. Several revisions later, 
this is the latest code base.  I was able to download Visual Studio 2017 community edition and get the files to compile.  
The main solution is located in the IISLogs.  The design the IISLogs solution creates an DLL and IISLogsEXE And IISLogsSVC solutions consume the DLL

AppConfigReadWriteClass is a helper utility class

IISLogs core solution creates an DLL

IISLogsEXE is a console application meant to run interactively

IISLogsGUI is a Winforms application

IISLogsLicense handles licensing and checks a file before the program executes.  

IISLogsSetupEXE - legacy solution to create setup files

IISLogsSetupSVC - legacy solution to create setup files

IISlogsSVC is a windows service application.  

OpenSMTP is an open source solution I add to handle emails

Xceed - compression files.  License key located in IISLogs DLL

Enjoy,

Steve Schofield
Microsoft ASP/ASP.NET & IIS MVP from 2002 - 2014
http://iislogs.com/help (contains help files and how-to's')

Here is a welcome aboard message included when a purchase was made. 

For IISLogs 2.0 deployments, you might need to create the 'license' folder under the 'logs' directory.  
We recommend you review these articles, they will help get the program setup and configured.

Windows 2012 R2 / IIS 8.5 deployments?
-------------
http://youtu.be/qu_ZioctJKk
 

IISLogs 4.0
-------------
Practical uses of IISLogs - 2 sections
http://www.iislogs.com/help/iislogs40/123goconfigure.htm
 
Phase 2 Configuration - First Time
http://www.iislogs.com/help/iislogs40/123goconfigure2.htm
 
 
IISLogs 2.0
-------------
Practical uses of IISLogs - 2 sections
http://www.iislogs.com/help/iislogs20/123goconfigure.htm
 
Phase 2 Configuration - First Time
http://www.iislogs.com/help/iislogs20/123goconfigure2.htm
 
Any questions on UAC (user account control)
-------------
IISLogs 4.0
http://www.iislogs.com/iislogsuac40/
 
IISLogs 2.0
http://www.iislogs.com/iislogsuac20/

Any questions, please post on github or contact at info@iislogs.com
If you decide to download, run locally and want assistance
Please contact us at info@iislogs.com and we can send a quote

IISLogs team.