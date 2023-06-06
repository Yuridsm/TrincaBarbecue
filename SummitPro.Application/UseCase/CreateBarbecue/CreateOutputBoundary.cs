using SummitPro.SharedKernel.Interfaces;

namespace SummitPro.Application.UseCase.CreateBarbecue
{
    public class CreateOutputBoundary : IOutputBoundary
    {
        private Guid Identifier;

        private CreateOutputBoundary(Guid identifier)
        {
            Identifier = identifier;
        }

        public static CreateOutputBoundary FactoryMethod(Guid identifier)
        {
            return new CreateOutputBoundary(identifier);
        }

        public string GetIdentifier()
        {
            return Identifier.ToString();
        }
    }
}
