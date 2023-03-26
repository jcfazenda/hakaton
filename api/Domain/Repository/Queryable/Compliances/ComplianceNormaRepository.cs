
using api.Domain.Models.Compliances;
using api.Domain.Repository.Interface.Compliances;
using api.Domain.Views.Input.Compliances;
using Microsoft.EntityFrameworkCore;
using System;
using System.Globalization;
using System.Linq;

namespace api.Domain.Repository.Queryable.Compliances
{
    public class ComplianceNormaRepository : Repository<ComplianceNorma, decimal>, IComplianceNormaRepository
    {
        private readonly GRCContext _context;
        public ComplianceNormaRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<ComplianceNorma> GetAny(bool active)
        {
            var data = DbSet.Where(x => x.Fl_Ativo.Equals(active)).Include(i => i.ComplianceNormaTipo)
                            .Include(i => i.OrgaoRegulador).AsQueryable();

            return data;
        }
        public bool UpdateStatus(long id)
        {
            ComplianceNorma data = DbSet.Where(x => x.Id_Compliance_Norma.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public long Create(ComplianceNormaInput input)
        {
            if (input.Data_Publicacao == null)      { input.Data_Publicacao      = DateTime.Now.ToString(); }
            if (input.Data_Inicio_Vigencia == null) { input.Data_Inicio_Vigencia = DateTime.Now.ToString(); }
            if (input.Data_Proxima_Revisao == null) { input.Data_Proxima_Revisao = "01/01/2030"; }

            DateTime Data_Publicacao      = DateTime.ParseExact(input.Data_Publicacao.ToString(), "dd/MM/yyyy", CultureInfo.CurrentUICulture.DateTimeFormat);
            DateTime Data_Inicio_Vigencia = DateTime.ParseExact(input.Data_Inicio_Vigencia.ToString(), "dd/MM/yyyy", CultureInfo.CurrentUICulture.DateTimeFormat);
            DateTime Data_Proxima_Revisao = DateTime.ParseExact(input.Data_Proxima_Revisao.ToString(), "dd/MM/yyyy", CultureInfo.CurrentUICulture.DateTimeFormat);

            ComplianceNorma data = new ComplianceNorma
            {
                Id_Compliance_Norma_Tipo    = input.Id_Compliance_Norma_Tipo,
                Id_Orgao_Regulador          = input.Id_Orgao_Regulador,
                Data_Publicacao             = Data_Publicacao,
                Data_Inicio_Vigencia        = Data_Inicio_Vigencia,
                Compliance_Norma_Nome       = input.Compliance_Norma_Nome,

                Compliance_Norma_Descricao          = input.Compliance_Norma_Descricao,
                Compliance_Norma_Conclusao_Analise  = input.Compliance_Norma_Conclusao_Analise,
                Compliance_Anexo_Byte               = input.Compliance_Anexo_Byte,
                Compliance_Anexo_Nome = input.Compliance_Anexo_Nome,

                Id_Norma_Criticidade    = input.Id_Norma_Criticidade,
                Id_Periodo_Revisao      = input.Id_Periodo_Revisao,
                Id_Usuario_Gestor       = input.Id_Usuario_Gestor,
                Data_Proxima_Revisao    = Data_Proxima_Revisao,
                Fl_Revisao_Manual       = input.Fl_Revisao_Manual,
                Fl_Ativo                = true,
            };

            _context.Add(data);
            _context.SaveChanges();

            return data.Id_Compliance_Norma;
        }

        public long Update(ComplianceNormaInput input)
        {
            if (input.Data_Publicacao      == null) { input.Data_Publicacao = DateTime.Now.ToString(); }
            if (input.Data_Inicio_Vigencia == null) { input.Data_Inicio_Vigencia = DateTime.Now.ToString(); }
            if (input.Data_Proxima_Revisao == null) { input.Data_Proxima_Revisao = "01/01/2030"; }

            DateTime Data_Publicacao = DateTime.ParseExact(input.Data_Publicacao.ToString(), "dd/MM/yyyy", CultureInfo.CurrentUICulture.DateTimeFormat);
            DateTime Data_Inicio_Vigencia = DateTime.ParseExact(input.Data_Inicio_Vigencia.ToString(), "dd/MM/yyyy", CultureInfo.CurrentUICulture.DateTimeFormat);
            DateTime Data_Proxima_Revisao = DateTime.ParseExact(input.Data_Proxima_Revisao.ToString(), "dd/MM/yyyy", CultureInfo.CurrentUICulture.DateTimeFormat);

            ComplianceNorma data = DbSet.Where(x => x.Id_Compliance_Norma.Equals(input.Id_Compliance_Norma)).AsQueryable().FirstOrDefault();

            data.Id_Compliance_Norma_Tipo   = input.Id_Compliance_Norma_Tipo;
            data.Id_Orgao_Regulador         = input.Id_Orgao_Regulador;
            data.Data_Publicacao            = Data_Publicacao;
            data.Data_Inicio_Vigencia       = Data_Inicio_Vigencia;
            data.Compliance_Norma_Nome      = input.Compliance_Norma_Nome;

            data.Compliance_Norma_Descricao         = input.Compliance_Norma_Descricao;
            data.Compliance_Norma_Conclusao_Analise = input.Compliance_Norma_Conclusao_Analise;
            data.Compliance_Anexo_Byte              = input.Compliance_Anexo_Byte;
            data.Compliance_Anexo_Nome = input.Compliance_Anexo_Nome;

            data.Id_Norma_Criticidade       = input.Id_Norma_Criticidade;
            data.Id_Periodo_Revisao         = input.Id_Periodo_Revisao;
            data.Id_Usuario_Gestor          = input.Id_Usuario_Gestor;
            data.Data_Proxima_Revisao       = Data_Proxima_Revisao;
            data.Fl_Revisao_Manual          = input.Fl_Revisao_Manual; 

            _context.Update(data);
            _context.SaveChanges();

            return data.Id_Compliance_Norma;
        }
        public bool Remove(long id)
        {
            ComplianceNorma data = DbSet.Where(x => x.Id_Compliance_Norma.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }

    }
}
