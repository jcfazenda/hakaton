using System.Collections.Generic;

namespace api.Domain.Models.Usuario
{
    public class UsuarioAreaAtuacao
    {
        public UsuarioAreaAtuacao()
        {
        }

        public UsuarioAreaAtuacao(long id_Usuario_Area_Atuacao, string usuario_Area_Atuacao_Nome, string usuario_Area_Atuacao_Descricao, bool? fl_Ativo)
        {
            Id_Usuario_Area_Atuacao = id_Usuario_Area_Atuacao;
            Usuario_Area_Atuacao_Nome = usuario_Area_Atuacao_Nome;
            Usuario_Area_Atuacao_Descricao = usuario_Area_Atuacao_Descricao;
            Fl_Ativo = fl_Ativo;
        }

        public long Id_Usuario_Area_Atuacao { get; set; }

        public string Usuario_Area_Atuacao_Nome { get; set; }
        public string Usuario_Area_Atuacao_Descricao { get; set; }

        public bool? Fl_Ativo { get; set; }
        public IEnumerable<Usuarios> Usuarios { get; set; }
    }
}
