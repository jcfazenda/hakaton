using api.Domain.Models.LGPD;
using api.Domain.Repository.Interface.LGPD;
using api.Domain.Views.Input.LGPD;
using System.Linq;

namespace api.Domain.Repository.Queryable.LGPD
{
    public class LgpdQuizRepository : Repository<LgpdQuiz, decimal>, ILgpdQuizRepository
    {
        private readonly GRCContext _context;
        public LgpdQuizRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<LgpdQuiz> GetAll(bool active)
        {
            var data = DbSet.AsQueryable();

            return data;
        }

        public IQueryable<LgpdQuiz> GetByTipo(long idTipo)
        {
            var data = DbSet.Where(x => x.Id_Lgpd_Tipo.Equals(idTipo)).AsQueryable();

            return data;
        }

        public bool Create(LgpdQuizInput input)
        {

            LgpdQuiz data = new LgpdQuiz();

            data.Id_Lgpd_Tipo                   = input.Id_Lgpd_Tipo;
            data.Id_Lgpd_Tipo_Dados             = input.Id_Lgpd_Tipo_Dados;
            data.Fl_Lgpd_Tipo_Dados_Coletado    = input.Fl_Lgpd_Tipo_Dados_Coletado;
            data.Lgpd_Quiz_Nome                 = input.Lgpd_Quiz_Nome;
            data.Lgpd_Quiz_Descricao            = input.Lgpd_Quiz_Descricao; 


            _context.Add(data);
            _context.SaveChanges();

            return true;
        }

        public bool Update(LgpdQuizInput input)
        {

            LgpdQuiz data = DbSet.Where(x => x.Id_Lgpd_Quiz.Equals(input.Id_Lgpd_Quiz)).AsQueryable().FirstOrDefault();

            data.Id_Lgpd_Tipo                   = input.Id_Lgpd_Tipo;
            data.Id_Lgpd_Tipo_Dados             = input.Id_Lgpd_Tipo_Dados;
            data.Fl_Lgpd_Tipo_Dados_Coletado    = input.Fl_Lgpd_Tipo_Dados_Coletado;
            data.Lgpd_Quiz_Nome                 = input.Lgpd_Quiz_Nome;
            data.Lgpd_Quiz_Descricao            = input.Lgpd_Quiz_Descricao;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public bool Remove(long id)
        {
            LgpdQuiz data = DbSet.Where(x => x.Id_Lgpd_Quiz.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }

    }
}
