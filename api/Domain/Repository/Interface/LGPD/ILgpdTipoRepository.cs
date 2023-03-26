using api.Domain.Models.LGPD;
using api.Domain.Views.Input.LGPD;
using System.Linq;

namespace api.Domain.Repository.Interface.LGPD
{
    public interface ILgpdTipoRepository : IRepository<LgpdTipo, decimal>
    {
        IQueryable<LgpdTipo> GetAll(bool active); 
        bool Create(LgpdTipoInput input);
        bool Update(LgpdTipoInput input);
        bool Remove(long id);

    }
}
