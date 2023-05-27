using TrincaBarbecue.Core.DomainException;

namespace TrincaBarbecue.Core.Aggregate
{
    public class Name : IValueObject
    {
        public string Value { get; private set; } = string.Empty;

        public Name(string name)
        {
            if (!Validate(name)) throw new NameInvalidException("Invalid name. Possibly caracter non ASCII");

            Value = name;
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
