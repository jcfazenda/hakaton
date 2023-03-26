 
using api.Domain.Models.Testes;
using api.Domain.Views.Input.Testes;
using System.Linq;

namespace api.Domain.Repository.Interface.Testes
{
    public interface ITesteAnexoRepository : IRepository<TesteAnexo, decimal>
    {
        IQueryable<TesteAnexo> GetByTeste(long id);
        IQueryable<TesteAnexo> GetAny(bool active); 
        bool Create(TesteAnexoInput input); 
        bool Remove(long id);

    }
}
