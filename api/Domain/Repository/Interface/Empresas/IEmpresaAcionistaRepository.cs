using api.Domain.Models.Empresas;
using api.Domain.Views.Input.Empresas;
using System.Linq;

namespace api.Domain.Repository.Interface.Empresas
{
    public interface IEmpresaAcionistaRepository : IRepository<EmpresaAcionista, decimal>
    {
        IQueryable<EmpresaAcionista> GetByEmpresa(long id);
        bool Create(EmpresaAcionistaInput input); 
        bool UpdatePercentual(EmpresaAcionistaInput input);
        IQueryable<EmpresaAcionista> GetByAcionista(long id);
        bool Remove(long id);

    }
}
