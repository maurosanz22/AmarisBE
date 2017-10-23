using Models;

namespace Amaris.ViewsModels
{
    public class ClientVm : BaseVm<ApplicationUser>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

        public override void MapperFromModel(ApplicationUser entity)
        {
            Id = entity?.Id;
            Name = entity?.UserName;
            Email = entity?.Email;
            Role = entity?.Role;
        }
    }
}