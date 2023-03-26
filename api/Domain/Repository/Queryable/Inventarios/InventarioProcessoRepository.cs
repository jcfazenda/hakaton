using api.Domain.Models.Inventarios;
using api.Domain.Repository.Interface.Inventarios; 
using api.Domain.Views.Input.Inventarios;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace api.Domain.Repository.Queryable.LGPD
{
    public class InventarioProcessoRepository : Repository<InventarioProcesso, decimal>, IInventarioProcessoRepository
    {
        private readonly GRCContext _context;
        public InventarioProcessoRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<InventarioProcesso> GetAll(bool active)
        {
            var data = DbSet.AsQueryable();

            return data;
        }

        public IQueryable<InventarioProcesso> GetByProcesso(long id)
        {
            var data = DbSet.Include(i => i.Inventario)
                            .Where(x => x.Id_Processo.Equals(id)).AsQueryable();

            return data;
        }

        public bool Create(InventarioProcessoInput input)
        {
            InventarioProcesso data = new InventarioProcesso();

            data.Id_Processo     = input.Id_Processo;
            data.Id_Inventario   = input.Id_Inventario; 

            _context.Add(data);
            _context.SaveChanges();

            return true;
        }

        public bool Anexo(InventarioProcessoInput input)
        {
            InventarioProcesso data = new InventarioProcesso();

            data.Anexo = input.Anexo; 

            _context.Add(data);
            _context.SaveChanges();

            return true;
        }

        public bool Remove(long id)
        {
            InventarioProcesso data = DbSet.Where(x => x.Id_Inventario_Processo.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }

    }
}
