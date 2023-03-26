using api.Domain.Models.Usuario;
using api.Domain.Views.Input.Usuario;
using System.Linq;

namespace api.Domain.Repository.Interface.Usuario
{
    public interface IUsuarioCargoAtividadeRepository : IRepository<UsuarioCargoAtividade, decimal>
    {
        IQueryable<UsuarioCargoAtividade> GetAll(bool active);

        bool UpdateStatus(long id);

        bool Create(UsuarioCargoAtividadeInput input);
        bool Update(UsuarioCargoAtividadeInput input);
        bool Remove(long id);

    }
}
