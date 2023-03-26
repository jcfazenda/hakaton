using api.Domain.Models.Message;
using api.Domain.Views.Input.Message;
using System.Linq;

namespace api.Domain.Repository.Interface.Message
{
    public interface IChatRepository : IRepository<Chat, decimal>
    {
        IQueryable<Chat> GetAll(bool active);
        IQueryable<Chat> GetMessage(long idBot, long idUsuario);

        Chat Create(ChatInput input);   

        bool Remove(long id);

    }
}
