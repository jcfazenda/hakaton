using api.Domain.Models.Controles;
using api.Domain.Repository.Interface.Controles;
using api.Domain.Views.Input.Controles;
using System.Linq;

namespace api.Domain.Repository.Queryable.Controles
{
    public class ControleAfirmacaoRepository : Repository<ControleAfirmacao, decimal>, IControleAfirmacaoRepository
    {
        private readonly GRCContext _context;
        public ControleAfirmacaoRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<ControleAfirmacao> GetAll(bool active)
        {
            var data = DbSet.Where(x => x.Fl_Ativo.Equals(active)).AsQueryable();

            return data;
        }
        public bool UpdateStatus(long id)
        {
            ControleAfirmacao data = DbSet.Where(x => x.Id_Controle_Afirmacao.Equals(id)).AsQueryable().FirstOrDefault();
            data.Fl_Ativo = data.Fl_Ativo == true ? false : true;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public long Create(ControleAfirmacaoInput input)
        {
            ControleAfirmacao data = new ControleAfirmacao
            {
                Controle_Afirmacao_Nome = input.Controle_Afirmacao_Nome,
                Controle_Afirmacao_Descricao = input.Controle_Afirmacao_Descricao,
                Fl_Ativo = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return data.Id_Controle_Afirmacao;
        }

        public long Update(ControleAfirmacaoInput input)
        {
            ControleAfirmacao data = DbSet.Where(x => x.Id_Controle_Afirmacao.Equals(input.Id_Controle_Afirmacao)).AsQueryable().FirstOrDefault();

            data.Controle_Afirmacao_Nome      = input.Controle_Afirmacao_Nome;
            data.Controle_Afirmacao_Descricao = input.Controle_Afirmacao_Descricao;

            _context.Update(data);
            _context.SaveChanges();

            return data.Id_Controle_Afirmacao;
        }
        public bool Remove(long id)
        {
            ControleAfirmacao data = DbSet.Where(x => x.Id_Controle_Afirmacao.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }


    }
}
