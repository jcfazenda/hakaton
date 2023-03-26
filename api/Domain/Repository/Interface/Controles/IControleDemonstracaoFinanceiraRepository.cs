using api.Domain.Models.Controles;
using api.Domain.Views.Input.Controles;
using System.Linq;

namespace api.Domain.Repository.Interface.Controles
{
    public interface IControleDemonstracaoFinanceiraRepository : IRepository<ControleDemonstracaoFinanceira, decimal>
    {
        IQueryable<ControleDemonstracaoFinanceira> GetAll(bool active);
        bool UpdateStatus(long id);
        long Create(ControleDemonstracaoFinanceiraInput input);
        long Update(ControleDemonstracaoFinanceiraInput input);
        bool Remove(long id);

    }
}
