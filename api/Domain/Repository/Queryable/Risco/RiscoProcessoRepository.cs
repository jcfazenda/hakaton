using api.Domain.Models.Risco;
using api.Domain.Repository.Interface.Risco;
using api.Domain.Views.Input.Risco;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace api.Domain.Repository.Queryable.Risco
{
    public class RiscoProcessoRepository : Repository<RiscoProcesso, decimal>, IRiscoProcessoRepository
    {
        private readonly GRCContext _context;
        public RiscoProcessoRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<RiscoProcesso> GetByRisco(long id)
        {
            var data = DbSet.Include(i => i.Processo).Where(x => x.Id_Risco.Equals(id)).AsQueryable();

            return data;
        }

        public bool Create(RiscoProcessoInput input)
        {
            RiscoProcesso data = new RiscoProcesso
            {
                Id_Risco = input.Id_Risco,
                Id_Processo = input.Id_Processo,
                Fl_Ativo = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return true;
        }

        public bool Remove(long id)
        {
            RiscoProcesso data = DbSet.Where(x => x.Id_Risco_Processo.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }


    }
}
