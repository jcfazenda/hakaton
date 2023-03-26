using api.Domain.Models.Message;
using api.Domain.Views.Input.Message;
using System.Linq;

namespace api.Domain.Repository.Interface.Message
{
    public interface IBotStatusRepository : IRepository<BotStatus, decimal>
    { 
        BotStatus Create(BotStatusInput input);

        bool Update(BotStatusInput input);
        bool Remove(long id);

    }
}
