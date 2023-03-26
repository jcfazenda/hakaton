using api.Domain.Models.Controles;
using api.Domain.Repository.Interface.Controles;
using api.Domain.Views.Input.Controles;
using System.Linq;

namespace api.Domain.Repository.Queryable.Controles
{
    public class ControleGrauAutomacaoRepository : Repository<ControleGrauAutomacao, decimal>, IControleGrauAutomacaoRepository
    {
        private readonly GRCContext _context;
        public ControleGrauAutomacaoRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<ControleGrauAutomacao> GetAll(bool active)
        {
            var data = DbSet.Where(x => x.Fl_Ativo.Equals(active)).AsQueryable();

            return data;
        }
        public bool UpdateStatus(long id)
        {
            ControleGrauAutomacao data = DbSet.Where(x => x.Id_Controle_Grau_Automacao.Equals(id)).AsQueryable().FirstOrDefault();
            data.Fl_Ativo = data.Fl_Ativo == true ? false : true;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public long Create(ControleGrauAutomacaoInput input)
        {
            ControleGrauAutomacao data = new ControleGrauAutomacao
            {
                Controle_Grau_Automacao_Nome = input.Controle_Grau_Automacao_Nome,
                Fl_Ativo = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return data.Id_Controle_Grau_Automacao;
        }

        public long Update(ControleGrauAutomacaoInput input)
        {
            ControleGrauAutomacao data = DbSet.Where(x => x.Id_Controle_Grau_Automacao.Equals(input.Id_Controle_Grau_Automacao)).AsQueryable().FirstOrDefault();

            data.Controle_Grau_Automacao_Nome = input.Controle_Grau_Automacao_Nome;

            _context.Update(data);
            _context.SaveChanges();

            return data.Id_Controle_Grau_Automacao;
        }
        public bool Remove(long id)
        {
            ControleGrauAutomacao data = DbSet.Where(x => x.Id_Controle_Grau_Automacao.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }


    }
}
