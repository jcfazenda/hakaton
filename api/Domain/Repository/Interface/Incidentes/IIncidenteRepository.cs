using api.Domain.Models.Incidentes;
using api.Domain.Views.Input.Incidentes;
using System.Linq;

namespace api.Domain.Repository.Interface.Incidentes
{
    public interface IIncidenteRepository : IRepository<Incidente, decimal>
    {
        IQueryable<Incidente> GetAll(bool active);
        bool UpdateStatus(long id);
        bool Create(IncidenteInput input);
        bool Update(IncidenteInput input);
        bool Remove(long id);

    }
}
