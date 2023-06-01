using TrincaBarbecue.SharedKernel.DomainException;
using TrincaBarbecue.SharedKernel.Interfaces;

namespace TrincaBarbecue.Core.Aggregate.Participant
{
    public class Username : IValueObject
    {
        public string Value { get; private set; }

        public Username(string username)
        {
            if (!Validate(username)) throw new InvalidUsernameException("username");

            Value = username;
        }

        public static bool Validate(string username)
        {
            if (string.IsNullOrEmpty(username)) return false;

            if (username.IndexOf("@") != 0) return false;

            return true;
        }
    }
}
