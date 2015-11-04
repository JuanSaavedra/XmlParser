using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;

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

  public class OrderParser
  {
    public List<FileInfo> GetOrdersAsFiles()
    {
      const string location = @"C:\GitPlay\Learn\XmlParser\Parser\Orders";
      var dirInfo = new DirectoryInfo(location);

      var files = dirInfo.GetFiles("*xml");

      Console.WriteLine(files.Count() + " files found");

      var orders = files.ToList();
      return orders;
    }

    public List<Order> GetOrders(List<FileInfo> xmlFiles)
    {
      var orders = new List<Order>();

      foreach (var fileInfo in xmlFiles)
      {
        var xmlDoc = XDocument.Load(fileInfo.FullName);
        var order = ParseOrder(xmlDoc);

        orders.Add(order);
      }

      return orders;
    }

    public Order ParseOrder(XDocument xmlDoc)
    {
      // get the source system / datetime / operation
      var sourceSystem = xmlDoc.GetOrderInnerValue("SOURCE_SYSTEM");
      var dateTime = xmlDoc.GetOrderInnerValue("DATETIME");

      // Order header
      var customerNumber = xmlDoc.GetOrderInnerValue("CUSTOMER_NUMBER");
      var customerName = xmlDoc.GetOrderInnerValue("CUSTOMER_NAME");
      var customerContact = xmlDoc.GetOrderInnerValue("CUSTOMER_CONTACT");
      var customerPurchaseOrder = xmlDoc.GetOrderInnerValue("CUSTOMER_PO");

      // Order Lines
      var lines = xmlDoc.Descendants("ORDER_LINE").ToList();

      if (!lines.Any())
      {
        throw new ApplicationException("No Order Items found for this Order");
      }

      Console.WriteLine(lines.Count());

      var order = new Order();
      order.SourceSystem = sourceSystem;
      order.CustomerPurchaseOrder = customerPurchaseOrder;
      order.OrderDateTime = ParseDateTime(dateTime);
      order.CustomerName = customerName;
      order.CustomerContact = customerContact;
      order.CustomerNumber = customerNumber;

      foreach (var xElement in lines)
      {
        var item = new OrderItem();

        var productCode01 = xElement.Descendants("ITEM_NUMBER_01").Single().Value;
        var productCode02 = xElement.Descendants("ITEM_NUMBER_02").Single().Value;
        var lineItemQty = xElement.Descendants("ORDERED_QUANTITY").Single().Value;

        Console.WriteLine("{0}_{1} {2}", productCode01, productCode02, lineItemQty);

        order.Items.Add(item);
      }

      return order;
    }

    public DateTime ParseDateTime(string dateString)
    {
      var date1 = DateTime.ParseExact(dateString, "dd-MMM-yyyy HH:mmm:ss", DateTimeFormatInfo.InvariantInfo);
      return date1;
    }
  }
}