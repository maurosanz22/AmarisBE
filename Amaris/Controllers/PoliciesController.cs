using Amaris.Attributes;
using Amaris.ViewsModels;
using Contracts.Services;
using Models;
using Models.Enumerations;
using System.Linq;
using System.Web.Http;

namespace Amaris.Controllers
{
    [RoutePrefix("api/Policies")]
    [ClaimsAuthorization(Accesslevels.Admin)]
    public class PoliciesController : BaseController<Policies, PoliciesVm>
    {
        public PoliciesController(IPoliciesService service) 
            : base(service)
        {
        }

        [HttpGet]
        [Route("GetByUserName/{userName}")]
        public IHttpActionResult GetByUserName(string userName)
        {
            var policies = ((IPoliciesService)_service).GetByUserName(userName);

            if (!policies.Any()) return NotFound();

            return Ok(policies.Select(x => MapperToVm(x)));
        }

        [HttpGet]
        [Route("GetClientByPolicyId/{id}")]
        public IHttpActionResult GetClientByPolicyId(string id)
        {
            var obj = _service.GetById(id);

            if (obj == null) return NotFound();

            return Ok(MapperToVm(obj).Client);
        }
    }
}
