using api.Domain.Models.Empresas;
using api.Domain.Views.Input.Empresas;
using System.Linq;

namespace api.Domain.Repository.Interface.Empresas
{
    public interface IEmpresaLinhaNegocioRepository : IRepository<EmpresaLinhaNegocio, decimal>
    {
        IQueryable<EmpresaLinhaNegocio> GetByEmpresa(long id);
        bool Create(EmpresaLinhaNegocioInput input);
        bool Remove(long id);

    }
}
