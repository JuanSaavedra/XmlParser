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
      var order = parser.ParseOrder();

      Console.WriteLine("Done!");
      Console.ReadLine();
    }
  }
}
