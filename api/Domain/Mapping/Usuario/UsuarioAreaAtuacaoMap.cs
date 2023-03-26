
using api.Domain.Models.Usuario;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Domain.Mapping.Usuario
{
    public sealed class UsuarioAreaAtuacaoMap : IEntityTypeConfiguration<UsuarioAreaAtuacao>
    {

        public void Configure(EntityTypeBuilder<UsuarioAreaAtuacao> constuctor)
        {

            constuctor.ToTable("usuario_area_atuacao");

            constuctor.Property(m => m.Id_Usuario_Area_Atuacao).HasColumnName("Id_Usuario_Area_Atuacao").IsRequired();
            constuctor.HasKey(o => o.Id_Usuario_Area_Atuacao);

            constuctor.Property(m => m.Usuario_Area_Atuacao_Nome).HasColumnName("Usuario_Area_Atuacao_Nome");
            constuctor.Property(m => m.Usuario_Area_Atuacao_Descricao).HasColumnName("Usuario_Area_Atuacao_Descricao");
            constuctor.Property(m => m.Fl_Ativo).HasColumnName("Fl_Ativo");

        }
    }
}
