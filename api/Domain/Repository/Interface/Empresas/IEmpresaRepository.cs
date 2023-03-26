using api.Domain.Models.Empresas;
using api.Domain.Views.Input.Empresas;
using System.Collections.Generic;
using System.Linq;

namespace api.Domain.Repository.Interface.Empresas
{
    public interface IEmpresaRepository : IRepository<Empresa, decimal>
    {
        IQueryable<Empresa> GetAll(bool active);
        bool UpdateStatus(long id);
        bool UpdateIdEndereco(long idEmpresa, long idEmdereco); 
        long Create(EmpresaInput input);
        bool Update(EmpresaInput input);
        bool Remove(long id);

    }
}
