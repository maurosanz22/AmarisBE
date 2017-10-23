using Amaris.Attributes;
using Amaris.ViewsModels;
using Contracts.Services;
using Models;
using Models.Enumerations;
using System.Web.Http;

namespace Amaris.Controllers
{
    [RoutePrefix("api/Clients")]
    [ClaimsAuthorization(Accesslevels.AllRoles)]
    public class ClientsController : BaseController<ApplicationUser, ClientVm>
    {
        public ClientsController(IClientsService service)
            : base(service)
        {
        }

        [HttpGet]
        [Route("GetByUserName/{userName}")]
        public IHttpActionResult GetByUserName(string userName)
        {
            var obj = ((IClientsService)_service).GetByUserName(userName);

            if (obj == null) return NotFound();

            return Ok(MapperToVm(obj));
        }
    }
}
