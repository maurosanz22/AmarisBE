using Models.Enumerations;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Amaris.Attributes
{
    public class ClaimsAuthorizationAttribute : AuthorizationFilterAttribute
    {
        public Accesslevels Accesslevel { get; set; }

        public ClaimsAuthorizationAttribute(Accesslevels accesslevel)
        {
            Accesslevel = accesslevel;
        }

        public override Task OnAuthorizationAsync(HttpActionContext actionContext, System.Threading.CancellationToken cancellationToken)
        {
            var claims = actionContext.RequestContext.Principal as ClaimsPrincipal;

            if (!Authorization(claims))
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                return Task.FromResult<object>(null);
            }

            return Task.FromResult<object>(null);

        }

        public bool Authorization(ClaimsPrincipal claims)
        {
            if (!claims.Identity.IsAuthenticated)
            {
                return false;
            }

            var claim = claims.FindFirst(x => x.Type == ClaimTypes.Role);

            if (claim != null && (Accesslevel == Accesslevels.AllRoles || claim.Value.ToLower() == Accesslevel.ToString().ToLower()))
            {
                return true;
            }

            return false;
        }
    }
}