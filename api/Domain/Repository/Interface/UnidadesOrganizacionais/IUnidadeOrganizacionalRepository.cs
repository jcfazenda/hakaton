using api.Domain.Models.UnidadesOrganizacionais;
using api.Domain.Views.Input.UnidadesOrganizacionais;
using System.Linq;

namespace api.Domain.Repository.Interface.UnidadesOrganizacionais
{
    public interface IUnidadeOrganizacionalRepository : IRepository<UnidadeOrganizacional, decimal>
    {
        IQueryable<UnidadeOrganizacional> GetAny(bool active);

        bool UpdateStatus(long id);
        long Create(UnidadeOrganizacionalInput input);
        long Update(UnidadeOrganizacionalInput input);
        bool Remove(long id);
    }
}
