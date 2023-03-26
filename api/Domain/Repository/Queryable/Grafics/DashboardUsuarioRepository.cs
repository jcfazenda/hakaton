using api.Domain.Models.Grafics;
using api.Domain.Repository.Interface.Grafics;
using api.Domain.Views.Input.Grafics;
using System.Linq;

namespace api.Domain.Repository.Queryable.Grafics
{
    public class DashboardUsuarioRepository : Repository<DashboardUsuario, decimal>, IDashboardUsuarioRepository
    {
        private readonly GRCContext _context;
        public DashboardUsuarioRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<DashboardUsuario> GetByUsuario(long id)
        {
            var data = DbSet.Where(x => x.Id_Usuario.Equals(id)).AsQueryable(); 
            return data;
        }
 

        public bool Create(DashboardUsuarioInput input)
        {
            DashboardUsuario data = new DashboardUsuario
            {
                Id_Usuario = (long)input.Id_Usuario,
                Id_Dashboard = (long)input.Id_Dashboard,
                Fl_Checked = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return true;
        }
         

        public bool Remove(long id)
        {
            DashboardUsuario data = DbSet.Where(x => x.Id_Dashboard_Usuario.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }
        public bool RemoveBy(long idDashboard, long idUsuario)
        {
            DashboardUsuario data = DbSet.Where(x => x.Id_Dashboard.Equals(idDashboard) &&
                                                     x.Id_Usuario.Equals(idUsuario)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }

    }
}
