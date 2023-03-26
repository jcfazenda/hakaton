using api.Domain.Models.Testes;
using api.Domain.Repository.Interface.Testes;
using api.Domain.Views.Input.Testes;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace api.Domain.Repository.Queryable.Testes
{
    public class TesteProcedimentoAmostraExecucaoRepository : Repository<TesteProcedimentoAmostraExecucao, decimal>, ITesteProcedimentoAmostraExecucaoRepository
    {
        private readonly GRCContext _context;
        public TesteProcedimentoAmostraExecucaoRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<TesteProcedimentoAmostraExecucao> GetByProcedimentoAmostra(long id)
        {
            var data = DbSet.Include(i => i.TesteProcedimentoAmostra).Where(x => x.Id_Teste_Procedimento_Amostra.Equals(id) &&
                                        x.Fl_Ativo.Equals(true)).AsQueryable();

            return data;
        }

        public IQueryable<TesteProcedimentoAmostraExecucao> GetAll(bool active)
        {
            var data = DbSet.Where(x => x.Fl_Ativo.Equals(active)).AsQueryable();

            return data;
        }

        public bool UpdateStatusExecucao(long id)
        {
            TesteProcedimentoAmostraExecucao data = DbSet.Where(x => x.Id_Teste_Procedimento_Amostra_Execucao.Equals(id)).AsQueryable().FirstOrDefault();
            data.Fl_Executado = data.Fl_Executado == true ? false : true;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public bool UpdateStatus(long id)
        {
            TesteProcedimentoAmostraExecucao data = DbSet.Where(x => x.Id_Teste_Procedimento_Amostra_Execucao.Equals(id)).AsQueryable().FirstOrDefault();
            data.Fl_Ativo = data.Fl_Ativo == true ? false : true;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public long Create(TesteProcedimentoAmostraExecucaoInput input)
        {
            TesteProcedimentoAmostraExecucao data = new TesteProcedimentoAmostraExecucao
            {
                Id_Teste_Procedimento_Amostra            = input.Id_Teste_Procedimento_Amostra,
                Teste_Procedimento_Amostra_Execucao_Nome = input.Teste_Procedimento_Amostra_Execucao_Nome,
                Fl_Executado = false,
                Fl_Ativo = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return data.Id_Teste_Procedimento_Amostra_Execucao;
        }

        public bool Update(TesteProcedimentoAmostraExecucaoInput input)
        {
            TesteProcedimentoAmostraExecucao data = DbSet.Where(x => x.Id_Teste_Procedimento_Amostra_Execucao.Equals(input.Id_Teste_Procedimento_Amostra_Execucao)).AsQueryable().FirstOrDefault();

            data.Teste_Procedimento_Amostra_Execucao_Nome = input.Teste_Procedimento_Amostra_Execucao_Nome; 

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }
        public bool RemoveByProcedimentoAmostra(long id)
        {
            List<TesteProcedimentoAmostraExecucao> data = DbSet.Where(x => x.Id_Teste_Procedimento_Amostra_Execucao.Equals(id)).AsQueryable().ToList();

            foreach (var item in data)
            {
                _context.Remove(item);
                _context.SaveChanges();
            }

            return true;
        }
        public bool Remove(long id)
        {
            TesteProcedimentoAmostraExecucao data = DbSet.Where(x => x.Id_Teste_Procedimento_Amostra_Execucao.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }

    }
}
