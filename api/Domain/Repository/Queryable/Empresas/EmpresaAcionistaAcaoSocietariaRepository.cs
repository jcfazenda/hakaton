using api.Domain.Models.Empresas;
using api.Domain.Repository.Interface.Empresas;
using api.Domain.Views.Input.Empresas;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace api.Domain.Repository.Queryable.Empresas
{
    public class EmpresaAcionistaAcaoSocietariaRepository : Repository<EmpresaAcionistaAcaoSocietaria, decimal>, IEmpresaAcionistaAcaoSocietariaRepository
    {
        private readonly GRCContext _context;
        public EmpresaAcionistaAcaoSocietariaRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<EmpresaAcionistaAcaoSocietaria> GetByAcionista(long idAcionista, long idEmpresa)
        {
            var data = DbSet.Include(i => i.Acionista)
                            .Where(x => x.Id_Empresa.Equals(idEmpresa) && x.Id_Acionista.Equals(idAcionista)).AsQueryable();

            return data;
        }

        public bool Create(EmpresaAcionistaAcaoSocietariaInput input)
        {
            EmpresaAcionistaAcaoSocietaria data = new EmpresaAcionistaAcaoSocietaria
            {
                Id_Empresa                      = input.Id_Empresa,
                Id_Acionista                    = input.Id_Acionista,
                Id_Empresa_Acao_Societaria_Item = input.Id_Empresa_Acao_Societaria_Item,
                Fl_Ativo = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return true;
        }

        public bool Remove(long id)
        {
            EmpresaAcionistaAcaoSocietaria data = DbSet.Where(x => x.Id_Empresa_Acionista_Acao_Societaria.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }

        public bool RemoveByAcionista(long id)
        {
            List<EmpresaAcionistaAcaoSocietaria> data = DbSet.Where(x => x.Id_Acionista.Equals(id)).AsQueryable().ToList();

            foreach (var item in data)
            {
                _context.Remove(item);
                _context.SaveChanges();
            }
             
            return true;
        }

    }
}
