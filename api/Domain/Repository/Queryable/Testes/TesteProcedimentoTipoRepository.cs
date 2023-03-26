using api.Domain.Models.Testes;
using api.Domain.Repository.Interface.Testes;
using api.Domain.Views.Input.Testes;
using System.Linq;

namespace api.Domain.Repository.Queryable.Testes
{
    public class TesteProcedimentoTipoRepository : Repository<TesteProcedimentoTipo, decimal>, ITesteProcedimentoTipoRepository
    {
        private readonly GRCContext _context;
        public TesteProcedimentoTipoRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<TesteProcedimentoTipo> GetAll(bool active)
        {
            var data = DbSet.Where(x => x.Fl_Ativo.Equals(active)).AsQueryable();

            return data;
        }
        public bool UpdateStatus(long id)
        {
            TesteProcedimentoTipo data = DbSet.Where(x => x.Id_Teste_Procedimento_Tipo.Equals(id)).AsQueryable().FirstOrDefault();
            data.Fl_Ativo = data.Fl_Ativo == true ? false : true;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public bool Create(TesteProcedimentoTipoInput input)
        {
            TesteProcedimentoTipo data = new TesteProcedimentoTipo
            {
                Teste_Procedimento_Tipo_Nome = input.Teste_Procedimento_Tipo_Nome, 
                Fl_Ativo = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return true;
        }

        public bool Update(TesteProcedimentoTipoInput input)
        {
            TesteProcedimentoTipo data = DbSet.Where(x => x.Id_Teste_Procedimento_Tipo.Equals(input.Id_Teste_Procedimento_Tipo)).AsQueryable().FirstOrDefault();

            data.Teste_Procedimento_Tipo_Nome = input.Teste_Procedimento_Tipo_Nome;  

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }
        public bool Remove(long id)
        {
            TesteProcedimentoTipo data = DbSet.Where(x => x.Id_Teste_Procedimento_Tipo.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }


    }
}
