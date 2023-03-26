using api.Domain.Models.Empresas;
using api.Domain.Repository.Interface.Empresas;
using api.Domain.Views.Input.Empresas;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace api.Domain.Repository.Queryable.Empresas
{
    public class EmpresaLinhaNegocioRepository : Repository<EmpresaLinhaNegocio, decimal>, IEmpresaLinhaNegocioRepository
    {
        private readonly GRCContext _context;
        public EmpresaLinhaNegocioRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<EmpresaLinhaNegocio> GetByEmpresa(long id)
        {
            var data = DbSet.Include(i => i.Empresa)
                            .Include(i => i.LinhaNegocio)
                            .Where(x => x.Id_Empresa.Equals(id)).AsQueryable();

            return data;
        }

        public bool Create(EmpresaLinhaNegocioInput input)
        {
            EmpresaLinhaNegocio data = new EmpresaLinhaNegocio
            {
                Id_Empresa = input.Id_Empresa,
                Id_Linha_Negocio = input.Id_Linha_Negocio,
                Fl_Ativo = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return true;
        }

        public bool Remove(long id)
        {
            EmpresaLinhaNegocio data = DbSet.Where(x => x.Id_Empresa_Linha_Negocio.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }


    }
}
