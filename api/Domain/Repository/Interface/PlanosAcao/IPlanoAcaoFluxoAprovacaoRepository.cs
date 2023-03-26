using api.Domain.Models.PlanosAcao;
using api.Domain.Views.Input.PlanosAcao;
using System.Linq;

namespace api.Domain.Repository.Interface.PlanosAcao
{
    public interface IPlanoAcaoFluxoAprovacaoRepository : IRepository<PlanoAcaoFluxoAprovacao, decimal>
    {
        IQueryable<PlanoAcaoFluxoAprovacao> GetAny(bool active);
        IQueryable<PlanoAcaoFluxoAprovacao> GetByPlanoAcao(long id);
        bool UpdateStatusworkFlow(PlanoAcaoFluxoAprovacaoInput input);
        bool SaveObservacao(PlanoAcaoFluxoAprovacaoInput input);

        long Create(PlanoAcaoFluxoAprovacaoInput input);
        bool UpdateStatus(long id);


        bool Remove(long id);

    }
}
