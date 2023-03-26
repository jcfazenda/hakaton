using api.Domain.Models.Risco;
using api.Domain.Views.Input.Risco;
using System.Linq;

namespace api.Domain.Repository.Interface.Risco
{
    public interface IRiscoAvaliacaoRepository : IRepository<RiscoAvaliacao, decimal>
    {
        IQueryable<RiscoAvaliacao> GetAll(bool active);
        IQueryable<RiscoAvaliacao> GetByAvaliacao(long id);
        IQueryable<RiscoAvaliacao> GetByRisco(long id);
        IQueryable<RiscoAvaliacao> GetByStatus(long id);

        bool UpdateStatusWorkFlow(long id, long idStatus);
        bool UpdateStatus(long id);
        long Create(RiscoAvaliacaoInput input);
        bool Update(RiscoAvaliacaoInput input);
        bool Remove(long id);

    }
}
