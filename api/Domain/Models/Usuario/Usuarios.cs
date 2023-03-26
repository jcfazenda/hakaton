 
using System.Collections.Generic;

namespace api.Domain.Models.Usuario
{
    public class Usuarios  
    {
        public Usuarios()
        {
        }

        public Usuarios(long id_Usuario, long id_Cliente, string usuario_Nome, string usuario_Sobrenome, string usuario_Email, string usuario_Senha, string usuario_Avatar, bool? fl_Ativo)
        {
            Id_Usuario = id_Usuario; 
            Id_Cliente = id_Cliente;
            Usuario_Nome = usuario_Nome;
            Usuario_Sobrenome = usuario_Sobrenome;
            Usuario_Email = usuario_Email;
            Usuario_Senha = usuario_Senha;
            Usuario_Avatar = usuario_Avatar;
            Fl_Ativo = fl_Ativo;
        }

        public long Id_Usuario { get; set; } 
        public long Id_Cliente { get; set; }

        public string Usuario_Nome { get; set; }
        public string Usuario_Sobrenome { get; set; }
        public string Usuario_Email { get; set; }
        public string Usuario_Senha { get; set; }
        public string Usuario_Avatar { get; set; } 

        public bool? Fl_Ativo { get; set; }

    }
}
