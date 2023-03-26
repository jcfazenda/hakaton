using api.Domain.Models.Processos;
using api.Domain.Views.Input.Processos;
using System.Linq;

namespace api.Domain.Repository.Interface.Processos
{
    public interface IProcessoUnidadeOrganizacionalRepository : IRepository<ProcessoUnidadeOrganizacional, decimal>
    {
        IQueryable<ProcessoUnidadeOrganizacional> GetByProcesso(long id);

        bool Create(ProcessoUnidadeOrganizacionalInput input);
        bool Remove(long id);

    }
}
