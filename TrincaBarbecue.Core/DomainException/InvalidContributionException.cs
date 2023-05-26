namespace TrincaBarbecue.Core.DomainException
{
    public class InvalidContributionException : Exception
    {
        public InvalidContributionException()
        {
        }

        public InvalidContributionException(string message)
            : base(message)
        {
        }

        public InvalidContributionException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
