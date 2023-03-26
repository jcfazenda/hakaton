using api.Domain.Models.Message;
using api.Domain.Repository.Interface.Message;
using api.Domain.Views.Input.Message;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace api.Domain.Repository.Queryable.Message
{
    public class BotStatusRepository : Repository<BotStatus, decimal>, IBotStatusRepository
    {
        private readonly GRCContext _context;
        public BotStatusRepository(GRCContext context) : base(context)
        {
            _context = context;
        }
 

        public bool Update(BotStatusInput input)
        {
            BotStatus data = DbSet.Where(x => x.Id_Bot_Status.Equals(input.Id_Bot_Status)).AsQueryable().FirstOrDefault();

            data.Bot_Status_Nome = input.Bot_Status_Nome; 

            _context.Add(data);
            _context.SaveChanges();

            return true;

        }

        public BotStatus Create(BotStatusInput input)
        {
            BotStatus data = new BotStatus
            { 
                Bot_Status_Nome = input.Bot_Status_Nome 
            };
            _context.Add(data);
            _context.SaveChanges();

            return data;

        }

        public bool Remove(long id)
        {
            BotStatus data = DbSet.Where(x => x.Id_Bot_Status.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }


    }
}
