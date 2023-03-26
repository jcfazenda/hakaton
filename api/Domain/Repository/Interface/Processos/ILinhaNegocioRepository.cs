using api.Domain.Models.Processos;
using api.Domain.Views.Input.Processos;
using System.Linq;

namespace api.Domain.Repository.Interface.Processos
{
    public interface ILinhaNegocioRepository : IRepository<LinhaNegocio, decimal>
    {
        IQueryable<LinhaNegocio> GetAll(bool active);
        bool UpdateStatus(long id);
        long Create(LinhaNegocioInput input);
        bool Update(LinhaNegocioInput input);
        bool Remove(long id);

    }
}
