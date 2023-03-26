using api.Domain.Models.Empresas;
using api.Domain.Repository.Interface.Empresas;
using api.Domain.Views.Input.Empresas;
using System.Linq;

namespace api.Domain.Repository.Queryable.Empresas
{
    public class OrgaoReguladorRepository : Repository<OrgaoRegulador, decimal>, IOrgaoReguladorRepository
    {
        private readonly GRCContext _context;
        public OrgaoReguladorRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<OrgaoRegulador> GetAll(bool active)
        {
            var data = DbSet.Where(x => x.Fl_Ativo.Equals(active)).AsQueryable();

            return data;
        }
        public bool UpdateStatus(long id)
        {
            OrgaoRegulador data = DbSet.Where(x => x.Id_Orgao_Regulador.Equals(id)).AsQueryable().FirstOrDefault();
            data.Fl_Ativo = data.Fl_Ativo == true ? false : true;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public bool Create(OrgaoReguladorInput input)
        {
            OrgaoRegulador data = new OrgaoRegulador
            {
                Orgao_Regulador_Nome = input.Orgao_Regulador_Nome,
                Fl_Ativo = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return true;
        }

        public bool Update(OrgaoReguladorInput input)
        {
            OrgaoRegulador data = DbSet.Where(x => x.Id_Orgao_Regulador.Equals(input.Id_Orgao_Regulador)).AsQueryable().FirstOrDefault();

            data.Orgao_Regulador_Nome = input.Orgao_Regulador_Nome;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }
        public bool Remove(long id)
        {
            OrgaoRegulador data = DbSet.Where(x => x.Id_Orgao_Regulador.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }


    }
}
