using Microsoft.AspNetCore.Mvc;

namespace TrincaBarbecue.Web.Endpoints
{
    #region Endpoint Contracts
    public interface WithReq<Request> { }

    public abstract class EndpointWithResult<Request, Response> : EndpointBase, WithReq<Request>
    {
        public abstract Response Handle(Request req);
    }

    public abstract class EndpointWithoutResult<Request> : EndpointBase, WithReq<Request>
    {
        public abstract void Handle(Request req);
    }

    public abstract class EndpointActionResult<Request, Response> : EndpointBase, WithReq<Request>
    {
        public abstract ActionResult<Response> Handle(Request req);
    }

    public abstract class EndpointActionResult<Request> : EndpointBase, WithReq<Request>
    {
        public abstract ActionResult Handle(Request req);
    }
    #endregion

    public class Get : EndpointWithResult<InputBoundary, ActionResult>
    {
        public override ActionResult Handle(InputBoundary req)
        {
            throw new NotImplementedException();
        }
    }

    // Models
    public class InputBoundary { }
    public class OutputBoundary { }
}
