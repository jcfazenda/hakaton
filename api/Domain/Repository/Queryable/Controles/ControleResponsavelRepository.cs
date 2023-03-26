using api.Domain.Models.Controles;
using api.Domain.Repository.Interface.Controles;
using api.Domain.Views.Input.Controles;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace api.Domain.Repository.Queryable.Controles
{
    public class ControleResponsavelRepository : Repository<ControleResponsavel, decimal>, IControleResponsavelRepository
    {
        private readonly GRCContext _context;
        public ControleResponsavelRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<ControleResponsavel> GetByControle(long id)
        {
            var data = DbSet.Include(i => i.Usuarios).Where(x => x.Id_Controle.Equals(id)).AsQueryable();

            return data;
        }

        public bool Create(ControleResponsavelInput input)
        {
            ControleResponsavel data = new ControleResponsavel
            {
                Id_Controle = input.Id_Controle,
                Id_Usuario = input.Id_Usuario,
                Fl_Ativo = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return true;
        }

        public bool Remove(long id)
        {
            ControleResponsavel data = DbSet.Where(x => x.Id_Controle_Responsavel.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }


    }
}
