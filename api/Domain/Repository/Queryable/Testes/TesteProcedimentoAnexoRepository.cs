
using api.Domain.Models.Testes;
using api.Domain.Repository.Interface.Testes;
using api.Domain.Views.Input.Testes;
using System.Linq;

namespace api.Domain.Repository.Queryable.Testes
{
    public class TesteProcedimentoAnexoRepository : Repository<TesteProcedimentoAnexo, decimal>, ITesteProcedimentoAnexoRepository
    {
        private readonly GRCContext _context;
        public TesteProcedimentoAnexoRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<TesteProcedimentoAnexo> GetAny(bool active)
        {
            var data = DbSet.Where(x => x.Fl_Ativo.Equals(active)).AsQueryable();

            return data;
        }

        public IQueryable<TesteProcedimentoAnexo> GetByProcedimento(long id)
        {
            var data = DbSet.Where(x => x.Id_Teste_Procedimento.Equals(id)).AsQueryable();

            return data;
        }

        public bool Create(TesteProcedimentoAnexoInput input)
        {
            TesteProcedimentoAnexo data = new TesteProcedimentoAnexo
            {
                Id_Teste_Procedimento = input.Id_Teste_Procedimento,
                Teste_Procedimento_Anexo_Nome = input.Teste_Procedimento_Anexo_Nome,
                Teste_Procedimento_Anexo_Byte = input.Teste_Procedimento_Anexo_Byte,
                Fl_Ativo = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return true;
        }

        public bool Remove(long id)
        {
            TesteProcedimentoAnexo data = DbSet.Where(x => x.Id_Teste_Procedimento_Anexo.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }


    }
}
