using api.Domain.Models.Processos;
using api.Domain.Repository.Interface.Processos;
using api.Domain.Views.Input.Processos;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace api.Domain.Repository.Queryable.Processos
{
    public class ProcessoProcessoRepository : Repository<ProcessoProcesso, decimal>, IProcessoProcessoRepository
    {
        private readonly GRCContext _context;
        public ProcessoProcessoRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<ProcessoProcesso> GetByProcesso(long id)
        {
            var data = DbSet.Include(i => i.Processos).Where(x => x.Id_Processo.Equals(id)).AsQueryable();

            return data;
        }
 

        public bool Create(ProcessoProcessoInput input)
        {
            ProcessoProcesso data = new ProcessoProcesso
            {
                Id_Processo_Associado = input.Id_Processo_Associado,
                Id_Processo           = input.Id_Processo,
                Fl_Ativo = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return true;
        }


        public bool Remove(long id)
        {
            ProcessoProcesso data = DbSet.Where(x => x.Id_Processo_Processo.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        } 


    }
}
