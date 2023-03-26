using api.Domain.Models.Empresas;
using api.Domain.Views.Input.Empresas;
using System.Linq;

namespace api.Domain.Repository.Interface.Empresas
{
    public interface IEmpresaEnderecoRepository : IRepository<EmpresaEndereco, decimal>
    {
        IQueryable<EmpresaEndereco> GeById(long id);
        IQueryable<EmpresaEndereco> GetAll(bool active);
        bool UpdateStatus(long id);
        long Create(EmpresaEnderecoInput input);
        bool Update(EmpresaEnderecoInput input);
        bool Remove(long id);

        bool RemoveByEmpresa(long id);

    }
}
