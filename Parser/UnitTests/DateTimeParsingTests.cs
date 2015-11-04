using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
  [TestClass]
  public class DateTimeParsingTests
  {
    [TestMethod]
    public void TestMethod1()
    {
      const string dateString = "20-OCT-2015 14:01:25";

      var date1 = DateTime.ParseExact(dateString, "dd-MMM-yyyy HH:mmm:ss", DateTimeFormatInfo.InvariantInfo);
      
      var date = DateTime.Parse(dateString, DateTimeFormatInfo.CurrentInfo);


      Console.WriteLine("Culture: {0}", CultureInfo.CurrentCulture.DisplayName);

      CultureInfo culture = new CultureInfo("en-AU");      
      Console.WriteLine(date1.Month + " " + date1.Day);
      Console.WriteLine(date1.ToString("d", culture));
    }
  }
}
