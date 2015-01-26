using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Utils
/// </summary>
public class Utils
{
	public Utils()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static string GetTextFilePhysicalDir()
    {
        string textDir = ConfigurationManager.AppSettings["textFilesDir"];
        string physicalDir = HttpContext.Current.Server.MapPath("~");
        return physicalDir + "\\" + textDir;
    }

    public static string GetExclusionFile()
    {
        string textDir = ConfigurationManager.AppSettings["exclusionFilesDir"];
        string fileName = "\\exclusion.txt";
        string physicalDir = HttpContext.Current.Server.MapPath("~");
        return physicalDir + "\\" + textDir + fileName;
    }
}