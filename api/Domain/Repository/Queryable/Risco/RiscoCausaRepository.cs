using api.Domain.Models.Risco;
using api.Domain.Repository.Interface.Risco;
using api.Domain.Views.Input.Risco;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace api.Domain.Repository.Queryable.Risco
{
    public class RiscoCausaRepository : Repository<RiscoCausa, decimal>, IRiscoCausaRepository
    {
        private readonly GRCContext _context;
        public RiscoCausaRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<RiscoCausa> GetByRisco(long id)
        {
            var data = DbSet.Include(i => i.Causas)
                            .Include(i => i.MatrizItem)
                            .Where(x => x.Id_Risco.Equals(id)).AsQueryable();

            return data;
        }

        public bool Create(RiscoCausaInput input)
        {
            RiscoCausa data = new RiscoCausa
            {
                Id_Risco = input.Id_Risco,
                Id_Causa = input.Id_Causa,
                Id_Matriz_Item = input.Id_Matriz_Item,
                Fl_Ativo = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return true;
        }

        public bool SaveRiscoCausaMatriz(RiscoCausaInput input)
        {
            RiscoCausa data = DbSet.Where(x => x.Id_Risco.Equals(input.Id_Risco) &&
                                               x.Id_Causa.Equals(input.Id_Causa)).AsQueryable().FirstOrDefault();


            data.Id_Matriz_Item = input.Id_Matriz_Item;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }


        public bool Remove(long id)
        {
            RiscoCausa data = DbSet.Where(x => x.Id_Risco_Causa.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }


    }
}
