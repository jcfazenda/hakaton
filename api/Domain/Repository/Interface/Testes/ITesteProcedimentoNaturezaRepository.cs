using api.Domain.Models.Testes;
using api.Domain.Views.Input.Testes;
using System.Linq;

namespace api.Domain.Repository.Interface.Testes
{
    public interface ITesteProcedimentoNaturezaRepository : IRepository<TesteProcedimentoNatureza, decimal>
    {
        IQueryable<TesteProcedimentoNatureza> GetAll(bool active);
        IQueryable<TesteProcedimentoNatureza> GetByProcedimento(long id);
        bool UpdateStatus(long id);
        bool Create(TesteProcedimentoNaturezaInput input);
        bool Update(TesteProcedimentoNaturezaInput input);
        bool Remove(long id);
        bool RemoveByProcedimento(long id);

    }
}
