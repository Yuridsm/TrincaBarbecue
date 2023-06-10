using Microsoft.AspNetCore.Mvc;

namespace SummitPro.Web.Endpoints
{
    public static class EndpointBaseAssynchronous
    {
        public static class WithRequest<TRequest>
        {
            public abstract class WithResult<TResponse> : EndpointBase
            {
                public abstract Task<TResponse> Handle(TRequest request);
            }

            public abstract class WithoutResult : EndpointBase
            {
                public abstract Task Handle(TRequest request);
            }

            public abstract class WithActionResult<TResponse> : EndpointBase
            {
                public abstract Task<ActionResult<TResponse>> Handle(TRequest request);
            }

            public abstract class WithActionResult : EndpointBase
            {
                public abstract Task<ActionResult> Handle(TRequest request);
            }
        }

        public static class WithoutRequest
        {
            public abstract class WithResult<TResponse> : EndpointBase
            {
                public abstract Task<TResponse> Handle();
            }

            public abstract class WithoutResult : EndpointBase
            {
                public abstract Task Handle();
            }

            public abstract class WithActionResult<TResponse> : EndpointBase
            {
                public abstract Task<ActionResult<TResponse>> Handle();
            }

            public abstract class WithActionResult : EndpointBase
            {
                public abstract Task<ActionResult> Handle();
            }
        }
    }
}
