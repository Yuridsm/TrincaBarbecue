using Microsoft.AspNetCore.Mvc.RazorPages;
using SummitPro.Web.ViewModel;

namespace SummitPro.Web.Pages.Participant;

public class CreateModel : PageModel
{
	public ParticipantViewModel Participant { get; set; }
}
