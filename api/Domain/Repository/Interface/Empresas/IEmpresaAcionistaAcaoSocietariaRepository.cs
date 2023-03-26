using api.Domain.Models.Empresas;
using api.Domain.Views.Input.Empresas;
using System.Linq;

namespace api.Domain.Repository.Interface.Empresas
{
    public interface IEmpresaAcionistaAcaoSocietariaRepository : IRepository<EmpresaAcionistaAcaoSocietaria, decimal>
    {
        IQueryable<EmpresaAcionistaAcaoSocietaria> GetByAcionista(long idAcionista, long idEmpresa);
        bool Create(EmpresaAcionistaAcaoSocietariaInput input);
        bool Remove(long id);
        bool RemoveByAcionista(long id);

    }
}
