
using api.Domain.Models.PerfisAcesso.Telas;
using api.Domain.Views.Input.PerfisAcesso.Telas;
using System.Linq;

namespace api.Domain.Repository.Interface.PerfisAcesso.Telas
{
    public interface INivelAcessoUsuarioRepository : IRepository<NivelAcessoUsuario, decimal>
    {
        IQueryable<NivelAcessoUsuario> GetAll(bool active);
        IQueryable<NivelAcessoUsuario> GetByUsuario(long id);
        IQueryable<NivelAcessoUsuario> GetExist(NivelAcessoUsuarioInput input);

        bool UpdateStatus(long id);
        bool Create(NivelAcessoUsuarioInput input);
        bool Update(NivelAcessoUsuarioInput input);

        bool RemoveByUsuario(long id);
        bool Remove(long id);

    }
}
