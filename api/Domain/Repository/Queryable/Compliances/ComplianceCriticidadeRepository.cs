
using api.Domain.Models.Compliances;
using api.Domain.Repository.Interface.Compliances;
using api.Domain.Views.Input.Compliances;
using System.Linq;

namespace api.Domain.Repository.Queryable.Compliances
{
    public class ComplianceCriticidadeRepository : Repository<ComplianceCriticidade, decimal>, IComplianceCriticidadeRepository
    {
        private readonly GRCContext _context;
        public ComplianceCriticidadeRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<ComplianceCriticidade> GetAny(bool active)
        {
            var data = DbSet.AsQueryable();

            return data;
        }
 

        public long Create(ComplianceCriticidadeInput input)
        {
            ComplianceCriticidade data = new ComplianceCriticidade
            {
                Compliance_Criticidade_Nome = input.Compliance_Criticidade_Nome
            };

            _context.Add(data);
            _context.SaveChanges();

            return data.Id_Compliance_Criticidade;
        }

        public long Update(ComplianceCriticidadeInput input)
        {
            ComplianceCriticidade data = DbSet.Where(x => x.Id_Compliance_Criticidade.Equals(input.Id_Compliance_Criticidade)).AsQueryable().FirstOrDefault();

            data.Compliance_Criticidade_Nome = input.Compliance_Criticidade_Nome;

            _context.Update(data);
            _context.SaveChanges();

            return data.Id_Compliance_Criticidade;
        }
        public bool Remove(long id)
        {
            ComplianceCriticidade data = DbSet.Where(x => x.Id_Compliance_Criticidade.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }

    }
}
