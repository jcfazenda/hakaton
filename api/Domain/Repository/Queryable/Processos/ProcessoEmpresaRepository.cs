using api.Domain.Models.Processos;
using api.Domain.Repository.Interface.Processos;
using api.Domain.Views.Input.Processos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace api.Domain.Repository.Queryable.Processos
{
    public class ProcessoEmpresaRepository : Repository<ProcessoEmpresa, decimal>, IProcessoEmpresaRepository
    {
        private readonly GRCContext _context;
        public ProcessoEmpresaRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<ProcessoEmpresa> GetByProcesso(long id)
        {
            var data = DbSet.Where(x => x.Id_Processo.Equals(id)).AsQueryable();

            return data;
        }
        public IQueryable<ProcessoEmpresa> GetByEmpresa(long id)
        {
            var data = DbSet.Include(i => i.Empresa)
                            .Include(i => i.Processo).Where(x => x.Id_Empresa.Equals(id == 0 ? x.Id_Empresa : id)).AsQueryable();

            return data;
        }

        public IQueryable<ProcessoEmpresa> GetByEmpresas(long id, bool Ativo)
        {
            var data = DbSet.Include(i => i.Empresa)
                            .Include(i => i.Processo).Where(x => x.Id_Empresa.Equals(id == 0 ? x.Id_Empresa : id)
                                       && x.Processo.Fl_Ativo.Equals(Ativo)).AsQueryable();

            return data;
        }

        public bool Create(ProcessoEmpresaInput input)
        {
            ProcessoEmpresa data = new ProcessoEmpresa
            {
                Id_Empresa = input.Id_Empresa,
                Id_Processo = input.Id_Processo
            };

            _context.Add(data);
            _context.SaveChanges();

            return true;
        }


        public bool Remove(long id)
        {
            ProcessoEmpresa data = DbSet.Where(x => x.Id_Processo_Empresa.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }
        public bool RemoveByProcesso(long idProcesso)
        {
            List<ProcessoEmpresa> data = DbSet.Where(x => x.Id_Processo.Equals(idProcesso)).AsQueryable().ToList();

            foreach (var item in data)
            {

                _context.Remove(item);
                _context.SaveChanges();

            }
            return true;
        }


    }
}
