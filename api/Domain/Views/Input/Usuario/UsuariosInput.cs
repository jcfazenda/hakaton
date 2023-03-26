namespace api.Domain.Views.Input.Usuario
{
    public class UsuariosInput
    {
        public long Id_Usuario { get; set; }

        public string Usuario_Nome { get; set; }
        public string Usuario_Sobrenome { get; set; }
        public string Usuario_Email { get; set; }
        public string Usuario_Senha { get; set; }
        public string Usuario_Avatar { get; set; }

        public bool? Fl_Ativo { get; set; }
        public long Id_Cliente { get; set; }
        public string Rota { get; set; }

    }
}
