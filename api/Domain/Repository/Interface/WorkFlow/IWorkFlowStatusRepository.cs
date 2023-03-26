using api.Domain.Models.WorkFlow;
using api.Domain.Views.Input.WorkFlow;
using System.Linq;

namespace api.Domain.Repository.Interface.WorkFlow
{
    public interface IWorkFlowStatusRepository : IRepository<WorkFlowStatus, decimal>
    {
        IQueryable<WorkFlowStatus> GetAny(bool active); 

        bool UpdateStatus(long id);
        bool Create(WorkFlowStatusInput input);
        bool Update(WorkFlowStatusInput input);
        bool Remove(long id);

    }
}
