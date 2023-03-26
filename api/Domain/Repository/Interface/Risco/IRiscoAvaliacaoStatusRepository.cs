using api.Domain.Models.Risco;
using api.Domain.Views.Input.Risco;
using System.Linq;

namespace api.Domain.Repository.Interface.Risco
{
    public interface IRiscoAvaliacaoStatusRepository : IRepository<RiscoAvaliacaoStatus, decimal>
    {
        IQueryable<RiscoAvaliacaoStatus> GetAll(bool active);
        IQueryable<RiscoAvaliacaoStatus> GetByDescricao(string Descricao);

        bool UpdateStatus(long id);
        bool Create(RiscoAvaliacaoStatusInput input);
        bool Update(RiscoAvaliacaoStatusInput input);
        bool Remove(long id);

    }
}
