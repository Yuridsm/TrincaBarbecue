using TrincaBarbecue.Core;

namespace TrincaBarbecue.Application.UseCase.CreateBarbecue
{
    public class InputBoundary : IInputBoundary
    {
        public DateTime BeginDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public string Description { get; private set; } = string.Empty;
        public List<string> AdditionalObservations { get; private set; } = new List<string>();

        private InputBoundary(string description, List<string> additionalObservations, DateTime beginDate, DateTime endDate)
        {
            Description = description;
            AdditionalObservations = additionalObservations;
            BeginDate = beginDate;
            EndDate = endDate;
        }

        public static InputBoundary FactoryMethod(string description, List<string> additionalObservations, DateTime beginDate, DateTime endDate)
        {
            var barbebueEntity = new InputBoundary(description, additionalObservations, beginDate, endDate);
            return barbebueEntity;
        }
    }
}
