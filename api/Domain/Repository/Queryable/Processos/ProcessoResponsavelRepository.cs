using api.Domain.Models.Processos;
using api.Domain.Repository.Interface.Processos;
using api.Domain.Views.Input.Processos;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace api.Domain.Repository.Queryable.Processos
{
    public class ProcessoResponsavelRepository : Repository<ProcessoResponsavel, decimal>, IProcessoResponsavelRepository
    {
        private readonly GRCContext _context;
        public ProcessoResponsavelRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<ProcessoResponsavel> GetByProcesso(long id)
        {
            var data = DbSet.Include(i => i.Usuarios)
                            .Where(x => x.Id_Processo.Equals(id)).AsQueryable();

            return data;
        }
        public IQueryable<ProcessoResponsavel> GetByProcessoResponsavel(long idProcesso, long idUsuario)
        {
            var data = DbSet.Where(x => x.Id_Processo.Equals(idProcesso)
                                             && x.Id_Usuario.Equals(idUsuario)).AsQueryable();

            return data;
        }

        public bool Create(ProcessoResponsavelInput input)
        {
            ProcessoResponsavel data = new ProcessoResponsavel
            {
                Id_Usuario = input.Id_Usuario,
                Id_Processo = input.Id_Processo
            };

            _context.Add(data);
            _context.SaveChanges();

            return true;
        }


        public bool Remove(long id)
        {
            ProcessoResponsavel data = DbSet.Where(x => x.Id_Processo_Responsavel.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }
        public bool RemoveByProcessoResponsavel(long idProcesso, long idUsuario)
        {
            ProcessoResponsavel data = DbSet.Where(x => x.Id_Processo.Equals(idProcesso)
                                             && x.Id_Usuario.Equals(idUsuario)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }


    }
}
