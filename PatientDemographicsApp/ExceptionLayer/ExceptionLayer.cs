using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;

namespace PatientDemographicsApp.ExceptionLayer
{
    public class ExceptionLayer : ApplicationException
    {
        public ExceptionLayer() : base()
        {
            LogError.ErrorLog("Unknown error occured\n");
        }
        public ExceptionLayer(string message)
            : base(message)
        {
            LogError.ErrorLog("following error occured\n " + message);
        }
        public ExceptionLayer(string message, Exception innerException)
            : base(message, innerException)
        {
            LogError.ErrorLog("following error occured\n "+ message + " along with innerexception\n" + innerException);
        }
    }
    internal class LogError
    {
        public static void ErrorLog(string message)
        {
            string path = ConfigurationSettings.AppSettings["ErrorPath"].ToString();
            StreamWriter writer = new StreamWriter(path);
            writer.WriteLine(message);
            writer.Flush();
            writer.Close();
        }
    }
}