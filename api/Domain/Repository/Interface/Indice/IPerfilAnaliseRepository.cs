using api.Domain.Models.Indice;
using api.Domain.Views.Input.Indice;
using System.Linq;

namespace api.Domain.Repository.Interface.Indice
{
    public interface IPerfilAnaliseRepository : IRepository<PerfilAnalise, decimal>
    {
        IQueryable<PerfilAnalise> GetAll(bool active);
        IQueryable<PerfilAnalise> Get(long id);
        bool UpdateStatus(long id);
        bool Create(PerfilAnaliseInput input);
        bool Update(PerfilAnaliseInput input);
        bool Remove(long id);

    }
}
