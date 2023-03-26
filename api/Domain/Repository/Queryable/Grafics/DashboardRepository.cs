using api.Domain.Models.Grafics;
using api.Domain.Repository.Interface.Grafics;
using api.Domain.Views.Input.Grafics;
using System.Linq;

namespace api.Domain.Repository.Queryable.Grafics
{
    public class DashboardRepository : Repository<Dashboard, decimal>, IDashboardRepository
    {
        private readonly GRCContext _context;
        public DashboardRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Dashboard> GetAny(bool active)
        {
            var data = DbSet.Where(x => x.Fl_Ativo.Equals(active)).AsQueryable();

            return data;
        }
        public bool UpdateStatus(long id)
        {
            Dashboard data = DbSet.Where(x => x.Id_Dashboard.Equals(id)).AsQueryable().FirstOrDefault();
            data.Fl_Ativo = data.Fl_Ativo == true ? false : true;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public bool Create(DashboardInput input)
        {
            Dashboard data = new Dashboard
            {
                Id_Dashboard_Tipo   = 1,
                Dashboard_Nome      = input.Dashboard_Nome,
                Dashboard_Descricao = input.Dashboard_Descricao,
                Dashboard_Url       = input.Dashboard_Url,
                Fl_Ativo            = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return true;
        }

        public bool Update(DashboardInput input)
        {
            Dashboard data = DbSet.Where(x => x.Id_Dashboard.Equals(input.Id_Dashboard)).AsQueryable().FirstOrDefault();

            //data.Id_Dashboard_Tipo      = input.Id_Dashboard_Tipo;
            data.Dashboard_Nome         = input.Dashboard_Nome;
            data.Dashboard_Descricao    =  input.Dashboard_Descricao;
            data.Dashboard_Url          = input.Dashboard_Url;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public bool Remove(long id)
        {
            Dashboard data = DbSet.Where(x => x.Id_Dashboard.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }


    }
}
