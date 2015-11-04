using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Parser
{
  public class OrderParser
  {
    public Order ParseOrder()
    {
      const string location = @"C:\GitPlay\Learn\XmlParser\Parser\Orders";

      var order = new Order();

      var dirInfo = new DirectoryInfo(location);

      var files = dirInfo.GetFiles("*xml");

      Console.WriteLine(files.Count() + " files found");

      foreach (var xmlOrder in files)
      {
        var xmlDoc = XDocument.Load(xmlOrder.FullName);

        Console.WriteLine(xmlDoc);
      }


      return order;
    }
  }
}