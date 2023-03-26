using api.Domain.Models.PlanosAcao;
using api.Domain.Views.Input.PlanosAcao;
using System.Linq;

namespace api.Domain.Repository.Interface.PlanosAcao
{
    public interface IPlanoAcaoRiscoRepository : IRepository<PlanoAcaoRisco, decimal>
    {
        IQueryable<PlanoAcaoRisco> GetAll(bool active);

        IQueryable<PlanoAcaoRisco> GetByPlanoAcao(long id);

        bool UpdateStatus(long id);

        bool Create(PlanoAcaoRiscoInput input);
        bool Update(PlanoAcaoRiscoInput input);
        bool Remove(long id);

    }
}
