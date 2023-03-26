using api.Domain.Models.Risco;
using api.Domain.Repository.Interface.Risco;
using api.Domain.Views.Input.Risco;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace api.Domain.Repository.Queryable.Risco
{
    public class RiscoAvaliacaoWorkflowAnexoRepository : Repository<RiscoAvaliacaoWorkflowAnexo, decimal>, IRiscoAvaliacaoWorkflowAnexoRepository
    {
        private readonly GRCContext _context;
        public RiscoAvaliacaoWorkflowAnexoRepository(GRCContext context) : base(context)
        {
            _context = context;
        }


        public IQueryable<RiscoAvaliacaoWorkflowAnexo> GetByRiscoAvaliacaoWorkflow(long id)
        {
            var data = DbSet.Where(x => x.Id_Risco_Avaliacao_Workflow.Equals(id)).AsQueryable();

            return data;
        }
        public IQueryable<RiscoAvaliacaoWorkflowAnexo> GetAny(bool active)
        {
            var data = DbSet.Where(x => x.Fl_Ativo.Equals(active)).AsQueryable();

            return data;
        }
        public bool UpdateStatus(long id)
        {
            RiscoAvaliacaoWorkflowAnexo data = DbSet.Where(x => x.Id_Risco_Avaliacao_Workflow_Anexo.Equals(id)).AsQueryable().FirstOrDefault();
            data.Fl_Ativo = data.Fl_Ativo == true ? false : true;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public bool Create(RiscoAvaliacaoWorkflowAnexoInput input)
        {
            RiscoAvaliacaoWorkflowAnexo data = new RiscoAvaliacaoWorkflowAnexo
            {
                Id_Risco_Avaliacao_Workflow = input.Id_Risco_Avaliacao_Workflow,
                Risco_Avaliacao_Workflow_Anexo_Nome = input.Risco_Avaliacao_Workflow_Anexo_Nome,
                Risco_Avaliacao_Workflow_Anexo_Byte = input.Risco_Avaliacao_Workflow_Anexo_Byte,
                Fl_Ativo = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return true;
        }

        public bool Update(RiscoAvaliacaoWorkflowAnexoInput input)
        {
            RiscoAvaliacaoWorkflowAnexo data = DbSet.Where(x => x.Id_Risco_Avaliacao_Workflow.Equals(input.Id_Risco_Avaliacao_Workflow)).AsQueryable().FirstOrDefault();

            data.Id_Risco_Avaliacao_Workflow = input.Id_Risco_Avaliacao_Workflow;
            data.Risco_Avaliacao_Workflow_Anexo_Nome = input.Risco_Avaliacao_Workflow_Anexo_Nome;
            data.Risco_Avaliacao_Workflow_Anexo_Byte = input.Risco_Avaliacao_Workflow_Anexo_Byte; 

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }
        public bool Remove(long id)
        {
            RiscoAvaliacaoWorkflowAnexo data = DbSet.Where(x => x.Id_Risco_Avaliacao_Workflow_Anexo.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }


    }
}
