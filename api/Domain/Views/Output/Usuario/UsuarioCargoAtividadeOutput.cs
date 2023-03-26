namespace api.Domain.Views.Output.Usuario
{
    public class UsuarioCargoAtividadeOutput
    {
        public long Id_Usuario_Cargo_Atividade { get; set; }

        public string Usuario_Cargo_Atividade_Nome { get; set; }
        public string Usuario_Cargo_Atividade_Descricao { get; set; }

        public bool? Fl_Ativo { get; set; }
    }
}
