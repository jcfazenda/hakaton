using api.Domain.Models.Usuario;
using api.Domain.Views.Input.Usuario;
using System.Linq;

namespace api.Domain.Repository.Interface.Usuario
{
    public interface IUsuariosRepository : IRepository<Usuarios, decimal>
    {
        IQueryable<Usuarios> GetAll(bool active);
        IQueryable<Usuarios> GetAccess(UsuariosInput input);

        bool UpdateStatus(long id);

        Usuarios Create(UsuariosInput input);
        bool Update(UsuariosInput input);
        bool UpdateAvatar(UsuariosInput input);
        bool UpdatePassword(UsuariosInput input);

        bool Remove(long id);

    }
}
