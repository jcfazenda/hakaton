using api.Domain.Models.Risco;
using api.Domain.Repository.Interface.Risco;
using api.Domain.Views.Input.Risco;
using System.Linq;

namespace api.Domain.Repository.Queryable.Risco
{
    public class ImpactoRepository : Repository<Impacto, decimal>, IImpactoRepository
    {
        private readonly GRCContext _context;
        public ImpactoRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Impacto> GetAll(bool active)
        {
            var data = DbSet.Where(x => x.Fl_Ativo.Equals(active)).AsQueryable();

            return data;
        }
        public bool UpdateStatus(long id)
        {
            Impacto data = DbSet.Where(x => x.Id_Impacto.Equals(id)).AsQueryable().FirstOrDefault();
            data.Fl_Ativo = data.Fl_Ativo == true ? false : true;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public bool Create(ImpactoInput input)
        {
            Impacto data = new Impacto
            {
                Impacto_Nome = input.Impacto_Nome,
                Impacto_Descricao = input.Impacto_Descricao, 
                Fl_Ativo = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return true;
        }

        public bool Update(ImpactoInput input)
        {
            Impacto data = DbSet.Where(x => x.Id_Impacto.Equals(input.Id_Impacto)).AsQueryable().FirstOrDefault();

            data.Impacto_Nome = input.Impacto_Nome;
            data.Impacto_Descricao = input.Impacto_Descricao; 

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }
        public bool Remove(long id)
        {
            Impacto data = DbSet.Where(x => x.Id_Impacto.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }


    }
}
