using api.Domain.Models.Risco;
using api.Domain.Views.Input.Risco;
using System.Linq;

namespace api.Domain.Repository.Interface.Risco
{
    public interface ICategoriaRiscoRepository : IRepository<CategoriaRisco, decimal>
    {
        IQueryable<CategoriaRisco> GetAll(bool active);
        bool UpdateStatus(long id);
        bool Create(CategoriaRiscoInput input);
        bool Update(CategoriaRiscoInput input);
        bool Remove(long id);

    }
}
