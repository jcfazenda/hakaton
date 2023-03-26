using api.Domain.Models.Risco;
using api.Domain.Repository.Interface.Risco;
using api.Domain.Views.Input.Risco;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace api.Domain.Repository.Queryable.Risco
{
    public class RiscoAvaliacaoWorkflowRepository : Repository<RiscoAvaliacaoWorkflow, decimal>, IRiscoAvaliacaoWorkflowRepository
    {
        private readonly GRCContext _context;
        public RiscoAvaliacaoWorkflowRepository(GRCContext context) : base(context)
        {
            _context = context;
        }


        public IQueryable<RiscoAvaliacaoWorkflow> GetByRiscoAvaliacao(long id)
        {
            var data = DbSet.Include(i => i.Usuario) 
                            .Include(i => i.RiscoAvaliacaoStatus)
                            .Where(x => x.Id_Risco_Avaliacao.Equals(id)).AsQueryable();

            return data;
        }
        public IQueryable<RiscoAvaliacaoWorkflow> GetAny(bool active)
        {
            var data = DbSet.Where(x => x.Fl_Ativo.Equals(active)).AsQueryable();

            return data;
        }
        public bool UpdateStatus(long id)
        {
            RiscoAvaliacaoWorkflow data = DbSet.Where(x => x.Id_Risco_Avaliacao_Workflow.Equals(id)).AsQueryable().FirstOrDefault();
            data.Fl_Ativo = data.Fl_Ativo == true ? false : true;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public long Create(RiscoAvaliacaoWorkflowInput input)
        {
            RiscoAvaliacaoWorkflow data = new RiscoAvaliacaoWorkflow
            {
                Id_Risco_Avaliacao_Workflow_Resposta    = input.Id_Risco_Avaliacao_Workflow_Resposta,
                Id_Risco_Avaliacao                      = input.Id_Risco_Avaliacao,
                Id_Risco                                = input.Id_Risco,
                Id_Risco_Avaliacao_Status               = input.Id_Risco_Avaliacao_Status,
                Id_Usuario                              = input.Id_Usuario,

                Risco_Avaliacao_Workflow_Nome           = input.Risco_Avaliacao_Workflow_Nome,
                Risco_Avaliacao_Workflow_Descricao      = input.Risco_Avaliacao_Workflow_Descricao, 
                Data_Evento                             = DateTime.Now,

                Fl_Ativo = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return data.Id_Risco_Avaliacao_Workflow;
        }

        public bool Update(RiscoAvaliacaoWorkflowInput input)
        {
            RiscoAvaliacaoWorkflow data = DbSet.Where(x => x.Id_Risco_Avaliacao_Workflow.Equals(input.Id_Risco_Avaliacao_Workflow)).AsQueryable().FirstOrDefault();

            data.Id_Risco_Avaliacao_Workflow_Resposta   = input.Id_Risco_Avaliacao_Workflow_Resposta;
            data.Id_Risco_Avaliacao                     = input.Id_Risco_Avaliacao;
            data.Id_Risco                               = input.Id_Risco;
            data.Id_Risco_Avaliacao_Status              = input.Id_Risco_Avaliacao_Status;
            data.Id_Usuario                             = input.Id_Usuario;

            data.Risco_Avaliacao_Workflow_Nome          = input.Risco_Avaliacao_Workflow_Nome;
            data.Risco_Avaliacao_Workflow_Descricao     = input.Risco_Avaliacao_Workflow_Descricao; 

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }
        public bool Remove(long id)
        {
            RiscoAvaliacaoWorkflow data = DbSet.Where(x => x.Id_Risco_Avaliacao_Workflow.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }


    }
}
