using api.Domain.Models.Incidentes;
using api.Domain.Repository.Interface.Incidentes;
using api.Domain.Views.Input.Incidentes;
using System.Linq;

namespace api.Domain.Repository.Queryable.Incidentes
{
    public class IncidenteCategoriaRepository : Repository<IncidenteCategoria, decimal>, IIncidenteCategoriaRepository
    {
        private readonly GRCContext _context;
        public IncidenteCategoriaRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<IncidenteCategoria> GetAll(bool active)
        {
            var data = DbSet.Where(x => x.Fl_Ativo.Equals(active)).AsQueryable();

            return data;
        }
        public bool UpdateStatus(long id)
        {
            IncidenteCategoria data = DbSet.Where(x => x.Id_Incidente_Categoria.Equals(id)).AsQueryable().FirstOrDefault();
            data.Fl_Ativo = data.Fl_Ativo == true ? false : true;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public bool Create(IncidenteCategoriaInput input)
        {
            IncidenteCategoria data = new IncidenteCategoria
            {
                Incidente_Categoria_Nome = input.Incidente_Categoria_Nome,
                Incidente_Categoria_Descricao = input.Incidente_Categoria_Descricao,
                Fl_Ativo = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return true;
        }

        public bool Update(IncidenteCategoriaInput input)
        {
            IncidenteCategoria data = DbSet.Where(x => x.Id_Incidente_Categoria.Equals(input.Id_Incidente_Categoria)).AsQueryable().FirstOrDefault();

            data.Incidente_Categoria_Nome = input.Incidente_Categoria_Nome;
            data.Incidente_Categoria_Descricao = input.Incidente_Categoria_Descricao; 

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }
        public bool Remove(long id)
        {
            IncidenteCategoria data = DbSet.Where(x => x.Id_Incidente_Categoria.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }


    }
}
