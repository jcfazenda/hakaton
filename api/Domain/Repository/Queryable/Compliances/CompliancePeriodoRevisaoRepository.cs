
using api.Domain.Models.Compliances;
using api.Domain.Repository.Interface.Compliances;
using api.Domain.Views.Input.Compliances;
using System.Linq;

namespace api.Domain.Repository.Queryable.Compliances
{
    public class CompliancePeriodoRevisaoRepository : Repository<CompliancePeriodoRevisao, decimal>, ICompliancePeriodoRevisaoRepository
    {
        private readonly GRCContext _context;
        public CompliancePeriodoRevisaoRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<CompliancePeriodoRevisao> GetAny(bool active)
        {
            var data = DbSet.AsQueryable();

            return data;
        }
 

        public long Create(CompliancePeriodoRevisaoInput input)
        {
            CompliancePeriodoRevisao data = new CompliancePeriodoRevisao
            {
                Compliance_Periodo_Revisao_Nome = input.Compliance_Periodo_Revisao_Nome
            };

            _context.Add(data);
            _context.SaveChanges();

            return data.Id_Compliance_Periodo_Revisao;
        }

        public long Update(CompliancePeriodoRevisaoInput input)
        {
            CompliancePeriodoRevisao data = DbSet.Where(x => x.Id_Compliance_Periodo_Revisao.Equals(input.Id_Compliance_Periodo_Revisao)).AsQueryable().FirstOrDefault();

            data.Compliance_Periodo_Revisao_Nome = input.Compliance_Periodo_Revisao_Nome;

            _context.Update(data);
            _context.SaveChanges();

            return data.Id_Compliance_Periodo_Revisao;
        }
        public bool Remove(long id)
        {
            CompliancePeriodoRevisao data = DbSet.Where(x => x.Id_Compliance_Periodo_Revisao.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }

    }
}
