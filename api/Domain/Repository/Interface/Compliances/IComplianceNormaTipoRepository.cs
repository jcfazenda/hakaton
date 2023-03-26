using api.Domain.Models.Compliances;
using api.Domain.Views.Input.Compliances;
using System.Linq;

namespace api.Domain.Repository.Interface.Compliances
{

    public interface IComplianceNormaTipoRepository : IRepository<ComplianceNormaTipo, decimal>
    {
        IQueryable<ComplianceNormaTipo> GetAny(bool active);
        bool UpdateStatus(long id);
        long Create(ComplianceNormaTipoInput input);
        long Update(ComplianceNormaTipoInput input);
        bool Remove(long id);
    }

}
