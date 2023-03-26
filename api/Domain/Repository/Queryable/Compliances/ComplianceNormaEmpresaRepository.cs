 
using api.Domain.Models.Compliances;
using api.Domain.Repository.Interface.Compliances;
using api.Domain.Views.Input.Compliances;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace api.Domain.Repository.Queryable.Compliances
{
    public class ComplianceNormaEmpresaRepository : Repository<ComplianceNormaEmpresa, decimal>, IComplianceNormaEmpresaRepository
    {
        private readonly GRCContext _context;
        public ComplianceNormaEmpresaRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<ComplianceNormaEmpresa> GetAny(bool active)
        {
            var data = DbSet.AsQueryable();

            return data;
        }

        public IQueryable<ComplianceNormaEmpresa> GetByNorma(long id)
        {
            var data = DbSet.Include(i => i.Empresa)
                            .Where(x => x.Id_Compliance_Norma.Equals(id)).AsQueryable();

            return data;
        }

        public IQueryable<ComplianceNormaEmpresa> GetByNormaComEmpresa(long idNorma, long idEmpresa)
        {
            var data = DbSet.Include(i => i.Empresa)
                            .Where(x => x.Id_Compliance_Norma.Equals(idNorma) &&
                                        x.Id_Empresa.Equals(idEmpresa)).AsQueryable();

            return data;
        }
          
        public bool UpdateStatus(long id)
        {
            ComplianceNormaEmpresa data = DbSet.Where(x => x.Id_Compliance_Norma_Empresa.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public long Create(ComplianceNormaEmpresaInput input)
        {
            ComplianceNormaEmpresa data = new ComplianceNormaEmpresa
            {
                Id_Compliance_Norma = input.Id_Compliance_Norma,
                Id_Empresa = input.Id_Empresa
            };

            _context.Add(data);
            _context.SaveChanges();

            return data.Id_Compliance_Norma_Empresa;
        }

        public long Update(ComplianceNormaEmpresaInput input)
        {
            ComplianceNormaEmpresa data = DbSet.Where(x => x.Id_Compliance_Norma_Empresa.Equals(input.Id_Compliance_Norma_Empresa)).AsQueryable().FirstOrDefault();

            data.Id_Compliance_Norma = input.Id_Compliance_Norma;
            data.Id_Empresa                      = input.Id_Empresa;

            _context.Update(data);
            _context.SaveChanges();

            return data.Id_Compliance_Norma_Empresa;
        }
        public bool Remove(long id)
        {
            ComplianceNormaEmpresa data = DbSet.Where(x => x.Id_Compliance_Norma_Empresa.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }
        public bool RemoveNormaComEmpresa(long idNorma, long idEmpresa)
        {
            ComplianceNormaEmpresa data = DbSet.Where(x => x.Id_Compliance_Norma.Equals(idNorma) &&
                                                           x.Id_Empresa.Equals(idEmpresa)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }

    }
}
