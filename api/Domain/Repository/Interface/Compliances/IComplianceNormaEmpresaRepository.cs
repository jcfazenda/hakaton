using api.Domain.Models.Compliances;
using api.Domain.Views.Input.Compliances;
using System.Linq;

namespace api.Domain.Repository.Interface.Compliances
{

    public interface IComplianceNormaEmpresaRepository : IRepository<ComplianceNormaEmpresa, decimal>
    {
        IQueryable<ComplianceNormaEmpresa> GetAny(bool active);
        IQueryable<ComplianceNormaEmpresa> GetByNorma(long id); 
        IQueryable<ComplianceNormaEmpresa> GetByNormaComEmpresa(long idNorma, long idEmpresa);

        bool UpdateStatus(long id);
        long Create(ComplianceNormaEmpresaInput input);
        long Update(ComplianceNormaEmpresaInput input);
        bool Remove(long id);
        bool RemoveNormaComEmpresa(long idNorma, long idEmpresa);
    }

}
