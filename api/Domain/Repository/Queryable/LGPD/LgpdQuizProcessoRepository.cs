using api.Domain.Models.LGPD;
using api.Domain.Repository.Interface.LGPD;
using api.Domain.Views.Input.LGPD;
using System.Collections.Generic;
using System.Linq;

namespace api.Domain.Repository.Queryable.LGPD
{
    public class LgpdQuizProcessoRepository : Repository<LgpdQuizProcesso, decimal>, ILgpdQuizProcessoRepository
    {
        private readonly GRCContext _context;
        public LgpdQuizProcessoRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<LgpdQuizProcesso> GetAll(bool active)
        {
            var data = DbSet.AsQueryable();

            return data;
        }


        public IQueryable<LgpdQuizProcesso> GetByProcesso(long idProcesso)
        {
            var data = DbSet.Where(x => x.Id_Processo.Equals(idProcesso)).AsQueryable();

            return data;
        }

        public IQueryable<LgpdQuizProcesso> GetByQuiz(long idQuiz)
        {
            var data = DbSet.Where(x => x.Id_Lgpd_Quiz.Equals(idQuiz)).AsQueryable();

            return data;
        }

        public bool Create(LgpdQuizProcessoInput input)
        {

            LgpdQuizProcesso data = new LgpdQuizProcesso();

            data.Id_Processo  = input.Id_Processo;
            data.Id_Lgpd_Quiz = input.Id_Lgpd_Quiz;
            data.Lgpd_Quiz_Processo_Descricao  = input.Lgpd_Quiz_Processo_Descricao;
            data.Lgpd_Quiz_Processo_Descritivo = input.Lgpd_Quiz_Processo_Descritivo; 

            _context.Add(data);
            _context.SaveChanges();

            return true;
        }

        public bool Update(LgpdQuizProcessoInput input)
        {

            LgpdQuizProcesso data = DbSet.Where(x => x.Id_Lgpd_Quiz_Processo.Equals(input.Id_Lgpd_Quiz_Processo)).AsQueryable().FirstOrDefault();

            data.Id_Processo = input.Id_Processo;
            data.Id_Lgpd_Quiz = input.Id_Lgpd_Quiz;
            data.Lgpd_Quiz_Processo_Descricao = input.Lgpd_Quiz_Processo_Descricao;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }
        public bool UpdateDescritivo(LgpdQuizProcessoInput input)
        {

            List<LgpdQuizProcesso> data = DbSet.Where(x => x.Id_Lgpd_Quiz.Equals(input.Id_Lgpd_Quiz) &&
                                                      x.Id_Processo.Equals(input.Id_Processo)).AsQueryable().ToList();

            foreach (var item in data)
            {
                item.Lgpd_Quiz_Processo_Descritivo = input.Lgpd_Quiz_Processo_Descritivo;

                _context.Update(item);
                _context.SaveChanges();
            }
 
            return true;
        }

        public bool Remove(long id)
        {
            LgpdQuizProcesso data = DbSet.Where(x => x.Id_Lgpd_Quiz_Processo.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }

    }
}
