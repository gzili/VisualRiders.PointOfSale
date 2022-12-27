namespace VisualRiders.PointOfSale.Project.Exceptions;

public class HttpResponseException : Exception
{
    public int StatusCode { get; set; }
    
    public object? Value { get; set; }

    public HttpResponseException(int statusCode, object? value)
    {
        StatusCode = statusCode;
        Value = value;
    }
}