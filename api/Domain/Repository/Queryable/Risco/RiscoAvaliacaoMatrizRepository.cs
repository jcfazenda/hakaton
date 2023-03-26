using api.Domain.Models.Risco;
using api.Domain.Repository.Interface.Risco;
using api.Domain.Views.Input.Risco;
using System.Collections.Generic;
using System.Linq;

namespace api.Domain.Repository.Queryable.Risco
{
    public class RiscoAvaliacaoMatrizRepository : Repository<RiscoAvaliacaoMatriz, decimal>, IRiscoAvaliacaoMatrizRepository
    {
        private readonly GRCContext _context;
        public RiscoAvaliacaoMatrizRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<RiscoAvaliacaoMatriz> GetAll(bool active)
        {
            var data = DbSet.Where(x => x.Fl_Ativo.Equals(active)).AsQueryable();

            return data;
        }
        public IQueryable<RiscoAvaliacaoMatriz> GetByAvaliacao(long id)
        {
            var data = DbSet.Where(x => x.Id_Risco_Avaliacao.Equals(id)).AsQueryable();

            return data;
        }

        public bool Create(RiscoAvaliacaoMatrizInput input)
        {
            RiscoAvaliacaoMatriz data = new RiscoAvaliacaoMatriz
            {
                Id_Risco_Avaliacao          = input.Id_Risco_Avaliacao,
                Id_Matriz_Item              = input.Id_Matriz_Item,
                Inerente_Residual_Planejado = input.Inerente_Residual_Planejado,

                Fl_Ativo                    = true,
                Fl_Pin                      = input.Fl_Pin
            };

            _context.Add(data);
            _context.SaveChanges();

            return true;
        }

        public bool Update(RiscoAvaliacaoMatrizInput input)
        {
            RiscoAvaliacaoMatriz data = DbSet.Where(x => x.Id_Risco_Avaliacao_Matriz.Equals(input.Id_Risco_Avaliacao_Matriz)).AsQueryable().FirstOrDefault();

            data.Id_Matriz_Item              = input.Id_Matriz_Item;
            data.Inerente_Residual_Planejado = input.Inerente_Residual_Planejado;
            data.Fl_Pin                      = input.Fl_Pin;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }
        public bool Remove(long id)
        {
            RiscoAvaliacaoMatriz data = DbSet.Where(x => x.Id_Risco_Avaliacao_Matriz.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }
        public bool RemoveByRiscoAvaliacao(long id)
        {
            List<RiscoAvaliacaoMatriz> data = DbSet.Where(x => x.Id_Risco_Avaliacao.Equals(id)).AsQueryable().ToList();

            foreach (var item in data)
            { 
                _context.Remove(item);
                _context.SaveChanges();
            }


            return true;
        }

    }
}
