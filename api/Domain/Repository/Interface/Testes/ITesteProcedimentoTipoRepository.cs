using api.Domain.Models.Testes;
using api.Domain.Views.Input.Testes;
using System.Linq;

namespace api.Domain.Repository.Interface.Testes
{
    public interface ITesteProcedimentoTipoRepository : IRepository<TesteProcedimentoTipo, decimal>
    {
        IQueryable<TesteProcedimentoTipo> GetAll(bool active);
        bool UpdateStatus(long id);
        bool Create(TesteProcedimentoTipoInput input);
        bool Update(TesteProcedimentoTipoInput input);
        bool Remove(long id);

    }
}
