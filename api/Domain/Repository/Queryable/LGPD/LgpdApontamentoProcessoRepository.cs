using api.Domain.Models.LGPD;
using api.Domain.Repository.Interface.LGPD;
using api.Domain.Views.Input.LGPD;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace api.Domain.Repository.Queryable.LGPD
{
    public class LgpdApontamentoProcessoRepository : Repository<LgpdApontamentoProcesso, decimal>, ILgpdApontamentoProcessoRepository
    {
        private readonly GRCContext _context;
        public LgpdApontamentoProcessoRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<LgpdApontamentoProcesso> GetByProcesso(long idProcesso)
        {
            var data = DbSet.Include(i => i.Apontamento).Where(x => x.Id_Processo.Equals(idProcesso)).AsQueryable();

            return data;
        }

        public bool Create(LgpdApontamentoProcessoInput input)
        {

            LgpdApontamentoProcesso data = new LgpdApontamentoProcesso();

            data.Id_Apontamento = input.Id_Apontamento; 
            data.Id_Processo         = input.Id_Processo;

            _context.Add(data);
            _context.SaveChanges();

            return true;
        }



        public bool Update(LgpdApontamentoProcessoInput input)
        {

            LgpdApontamentoProcesso data = DbSet.Where(x => x.Id_Lgpd_Apontamento_Processo.Equals(input.Id_Lgpd_Apontamento_Processo)).AsQueryable().FirstOrDefault();

            data.Id_Apontamento = input.Id_Apontamento;
            data.Id_Processo = input.Id_Processo;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public bool Remove(long id)
        {
            LgpdApontamentoProcesso data = DbSet.Where(x => x.Id_Lgpd_Apontamento_Processo.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }

    }
}
