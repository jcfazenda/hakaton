using api.Domain.Models.Controles;
using api.Domain.Views.Input.Controles;
using System.Linq;

namespace api.Domain.Repository.Interface.Controles
{
    public interface IControleTipoRepository : IRepository<ControleTipo, decimal>
    {
        IQueryable<ControleTipo> GetAll(bool active);
        bool UpdateStatus(long id);
        bool Create(ControleTipoInput input);
        bool Update(ControleTipoInput input);
        bool Remove(long id);

    }
}
