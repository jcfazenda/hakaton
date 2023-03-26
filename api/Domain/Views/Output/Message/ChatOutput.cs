using System;
namespace api.Domain.Views.Output.Message
{
	public class ChatOutput
	{
        public long Id_Chat { get; set; }
        public long Id_Bot { get; set; }
        public long Id_Usuario { get; set; }

        public string Mensagem { get; set; }
        public DateTime? Data_Hora { get; set; }
        public bool? Fl_Bot { get; set; }
        public bool? Fl_Ativo { get; set; }
    }
}

