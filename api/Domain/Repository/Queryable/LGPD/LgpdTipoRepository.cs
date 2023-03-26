using api.Domain.Models.LGPD;
using api.Domain.Repository.Interface.LGPD;
using api.Domain.Views.Input.LGPD;
using System.Linq;

namespace api.Domain.Repository.Queryable.LGPD
{
    public class LgpdTipoRepository : Repository<LgpdTipo, decimal>, ILgpdTipoRepository
    {
        private readonly GRCContext _context;
        public LgpdTipoRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<LgpdTipo> GetAll(bool active)
        {
            var data = DbSet.AsQueryable();

            return data;
        }
 

        public bool Create(LgpdTipoInput input)
        {

            LgpdTipo data = new LgpdTipo();

            data.Lgpd_Tipo_Nome = input.Lgpd_Tipo_Nome; 

            _context.Add(data);
            _context.SaveChanges();

            return true;
        }

        public bool Update(LgpdTipoInput input)
        { 

            LgpdTipo data = DbSet.Where(x => x.Id_Lgpd_Tipo.Equals(input.Id_Lgpd_Tipo)).AsQueryable().FirstOrDefault();

            data.Lgpd_Tipo_Nome = input.Lgpd_Tipo_Nome; 

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public bool Remove(long id)
        {
            LgpdTipo data = DbSet.Where(x => x.Id_Lgpd_Tipo.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }

    }
}
