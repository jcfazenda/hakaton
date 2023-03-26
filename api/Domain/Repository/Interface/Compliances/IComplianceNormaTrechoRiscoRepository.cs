using api.Domain.Models.Compliances;
using api.Domain.Views.Input.Compliances;
using System.Linq;

namespace api.Domain.Repository.Interface.Compliances
{


    public interface IComplianceNormaTrechoRiscoRepository : IRepository<ComplianceNormaTrechoRisco, decimal>
    {
        IQueryable<ComplianceNormaTrechoRisco> GetAny(bool active);
        IQueryable<ComplianceNormaTrechoRisco> GetByNormaTrecho(long id);
        IQueryable<ComplianceNormaTrechoRisco> GetByNormaTrechoRisco(long idNormaTrecho, long idRisco);

        long Create(ComplianceNormaTrechoRiscoInput input); 
        bool Remove(long id);
        bool RemoveNormaTrechoRisco(long idNormaTrecho, long idRisco);
    }

}
