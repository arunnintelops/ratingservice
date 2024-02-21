namespace Application.Exceptions
{
    public class RatingNotFoundException : ApplicationException
    {
        public RatingNotFoundException(string name, object key) : base($"Entity {name} - {key} is not found.")
        {

        }
    }
}
