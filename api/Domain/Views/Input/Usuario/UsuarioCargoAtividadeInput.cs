namespace api.Domain.Views.Input.Usuario
{
    public class UsuarioCargoAtividadeInput
    {
        public long Id_Usuario_Cargo_Atividade { get; set; }

        public string Usuario_Cargo_Atividade_Nome { get; set; }
        public string Usuario_Cargo_Atividade_Descricao { get; set; }

        public bool? Fl_Ativo { get; set; }


        public long Id { get; set; }
        public string Rota { get; set; }
    }
}
