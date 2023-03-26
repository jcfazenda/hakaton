using api.Domain.Models.Controles;
using api.Domain.Repository.Interface.Controles;
using api.Domain.Views.Input.Controles;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace api.Domain.Repository.Queryable.Controles
{
    public class ControleDemonstracaoFinanceiraControleRepository : Repository<ControleDemonstracaoFinanceiraControle, decimal>, IControleDemonstracaoFinanceiraControleRepository
    {
        private readonly GRCContext _context;
        public ControleDemonstracaoFinanceiraControleRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<ControleDemonstracaoFinanceiraControle> GetByControle(long id)
        {
            var data = DbSet.Include(i => i.ControleDemonstracaoFinanceira).Where(x => x.Id_Controle.Equals(id)).AsQueryable();

            return data;
        }

        public bool Create(ControleDemonstracaoFinanceiraControleInput input)
        {
            ControleDemonstracaoFinanceiraControle data = new ControleDemonstracaoFinanceiraControle
            {
                Id_Controle = input.Id_Controle,
                Id_Controle_Demonstracao_Financeira = input.Id_Controle_Demonstracao_Financeira,
                Fl_Ativo = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return true;
        }

        public bool Remove(long id)
        {
            ControleDemonstracaoFinanceiraControle data = DbSet.Where(x => x.Id_Controle_Demonstracao_Financeira_Controle.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }


    }
}
