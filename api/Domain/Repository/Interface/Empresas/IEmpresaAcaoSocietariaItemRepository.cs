using api.Domain.Models.Empresas;
using api.Domain.Views.Input.Empresas;
using System.Linq;

namespace api.Domain.Repository.Interface.Empresas
{
    public interface IEmpresaAcaoSocietariaItemRepository : IRepository<EmpresaAcaoSocietariaItem, decimal>
    {
        IQueryable<EmpresaAcaoSocietariaItem> GetAny(bool Active);
        long Create(EmpresaAcaoSocietariaItemInput input);
        bool Update(EmpresaAcaoSocietariaItemInput input);
        bool Remove(long id);

    }
}
