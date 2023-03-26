using api.Domain.Models.Controles;
using api.Domain.Repository.Interface.Controles;
using api.Domain.Views.Input.Controles;
using System.Linq;

namespace api.Domain.Repository.Queryable.Controles
{
    public class ControleDemonstracaoFinanceiraRepository : Repository<ControleDemonstracaoFinanceira, decimal>, IControleDemonstracaoFinanceiraRepository
    {
        private readonly GRCContext _context;
        public ControleDemonstracaoFinanceiraRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<ControleDemonstracaoFinanceira> GetAll(bool active)
        {
            var data = DbSet.Where(x => x.Fl_Ativo.Equals(active)).AsQueryable();

            return data;
        }
        public bool UpdateStatus(long id)
        {
            ControleDemonstracaoFinanceira data = DbSet.Where(x => x.Id_Controle_Demonstracao_Financeira.Equals(id)).AsQueryable().FirstOrDefault();
            data.Fl_Ativo = data.Fl_Ativo == true ? false : true;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public long Create(ControleDemonstracaoFinanceiraInput input)
        {
            ControleDemonstracaoFinanceira data = new ControleDemonstracaoFinanceira
            {
                Controle_Demonstracao_Financeira_Nome = input.Controle_Demonstracao_Financeira_Nome,
                Controle_Demonstracao_Financeira_Descricao = input.Controle_Demonstracao_Financeira_Descricao,
                Fl_Ativo = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return data.Id_Controle_Demonstracao_Financeira;
        }

        public long Update(ControleDemonstracaoFinanceiraInput input)
        {
            ControleDemonstracaoFinanceira data = DbSet.Where(x => x.Id_Controle_Demonstracao_Financeira.Equals(input.Id_Controle_Demonstracao_Financeira)).AsQueryable().FirstOrDefault();

            data.Controle_Demonstracao_Financeira_Nome = input.Controle_Demonstracao_Financeira_Nome;
            data.Controle_Demonstracao_Financeira_Descricao = input.Controle_Demonstracao_Financeira_Descricao;

            _context.Update(data);
            _context.SaveChanges();

            return data.Id_Controle_Demonstracao_Financeira;
        }
        public bool Remove(long id)
        {
            ControleDemonstracaoFinanceira data = DbSet.Where(x => x.Id_Controle_Demonstracao_Financeira.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }


    }
}
