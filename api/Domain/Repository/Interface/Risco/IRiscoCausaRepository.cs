using api.Domain.Models.Risco;
using api.Domain.Views.Input.Risco;
using System.Linq;

namespace api.Domain.Repository.Interface.Risco
{
    public interface IRiscoCausaRepository : IRepository<RiscoCausa, decimal>
    {
        IQueryable<RiscoCausa> GetByRisco(long id);
        bool Create(RiscoCausaInput input);
        bool SaveRiscoCausaMatriz(RiscoCausaInput input);
        bool Remove(long id);

    }
}
