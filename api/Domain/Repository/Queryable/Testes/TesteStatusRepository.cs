using api.Domain.Models.Testes;
using api.Domain.Repository.Interface.Testes;
using api.Domain.Views.Input.Testes;
using System.Linq;

namespace api.Domain.Repository.Queryable.Testes
{
    public class TesteStatusRepository : Repository<TesteStatus, decimal>, ITesteStatusRepository
    {
        private readonly GRCContext _context;
        public TesteStatusRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<TesteStatus> GetAll(bool active)
        {
            var data = DbSet.Where(x => x.Fl_Ativo.Equals(active)).AsQueryable();

            return data;
        }
        public bool UpdateStatus(long id)
        {
            TesteStatus data = DbSet.Where(x => x.Id_Teste_Status.Equals(id)).AsQueryable().FirstOrDefault();
            data.Fl_Ativo = data.Fl_Ativo == true ? false : true;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public bool Create(TesteStatusInput input)
        {
            TesteStatus data = new TesteStatus
            {
                Teste_Status_Nome = input.Teste_Status_Nome, 
                Fl_Ativo = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return true;
        }

        public bool Update(TesteStatusInput input)
        {
            TesteStatus data = DbSet.Where(x => x.Id_Teste_Status.Equals(input.Id_Teste_Status)).AsQueryable().FirstOrDefault();

            data.Teste_Status_Nome = input.Teste_Status_Nome; 

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }
        public bool Remove(long id)
        {
            TesteStatus data = DbSet.Where(x => x.Id_Teste_Status.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }


    }
}
