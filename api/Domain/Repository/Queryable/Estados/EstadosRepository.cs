using api.Domain.Models.Estados;
using api.Domain.Repository.Interface.Estados;
using System.Linq;

namespace api.Domain.Repository.Queryable.Estados
{
    public class EstadoRepository : Repository<Estado, decimal>, IEstadoRepository
    {
        private readonly GRCContext _context;
        public EstadoRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Estado> GetAll(bool active)
        {
            var data = DbSet.AsQueryable();
            return data;
        }
 


    }
}
