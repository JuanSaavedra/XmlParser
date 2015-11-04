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
      var parser = new OrderParser();
      var files = parser.GetOrdersAsFiles();
      var orders = parser.GetOrders(files);
      
      Console.WriteLine("Done!");
      Console.WriteLine("========================");
      Console.ReadLine();
    }
  }
}
