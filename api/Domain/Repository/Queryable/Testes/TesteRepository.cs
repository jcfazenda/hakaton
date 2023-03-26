using api.Domain.Models.Testes;
using api.Domain.Repository.Interface.Testes;
using api.Domain.Views.Input.Testes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace api.Domain.Repository.Queryable.Testes
{
    public class TesteRepository : Repository<Teste, decimal>, ITesteRepository
    {
        private readonly GRCContext _context;
        public TesteRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Teste> GetActive(bool active)
        {
            var data = DbSet.Where(x => x.Fl_Ativo.Equals(active)).AsQueryable();

            return data;
        }

        public IQueryable<Teste> GetAll(bool active)
        {
            var data = DbSet.Include(i => i.WorkFlowStatus)
                       .Where(x => x.Fl_Ativo.Equals(active)).AsQueryable().OrderByDescending(o => o.Data_Hora);

            return data;
        }
        public bool UpdateStatus(long id)
        {
            Teste data = DbSet.Where(x => x.Id_Teste.Equals(id)).AsQueryable().FirstOrDefault();
            data.Fl_Ativo = data.Fl_Ativo == true ? false : true;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }
        public bool UpdateStatusWorkflow(TesteInput input)
        {
            Teste data = DbSet.Where(x => x.Id_Teste.Equals(input.Id_Teste)).AsQueryable().FirstOrDefault();
            data.Id_Teste_Status = input.Id_Teste_Status;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public long Create(TesteInput input)
        {
            Teste data = new Teste
            {
                Id_Teste_Status         = 11, // input.Id_Teste_Status,
                Teste_Nome              = input.Teste_Nome,
                Teste_Descricao         = input.Teste_Descricao,
                Fl_Resultado_Efetivo    = input.Fl_Resultado_Efetivo,
                Fl_Exclusivo            = input.Fl_Exclusivo,
                Id_Usuario              = input.Id_Usuario,
                Data_Hora               = DateTime.Now,
                Fl_Ativo                = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return data.Id_Teste;
        }

        public bool UpdateExclusivo(long id)
        {
            Teste data = DbSet.Where(x => x.Id_Teste.Equals(id)).AsQueryable().FirstOrDefault();
            data.Fl_Exclusivo = data.Fl_Exclusivo == true ? false : true;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public bool Update(TesteInput input)
        {
            Teste data = DbSet.Where(x => x.Id_Teste.Equals(input.Id_Teste)).AsQueryable().FirstOrDefault();

            data.Id_Teste_Status = input.Id_Teste_Status;
            data.Teste_Nome = input.Teste_Nome;
            data.Teste_Descricao = input.Teste_Descricao;
            data.Fl_Resultado_Efetivo = input.Fl_Resultado_Efetivo; 

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }
        public bool Remove(long id)
        {
            Teste data = DbSet.Where(x => x.Id_Teste.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }


    }
}
