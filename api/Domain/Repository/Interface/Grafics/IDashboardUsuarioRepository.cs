using api.Domain.Models.Grafics;
using api.Domain.Views.Input.Grafics;
using System.Linq;

namespace api.Domain.Repository.Interface.Grafics
{
    public interface IDashboardUsuarioRepository : IRepository<DashboardUsuario, decimal>
    {
        IQueryable<DashboardUsuario> GetByUsuario(long id); 
        bool Create(DashboardUsuarioInput input); 
        bool Remove(long id);
        bool RemoveBy(long idDashboard, long idUsuario);

    }
}
