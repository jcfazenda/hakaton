using api.Domain.Models.PerfisAcesso.Telas;
using api.Domain.Repository.Interface.PerfisAcesso.Telas;
using api.Domain.Views.Input.PerfisAcesso.Telas;
using System.Linq;

namespace api.Domain.Repository.Queryable.PerfisAcesso.Telas
{
    public class NivelAcessoRepository : Repository<NivelAcesso, decimal>, INivelAcessoRepository
    {
        private readonly GRCContext _context;
        public NivelAcessoRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<NivelAcesso> GetAll(bool active)
        {
            var data = DbSet.AsQueryable();

            return data;
        }
        public bool UpdateStatus(long id)
        {
            NivelAcesso data = DbSet.Where(x => x.Id_Nivel_Acesso.Equals(id)).AsQueryable().FirstOrDefault();
            data.Fl_Ativo = data.Fl_Ativo == true ? false : true;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public bool Create(NivelAcessoInput input)
        {
            NivelAcesso data = new NivelAcesso
            {
                Nivel_Acesso_Nome = input.Nivel_Acesso_Nome, 
                Fl_Ativo = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return true;
        }

        public bool Update(NivelAcessoInput input)
        {
            NivelAcesso data = DbSet.Where(x => x.Id_Nivel_Acesso.Equals(input.Id_Nivel_Acesso)).AsQueryable().FirstOrDefault();

            data.Nivel_Acesso_Nome = input.Nivel_Acesso_Nome; 

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }
        public bool Remove(long id)
        {
            NivelAcesso data = DbSet.Where(x => x.Id_Nivel_Acesso.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }


    }
}
