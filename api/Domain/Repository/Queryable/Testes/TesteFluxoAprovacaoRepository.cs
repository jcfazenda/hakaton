using api.Domain.Models.Testes;
using api.Domain.Repository.Interface.Testes;
using api.Domain.Views.Input.Testes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace api.Domain.Repository.Queryable.Testes
{
    public class TesteFluxoAprovacaoRepository : Repository<TesteFluxoAprovacao, decimal>, ITesteFluxoAprovacaoRepository
    {
        private readonly GRCContext _context;
        public TesteFluxoAprovacaoRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

 
        public IQueryable<TesteFluxoAprovacao> GetAny(bool active)
        {
            var data = DbSet.Where(x => x.Fl_Ativo.Equals(active)).AsQueryable();

            return data;
        }

        public IQueryable<TesteFluxoAprovacao> GetByTeste(long id)
        {
            var data = DbSet.Include(i => i.WorkFlowStatus)
                            .Include(i => i.Usuarios)
                            .Where(x => x.Id_Teste.Equals(id)).AsQueryable();

            return data;
        }

        public bool UpdateStatusworkFlow(TesteFluxoAprovacaoInput input)
        {
            TesteFluxoAprovacao data = DbSet.Where(x => x.Id_Teste_Fluxo_Aprovacao.Equals(input.Id_Teste_Fluxo_Aprovacao)).AsQueryable().FirstOrDefault();
            data.Id_Workflow_Status = input.Id_Workflow_Status; 
            data.Data_Evento        = DateTime.Now;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public bool UpdateStatus(long id)
        {
            TesteFluxoAprovacao data = DbSet.Where(x => x.Id_Teste_Fluxo_Aprovacao.Equals(id)).AsQueryable().FirstOrDefault();
            data.Fl_Ativo = data.Fl_Ativo == true ? false : true;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public bool SaveObservacao(TesteFluxoAprovacaoInput input)
        {
            TesteFluxoAprovacao data = DbSet.Where(x => x.Id_Teste_Fluxo_Aprovacao.Equals(input.Id_Teste_Fluxo_Aprovacao)).AsQueryable().FirstOrDefault();
            data.Workflow_Status_Observacao = input.Workflow_Status_Observacao;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public long Create(TesteFluxoAprovacaoInput input)
        {
            TesteFluxoAprovacao data = new TesteFluxoAprovacao
            {
                Id_Workflow_Status  = 4,
                Id_Teste            = input.Id_Teste,
                Id_Usuario          = input.Id_Usuario,
                Workflow_Status_Observacao = input.Workflow_Status_Observacao,
                Data_Evento         = DateTime.Now, 
                Fl_Ativo            = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return data.Id_Teste_Fluxo_Aprovacao;
        }
 
        public bool Remove(long id)
        {
            TesteFluxoAprovacao data = DbSet.Where(x => x.Id_Teste_Fluxo_Aprovacao.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }

    }
}
