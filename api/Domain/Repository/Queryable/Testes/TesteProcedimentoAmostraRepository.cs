using api.Domain.Models.Testes;
using api.Domain.Repository.Interface.Testes;
using api.Domain.Views.Input.Testes;
using System.Collections.Generic;
using System.Linq;

namespace api.Domain.Repository.Queryable.Testes
{
    public class TesteProcedimentoAmostraRepository : Repository<TesteProcedimentoAmostra, decimal>, ITesteProcedimentoAmostraRepository
    {
        private readonly GRCContext _context;
        public TesteProcedimentoAmostraRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<TesteProcedimentoAmostra> GetByProcedimento(long id)
        {
            var data = DbSet.Where(x => x.Id_Teste_Procedimento.Equals(id) &&
                                        x.Fl_Ativo.Equals(true)).AsQueryable();

            return data;
        }

        public IQueryable<TesteProcedimentoAmostra> GetAll(bool active)
        {
            var data = DbSet.Where(x => x.Fl_Ativo.Equals(active)).AsQueryable();

            return data;
        }

        public bool UpdateStatus(long id)
        {
            TesteProcedimentoAmostra data = DbSet.Where(x => x.Id_Teste_Procedimento_Amostra.Equals(id)).AsQueryable().FirstOrDefault();
            data.Fl_Ativo = data.Fl_Ativo == true ? false : true;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public bool Create(TesteProcedimentoAmostraInput input)
        {
            TesteProcedimentoAmostra data = new TesteProcedimentoAmostra
            {
                Id_Teste_Procedimento = input.Id_Teste_Procedimento,
                Teste_Procedimento_Amostra_Nome = input.Teste_Procedimento_Amostra_Nome,
                Teste_Procedimento_Amostra_Descricao = input.Teste_Procedimento_Amostra_Descricao,
                Fl_Ativo = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return true;
        }

        public bool Update(TesteProcedimentoAmostraInput input)
        {
            TesteProcedimentoAmostra data = DbSet.Where(x => x.Id_Teste_Procedimento_Amostra.Equals(input.Id_Teste_Procedimento_Amostra)).AsQueryable().FirstOrDefault();
             
            data.Teste_Procedimento_Amostra_Nome = input.Teste_Procedimento_Amostra_Nome;
            data.Teste_Procedimento_Amostra_Descricao = input.Teste_Procedimento_Amostra_Descricao;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }
        public bool RemoveByProcedimento(long id)
        {
            List<TesteProcedimentoAmostra> data = DbSet.Where(x => x.Id_Teste_Procedimento.Equals(id)).AsQueryable().ToList();

            foreach (var item in data)
            {
                _context.Remove(item);
                _context.SaveChanges();
            }

            return true;
        }
        public bool Remove(long id)
        {
            TesteProcedimentoAmostra data = DbSet.Where(x => x.Id_Teste_Procedimento_Amostra.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }

    }
}
