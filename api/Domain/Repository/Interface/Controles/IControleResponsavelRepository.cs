using api.Domain.Models.Controles;
using api.Domain.Views.Input.Controles;
using System.Linq;

namespace api.Domain.Repository.Interface.Controles
{
    public interface IControleResponsavelRepository : IRepository<ControleResponsavel, decimal>
    {
        IQueryable<ControleResponsavel> GetByControle(long id);
        bool Create(ControleResponsavelInput input);
        bool Remove(long id);

    }
}
