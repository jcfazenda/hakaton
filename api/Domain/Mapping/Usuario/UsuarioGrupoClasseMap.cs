
using api.Domain.Models.Usuario;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Domain.Mapping.Usuario
{
    public sealed class UsuarioGrupoClasseMap : IEntityTypeConfiguration<UsuarioGrupoClasse>
    {

        public void Configure(EntityTypeBuilder<UsuarioGrupoClasse> constuctor)
        {

            constuctor.ToTable("usuario_grupo_classe");

            constuctor.Property(m => m.Id_Usuario_Grupo_Classe).HasColumnName("Id_Usuario_Grupo_Classe").IsRequired();
            constuctor.HasKey(o => o.Id_Usuario_Grupo_Classe);

            constuctor.Property(m => m.Usuario_Grupo_Classe_Nome).HasColumnName("Usuario_Grupo_Classe_Nome");
            constuctor.Property(m => m.Usuario_Grupo_Classe_Descricao).HasColumnName("Usuario_Grupo_Classe_Descricao");
            constuctor.Property(m => m.Fl_Ativo).HasColumnName("Fl_Ativo");

        }
    }
}
