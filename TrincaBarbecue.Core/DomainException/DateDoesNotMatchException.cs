namespace TrincaBarbecue.Core.DomainException
{
    public class DateDoesNotMatchException : Exception
    {
        public DateDoesNotMatchException()
        {
        }

        public DateDoesNotMatchException(string message)
            : base(message)
        {
        }

        public DateDoesNotMatchException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
