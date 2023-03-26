using api.Domain.Models.Message;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Domain.Mapping.Message
{
    public sealed class BotStatusMap : IEntityTypeConfiguration<BotStatus>
    {

        public void Configure(EntityTypeBuilder<BotStatus> constuctor)
        {

            constuctor.ToTable("bot_status");


            constuctor.Property(m => m.Id_Bot_Status).HasColumnName("Id_Bot_Status").IsRequired();
            constuctor.HasKey(o => o.Id_Bot_Status);

            constuctor.Property(m => m.Bot_Status_Nome).HasColumnName("Bot_Status_Nome"); 


        }
    }
}
