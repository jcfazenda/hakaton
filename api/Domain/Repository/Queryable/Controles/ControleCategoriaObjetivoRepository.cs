using api.Domain.Models.Controles;
using api.Domain.Repository.Interface.Controles;
using api.Domain.Views.Input.Controles;
using System.Linq;

namespace api.Domain.Repository.Queryable.Controles
{
    public class ControleCategoriaObjetivoRepository : Repository<ControleCategoriaObjetivo, decimal>, IControleCategoriaObjetivoRepository
    {
        private readonly GRCContext _context;
        public ControleCategoriaObjetivoRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<ControleCategoriaObjetivo> GetAll(bool active)
        {
            var data = DbSet.Where(x => x.Fl_Ativo.Equals(active)).AsQueryable();

            return data;
        }
        public bool UpdateStatus(long id)
        {
            ControleCategoriaObjetivo data = DbSet.Where(x => x.Id_Controle_Categoria_Objetivo.Equals(id)).AsQueryable().FirstOrDefault();
            data.Fl_Ativo = data.Fl_Ativo == true ? false : true;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public long Create(ControleCategoriaObjetivoInput input)
        {
            ControleCategoriaObjetivo data = new ControleCategoriaObjetivo
            {
                Controle_Categoria_Objetivo_Nome = input.Controle_Categoria_Objetivo_Nome,
                Fl_Ativo = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return data.Id_Controle_Categoria_Objetivo;
        }

        public long Update(ControleCategoriaObjetivoInput input)
        {
            ControleCategoriaObjetivo data = DbSet.Where(x => x.Id_Controle_Categoria_Objetivo.Equals(input.Id_Controle_Categoria_Objetivo)).AsQueryable().FirstOrDefault();

            data.Controle_Categoria_Objetivo_Nome = input.Controle_Categoria_Objetivo_Nome;

            _context.Update(data);
            _context.SaveChanges();

            return data.Id_Controle_Categoria_Objetivo;
        }
        public bool Remove(long id)
        {
            ControleCategoriaObjetivo data = DbSet.Where(x => x.Id_Controle_Categoria_Objetivo.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }


    }
}
