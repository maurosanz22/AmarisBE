using Models;
using System;

namespace Amaris.ViewsModels
{
    public class PoliciesVm : BaseVm<Policies>
    {
        public decimal? AmountInsured { get; set; }
        public string Email { get; set; }
        public DateTime? InceptionDate { get; set; }
        public bool? InstallmentPayment { get; set; }
        public ClientVm Client { get; set; }

        public override void MapperFromModel(Policies entity)
        {
            Id = entity?.Id;
            AmountInsured = entity?.AmountInsured;
            Email = entity?.Email;
            InceptionDate = entity?.InceptionDate;
            InstallmentPayment = entity?.InstallmentPayment;
            var clientVm = new ClientVm();
            clientVm.MapperFromModel(entity?.Client);
            Client = clientVm;
        }
    }
}