using api.Domain.Models.Empresas;
using api.Domain.Repository.Interface.Empresas;
using api.Domain.Views.Input.Empresas;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace api.Domain.Repository.Queryable.Empresas
{
    public class EmpresaDiagramaRepository : Repository<EmpresaDiagrama, decimal>, IEmpresaDiagramaRepository
    {
        private readonly GRCContext _context;
        public EmpresaDiagramaRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<EmpresaDiagrama> GetByEmpresa(long id)
        {
            var data = DbSet.Include(i => i.Empresa)
                            .Where(x => x.Id_Empresa.Equals(id)).OrderBy(o => o.Id_Empresa_Diagrama).AsQueryable();

            return data;
        }

        public bool Create(EmpresaDiagramaInput input)
        {
            EmpresaDiagrama data = new EmpresaDiagrama
            {
                Id_Empresa          = input.Id_Empresa,
                Id_Empresa_Pai      = input.Id_Empresa_Pai,
                Id_Empresa_Filho    = input.Id_Empresa_Filho,
                Percentual          = 0.0,
                Fl_Temporaria       = input.Fl_Temporaria,
                Fl_Colegiada        = input.Fl_Colegiada,
                Fl_Ativo            = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return true;
        }

        public bool Remove(long id)
        {
            EmpresaDiagrama data = DbSet.Where(x => x.Id_Empresa_Diagrama.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }

    }
}
