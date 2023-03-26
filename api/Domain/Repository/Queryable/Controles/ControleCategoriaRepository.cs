using api.Domain.Models.Controles;
using api.Domain.Repository.Interface.Controles;
using api.Domain.Views.Input.Controles;
using System.Linq;

namespace api.Domain.Repository.Queryable.Controles
{
    public class ControleCategoriaRepository : Repository<ControleCategoria, decimal>, IControleCategoriaRepository
    {
        private readonly GRCContext _context;
        public ControleCategoriaRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<ControleCategoria> GetAll(bool active)
        {
            var data = DbSet.Where(x => x.Fl_Ativo.Equals(active)).AsQueryable();

            return data;
        }
        public bool UpdateStatus(long id)
        {
            ControleCategoria data = DbSet.Where(x => x.Id_Controle_Categoria.Equals(id)).AsQueryable().FirstOrDefault();
            data.Fl_Ativo = data.Fl_Ativo == true ? false : true;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public long Create(ControleCategoriaInput input)
        {
            ControleCategoria data = new ControleCategoria
            {
                Controle_Categoria_Nome = input.Controle_Categoria_Nome, 
                Fl_Ativo = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return data.Id_Controle_Categoria;
        }

        public long Update(ControleCategoriaInput input)
        {
            ControleCategoria data = DbSet.Where(x => x.Id_Controle_Categoria.Equals(input.Id_Controle_Categoria)).AsQueryable().FirstOrDefault();

            data.Controle_Categoria_Nome = input.Controle_Categoria_Nome; 

            _context.Update(data);
            _context.SaveChanges();

            return data.Id_Controle_Categoria;
        }
        public bool Remove(long id)
        {
            ControleCategoria data = DbSet.Where(x => x.Id_Controle_Categoria.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }


    }
}
