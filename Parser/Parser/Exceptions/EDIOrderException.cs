using System;

namespace Parser
{
  public abstract class EDIOrderException : Exception
  {
    public string  OrderFileName { get; set; }

    protected EDIOrderException()
    {
      
    }

    protected EDIOrderException(string message) : base(message)
    {
      
    }

    protected EDIOrderException(string message, Exception innerException) : base(message, innerException)
    {
      
    }

    protected EDIOrderException(string message, string orderFileName)
    {
      OrderFileName = orderFileName;
    }
  }
}