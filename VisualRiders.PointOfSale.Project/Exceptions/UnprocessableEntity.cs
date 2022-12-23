namespace VisualRiders.PointOfSale.Project.Exceptions;

public class UnprocessableEntity : HttpResponseException
{
    public UnprocessableEntity(string message) : base(StatusCodes.Status422UnprocessableEntity, new { Message = message })
    {
    }
}