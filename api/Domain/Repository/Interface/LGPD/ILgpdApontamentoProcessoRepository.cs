using api.Domain.Models.LGPD;
using api.Domain.Views.Input.LGPD;
using System.Linq;

namespace api.Domain.Repository.Interface.LGPD
{
    public interface ILgpdApontamentoProcessoRepository : IRepository<LgpdApontamentoProcesso, decimal>
    { 
        IQueryable<LgpdApontamentoProcesso> GetByProcesso(long idProcesso);
        bool Create(LgpdApontamentoProcessoInput input);
        bool Update(LgpdApontamentoProcessoInput input);
        bool Remove(long id);

    }
}
