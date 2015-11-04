using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Parser
{
  public class XmlOrderFile
  {
    public long SizeBytes { get; set; } 

    public string FileName { get; set; }

    public string ContentAsString { get; set; }

    public string FileFullName { get; set; }
  }

  public class XmlOrderFileCollector
  {
    public string PathToOrderLandingZone { get; set; }

    public string FileNamePattern { get; set; }

    public XmlOrderFileCollector(string location, string pattern)
    {
      PathToOrderLandingZone = location;
      FileNamePattern = pattern;
    }

    public List<XmlOrderFile> GetRawOrderFiles()
    {
      //const string location = @"C:\GitPlay\Learn\XmlParser\Parser\Orders";
      var dirInfo = new DirectoryInfo(PathToOrderLandingZone);

      //var files = dirInfo.GetFiles("*xml");
      var files = dirInfo.GetFiles(FileNamePattern);

      Console.WriteLine("Order files found: " + files.Count());

      var orderFiles = new List<XmlOrderFile>();

      foreach (var file in files)
      {
        var xmlOrderFile = new XmlOrderFile();
        xmlOrderFile.ContentAsString = File.ReadAllText(file.FullName);
        xmlOrderFile.FileFullName = file.FullName;
        xmlOrderFile.FileName = file.Name;
        xmlOrderFile.SizeBytes = file.Length;

        orderFiles.Add(xmlOrderFile);
      }

      return orderFiles;
    }
  }
}