using api.Domain.Models.CarrieMessage;
using api.Domain.Views.Input.CarrieMessage;
using System.Linq;

namespace api.Domain.Repository.Interface.CarrieMessage
{
    public interface ICorreioRepository : IRepository<Correio, decimal>
    {
        IQueryable<Correio> GetAll(bool active);
        IQueryable<Correio> GetByCorreio(long id);
        IQueryable<Correio> GetByUsuarioReceive(long id, bool fl_Lido);
        bool UpdateLido(long id);
        bool UpdateStatus(long id); 
        bool Create(CorreioInput input);
        bool Update(CorreioInput input);
        bool Remove(long id);

    }
}
