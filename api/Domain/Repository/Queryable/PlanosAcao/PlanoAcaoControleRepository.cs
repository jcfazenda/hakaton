using api.Domain.Models.PlanosAcao;
using api.Domain.Repository.Interface.PlanosAcao;
using api.Domain.Views.Input.PlanosAcao;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace api.Domain.Repository.Queryable.PlanosAcao
{
    public class PlanoAcaoControleRepository : Repository<PlanoAcaoControle, decimal>, IPlanoAcaoControleRepository
    {
        private readonly GRCContext _context;
        public PlanoAcaoControleRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<PlanoAcaoControle> GetByPlanoAcao(long id)
        {
            var data = DbSet.Include(i => i.Controle).Where(x => x.Id_Plano_Acao.Equals(id)).AsQueryable();
            return data;

        }

        public IQueryable<PlanoAcaoControle> GetAll(bool active)
        {
            var data = DbSet.Where(x => x.Fl_Ativo.Equals(active)).AsQueryable();
            return data;

        }
        public IQueryable<PlanoAcaoControle> GetByPlanoAcaoControle(long idPlanoAcao, long idControle)
        {
            var data = DbSet.Where(x => x.Id_Plano_Acao.Equals(idPlanoAcao) && x.Id_Controle.Equals(idControle)).AsQueryable();
            return data;

        }

        public bool UpdateStatus(long id)
        {
            PlanoAcaoControle data = DbSet.Where(x => x.Id_Plano_Acao_Controle.Equals(id)).AsQueryable().FirstOrDefault();
            data.Fl_Ativo = data.Fl_Ativo == true ? false : true;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public bool Create(PlanoAcaoControleInput input)
        {
            PlanoAcaoControle data = new PlanoAcaoControle
            {
                Id_Plano_Acao = input.Id_Plano_Acao,
                Id_Controle = input.Id_Controle,
                Fl_Ativo = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return true;
        }

        public bool Update(PlanoAcaoControleInput input)
        {
            PlanoAcaoControle data = DbSet.Where(x => x.Id_Plano_Acao_Controle.Equals(input.Id_Plano_Acao_Controle)).AsQueryable().FirstOrDefault();

            data.Id_Plano_Acao = input.Id_Plano_Acao;
            data.Id_Controle = input.Id_Controle;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public bool Remove(long id)
        {
            PlanoAcaoControle data = DbSet.Where(x => x.Id_Plano_Acao_Controle.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }


    }
}
