using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SummitPro.Application.Repository;
using SummitPro.Web.ViewModel;

namespace SummitPro.Web.Pages.Barbecue
{
    public class IndexModel : PageModel
    {
        private readonly IBarbecueRepository _barbecueRepository;

        [BindProperty]
        public List<BarbecueViewModel> BarbecueViewModels { get; set; } = new();

        public IndexModel(IBarbecueRepository barbecueRepository)
        {
            _barbecueRepository = barbecueRepository;
        }

        public void OnGet()
        {
            var barbecues = _barbecueRepository.GetAll();

            if (barbecues is null) return;

            foreach(var item in barbecues)
            {
                BarbecueViewModels.Add(new BarbecueViewModel
                {
                    BarbecueIdentifier = item.Identifier,
                    Description = item.Description,
                    BeginDate = item.BeginDate,
                    EndDateTime = item.EndDate,
                    AdditionalRemarks = string.Join("\r\n", item.AdditionalRemarks),
                    ParticipantQuantity = item.ParticipantsQuantity()
                });
            }
        }
    }
}
