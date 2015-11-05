using System;

namespace Parser
{
  public class EDIOrderLinesNotFoundException : EDIOrderException
  {
    public EDIOrderLinesNotFoundException() { }

    public EDIOrderLinesNotFoundException(string message) : base(message)
    {
      
    }

    public EDIOrderLinesNotFoundException(string message, string orderFileName)
      : base(message, orderFileName)
    {

    }

    public EDIOrderLinesNotFoundException(string message, Exception innerException)
      : base(message, innerException) { }
  }
}