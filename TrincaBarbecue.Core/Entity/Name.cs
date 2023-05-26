using TrincaBarbecue.Core.DomainException;

namespace TrincaBarbecue.Core.Entity
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

            // Verifica se os nomes contêm apenas caracteres ASCII
            if (!IsAsciiString(name)) return false;

            return true;
        }

        private static bool IsAsciiString(string input)
        {
            foreach (char c in input)
                if (c > 255) return false;

            return true;
        }
    }
}
