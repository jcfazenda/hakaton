using System;
namespace api.Domain.Views.Input.Message
{
	public class BotInput
	{
        public long Id_Bot { get; set; }
        public long Id_Status { get; set; }

        public string Api { get; set; }
        public string Bot_Nome { get; set; }
        public string Bot_Descricao { get; set; }
        public string Icone { get; set; }
        public bool? Fl_Ativo { get; set; }

        public string Key_Vonage_Voice { get; set; }
        public string Phone { get; set; }

        public string Rota { get; set; }
    }
}

