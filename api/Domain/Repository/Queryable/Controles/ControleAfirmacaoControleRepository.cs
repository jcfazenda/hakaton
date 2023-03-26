using api.Domain.Models.Controles;
using api.Domain.Repository.Interface.Controles;
using api.Domain.Views.Input.Controles;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace api.Domain.Repository.Queryable.Controles
{
    public class ControleAfirmacaoControleRepository : Repository<ControleAfirmacaoControle, decimal>, IControleAfirmacaoControleRepository
    {
        private readonly GRCContext _context;
        public ControleAfirmacaoControleRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<ControleAfirmacaoControle> GetByControle(long id)
        {
            var data = DbSet.Include(i => i.ControleAfirmacao).Where(x => x.Id_Controle.Equals(id)).AsQueryable();

            return data;
        }

        public bool Create(ControleAfirmacaoControleInput input)
        {
            ControleAfirmacaoControle data = new ControleAfirmacaoControle
            {
                Id_Controle = input.Id_Controle,
                Id_Controle_Afirmacao = input.Id_Controle_Afirmacao,
                Fl_Ativo = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return true;
        }

        public bool Remove(long id)
        {
            ControleAfirmacaoControle data = DbSet.Where(x => x.Id_Controle_Afirmacao_Controle.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }


    }
}
