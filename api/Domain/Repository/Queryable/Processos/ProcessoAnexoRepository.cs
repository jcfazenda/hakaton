using api.Domain.Models.Processos;
using api.Domain.Repository.Interface.Processos;
using api.Domain.Views.Input.Processos;
using System.Linq;

namespace api.Domain.Repository.Queryable.Processos
{
    public class ProcessoAnexoRepository : Repository<ProcessoAnexo, decimal>, IProcessoAnexoRepository
    {
        private readonly GRCContext _context;
        public ProcessoAnexoRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<ProcessoAnexo> GetByProcesso(long id)
        {
            var data = DbSet.Where(x => x.Id_Processo.Equals(id)).AsQueryable();

            return data;
        }

        public bool Create(ProcessoAnexoInput input)
        {
            ProcessoAnexo data = new ProcessoAnexo
            {
                Id_Processo         = input.Id_Processo,
                Processo_Anexo_Nome = input.Processo_Anexo_Nome,
                Processo_Anexo_Byte = input.Processo_Anexo_Byte
            };

            _context.Add(data);
            _context.SaveChanges();

            return true;
        }


        public bool Remove(long id)
        {
            ProcessoAnexo data = DbSet.Where(x => x.Id_Processo_Anexo.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }
 


    }
}
