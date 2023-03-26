using api.Domain.Models.Processos;
using api.Domain.Views.Input.Processos;
using System.Linq;

namespace api.Domain.Repository.Interface.Processos
{
    public interface IProcessoResponsavelRepository : IRepository<ProcessoResponsavel, decimal>
    {
        IQueryable<ProcessoResponsavel> GetByProcesso(long id);
        IQueryable<ProcessoResponsavel> GetByProcessoResponsavel(long idProcesso, long idUsuario);

        bool Create(ProcessoResponsavelInput input);
        bool Remove(long id);
        bool RemoveByProcessoResponsavel(long idProcesso, long idUsuario);

    }
}
