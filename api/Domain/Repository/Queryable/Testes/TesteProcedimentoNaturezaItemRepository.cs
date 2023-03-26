using api.Domain.Models.Testes;
using api.Domain.Repository.Interface.Testes;
using api.Domain.Views.Input.Testes;
using System.Linq;

namespace api.Domain.Repository.Queryable.Testes
{
    public class TesteProcedimentoNaturezaItemRepository : Repository<TesteProcedimentoNaturezaItem, decimal>, ITesteProcedimentoNaturezaItemRepository
    {
        private readonly GRCContext _context;
        public TesteProcedimentoNaturezaItemRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<TesteProcedimentoNaturezaItem> GetAll(bool active)
        {
            var data = DbSet.Where(x => x.Fl_Ativo.Equals(active)).AsQueryable();

            return data;
        }
        public bool UpdateStatus(long id)
        {
            TesteProcedimentoNaturezaItem data = DbSet.Where(x => x.Id_Teste_Procedimento_Natureza_Item.Equals(id)).AsQueryable().FirstOrDefault();
            data.Fl_Ativo = data.Fl_Ativo == true ? false : true;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public long Create(TesteProcedimentoNaturezaItemInput input)
        {
            TesteProcedimentoNaturezaItem data = new TesteProcedimentoNaturezaItem
            {
                Teste_Procedimento_Natureza_Item_Nome = input.Teste_Procedimento_Natureza_Item_Nome,
                Fl_Ativo = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return data.Id_Teste_Procedimento_Natureza_Item;
        }

        public bool Update(TesteProcedimentoNaturezaItemInput input)
        {
            TesteProcedimentoNaturezaItem data = DbSet.Where(x => x.Id_Teste_Procedimento_Natureza_Item.Equals(input.Id_Teste_Procedimento_Natureza_Item)).AsQueryable().FirstOrDefault();

            data.Teste_Procedimento_Natureza_Item_Nome = input.Teste_Procedimento_Natureza_Item_Nome;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }
        public bool Remove(long id)
        {
            TesteProcedimentoNaturezaItem data = DbSet.Where(x => x.Id_Teste_Procedimento_Natureza_Item.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }


    }
}
