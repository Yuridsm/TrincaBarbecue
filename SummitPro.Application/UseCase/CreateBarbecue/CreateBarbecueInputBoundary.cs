using SummitPro.SharedKernel.Interfaces;

namespace SummitPro.Application.UseCase.CreateBarbecue
{
    public class CreateBarbecueInputBoundary : IInputBoundary
    {
        public DateTime BeginDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public string Description { get; private set; } = string.Empty;
        public List<string> AdditionalObservations { get; private set; } = new List<string>();

        private CreateBarbecueInputBoundary(string description, List<string> additionalObservations, DateTime beginDate, DateTime endDate)
        {
            Description = description;
            AdditionalObservations = additionalObservations;
            BeginDate = beginDate;
            EndDate = endDate;
        }

        public static CreateBarbecueInputBoundary FactoryMethod(string description, List<string> additionalObservations, DateTime beginDate, DateTime endDate)
        {
            var barbebueEntity = new CreateBarbecueInputBoundary(description, additionalObservations, beginDate, endDate);
            return barbebueEntity;
        }
    }
}
