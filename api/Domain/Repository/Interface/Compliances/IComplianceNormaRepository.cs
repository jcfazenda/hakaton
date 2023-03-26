using api.Domain.Models.Compliances;
using api.Domain.Views.Input.Compliances;
using System.Linq;

namespace api.Domain.Repository.Interface.Compliances
{


    public interface IComplianceNormaRepository : IRepository<ComplianceNorma, decimal>
    {
        IQueryable<ComplianceNorma> GetAny(bool active);
        bool UpdateStatus(long id);
        long Create(ComplianceNormaInput input);
        long Update(ComplianceNormaInput input);
        bool Remove(long id);
    }

}
