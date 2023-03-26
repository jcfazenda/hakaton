using api.Domain.Models.Message;
using api.Domain.Views.Input.Message;
using api.Domain.Views.Input.Usuario;
using System.Linq;

namespace api.Domain.Repository.Interface.Message
{
    public interface IBotRepository : IRepository<Bot, decimal>
    {
        IQueryable<Bot> GetAny(bool active);
        IQueryable<Bot> GetApi(long id);
        IQueryable<Bot> GetById(long id);

        Bot Create(BotInput input);

        bool Update(BotInput input);
        bool UpdateStatus(BotInput input);
        bool Remove(long id);

    }
}
