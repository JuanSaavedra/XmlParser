using System;
using System.Linq;
using System.Xml.Linq;

namespace Parser
{
  public static class Utils
  {
    public static string GetOrderInnerValue(this XDocument doc, string path)
    {
      try
      {
        return doc.Descendants(path).Single().Value;
      }
      catch (Exception e)
      {
        throw new ApplicationException("Cannot parse order doc " + path);
      }
    }
  }
}