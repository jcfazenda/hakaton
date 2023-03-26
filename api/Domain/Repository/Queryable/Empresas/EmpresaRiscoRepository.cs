using api.Domain.Models.Empresas;
using api.Domain.Repository.Interface.Empresas;
using api.Domain.Views.Input.Empresas;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace api.Domain.Repository.Queryable.Empresas
{
    public class EmpresaRiscoRepository : Repository<EmpresaRisco, decimal>, IEmpresaRiscoRepository
    {
        private readonly GRCContext _context;
        public EmpresaRiscoRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<EmpresaRisco> GetByEmpresa(long id, bool Ativo)
        {
            var data = DbSet.Include(i => i.Riscos)
                .Where(x => x.Id_Empresa.Equals(id) && x.Riscos.Fl_Ativo.Equals(Ativo)).AsQueryable();

            return data;
        }

        public IQueryable<EmpresaRisco> GetByEmpresas(long id, bool Ativo)
        {
            var data = DbSet.Include(i => i.Riscos)
                .Where(x => x.Id_Empresa.Equals(id)).AsQueryable();

            return data;
        }


        public IQueryable<EmpresaRisco> GetByEmpresaList(List<long> List, bool Ativo)
        {
            var data = DbSet.Include(i => i.Riscos).Where(x => List.Contains(x.Id_Empresa) && x.Riscos.Fl_Ativo.Equals(Ativo)).AsQueryable();

            return data;
        }
        public IQueryable<EmpresaRisco> GetByRiscoList(List<long> List, bool Ativo)
        {
            var data = DbSet.Include(i => i.Empresa).Where(x => List.Contains(x.Id_Risco)).AsQueryable();

            return data;
        }

        public bool Create(EmpresaRiscoInput input)
        {
            EmpresaRisco data = new EmpresaRisco
            {
                Id_Empresa = input.Id_Empresa,
                Id_Risco = input.Id_Risco,
                Fl_Ativo = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return true;
        }

        public bool Remove(long id)
        {
            EmpresaRisco data = DbSet.Where(x => x.Id_Empresa_Risco.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }


    }
}
