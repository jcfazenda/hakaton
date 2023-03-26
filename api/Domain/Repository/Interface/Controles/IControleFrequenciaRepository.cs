using api.Domain.Models.Controles;
using api.Domain.Views.Input.Controles;
using System.Linq;

namespace api.Domain.Repository.Interface.Controles
{
    public interface IControleFrequenciaRepository : IRepository<ControleFrequencia, decimal>
    {
        IQueryable<ControleFrequencia> GetAll(bool active);
        bool UpdateStatus(long id);
        long Create(ControleFrequenciaInput input);
        long Update(ControleFrequenciaInput input);
        bool Remove(long id);

    }
}
