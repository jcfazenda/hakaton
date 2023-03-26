
using System;
using System.Collections.Generic;

namespace api.Domain.Models.Message
{
    public class BotStatus
    {
        public BotStatus()
        {
        }

        public BotStatus(long id_Bot_Status, string bot_Status_Nome)
        {
            Id_Bot_Status = id_Bot_Status;
            Bot_Status_Nome = bot_Status_Nome;
        }

        public long Id_Bot_Status { get; set; } 
        public string Bot_Status_Nome { get; set; }

        public IEnumerable<Bot> Bot { get; set; }

    }
}
