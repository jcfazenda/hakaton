using api.Domain.Models.Empresas;
using api.Domain.Repository.Interface.Empresas;
using api.Domain.Views.Input.Empresas;
using System.Linq;

namespace api.Domain.Repository.Queryable.Empresas
{
    public class AcionistaRepository : Repository<Acionista, decimal>, IAcionistaRepository
    {
        private readonly GRCContext _context;
        public AcionistaRepository(GRCContext context) : base(context)
        {
            _context = context;
        }



        public IQueryable<Acionista> GetAll(bool active)
        {
            var data = DbSet.Where(x => x.Fl_Ativo.Equals(active)).AsQueryable();

            return data;
        }
        public bool UpdateStatus(long id)
        {
            Acionista data = DbSet.Where(x => x.Id_Acionista.Equals(id)).AsQueryable().FirstOrDefault();
            data.Fl_Ativo = data.Fl_Ativo == true ? false : true;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public bool Create(AcionistaInput input)
        {
            Acionista data = new Acionista
            {
                Acionista_Nome      = input.Acionista_Nome,
                Acionista_Descricao = input.Acionista_Descricao,
                Acionista_Cpf_Cnpj = input.Acionista_Cpf_Cnpj,
                Acionista_Cpf = input.Acionista_Cpf,

                Fl_Ativo = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return true;
        }

        public bool Update(AcionistaInput input)
        {
            Acionista data = DbSet.Where(x => x.Id_Acionista.Equals(input.Id_Acionista)).AsQueryable().FirstOrDefault();

            data.Acionista_Nome = input.Acionista_Nome;
            data.Acionista_Descricao = input.Acionista_Descricao;
            data.Acionista_Cpf_Cnpj = input.Acionista_Cpf_Cnpj;
            data.Acionista_Cpf = input.Acionista_Cpf;


            _context.Update(data);
            _context.SaveChanges();

            return true;
        }
        public bool Remove(long id)
        {
            Acionista data = DbSet.Where(x => x.Id_Acionista.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }


    }
}
