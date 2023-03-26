using api.Domain.Models.PlanosAcao;
using api.Domain.Repository.Interface.PlanosAcao;
using api.Domain.Views.Input.PlanosAcao;
using System;
using System.Linq;

namespace api.Domain.Repository.Queryable.PlanosAcao
{
    public class PlanoAcaoStatusRepository : Repository<PlanoAcaoStatus, decimal>, IPlanoAcaoStatusRepository
    {
        private readonly GRCContext _context;
        public PlanoAcaoStatusRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<PlanoAcaoStatus> GetAll(bool active)
        {
            var data = DbSet.Where(x => x.Fl_Ativo.Equals(active)).AsQueryable();

            return data;
        }
        public bool UpdateStatus(long id)
        {
            PlanoAcaoStatus data = DbSet.Where(x => x.Id_Plano_Acao_Status.Equals(id)).AsQueryable().FirstOrDefault();
            data.Fl_Ativo = data.Fl_Ativo == true ? false : true;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public bool Create(PlanoAcaoStatusInput input)
        {
            PlanoAcaoStatus data = new PlanoAcaoStatus
            {
                Plano_Acao_Status_Nome = input.Plano_Acao_Status_Nome, 
                Fl_Ativo = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return true;
        }
 
        public bool Update(PlanoAcaoStatusInput input)
        {
            PlanoAcaoStatus data = DbSet.Where(x => x.Id_Plano_Acao_Status.Equals(input.Id_Plano_Acao_Status)).AsQueryable().FirstOrDefault();

            data.Plano_Acao_Status_Nome = input.Plano_Acao_Status_Nome; 

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }


        public bool Remove(long id)
        {
            PlanoAcaoStatus data = DbSet.Where(x => x.Id_Plano_Acao_Status.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }


    }
}
