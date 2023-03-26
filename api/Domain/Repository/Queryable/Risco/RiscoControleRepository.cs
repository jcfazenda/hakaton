using api.Domain.Models.Risco;
using api.Domain.Repository.Interface.Risco;
using api.Domain.Views.Input.Risco;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace api.Domain.Repository.Queryable.Risco
{
    public class RiscoControleRepository : Repository<RiscoControle, decimal>, IRiscoControleRepository
    {
        private readonly GRCContext _context;
        public RiscoControleRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<RiscoControle> GetByRisco(long id)
        {
            var data = DbSet.Include(i => i.Controle).Where(x => x.Id_Risco.Equals(id)).AsQueryable();

            return data;
        }
  
        public bool Create(RiscoControleInput input)
        {
            RiscoControle data = new RiscoControle
            {
                Id_Risco = input.Id_Risco,
                Id_Controle = input.Id_Controle, 
                Fl_Ativo = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return true;
        }
 
        public bool Remove(long id)
        {
            RiscoControle data = DbSet.Where(x => x.Id_Risco_Controle.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }


    }
}
