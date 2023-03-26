using api.Domain.Models.Processos;
using api.Domain.Repository.Interface.Processos;
using api.Domain.Views.Input.Processos;
using System.Collections.Generic;
using System.Linq;

namespace api.Domain.Repository.Queryable.Processos
{
    public class ProcessoLinhaNegocioRepository : Repository<ProcessoLinhaNegocio, decimal>, IProcessoLinhaNegocioRepository
    {
        private readonly GRCContext _context;
        public ProcessoLinhaNegocioRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<ProcessoLinhaNegocio> GetByProcesso(long id)
        {
            var data = DbSet.Where(x => x.Id_Processo.Equals(id)).AsQueryable();

            return data;
        }

        public bool Create(ProcessoLinhaNegocioInput input)
        {
            ProcessoLinhaNegocio data = new ProcessoLinhaNegocio
            {
                Id_Linha_Negocio = input.Id_Linha_Negocio,
                Id_Processo = input.Id_Processo
            };

            _context.Add(data);
            _context.SaveChanges();

            return true;
        }


        public bool Remove(long id)
        {
            ProcessoLinhaNegocio data = DbSet.Where(x => x.Id_Processo_Linha_Negocio.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }
        public bool RemoveByProcesso(long idProcesso)
        {
            List<ProcessoLinhaNegocio> data = DbSet.Where(x => x.Id_Processo.Equals(idProcesso)).AsQueryable().ToList();

            foreach (var item in data)
            {

                _context.Remove(item);
                _context.SaveChanges();

            }
            return true;
        }


    }
}
