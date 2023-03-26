using api.Domain.Models.PlanosAcao;
using api.Domain.Views.Input.PlanosAcao;
using System.Linq;

namespace api.Domain.Repository.Interface.PlanosAcao
{
    public interface IPlanoAcaoRepository : IRepository<PlanoAcao, decimal>
    {
        IQueryable<PlanoAcao> GetAll(bool active);
        bool UpdateStatus(long id);
        bool UpdateEncerramento(PlanoAcaoInput input);

        bool UpdatePlanoAcaoWorkflow(PlanoAcaoInput input);

        bool Create(PlanoAcaoInput input);
        bool Update(PlanoAcaoInput input);
        bool Remove(long id);

    }
}
