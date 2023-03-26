using api.Domain.Models.Risco;
using api.Domain.Views.Input.Risco;
using System.Linq;

namespace api.Domain.Repository.Interface.Risco
{
    public interface IRiscoAvaliacaoWorkflowRepository : IRepository<RiscoAvaliacaoWorkflow, decimal>
    {
        IQueryable<RiscoAvaliacaoWorkflow> GetAny(bool active);
        IQueryable<RiscoAvaliacaoWorkflow> GetByRiscoAvaliacao(long id);
        bool UpdateStatus(long id);

        long Create(RiscoAvaliacaoWorkflowInput input);
        bool Update(RiscoAvaliacaoWorkflowInput input);
        bool Remove(long id);

    }
}
