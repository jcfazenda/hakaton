using api.Domain.Models.Apontamentos;
using api.Domain.Repository.Interface.Apontamentos;
using api.Domain.Views.Input.Apontamentos;
using System.Linq;

namespace api.Domain.Repository.Queryable.Apontamentos
{
    public class ApontamentoCategoriaRepository : Repository<ApontamentoCategoria, decimal>, IApontamentoCategoriaRepository
    {
        private readonly GRCContext _context;
        public ApontamentoCategoriaRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<ApontamentoCategoria> GetAll(bool active)
        {
            var data = DbSet.AsQueryable();

            return data;
        }


        public bool Create(ApontamentoCategoriaInput input)
        {
            ApontamentoCategoria data = new ApontamentoCategoria
            {
                Apontamento_Categoria_Nome = input.Apontamento_Categoria_Nome
            };

            _context.Add(data);
            _context.SaveChanges();

            return true;
        }

        public bool Update(ApontamentoCategoriaInput input)
        {
            ApontamentoCategoria data = DbSet.Where(x => x.Id_Apontamento_Categoria.Equals(input.Id_Apontamento_Categoria)).AsQueryable().FirstOrDefault();

            data.Apontamento_Categoria_Nome = input.Apontamento_Categoria_Nome;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public bool Remove(long id)
        {
            ApontamentoCategoria data = DbSet.Where(x => x.Id_Apontamento_Categoria.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }

    }
}
