using api.Domain.Models.Empresas;
using api.Domain.Views.Input.Empresas;
using System.Linq;

namespace api.Domain.Repository.Interface.Empresas
{
    public interface IOrgaoReguladorRepository : IRepository<OrgaoRegulador, decimal>
    {
        IQueryable<OrgaoRegulador> GetAll(bool active);
        bool UpdateStatus(long id);
        bool Create(OrgaoReguladorInput input);
        bool Update(OrgaoReguladorInput input);
        bool Remove(long id);

    }
}
