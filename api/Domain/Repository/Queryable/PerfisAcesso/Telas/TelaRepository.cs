using api.Domain.Models.PerfisAcesso.Telas;
using api.Domain.Repository.Interface.PerfisAcesso.Telas;
using api.Domain.Views.Input.PerfisAcesso.Telas;
using System.Linq;

namespace api.Domain.Repository.Queryable.PerfisAcesso.Telas
{
    public class TelaRepository : Repository<Tela, decimal>, ITelaRepository
    {
        private readonly GRCContext _context;
        public TelaRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Tela> GetAll(bool active)
        {
            var data = DbSet.Where(x => x.Fl_Ativo.Equals(active)).AsQueryable();

            return data;
        }
        public IQueryable<Tela> GetByURL(string url)
        {
            var data = DbSet.Where(x => x.Tela_Url.Equals(url)).AsQueryable();

            return data;
        }
        public bool UpdateStatus(long id)
        {
            Tela data = DbSet.Where(x => x.Id_Tela.Equals(id)).AsQueryable().FirstOrDefault();
            data.Fl_Ativo = data.Fl_Ativo == true ? false : true;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public bool Create(TelaInput input)
        {
            Tela data = new Tela
            {
                Tela_Url   = input.Tela_Url,
                Tela_Nome  = input.Tela_Nome, 
                Fl_Ativo   = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return true;
        }

        public bool Update(TelaInput input)
        {
            Tela data = DbSet.Where(x => x.Id_Tela.Equals(input.Id_Tela)).AsQueryable().FirstOrDefault();

            data.Tela_Nome = input.Tela_Nome;
            data.Tela_Url  = input.Tela_Url; 

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }
        public bool Remove(long id)
        {
            Tela data = DbSet.Where(x => x.Id_Tela.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }


    }
}
