using api.Domain.Models.PlanosAcao;
using api.Domain.Views.Input.PlanosAcao;
using System.Linq;

namespace api.Domain.Repository.Interface.PlanosAcao
{
    public interface IPlanoAcaoApontamentoPlanoRepository : IRepository<PlanoAcaoApontamentoPlano, decimal>
    {
        IQueryable<PlanoAcaoApontamentoPlano> GetAll(bool active);
        IQueryable<PlanoAcaoApontamentoPlano> GetByPlanoAcao(long id);
        IQueryable<PlanoAcaoApontamentoPlano> GetByPlanoAcaoApontamento(long idPlanoAcao, long idApontamento);
        bool UpdateStatus(long id);

        bool Create(PlanoAcaoApontamentoPlanoInput input);
        bool Update(PlanoAcaoApontamentoPlanoInput input);
        bool Remove(long id);

    }
}
