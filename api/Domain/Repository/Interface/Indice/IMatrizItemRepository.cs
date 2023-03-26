using api.Domain.Models.Indice;
using api.Domain.Views.Input.Indice;
using System.Linq;

namespace api.Domain.Repository.Interface.Indice
{
    public interface IMatrizItemRepository : IRepository<MatrizItem, decimal>
    {
        IQueryable<MatrizItem> GetAll(bool active);
        IQueryable<MatrizItem> GetByMatriz(long id);

        
        bool UpdateStatus(long id);
        long Create(MatrizItemInput input);
        bool Update(MatrizItemInput input);
        bool Remove(long id);
        bool RemoveByMatriz(long id);

    }
}
