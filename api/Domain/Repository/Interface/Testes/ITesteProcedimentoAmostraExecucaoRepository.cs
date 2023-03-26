using api.Domain.Models.Testes;
using api.Domain.Views.Input.Testes;
using System.Linq;

namespace api.Domain.Repository.Interface.Testes
{
    public interface ITesteProcedimentoAmostraExecucaoRepository : IRepository<TesteProcedimentoAmostraExecucao, decimal>
    {
        IQueryable<TesteProcedimentoAmostraExecucao> GetAll(bool active);
        IQueryable<TesteProcedimentoAmostraExecucao> GetByProcedimentoAmostra(long id);

        long Create(TesteProcedimentoAmostraExecucaoInput input);
        bool Update(TesteProcedimentoAmostraExecucaoInput input);
        bool UpdateStatus(long id);
        bool UpdateStatusExecucao(long id);

        bool Remove(long id);
        bool RemoveByProcedimentoAmostra(long id);

    }
}
