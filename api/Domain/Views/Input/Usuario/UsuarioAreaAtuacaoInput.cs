namespace api.Domain.Views.Input.Usuario
{
    public class UsuarioAreaAtuacaoInput
    {
         
        public long Id_Usuario_Area_Atuacao { get; set; }

        public string Usuario_Area_Atuacao_Nome { get; set; }
        public string Usuario_Area_Atuacao_Descricao { get; set; }

        public bool? Fl_Ativo { get; set; }

        public long Id { get; set; }
        public string Rota { get; set; }
    }
}
