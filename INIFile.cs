using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace ReadWriteINI
{
    public class INIFile
    {
       string Path;
       string EXE = Assembly.GetExecutingAssembly ().GetName ().Name;
       [DllImport ("kernel32", CharSet = CharSet.Unicode)]
       static extern long WritePrivateProfileString (string section, string key, string dataValue, string FilePath);

       [DllImport ("kernel32", CharSet = CharSet.Unicode)]
       static extern int GetPrivateProfileString (string section, string key, string Default, StringBuilder RetVal, int Size, string FilePath);
    

    public INIFile(string IniPath = null) 
    {
     Path = new FileInfo (IniPath ?? EXE + ".ini").FullName;
    }
     public string Read (string key, string section) {
     var RetVal = new StringBuilder (255);
     GetPrivateProfileString (section ?? EXE, key, "Unknown", RetVal, 255, Path);
     return RetVal.ToString ();
    }
     public void Write (string key, string dataValue, string section) {
     WritePrivateProfileString (section ?? EXE, key, dataValue, Path);
    }
   
}
}