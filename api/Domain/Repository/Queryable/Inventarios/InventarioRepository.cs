using api.Domain.Models.Inventarios;
using api.Domain.Repository.Interface.Inventarios;
using api.Domain.Views.Input.Inventarios;
using System.Linq;

namespace api.Domain.Repository.Queryable.Inventarios
{
    public class InventarioRepository : Repository<Inventario, decimal>, IInventarioRepository
    {
        private readonly GRCContext _context;
        public InventarioRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Inventario> GetAll(bool active)
        {
            var data = DbSet.Where(x => x.Fl_Ativo.Equals(active)).AsQueryable();

            return data;
        }

        public bool UpdateStatus(long id)
        {
            Inventario data = DbSet.Where(x => x.Id_Inventario.Equals(id)).AsQueryable().FirstOrDefault();
            data.Fl_Ativo = data.Fl_Ativo == true ? false : true;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public bool Anexo(InventarioInput input)
        {

            Inventario data = DbSet.Where(x => x.Id_Inventario.Equals(input.Id_Inventario)).AsQueryable().FirstOrDefault();

            data.Inventario_Anexo_Nome = input.Inventario_Anexo_Nome;
            data.Inventario_Anexo = input.Inventario_Anexo;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }
        public bool Create(InventarioInput input)
        {

            Inventario data = new Inventario();

            data.Id_Inventario_Tipo     = input.Id_Inventario_Tipo;
            data.Inventario_Codigo      = input.Inventario_Codigo;
            data.Inventario_Nome        = input.Inventario_Nome;
            data.Inventario_Descricao   = input.Inventario_Descricao;
            data.Inventario_Anexo       = input.Inventario_Anexo;
            data.Inventario_Anexo_Nome  = input.Inventario_Anexo_Nome;

            data.Fl_Ativo               = true;

            _context.Add(data);
            _context.SaveChanges();

            return true;
        }

        public bool Update(InventarioInput input)
        {

            Inventario data = DbSet.Where(x => x.Id_Inventario.Equals(input.Id_Inventario)).AsQueryable().FirstOrDefault();

            data.Id_Inventario_Tipo     = input.Id_Inventario_Tipo;
            data.Inventario_Codigo      = input.Inventario_Codigo;
            data.Inventario_Nome        = input.Inventario_Nome;
            data.Inventario_Descricao   = input.Inventario_Descricao;
            data.Inventario_Anexo       = input.Inventario_Anexo;
            data.Inventario_Anexo_Nome  = input.Inventario_Anexo_Nome;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public bool Remove(long id)
        {
            Inventario data = DbSet.Where(x => x.Id_Inventario.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }

    }
}
