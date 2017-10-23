using Amaris.ViewsModels;
using Contracts.Services;
using System.Web.Http;

namespace Amaris.Controllers
{
    public class BaseController<T, Y> : ApiController
        where T : new()
        where Y : BaseVm<T>, new()
    {
        protected readonly IBaseService<T> _service;

        public BaseController(IBaseService<T> service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("")]
        public virtual IHttpActionResult Get(string id)
        {
            var obj = _service.GetById(id);

            if (obj == null) return NotFound();

            return Ok(MapperToVm(obj));
        }

        protected Y MapperToVm(T entity)
        {
            var vm = new Y();
            vm.MapperFromModel(entity);

            return vm;
        }
    }
}
