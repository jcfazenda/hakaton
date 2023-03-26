using api.Domain.Models.UnidadesOrganizacionais;
using api.Domain.Views.Input.UnidadesOrganizacionais;
using System.Linq;

namespace api.Domain.Repository.Interface.UnidadesOrganizacionais
{
    public interface IUnidadeOrganizacionalOrgaoRepository : IRepository<UnidadeOrganizacionalOrgao, decimal>
    {
        IQueryable<UnidadeOrganizacionalOrgao> GetAny(bool active);

        bool UpdateStatus(long id);
        long Create(UnidadeOrganizacionalOrgaoInput input);
        long Update(UnidadeOrganizacionalOrgaoInput input);
        bool Remove(long id);
    }
}
