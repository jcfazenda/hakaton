using api.Domain.Models.Processos;
using api.Domain.Views.Input.Processos;
using System.Linq;

namespace api.Domain.Repository.Interface.Processos
{
    public interface IProcessoNivelRepository : IRepository<ProcessoNivel, decimal>
    {
        IQueryable<ProcessoNivel> GetAny(bool active);
        bool UpdateStatus(long id);
        long Create(ProcessoNivelInput input);
        long Update(ProcessoNivelInput input);
        bool Remove(long id);

    }
}
