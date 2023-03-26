using api.Domain.Models.Risco;
using api.Domain.Repository.Interface.Risco;
using api.Domain.Views.Input.Risco;
using System.Linq;

namespace api.Domain.Repository.Queryable.Risco
{
    public class FatorRiscoRepository : Repository<FatorRisco, decimal>, IFatorRiscoRepository
    {
        private readonly GRCContext _context;
        public FatorRiscoRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<FatorRisco> GetAll(bool active)
        {
            var data = DbSet.Where(x => x.Fl_Ativo.Equals(active)).AsQueryable();

            return data;
        }
        public bool UpdateStatus(long id)
        {
            FatorRisco data = DbSet.Where(x => x.Id_Fator_Risco.Equals(id)).AsQueryable().FirstOrDefault();
            data.Fl_Ativo = data.Fl_Ativo == true ? false : true;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public bool Create(FatorRiscoInput input)
        {
            FatorRisco data = new FatorRisco
            {
                Fator_Risco_Nome = input.Fator_Risco_Nome,
                Fator_Risco_Descricao = input.Fator_Risco_Descricao,
                Fl_Ativo = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return true;
        }

        public bool Update(FatorRiscoInput input)
        {
            FatorRisco data = DbSet.Where(x => x.Id_Fator_Risco.Equals(input.Id_Fator_Risco)).AsQueryable().FirstOrDefault();

            data.Fator_Risco_Nome = input.Fator_Risco_Nome;
            data.Fator_Risco_Descricao = input.Fator_Risco_Descricao;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }
        public bool Remove(long id)
        {
            FatorRisco data = DbSet.Where(x => x.Id_Fator_Risco.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }


    }
}
