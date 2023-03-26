using api.Domain.Models.Message;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Domain.Mapping.Message
{
    public sealed class BotMap : IEntityTypeConfiguration<Bot>
    {

        public void Configure(EntityTypeBuilder<Bot> constuctor)
        {

            constuctor.ToTable("bot");


            constuctor.Property(m => m.Id_Bot).HasColumnName("Id_Bot").IsRequired();
            constuctor.HasKey(o => o.Id_Bot);

            constuctor.Property(m => m.Api).HasColumnName("Api");
            constuctor.Property(m => m.Bot_Nome).HasColumnName("Bot_Nome");
            constuctor.Property(m => m.Bot_Descricao).HasColumnName("Bot_Descricao");
            constuctor.Property(m => m.Icone).HasColumnName("Icone");
            constuctor.Property(m => m.Id_Status).HasColumnName("Id_Status");
            constuctor.Property(m => m.Fl_Ativo).HasColumnName("Fl_Ativo");
            constuctor.Property(m => m.Key_Vonage_Voice).HasColumnName("Key_Vonage_Voice");

            constuctor.HasOne(m => m.BotStatus).WithMany(m => m.Bot)
                                               .HasForeignKey(x => x.Id_Bot).HasPrincipalKey(x => x.Id_Bot_Status); /* Join */


        }
    }
}
