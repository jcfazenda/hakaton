
using api.Controllers.Generics;
using api.Domain.Repository.Interface.Apontamentos;
using api.Domain.Repository.Interface.Compliances;
using api.Domain.Repository.Interface.Controles;
using api.Domain.Repository.Interface.Departamentos;
using api.Domain.Repository.Interface.Empresas;
using api.Domain.Repository.Interface.Estados;
using api.Domain.Repository.Interface.Incidentes;
using api.Domain.Repository.Interface.Indice;
using api.Domain.Repository.Interface.LGPD;
using api.Domain.Repository.Interface.PerfisAcesso.Telas;
using api.Domain.Repository.Interface.PlanosAcao;
using api.Domain.Repository.Interface.Processos;
using api.Domain.Repository.Interface.Risco;
using api.Domain.Repository.Interface.Testes;
using api.Domain.Repository.Interface.UnidadesOrganizacionais;
using api.Domain.Repository.Interface.Usuario;
using api.Domain.Repository.Interface.WorkFlow;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Api.Controllers
{
    //[Authorize]
    [EnableCors("CorsPolicy")]
    [Produces("application/json")]
    [Route("{tenant_database}/api/Generics")]
    public class GenericsController : Controller
    {
        private readonly IIncidenteCategoriaRepository _incidenteCategoria;
        private readonly IIndiceFinanceiroRepository _indiceFinanceiro;
        private readonly IMatrizRepository _matriz;
        private readonly IPlanoAcaoStatusRepository _planoAcaoStatus;
        private readonly IStepStatusRepository _stepStatus;
        private readonly IUsuariosRepository _usuarios; 
        private readonly ILinhaNegocioRepository _LinhaNegocio; 
        private readonly IEmpresaClassificacaoRepository _empresaClassificacao;
        private readonly IOrgaoReguladorRepository _orgaoRegulador;
        private readonly IEstadoRepository _estado;
        private readonly IRiscoTratamentoTipoRepository _riscoTratamentoTipo;
        private readonly IRiscoAvaliacaoStatusRepository _RiscoAvaliacaoStatus;
        private readonly IPerfilAnaliseRepository _perfilAnalise;

        private readonly IControleRepository _controle; 
        private readonly IControleCategoriaRepository _controleCategoria;
        private readonly IControleFrequenciaRepository _controleFrequencia;
        private readonly IControleTipoRepository _controleTipo;
        private readonly IControleObjetivoRepository _controleObjetivo;
        private readonly IControleGrauAutomacaoRepository _controleGrauAutomacao;
        private readonly IControleAfirmacaoRepository _controleAfirmacao;
        private readonly IControleDemonstracaoFinanceiraRepository _controleDemonstracaoFinanceira;
        private readonly IControleCategoriaObjetivoRepository _controleCategoriaObjetivo;

        private readonly IRiscosRepository   _riscos; 
        private readonly IProcessoRepository _processo;
        private readonly IProcessoNivelRepository _processoNivel;
        private readonly IFatorRiscoRepository _fatorRisco;
        private readonly IIncidenteRepository _incidente;
        private readonly IPlanoAcaoRepository _planoAcao;
        private readonly ICategoriaRiscoRepository _categoriaRisco;
        private readonly ICausasRepository _causa;
        private readonly IImpactoRepository _impacto;
        private readonly IAcionistaRepository _acionista;

        private readonly IUsuarioAreaAtuacaoRepository _usuarioAreaAtuacao;
        private readonly IUsuarioCargoAtividadeRepository _usuarioCargoAtividade;
        private readonly IUsuarioGrupoClasseRepository _usuarioGrupoClasse;

        private readonly ITesteRepository _teste;
        private readonly ITesteStatusRepository _testeStatus;
        private readonly ITesteProcedimentoTipoRepository _testeProcedimentoTipo;
        private readonly ITesteProcedimentoNaturezaItemRepository _testeProcedimentoNaturezaItem; 
        private readonly IEmpresaAcaoSocietariaItemRepository _empresaAcaoSocietariaItem;
        private readonly INivelAcessoRepository _nivelAcesso;
        private readonly IWorkFlowStatusRepository _workFlowStatus; 

        private readonly IUnidadeOrganizacionalResponsabilidadeRepository _unidadeOrganizacionalResponsabilidade;
        private readonly IUnidadeOrganizacionalOrgaoRepository _unidadeOrganizacionalOrgao;

        private readonly IComplianceNormaTipoRepository _ComplianceNormaTipo;
        private readonly ICompliancePeriodoRevisaoRepository _CompliancePeriodoRevisao;
        private readonly IComplianceCriticidadeRepository _ComplianceCriticidade; 

        private readonly ILgpdTipoRepository _LgpdTipo;
        private readonly ILgpdTipoDadosRepository _LgpdTipoDados; 

        private readonly IDepartamentoRepository                _Departamento;
        private readonly IApontamentoCategoriaRepository        _apontamentoCategoria;
        private readonly IApontamentoClassificacaoRepository    _apontamentoClassificacao;

        public GenericsController(IIncidenteCategoriaRepository incidenteCategoria,
                                  IIndiceFinanceiroRepository indiceFinanceiro,
                                  IMatrizRepository matriz,
                                  IPlanoAcaoStatusRepository planoAcaoStatus,
                                  IStepStatusRepository stepStatus,
                                  IUsuariosRepository usuarios, 
                                  ILinhaNegocioRepository LinhaNegocio, 
                                  IEmpresaClassificacaoRepository empresaClassificacao,
                                  IOrgaoReguladorRepository orgaoRegulador,
                                  IEstadoRepository estado,
                                  IRiscoTratamentoTipoRepository riscoTratamentoTipo,
                                  IRiscoAvaliacaoStatusRepository RiscoAvaliacaoStatus,
                                  IPerfilAnaliseRepository perfilAnalise, 

                                  IControleCategoriaRepository  controleCategoria,  IControleFrequenciaRepository controleFrequencia, 
                                  IControleTipoRepository       controleTipo,       IControleObjetivoRepository controleObjetivo,
                                  IControleRepository           controle,           IControleGrauAutomacaoRepository controleGrauAutomacao,
                                  IControleAfirmacaoRepository  controleAfirmacao,  IControleDemonstracaoFinanceiraRepository controleDemonstracaoFinanceira,
                                  IControleCategoriaObjetivoRepository controleCategoriaObjetivo,

                                  IProcessoRepository processo, IProcessoNivelRepository processoNivel, IFatorRiscoRepository fatorRisco, IRiscosRepository riscos,
                                  IIncidenteRepository incidente, IPlanoAcaoRepository planoAcao, ICategoriaRiscoRepository categoriaRisco,
                                  ICausasRepository causa, IImpactoRepository impacto,
                                  IUsuarioAreaAtuacaoRepository usuarioAreaAtuacao, IUsuarioCargoAtividadeRepository usuarioCargoAtividade, IUsuarioGrupoClasseRepository usuarioGrupoClasse,
                                  IAcionistaRepository acionista,
                                  ITesteRepository teste, ITesteStatusRepository testeStatus, ITesteProcedimentoTipoRepository testeProcedimentoTipo,  
                                  ITesteProcedimentoNaturezaItemRepository testeProcedimentoNaturezaItem, 
                                  IEmpresaAcaoSocietariaItemRepository empresaAcaoSocietariaItem,
                                  INivelAcessoRepository nivelAcesso,
                                  IWorkFlowStatusRepository workFlowStatus, 
                                  IUnidadeOrganizacionalResponsabilidadeRepository unidadeOrganizacionalResponsabilidade, IUnidadeOrganizacionalOrgaoRepository unidadeOrganizacionalOrgao,
                                  IComplianceNormaTipoRepository ComplianceNormaTipo, ICompliancePeriodoRevisaoRepository CompliancePeriodoRevisao, IComplianceCriticidadeRepository ComplianceCriticidade,
                                  IApontamentoCategoriaRepository apontamentoCategoria, IApontamentoClassificacaoRepository apontamentoClassificacao,
                                  ILgpdTipoRepository LgpdTipo, ILgpdTipoDadosRepository LgpdTipoDados, 
                                  IDepartamentoRepository Departamento)
        {
            _Departamento                           = Departamento;

            
            _unidadeOrganizacionalResponsabilidade  = unidadeOrganizacionalResponsabilidade;
            _unidadeOrganizacionalOrgao             = unidadeOrganizacionalOrgao;

            _empresaAcaoSocietariaItem              = empresaAcaoSocietariaItem;
            _nivelAcesso                            = nivelAcesso;
            _workFlowStatus                         = workFlowStatus; 

            _teste                                  = teste;
            _testeStatus                            = testeStatus;
            _testeProcedimentoTipo                  = testeProcedimentoTipo; 
            _testeProcedimentoNaturezaItem          = testeProcedimentoNaturezaItem;

            _incidenteCategoria                     = incidenteCategoria;
            _indiceFinanceiro                       = indiceFinanceiro;
            _matriz                                 = matriz;
            _planoAcaoStatus                        = planoAcaoStatus;
            _stepStatus                             = stepStatus; 
            
            _LinhaNegocio                           = LinhaNegocio; 
            _empresaClassificacao                   = empresaClassificacao;
            _orgaoRegulador                         = orgaoRegulador;
            _estado                                 = estado;
            _riscoTratamentoTipo                    = riscoTratamentoTipo;
            _RiscoAvaliacaoStatus                   = RiscoAvaliacaoStatus;
            _perfilAnalise                          = perfilAnalise;

            _causa                                  = causa;
            _impacto                                = impacto;
            _riscos                                 = riscos;
            _categoriaRisco                         = categoriaRisco;
            _processo                               = processo;
            _fatorRisco                             = fatorRisco;
            _incidente                              = incidente;
            _planoAcao                              = planoAcao;

            _acionista                              = acionista;
            _usuarios                               = usuarios;
            _usuarioAreaAtuacao                     = usuarioAreaAtuacao;
            _usuarioCargoAtividade                  = usuarioCargoAtividade;
            _usuarioGrupoClasse                     = usuarioGrupoClasse;

            _controleCategoria                      = controleCategoria;
            _controleFrequencia                     = controleFrequencia;
            _controleTipo                           = controleTipo;
            _controleObjetivo                       = controleObjetivo;
            _controle                               = controle;
            _controleGrauAutomacao                  = controleGrauAutomacao;
            _controleAfirmacao                      = controleAfirmacao;
            _controleDemonstracaoFinanceira         = controleDemonstracaoFinanceira;
            _controleCategoriaObjetivo              = controleCategoriaObjetivo;
            _processoNivel                          = processoNivel;

            _ComplianceNormaTipo                    = ComplianceNormaTipo;
            _CompliancePeriodoRevisao               = CompliancePeriodoRevisao;
            _ComplianceCriticidade                  = ComplianceCriticidade;
            _LgpdTipo                               = LgpdTipo;
            _LgpdTipoDados                          = LgpdTipoDados; 

            _apontamentoClassificacao  = apontamentoClassificacao;
            _apontamentoCategoria      = apontamentoCategoria;

        }

        [HttpPost("GetList")]
        [EnableCors("CorsPolicy")]
        public async Task<ListGenericsOutput> GetList([FromBody] List<ListGenericsInput> input)
        {
            ListGenericsOutput ListReturn = new ListGenericsOutput();

            try
            {

                if (ModelState.IsValid)
                {
                    foreach (var item in input)
                    {
                        switch (item.Nome)
                        {
                            case "CategoriaRisco":
                                ListReturn.ListCategoriaRisco = ListItems.ListCategoriaRiscoSet(_categoriaRisco.GetAll(true).ToList(), 0);
                                break;


                            case "PlanoAcao":
                                ListReturn.ListPlanoAcao = ListItems.ListPlanoAcaoSet(_planoAcao.GetAll(true).ToList(), 0);
                                break;

                            case "PlanoAcaoStatus":
                                ListReturn.ListPlanoAcaoStatus = ListItems.ListPlanoAcaoStatusSet(_planoAcaoStatus.GetAll(true).ToList(), 0);
                                break;

                            case "ApontamentoCategoria":
                                ListReturn.ListApontamentoCategoria = ListItems.ListApontamentoCategoriaSet(_apontamentoCategoria.GetAll(true).ToList(), 0);
                                break;

                            case "ApontamentoClassificacao":
                                ListReturn.ListApontamentoClassificacao = ListItems.ListApontamentoClassificacaoSet(_apontamentoClassificacao.GetAll(true).ToList(), 0);
                                break;

                            case "Departamento":
                                ListReturn.ListDepartamento = ListItems.ListDepartamentoSet(_Departamento.GetAll(true).ToList(), 0);
                                break;
                                 

                            case "LgpdTipo":
                                ListReturn.ListLgpdTipo = ListItems.ListLgpdTipoSet(_LgpdTipo.GetAll(true).ToList(), 0);
                                break;

                            case "LgpdTipoDados":
                                ListReturn.ListLgpdTipoDados = ListItems.ListLgpdTipoDadosSet(_LgpdTipoDados.GetAll(true).ToList(), 0);
                                break; 

                            case "ComplianceCriticidade":
                                ListReturn.ListComplianceCriticidade = ListItems.ListComplianceCriticidadeSet(_ComplianceCriticidade.GetAny(true).ToList(), 0);
                                break;


                            case "CompliancePeriodoRevisao":
                                ListReturn.ListCompliancePeriodoRevisao = ListItems.ListCompliancePeriodoRevisaoSet(_CompliancePeriodoRevisao.GetAny(true).ToList(), 0);
                                break;

                            case "ComplianceNormaTipo":
                                ListReturn.ListComplianceNormaTipo = ListItems.ListComplianceNormaTipoSet(_ComplianceNormaTipo.GetAny(true).ToList(), 0);
                                break;

                            case "UnidadeOrganizacionalResponsabilidade":
                                ListReturn.ListUnidadeOrganizacionalResponsabilidade = ListItems.ListUnidadeOrganizacionalResponsabilidadeSet(_unidadeOrganizacionalResponsabilidade.GetAny(true).ToList(), 0);
                                break;

                            case "UnidadeOrganizacionalOrgao":
                                ListReturn.ListUnidadeOrganizacionalOrgao = ListItems.LisUnidadeOrganizacionalOrgaoSet(_unidadeOrganizacionalOrgao.GetAny(true).ToList(), 0);
                                break;
                                 

                            case "ProcessoNivel":
                                ListReturn.ListProcessoNivel = ListItems.ListProcessoNivelSet(_processoNivel.GetAny(true).ToList(), 0);
                                break;

                            case "WorkFlowStatus":
                                ListReturn.ListWorkFlowStatus = ListItems.ListWorkFlowStatusSet(_workFlowStatus.GetAny(true).ToList(), 0);
                                break;

                            case "NivelAcesso":
                                ListReturn.ListNivelAcesso = ListItems.ListNivelAcessoSet(_nivelAcesso.GetAll(true).ToList(), 0);
                                break;

                            case "EmpresaAcaoSocietariaItem":
                                ListReturn.ListEmpresaAcaoSocietariaItem = ListItems.ListEmpresaAcaoSocietariaItemSet(_empresaAcaoSocietariaItem.GetAny(true).ToList(), 0);
                                break;

                            /* Teste */
                            case "Teste":
                                ListReturn.ListTeste = ListItems.ListTesteSet(_teste.GetActive(true).ToList(), 0);
                                break;
                            case "TesteStatus":
                                ListReturn.ListTesteStatus = ListItems.ListTesteStatusSet(_testeStatus.GetAll(true).ToList(), 0);
                                break;
                            case "TesteProcedimentoTipo":
                                ListReturn.ListTesteProcedimentoTipo = ListItems.ListTesteProcedimentoTipoSet(_testeProcedimentoTipo.GetAll(true).ToList(), 0);
                                break;
                            case "TesteProcedimentoNaturezaItem":
                                ListReturn.ListTesteProcedimentoNaturezaItem = ListItems.ListTesteProcedimentoNaturezaItemSet(_testeProcedimentoNaturezaItem.GetAll(true).ToList(), 0);
                                break; 

                            /* Controles */
                            case "Controles":
                                ListReturn.ListControles = ListItems.ListControleSet(_controle.GetAll(true).ToList(), 0);
                                break;
                            case "ControleObjetivo":
                                ListReturn.ListControleObjetivo = ListItems.ListControleObjetivoSet(_controleObjetivo.GetAll(true).ToList(), 0);
                                break;

                            case "ControleTipo":
                                ListReturn.ListControleTipo = ListItems.ListControleTipoSet(_controleTipo.GetAll(true).ToList(), 0);
                                break;

                            case "ControleFrequencia":
                                ListReturn.ListControleFrequencia = ListItems.ListControleFrequenciaSet(_controleFrequencia.GetAll(true).ToList(), 0);
                                break;

                            case "ControleCategoria":
                                ListReturn.ListControleCategoria = ListItems.ListControleCategoriaSet(_controleCategoria.GetAll(true).ToList(), 0);
                                break;

                            case "ControleGrauAutomacao":
                                ListReturn.ListControleGrauAutomacao = ListItems.ListControleGrauAutomacaoSet(_controleGrauAutomacao.GetAll(true).ToList(), 0);
                                break;

                            case "ControleAfirmacao":
                                ListReturn.ListControleAfirmacao = ListItems.ListControleAfirmacaoSet(_controleAfirmacao.GetAll(true).ToList(), 0);
                                break;

                            case "ControleDemonstracaoFinanceira":
                                ListReturn.ListControleDemonstracaoFinanceira = ListItems.ListControleDemonstracaoFinanceiraSet(_controleDemonstracaoFinanceira.GetAll(true).ToList(), 0);
                                break;

                            case "ControleCategoriaObjetivo":
                                ListReturn.ListControleCategoriaObjetivo = ListItems.ListControleCategoriaObjetivoSet(_controleCategoriaObjetivo.GetAll(true).ToList(), 0);
                                break;


                            /* outros */
                            case "Usuarios":
                                ListReturn.ListUsuarios = ListItems.ListUsuariosSet(_usuarios.GetAll(true).ToList(), 0);
                                break; 
                            case "UsuarioAreaAtuacao":
                                ListReturn.ListUsuarioAreaAtuacao = ListItems.ListUsuarioAreaAtuacaoSet(_usuarioAreaAtuacao.GetAll(true).ToList(), 0);
                                break;
                            case "UsuarioCargoAtividade":
                                ListReturn.ListUsuarioCargoAtividade = ListItems.ListUsuarioCargoAtividadeSet(_usuarioCargoAtividade.GetAll(true).ToList(), 0);
                                break;
                            case "UsuarioGrupoClasse":
                                ListReturn.ListUsuarioGrupoClasse = ListItems.ListUsuarioGrupoClasseSet(_usuarioGrupoClasse.GetAll(true).ToList(), 0);
                                break;

                            case "Acionistas":
                                ListReturn.ListAcionistas = ListItems.ListAcionistasSet(_acionista.GetAll(true).ToList(), 0);
                                break;

                            case "Causas":
                                ListReturn.ListCausas = ListItems.ListCausaSet(_causa.GetAll(true).ToList(), 0);
                                break;

                            case "Impactos":
                                ListReturn.ListImpactos = ListItems.ListImpactoSet(_impacto.GetAll(true).ToList(), 0);
                                break;

                            case "Riscos":
                                ListReturn.ListRiscos = ListItems.ListRiscosSet(_riscos.GetAll(true).ToList(), 0);
                                break; 

                            case "Processos":
                                ListReturn.ListProcessos = ListItems.ListProcessoSet(_processo.GetAll(true).ToList(), 0);
                                break;

                            case "FatorRisco":
                                ListReturn.ListFatorRisco = ListItems.ListFatorRiscoSet(_fatorRisco.GetAll(true).ToList(), 0);
                                break;

                            case "Incidente":
                                ListReturn.ListIncidentes = ListItems.ListIncidenteSet(_incidente.GetAll(true).ToList(), 0);
                                break;


                            case "PerfilAnalise":
                                ListReturn.ListPerfilAnalise = ListItems.ListPerfilAnaliseSet(_perfilAnalise.GetAll(true).ToList(), 0);
                                break;

                            case "RiscoAvaliacaoStatus":
                                ListReturn.ListRiscoAvaliacaoStatus = ListItems.ListRiscoAvaliacaoStatusSet(_RiscoAvaliacaoStatus.GetAll(true).ToList(), 0);
                                break;

                            case "RiscoTratamentoTipo":
                                ListReturn.ListRiscoTratamentoTipo = ListItems.ListRiscoTratamentoTipoSet(_riscoTratamentoTipo.GetAll(true).ToList(), 0);
                                break;

                            case "Estados":
                                ListReturn.ListEstados = ListItems.ListEstadosSet(_estado.GetAll(true).ToList(), 0);
                                break;

                            case "TipoLogradouro":
                                ListReturn.ListTipoLogradouro = ListItems.ListTipoLogradouro();
                                break;

                            case "UF":
                                ListReturn.ListUF = ListItems.ListUF();
                                break;

                            case "EmpresaClassificacao":
                                ListReturn.ListEmpresaClassificacao = ListItems.ListEmpresaClassificacaoSet(_empresaClassificacao.GetAll(true).ToList(), 0);
                                break;

                            case "OrgaoRegulador":
                                ListReturn.ListOrgaoRegulador = ListItems.ListOrgaoReguladorSet(_orgaoRegulador.GetAll(true).ToList(), 0);
                                break; 

                            case "LinhaNegocio":
                                ListReturn.ListLinhaNegocio = ListItems.ListLinhaNegocioSet(_LinhaNegocio.GetAll(true).ToList(), 0);
                                break;

                            case "IncidenteCategoria": 
                                ListReturn.ListIncidenteCategoria = ListItems.ListIncidenteCategoriaSet(_incidenteCategoria.GetAll(true).ToList(), 0);
                                break;

                            case "Matriz":
                                ListReturn.ListMatriz = ListItems.ListMatrizSet(_matriz.GetAll(true).ToList(), 0);
                                break;

                            case "IndiceFinanceiro":
                                ListReturn.ListIndiceFinanceiro = ListItems.ListIndiceFinanceiroSet(_indiceFinanceiro.GetAll(true).ToList(), 0);
                                break;

                            case "StepStatus":
                                ListReturn.ListStepStatus = ListItems.ListStepStatusSet(_stepStatus.GetAll(true).ToList(), 0);
                                break;


                            default:
                                break;
                        }
                    }
                }

                await Task.Delay(1);
                return ListReturn; 

            }
            catch (System.Exception ex)
            {
                return ListReturn;
            }
        }

        [HttpPost("GetEnderecoCorreios")]
        [EnableCors("CorsPolicy")]
        public async Task<IActionResult> GetEnderecoCorreios([FromBody] string Cep)
        {
            await Task.Delay(1);

            try
            {

                Regex regexObj = new Regex(@"[^\d]");
                Cep = regexObj.Replace(Cep, "");

                var end = new CepConsulta
                {
                    Cep = Cep
                };

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.buscacep.correios.com.br/sistemas/buscacep/resultadoBuscaCepEndereco.cfm");
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                byte[] postBytes = Encoding.ASCII.GetBytes("relaxation=" + Cep.Replace("-", "") + "&tipoCEP=ALL&semelhante=N");

                request.GetRequestStream()
                    .Write(postBytes, 0, postBytes.Length);

                string responseText = new StreamReader(request.GetResponse().GetResponseStream(), Encoding.GetEncoding("ISO-8859-1")).ReadToEnd();

                string s = responseText.Substring(responseText.LastIndexOf("<tr>"));
                s = s.Substring(0, s.LastIndexOf("</tr>"));
                s = s.Replace("<tr>", "");
                s = s.Replace("</tr>", "");
                s = s.Replace("&nbsp;", "");
                s = s.Replace("\r", "\n");

                List<string> Address = new List<string>();
                const string pattern = @"<td\b[^>]*?>(?<V>[\s\S]*?)</\s*td>";
                foreach (Match match in Regex.Matches(s, pattern, RegexOptions.IgnoreCase))
                {
                    string value = match.Groups["V"].Value;
                    Address.Add(value);
                }

                end.Rua = Address[0];
                end.Bairro = Address[1];
                end.Cidade = Address[2].Substring(0, Address[2].LastIndexOf("/"));
                end.UF = Address[2].Substring(Address[2].LastIndexOf("/") + 1);

                if (Address[0] == "")
                    end.universalCep = true;

                return Response(end, "success");

            }
            catch (System.Exception ex)
            {
                return Response("Não foi possível localizar pelo Cep: " + Cep, ex.Message);
            }
        }

        protected new ActionResult Response(object result,  string message)
        {
            return Ok(new
            {
                success = true,
                data = result,
                message
            });
        }
    }
}
