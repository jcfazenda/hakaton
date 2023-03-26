using api.Domain.Models.Controles;
using api.Domain.Repository.Interface.Controles;
using api.Domain.Views.Input.Controles;
using System.Linq;

namespace api.Domain.Repository.Queryable.Controles
{
    public class ControleFrequenciaRepository : Repository<ControleFrequencia, decimal>, IControleFrequenciaRepository
    {
        private readonly GRCContext _context;
        public ControleFrequenciaRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<ControleFrequencia> GetAll(bool active)
        {
            var data = DbSet.Where(x => x.Fl_Ativo.Equals(active)).AsQueryable();

            return data;
        }
        public bool UpdateStatus(long id)
        {
            ControleFrequencia data = DbSet.Where(x => x.Id_Controle_Frequencia.Equals(id)).AsQueryable().FirstOrDefault();
            data.Fl_Ativo = data.Fl_Ativo == true ? false : true;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public long Create(ControleFrequenciaInput input)
        {
            ControleFrequencia data = new ControleFrequencia
            {
                Controle_Frequencia_Nome = input.Controle_Frequencia_Nome,
                Fl_Ativo = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return data.Id_Controle_Frequencia;
        }

        public long Update(ControleFrequenciaInput input)
        {
            ControleFrequencia data = DbSet.Where(x => x.Id_Controle_Frequencia.Equals(input.Id_Controle_Frequencia)).AsQueryable().FirstOrDefault();

            data.Controle_Frequencia_Nome = input.Controle_Frequencia_Nome;

            _context.Update(data);
            _context.SaveChanges();

            return data.Id_Controle_Frequencia;
        }
        public bool Remove(long id)
        {
            ControleFrequencia data = DbSet.Where(x => x.Id_Controle_Frequencia.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }


    }
}
