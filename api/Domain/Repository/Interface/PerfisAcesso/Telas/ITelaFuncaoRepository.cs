
using api.Domain.Models.PerfisAcesso.Telas;
using api.Domain.Views.Input.PerfisAcesso.Telas;
using System.Linq;

namespace api.Domain.Repository.Interface.PerfisAcesso.Telas
{
    public interface ITelaFuncaoRepository : IRepository<TelaFuncao, decimal>
    {
        IQueryable<TelaFuncao> GetAll(bool active);
        IQueryable<TelaFuncao> GetByTela(long id);
        IQueryable<TelaFuncao> GetByCodFuncao(string codFuncao, long idTela);

        bool UpdateStatus(long id);
        long Create(TelaFuncaoInput input);
        bool CreateByTela(TelaFuncaoInput input);

        long Update(TelaFuncaoInput input);
        bool Remove(long id);
        bool RemoveByTela(long idTela);

    }
}
