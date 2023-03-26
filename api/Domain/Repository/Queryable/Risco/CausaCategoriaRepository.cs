using api.Domain.Models.Risco;
using api.Domain.Repository.Interface.Risco;
using api.Domain.Views.Input.Risco;
using System.Linq;

namespace api.Domain.Repository.Queryable.Risco
{
    public class CausaCategoriaRepository : Repository<CausaCategoria, decimal>, ICausaCategoriaRepository
    {
        private readonly GRCContext _context;
        public CausaCategoriaRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<CausaCategoria> GetAll(bool active)
        {
            var data = DbSet.Where(x => x.Fl_Ativo.Equals(active)).AsQueryable();

            return data;
        }
        public bool UpdateStatus(long id)
        {
            CausaCategoria data = DbSet.Where(x => x.Id_Causa_Categoria.Equals(id)).AsQueryable().FirstOrDefault();
            data.Fl_Ativo = data.Fl_Ativo == true ? false : true;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public bool Create(CausaCategoriaInput input)
        {
            CausaCategoria data = new CausaCategoria
            {
                Causa_Categoria_Nome = input.Causa_Categoria_Nome,
                Causa_Categoria_Descricao = input.Causa_Categoria_Descricao, 
                Fl_Ativo = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return true;
        }

        public bool Update(CausaCategoriaInput input)
        {
            CausaCategoria data = DbSet.Where(x => x.Id_Causa_Categoria.Equals(input.Id_Causa_Categoria)).AsQueryable().FirstOrDefault();

            data.Causa_Categoria_Nome = input.Causa_Categoria_Nome;
            data.Causa_Categoria_Descricao = input.Causa_Categoria_Descricao;
            data.Id_Causa_Categoria = input.Id_Causa_Categoria;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }
        public bool Remove(long id)
        {
            CausaCategoria data = DbSet.Where(x => x.Id_Causa_Categoria.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }


    }


}
