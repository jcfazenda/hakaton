using api.Domain.Models.Risco;
using api.Domain.Repository.Interface.Risco;
using api.Domain.Views.Input.Risco;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace api.Domain.Repository.Queryable.Risco
{
    public class RiscoRiscoRepository : Repository<RiscoRisco, decimal>, IRiscoRiscoRepository
    {
        private readonly GRCContext _context;
        public RiscoRiscoRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<RiscoRisco> GetByRisco(long id)
        {
            var data = DbSet.Include(i => i.Riscos).Where(x => x.Id_Risco.Equals(id)).AsQueryable();

            return data;
        }

        public bool Create(RiscoRiscoInput input)
        {
            RiscoRisco data = new RiscoRisco
            {
                Id_Risco = input.Id_Risco,
                Id_Risco_Relacionado = input.Id_Risco_Relacionado,
                Fl_Ativo = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return true;
        }

        public bool Remove(long id)
        {
            RiscoRisco data = DbSet.Where(x => x.Id_Risco_Risco.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }


    }
}
