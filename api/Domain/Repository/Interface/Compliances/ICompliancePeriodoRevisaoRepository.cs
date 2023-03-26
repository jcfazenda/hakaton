using api.Domain.Models.Compliances;
using api.Domain.Views.Input.Compliances;
using System.Linq;

namespace api.Domain.Repository.Interface.Compliances
{

    public interface ICompliancePeriodoRevisaoRepository : IRepository<CompliancePeriodoRevisao, decimal>
    {
        IQueryable<CompliancePeriodoRevisao> GetAny(bool active); 
        long Create(CompliancePeriodoRevisaoInput input);
        long Update(CompliancePeriodoRevisaoInput input);
        bool Remove(long id);
    }

}
