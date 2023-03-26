using api.Domain.Models.Risco;
using api.Domain.Repository.Interface.Risco;
using api.Domain.Views.Input.Risco;
using System.Linq;

namespace api.Domain.Repository.Queryable.Risco
{
    public class RiscoTratamentoTipoRepository : Repository<RiscoTratamentoTipo, decimal>, IRiscoTratamentoTipoRepository
    {
        private readonly GRCContext _context;
        public RiscoTratamentoTipoRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<RiscoTratamentoTipo> GetAll(bool active)
        {
            var data = DbSet.Where(x => x.Fl_Ativo.Equals(active)).AsQueryable();

            return data;
        }
        public bool UpdateStatus(long id)
        {
            RiscoTratamentoTipo data = DbSet.Where(x => x.Id_Risco_Tratamento_Tipo.Equals(id)).AsQueryable().FirstOrDefault();
            data.Fl_Ativo = data.Fl_Ativo == true ? false : true;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public bool Create(RiscoTratamentoTipoInput input)
        {
            RiscoTratamentoTipo data = new RiscoTratamentoTipo
            {
                Tratamento_Tipo_Nome = input.Tratamento_Tipo_Nome, 
                Fl_Ativo = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return true;
        }

        public bool Update(RiscoTratamentoTipoInput input)
        {
            RiscoTratamentoTipo data = DbSet.Where(x => x.Id_Risco_Tratamento_Tipo.Equals(input.Id_Risco_Tratamento_Tipo)).AsQueryable().FirstOrDefault();

            data.Tratamento_Tipo_Nome = input.Tratamento_Tipo_Nome; 

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }
        public bool Remove(long id)
        {
            RiscoTratamentoTipo data = DbSet.Where(x => x.Id_Risco_Tratamento_Tipo.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }


    }
}
