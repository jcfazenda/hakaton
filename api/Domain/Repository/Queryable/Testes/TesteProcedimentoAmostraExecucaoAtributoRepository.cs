using api.Domain.Models.Testes;
using api.Domain.Repository.Interface.Testes;
using api.Domain.Views.Input.Testes;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace api.Domain.Repository.Queryable.Testes
{
    public class TesteProcedimentoAmostraExecucaoAtributoRepository : Repository<TesteProcedimentoAmostraExecucaoAtributo, decimal>, ITesteProcedimentoAmostraExecucaoAtributoRepository
    {
        private readonly GRCContext _context;
        public TesteProcedimentoAmostraExecucaoAtributoRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<TesteProcedimentoAmostraExecucaoAtributo> GetByProcedimentoAmostraExecucaoAtributo(long id)
        {
            var data = DbSet.Where(x => x.Id_Teste_Procedimento_Amostra_Execucao_Atributo.Equals(id)).AsQueryable();

            return data;
        }

        public IQueryable<TesteProcedimentoAmostraExecucaoAtributo> GetByProcedimentoAmostraExecucao(long id)
        {
            var data = DbSet.Where(x => x.Id_Teste_Procedimento_Amostra_Execucao.Equals(id) &&
                                        x.Fl_Ativo.Equals(true)).AsQueryable();

            return data;
        }

        public IQueryable<TesteProcedimentoAmostraExecucaoAtributo> GetAll(bool active)
        {
            var data = DbSet.Where(x => x.Fl_Ativo.Equals(active)).AsQueryable();

            return data;
        }

        public bool UpdateStatusExecucaoAtributo(long id)
        {
            TesteProcedimentoAmostraExecucaoAtributo data = DbSet.Where(x => x.Id_Teste_Procedimento_Amostra_Execucao_Atributo.Equals(id)).AsQueryable().FirstOrDefault();
            data.Fl_Executado = data.Fl_Executado == true ? false : true;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }
 
        public bool UpdateStatus(long id)
        {
            TesteProcedimentoAmostraExecucaoAtributo data = DbSet.Where(x => x.Id_Teste_Procedimento_Amostra_Execucao.Equals(id)).AsQueryable().FirstOrDefault();
            data.Fl_Ativo = data.Fl_Ativo == true ? false : true;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public bool Create(TesteProcedimentoAmostraExecucaoAtributoInput input)
        {
            TesteProcedimentoAmostraExecucaoAtributo data = new TesteProcedimentoAmostraExecucaoAtributo
            {
                Id_Teste_Procedimento_Amostra_Execucao = input.Id_Teste_Procedimento_Amostra_Execucao,
                Id_Teste_Procedimento_Amostra = input.Id_Teste_Procedimento_Amostra,
                Teste_Procedimento_Amostra_Execucao_Atributo_Nome = input.Teste_Procedimento_Amostra_Execucao_Atributo_Nome,
                Fl_Executado = false,
                Fl_Ativo = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return true;
        }

        public bool Update(TesteProcedimentoAmostraExecucaoAtributoInput input)
        { 
            List<TesteProcedimentoAmostraExecucaoAtributo> data = DbSet.Where(x => x.Id_Teste_Procedimento_Amostra.Equals(input.Id_Teste_Procedimento_Amostra)
                                                                           && x.Teste_Procedimento_Amostra_Execucao_Atributo_Nome.Equals(input.Teste_Procedimento_Amostra_Execucao_Atributo_Nome_Old)).AsQueryable().ToList();

            foreach (var item in data)
            {
                item.Teste_Procedimento_Amostra_Execucao_Atributo_Nome = input.Teste_Procedimento_Amostra_Execucao_Atributo_Nome;

                _context.Update(item);
                _context.SaveChanges();
            }


            return true;
        }
        public bool RemoveByProcedimentoAmostraExecucao(long id)
        {
            List<TesteProcedimentoAmostraExecucaoAtributo> data = DbSet.Where(x => x.Id_Teste_Procedimento_Amostra_Execucao_Atributo.Equals(id)).AsQueryable().ToList();

            foreach (var item in data)
            {
                _context.Remove(item);
                _context.SaveChanges();
            }

            return true;
        }
        public bool RemoveByProcedimentoAmostra(TesteProcedimentoAmostraExecucaoAtributoInput input)
        {
            List<TesteProcedimentoAmostraExecucaoAtributo> data = DbSet.Where(x => x.Id_Teste_Procedimento_Amostra.Equals(input.Id_Teste_Procedimento_Amostra)
                                                                           && x.Teste_Procedimento_Amostra_Execucao_Atributo_Nome.Equals(input.Teste_Procedimento_Amostra_Execucao_Atributo_Nome)).AsQueryable().ToList();

            foreach (var item in data)
            {
                _context.Remove(item);
                _context.SaveChanges();
            }

            return true;
        }

        public bool Remove(long id)
        {
            TesteProcedimentoAmostraExecucaoAtributo data = DbSet.Where(x => x.Id_Teste_Procedimento_Amostra_Execucao_Atributo.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }

    }
}
