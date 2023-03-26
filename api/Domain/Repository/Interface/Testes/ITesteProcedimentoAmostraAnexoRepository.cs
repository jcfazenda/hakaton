
using api.Domain.Models.Testes;
using api.Domain.Views.Input.Testes;
using System.Linq;

namespace api.Domain.Repository.Interface.Testes
{
    public interface ITesteProcedimentoAmostraAnexoRepository : IRepository<TesteProcedimentoAmostraAnexo, decimal>
    {
        IQueryable<TesteProcedimentoAmostraAnexo> GetByProcedimento(long id);
        IQueryable<TesteProcedimentoAmostraAnexo> GetAny(bool active);
        bool Create(TesteProcedimentoAmostraAnexoInput input);
        bool RemoveByProcedimento(long id);
        bool Remove(long id);

    }
}
