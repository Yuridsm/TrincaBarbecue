namespace TrincaBarbecue.Core.UseCaseContract
{
    public interface IUseCase<in TInputBoundary, out TOutputBoundary>
        where TInputBoundary : IInputBoundary
        where TOutputBoundary : IOutputBoundary
    {
        TOutputBoundary Execute(TInputBoundary inputBoundary);
    }
}
