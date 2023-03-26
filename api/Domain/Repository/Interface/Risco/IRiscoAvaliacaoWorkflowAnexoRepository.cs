using api.Domain.Models.Risco;
using api.Domain.Views.Input.Risco;
using System.Linq;

namespace api.Domain.Repository.Interface.Risco
{
    public interface IRiscoAvaliacaoWorkflowAnexoRepository : IRepository<RiscoAvaliacaoWorkflowAnexo, decimal>
    {
        IQueryable<RiscoAvaliacaoWorkflowAnexo> GetAny(bool active);
        IQueryable<RiscoAvaliacaoWorkflowAnexo> GetByRiscoAvaliacaoWorkflow(long id);
        bool UpdateStatus(long id);

        bool Create(RiscoAvaliacaoWorkflowAnexoInput input);
        bool Update(RiscoAvaliacaoWorkflowAnexoInput input);
        bool Remove(long id);

    }
}
