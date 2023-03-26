
using api.Domain.Models.Compliances;
using api.Domain.Repository.Interface.Compliances;
using api.Domain.Views.Input.Compliances;
using System.Linq;

namespace api.Domain.Repository.Queryable.Compliances
{
    public class ComplianceNormaTipoRepository : Repository<ComplianceNormaTipo, decimal>, IComplianceNormaTipoRepository
    {
        private readonly GRCContext _context;
        public ComplianceNormaTipoRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<ComplianceNormaTipo> GetAny(bool active)
        {
            var data = DbSet.AsQueryable();

            return data;
        }
        public bool UpdateStatus(long id)
        {
            ComplianceNormaTipo data = DbSet.Where(x => x.Id_Compliance_Norma_Tipo.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public long Create(ComplianceNormaTipoInput input)
        {
            ComplianceNormaTipo data = new ComplianceNormaTipo
            {
                Compliance_Norma_Tipo_Nome = input.Compliance_Norma_Tipo_Nome
            };

            _context.Add(data);
            _context.SaveChanges();

            return data.Id_Compliance_Norma_Tipo;
        }

        public long Update(ComplianceNormaTipoInput input)
        {
            ComplianceNormaTipo data = DbSet.Where(x => x.Id_Compliance_Norma_Tipo.Equals(input.Id_Compliance_Norma_Tipo)).AsQueryable().FirstOrDefault();

            data.Compliance_Norma_Tipo_Nome = input.Compliance_Norma_Tipo_Nome; 

            _context.Update(data);
            _context.SaveChanges();

            return data.Id_Compliance_Norma_Tipo;
        }
        public bool Remove(long id)
        {
            ComplianceNormaTipo data = DbSet.Where(x => x.Id_Compliance_Norma_Tipo.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }

    }
}
