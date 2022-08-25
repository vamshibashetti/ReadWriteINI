using System.ComponentModel;
using System;

namespace ReadWriteINI
{
    class Program
    {
        static void Main(string[] args)
        {
        INIFile settingsIni = new INIFile(@".\\TestData.ini");
 
        string executionMode = settingsIni.Read ("BrowserName", "BrowserInfo").ToLower ();
        
        Console.WriteLine (executionMode);
 
         string WebdriverToUse = settingsIni.Read ("WebDriverLocation", "BrowserInfo").ToLower ();
        Console.WriteLine (WebdriverToUse);

        settingsIni.Write("TimeOut","4000","BrowserInfo");

         string WebdriverTimeout= settingsIni.Read ("TimeOut", "BrowserInfo");
        Console.WriteLine (WebdriverTimeout);

        settingsIni.Write("BrowserName","IE","BrowserInfo");

        settingsIni.Write("Url","https://www.google.com","AppUnderTest");

        }
        
    }
}
