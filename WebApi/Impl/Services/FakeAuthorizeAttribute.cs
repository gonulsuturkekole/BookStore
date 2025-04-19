using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Impl.Services
{
    public class FakeAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var userId = context.HttpContext.Items["UserId"];
            if (userId == null)
            {
                context.Result = new UnauthorizedObjectResult(new
                {
                    status = 401,
                    message = "must log in to perform this action"
                });
            }
        }
    }
}
