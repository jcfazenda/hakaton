using api.Domain.Models.Indice;
using api.Domain.Repository.Interface.Indice;
using api.Domain.Views.Input.Indice;
using System;
using System.Linq;

namespace api.Domain.Repository.Queryable.Indice
{
    public class MatrizRepository : Repository<Matriz, decimal>, IMatrizRepository
    {
        private readonly GRCContext _context;
        public MatrizRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Matriz> GetAll(bool active)
        {
            var data = DbSet.Where(x => x.Fl_Ativo.Equals(active)).AsQueryable();

            return data;
        }
        public bool UpdateStatus(long id)
        {
            Matriz data = DbSet.Where(x => x.Id_Matriz.Equals(id)).AsQueryable().FirstOrDefault();
            data.Fl_Ativo = data.Fl_Ativo == true ? false : true;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public bool Create(MatrizInput input)
        {
            Matriz data = new Matriz
            {
                Matriz_Nome = input.Matriz_Nome,
                Matriz_Descricao = input.Matriz_Descricao, 
                Fl_Ativo = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return true;
        }

        public bool Update(MatrizInput input)
        {
            Matriz data = DbSet.Where(x => x.Id_Matriz.Equals(input.Id_Matriz)).AsQueryable().FirstOrDefault();

            data.Matriz_Nome = input.Matriz_Nome;
            data.Matriz_Descricao = input.Matriz_Descricao; 

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public bool Remove(long id)
        {
            Matriz data = DbSet.Where(x => x.Id_Matriz.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }


    }
}
