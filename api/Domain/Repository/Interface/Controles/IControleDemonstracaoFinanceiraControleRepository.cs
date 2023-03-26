 
using api.Domain.Models.Controles;
using api.Domain.Views.Input.Controles;
using System.Linq;

namespace api.Domain.Repository.Interface.Controles
{
    public interface IControleDemonstracaoFinanceiraControleRepository : IRepository<ControleDemonstracaoFinanceiraControle, decimal>
    {
        IQueryable<ControleDemonstracaoFinanceiraControle> GetByControle(long id);
        bool Create(ControleDemonstracaoFinanceiraControleInput input);
        bool Remove(long id);

    }
}
