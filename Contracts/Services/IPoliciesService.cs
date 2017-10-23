using Models;
using System.Collections.Generic;

namespace Contracts.Services
{
    public interface IPoliciesService : IBaseService<Policies>
    {
        IEnumerable<Policies> GetByUserName(string userName);
    }
}
