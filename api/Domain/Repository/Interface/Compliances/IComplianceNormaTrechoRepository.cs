using api.Domain.Models.Compliances;
using api.Domain.Views.Input.Compliances;
using System.Linq;

namespace api.Domain.Repository.Interface.Compliances
{


    public interface IComplianceNormaTrechoRepository : IRepository<ComplianceNormaTrecho, decimal>
    {
        IQueryable<ComplianceNormaTrecho> GetAny(bool active);
        IQueryable<ComplianceNormaTrecho> GetByNorma(long id);

        bool UpdateStatus(long id);
        long Create(ComplianceNormaTrechoInput input);
        long Update(ComplianceNormaTrechoInput input);
        bool Remove(long id);
    }

}
