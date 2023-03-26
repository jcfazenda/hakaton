using api.Domain.Models.Testes;
using api.Domain.Repository.Interface.Testes;
using api.Domain.Views.Input.Testes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace api.Domain.Repository.Queryable.Testes
{
    public class TesteStatusHistoricoRepository : Repository<TesteStatusHistorico, decimal>, ITesteStatusHistoricoRepository
    {
        private readonly GRCContext _context;
        public TesteStatusHistoricoRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<TesteStatusHistorico> GetByTeste(long id)
        {
            var data = DbSet.Include(i => i.WorkFlowStatus)
                            .Include(i => i.Usuarios)
                            .Where(x => x.Id_Teste.Equals(id)).AsQueryable();

            return data;
        }
 
        public bool Create(TesteStatusHistoricoInput input)
        {
            TesteStatusHistorico data = new TesteStatusHistorico
            {
                Id_Teste                = input.Id_Teste,
                Id_Workflow_Status = input.Id_Workflow_Status,
                Id_Usuario              = input.Id_Usuario,
                Teste_Status_Descricao  = input.Teste_Status_Descricao,
                Data_Hora               = DateTime.Now, 
                Fl_Ativo                = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return true;
        }
 
        public bool Remove(long id)
        {
            TesteStatusHistorico data = DbSet.Where(x => x.Id_Teste_Status_Historico.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }


    }
}
