
using System;
using System.Collections.Generic;

namespace api.Domain.Models.Message
{
    public class Bot
    {
        public Bot()
        {
        }

        public Bot(long id_Bot, long id_Status, string api, string bot_Nome, string bot_Descricao, string icone, string key_Vonage_Voice, bool? fl_Ativo)
        {
            Id_Bot = id_Bot;
            Id_Status = id_Status;
            Api = api;
            Bot_Nome = bot_Nome;
            Bot_Descricao = bot_Descricao;
            Icone = icone;
            Key_Vonage_Voice = key_Vonage_Voice;
            Fl_Ativo = fl_Ativo;
        }

        public long Id_Bot { get; set; }
        public long Id_Status { get; set; }

        public string Api { get; set; }
        public string Bot_Nome { get; set; }
        public string Bot_Descricao { get; set; }
        public string Icone { get; set; }
        public string Key_Vonage_Voice { get; set; }
        public bool? Fl_Ativo { get; set; }

        public BotStatus BotStatus { get; set; }
    }
}
