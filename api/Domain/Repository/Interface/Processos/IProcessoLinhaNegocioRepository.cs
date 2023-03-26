using api.Domain.Models.Processos;
using api.Domain.Views.Input.Processos;
using System.Linq;

namespace api.Domain.Repository.Interface.Processos
{
    public interface IProcessoLinhaNegocioRepository : IRepository<ProcessoLinhaNegocio, decimal>
    {
        IQueryable<ProcessoLinhaNegocio> GetByProcesso(long id); 

        bool Create(ProcessoLinhaNegocioInput input);
        bool Remove(long id);
        bool RemoveByProcesso(long idProcesso);

    }
}
