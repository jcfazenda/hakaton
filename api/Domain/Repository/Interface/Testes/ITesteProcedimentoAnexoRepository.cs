
using api.Domain.Models.Testes;
using api.Domain.Views.Input.Testes;
using System.Linq;

namespace api.Domain.Repository.Interface.Testes
{
    public interface ITesteProcedimentoAnexoRepository : IRepository<TesteProcedimentoAnexo, decimal>
    {
        IQueryable<TesteProcedimentoAnexo> GetByProcedimento(long id);
        IQueryable<TesteProcedimentoAnexo> GetAny(bool active);
        bool Create(TesteProcedimentoAnexoInput input);
        bool Remove(long id);

    }
}
