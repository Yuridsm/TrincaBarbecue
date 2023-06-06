namespace SummitPro.SharedKernel.DomainException
{
    public class DateTimeDoesNotMatchException : Exception
    {
        public DateTimeDoesNotMatchException()
        {
        }

        public DateTimeDoesNotMatchException(string message)
            : base(message)
        {
        }

        public DateTimeDoesNotMatchException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
