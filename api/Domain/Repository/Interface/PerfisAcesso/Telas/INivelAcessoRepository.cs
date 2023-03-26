
using api.Domain.Models.PerfisAcesso.Telas;
using api.Domain.Views.Input.PerfisAcesso.Telas;
using System.Linq;

namespace api.Domain.Repository.Interface.PerfisAcesso.Telas
{
    public interface INivelAcessoRepository : IRepository<NivelAcesso, decimal>
    {
        IQueryable<NivelAcesso> GetAll(bool active);
        bool UpdateStatus(long id);
        bool Create(NivelAcessoInput input);
        bool Update(NivelAcessoInput input);
        bool Remove(long id);

    }
}
