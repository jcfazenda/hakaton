using api.Domain.Models.Controles;
using api.Domain.Repository.Interface.Controles;
using api.Domain.Views.Input.Controles;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace api.Domain.Repository.Queryable.Controles
{
    public class ControleObjetivoControleRepository : Repository<ControleObjetivoControle, decimal>, IControleObjetivoControleRepository
    {
        private readonly GRCContext _context;
        public ControleObjetivoControleRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<ControleObjetivoControle> GetByControle(long id)
        {
            var data = DbSet.Include(i => i.ControleObjetivo).Where(x => x.Id_Controle.Equals(id)).AsQueryable();

            return data;
        }

        public bool Create(ControleObjetivoControleInput input)
        {
            ControleObjetivoControle data = new ControleObjetivoControle
            {
                Id_Controle = input.Id_Controle,
                Id_Controle_Objetivo = input.Id_Controle_Objetivo,
                Fl_Ativo = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return true;
        }

        public bool Remove(long id)
        {
            ControleObjetivoControle data = DbSet.Where(x => x.Id_Controle_Objetivo_Controle.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }


    }
}
