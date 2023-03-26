using api.Domain.Models.Usuario;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Domain.Mapping.Usuario
{
    public sealed class UsuariosMap : IEntityTypeConfiguration<Usuarios>
    {

        public void Configure(EntityTypeBuilder<Usuarios> constuctor)
        {

            constuctor.ToTable("usuario");


            constuctor.Property(m => m.Id_Usuario).HasColumnName("Id_Usuario").IsRequired();
            constuctor.HasKey(o => o.Id_Usuario);
              
            constuctor.Property(m => m.Usuario_Nome).HasColumnName("Usuario_Nome");
            constuctor.Property(m => m.Usuario_Sobrenome).HasColumnName("Usuario_Sobrenome");
            constuctor.Property(m => m.Usuario_Email).HasColumnName("Usuario_Email");
            constuctor.Property(m => m.Usuario_Senha).HasColumnName("Usuario_Senha");
            constuctor.Property(m => m.Usuario_Avatar).HasColumnName("Usuario_Avatar"); 
            constuctor.Property(m => m.Fl_Ativo).HasColumnName("Fl_Ativo");


        }
    }
}
