
using api.Domain.Models.PerfisAcesso.Telas;
using api.Domain.Views.Input.PerfisAcesso.Telas;
using System.Linq;

namespace api.Domain.Repository.Interface.PerfisAcesso.Telas
{
    public interface ITelaRepository : IRepository<Tela, decimal>
    {
        IQueryable<Tela> GetAll(bool active);
        IQueryable<Tela> GetByURL(string url);

        bool UpdateStatus(long id);
        bool Create(TelaInput input);
        bool Update(TelaInput input);
        bool Remove(long id);

    }
}
