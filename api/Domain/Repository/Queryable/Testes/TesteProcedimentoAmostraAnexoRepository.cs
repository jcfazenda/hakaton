
using api.Domain.Models.Testes;
using api.Domain.Repository.Interface.Testes;
using api.Domain.Views.Input.Testes;
using System.Collections.Generic;
using System.Linq;

namespace api.Domain.Repository.Queryable.Testes
{
    public class TesteProcedimentoAmostraAnexoRepository : Repository<TesteProcedimentoAmostraAnexo, decimal>, ITesteProcedimentoAmostraAnexoRepository
    {
        private readonly GRCContext _context;
        public TesteProcedimentoAmostraAnexoRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<TesteProcedimentoAmostraAnexo> GetAny(bool active)
        {
            var data = DbSet.Where(x => x.Fl_Ativo.Equals(active)).AsQueryable();

            return data;
        }

        public IQueryable<TesteProcedimentoAmostraAnexo> GetByProcedimento(long id)
        {
            var data = DbSet.Where(x => x.Id_Teste_Procedimento.Equals(id)).AsQueryable();

            return data;
        }

        public bool Create(TesteProcedimentoAmostraAnexoInput input)
        {
            TesteProcedimentoAmostraAnexo data = new TesteProcedimentoAmostraAnexo
            {
                Id_Teste_Procedimento = input.Id_Teste_Procedimento,
                Teste_Procedimento_Amostra_Anexo_Nome = input.Teste_Procedimento_Amostra_Anexo_Nome,
                Teste_Procedimento_Amostra_Anexo_Byte = input.Teste_Procedimento_Amostra_Anexo_Byte,
                Fl_Ativo = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return true;
        }

        public bool RemoveByProcedimento(long id)
        {
            List<TesteProcedimentoAmostraAnexo> data = DbSet.Where(x => x.Id_Teste_Procedimento.Equals(id)).AsQueryable().ToList();

            foreach (var item in data)
            {
                _context.Remove(item);
                _context.SaveChanges();
            }

            return true;
        }

        public bool Remove(long id)
        {
            TesteProcedimentoAmostraAnexo data = DbSet.Where(x => x.Id_Teste_Procedimento_Amostra_Anexo.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }


    }
}
