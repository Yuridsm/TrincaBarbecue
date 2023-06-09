using SummitPro.SharedKernel.Interfaces;

namespace SummitPro.SharedKernel.UseCaseContract
{
    public static class IUseCaseAsynchronous
    {
        public static class WithInputBoundary<TInputBoundary> where TInputBoundary : IInputBoundary
        {
            public abstract class WithOutputBoundary<TOutputBoundary> where TOutputBoundary : IOutputBoundary
            {
                public abstract Task<TOutputBoundary> Execute(TInputBoundary inputBoundary);
            }

            public abstract class WithoutOutputBoundary
            {
                public abstract Task Execute(TInputBoundary inputBoundary);
            }
        }

        public static class WithoutInputBoundary
        {
            public abstract class WithOutputBondary<TOutputBoundary> where TOutputBoundary : IOutputBoundary
            {
                public abstract Task<TOutputBoundary> Execute();
            }

            public abstract class WithoutOutputBoundary
            {
                public abstract Task Execute();
            }
        }
    }
}
