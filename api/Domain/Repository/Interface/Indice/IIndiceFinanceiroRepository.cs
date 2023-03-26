using api.Domain.Models.Indice;
using api.Domain.Views.Input.Indice;
using System.Linq;

namespace api.Domain.Repository.Interface.Indice
{
    public interface IIndiceFinanceiroRepository : IRepository<IndiceFinanceiro, decimal>
    {
        IQueryable<IndiceFinanceiro> GetAll(bool active);
        bool UpdateStatus(long id);
        bool Create(IndiceFinanceiroInput input);
        bool Update(IndiceFinanceiroInput input);
        bool Remove(long id);

    }
}
