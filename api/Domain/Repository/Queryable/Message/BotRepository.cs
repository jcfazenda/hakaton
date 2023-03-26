using api.Domain.Models.Message;
using api.Domain.Repository.Interface.Message;
using api.Domain.Views.Input.Message;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace api.Domain.Repository.Queryable.Message
{
    public class BotRepository : Repository<Bot, decimal>, IBotRepository
    {
        private readonly GRCContext _context;
        public BotRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Bot> GetApi(long id)
        {
            var data = DbSet.Where(x => x.Id_Bot.Equals(id)).AsQueryable();

            return data;
        }

        public IQueryable<Bot> GetById(long id)
        {
            var data = DbSet.Include(i => i.BotStatus)
                            .Where(x => x.Id_Bot.Equals(id)).AsQueryable();

            return data;
        }

        public IQueryable<Bot> GetAny(bool active)
        {
            var data = DbSet.Include(i => i.BotStatus)
                            .Where(x => x.Fl_Ativo.Equals(active)).AsQueryable();

            return data;
        }

        public bool UpdateStatus(BotInput input)
        {
            Bot data = DbSet.Where(x => x.Id_Bot.Equals(input.Id_Bot)).AsQueryable().FirstOrDefault();

            data.Id_Status = input.Id_Status; 

            _context.Add(data);
            _context.SaveChanges();

            return true;

        }

        public bool Update(BotInput input)
        {
            Bot data = DbSet.Where(x => x.Id_Bot.Equals(input.Id_Bot)).AsQueryable().FirstOrDefault();
             
            data.Bot_Nome       = input.Bot_Nome;
            data.Icone          = input.Icone;
            data.Bot_Descricao  = input.Bot_Descricao; 

            _context.Add(data);
            _context.SaveChanges();

            return true;

        }

        public Bot Create(BotInput input)
        {
            Bot data = new Bot
            {
                Id_Status       = input.Id_Status,
                Bot_Nome        = input.Bot_Nome,
                Icone           = input.Icone,
                Bot_Descricao   = input.Bot_Descricao, 
                Fl_Ativo        = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return data;

        }

        public bool Remove(long id)
        {
            Bot data = DbSet.Where(x => x.Id_Bot.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }


    }
}
