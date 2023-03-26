using api.Domain.Models.Risco;
using api.Domain.Repository.Interface.Risco;
using api.Domain.Views.Input.Risco;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace api.Domain.Repository.Queryable.Risco
{
    public class RiscoIncidenteRepository : Repository<RiscoIncidente, decimal>, IRiscoIncidenteRepository
    {
        private readonly GRCContext _context;
        public RiscoIncidenteRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<RiscoIncidente> GetByRisco(long id)
        {
            var data = DbSet.Include(i => i.Incidente).Where(x => x.Id_Risco.Equals(id)).AsQueryable();

            return data;
        }

        public IQueryable<RiscoIncidente> GetByIncidente(long id)
        {
            var data = DbSet.Include(i => i.Riscos).Where(x => x.Id_Incidente.Equals(id)).AsQueryable();

            return data;
        } 

        public bool Create(RiscoIncidenteInput input)
        {
            RiscoIncidente data = new RiscoIncidente
            {
                Id_Risco = input.Id_Risco,
                Id_Incidente = input.Id_Incidente,
                Fl_Ativo = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return true;
        }

        public bool Remove(long id)
        {
            RiscoIncidente data = DbSet.Where(x => x.Id_Risco_Incidente.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }


    }
}
