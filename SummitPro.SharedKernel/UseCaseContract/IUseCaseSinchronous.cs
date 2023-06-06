using SummitPro.SharedKernel.Interfaces;

namespace SummitPro.SharedKernel.UseCaseContract
{
    public static class IUseCaseSinchronous
    {
        public static class WithInputBoundary<TInputBoundary>
            where TInputBoundary : IInputBoundary
        {
            public abstract class WithOutputBoundary<TOutputBoundary>
                where TOutputBoundary : IOutputBoundary
            {
                public abstract TOutputBoundary Execute(TInputBoundary inputBoundary);
            }

            public abstract class WithoutOutputBoundary
            {
                public abstract void Execute(TInputBoundary inputBoundary);
            }
        }

        public static class WithoutInputBoundary
        {
            public abstract class WithOutputBoundary<TOutputBoundary>
            {
                public abstract TOutputBoundary Execute();
            }

            public abstract class WithoutOutputBoundary
            {
                public abstract void Execute();
            }
        }
    }
}
