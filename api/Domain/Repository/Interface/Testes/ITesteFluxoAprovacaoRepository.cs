using api.Domain.Models.Testes;
using api.Domain.Views.Input.Testes;
using System.Linq;

namespace api.Domain.Repository.Interface.Testes
{
    public interface ITesteFluxoAprovacaoRepository : IRepository<TesteFluxoAprovacao, decimal>
    {
        IQueryable<TesteFluxoAprovacao> GetAny(bool active);
        IQueryable<TesteFluxoAprovacao> GetByTeste(long id);
        bool UpdateStatusworkFlow(TesteFluxoAprovacaoInput input);
        bool SaveObservacao(TesteFluxoAprovacaoInput input);

        long Create(TesteFluxoAprovacaoInput input);
        bool UpdateStatus(long id);
        

        bool Remove(long id); 

    }
}
