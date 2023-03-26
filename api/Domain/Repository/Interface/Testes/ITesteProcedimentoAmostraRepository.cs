using api.Domain.Models.Testes;
using api.Domain.Views.Input.Testes;
using System.Linq;

namespace api.Domain.Repository.Interface.Testes
{
    public interface ITesteProcedimentoAmostraRepository : IRepository<TesteProcedimentoAmostra, decimal>
    {
        IQueryable<TesteProcedimentoAmostra> GetAll(bool active);
        IQueryable<TesteProcedimentoAmostra> GetByProcedimento(long id);

        bool UpdateStatus(long id);
        bool Create(TesteProcedimentoAmostraInput input);
        bool Update(TesteProcedimentoAmostraInput input);

        bool Remove(long id);
        bool RemoveByProcedimento(long id);

    }
}
