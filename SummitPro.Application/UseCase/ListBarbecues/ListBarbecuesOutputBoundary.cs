using SummitPro.SharedKernel.Interfaces;

namespace SummitPro.Application.UseCase.ListBarbecues
{
    public class ListBarbecuesOutputBoundary : IOutputBoundary
    {
        public IEnumerable<BarbecueModel> Barbecues { get; set; }
    }

    public class BarbecueModel
    {
        public Guid barbecueIdentifier { get; set; }
        public string Description { get; set; }
        public IEnumerable<ParticipantModel> Participants { get; set; }
        public string BeginDate { get; set; }
        public string EndDate { get; set; }
        public List<string> AdditionalRemarks { get; set; }

    }

    public class ParticipantModel
    {
        public Guid Identifier { get; set; }
        public string Name { get; set; }
        public double ContributionValue { get; set; }
        public string BringDrink { get; set; }
        public List<string> Items { get; set; }
        public string Username { get; set; }
    }
}
