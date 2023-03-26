using api.Domain.Models.Incidentes;
using api.Domain.Views.Input.Incidentes;
using System.Linq;

namespace api.Domain.Repository.Interface.Incidentes
{
    public interface IIncidenteFluxoAprovacaoRepository : IRepository<IncidenteFluxoAprovacao, decimal>
    {
        IQueryable<IncidenteFluxoAprovacao> GetAny(bool active);
        IQueryable<IncidenteFluxoAprovacao> GetByIncidente(long id);
        IQueryable<IncidenteFluxoAprovacao> GetByRiscoAvaliacaoIncidente(long idRiscoAvaliacao, long idIncidente);

        bool UpdateStatusworkFlow(IncidenteFluxoAprovacaoInput input);
        bool SaveObservacao(IncidenteFluxoAprovacaoInput input);

        long Create(IncidenteFluxoAprovacaoInput input);
        bool UpdateStatus(long id);


        bool Remove(long id);

    }
}
