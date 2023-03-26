using api.Domain.Models.Departamentos;
using api.Domain.Repository.Interface.Departamentos;
using api.Domain.Views.Input.Departamentos;
using System.Linq;

namespace api.Domain.Repository.Queryable.Departamentos
{
    public class DepartamentoRepository : Repository<Departamento, decimal>, IDepartamentoRepository
    {
        private readonly GRCContext _context;
        public DepartamentoRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Departamento> GetAll(bool active)
        {
            var data = DbSet.Where(x => x.Fl_Ativo.Equals(active)).AsQueryable();

            return data;
        }


        public bool UpdateStatus(long id)
        {
            Departamento data = DbSet.Where(x => x.Id_Departamento.Equals(id)).AsQueryable().FirstOrDefault();
            data.Fl_Ativo = data.Fl_Ativo == true ? false : true;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public long Create(DepartamentoInput input)
        {

            Departamento data = new Departamento
            {
                Departamento_Nome = input.Departamento_Nome,
                Departamento_Descricao = input.Departamento_Descricao,
                Fl_Ativo = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return data.Id_Departamento;
        }
 
        public bool Update(DepartamentoInput input)
        { 
            Departamento data = DbSet.Where(x => x.Id_Departamento.Equals(input.Id_Departamento)).AsQueryable().FirstOrDefault();

            data.Departamento_Nome = input.Departamento_Nome;
            data.Departamento_Descricao = input.Departamento_Descricao; 

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }
        public bool Remove(long id)
        {
            Departamento data = DbSet.Where(x => x.Id_Departamento.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }


    }
}
