using System.Collections.Generic;

namespace api.Domain.Models.Usuario
{
    public class UsuarioGrupoClasse
    {
        public UsuarioGrupoClasse()
        {
        }

        public UsuarioGrupoClasse(long id_Usuario_Grupo_Classe, string usuario_Grupo_Classe_Nome, string usuario_Grupo_Classe_Descricao, bool? fl_Ativo)
        {
            Id_Usuario_Grupo_Classe = id_Usuario_Grupo_Classe;
            Usuario_Grupo_Classe_Nome = usuario_Grupo_Classe_Nome;
            Usuario_Grupo_Classe_Descricao = usuario_Grupo_Classe_Descricao;
            Fl_Ativo = fl_Ativo;
        }

        public long Id_Usuario_Grupo_Classe { get; set; }

        public string Usuario_Grupo_Classe_Nome { get; set; }
        public string Usuario_Grupo_Classe_Descricao { get; set; }

        public bool? Fl_Ativo { get; set; }

        public IEnumerable<Usuarios> Usuarios { get;  set; }
    }
}
