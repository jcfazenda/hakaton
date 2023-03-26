using api.Domain.Models.LGPD;
using api.Domain.Repository.Interface.LGPD;
using api.Domain.Views.Input.LGPD;
using System.Linq;

namespace api.Domain.Repository.Queryable.LGPD
{
    public class LgpdTipoDadosRepository : Repository<LgpdTipoDados, decimal>, ILgpdTipoDadosRepository
    {
        private readonly GRCContext _context;
        public LgpdTipoDadosRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<LgpdTipoDados> GetAll(bool active)
        {
            var data = DbSet.AsQueryable();

            return data;
        }


        public bool Create(LgpdTipoDadosInput input)
        {

            LgpdTipoDados data = new LgpdTipoDados();

            data.Id_Lgpd_Tipo_Dados_Categoria = input.Id_Lgpd_Tipo_Dados_Categoria;
            data.Lgpd_Tipo_Dados_Nome = input.Lgpd_Tipo_Dados_Nome; 

            _context.Add(data);
            _context.SaveChanges();

            return true;
        }

        public bool Update(LgpdTipoDadosInput input)
        {

            LgpdTipoDados data = DbSet.Where(x => x.Id_Lgpd_Tipo_Dados.Equals(input.Id_Lgpd_Tipo_Dados)).AsQueryable().FirstOrDefault();

            data.Id_Lgpd_Tipo_Dados_Categoria = input.Id_Lgpd_Tipo_Dados_Categoria;
            data.Lgpd_Tipo_Dados_Nome = input.Lgpd_Tipo_Dados_Nome;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public bool Remove(long id)
        {
            LgpdTipoDados data = DbSet.Where(x => x.Id_Lgpd_Tipo_Dados.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }

    }
}
