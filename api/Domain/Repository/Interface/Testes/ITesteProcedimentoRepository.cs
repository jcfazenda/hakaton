using api.Domain.Models.Testes;
using api.Domain.Views.Input.Testes;
using System.Linq;

namespace api.Domain.Repository.Interface.Testes
{
    public interface ITesteProcedimentoRepository : IRepository<TesteProcedimento, decimal>
    {
        IQueryable<TesteProcedimento> GetAll(bool active);
        IQueryable<TesteProcedimento> GetByTeste(long id);

        bool UpdateStatus(long id);
        long Create(TesteProcedimentoInput input);
        bool Update(TesteProcedimentoInput input);
        bool Remove(long id);

    }
}
