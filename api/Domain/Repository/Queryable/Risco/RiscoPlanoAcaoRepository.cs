using api.Domain.Models.Risco;
using api.Domain.Repository.Interface.Risco;
using api.Domain.Views.Input.Risco;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace api.Domain.Repository.Queryable.Risco
{
    public class RiscoPlanoAcaoRepository : Repository<RiscoPlanoAcao, decimal>, IRiscoPlanoAcaoRepository
    {
        private readonly GRCContext _context;
        public RiscoPlanoAcaoRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<RiscoPlanoAcao> GetByRisco(long id)
        {
            var data = DbSet.Include(i => i.PlanoAcao).Where(x => x.Id_Risco.Equals(id)).AsQueryable();

            return data;
        }

        public bool Create(RiscoPlanoAcaoInput input)
        {
            RiscoPlanoAcao data = new RiscoPlanoAcao
            {
                Id_Risco = input.Id_Risco,
                Id_Plano_Acao = input.Id_Plano_Acao,
                Fl_Ativo = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return true;
        }

        public bool Remove(long id)
        {
            RiscoPlanoAcao data = DbSet.Where(x => x.Id_Risco_Plano_Acao.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }


    }
}
