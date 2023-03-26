using api.Domain.Models.CarrieMessage;
using api.Domain.Views.Input.CarrieMessage;
using System.Linq;

namespace api.Domain.Repository.Interface.CarrieMessage
{
    public interface ICorreioTipoRepository : IRepository<CorreioTipo, decimal>
    {
        IQueryable<CorreioTipo> GetAll(bool active);
        bool UpdateStatus(long id);
        bool Create(CorreioTipoInput input);
        bool Update(CorreioTipoInput input);
        bool Remove(long id);

    }
}
