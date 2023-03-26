using api.Domain.Models.Testes;
using api.Domain.Views.Input.Testes;
using System.Linq;

namespace api.Domain.Repository.Interface.Testes
{
    public interface ITesteStatusHistoricoRepository : IRepository<TesteStatusHistorico, decimal>
    {
        IQueryable<TesteStatusHistorico> GetByTeste(long id);

        bool Create(TesteStatusHistoricoInput input);
        bool Remove(long id);

    }
}
