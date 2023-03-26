using api.Domain.Models.Controles;
using api.Domain.Views.Input.Controles;
using System.Linq;

namespace api.Domain.Repository.Interface.Controles
{
    public interface IControleAfirmacaoRepository : IRepository<ControleAfirmacao, decimal>
    {
        IQueryable<ControleAfirmacao> GetAll(bool active);
        bool UpdateStatus(long id);
        long Create(ControleAfirmacaoInput input);
        long Update(ControleAfirmacaoInput input);
        bool Remove(long id);

    }
}
