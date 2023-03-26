using api.Domain.Models.LGPD;
using api.Domain.Views.Input.LGPD;
using System.Linq;

namespace api.Domain.Repository.Interface.LGPD
{
    public interface ILgpdQuizProcessoRepository : IRepository<LgpdQuizProcesso, decimal>
    {
        IQueryable<LgpdQuizProcesso> GetAll(bool active);
        IQueryable<LgpdQuizProcesso> GetByProcesso(long idProcesso);
        IQueryable<LgpdQuizProcesso> GetByQuiz(long idQuiz);
        bool Create(LgpdQuizProcessoInput input);
        bool Update(LgpdQuizProcessoInput input);
        bool UpdateDescritivo(LgpdQuizProcessoInput input);
        bool Remove(long id);

    }
}
