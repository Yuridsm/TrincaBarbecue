namespace SummitPro.Application.Model;

public class ParticipantModel
{
	public Guid Identifier { get; set; }
	public string Name { get; set; } = string.Empty;
	public double ContributionValue { get; set; }
	public string BringDrink { get; set; } = string.Empty;
	public List<string> Items { get; set; } = new();
	public string Username { get; set; } = string.Empty;
}
