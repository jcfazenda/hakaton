using api.Domain.Models.Processos;
using api.Domain.Views.Input.Processos;
using System.Linq;

namespace api.Domain.Repository.Interface.Processos
{
    public interface IProcessoRepository : IRepository<Processo, decimal>
    {
        IQueryable<Processo> GetAll(bool active);
        IQueryable<Processo> GetByProcessoByNivel(long idNivel);
        IQueryable<Processo> GetByProcessoByMinorNivel(long idNivel);
        bool UpdateStatus(long id);
        long Create(ProcessoInput input);
        bool Update(ProcessoInput input);
        bool Remove(long id);

    }
}
