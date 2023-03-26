using api.Domain.Models.Message;
using api.Domain.Repository.Interface.Message;
using api.Domain.Views.Input.Message;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace api.Domain.Repository.Queryable.Message
{
    public class ChatRepository : Repository<Chat, decimal>, IChatRepository
    {
        private readonly GRCContext _context;
        public ChatRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Chat> GetMessage(long idBot, long idUsuario)
        {
            var data = DbSet.Where(x => x.Id_Bot.Equals(idBot) &&
                                        x.Id_Usuario.Equals(idUsuario)).AsQueryable();

            return data;
        }

        public IQueryable<Chat> GetAll(bool active)
        {
            var data = DbSet.Where(x => x.Fl_Ativo.Equals(active)).AsQueryable();

            return data;
        }

        public Chat Create(ChatInput input)
        {
            Chat data = new Chat
            {
                Id_Usuario      = input.Id_Usuario,
                Id_Bot          = input.Id_Bot,
                Mensagem        = input.Mensagem,
                Fl_Bot          = input.Fl_Bot,
                Data_Hora       = System.DateTime.Now,
                Fl_Ativo        = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return data;

        }
        public bool Remove(long id)
        {
            Chat data = DbSet.Where(x => x.Id_Chat.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }


    }
}
