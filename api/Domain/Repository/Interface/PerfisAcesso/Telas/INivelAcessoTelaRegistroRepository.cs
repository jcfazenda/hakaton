
using api.Domain.Models.PerfisAcesso.Telas;
using api.Domain.Views.Input.PerfisAcesso.Telas;
using System.Linq;

namespace api.Domain.Repository.Interface.PerfisAcesso.Telas
{
    public interface INivelAcessoTelaRegistroRepository : IRepository<NivelAcessoTelaRegistro, decimal>
    {
        IQueryable<NivelAcessoTelaRegistro> GetAll(bool active);
        IQueryable<NivelAcessoTelaRegistro> GetByNivelAndTela(long idNivel, long idTela);
        IQueryable<NivelAcessoTelaRegistro> GetExist(NivelAcessoTelaRegistroInput input);
        IQueryable<NivelAcessoTelaRegistro> GetById(long id);
        IQueryable<NivelAcessoTelaRegistro> GetByTelaRegistro(NivelAcessoTelaRegistroInput input);



        bool UpdateStatus(long id);
        bool Create(NivelAcessoTelaRegistroInput input);
        bool Update(NivelAcessoTelaRegistroInput input);
        bool Remove(long id);

    }
}
