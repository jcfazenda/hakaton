using api.Domain.Models.Testes;
using api.Domain.Repository.Interface.Testes;
using api.Domain.Views.Input.Testes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace api.Domain.Repository.Queryable.Testes
{
    public class TesteApontamentoTesteRepository : Repository<TesteApontamentoTeste, decimal>, ITesteApontamentoTesteRepository
    {
        private readonly GRCContext _context;
        public TesteApontamentoTesteRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<TesteApontamentoTeste> GetAny(bool active)
        {
            var data = DbSet.Where(x => x.Fl_Ativo.Equals(active)).AsQueryable();

            return data;
        }
        public IQueryable<TesteApontamentoTeste> GetByTeste(long id)
        {
            var data = DbSet.Include(i => i.Apontamento).Where(x => x.Id_Teste.Equals(id)).AsQueryable();

            return data;
        }

        public IQueryable<TesteApontamentoTeste> GetByTesteApontamento(long idPlanoAcao, long idApontamento)
        {
            var data = DbSet.Where(x => x.Id_Teste.Equals(idPlanoAcao) && x.Id_Apontamento.Equals(idApontamento)).AsQueryable();
            return data;

        }

        public long Create(TesteApontamentoTesteInput input)
        {
            TesteApontamentoTeste data = new TesteApontamentoTeste
            {
                Id_Apontamento = input.Id_Apontamento,
                Id_Teste = input.Id_Teste, 
                Fl_Ativo = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return data.Id_Apontamento;
        }
 
        public bool Remove(long id)
        {
            TesteApontamentoTeste data = DbSet.Where(x => x.Id_Teste_Apontamento_Teste.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }


    }
}
