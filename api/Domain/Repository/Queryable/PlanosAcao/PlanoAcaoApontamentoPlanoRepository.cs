using api.Domain.Models.PlanosAcao;
using api.Domain.Repository.Interface.PlanosAcao;
using api.Domain.Views.Input.PlanosAcao;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace api.Domain.Repository.Queryable.PlanosAcao
{
    public class PlanoAcaoApontamentoPlanoRepository : Repository<PlanoAcaoApontamentoPlano, decimal>, IPlanoAcaoApontamentoPlanoRepository
    {
        private readonly GRCContext _context;
        public PlanoAcaoApontamentoPlanoRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<PlanoAcaoApontamentoPlano> GetByPlanoAcao(long id)
        {
            var data = DbSet.Include(i => i.Apontamento).Where(x => x.Id_Plano_Acao.Equals(id)).AsQueryable();
            return data;

        }

        public IQueryable<PlanoAcaoApontamentoPlano> GetAll(bool active)
        {
            var data = DbSet.Where(x => x.Fl_Ativo.Equals(active)).AsQueryable();
            return data;

        }
        public IQueryable<PlanoAcaoApontamentoPlano> GetByPlanoAcaoApontamento(long idPlanoAcao, long idApontamento)
        {
            var data = DbSet.Where(x => x.Id_Plano_Acao.Equals(idPlanoAcao) && x.Id_Apontamento.Equals(idApontamento)).AsQueryable();
            return data;

        }

        public bool UpdateStatus(long id)
        {
            PlanoAcaoApontamentoPlano data = DbSet.Where(x => x.Id_Plano_Acao_Apontamento_Plano.Equals(id)).AsQueryable().FirstOrDefault();
            data.Fl_Ativo = data.Fl_Ativo == true ? false : true;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public bool Create(PlanoAcaoApontamentoPlanoInput input)
        {
            PlanoAcaoApontamentoPlano data = new PlanoAcaoApontamentoPlano
            {
                Id_Plano_Acao = input.Id_Plano_Acao,
                Id_Apontamento = input.Id_Apontamento, 
                Fl_Ativo = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return true;
        }

        public bool Update(PlanoAcaoApontamentoPlanoInput input)
        {
            PlanoAcaoApontamentoPlano data = DbSet.Where(x => x.Id_Plano_Acao_Apontamento_Plano.Equals(input.Id_Plano_Acao_Apontamento_Plano)).AsQueryable().FirstOrDefault();

            data.Id_Plano_Acao = input.Id_Plano_Acao;
            data.Id_Apontamento = input.Id_Apontamento; 

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public bool Remove(long id)
        {
            PlanoAcaoApontamentoPlano data = DbSet.Where(x => x.Id_Plano_Acao_Apontamento_Plano.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }


    }
}
