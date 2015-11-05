using System;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Parser.XMLParser;

namespace Parser
{
  public class Program
  {
    static void Main(string[] args)
    {
      // create collector get all files
      var collector = new XmlOrderFileCollector("","");
      var rawFiles = collector.GetRawOrderFiles();

      // create order parser
      var parser = new XMLOrderParser();

      var request = new XMLOrderParserRequest();
      request.XmlOrderFiles = rawFiles;

      // parse files into Orders
      var xmlOrderParserResponse = parser.ParseOrders(request);
      
      Console.WriteLine("Done!");
      Console.WriteLine("========================");
      Console.ReadLine();
    }
  }
}
