using api.Domain.Models.Risco;
using api.Domain.Repository.Interface.Risco;
using api.Domain.Views.Input.Risco;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace api.Domain.Repository.Queryable.Risco
{
    public class RiscoCategoriaRepository : Repository<RiscoCategoria, decimal>, IRiscoCategoriaRepository
    {
        private readonly GRCContext _context;
        public RiscoCategoriaRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<RiscoCategoria> GetByRisco(long id)
        {
            var data = DbSet.Include(i => i.CategoriaRisco).Where(x => x.Id_Risco.Equals(id)).AsQueryable();

            return data;
        }

        public bool Create(RiscoCategoriaInput input)
        {
            RiscoCategoria data = new RiscoCategoria
            {
                Id_Risco = input.Id_Risco,
                Id_Categoria_Risco = input.Id_Categoria_Risco,
                Fl_Ativo = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return true;
        }

        public bool Remove(long id)
        {
            RiscoCategoria data = DbSet.Where(x => x.Id_Risco_Categoria.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }


    }
}
