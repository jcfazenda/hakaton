using api.Domain.Models.Compliances;
using api.Domain.Repository.Interface.Compliances;
using api.Domain.Views.Input.Compliances;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace api.Domain.Repository.Queryable.Compliances
{
    public class ComplianceNormaEmpresaContraparteRepository : Repository<ComplianceNormaEmpresaContraparte, decimal>, IComplianceNormaEmpresaContraparteRepository
    {
        private readonly GRCContext _context;
        public ComplianceNormaEmpresaContraparteRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<ComplianceNormaEmpresaContraparte> GetAny(bool active)
        {
            var data = DbSet.AsQueryable();

            return data;
        }
        public bool UpdateStatus(long id)
        {
            ComplianceNormaEmpresaContraparte data = DbSet.Where(x => x.Id_Compliance_Norma_Empresa_Contraparte.Equals(id)).AsQueryable().FirstOrDefault(); 

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public IQueryable<ComplianceNormaEmpresaContraparte> GetByNormaEmpresa(long id)
        {
            var data = DbSet.Include(i => i.Empresa)
                            .Where(x => x.Id_Compliance_Norma_Empresa.Equals(id)).AsQueryable();

            return data;
        }

        public IQueryable<ComplianceNormaEmpresaContraparte> GetByEmpresaComNormaEmpresa(long idNormaEmpresa, long idEmpresa)
        {
            var data = DbSet.Include(i => i.Empresa)
                            .Where(x => x.Id_Compliance_Norma_Empresa.Equals(idNormaEmpresa) &&
                                        x.Id_Empresa.Equals(idEmpresa)).AsQueryable();

            return data;
        }



        public long Create(ComplianceNormaEmpresaContraparteInput input)
        {
            ComplianceNormaEmpresaContraparte data = new ComplianceNormaEmpresaContraparte
            {
                Id_Compliance_Norma_Empresa = input.Id_Compliance_Norma_Empresa,
                Id_Empresa          = input.Id_Empresa
            };

            _context.Add(data);
            _context.SaveChanges();

            return data.Id_Compliance_Norma_Empresa_Contraparte;
        }

        public long Update(ComplianceNormaEmpresaContraparteInput input)
        {
            ComplianceNormaEmpresaContraparte data = DbSet.Where(x => x.Id_Compliance_Norma_Empresa_Contraparte.Equals(input.Id_Compliance_Norma_Empresa_Contraparte)).AsQueryable().FirstOrDefault();

            data.Id_Compliance_Norma_Empresa = input.Id_Compliance_Norma_Empresa;
            data.Id_Empresa = input.Id_Empresa;

            _context.Update(data);
            _context.SaveChanges();

            return data.Id_Compliance_Norma_Empresa_Contraparte;
        }
        public bool Remove(long id)
        {
            ComplianceNormaEmpresaContraparte data = DbSet.Where(x => x.Id_Compliance_Norma_Empresa_Contraparte.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }
        public bool RemoveEmpresaComNormaEmpresa(long idNormaEmpresa, long idEmpresa)
        {
            ComplianceNormaEmpresaContraparte data = DbSet.Where(x => x.Id_Compliance_Norma_Empresa.Equals(idNormaEmpresa) &&
                                                                      x.Id_Empresa.Equals(idEmpresa)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }


    }
}
