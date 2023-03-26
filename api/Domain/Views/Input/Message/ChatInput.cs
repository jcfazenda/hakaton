using System;
namespace api.Domain.Views.Input.Message
{
	public class ChatInput
	{
        public long Id_Chat { get; set; }
        public long Id_Bot { get; set; }
        public long Id_Usuario { get; set; }

        public string Mensagem { get; set; }
        public DateTime? Data_Hora { get; set; }
        public bool? Fl_Bot { get; set; }
        public bool? Fl_Ativo { get; set; }

        public string Rota { get; set; }
    }
}

