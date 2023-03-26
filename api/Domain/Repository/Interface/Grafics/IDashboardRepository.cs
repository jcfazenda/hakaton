using api.Domain.Models.Grafics;
using api.Domain.Views.Input.Grafics;
using System.Linq;

namespace api.Domain.Repository.Interface.Grafics
{
    public interface IDashboardRepository : IRepository<Dashboard, decimal>
    {
        IQueryable<Dashboard> GetAny(bool active);
        bool UpdateStatus(long id);
        bool Create(DashboardInput input);
        bool Update(DashboardInput input);
        bool Remove(long id);

    }
}
