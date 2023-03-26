using api.Domain.Models.Apontamentos;
using api.Domain.Repository.Interface.Apontamentos;
using api.Domain.Views.Input.Apontamentos;
using System.Linq;

namespace api.Domain.Repository.Queryable.Apontamentos
{
    public class ApontamentoClassificacaoRepository : Repository<ApontamentoClassificacao, decimal>, IApontamentoClassificacaoRepository
    {
        private readonly GRCContext _context;
        public ApontamentoClassificacaoRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<ApontamentoClassificacao> GetAll(bool active)
        {
            var data = DbSet.Where(x => x.Fl_Ativo.Equals(active)).AsQueryable();

            return data;
        }
        public bool UpdateStatus(long id)
        {
            ApontamentoClassificacao data = DbSet.Where(x => x.Id_Apontamento_Classificacao.Equals(id)).AsQueryable().FirstOrDefault();
            data.Fl_Ativo = data.Fl_Ativo == true ? false : true;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public bool Create(ApontamentoClassificacaoInput input)
        {
            ApontamentoClassificacao data = new ApontamentoClassificacao
            {
                Apontamento_Classificacao_Nome = input.Apontamento_Classificacao_Nome,
                Icon = input.Icon,
                Fl_Ativo = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return true;
        }

        public bool Update(ApontamentoClassificacaoInput input)
        {
            ApontamentoClassificacao data = DbSet.Where(x => x.Id_Apontamento_Classificacao.Equals(input.Id_Apontamento_Classificacao)).AsQueryable().FirstOrDefault();

            data.Apontamento_Classificacao_Nome = input.Apontamento_Classificacao_Nome;
            data.Icon = input.Icon;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public bool Remove(long id)
        {
            ApontamentoClassificacao data = DbSet.Where(x => x.Id_Apontamento_Classificacao.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }


    }
}
