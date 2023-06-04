using System.Text.Json.Serialization;
using TrincaBarbecue.SharedKernel.DomainException;
using TrincaBarbecue.SharedKernel.Interfaces;

namespace TrincaBarbecue.Core.Aggregate.Participant
{
    public class Name : IValueObject
    {
        public string Value { get; private set; } = string.Empty;

        public Name(string value)
        {
            if (!Validate(value)) throw new NameInvalidException("Invalid name. Possibly caracter non ASCII");

            Value = value;
        }

        public static bool Validate(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return false;

            if (!IsLetterString(name)) return false;

            return true;
        }

        private static bool IsLetterString(string input)
        {
            foreach (char c in input)
                if (char.IsNumber(c)) return false;

            return true;
        }
    }
}
