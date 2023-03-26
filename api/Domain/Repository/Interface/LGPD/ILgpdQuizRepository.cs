using api.Domain.Models.LGPD;
using api.Domain.Views.Input.LGPD;
using System.Linq;

namespace api.Domain.Repository.Interface.LGPD
{
    public interface ILgpdQuizRepository : IRepository<LgpdQuiz, decimal>
    {
        IQueryable<LgpdQuiz> GetAll(bool active);
        IQueryable<LgpdQuiz> GetByTipo(long idTipo); 
        bool Create(LgpdQuizInput input);
        bool Update(LgpdQuizInput input);
        bool Remove(long id);

    }
}
