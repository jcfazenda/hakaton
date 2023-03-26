using api.Domain.Models.Empresas;
using api.Domain.Views.Input.Empresas;
using System.Linq;

namespace api.Domain.Repository.Interface.Empresas
{
    public interface IEmpresaClassificacaoRepository : IRepository<EmpresaClassificacao, decimal>
    {
        IQueryable<EmpresaClassificacao> GetAll(bool active);
        bool UpdateStatus(long id);
        long Create(EmpresaClassificacaoInput input);
        bool Update(EmpresaClassificacaoInput input);
        bool Remove(long id);

    }
}
