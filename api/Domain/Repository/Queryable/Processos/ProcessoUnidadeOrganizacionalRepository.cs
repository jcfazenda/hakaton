using api.Domain.Models.Processos;
using api.Domain.Repository.Interface.Processos;
using api.Domain.Views.Input.Processos;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace api.Domain.Repository.Queryable.Processos
{
    public class ProcessoUnidadeOrganizacionalRepository : Repository<ProcessoUnidadeOrganizacional, decimal>, IProcessoUnidadeOrganizacionalRepository
    {
        private readonly GRCContext _context;
        public ProcessoUnidadeOrganizacionalRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<ProcessoUnidadeOrganizacional> GetByProcesso(long id)
        {
            var data = DbSet.Include(i => i.UnidadeOrganizacional).Where(x => x.Id_Processo.Equals(id)).AsQueryable();

            return data;
        }


        public bool Create(ProcessoUnidadeOrganizacionalInput input)
        {
            ProcessoUnidadeOrganizacional data = new ProcessoUnidadeOrganizacional
            {
                Id_Unidade_Organizacional = input.Id_Unidade_Organizacional,
                Id_Processo = input.Id_Processo,
                Fl_Ativo = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return true;
        }


        public bool Remove(long id)
        {
            ProcessoUnidadeOrganizacional data = DbSet.Where(x => x.Id_Processo_Unidade_Organizacional.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }


    }
}
