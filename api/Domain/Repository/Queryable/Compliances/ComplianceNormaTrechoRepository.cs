
using api.Domain.Models.Compliances;
using api.Domain.Repository.Interface.Compliances;
using api.Domain.Views.Input.Compliances;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace api.Domain.Repository.Queryable.Compliances
{
    public class ComplianceNormaTrechoRepository : Repository<ComplianceNormaTrecho, decimal>, IComplianceNormaTrechoRepository
    {
        private readonly GRCContext _context;
        public ComplianceNormaTrechoRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<ComplianceNormaTrecho> GetAny(bool active)
        {
            var data = DbSet.AsQueryable();

            return data;
        }

        public IQueryable<ComplianceNormaTrecho> GetByNorma(long id)
        {
            var data = DbSet.Include(i => i.ComplianceNorma)
                            .Where(x => x.Id_Compliance_Norma.Equals(id)).AsQueryable(); 

            return data;
        }


        public bool UpdateStatus(long id)
        {
            ComplianceNormaTrecho data = DbSet.Where(x => x.Id_Compliance_Norma_Trecho.Equals(id)).AsQueryable().FirstOrDefault();

            data.Fl_Ativo = data.Fl_Ativo == true ? false : true;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public long Create(ComplianceNormaTrechoInput input)
        {
            ComplianceNormaTrecho data = new ComplianceNormaTrecho
            {
                Id_Compliance_Norma                 = input.Id_Compliance_Norma,
                Compliance_Norma_Trecho_Nome        = input.Compliance_Norma_Trecho_Nome,
                Compliance_Norma_Trecho_Descricao   = input.Compliance_Norma_Trecho_Descricao,
                Fl_Ativo =true
            };

            _context.Add(data);
            _context.SaveChanges();

            return data.Id_Compliance_Norma_Trecho;
        }

        public long Update(ComplianceNormaTrechoInput input)
        {
            ComplianceNormaTrecho data = DbSet.Where(x => x.Id_Compliance_Norma_Trecho.Equals(input.Id_Compliance_Norma_Trecho)).AsQueryable().FirstOrDefault();

            data.Id_Compliance_Norma                = input.Id_Compliance_Norma;
            data.Compliance_Norma_Trecho_Nome       = input.Compliance_Norma_Trecho_Nome;
            data.Compliance_Norma_Trecho_Descricao  = input.Compliance_Norma_Trecho_Descricao;
            data.Fl_Ativo                           = input.Fl_Ativo;
                
            _context.Update(data);
            _context.SaveChanges();

            return data.Id_Compliance_Norma_Trecho;
        }
        public bool Remove(long id)
        {
            ComplianceNormaTrecho data = DbSet.Where(x => x.Id_Compliance_Norma_Trecho.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }

    }
}
