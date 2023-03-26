using api.Domain.Models.Testes;
using api.Domain.Views.Input.Testes;
using System.Linq;

namespace api.Domain.Repository.Interface.Testes
{
    public interface ITesteStatusRepository : IRepository<TesteStatus, decimal>
    {
        IQueryable<TesteStatus> GetAll(bool active);
        bool UpdateStatus(long id);
        bool Create(TesteStatusInput input);
        bool Update(TesteStatusInput input);
        bool Remove(long id);

    }
}
