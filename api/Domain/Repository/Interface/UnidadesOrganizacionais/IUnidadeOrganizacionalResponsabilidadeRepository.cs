using api.Domain.Models.UnidadesOrganizacionais;
using api.Domain.Views.Input.UnidadesOrganizacionais;
using System.Linq;

namespace api.Domain.Repository.Interface.UnidadesOrganizacionais
{
    public interface IUnidadeOrganizacionalResponsabilidadeRepository : IRepository<UnidadeOrganizacionalResponsabilidade, decimal>
    {
        IQueryable<UnidadeOrganizacionalResponsabilidade> GetAny(bool active);

        bool UpdateStatus(long id);
        long Create(UnidadeOrganizacionalResponsabilidadeInput input);
        long Update(UnidadeOrganizacionalResponsabilidadeInput input);
        bool Remove(long id);
    }
}
