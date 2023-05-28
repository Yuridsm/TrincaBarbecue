namespace TrincaBarbecue.Application.UseCase.CreateBarbecue
{
    public class OutputBoundary
    {
        private Guid Identifier;

        private OutputBoundary(Guid identifier)
        {
            Identifier = identifier;
        }

        public static OutputBoundary FactoryMethod(Guid identifier)
        {
            return new OutputBoundary(identifier);
        }

        public string GetIdentifier()
        {
            return Identifier.ToString();
        }
    }
}
