using api.Domain.Models.Testes;
using api.Domain.Repository.Interface.Testes;
using api.Domain.Views.Input.Testes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Globalization;
using System.Linq;

namespace api.Domain.Repository.Queryable.Testes
{
    public class TesteProcedimentoRepository : Repository<TesteProcedimento, decimal>, ITesteProcedimentoRepository
    {
        private readonly GRCContext _context;
        public TesteProcedimentoRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<TesteProcedimento> GetAll(bool active)
        {
            var data = DbSet.Include(i => i.TesteProcedimentoTipo).Where(x => x.Fl_Ativo.Equals(active)).AsQueryable();

            return data;
        } 
        public IQueryable<TesteProcedimento> GetByTeste(long id)
        {
            var data = DbSet.Include(i => i.TesteProcedimentoTipo)
                            .Where(x => x.Id_Teste.Equals(id)).OrderBy(o => o.Data_Inicio).AsQueryable();

            return data;
        }


        public bool UpdateStatus(long id)
        {
            TesteProcedimento data = DbSet.Where(x => x.Id_Teste_Procedimento.Equals(id)).AsQueryable().FirstOrDefault();
            data.Fl_Ativo = data.Fl_Ativo == true ? false : true;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public long Create(TesteProcedimentoInput input)
        {
            DateTime dtInicio = DateTime.ParseExact(input.Data_Inicio.ToString(), "dd/MM/yyyy", CultureInfo.CurrentUICulture.DateTimeFormat);
            DateTime dtFim = DateTime.ParseExact(input.Data_Fim.ToString(), "dd/MM/yyyy", CultureInfo.CurrentUICulture.DateTimeFormat);

            TesteProcedimento data = new TesteProcedimento
            {
                Id_Teste_Procedimento_Tipo      = input.Id_Teste_Procedimento_Tipo,
                Id_Teste                        = input.Id_Teste,

                Teste_Procedimento_Nome         = input.Teste_Procedimento_Nome,
                Teste_Procedimento_Descricao    = input.Teste_Procedimento_Descricao,
                Data_Inicio                     = dtInicio,
                Data_Fim                        = dtFim,
                Fl_Efetivo                      = input.Fl_Efetivo,
                Fl_Ativo                        = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return data.Id_Teste_Procedimento;

        }

        public bool Update(TesteProcedimentoInput input)
        { 
                DateTime dtInicio = DateTime.ParseExact(input.Data_Inicio.ToString(), "dd/MM/yyyy", CultureInfo.CurrentUICulture.DateTimeFormat);
                DateTime dtFim    = DateTime.ParseExact(input.Data_Fim.ToString(), "dd/MM/yyyy", CultureInfo.CurrentUICulture.DateTimeFormat);

                TesteProcedimento data = DbSet.Where(x => x.Id_Teste_Procedimento.Equals((long)input.Id_Teste_Procedimento)).AsQueryable().FirstOrDefault();

                data.Id_Teste_Procedimento_Tipo         = input.Id_Teste_Procedimento_Tipo; 
                data.Id_Teste                           = input.Id_Teste;

                data.Teste_Procedimento_Nome            = input.Teste_Procedimento_Nome;
                data.Teste_Procedimento_Descricao       = input.Teste_Procedimento_Descricao;
                data.Data_Inicio                        = dtInicio;
                data.Data_Fim                           = dtFim;
                data.Fl_Efetivo                         = input.Fl_Efetivo;

                _context.Update(data);
                _context.SaveChanges();

                return true; 

        }
        public bool Remove(long id)
        {
            TesteProcedimento data = DbSet.Where(x => x.Id_Teste_Procedimento.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }


    }
}
