using System;
using api.Domain.Models.Message;

namespace api.Domain.Views.Output.Message
{
	public class BotOutput
	{
        public long Id_Bot { get; set; }
        public long Id_Status { get; set; }

        public string Api { get; set; }
        public string Bot_Nome { get; set; }
        public string Bot_Descricao { get; set; }
        public string Icone { get; set; }
        public bool? Fl_Ativo { get; set; }
        public string Key_Vonage_Voice { get; set; }

        public BotStatus BotStatus { get;  set; }
    }
}

