using api.Domain.Models.UnidadesOrganizacionais;
using api.Domain.Repository.Interface.UnidadesOrganizacionais;
using api.Domain.Views.Input.UnidadesOrganizacionais;
using System.Linq;

namespace api.Domain.Repository.Queryable.UnidadesOrganizacional
{
    public class UnidadeOrganizacionalOrgaoRepository : Repository<UnidadeOrganizacionalOrgao, decimal>, IUnidadeOrganizacionalOrgaoRepository
    {
        private readonly GRCContext _context;
        public UnidadeOrganizacionalOrgaoRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<UnidadeOrganizacionalOrgao> GetAny(bool active)
        {
            var data = DbSet.Where(x => x.Fl_Ativo.Equals(active)).AsQueryable();

            return data;
        }
        public bool UpdateStatus(long id)
        {
            UnidadeOrganizacionalOrgao data = DbSet.Where(x => x.Id_Unidade_Organizacional_Orgao.Equals(id)).AsQueryable().FirstOrDefault();
            data.Fl_Ativo = data.Fl_Ativo == true ? false : true;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public long Create(UnidadeOrganizacionalOrgaoInput input)
        {
            UnidadeOrganizacionalOrgao data = new UnidadeOrganizacionalOrgao
            { 
                Unidade_Organizacional_Orgao_Nome = input.Unidade_Organizacional_Orgao_Nome, 
                Fl_Ativo = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return data.Id_Unidade_Organizacional_Orgao;
        }

        public long Update(UnidadeOrganizacionalOrgaoInput input)
        {
            UnidadeOrganizacionalOrgao data = DbSet.Where(x => x.Id_Unidade_Organizacional_Orgao.Equals(input.Id_Unidade_Organizacional_Orgao)).AsQueryable().FirstOrDefault();
 
            data.Unidade_Organizacional_Orgao_Nome = input.Unidade_Organizacional_Orgao_Nome; 
            data.Fl_Ativo = input.Fl_Ativo;

            _context.Update(data);
            _context.SaveChanges();

            return data.Id_Unidade_Organizacional_Orgao;
        }
        public bool Remove(long id)
        {
            UnidadeOrganizacionalOrgao data = DbSet.Where(x => x.Id_Unidade_Organizacional_Orgao.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }


    }
}
