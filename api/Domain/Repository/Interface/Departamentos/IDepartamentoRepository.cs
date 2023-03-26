using api.Domain.Models.Departamentos;
using api.Domain.Views.Input.Departamentos;
using System.Linq;

namespace api.Domain.Repository.Interface.Departamentos
{
    public interface IDepartamentoRepository : IRepository<Departamento, decimal>
    {
        IQueryable<Departamento> GetAll(bool active);
        bool UpdateStatus(long id); 
        long Create(DepartamentoInput input);
        bool Update(DepartamentoInput input);
        bool Remove(long id);

    }
}
