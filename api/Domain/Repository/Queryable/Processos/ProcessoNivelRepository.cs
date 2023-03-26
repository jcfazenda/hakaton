using api.Domain.Models.Processos;
using api.Domain.Repository.Interface.Processos;
using api.Domain.Views.Input.Processos;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace api.Domain.Repository.Queryable.Processos
{
    public class ProcessoNivelRepository : Repository<ProcessoNivel, decimal>, IProcessoNivelRepository
    {
        private readonly GRCContext _context;
        public ProcessoNivelRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<ProcessoNivel> GetAny(bool active)
        {
            var data = DbSet.Where(x => x.Fl_Ativo.Equals(active)).AsQueryable();

            return data;
        }
        public bool UpdateStatus(long id)
        {
            ProcessoNivel data = DbSet.Where(x => x.Id_Processo_Nivel.Equals(id)).AsQueryable().FirstOrDefault();
            data.Fl_Ativo = data.Fl_Ativo == true ? false : true;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public long Create(ProcessoNivelInput input)
        {
            ProcessoNivel data = new ProcessoNivel
            {
                Processo_Nivel_Nome = input.Processo_Nivel_Nome, 
                Fl_Ativo = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return data.Id_Processo_Nivel;
        }

        public long Update(ProcessoNivelInput input)
        {

            ProcessoNivel data = DbSet.Where(x => x.Id_Processo_Nivel.Equals((long)input.Id_Processo_Nivel)).AsQueryable().FirstOrDefault();

            data.Processo_Nivel_Nome = input.Processo_Nivel_Nome;

            _context.Update(data);
            _context.SaveChanges();

            return data.Id_Processo_Nivel;

        }
        public bool Remove(long id)
        {
            ProcessoNivel data = DbSet.Where(x => x.Id_Processo_Nivel.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }


    }
}
