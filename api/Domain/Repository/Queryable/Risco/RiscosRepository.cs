using api.Domain.Models.Risco;
using api.Domain.Repository.Interface.Risco;
using api.Domain.Views.Input.Risco;
using System.Linq;

namespace api.Domain.Repository.Queryable.Risco
{
    public class RiscosRepository : Repository<Riscos, decimal>, IRiscosRepository
    {
        private readonly GRCContext _context;
        public RiscosRepository(GRCContext context) : base(context)
        {
            _context = context;
        }


        public IQueryable<Riscos> GetByRisco(long id)
        {
            var data = DbSet.Where(x => x.Id_Risco.Equals(id)).AsQueryable();

            return data;
        }
        public IQueryable<Riscos> GetAll(bool active)
        {
            var data = DbSet.Where(x => x.Fl_Ativo.Equals(active) && x.Fl_Excluido.Equals(false)).AsQueryable();

            return data;
        }
        public bool UpdateStatus(long id)
        {
            Riscos data = DbSet.Where(x => x.Id_Risco.Equals(id)).AsQueryable().FirstOrDefault();
            data.Fl_Ativo = data.Fl_Ativo == true ? false : true;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        } 

        public long Create(RiscosInput input)
        {
            Riscos data = new Riscos
            {
                Id_Perfil_Analise           = input.Id_Perfil_Analise,
                Id_Risco_Tratamento_Tipo    = input.Id_Risco_Tratamento_Tipo,
                Id_Usuario        = input.Id_Usuario_Tenant,
                Risco_Nome        = input.Risco_Nome,
                Risco_Descricao   = input.Risco_Descricao,
                Risco_Tratamento_Tipo_Descricao = input.Risco_Tratamento_Tipo_Descricao,
                Fl_Exclusivo      = input.Fl_Exclusivo,
                Fl_Ativo          = true,
                Fl_Excluido = false
            };

            _context.Add(data);
            _context.SaveChanges(); 

            return data.Id_Risco;
        }

        public bool Update(RiscosInput input)
        {
            Riscos data = DbSet.Where(x => x.Id_Risco.Equals(input.Id_Risco)).AsQueryable().FirstOrDefault();

            data.Id_Perfil_Analise      = input.Id_Perfil_Analise;
            data.Id_Risco_Tratamento_Tipo = input.Id_Risco_Tratamento_Tipo;
            data.Risco_Nome             = input.Risco_Nome;
            data.Risco_Descricao        = input.Risco_Descricao;
            data.Risco_Tratamento_Tipo_Descricao = input.Risco_Tratamento_Tipo_Descricao;

            _context.Update(data);
            _context.SaveChanges(); 

            return true;
        }
        public bool UpdateExclusivo(long id)
        {
            Riscos data = DbSet.Where(x => x.Id_Risco.Equals(id)).AsQueryable().FirstOrDefault();
            data.Fl_Exclusivo = data.Fl_Exclusivo == true ? false : true;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }
        public bool UpdateExcluir(long id)
        {
            Riscos data = DbSet.Where(x => x.Id_Risco.Equals(id)).AsQueryable().FirstOrDefault();
            data.Fl_Excluido = true;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public bool Remove(long id)
        {
            Riscos data = DbSet.Where(x => x.Id_Risco.Equals(id)).AsQueryable().FirstOrDefault(); 

            _context.Remove(data);
            _context.SaveChanges(); 

            return true;
        }


    }
}
