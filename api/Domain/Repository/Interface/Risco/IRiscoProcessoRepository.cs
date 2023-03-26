using api.Domain.Models.Risco;
using api.Domain.Views.Input.Risco;
using System.Linq;

namespace api.Domain.Repository.Interface.Risco
{
    public interface IRiscoProcessoRepository : IRepository<RiscoProcesso, decimal>
    {
        IQueryable<RiscoProcesso> GetByRisco(long id);
        bool Create(RiscoProcessoInput input);
        bool Remove(long id);

    }
}
