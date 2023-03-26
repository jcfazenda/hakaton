using api.Domain.Models.Testes;
using api.Domain.Repository.Interface.Testes;
using api.Domain.Views.Input.Testes;
using System.Collections.Generic;
using System.Linq;

namespace api.Domain.Repository.Queryable.Testes
{
    public class TesteProcedimentoNaturezaRepository : Repository<TesteProcedimentoNatureza, decimal>, ITesteProcedimentoNaturezaRepository
    {
        private readonly GRCContext _context;
        public TesteProcedimentoNaturezaRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<TesteProcedimentoNatureza> GetByProcedimento(long id)
        {
            var data = DbSet.Where(x => x.Id_Teste_Procedimento.Equals(id) &&
                                        x.Fl_Ativo.Equals(true)).AsQueryable();

            return data;
        }

        public IQueryable<TesteProcedimentoNatureza> GetAll(bool active)
        {
            var data = DbSet.Where(x => x.Fl_Ativo.Equals(active)).AsQueryable();

            return data;
        }

        public bool UpdateStatus(long id)
        {
            TesteProcedimentoNatureza data = DbSet.Where(x => x.Id_Teste_Procedimento_Natureza.Equals(id)).AsQueryable().FirstOrDefault();
            data.Fl_Ativo = data.Fl_Ativo == true ? false : true;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public bool Create(TesteProcedimentoNaturezaInput input)
        {
            TesteProcedimentoNatureza data = new TesteProcedimentoNatureza
            {
                Id_Teste_Procedimento            = input.Id_Teste_Procedimento,
                Id_Teste_Procedimento_Natureza_Item = input.Id_Teste_Procedimento_Natureza_Item,
                Fl_Ativo = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return true;
        }

        public bool Update(TesteProcedimentoNaturezaInput input)
        {
            TesteProcedimentoNatureza data = DbSet.Where(x => x.Id_Teste_Procedimento_Natureza.Equals(input.Id_Teste_Procedimento_Natureza)).AsQueryable().FirstOrDefault();

            data.Id_Teste_Procedimento_Natureza_Item = input.Id_Teste_Procedimento_Natureza_Item;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }
        public bool RemoveByProcedimento(long id)
        {
            List<TesteProcedimentoNatureza> data = DbSet.Where(x => x.Id_Teste_Procedimento.Equals(id)).AsQueryable().ToList();

            foreach (var item in data)
            {
                _context.Remove(item);
                _context.SaveChanges();
            } 

            return true;
        }
        public bool Remove(long id)
        {
            TesteProcedimentoNatureza data = DbSet.Where(x => x.Id_Teste_Procedimento_Natureza.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }

    }
}
