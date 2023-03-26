using api.Domain.Models.PlanosAcao;
using api.Domain.Views.Input.PlanosAcao;
using System.Linq;

namespace api.Domain.Repository.Interface.PlanosAcao
{
    public interface IPlanoAcaoControleRepository : IRepository<PlanoAcaoControle, decimal>
    {
        IQueryable<PlanoAcaoControle> GetAll(bool active);
        IQueryable<PlanoAcaoControle> GetByPlanoAcao(long id);
        IQueryable<PlanoAcaoControle> GetByPlanoAcaoControle(long idPlanoAcao, long idControle);
        bool UpdateStatus(long id);

        bool Create(PlanoAcaoControleInput input);
        bool Update(PlanoAcaoControleInput input);
        bool Remove(long id);

    }
}
