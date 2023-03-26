using api.Domain.Models.PlanosAcao;
using api.Domain.Repository.Interface.PlanosAcao;
using api.Domain.Views.Input.PlanosAcao;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace api.Domain.Repository.Queryable.PlanosAcao
{
    public class PlanoAcaoFluxoAprovacaoRepository : Repository<PlanoAcaoFluxoAprovacao, decimal>, IPlanoAcaoFluxoAprovacaoRepository
    {
        private readonly GRCContext _context;
        public PlanoAcaoFluxoAprovacaoRepository(GRCContext context) : base(context)
        {
            _context = context;
        }


        public IQueryable<PlanoAcaoFluxoAprovacao> GetAny(bool active)
        {
            var data = DbSet.Where(x => x.Fl_Ativo.Equals(active)).AsQueryable();

            return data;
        }

        public IQueryable<PlanoAcaoFluxoAprovacao> GetByPlanoAcao(long id)
        {
            var data = DbSet.Include(i => i.WorkFlowStatus)
                            .Include(i => i.Usuarios)
                            .Where(x => x.Id_Plano_Acao.Equals(id)).AsQueryable();

            return data;
        }

        public bool UpdateStatusworkFlow(PlanoAcaoFluxoAprovacaoInput input)
        {
            PlanoAcaoFluxoAprovacao data = DbSet.Where(x => x.Id_Plano_Acao_Fluxo_Aprovacao.Equals(input.Id_Plano_Acao_Fluxo_Aprovacao)).AsQueryable().FirstOrDefault();
            data.Id_Workflow_Status = input.Id_Workflow_Status;
            data.Data_Evento = DateTime.Now;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public bool UpdateStatus(long id)
        {
            PlanoAcaoFluxoAprovacao data = DbSet.Where(x => x.Id_Plano_Acao_Fluxo_Aprovacao.Equals(id)).AsQueryable().FirstOrDefault();
            data.Fl_Ativo = data.Fl_Ativo == true ? false : true;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public bool SaveObservacao(PlanoAcaoFluxoAprovacaoInput input)
        {
            PlanoAcaoFluxoAprovacao data = DbSet.Where(x => x.Id_Plano_Acao_Fluxo_Aprovacao.Equals(input.Id_Plano_Acao_Fluxo_Aprovacao)).AsQueryable().FirstOrDefault();
            data.Workflow_Status_Observacao = input.Workflow_Status_Observacao;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public long Create(PlanoAcaoFluxoAprovacaoInput input)
        {
            PlanoAcaoFluxoAprovacao data = new PlanoAcaoFluxoAprovacao
            {
                Id_Workflow_Status = 4,
                Id_Plano_Acao = input.Id_Plano_Acao,
                Id_Usuario = input.Id_Usuario,
                Workflow_Status_Observacao = input.Workflow_Status_Observacao,
                Data_Evento = DateTime.Now,
                Fl_Ativo = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return data.Id_Plano_Acao_Fluxo_Aprovacao;
        }

        public bool Remove(long id)
        {
            PlanoAcaoFluxoAprovacao data = DbSet.Where(x => x.Id_Plano_Acao_Fluxo_Aprovacao.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }

    }
}
