using api.Domain.Models.Processos;
using api.Domain.Views.Input.Processos;
using System.Linq;

namespace api.Domain.Repository.Interface.Processos
{
    public interface IProcessoEmpresaRepository : IRepository<ProcessoEmpresa, decimal>
    {
        IQueryable<ProcessoEmpresa> GetByProcesso(long id);
        IQueryable<ProcessoEmpresa> GetByEmpresa(long id);
        IQueryable<ProcessoEmpresa> GetByEmpresas(long id, bool Ativo);

        bool Create(ProcessoEmpresaInput input);
        bool Remove(long id);
        bool RemoveByProcesso(long idProcesso);

    }
}
