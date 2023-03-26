using api.Domain.Models.Usuario;
using api.Domain.Views.Input.Usuario;
using System.Linq;

namespace api.Domain.Repository.Interface.Usuario
{
    public interface IUsuarioAreaAtuacaoRepository : IRepository<UsuarioAreaAtuacao, decimal>
    {
        IQueryable<UsuarioAreaAtuacao> GetAll(bool active);

        bool UpdateStatus(long id);

        bool Create(UsuarioAreaAtuacaoInput input);
        bool Update(UsuarioAreaAtuacaoInput input);
        bool Remove(long id);

    }
}
