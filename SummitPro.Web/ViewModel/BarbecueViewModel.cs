namespace SummitPro.Web.ViewModel;

public class BarbecueViewModel
{
	public Guid BarbecueIdentifier { get; set; }
	public string Description { get; set; } = string.Empty;
	public DateTime BeginDate { get; set; }
	public DateTime EndDateTime { get; set; }
	public string? AdditionalRemarks { get; set; } = string.Empty;
	public int ParticipantQuantity { get; set; }

	public override string ToString()
	{
		return $"Description: {Description}" +
			$"BeginDate: {BeginDate}" +
			$"EndDate: {EndDateTime}" +
			$"Additional Remarks: {AdditionalRemarks}";
	}

	public List<string> SplitAdditionalRemarks(string token = "\r\n")
	{
		if (string.IsNullOrEmpty(AdditionalRemarks)) return new List<string>(0);

		var remarks = new List<string>();
		var splittedAdditionalRemarks = AdditionalRemarks!.Split(token);

		foreach (var remark in splittedAdditionalRemarks)
			remarks.Add(remark);

		return remarks;
	}
}
