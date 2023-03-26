using api.Domain.Models.Incidentes;
using api.Domain.Repository.Interface.Incidentes;
using api.Domain.Views.Input.Incidentes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace api.Domain.Repository.Queryable.Incidentes
{
    public class IncidenteFluxoAprovacaoRepository : Repository<IncidenteFluxoAprovacao, decimal>, IIncidenteFluxoAprovacaoRepository
    {
        private readonly GRCContext _context;
        public IncidenteFluxoAprovacaoRepository(GRCContext context) : base(context)
        {
            _context = context;
        }


        public IQueryable<IncidenteFluxoAprovacao> GetAny(bool active)
        {
            var data = DbSet.AsQueryable();

            return data;
        }

        public IQueryable<IncidenteFluxoAprovacao> GetByIncidente(long id)
        {
            var data = DbSet.Include(i => i.WorkFlowStatus)
                            .Include(i => i.Usuarios)
                            .Where(x => x.Id_Incidente.Equals(id)).AsQueryable();

            return data;
        }

        public IQueryable<IncidenteFluxoAprovacao> GetByRiscoAvaliacaoIncidente(long idRiscoAvaliacao, long idIncidente)
        {
            var data = DbSet.Include(i => i.WorkFlowStatus)
                            .Include(i => i.Usuarios)
                            .Where(x => x.Id_Incidente.Equals(idIncidente) && x.Id_Risco_Avaliacao.Equals(idRiscoAvaliacao)).AsQueryable();

            return data;
        }


        public bool UpdateStatusworkFlow(IncidenteFluxoAprovacaoInput input)
        { 

            IncidenteFluxoAprovacao data = DbSet.Where(x => x.Id_Incidente_Fluxo_Aprovacao.Equals(input.Id_Incidente_Fluxo_Aprovacao)).AsQueryable().FirstOrDefault();
            data.Id_Workflow_Status = input.Id_Workflow_Status;
            data.Data_Evento        = DateTime.Now;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public bool UpdateStatus(long id)
        {
            IncidenteFluxoAprovacao data = DbSet.Where(x => x.Id_Incidente_Fluxo_Aprovacao.Equals(id)).AsQueryable().FirstOrDefault(); 

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public bool SaveObservacao(IncidenteFluxoAprovacaoInput input)
        {
            IncidenteFluxoAprovacao data = DbSet.Where(x => x.Id_Incidente_Fluxo_Aprovacao.Equals(input.Id_Incidente_Fluxo_Aprovacao)).AsQueryable().FirstOrDefault();
            data.Workflow_Status_Observacao = input.Workflow_Status_Observacao;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public long Create(IncidenteFluxoAprovacaoInput input)
        {
            try
            {
                IncidenteFluxoAprovacao data = new IncidenteFluxoAprovacao
                {
                    Id_Workflow_Status = 4,
                    Id_Incidente = input.Id_Incidente,
                    Id_Risco_Avaliacao = input.Id_Risco_Avaliacao,
                    Id_Usuario = input.Id_Usuario,
                    Workflow_Status_Observacao = input.Workflow_Status_Observacao,
                    Data_Evento = DateTime.Now,
                };

                _context.Add(data);
                _context.SaveChanges();

                return data.Id_Incidente_Fluxo_Aprovacao;
            }
            catch (Exception )
            {

                throw;
            }

        }

        public bool Remove(long id)
        {
            IncidenteFluxoAprovacao data = DbSet.Where(x => x.Id_Incidente_Fluxo_Aprovacao.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }

    }
}
