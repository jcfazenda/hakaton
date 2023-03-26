using api.Domain.Models.Testes;
using api.Domain.Views.Input.Testes;
using System.Linq;

namespace api.Domain.Repository.Interface.Testes
{
    public interface ITesteProcedimentoAmostraExecucaoAtributoRepository : IRepository<TesteProcedimentoAmostraExecucaoAtributo, decimal>
    {
        IQueryable<TesteProcedimentoAmostraExecucaoAtributo> GetAll(bool active);
        IQueryable<TesteProcedimentoAmostraExecucaoAtributo> GetByProcedimentoAmostraExecucao(long id);
        IQueryable<TesteProcedimentoAmostraExecucaoAtributo> GetByProcedimentoAmostraExecucaoAtributo(long id);

        bool Create(TesteProcedimentoAmostraExecucaoAtributoInput input);
        bool Update(TesteProcedimentoAmostraExecucaoAtributoInput input);
        bool UpdateStatus(long id);
        bool UpdateStatusExecucaoAtributo(long id);

        bool Remove(long id);
        bool RemoveByProcedimentoAmostra(TesteProcedimentoAmostraExecucaoAtributoInput inpu);
        bool RemoveByProcedimentoAmostraExecucao(long id);

    }
}
