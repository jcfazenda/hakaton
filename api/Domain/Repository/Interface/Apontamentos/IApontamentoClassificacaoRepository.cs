using api.Domain.Models.Apontamentos;
using api.Domain.Views.Input.Apontamentos;
using System.Linq;

namespace api.Domain.Repository.Interface.Apontamentos
{
    public interface IApontamentoClassificacaoRepository : IRepository<ApontamentoClassificacao, decimal>
    {
        IQueryable<ApontamentoClassificacao> GetAll(bool active);
        bool UpdateStatus(long id);

        bool Create(ApontamentoClassificacaoInput input);
        bool Update(ApontamentoClassificacaoInput input);
        bool Remove(long id);

    }
}
