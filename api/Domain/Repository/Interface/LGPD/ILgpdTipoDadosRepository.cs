using api.Domain.Models.LGPD;
using api.Domain.Views.Input.LGPD;
using System.Linq;

namespace api.Domain.Repository.Interface.LGPD
{
    public interface ILgpdTipoDadosRepository : IRepository<LgpdTipoDados, decimal>
    {
        IQueryable<LgpdTipoDados> GetAll(bool active);
        bool Create(LgpdTipoDadosInput input);
        bool Update(LgpdTipoDadosInput input);
        bool Remove(long id);

    }
}
