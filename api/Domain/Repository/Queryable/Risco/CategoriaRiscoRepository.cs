using api.Domain.Models.Risco;
using api.Domain.Repository.Interface.Risco;
using api.Domain.Views.Input.Risco;
using System.Linq;

namespace api.Domain.Repository.Queryable.Risco
{
    public class CategoriaRiscoRepository : Repository<CategoriaRisco, decimal>, ICategoriaRiscoRepository
    {
        private readonly GRCContext _context;
        public CategoriaRiscoRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<CategoriaRisco> GetAll(bool active)
        {
            var data = DbSet.Where(x => x.Fl_Ativo.Equals(active)).AsQueryable();

            return data;
        }
        public bool UpdateStatus(long id)
        {
            CategoriaRisco data = DbSet.Where(x => x.Id_Categoria_Risco.Equals(id)).AsQueryable().FirstOrDefault();
            data.Fl_Ativo = data.Fl_Ativo == true ? false : true;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public bool Create(CategoriaRiscoInput input)
        {
            CategoriaRisco data = new CategoriaRisco
            {
                Categoria_Risco_Nome = input.Categoria_Risco_Nome, 
                Fl_Ativo = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return true;
        }

        public bool Update(CategoriaRiscoInput input)
        {
            CategoriaRisco data = DbSet.Where(x => x.Id_Categoria_Risco.Equals(input.Id_Categoria_Risco)).AsQueryable().FirstOrDefault();

            data.Categoria_Risco_Nome = input.Categoria_Risco_Nome; 

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }
        public bool Remove(long id)
        {
            CategoriaRisco data = DbSet.Where(x => x.Id_Categoria_Risco.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }


    }
}
