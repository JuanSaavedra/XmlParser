using System;
using System.Collections.Generic;

namespace Parser
{
  public class Order
  {
    public string SourceSystem { get; set; }

    public DateTime OrderDateTime { get; set; }

    public List<OrderItem> Items { get; set; }

    public string CustomerPurchaseOrder { get; set; }

    public string CustomerNumber { get; set; }

    public string CustomerName { get; set; }

    public string CustomerContact { get; set; }

    public Order()
    {
      Items = new List<OrderItem>();
    }
  }
}