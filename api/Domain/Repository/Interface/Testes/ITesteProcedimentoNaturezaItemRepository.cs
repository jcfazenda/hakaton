using api.Domain.Models.Testes;
using api.Domain.Views.Input.Testes;
using System.Linq;

namespace api.Domain.Repository.Interface.Testes
{
    public interface ITesteProcedimentoNaturezaItemRepository : IRepository<TesteProcedimentoNaturezaItem, decimal>
    {
        IQueryable<TesteProcedimentoNaturezaItem> GetAll(bool active);
        bool UpdateStatus(long id);
        long Create(TesteProcedimentoNaturezaItemInput input);
        bool Update(TesteProcedimentoNaturezaItemInput input);
        bool Remove(long id);

    }
}
