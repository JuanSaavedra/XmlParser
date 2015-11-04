using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Parser
{
  public class XMLOrderParser
  {
    public List<Order> ParseOrders(List<XmlOrderFile> rawOrderFileContent)
    {
      var orders = new List<Order>();

      foreach (var rawOrderFile in rawOrderFileContent)
      {
        try
        {
          var order = ParseOrder(rawOrderFile);
          orders.Add(order);

          Console.WriteLine("Order processed..");
          Console.WriteLine("------------------");
        }
        catch (EDIOrderException ediOrderException)
        {
          Console.WriteLine("Order with filename '{0}' could not be processed", ediOrderException.OrderFileName);
        }
      }

      return orders;
    }

    public Order ParseOrder(XmlOrderFile orderFile)
    {
      var xmlDoc = XDocument.Parse(orderFile.ContentAsString);

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
        throw new EDIOrderLinesNotFoundException("Order Lines not found", orderFile.FileName);
      }

      Console.WriteLine("Order lines found: " + lines.Count());

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

    /// <summary>
    /// 
    /// </summary>
    /// <param name="dateString"></param>
    /// <returns></returns>
    public DateTime ParseDateTime(string dateString)
    {
      var date1 = DateTime.ParseExact(dateString, "dd-MMM-yyyy HH:mmm:ss", DateTimeFormatInfo.InvariantInfo);
      return date1;
    }
  }
}