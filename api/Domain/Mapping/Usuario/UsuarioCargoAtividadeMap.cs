 
using api.Domain.Models.Usuario;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Domain.Mapping.Usuario
{
    public sealed class UsuarioCargoAtividadeMap : IEntityTypeConfiguration<UsuarioCargoAtividade>
    {

        public void Configure(EntityTypeBuilder<UsuarioCargoAtividade> constuctor)
        {

            constuctor.ToTable("usuario_cargo_atividade");

            constuctor.Property(m => m.Id_Usuario_Cargo_Atividade).HasColumnName("Id_Usuario_Cargo_Atividade").IsRequired();
            constuctor.HasKey(o => o.Id_Usuario_Cargo_Atividade);

            constuctor.Property(m => m.Usuario_Cargo_Atividade_Nome).HasColumnName("Usuario_Cargo_Atividade_Nome");
            constuctor.Property(m => m.Usuario_Cargo_Atividade_Descricao).HasColumnName("Usuario_Cargo_Atividade_Descricao"); 
            constuctor.Property(m => m.Fl_Ativo).HasColumnName("Fl_Ativo");

        }
    }
}
