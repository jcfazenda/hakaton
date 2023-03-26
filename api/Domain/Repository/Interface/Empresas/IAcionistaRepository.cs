using api.Domain.Models.Empresas;
using api.Domain.Views.Input.Empresas;
using System.Linq;

namespace api.Domain.Repository.Interface.Empresas
{
    public interface IAcionistaRepository : IRepository<Acionista, decimal>
    {
        IQueryable<Acionista> GetAll(bool active);
        bool UpdateStatus(long id);
        bool Create(AcionistaInput input);
        bool Update(AcionistaInput input);
        bool Remove(long id);

    }
}
