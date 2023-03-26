
using api.Domain.Models.Compliances;
using api.Domain.Repository.Interface.Compliances;
using api.Domain.Views.Input.Compliances;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace api.Domain.Repository.Queryable.Compliances
{
    public class ComplianceNormaTrechoRiscoRepository : Repository<ComplianceNormaTrechoRisco, decimal>, IComplianceNormaTrechoRiscoRepository
    {
        private readonly GRCContext _context;
        public ComplianceNormaTrechoRiscoRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<ComplianceNormaTrechoRisco> GetAny(bool active)
        {
            var data = DbSet.AsQueryable();

            return data;
        }

        public IQueryable<ComplianceNormaTrechoRisco> GetByNormaTrecho(long id)
        {
            var data = DbSet.Include(i => i.Riscos)
                            .Where(x => x.Id_Compliance_Norma_Trecho.Equals(id)).AsQueryable();

            return data;
        }

        public IQueryable<ComplianceNormaTrechoRisco> GetByNormaTrechoRisco(long idNormaTrecho, long idRisco)
        {
            var data = DbSet.Include(i => i.Riscos)
                            .Where(x => x.Id_Compliance_Norma_Trecho.Equals(idNormaTrecho) &&
                                        x.Id_Risco.Equals(idRisco)).AsQueryable();

            return data;
        }

        public long Create(ComplianceNormaTrechoRiscoInput input)
        {
            ComplianceNormaTrechoRisco data = new ComplianceNormaTrechoRisco
            {
                Id_Compliance_Norma_Trecho = input.Id_Compliance_Norma_Trecho,
                Id_Risco = input.Id_Risco, 
            };

            _context.Add(data);
            _context.SaveChanges();

            return data.Id_Compliance_Norma_Trecho;
        }
         
        public bool RemoveNormaTrechoRisco(long idNormaTrecho, long idRisco)
        {
            ComplianceNormaTrechoRisco data = DbSet.Where(x => x.Id_Compliance_Norma_Trecho.Equals(idNormaTrecho) &&
                                                               x.Id_Risco.Equals(idRisco)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }

        public bool Remove(long id)
        {
            ComplianceNormaTrechoRisco data = DbSet.Where(x => x.Id_Compliance_Norma_Trecho.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }


    }
}
