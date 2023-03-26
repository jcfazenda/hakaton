using api.Domain.Models.PlanosAcao;
using api.Domain.Views.Input.PlanosAcao;
using System.Linq;

namespace api.Domain.Repository.Interface.PlanosAcao
{
    public interface IPlanoAcaoStatusRepository : IRepository<PlanoAcaoStatus, decimal>
    {
        IQueryable<PlanoAcaoStatus> GetAll(bool active);
        bool UpdateStatus(long id); 

        bool Create(PlanoAcaoStatusInput input);
        bool Update(PlanoAcaoStatusInput input);
        bool Remove(long id);

    }
}
