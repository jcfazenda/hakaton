using api.Domain.Models.Risco;
using api.Domain.Repository.Interface.Risco;
using api.Domain.Views.Input.Risco;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace api.Domain.Repository.Queryable.Risco
{
    public class RiscoFatorRepository : Repository<RiscoFator, decimal>, IRiscoFatorRepository
    {
        private readonly GRCContext _context;
        public RiscoFatorRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<RiscoFator> GetByRisco(long id)
        {
            var data = DbSet.Include(i => i.FatorRisco).Where(x => x.Id_Risco.Equals(id)).AsQueryable();

            return data;
        }

        public bool Create(RiscoFatorInput input)
        {
            RiscoFator data = new RiscoFator
            {
                Id_Risco = input.Id_Risco,
                Id_Fator_Risco = input.Id_Fator_Risco,
                Fl_Ativo = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return true;
        }

        public bool Remove(long id)
        {
            RiscoFator data = DbSet.Where(x => x.Id_Risco_Fator.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }


    }
}
