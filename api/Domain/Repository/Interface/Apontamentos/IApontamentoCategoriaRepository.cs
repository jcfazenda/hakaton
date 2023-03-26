using api.Domain.Models.Apontamentos;
using api.Domain.Views.Input.Apontamentos;
using System.Linq;

namespace api.Domain.Repository.Interface.Apontamentos
{
    public interface IApontamentoCategoriaRepository : IRepository<ApontamentoCategoria, decimal>
    {
        IQueryable<ApontamentoCategoria> GetAll(bool active);

        bool Create(ApontamentoCategoriaInput input);
        bool Update(ApontamentoCategoriaInput input);
        bool Remove(long id);

    }
}
