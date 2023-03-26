
using api.Domain.Models.PerfisAcesso.Telas;
using api.Domain.Views.Input.PerfisAcesso.Telas;
using System.Linq;

namespace api.Domain.Repository.Interface.PerfisAcesso.Telas
{
    public interface INivelAcessoTelaFuncaoRepository : IRepository<NivelAcessoTelaFuncao, decimal>
    {
        IQueryable<NivelAcessoTelaFuncao> GetAll(bool active);
        IQueryable<NivelAcessoTelaFuncao> GetByNivel(long id);
        IQueryable<NivelAcessoTelaFuncao> GetByNivelTela(long idNivel, long idTela);
        IQueryable<NivelAcessoTelaFuncao> GetByTela(long idTela);
        IQueryable<NivelAcessoTelaFuncao> GetExist(NivelAcessoTelaFuncaoInput input);

        bool UpdateStatus(long id);
        bool Create(NivelAcessoTelaFuncaoInput input);
        bool Update(NivelAcessoTelaFuncaoInput input);
        bool Remove(long id);

    }
}
