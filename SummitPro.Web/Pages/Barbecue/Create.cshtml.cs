using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SummitPro.Application.Interface;
using SummitPro.Application.UseCase.CreateBarbecue;
using SummitPro.Web.ViewModel;

namespace SummitPro.Web.Pages.Barbecue;

public class CreateModel : PageModel
{
	private readonly ICreateBarbecueUseCase _createBarbecueUseCase;

	[BindProperty]
	public BarbecueViewModel Barbecue { get; set; }

	public CreateModel(ICreateBarbecueUseCase createBarbecueUseCase)
	{
		Barbecue = new BarbecueViewModel();
		_createBarbecueUseCase = createBarbecueUseCase;
	}

	public void OnGet()
	{
	}

	public async Task<IActionResult> OnPostAsync()
	{
		if (!ModelState.IsValid) return Page();

		var inputBoundary = new CreateBarbecueInputBoundary
		{
			Description = Barbecue.Description,
			BeginDate = Barbecue.BeginDate,
			EndDate = Barbecue.EndDateTime,
			AdditionalObservations = Barbecue.SplitAdditionalRemarks()
		};

		var output = await _createBarbecueUseCase.Execute(inputBoundary);

		return RedirectToPage("Index");
	}
}
