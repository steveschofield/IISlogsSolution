_CS=csc.exe

# path to Nunit core dll on local machine
_NUNIT_DLL=..\bin\NUnit.framework.dll

# no debugging symbols, optimise, don't display logo
_CSFLAGS=/o+ /nologo /warn:3

_DEBUG=/debug+

# list of files needed to compile
_FILE_LIST=*.cs 

#adds all files in /tests subdirectory to compile
_TEST_FILE_LIST=/recurse:tests\*.cs

# mail directories used in "clean"
_MAIL_DROP_DIR=c:\inetpub\mailroot\drop
_BAD_MAIL_DIR=c:\inetpub\mailroot\badmail
_LOG_DIR=c:\cvs\opensmtp\logs

all: Smtp
release: Smtp
debug: SmtpDebug

Smtp :
  $(_CS) $(_CSFLAGS) /t:library \
  /out:..\bin\OpenSmtp.dll \
  /doc:..\OpenSmtp.xml $(_FILE_LIST) \

SmtpDebug :
  $(_CS) $(_DEBUG) $(_CSFLAGS) /t:library \
  /r:$(_NUNIT_DLL) \
  /out:..\bin\OpenSmtp.dll \
  $(_FILE_LIST)\
  $(_TEST_FILE_LIST)
  
test: SmtpDebug ..\bin\nunit-console.exe ..\bin\OpenSmtp.dll
	cd ..\bin
	NUnit-console /assembly:OpenSmtp.dll

# WARNING: this test will only work with VerifyAddresses set to true in the SmtpConfig class.
addresstest: ..\bin\nunit-console.exe ..\bin\OpenSmtp.dll
	cd ..\bin
	NUnit-console OpenSmtp.Mail.Test.EmailAddressTest,OpenSmtp.dll

clean: 
	cd $(_MAIL_DROP_DIR)
	dir
	del *.*	/s /q
	cd $(_BAD_MAIL_DIR)
	dir
	del *.*	/s /q
	cd $(_LOG_DIR)
	dir
	del SmtpLog.* /s /q
	
	
