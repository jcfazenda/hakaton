using api.Domain.Models.Risco;
using api.Domain.Repository.Interface.Risco;
using api.Domain.Views.Input.Risco;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace api.Domain.Repository.Queryable.Risco
{
    public class RiscoAvaliacaoRepository : Repository<RiscoAvaliacao, decimal>, IRiscoAvaliacaoRepository
    {
        private readonly GRCContext _context;
        public RiscoAvaliacaoRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<RiscoAvaliacao> GetAll(bool active)
        {
            var data = DbSet.Include(i => i.Riscos).Include(i => i.Usuarios)
                            .Include(i => i.RiscoAvaliacaoStatus).Where(x => x.Fl_Ativo.Equals(active) && x.Fl_Excluido.Equals(false)).AsQueryable();

            return data;
        }
        public IQueryable<RiscoAvaliacao> GetByRisco(long id)
        {
            var data = DbSet.Include(i => i.Usuarios)
                            .Include(i => i.Riscos)
                            .Include(i => i.RiscoAvaliacaoStatus).Where(x => x.Id_Risco.Equals(id)
                                                                          && x.Fl_Excluido.Equals(false)).OrderByDescending(o => o.Id_Risco_Avaliacao).AsQueryable();

            return data;
        }
        public IQueryable<RiscoAvaliacao> GetByAvaliacao(long id)
        {
            var data = DbSet.Include(i => i.Riscos).Include(i => i.Usuarios)
                            .Include(i => i.RiscoAvaliacaoStatus)
                            .Where(x => x.Id_Risco_Avaliacao.Equals(id)).AsQueryable();

            return data;
        }
        public IQueryable<RiscoAvaliacao> GetByStatus(long id)
        {
            var data = DbSet.Include(i => i.Riscos).Include(i => i.Usuarios)
                            .Include(i => i.RiscoAvaliacaoStatus).Where(x => x.Id_Risco_Avaliacao_Status.Equals(id)).AsQueryable();

            return data;
        }

        public bool UpdateStatusWorkFlow(long id, long idStatus)
        {
            RiscoAvaliacao data = DbSet.Where(x => x.Id_Risco_Avaliacao.Equals(id)).AsQueryable().FirstOrDefault();

            data.Id_Risco_Avaliacao_Status = idStatus;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }


        public bool UpdateStatus(long id)
        {
            RiscoAvaliacao data = DbSet.Where(x => x.Id_Risco_Avaliacao.Equals(id)).AsQueryable().FirstOrDefault();
            data.Fl_Ativo = data.Fl_Ativo == true ? false : true;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public long Create(RiscoAvaliacaoInput input)
        {
            RiscoAvaliacao data = new RiscoAvaliacao
            {
                Data_Inicio_Avaliacao       = DateTime.Now,
                Id_Risco                    = input.Id_Risco,
                Id_Usuario = input.Id_Usuario,
                Id_Risco_Tratamento_Tipo    = input.Id_Risco_Tratamento_Tipo,
                Id_Risco_Avaliacao_Status   = 3,
                Fl_Ativo = true,
                Fl_Excluido = false
            };

            _context.Add(data);
            _context.SaveChanges();

            return data.Id_Risco_Avaliacao;
        }

        public bool Update(RiscoAvaliacaoInput input)
        {
            RiscoAvaliacao data = DbSet.Where(x => x.Id_Risco_Avaliacao.Equals(input.Id_Risco_Avaliacao)).AsQueryable().FirstOrDefault();

            data.Id_Risco_Tratamento_Tipo = input.Id_Risco_Tratamento_Tipo;
            data.Id_Risco_Avaliacao_Status = input.Id_Risco_Avaliacao_Status; 

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }
        public bool Remove(long id)
        {
            RiscoAvaliacao data = DbSet.Where(x => x.Id_Risco_Avaliacao.Equals(id)).AsQueryable().FirstOrDefault();

            //_context.Remove(data);

             data.Fl_Excluido = true;
            _context.SaveChanges();

            return true;
        }


    }
}
