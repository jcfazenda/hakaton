using api.Domain.Models.Indice;
using api.Domain.Views.Input.Indice;
using System.Linq;

namespace api.Domain.Repository.Interface.Indice
{
    public interface IMatrizItemCorRepository : IRepository<MatrizItemCor, decimal>
    { 
        IQueryable<MatrizItemCor> GetByMatrizItem(long id);
        IQueryable<MatrizItemCor> GetByMatriz(long id);
        IQueryable<MatrizItemCor> GetExist(MatrizItemCorInput input);
        bool Create(MatrizItemCorInput input);
        bool UpdateBackground(MatrizItemCorInput input);
        bool Remove(long id);
        bool RemoveByMatrizItem(long id);

    }
}
