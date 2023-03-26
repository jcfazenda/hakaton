using api.Domain.Models.Incidentes;
using api.Domain.Views.Input.Incidentes;
using System.Linq;

namespace api.Domain.Repository.Interface.Incidentes
{
    public interface IIncidenteCategoriaRepository : IRepository<IncidenteCategoria, decimal>
    {
        IQueryable<IncidenteCategoria> GetAll(bool active);
        bool UpdateStatus(long id);
        bool Create(IncidenteCategoriaInput input);
        bool Update(IncidenteCategoriaInput input);
        bool Remove(long id);

    }
}
