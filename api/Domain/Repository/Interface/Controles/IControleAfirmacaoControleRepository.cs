using api.Domain.Models.Controles;
using api.Domain.Views.Input.Controles;
using System.Linq;

namespace api.Domain.Repository.Interface.Controles
{
    public interface IControleAfirmacaoControleRepository : IRepository<ControleAfirmacaoControle, decimal>
    {
        IQueryable<ControleAfirmacaoControle> GetByControle(long id);
        bool Create(ControleAfirmacaoControleInput input);
        bool Remove(long id);

    }
}
