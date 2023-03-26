using api.Domain.Models.Controles;
using api.Domain.Repository.Interface.Controles;
using api.Domain.Views.Input.Controles;
using System.Linq;

namespace api.Domain.Repository.Queryable.Controles
{
    public class ControleTipoRepository : Repository<ControleTipo, decimal>, IControleTipoRepository
    {
        private readonly GRCContext _context;
        public ControleTipoRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<ControleTipo> GetAll(bool active)
        {
            var data = DbSet.Where(x => x.Fl_Ativo.Equals(active)).AsQueryable();

            return data;
        }
        public bool UpdateStatus(long id)
        {
            ControleTipo data = DbSet.Where(x => x.Id_Controle_Tipo.Equals(id)).AsQueryable().FirstOrDefault();
            data.Fl_Ativo = data.Fl_Ativo == true ? false : true;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public bool Create(ControleTipoInput input)
        {
            ControleTipo data = new ControleTipo
            {
                Controle_Tipo_Nome = input.Controle_Tipo_Nome,
                Fl_Ativo = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return true;
        }

        public bool Update(ControleTipoInput input)
        {
            ControleTipo data = DbSet.Where(x => x.Id_Controle_Tipo.Equals(input.Id_Controle_Tipo)).AsQueryable().FirstOrDefault();

            data.Controle_Tipo_Nome = input.Controle_Tipo_Nome;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }
        public bool Remove(long id)
        {
            ControleTipo data = DbSet.Where(x => x.Id_Controle_Tipo.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }


    }
}
