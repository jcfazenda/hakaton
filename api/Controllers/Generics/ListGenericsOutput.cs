using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace api.Controllers.Generics
{
    public class ListGenericsOutput
    {
        public List<SelectListItem> ListUF { get; set; }
        public List<SelectListItem> ListTipoLogradouro { get; set; }
        public List<SelectListItem> ListEstados { get; set; }

        public List<SelectListItem> ListCausas { get; set; }
        public List<SelectListItem> ListImpactos { get; set; }
        public List<SelectListItem> ListRiscos { get; set; } 
        public List<SelectListItem> ListCategoriaRisco { get; set; }
        public List<SelectListItem> ListProcessos { get; set; }
        public List<SelectListItem> ListFatorRisco { get; set; }
        public List<SelectListItem> ListIncidentes { get; set; }
        public List<SelectListItem> ListPlanoAcao { get; set; }
        public List<SelectListItem> ListPlanoAcaoApontamentoClassificacao { get; set; } 
        

        public List<SelectListItem> ListIncidenteCategoria { get; set; }
        public List<SelectListItem> ListIndiceFinanceiro { get; set; }
        public List<SelectListItem> ListMatriz { get; set; }
        public List<SelectListItem> ListPlanoAcaoStatus { get; set; }
        public List<SelectListItem> ListStepStatus { get; set; } 
        public List<SelectListItem> ListApontamentoClassificacao { get; set; }
        public List<SelectListItem> ListApontamentoCategoria { get; set; }
        public List<SelectListItem> ListLinhaNegocio { get; set; } 
        public List<SelectListItem> ListEmpresaClassificacao { get; set; }
        public List<SelectListItem> ListOrgaoRegulador { get; set; }
        public List<SelectListItem> ListRiscoTratamentoTipo { get; set; }
        public List<SelectListItem> ListRiscoAvaliacaoStatus { get; set; }
        public List<SelectListItem> ListPerfilAnalise { get; set; } 

        public List<SelectListItem> ListUsuarios { get; set; }
        public List<SelectListItem> ListUsuarioAreaAtuacao { get; set; }
        public List<SelectListItem> ListUsuarioGrupoClasse { get; set; }
        public List<SelectListItem> ListUsuarioCargoAtividade { get; set; }
        public List<SelectListItem> ListAcionistas { get; set; }


        public List<SelectListItem> ListTeste { get; set; }
        public List<SelectListItem> ListTesteProcedimentoTipo { get; set; }
        public List<SelectListItem> ListTesteProcedimentoNaturezaItem { get; set; }
        public List<SelectListItem> ListTesteStatus { get; set; }
        public List<SelectListItem> ListTesteApontamentoClassificacao { get; set; }

        
        public List<SelectListItem> ListControles { get; set; }
        public List<SelectListItem> ListControleCategoria { get; set; }
        public List<SelectListItem> ListControleFrequencia { get; set; }
        public List<SelectListItem> ListControleObjetivo { get; set; }
        public List<SelectListItem> ListControleTipo { get; set; }
        public List<SelectListItem> ListControleStatusAprovacao { get; set; }
        public List<SelectListItem> ListControleGrauAutomacao { get; set; }
        public List<SelectListItem> ListControleAfirmacao { get; set; }
        public List<SelectListItem> ListControleDemonstracaoFinanceira { get; set; }
        public List<SelectListItem> ListControleCategoriaObjetivo { get; set; }
        public List<SelectListItem> ListEmpresaAcaoSocietariaItem { get; set; }
        public List<SelectListItem> ListNivelAcesso { get; set; }
        public List<SelectListItem> ListWorkFlowStatus { get; set; }
        public List<SelectListItem> ListProcessoNivel { get; set; }
        public List<SelectListItem> ListTesteApontamento { get; set; }

        public List<SelectListItem> ListUnidadeOrganizacionalResponsabilidade { get; set; }
        public List<SelectListItem> ListUnidadeOrganizacionalOrgao { get; set; }
        public List<SelectListItem> ListComplianceNormaTipo { get; set; }

        public List<SelectListItem> ListCompliancePeriodoRevisao { get; set; }
        public List<SelectListItem> ListComplianceCriticidade { get; set; }
        public List<SelectListItem> ListPlanoAcaoApontamentoCategoria { get; set; }

        public List<SelectListItem> ListLgpdTipo { get; set; }
        public List<SelectListItem> ListLgpdApontamento { get; set; }
        public List<SelectListItem> ListLgpdApontamentoClassificacao { get; set; }
        public List<SelectListItem> ListLgpdTipoDados { get; set; }
        public List<SelectListItem> ListDepartamento { get; set; }
        public List<SelectListItem> ListTesteControle { get; set; }

        

    }
}

