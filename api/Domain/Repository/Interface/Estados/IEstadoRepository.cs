using api.Domain.Models.Estados;
using System.Linq;

namespace api.Domain.Repository.Interface.Estados
{
    public interface IEstadoRepository : IRepository<Estado, decimal>
    {
        IQueryable<Estado> GetAll(bool active); 

    }
}
