using api.Domain.Models.CarrieMessage;
using api.Domain.Repository.Interface.CarrieMessage;
using api.Domain.Views.Input.CarrieMessage;
using System.Linq;

namespace api.Domain.Repository.Queryable.CarrieMessage
{
    public class CorreioTipoRepository : Repository<CorreioTipo, decimal>, ICorreioTipoRepository
    {
        private readonly GRCContext _context;
        public CorreioTipoRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<CorreioTipo> GetAll(bool active)
        {
            var data = DbSet.Where(x => x.Fl_Ativo.Equals(active)).AsQueryable();

            return data;
        }
        public bool UpdateStatus(long id)
        {
            CorreioTipo data = DbSet.Where(x => x.Id_Correio_Tipo.Equals(id)).AsQueryable().FirstOrDefault();
            data.Fl_Ativo = data.Fl_Ativo == true ? false : true;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public bool Create(CorreioTipoInput input)
        {
            CorreioTipo data = new CorreioTipo
            {
                Correio_Tipo_Nome = input.Correio_Tipo_Nome,
                Icone = input.Icone,
                Cor = input.Cor,

                Fl_Ativo = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return true;
        }

        public bool Update(CorreioTipoInput input)
        {
            CorreioTipo data = DbSet.Where(x => x.Id_Correio_Tipo.Equals(input.Id_Correio_Tipo)).AsQueryable().FirstOrDefault();

            data.Correio_Tipo_Nome = input.Correio_Tipo_Nome; 

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }
        public bool Remove(long id)
        {
            CorreioTipo data = DbSet.Where(x => x.Id_Correio_Tipo.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }


    }
}
