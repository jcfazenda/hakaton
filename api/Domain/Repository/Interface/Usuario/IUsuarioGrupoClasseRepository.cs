using api.Domain.Models.Usuario;
using api.Domain.Views.Input.Usuario;
using System.Linq;

namespace api.Domain.Repository.Interface.Usuario
{
    public interface IUsuarioGrupoClasseRepository : IRepository<UsuarioGrupoClasse, decimal>
    {
        IQueryable<UsuarioGrupoClasse> GetAll(bool active);

        bool UpdateStatus(long id);

        bool Create(UsuarioGrupoClasseInput input);
        bool Update(UsuarioGrupoClasseInput input);
        bool Remove(long id);

    }
}
