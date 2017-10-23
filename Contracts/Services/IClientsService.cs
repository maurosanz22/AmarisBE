using Models;

namespace Contracts.Services
{
    public interface IClientsService : IBaseService<ApplicationUser>
    {
        ApplicationUser GetByUserName(string userName);
    }
}
