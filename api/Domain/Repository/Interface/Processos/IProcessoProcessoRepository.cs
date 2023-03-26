using api.Domain.Models.Processos;
using api.Domain.Views.Input.Processos;
using System.Linq;

namespace api.Domain.Repository.Interface.Processos
{
    public interface IProcessoProcessoRepository : IRepository<ProcessoProcesso, decimal>
    {
        IQueryable<ProcessoProcesso> GetByProcesso(long id); 

        bool Create(ProcessoProcessoInput input);
        bool Remove(long id); 

    }
}
