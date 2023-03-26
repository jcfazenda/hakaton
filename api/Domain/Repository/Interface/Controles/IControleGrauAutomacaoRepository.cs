using api.Domain.Models.Controles;
using api.Domain.Views.Input.Controles;
using System.Linq;

namespace api.Domain.Repository.Interface.Controles
{
    public interface IControleGrauAutomacaoRepository : IRepository<ControleGrauAutomacao, decimal>
    {
        IQueryable<ControleGrauAutomacao> GetAll(bool active);
        bool UpdateStatus(long id);
        long Create(ControleGrauAutomacaoInput input);
        long Update(ControleGrauAutomacaoInput input);
        bool Remove(long id);

    }
}
