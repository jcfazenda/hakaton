using System.Collections.Generic;

namespace api.Domain.Models.Usuario
{
    public class UsuarioCargoAtividade
    {
        public UsuarioCargoAtividade()
        {
        }

        public UsuarioCargoAtividade(long id_Usuario_Cargo_Atividade, string usuario_Cargo_Atividade_Nome, string usuario_Cargo_Atividade_Descricao, bool? fl_Ativo)
        {
            Id_Usuario_Cargo_Atividade = id_Usuario_Cargo_Atividade;
            Usuario_Cargo_Atividade_Nome = usuario_Cargo_Atividade_Nome;
            Usuario_Cargo_Atividade_Descricao = usuario_Cargo_Atividade_Descricao;
            Fl_Ativo = fl_Ativo;
        }

        public long Id_Usuario_Cargo_Atividade { get; set; } 

        public string Usuario_Cargo_Atividade_Nome { get; set; }
        public string Usuario_Cargo_Atividade_Descricao { get; set; } 

        public bool? Fl_Ativo { get; set; }
        public IEnumerable<Usuarios> Usuarios { get; set; }
    }
}
