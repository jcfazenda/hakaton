using api.Domain.Models.Processos;
using api.Domain.Repository.Interface.Processos;
using api.Domain.Views.Input.Processos;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace api.Domain.Repository.Queryable.Processos
{
    public class ProcessoRiscoRepository : Repository<ProcessoRisco, decimal>, IProcessoRiscoRepository
    {
        private readonly GRCContext _context;
        public ProcessoRiscoRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<ProcessoRisco> GetByProcesso(long id)
        {
            var data = DbSet.Include(i => i.Riscos)
                            .Where(x => x.Id_Processo.Equals(id)).AsQueryable();

            return data;
        }
        public IQueryable<ProcessoRisco> GetByProcessoRisco(long idProcesso, long idRisco)
        {
            var data = DbSet.Where(x => x.Id_Processo.Equals(idProcesso)
                                             && x.Id_Risco.Equals(idRisco)).AsQueryable();

            return data;
        }

        public bool Create(ProcessoRiscoInput input)
        {
            ProcessoRisco data = new ProcessoRisco
            {
                Id_Risco    = input.Id_Risco,
                Id_Processo = input.Id_Processo
            };

            _context.Add(data);
            _context.SaveChanges();

            return true;
        } 


        public bool Remove(long id)
        {
            ProcessoRisco data = DbSet.Where(x => x.Id_Processo_Risco.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }
        public bool RemoveByProcessoRisco(long idProcesso, long idRisco)
        {
            ProcessoRisco data = DbSet.Where(x => x.Id_Processo.Equals(idProcesso)
                                             && x.Id_Risco.Equals(idRisco)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }


    }
}
