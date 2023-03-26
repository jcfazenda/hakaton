
using api.Domain.Mapping.Message;
using api.Domain.Mapping.Usuario;
 
using Microsoft.EntityFrameworkCore;
 

namespace api
{
    public class GRCContext : DbContext
    {
        public GRCContext()
        {

        }

        public GRCContext(DbContextOptions options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /* usuarios */
            modelBuilder.ApplyConfiguration(new UsuariosMap());
            modelBuilder.ApplyConfiguration(new ChatMap());
            modelBuilder.ApplyConfiguration(new BotMap());
            modelBuilder.ApplyConfiguration(new BotStatusMap());

            base.OnModelCreating(modelBuilder);
        }
         
    }
}
