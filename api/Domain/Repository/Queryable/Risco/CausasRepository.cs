using api.Domain.Models.Risco;
using api.Domain.Repository.Interface.Risco;
using api.Domain.Views.Input.Risco;
using System.Linq;

namespace api.Domain.Repository.Queryable.Risco
{
    public class CausasRepository : Repository<Causas, decimal>, ICausasRepository
    {
        private readonly GRCContext _context;
        public CausasRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Causas> GetAll(bool active)
        {
            var data = DbSet.Where(x => x.Fl_Ativo.Equals(active)).AsQueryable();

            return data;
        }
        public bool UpdateStatus(long id)
        {
            Causas data = DbSet.Where(x => x.Id_Causa.Equals(id)).AsQueryable().FirstOrDefault();
            data.Fl_Ativo = data.Fl_Ativo == true ? false : true;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public bool Create(CausasInput input)
        {
            Causas data = new Causas
            {
                Causa_Nome = input.Causa_Nome,
                Causa_Descricao = input.Causa_Descricao,
                Id_Causa_Categoria = input.Id_Causa_Categoria, 
                Fl_Ativo = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return true;
        }

        public bool Update(CausasInput input)
        {
            Causas data = DbSet.Where(x => x.Id_Causa.Equals(input.Id_Causa)).AsQueryable().FirstOrDefault();

            data.Causa_Nome = input.Causa_Nome;
            data.Causa_Descricao = input.Causa_Descricao;
            data.Id_Causa_Categoria = input.Id_Causa_Categoria;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }
        public bool Remove(long id)
        {
            Causas data = DbSet.Where(x => x.Id_Causa.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }


    }
}
