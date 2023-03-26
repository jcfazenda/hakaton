using api.Domain.Models.Risco;
using api.Domain.Repository.Interface.Risco;
using api.Domain.Views.Input.Risco;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace api.Domain.Repository.Queryable.Risco
{
    public class RiscoImpactoRepository : Repository<RiscoImpacto, decimal>, IRiscoImpactoRepository
    {
        private readonly GRCContext _context;
        public RiscoImpactoRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<RiscoImpacto> GetByRisco(long id)
        {
            var data = DbSet.Include(i => i.Impacto)
                            .Include(i => i.MatrizItem)
                            .Where(x => x.Id_Risco.Equals(id)).AsQueryable();

            return data;
        }

        public bool Create(RiscoImpactoInput input)
        {
            RiscoImpacto data = new RiscoImpacto
            {
                Id_Risco = input.Id_Risco,
                Id_Impacto = input.Id_Impacto,
                Id_Matriz_Item = input.Id_Matriz_Item,

                Fl_Ativo = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return true;
        }

        public bool SaveRiscoImpactoMatriz(RiscoImpactoInput input)
        {
            RiscoImpacto data = DbSet.Where(x => x.Id_Risco.Equals(input.Id_Risco) &&
                                               x.Id_Impacto.Equals(input.Id_Impacto)).AsQueryable().FirstOrDefault();


            data.Id_Matriz_Item = input.Id_Matriz_Item;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public bool Remove(long id)
        {
            RiscoImpacto data = DbSet.Where(x => x.Id_Risco_Impacto.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }


    }
}
