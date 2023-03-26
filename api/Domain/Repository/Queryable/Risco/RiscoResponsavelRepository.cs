using api.Domain.Models.Risco;
using api.Domain.Repository.Interface.Risco;
using api.Domain.Views.Input.Risco;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace api.Domain.Repository.Queryable.Risco
{
    public class RiscoResponsavelRepository : Repository<RiscoResponsavel, decimal>, IRiscoResponsavelRepository
    {
        private readonly GRCContext _context;
        public RiscoResponsavelRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<RiscoResponsavel> GetByRisco(long id)
        {
            var data = DbSet.Include(i => i.Usuarios).Where(x => x.Id_Risco.Equals(id)).AsQueryable();

            return data;
        }

        public bool Create(RiscoResponsavelInput input)
        {
            RiscoResponsavel data = new RiscoResponsavel
            {
                Id_Risco = input.Id_Risco,
                Id_Usuario = input.Id_Usuario,
                Fl_Ativo = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return true;
        }

        public bool Remove(long id)
        {
            RiscoResponsavel data = DbSet.Where(x => x.Id_Risco_Responsavel.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }


    }
}
