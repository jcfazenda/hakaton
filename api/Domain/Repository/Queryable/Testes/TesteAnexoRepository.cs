
using api.Domain.Models.Testes;
using api.Domain.Repository.Interface.Testes;
using api.Domain.Views.Input.Testes;
using System.Linq;

namespace api.Domain.Repository.Queryable.Testes
{
    public class TesteAnexoRepository : Repository<TesteAnexo, decimal>, ITesteAnexoRepository
    {
        private readonly GRCContext _context;
        public TesteAnexoRepository(GRCContext context) : base(context)
        {
            _context = context;
        } 

        public IQueryable<TesteAnexo> GetAny(bool active)
        {
            var data = DbSet.Where(x => x.Fl_Ativo.Equals(active)).AsQueryable();

            return data;
        }

        public IQueryable<TesteAnexo> GetByTeste(long id)
        {
            var data = DbSet.Where(x => x.Id_Teste.Equals(id)).AsQueryable();

            return data;
        }

        public bool Create(TesteAnexoInput input)
        {
            TesteAnexo data = new TesteAnexo
            {
                Id_Teste = input.Id_Teste,
                Teste_Anexo_Nome = input.Teste_Anexo_Nome,
                Teste_Anexo_Byte = input.Teste_Anexo_Byte, 
                Fl_Ativo = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return true;
        }
 
        public bool Remove(long id)
        {
            TesteAnexo data = DbSet.Where(x => x.Id_Teste_Anexo.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }


    }
}
