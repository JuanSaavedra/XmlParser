using System.Collections.Generic;

namespace Parser.XMLParser
{
  public class XMLOrderParserResponse
  {
    public List<Order> Orders { get; set; }

    public List<string> OrderFileNamesWithProblems { get; set; } 
    
    public XMLOrderParserResponse()
    {
      Orders = new List<Order>();
      OrderFileNamesWithProblems = new List<string>();
    }
  }
}