using api.Domain.Models.Empresas;
using api.Domain.Views.Input.Empresas;
using System.Collections.Generic;
using System.Linq;

namespace api.Domain.Repository.Interface.Empresas
{
    public interface IEmpresaRiscoRepository : IRepository<EmpresaRisco, decimal>
    {
        IQueryable<EmpresaRisco> GetByEmpresa(long id, bool Ativo);
        IQueryable<EmpresaRisco> GetByEmpresas(long id, bool Ativo);

        IQueryable<EmpresaRisco> GetByRiscoList(List<long> List, bool Ativo);
        IQueryable<EmpresaRisco> GetByEmpresaList(List<long> List, bool Ativo);
        bool Create(EmpresaRiscoInput input);
        bool Remove(long id);

    }
}
