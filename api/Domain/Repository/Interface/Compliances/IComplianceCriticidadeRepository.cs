using api.Domain.Models.Compliances;
using api.Domain.Views.Input.Compliances;
using System.Linq;

namespace api.Domain.Repository.Interface.Compliances
{

    public interface IComplianceCriticidadeRepository : IRepository<ComplianceCriticidade, decimal>
    {
        IQueryable<ComplianceCriticidade> GetAny(bool active); 
        long Create(ComplianceCriticidadeInput input);
        long Update(ComplianceCriticidadeInput input);
        bool Remove(long id);
    }

}
