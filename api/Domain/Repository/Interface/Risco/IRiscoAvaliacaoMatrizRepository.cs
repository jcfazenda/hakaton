using api.Domain.Models.Risco;
using api.Domain.Views.Input.Risco;
using System.Linq;

namespace api.Domain.Repository.Interface.Risco
{
    public interface IRiscoAvaliacaoMatrizRepository : IRepository<RiscoAvaliacaoMatriz, decimal>
    {
        IQueryable<RiscoAvaliacaoMatriz> GetAll(bool active);
        IQueryable<RiscoAvaliacaoMatriz> GetByAvaliacao(long id);

        bool Create(RiscoAvaliacaoMatrizInput input);
        bool Update(RiscoAvaliacaoMatrizInput input);
        bool Remove(long id);
        bool RemoveByRiscoAvaliacao(long id);

    }
}
