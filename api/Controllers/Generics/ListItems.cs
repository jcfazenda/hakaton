using api.Domain.Models.Apontamentos;
using api.Domain.Models.Compliances;
using api.Domain.Models.Controles;
using api.Domain.Models.Departamentos;
using api.Domain.Models.Empresas;
using api.Domain.Models.Estados;
using api.Domain.Models.Incidentes;
using api.Domain.Models.Indice;
using api.Domain.Models.LGPD;
using api.Domain.Models.PerfisAcesso.Telas;
using api.Domain.Models.PlanosAcao;
using api.Domain.Models.Processos;
using api.Domain.Models.Risco;
using api.Domain.Models.Testes;
using api.Domain.Models.UnidadesOrganizacionais;
using api.Domain.Models.Usuario;
using api.Domain.Models.WorkFlow;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace api.Controllers.Generics
{
    public class ListItems
    {
        public long Value { get; set; }
        public string Text { get; set; }

        public static List<SelectListItem> ListUF()
        {

            List<SelectListItem> List = new List<SelectListItem>();

            List.Add(new SelectListItem { Text = "AC", Value = "AC" });
            List.Add(new SelectListItem { Text = "AL", Value = "AL" });
            List.Add(new SelectListItem { Text = "AM", Value = "AM" });
            List.Add(new SelectListItem { Text = "AP", Value = "AP" });
            List.Add(new SelectListItem { Text = "BA", Value = "BA" });
            List.Add(new SelectListItem { Text = "CE", Value = "CE" });
            List.Add(new SelectListItem { Text = "DF", Value = "DF" });
            List.Add(new SelectListItem { Text = "ES", Value = "ES" });
            List.Add(new SelectListItem { Text = "GO", Value = "GO" });
            List.Add(new SelectListItem { Text = "MA", Value = "MA" });
            List.Add(new SelectListItem { Text = "MG", Value = "MG" });
            List.Add(new SelectListItem { Text = "MS", Value = "MS" });
            List.Add(new SelectListItem { Text = "MT", Value = "MT" });
            List.Add(new SelectListItem { Text = "PA", Value = "PA" });
            List.Add(new SelectListItem { Text = "PB", Value = "PB" });
            List.Add(new SelectListItem { Text = "PE", Value = "PE" });
            List.Add(new SelectListItem { Text = "PI", Value = "PI" });
            List.Add(new SelectListItem { Text = "PR", Value = "PR" });
            List.Add(new SelectListItem { Text = "RJ", Value = "RJ" });
            List.Add(new SelectListItem { Text = "RN", Value = "RN" });
            List.Add(new SelectListItem { Text = "RO", Value = "RO" });
            List.Add(new SelectListItem { Text = "RR", Value = "RR" });
            List.Add(new SelectListItem { Text = "RS", Value = "RS" });
            List.Add(new SelectListItem { Text = "SC", Value = "SC" });
            List.Add(new SelectListItem { Text = "SE", Value = "SE" });
            List.Add(new SelectListItem { Text = "SP", Value = "SP" });
            List.Add(new SelectListItem { Text = "TO", Value = "TO" });

            return List;
        }
        public static List<SelectListItem> ListTipoLogradouro()
        {
            List<SelectListItem> List = new List<SelectListItem>();

            List.Add(new SelectListItem { Text = "Rua", Value = "Rua" });
            List.Add(new SelectListItem { Text = "Avenida", Value = "Avenida" });
            List.Add(new SelectListItem { Text = "Alameda", Value = "Alameda" });
            List.Add(new SelectListItem { Text = "Praça", Value = "Praça" });
            List.Add(new SelectListItem { Text = "Outros", Value = "Outros" });

            return List;
        }
        public static List<SelectListItem> ListEstadosSet(List<Estado> Estado, long id)
        {
            bool Selected = false;

            List<SelectListItem> List = new List<SelectListItem>();

            foreach (var item in Estado)
            {
                Selected = false;
                if (id == item.Id_Estado) { Selected = true; }

                List.Add(new SelectListItem
                {
                    Text     = item.Estado_Uf + " - "+ item.Estado_Nome,
                    Value    = item.Id_Estado.ToString(),
                    Selected = Selected
                });
            }

            return List;
        }

        public static List<SelectListItem> ListRiscosSet(List<Riscos> Riscos, long id)
        {
            bool Selected = false;

            List<SelectListItem> List = new List<SelectListItem>();

            foreach (var item in Riscos)
            {
                Selected = false;
                if (id == item.Id_Risco) { Selected = true; }

                List.Add(new SelectListItem
                {
                    Text = item.Risco_Nome,
                    Value = item.Id_Risco.ToString(),
                    Selected = Selected
                });
            }

            return List;
        }
       
        /* Controles */         
        public static List<SelectListItem> ListControleSet(List<Controle> Controle, long id)
        {
            bool Selected = false;

            List<SelectListItem> List = new List<SelectListItem>();

            foreach (var item in Controle)
            {
                Selected = false;
                if (id == item.Id_Controle) { Selected = true; }

                List.Add(new SelectListItem
                {
                    Text = item.Controle_Nome,
                    Value = item.Id_Controle.ToString(),
                    Selected = Selected
                });
            }

            return List;
        }
        public static List<SelectListItem> ListControleObjetivoSet(List<ControleObjetivo> ControleObjetivo, long id)
        {
            bool Selected = false;

            List<SelectListItem> List = new List<SelectListItem>();

            foreach (var item in ControleObjetivo)
            {
                Selected = false;
                if (id == item.Id_Controle_Objetivo) { Selected = true; }

                List.Add(new SelectListItem
                {
                    Text = item.Controle_Objetivo_Nome,
                    Value = item.Id_Controle_Objetivo.ToString(),
                    Selected = Selected
                });
            }

            return List;
        }
        public static List<SelectListItem> ListControleTipoSet(List<ControleTipo> ControleTipo, long id)
        {
            bool Selected = false;

            List<SelectListItem> List = new List<SelectListItem>();

            foreach (var item in ControleTipo)
            {
                Selected = false;
                if (id == item.Id_Controle_Tipo) { Selected = true; }

                List.Add(new SelectListItem
                {
                    Text = item.Controle_Tipo_Nome,
                    Value = item.Id_Controle_Tipo.ToString(),
                    Selected = Selected
                });
            }

            return List;
        }
        public static List<SelectListItem> ListControleFrequenciaSet(List<ControleFrequencia> ControleFrequencia, long id)
        {
            bool Selected = false;

            List<SelectListItem> List = new List<SelectListItem>();

            foreach (var item in ControleFrequencia)
            {
                Selected = false;
                if (id == item.Id_Controle_Frequencia) { Selected = true; }

                List.Add(new SelectListItem
                {
                    Text = item.Controle_Frequencia_Nome,
                    Value = item.Id_Controle_Frequencia.ToString(),
                    Selected = Selected
                });
            }

            return List;
        }
        public static List<SelectListItem> ListControleCategoriaSet(List<ControleCategoria> ControleCategoria, long id)
        {
            bool Selected = false;

            List<SelectListItem> List = new List<SelectListItem>();

            foreach (var item in ControleCategoria)
            {
                Selected = false;
                if (id == item.Id_Controle_Categoria) { Selected = true; }

                List.Add(new SelectListItem
                {
                    Text = item.Controle_Categoria_Nome,
                    Value = item.Id_Controle_Categoria.ToString(),
                    Selected = Selected
                });
            }

            return List;
        }
        public static List<SelectListItem> ListControleGrauAutomacaoSet(List<ControleGrauAutomacao> ControleGrauAutomacao, long id)
        {
            bool Selected = false;

            List<SelectListItem> List = new List<SelectListItem>();

            foreach (var item in ControleGrauAutomacao)
            {
                Selected = false;
                if (id == item.Id_Controle_Grau_Automacao) { Selected = true; }

                List.Add(new SelectListItem
                {
                    Text = item.Controle_Grau_Automacao_Nome,
                    Value = item.Id_Controle_Grau_Automacao.ToString(),
                    Selected = Selected
                });
            }

            return List;
        }
        public static List<SelectListItem> ListControleAfirmacaoSet(List<ControleAfirmacao> ControleAfirmacao, long id)
        {
            bool Selected = false;

            List<SelectListItem> List = new List<SelectListItem>();

            foreach (var item in ControleAfirmacao)
            {
                Selected = false;
                if (id == item.Id_Controle_Afirmacao) { Selected = true; }

                List.Add(new SelectListItem
                {
                    Text = item.Controle_Afirmacao_Nome,
                    Value = item.Id_Controle_Afirmacao.ToString(),
                    Selected = Selected
                });
            }

            return List;
        }
        public static List<SelectListItem> ListControleDemonstracaoFinanceiraSet(List<ControleDemonstracaoFinanceira> ControleDemonstracaoFinanceira, long id)
        {
            bool Selected = false;

            List<SelectListItem> List = new List<SelectListItem>();

            foreach (var item in ControleDemonstracaoFinanceira)
            {
                Selected = false;
                if (id == item.Id_Controle_Demonstracao_Financeira) { Selected = true; }

                List.Add(new SelectListItem
                {
                    Text = item.Controle_Demonstracao_Financeira_Nome,
                    Value = item.Id_Controle_Demonstracao_Financeira.ToString(),
                    Selected = Selected
                });
            }

            return List;
        }
        public static List<SelectListItem> ListControleCategoriaObjetivoSet(List<ControleCategoriaObjetivo> ControleCategoriaObjetivo, long id)
        {
            bool Selected = false;

            List<SelectListItem> List = new List<SelectListItem>();

            foreach (var item in ControleCategoriaObjetivo)
            {
                Selected = false;
                if (id == item.Id_Controle_Categoria_Objetivo) { Selected = true; }

                List.Add(new SelectListItem
                {
                    Text = item.Controle_Categoria_Objetivo_Nome,
                    Value = item.Id_Controle_Categoria_Objetivo.ToString(),
                    Selected = Selected
                });
            }

            return List;
        }

        /* teste */
        public static List<SelectListItem> ListTesteSet(List<Teste> Teste, long id)
        {
            bool Selected = false;

            List<SelectListItem> List = new List<SelectListItem>();

            foreach (var item in Teste)
            {
                Selected = false;
                if (id == item.Id_Teste) { Selected = true; }

                List.Add(new SelectListItem
                {
                    Text = item.Teste_Nome,
                    Value = item.Id_Teste.ToString(),
                    Selected = Selected
                });
            }

            return List;
        }
        public static List<SelectListItem> ListTesteStatusSet(List<TesteStatus> TesteStatus, long id)
        {
            bool Selected = false;

            List<SelectListItem> List = new List<SelectListItem>();

            foreach (var item in TesteStatus)
            {
                Selected = false;
                if (id == item.Id_Teste_Status) { Selected = true; }

                List.Add(new SelectListItem
                { 
                    Text = item.Teste_Status_Nome,
                    Value = item.Id_Teste_Status.ToString(),
                    Selected = Selected
                });
            }

            return List;
        }
        public static List<SelectListItem> ListTesteProcedimentoTipoSet(List<TesteProcedimentoTipo> TesteProcedimentoTipo, long id)
        {
            bool Selected = false;

            List<SelectListItem> List = new List<SelectListItem>();

            foreach (var item in TesteProcedimentoTipo)
            {
                Selected = false;
                if (id == item.Id_Teste_Procedimento_Tipo) { Selected = true; }

                List.Add(new SelectListItem
                {
                    Text = item.Teste_Procedimento_Tipo_Nome,
                    Value = item.Id_Teste_Procedimento_Tipo.ToString(),
                    Selected = Selected
                });
            }

            return List;
        }
        public static List<SelectListItem> ListTesteProcedimentoNaturezaItemSet(List<TesteProcedimentoNaturezaItem> TesteProcedimentoNaturezaItem, long id)
        {
            bool Selected = false;

            List<SelectListItem> List = new List<SelectListItem>();

            foreach (var item in TesteProcedimentoNaturezaItem)
            {
                Selected = false;
                if (id == item.Id_Teste_Procedimento_Natureza_Item) { Selected = true; }

                List.Add(new SelectListItem
                {
                    Text = item.Teste_Procedimento_Natureza_Item_Nome,
                    Value = item.Id_Teste_Procedimento_Natureza_Item.ToString(),
                    Selected = Selected
                });
            }

            return List;
        }
 


        public static List<SelectListItem> ListProcessoSet(List<Processo> Processo, long id)
        {
            bool Selected = false;

            List<SelectListItem> List = new List<SelectListItem>();

            foreach (var item in Processo)
            {
                Selected = false;
                if (id == item.Id_Processo) { Selected = true; }

                List.Add(new SelectListItem
                {
                    Text = item.Processo_Nome,
                    Value = item.Id_Processo.ToString(),
                    Selected = Selected
                });
            }

            return List;
        }
        public static List<SelectListItem> ListFatorRiscoSet(List<FatorRisco> FatorRisco, long id)
        {
            bool Selected = false;

            List<SelectListItem> List = new List<SelectListItem>();

            foreach (var item in FatorRisco)
            {
                Selected = false;
                if (id == item.Id_Fator_Risco) { Selected = true; }

                List.Add(new SelectListItem
                {
                    Text = item.Fator_Risco_Nome,
                    Value = item.Id_Fator_Risco.ToString(),
                    Selected = Selected
                });
            }

            return List;
        }
        public static List<SelectListItem> ListIncidenteSet(List<Incidente> Incidente, long id)
        {
            bool Selected = false;

            List<SelectListItem> List = new List<SelectListItem>();

            foreach (var item in Incidente)
            {
                Selected = false;
                if (id == item.Id_Incidente) { Selected = true; }

                List.Add(new SelectListItem
                {
                    Text = item.Incidente_Nome,
                    Value = item.Id_Incidente.ToString(),
                    Selected = Selected
                });
            }

            return List;
        }
        public static List<SelectListItem> ListPlanoAcaoSet(List<PlanoAcao> PlanoAcao, long id)
        {
            bool Selected = false;

            List<SelectListItem> List = new List<SelectListItem>();

            foreach (var item in PlanoAcao)
            {
                Selected = false;
                if (id == item.Id_Plano_Acao) { Selected = true; }

                List.Add(new SelectListItem
                {
                    Text = item.Plano_Acao_Nome,
                    Value = item.Id_Plano_Acao.ToString(),
                    Selected = Selected
                });
            }

            return List;
        }


        public static List<SelectListItem> ListCategoriaRiscoSet(List<CategoriaRisco> CategoriaRisco, long id)
        {
            bool Selected = false;

            List<SelectListItem> List = new List<SelectListItem>();

            foreach (var item in CategoriaRisco)
            {
                Selected = false;
                if (id == item.Id_Categoria_Risco) { Selected = true; }

                List.Add(new SelectListItem
                {
                    Text = item.Categoria_Risco_Nome,
                    Value = item.Id_Categoria_Risco.ToString(),
                    Selected = Selected
                });
            }

            return List;
        }
        public static List<SelectListItem> ListCausaSet(List<Causas> Causas, long id)
        {
            bool Selected = false;

            List<SelectListItem> List = new List<SelectListItem>();

            foreach (var item in Causas)
            {
                Selected = false;
                if (id == item.Id_Causa) { Selected = true; }

                List.Add(new SelectListItem
                {
                    Text = item.Causa_Nome,
                    Value = item.Id_Causa.ToString(),
                    Selected = Selected
                });
            }

            return List;
        }
        public static List<SelectListItem> ListImpactoSet(List<Impacto> Impacto, long id)
        {
            bool Selected = false;

            List<SelectListItem> List = new List<SelectListItem>();

            foreach (var item in Impacto)
            {
                Selected = false;
                if (id == item.Id_Impacto) { Selected = true; }

                List.Add(new SelectListItem
                {
                    Text = item.Impacto_Nome,
                    Value = item.Id_Impacto.ToString(),
                    Selected = Selected
                });
            }

            return List;
        }


        public static List<SelectListItem> ListUsuariosSet(List<Usuarios> Usuarios, long id)
        {
            bool Selected = false;

            List<SelectListItem> List = new List<SelectListItem>();

            foreach (var item in Usuarios)
            {
                Selected = false;
                if (id == item.Id_Usuario) { Selected = true; }

                List.Add(new SelectListItem
                {
                    Text = item.Usuario_Nome + " " + item.Usuario_Sobrenome,
                    Value = item.Id_Usuario.ToString(),
                    Selected = Selected
                });
            }

            return List;
        }
        public static List<SelectListItem> ListUsuarioAreaAtuacaoSet(List<UsuarioAreaAtuacao> UsuarioAreaAtuacao, long id)
        {
            bool Selected = false;

            List<SelectListItem> List = new List<SelectListItem>();

            foreach (var item in UsuarioAreaAtuacao)
            {
                Selected = false;
                if (id == item.Id_Usuario_Area_Atuacao) { Selected = true; }

                List.Add(new SelectListItem
                {
                    Text = item.Usuario_Area_Atuacao_Nome,
                    Value = item.Id_Usuario_Area_Atuacao.ToString(),
                    Selected = Selected
                });
            }

            return List;
        }
        public static List<SelectListItem> ListUsuarioGrupoClasseSet(List<UsuarioGrupoClasse> UsuarioGrupoClasse, long id)
        {
            bool Selected = false;

            List<SelectListItem> List = new List<SelectListItem>();

            foreach (var item in UsuarioGrupoClasse)
            {
                Selected = false;
                if (id == item.Id_Usuario_Grupo_Classe) { Selected = true; }

                List.Add(new SelectListItem
                {
                    Text = item.Usuario_Grupo_Classe_Nome,
                    Value = item.Id_Usuario_Grupo_Classe.ToString(),
                    Selected = Selected
                });
            }

            return List;
        }
        public static List<SelectListItem> ListUsuarioCargoAtividadeSet(List<UsuarioCargoAtividade> UsuarioCargoAtividade, long id)
        {
            bool Selected = false;

            List<SelectListItem> List = new List<SelectListItem>();

            foreach (var item in UsuarioCargoAtividade)
            {
                Selected = false;
                if (id == item.Id_Usuario_Cargo_Atividade) { Selected = true; }

                List.Add(new SelectListItem
                {
                    Text = item.Usuario_Cargo_Atividade_Nome,
                    Value = item.Id_Usuario_Cargo_Atividade.ToString(),
                    Selected = Selected
                });
            }

            return List;
        }
        public static List<SelectListItem> ListAcionistasSet(List<Acionista> Acionista, long id)
        {
            bool Selected = false;

            List<SelectListItem> List = new List<SelectListItem>();

            foreach (var item in Acionista)
            {
                Selected = false;
                if (id == item.Id_Acionista) { Selected = true; }

                List.Add(new SelectListItem
                {
                    Text = item.Acionista_Nome,
                    Value = item.Id_Acionista.ToString(),
                    Selected = Selected
                });
            }

            return List;
        } 

        public static List<SelectListItem> ListPerfilAnaliseSet(List<PerfilAnalise> PerfilAnalise, long id)
        {
            bool Selected = false;

            List<SelectListItem> List = new List<SelectListItem>();

            foreach (var item in PerfilAnalise)
            {
                Selected = false;
                if (id == item.Id_Perfil_Analise) { Selected = true; }

                List.Add(new SelectListItem
                {
                    Text = item.Perfil_Analise_Nome,
                    Value = item.Id_Perfil_Analise.ToString(),
                    Selected = Selected
                });
            }

            return List;
        }
        public static List<SelectListItem> ListRiscoAvaliacaoStatusSet(List<RiscoAvaliacaoStatus> RiscoAvaliacaoStatus, long id)
        {
            bool Selected = false;

            List<SelectListItem> List = new List<SelectListItem>();

            foreach (var item in RiscoAvaliacaoStatus)
            {
                Selected = false;
                if (id == item.Id_Risco_Avaliacao_Status) { Selected = true; }

                List.Add(new SelectListItem
                {
                    Text = item.Avaliacao_Status_Nome,
                    Value = item.Id_Risco_Avaliacao_Status.ToString(),
                    Selected = Selected
                });
            }

            return List;
        }
        public static List<SelectListItem> ListRiscoTratamentoTipoSet(List<RiscoTratamentoTipo> RiscoTratamentoTipo, long id)
        {
            bool Selected = false;

            List<SelectListItem> List = new List<SelectListItem>();

            foreach (var item in RiscoTratamentoTipo)
            {
                Selected = false;
                if (id == item.Id_Risco_Tratamento_Tipo) { Selected = true; }

                List.Add(new SelectListItem
                {
                    Text = item.Tratamento_Tipo_Nome,
                    Value = item.Id_Risco_Tratamento_Tipo.ToString(),
                    Selected = Selected
                });
            }

            return List;
        }
        public static List<SelectListItem> ListIncidenteCategoriaSet(List<IncidenteCategoria> IncidenteCategoria, long id)
        {
            bool Selected = false;

            List<SelectListItem> List = new List<SelectListItem>();

            foreach (var item in IncidenteCategoria)
            {
                Selected = false;
                if (id == item.Id_Incidente_Categoria) { Selected = true; }

                List.Add(new SelectListItem
                {
                    Text     = item.Incidente_Categoria_Nome,
                    Value    = item.Id_Incidente_Categoria.ToString(),
                    Selected = Selected
                });
            }

            return List;
        }
        public static List<SelectListItem> ListIndiceFinanceiroSet(List<IndiceFinanceiro> IndiceFinanceiro, long id)
        {
            bool Selected = false;

            List<SelectListItem> List = new List<SelectListItem>();

            foreach (var item in IndiceFinanceiro)
            {
                Selected = false;
                if (id == item.Id_Indice_Financeiro) { Selected = true; }

                List.Add(new SelectListItem
                {
                    Text = item.Indice_Financeiro_Nome,
                    Value = item.Id_Indice_Financeiro.ToString(),
                    Selected = Selected
                });
            }

            return List;
        }
        public static List<SelectListItem> ListMatrizSet(List<Matriz> Matriz, long id)
        {
            bool Selected = false;

            List<SelectListItem> List = new List<SelectListItem>();

            foreach (var item in Matriz)
            {
                Selected = false;
                if (id == item.Id_Matriz) { Selected = true; }

                List.Add(new SelectListItem
                {
                    Text = item.Matriz_Nome,
                    Value = item.Id_Matriz.ToString(),
                    Selected = Selected
                });
            }

            return List;
        }
        public static List<SelectListItem> ListPlanoAcaoStatusSet(List<PlanoAcaoStatus> PlanoAcaoStatus, long id)
        {
            bool Selected = false;

            List<SelectListItem> List = new List<SelectListItem>();

            foreach (var item in PlanoAcaoStatus)
            {
                Selected = false;
                if (id == item.Id_Plano_Acao_Status) { Selected = true; }

                List.Add(new SelectListItem
                {
                    Text = item.Plano_Acao_Status_Nome,
                    Value = item.Id_Plano_Acao_Status.ToString(),
                    Selected = Selected
                });
            }

            return List;
        }
        public static List<SelectListItem> ListStepStatusSet(List<StepStatus> StepStatus, long id)
        {
            bool Selected = false;

            List<SelectListItem> List = new List<SelectListItem>();

            foreach (var item in StepStatus)
            {
                Selected = false;
                if (id == item.Id_Step_Status) { Selected = true; }

                List.Add(new SelectListItem
                {
                    Text = item.Step_Status_Nome,
                    Value = item.Id_Step_Status.ToString(),
                    Selected = Selected
                });
            }

            return List;
        }
        public static List<SelectListItem> ListApontamentoClassificacaoSet(List<ApontamentoClassificacao> ApontamentoClassificacao, long id)
        {
            bool Selected = false;

            List<SelectListItem> List = new List<SelectListItem>();

            foreach (var item in ApontamentoClassificacao)
            {
                Selected = false;
                if (id == item.Id_Apontamento_Classificacao) { Selected = true; }

                List.Add(new SelectListItem
                {
                    Text = item.Apontamento_Classificacao_Nome,
                    Value = item.Id_Apontamento_Classificacao.ToString(),
                    Selected = Selected
                });
            }

            return List;
        }
        public static List<SelectListItem> ListLinhaNegocioSet(List<LinhaNegocio> LinhaNegocio, long id)
        {
            bool Selected = false;

            List<SelectListItem> List = new List<SelectListItem>();

            foreach (var item in LinhaNegocio)
            {
                Selected = false;
                if (id == item.Id_Linha_Negocio) { Selected = true; }

                List.Add(new SelectListItem
                {
                    Text = item.Linha_Negocio_Nome,
                    Value = item.Id_Linha_Negocio.ToString(),
                    Selected = Selected
                });
            }

            return List;
        }
       public static List<SelectListItem> ListEmpresaClassificacaoSet(List<EmpresaClassificacao> EmpresaClassificacao, long id)
        {
            bool Selected = false;

            List<SelectListItem> List = new List<SelectListItem>();

            //List.Add(new SelectListItem
            //{
            //    Text = "",
            //    Value = "0",
            //    Selected = true
            //});

            foreach (var item in EmpresaClassificacao)
            {
                Selected = false;
                if (id == item.Id_Empresa_Classificacao) { Selected = true; }

                List.Add(new SelectListItem
                {
                    Text = item.Empresa_Classificacao_Nome,
                    Value = item.Id_Empresa_Classificacao.ToString(),
                    Selected = Selected
                });
            }

            return List;
        }
        public static List<SelectListItem> ListOrgaoReguladorSet(List<OrgaoRegulador> OrgaoRegulador, long id)
        {
            bool Selected = false;

            List<SelectListItem> List = new List<SelectListItem>();
            //List.Add(new SelectListItem
            //{
            //    Text = "",
            //    Value = "0",
            //    Selected = true
            //});

            foreach (var item in OrgaoRegulador)
            {
                Selected = false;
                if (id == item.Id_Orgao_Regulador) { Selected = true; }

                List.Add(new SelectListItem
                {
                    Text = item.Orgao_Regulador_Nome,
                    Value = item.Id_Orgao_Regulador.ToString(),
                    Selected = Selected
                });
            }

            return List;
        }

        public static List<SelectListItem> ListEmpresaAcaoSocietariaItemSet(List<EmpresaAcaoSocietariaItem> EmpresaAcaoSocietariaItem, long id)
        {
            bool Selected = false;

            List<SelectListItem> List = new List<SelectListItem>();

            foreach (var item in EmpresaAcaoSocietariaItem)
            {
                Selected = false;
                if (id == item.Id_Empresa_Acao_Societaria_Item) { Selected = true; }

                List.Add(new SelectListItem
                {
                    Text = item.Empresa_Acao_Societaria_Item_Nome,
                    Value = item.Id_Empresa_Acao_Societaria_Item.ToString(),
                    Selected = Selected
                });
            }

            return List;
        }
        public static List<SelectListItem> ListNivelAcessoSet(List<NivelAcesso> NivelAcesso, long id)
        {
            bool Selected = false;

            List<SelectListItem> List = new List<SelectListItem>();

            foreach (var item in NivelAcesso)
            {
                Selected = false;
                if (id == item.Id_Nivel_Acesso) { Selected = true; }

                List.Add(new SelectListItem
                {
                    Text = item.Nivel_Acesso_Nome,
                    Value = item.Id_Nivel_Acesso.ToString(),
                    Selected = Selected
                });
            }

            return List;
        }
        public static List<SelectListItem> ListWorkFlowStatusSet(List<WorkFlowStatus> WorkFlowStatus, long id)
        {
            bool Selected = false;

            List<SelectListItem> List = new List<SelectListItem>();

            foreach (var item in WorkFlowStatus)
            {
                Selected = false;
                if (id == item.Id_Workflow_Status) { Selected = true; }

                List.Add(new SelectListItem
                {
                    Text = item.Workflow_Status_Nome,
                    Value = item.Id_Workflow_Status.ToString(),
                    Selected = Selected
                });
            }

            return List;
        }
        public static List<SelectListItem> ListProcessoNivelSet(List<ProcessoNivel> ProcessoNivel, long id)
        {
            bool Selected = false;

            List<SelectListItem> List = new List<SelectListItem>();

            foreach (var item in ProcessoNivel)
            {
                Selected = false;
                if (id == item.Id_Processo_Nivel) { Selected = true; }

                List.Add(new SelectListItem
                {
                    Text = item.Processo_Nivel_Nome,
                    Value = item.Id_Processo_Nivel.ToString(),
                    Selected = Selected
                });
            }

            return List;
        }
 
        public static List<SelectListItem> ListUnidadeOrganizacionalResponsabilidadeSet(List<UnidadeOrganizacionalResponsabilidade> UnidadeOrganizacionalResponsabilidade, long id)
        {
            bool Selected = false;

            List<SelectListItem> List = new List<SelectListItem>();

            foreach (var item in UnidadeOrganizacionalResponsabilidade)
            {
                Selected = false;
                if (id == item.Id_Unidade_Organizacional_Responsabilidade) { Selected = true; }

                List.Add(new SelectListItem
                {
                    Text = item.Unidade_Organizacional_Responsabilidade_Nome,
                    Value = item.Id_Unidade_Organizacional_Responsabilidade.ToString(),
                    Selected = Selected
                });
            }

            return List;
        }
        public static List<SelectListItem> LisUnidadeOrganizacionalOrgaoSet(List<UnidadeOrganizacionalOrgao> UnidadeOrganizacionalOrgao, long id)
        {
            bool Selected = false;

            List<SelectListItem> List = new List<SelectListItem>();

            foreach (var item in UnidadeOrganizacionalOrgao)
            {
                Selected = false;
                if (id == item.Id_Unidade_Organizacional_Orgao) { Selected = true; }

                List.Add(new SelectListItem
                {
                    Text = item.Unidade_Organizacional_Orgao_Nome,
                    Value = item.Id_Unidade_Organizacional_Orgao.ToString(),
                    Selected = Selected
                });
            }

            return List;
        }
        public static List<SelectListItem> ListComplianceNormaTipoSet(List<ComplianceNormaTipo> ComplianceNormaTipo, long id)
        {
            bool Selected = false;

            List<SelectListItem> List = new List<SelectListItem>();

            foreach (var item in ComplianceNormaTipo)
            {
                Selected = false;
                if (id == item.Id_Compliance_Norma_Tipo) { Selected = true; }

                List.Add(new SelectListItem
                {
                    Text = item.Compliance_Norma_Tipo_Nome,
                    Value = item.Id_Compliance_Norma_Tipo.ToString(),
                    Selected = Selected
                });
            }

            return List;
        }
        public static List<SelectListItem> ListCompliancePeriodoRevisaoSet(List<CompliancePeriodoRevisao> CompliancePeriodoRevisao, long id)
        {
            bool Selected = false;

            List<SelectListItem> List = new List<SelectListItem>();

            foreach (var item in CompliancePeriodoRevisao)
            {
                Selected = false;
                if (id == item.Id_Compliance_Periodo_Revisao) { Selected = true; }

                List.Add(new SelectListItem
                {
                    Text = item.Compliance_Periodo_Revisao_Nome,
                    Value = item.Id_Compliance_Periodo_Revisao.ToString(),
                    Selected = Selected
                });
            }

            return List;
        }
        public static List<SelectListItem> ListComplianceCriticidadeSet(List<ComplianceCriticidade> ComplianceCriticidade, long id)
        {
            bool Selected = false;

            List<SelectListItem> List = new List<SelectListItem>();

            foreach (var item in ComplianceCriticidade)
            {
                Selected = false;
                if (id == item.Id_Compliance_Criticidade) { Selected = true; }

                List.Add(new SelectListItem
                {
                    Text = item.Compliance_Criticidade_Nome,
                    Value = item.Id_Compliance_Criticidade.ToString(),
                    Selected = Selected
                });
            }

            return List;
        }
        public static List<SelectListItem> ListApontamentoCategoriaSet(List<ApontamentoCategoria> ApontamentoCategoria, long id)
        {
            bool Selected = false;

            List<SelectListItem> List = new List<SelectListItem>();

            foreach (var item in ApontamentoCategoria)
            {
                Selected = false;
                if (id == item.Id_Apontamento_Categoria) { Selected = true; }

                List.Add(new SelectListItem
                {
                    Text = item.Apontamento_Categoria_Nome,
                    Value = item.Id_Apontamento_Categoria.ToString(),
                    Selected = Selected
                });
            }

            return List;
        }

        public static List<SelectListItem> ListLgpdTipoSet(List<LgpdTipo> LgpdTipo, long id)
        {
            bool Selected = false;

            List<SelectListItem> List = new List<SelectListItem>();

            foreach (var item in LgpdTipo)
            {
                Selected = false;
                if (id == item.Id_Lgpd_Tipo) { Selected = true; }

                List.Add(new SelectListItem
                {
                    Text = item.Lgpd_Tipo_Nome,
                    Value = item.Id_Lgpd_Tipo.ToString(),
                    Selected = Selected
                });
            }

            return List;
        } 

        public static List<SelectListItem> ListLgpdTipoDadosSet(List<LgpdTipoDados> LgpdTipoDados, long id)
        {
            bool Selected = false;

            List<SelectListItem> List = new List<SelectListItem>();

            foreach (var item in LgpdTipoDados)
            {
                Selected = false;
                if (id == item.Id_Lgpd_Tipo_Dados) { Selected = true; }

                List.Add(new SelectListItem
                {
                    Text = item.Lgpd_Tipo_Dados_Nome,
                    Value = item.Id_Lgpd_Tipo_Dados.ToString(),
                    Selected = Selected
                });
            }

            return List;
        }

        public static List<SelectListItem> ListDepartamentoSet(List<Departamento> Departamento, long id)
        {
            bool Selected = false;

            List<SelectListItem> List = new List<SelectListItem>();

            foreach (var item in Departamento)
            {
                Selected = false;
                if (id == item.Id_Departamento) { Selected = true; }

                List.Add(new SelectListItem
                {
                    Text        = item.Departamento_Nome,
                    Value       = item.Id_Departamento.ToString(),
                    Selected    = Selected
                });
            }

            return List;
        }

    }
}


