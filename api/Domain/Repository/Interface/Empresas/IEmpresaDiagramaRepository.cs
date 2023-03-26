using api.Domain.Models.Empresas;
using api.Domain.Views.Input.Empresas;
using System.Linq;

namespace api.Domain.Repository.Interface.Empresas
{
    public interface IEmpresaDiagramaRepository : IRepository<EmpresaDiagrama, decimal>
    {
        IQueryable<EmpresaDiagrama> GetByEmpresa(long id);
        bool Create(EmpresaDiagramaInput input);
        bool Remove(long id);

    }
}
