using api.Domain.Models.Processos;
using api.Domain.Views.Input.Processos;
using System.Linq;

namespace api.Domain.Repository.Interface.Processos
{
    public interface IProcessoAnexoRepository : IRepository<ProcessoAnexo, decimal>
    {
        IQueryable<ProcessoAnexo> GetByProcesso(long id);

        bool Create(ProcessoAnexoInput input);
        bool Remove(long id); 

    }
}
