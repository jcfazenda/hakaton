using api.Domain.Models.Risco;
using api.Domain.Repository.Interface.Risco;
using api.Domain.Views.Input.Risco;
using System.Linq;

namespace api.Domain.Repository.Queryable.Risco
{
    public class RiscoAvaliacaoStatusRepository : Repository<RiscoAvaliacaoStatus, decimal>, IRiscoAvaliacaoStatusRepository
    {
        private readonly GRCContext _context;
        public RiscoAvaliacaoStatusRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<RiscoAvaliacaoStatus> GetAll(bool active)
        {
            var data = DbSet.Where(x => x.Fl_Ativo.Equals(active)).AsQueryable();

            return data;
        }

        public IQueryable<RiscoAvaliacaoStatus> GetByDescricao(string Descricao)
        {
            var data = DbSet.Where(x => x.Avaliacao_Status_Nome.Equals(Descricao)).AsQueryable();

            return data;
        }

        public bool UpdateStatus(long id)
        {
            RiscoAvaliacaoStatus data = DbSet.Where(x => x.Id_Risco_Avaliacao_Status.Equals(id)).AsQueryable().FirstOrDefault();
            data.Fl_Ativo = data.Fl_Ativo == true ? false : true;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public bool Create(RiscoAvaliacaoStatusInput input)
        {
            RiscoAvaliacaoStatus data = new RiscoAvaliacaoStatus
            {
                Avaliacao_Status_Nome = input.Avaliacao_Status_Nome,
                Label_Color = input.Label_Color,
                Panel_Color = input.Panel_Color,
                Fl_Ativo = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return true;
        }

        public bool Update(RiscoAvaliacaoStatusInput input)
        {
            RiscoAvaliacaoStatus data = DbSet.Where(x => x.Id_Risco_Avaliacao_Status.Equals(input.Id_Risco_Avaliacao_Status)).AsQueryable().FirstOrDefault();

            data.Label_Color = input.Label_Color;
            data.Avaliacao_Status_Nome = input.Avaliacao_Status_Nome;
            data.Panel_Color = input.Panel_Color;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }
        public bool Remove(long id)
        {
            RiscoAvaliacaoStatus data = DbSet.Where(x => x.Id_Risco_Avaliacao_Status.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }


    }
}
