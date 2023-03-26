namespace api.Domain.Views.Input.Usuario
{
    public class UsuarioGrupoClasseInput
    {
        public long Id_Usuario_Grupo_Classe { get; set; }

        public string Usuario_Grupo_Classe_Nome { get; set; }
        public string Usuario_Grupo_Classe_Descricao { get; set; }

        public bool? Fl_Ativo { get; set; }

        public long Id { get; set; }
        public string Rota { get; set; }
    }


}
