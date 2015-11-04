using System.Collections.Generic;

namespace Parser
{
  public class Order
  {
    public List<OrderItem> Items { get; set; }

    public Order()
    {
      Items = new List<OrderItem>();
    }
  }
}