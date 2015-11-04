using System;
using System.ComponentModel;
using System.Linq;
using System.Text;

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
      
      // parse files into Orders
      var orders = parser.ParseOrders(rawFiles);
      
      
      Console.WriteLine("Done!");
      Console.WriteLine("========================");
      Console.ReadLine();
    }
  }
}
