namespace TrincaBarbecue.Application.Input
{
    public class BarbecueInput
    {
        public DateTime BeginDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public string Description { get; private set; } = string.Empty;
        public IEnumerable<string> AdditionalObservations { get; private set; } = new List<string>();

        private BarbecueInput(string description, IEnumerable<string> additionalObservations, DateTime beginDate, DateTime endDate)
        {
            Description = description;
            AdditionalObservations = additionalObservations;
            BeginDate = beginDate;
            EndDate = endDate;
        }

        public static BarbecueInput FactoryMethod(string description, IEnumerable<string> additionalObservations, DateTime beginDate, DateTime endDate)
        {
            var barbebueEntity = new BarbecueInput(description, additionalObservations, beginDate, endDate);
            return barbebueEntity;
        }
    }
}
