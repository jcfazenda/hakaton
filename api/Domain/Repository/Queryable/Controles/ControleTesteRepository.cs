using api.Domain.Models.Controles;
using api.Domain.Repository.Interface.Controles;
using api.Domain.Views.Input.Controles;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace api.Domain.Repository.Queryable.Controles
{
    public class ControleTesteRepository : Repository<ControleTeste, decimal>, IControleTesteRepository
    {
        private readonly GRCContext _context;
        public ControleTesteRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<ControleTeste> GetByControle(long id)
        {
            var data = DbSet.Include(i => i.Teste).Where(x => x.Id_Controle.Equals(id)).AsQueryable();

            return data;
        }

        public IQueryable<ControleTeste> GetByTeste(long id)
        {
            var data = DbSet.Include(i => i.Controle).Where(x => x.Id_Teste.Equals(id)).AsQueryable();

            return data;
        }

        public bool Create(ControleTesteInput input)
        {
            ControleTeste data = new ControleTeste
            {
                Id_Controle = input.Id_Controle,
                Id_Teste = input.Id_Teste,
                Fl_Ativo = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return true;
        }

        public bool Remove(long id)
        {
            ControleTeste data = DbSet.Where(x => x.Id_Controle_Teste.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }


    }
}
