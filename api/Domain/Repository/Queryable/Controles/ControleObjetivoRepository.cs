using api.Domain.Models.Controles;
using api.Domain.Repository.Interface.Controles;
using api.Domain.Views.Input.Controles;
using System.Linq;

namespace api.Domain.Repository.Queryable.Controles
{
    public class ControleObjetivoRepository : Repository<ControleObjetivo, decimal>, IControleObjetivoRepository
    {
        private readonly GRCContext _context;
        public ControleObjetivoRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<ControleObjetivo> GetAll(bool active)
        {
            var data = DbSet.Where(x => x.Fl_Ativo.Equals(active)).AsQueryable();

            return data;
        }
        public bool UpdateStatus(long id)
        {
            ControleObjetivo data = DbSet.Where(x => x.Id_Controle_Objetivo.Equals(id)).AsQueryable().FirstOrDefault();
            data.Fl_Ativo = data.Fl_Ativo == true ? false : true;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public long Create(ControleObjetivoInput input)
        {
            ControleObjetivo data = new ControleObjetivo
            {
                Controle_Objetivo_Nome = input.Controle_Objetivo_Nome,
                Controle_Objetivo_Descricao = input.Controle_Objetivo_Descricao,
                Fl_Ativo = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return data.Id_Controle_Objetivo;
        }

        public long Update(ControleObjetivoInput input)
        {
            ControleObjetivo data = DbSet.Where(x => x.Id_Controle_Objetivo.Equals(input.Id_Controle_Objetivo)).AsQueryable().FirstOrDefault();

            data.Controle_Objetivo_Nome = input.Controle_Objetivo_Nome;
            data.Controle_Objetivo_Descricao = input.Controle_Objetivo_Descricao;

            _context.Update(data);
            _context.SaveChanges();

            return data.Id_Controle_Objetivo;
        }
        public bool Remove(long id)
        {
            ControleObjetivo data = DbSet.Where(x => x.Id_Controle_Objetivo.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }


    }
}
