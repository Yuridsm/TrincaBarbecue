using SummitPro.SharedKernel.Interfaces;
using SummitPro.SharedKernel.DomainException;

namespace SummitPro.Core.Aggregate.Participant;

public class Username : IValueObject
{
	public string Value { get; private set; }

	public Username(string value)
	{
		if (!Validate(value)) throw new InvalidUsernameException("username");

		Value = value;
	}

	public static bool Validate(string username)
	{
		if (string.IsNullOrEmpty(username)) return false;

		if (username.IndexOf("@") != 0) return false;

		return true;
	}
}
