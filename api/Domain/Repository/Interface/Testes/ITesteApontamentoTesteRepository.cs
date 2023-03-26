using api.Domain.Models.Testes;
using api.Domain.Views.Input.Testes;
using System.Linq;

namespace api.Domain.Repository.Interface.Testes
{
    public interface ITesteApontamentoTesteRepository : IRepository<TesteApontamentoTeste, decimal>
    {
        IQueryable<TesteApontamentoTeste> GetAny(bool active);
        IQueryable<TesteApontamentoTeste> GetByTeste(long id);
        IQueryable<TesteApontamentoTeste> GetByTesteApontamento(long idPlanoAcao, long idApontamento);
        long Create(TesteApontamentoTesteInput input); 
        bool Remove(long id);

    }
}
