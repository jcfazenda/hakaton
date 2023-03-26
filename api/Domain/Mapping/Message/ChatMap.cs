using api.Domain.Models.Message;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Domain.Mapping.Message
{
    public sealed class ChatMap : IEntityTypeConfiguration<Chat>
    {

        public void Configure(EntityTypeBuilder<Chat> constuctor)
        {

            constuctor.ToTable("chat");


            constuctor.Property(m => m.Id_Chat).HasColumnName("Id_Chat").IsRequired();
            constuctor.HasKey(o => o.Id_Chat);

            constuctor.Property(m => m.Id_Bot).HasColumnName("Id_Bot");
            constuctor.Property(m => m.Id_Usuario).HasColumnName("Id_Usuario");
            constuctor.Property(m => m.Mensagem).HasColumnName("Mensagem");
            constuctor.Property(m => m.Fl_Bot).HasColumnName("Fl_Bot");
            constuctor.Property(m => m.Data_Hora).HasColumnName("Data_Hora");
            constuctor.Property(m => m.Fl_Ativo).HasColumnName("Fl_Ativo");


        }
    }
}
