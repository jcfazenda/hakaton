using api.Domain.Models.Processos;
using api.Domain.Views.Input.Processos;
using System.Linq;

namespace api.Domain.Repository.Interface.Processos
{
    public interface IProcessoRiscoRepository : IRepository<ProcessoRisco, decimal>
    {
        IQueryable<ProcessoRisco> GetByProcesso(long id);
        IQueryable<ProcessoRisco> GetByProcessoRisco(long idProcesso, long idRisco);

        bool Create(ProcessoRiscoInput input); 
        bool Remove(long id);
        bool RemoveByProcessoRisco(long idProcesso, long idRisco);

    }
}
