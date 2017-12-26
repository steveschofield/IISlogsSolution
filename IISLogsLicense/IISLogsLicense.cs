using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace IISLogsl
{
    public class IISLogsLicense
    {
        private string licenseFolderPath = "";
        private string licenseFilePath = "";
        private double evalDaysLeft=0;
        private bool isFullVersionLicense=false;

        public string LicenseFolderPath
        {
            get
            {
                return licenseFolderPath;
            }
            set
            {
                licenseFolderPath = value;
            }
        }

        public string LicenseFilePath
        {
            get
            {
                return licenseFilePath;
            }
            set
            {
                licenseFilePath = value;
            }
        }

        public double EvalDaysLeft
        {
            get
            {
                return evalDaysLeft;
            }
        }

        public bool IsFullVersionLicense
        {
            get
            {
                return isFullVersionLicense;
            }
        }

        public void CheckLicenseFile()
        {
            //get
            //{
            if (System.IO.File.Exists(licenseFilePath))
                {
                    CheckLicenseValue();
                }
                else
                {
                   System.IO.Directory.CreateDirectory(licenseFolderPath);
                   CreateEvalLicense();
                }
            //}
        }

        private void CreateEvalLicense()
        {
                FileStream fs;
                fs = System.IO.File.Create(licenseFilePath);
                fs.Close();
                System.Threading.Thread.Sleep(100);

                // create a writer and open the file
                TextWriter tw = new StreamWriter(licenseFilePath);

                // write a line of text to the file
                string val1 = EncryptTripleDES("evaluationversionofiislogs");
                tw.WriteLine(val1);

                // close the stream
                tw.Close();

                isFullVersionLicense = false;
        }

        private void CheckLicenseValue()
        {
            StreamReader sr = new StreamReader(licenseFilePath);
            string line = DecryptTripleDES(sr.ReadLine());

            if (line.ToLower() == "fullversionofiislogs")
            {
                isFullVersionLicense = true;
                //return true;
            }
            else if(line.ToLower() == "evaluationversionofiislogs")
            {
                //Check time on the file
                double result=0;
                result = CheckEvalTime(licenseFilePath);
                
                isFullVersionLicense = false;
                evalDaysLeft = System.Math.Round(result,0);
            }            
            else
            {
                isFullVersionLicense = false;
            }
        }

        private double CheckEvalTime(string licenseFile)
        {
            System.IO.FileInfo fi = new System.IO.FileInfo(licenseFile);
            DateTime dtNow = DateTime.Now;
            TimeSpan ts = dtNow - fi.LastWriteTimeUtc;
            
            return ts.TotalDays;
        }

        private static byte[] KEY_192 = { 40, 50, 60, 89, 92, 6, 217, 30, 15, 16, 44, 60, 65, 25, 14, 12, 2, 14, 10, 20, 19, 9, 14, 17 };
        private static byte[] IV_192 = { 5, 13, 52, 4, 8, 1, 17, 3, 42, 5, 82, 83, 16, 7, 29, 13, 11, 3, 22, 8, 16, 10, 11, 25 };

        private string DecryptTripleDES(string value)
        {

            TripleDESCryptoServiceProvider cryptoProvider = new TripleDESCryptoServiceProvider();
            Byte[] buffer = Convert.FromBase64String(value);
            MemoryStream ms = new MemoryStream(buffer);
            CryptoStream cs = new CryptoStream(ms, cryptoProvider.CreateDecryptor(KEY_192, IV_192), CryptoStreamMode.Read);
            StreamReader sr = new StreamReader(cs);
            return sr.ReadToEnd().ToLower();
        }

        private string EncryptTripleDES(string value)
        {
            TripleDESCryptoServiceProvider cryptoProvider = new TripleDESCryptoServiceProvider();
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, cryptoProvider.CreateEncryptor(KEY_192, IV_192), CryptoStreamMode.Write);
            StreamWriter sw = new StreamWriter(cs);
            sw.Write(value);
            sw.Flush();
            cs.FlushFinalBlock();
            ms.Flush();
            return Convert.ToBase64String(ms.GetBuffer(), 0, (int)ms.Length);
        }
    }
}