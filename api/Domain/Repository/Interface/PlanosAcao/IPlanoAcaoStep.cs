using api.Domain.Models.PlanosAcao;
using api.Domain.Views.Input.PlanosAcao;
using System.Linq;

namespace api.Domain.Repository.Interface.PlanosAcao
{
    public interface IPlanoAcaoStepRepository : IRepository<PlanoAcaoStep, decimal>
    {
        IQueryable<PlanoAcaoStep> GetAll(bool active);

        IQueryable<PlanoAcaoStep> GetByPlanoAcao(long id);

        bool UpdateStatus(long id);

        bool Create(PlanoAcaoStepInput input);
        bool Update(PlanoAcaoStepInput input);
        bool Remove(long id);

    }
}
