using api.Domain.Models.Compliances;
using api.Domain.Views.Input.Compliances;
using System.Linq;

namespace api.Domain.Repository.Interface.Compliances
{

    public interface IComplianceNormaEmpresaContraparteRepository : IRepository<ComplianceNormaEmpresaContraparte, decimal>
    {
        IQueryable<ComplianceNormaEmpresaContraparte> GetAny(bool active);
        IQueryable<ComplianceNormaEmpresaContraparte> GetByNormaEmpresa(long id);
        IQueryable<ComplianceNormaEmpresaContraparte> GetByEmpresaComNormaEmpresa(long idNormaEmpresa, long idEmpresa);


        bool UpdateStatus(long id);
        long Create(ComplianceNormaEmpresaContraparteInput input);
        long Update(ComplianceNormaEmpresaContraparteInput input);
        bool Remove(long id);
        bool RemoveEmpresaComNormaEmpresa(long idNormaEmpresa, long idEmpresa);
    }

}
