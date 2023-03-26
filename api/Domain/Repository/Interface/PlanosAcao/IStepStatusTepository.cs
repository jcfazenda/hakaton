using api.Domain.Models.PlanosAcao;
using api.Domain.Views.Input.PlanosAcao;
using System.Linq;

namespace api.Domain.Repository.Interface.PlanosAcao
{
    public interface IStepStatusRepository : IRepository<StepStatus, decimal>
    {
        IQueryable<StepStatus> GetAll(bool active);
        bool UpdateStatus(long id);

        bool Create(StepStatusInput input);
        bool Update(StepStatusInput input);
        bool Remove(long id);

    }
}
