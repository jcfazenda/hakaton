using api.Domain.Models.Testes;
using api.Domain.Views.Input.Testes;
using System.Linq;

namespace api.Domain.Repository.Interface.Testes
{
    public interface ITesteRepository : IRepository<Teste, decimal>
    {
        IQueryable<Teste> GetAll(bool active);
        IQueryable<Teste> GetActive(bool active);

        bool UpdateStatusWorkflow(TesteInput input); 
        bool UpdateExclusivo(long id);

        bool UpdateStatus(long id);
        long Create(TesteInput input);
        bool Update(TesteInput input);
        bool Remove(long id);

    }
}
