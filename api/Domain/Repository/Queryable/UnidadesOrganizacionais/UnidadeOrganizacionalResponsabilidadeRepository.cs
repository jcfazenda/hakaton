using api.Domain.Models.UnidadesOrganizacionais;
using api.Domain.Repository.Interface.UnidadesOrganizacionais;
using api.Domain.Views.Input.UnidadesOrganizacionais;
using System.Linq;

namespace api.Domain.Repository.Queryable.UnidadesOrganizacional
{
    public class UnidadeOrganizacionalResponsabilidadeRepository : Repository<UnidadeOrganizacionalResponsabilidade, decimal>, IUnidadeOrganizacionalResponsabilidadeRepository
    {
        private readonly GRCContext _context;
        public UnidadeOrganizacionalResponsabilidadeRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<UnidadeOrganizacionalResponsabilidade> GetAny(bool active)
        {
            var data = DbSet.Where(x => x.Fl_Ativo.Equals(active)).AsQueryable();

            return data;
        }
        public bool UpdateStatus(long id)
        {
            UnidadeOrganizacionalResponsabilidade data = DbSet.Where(x => x.Id_Unidade_Organizacional_Responsabilidade.Equals(id)).AsQueryable().FirstOrDefault();
            data.Fl_Ativo = data.Fl_Ativo == true ? false : true;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public long Create(UnidadeOrganizacionalResponsabilidadeInput input)
        {
            UnidadeOrganizacionalResponsabilidade data = new UnidadeOrganizacionalResponsabilidade
            {
                Unidade_Organizacional_Responsabilidade_Nome = input.Unidade_Organizacional_Responsabilidade_Nome,
                Fl_Ativo = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return data.Id_Unidade_Organizacional_Responsabilidade;
        }

        public long Update(UnidadeOrganizacionalResponsabilidadeInput input)
        {
            UnidadeOrganizacionalResponsabilidade data = DbSet.Where(x => x.Id_Unidade_Organizacional_Responsabilidade.Equals(input.Id_Unidade_Organizacional_Responsabilidade)).AsQueryable().FirstOrDefault();

            data.Unidade_Organizacional_Responsabilidade_Nome = input.Unidade_Organizacional_Responsabilidade_Nome;
            data.Fl_Ativo = input.Fl_Ativo;

            _context.Update(data);
            _context.SaveChanges();

            return data.Id_Unidade_Organizacional_Responsabilidade;
        }
        public bool Remove(long id)
        {
            UnidadeOrganizacionalResponsabilidade data = DbSet.Where(x => x.Id_Unidade_Organizacional_Responsabilidade.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }


    }
}
