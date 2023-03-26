using api.Domain.Models.PlanosAcao;
using api.Domain.Repository.Interface.PlanosAcao;
using api.Domain.Views.Input.PlanosAcao;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace api.Domain.Repository.Queryable.PlanosAcao
{
    public class PlanoAcaoRiscoRepository : Repository<PlanoAcaoRisco, decimal>, IPlanoAcaoRiscoRepository
    {
        private readonly GRCContext _context;
        public PlanoAcaoRiscoRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<PlanoAcaoRisco> GetByPlanoAcao(long id)
        {
            var data = DbSet.Where(x => x.Id_Plano_Acao.Equals(id)).AsQueryable();
            return data;
        }

        public IQueryable<PlanoAcaoRisco> GetAll(bool active)
        {
            var data = DbSet.Where(x => x.Fl_Ativo.Equals(active)).AsQueryable();

            return data;
        }

        public bool UpdateStatus(long id)
        {
            PlanoAcaoRisco data = DbSet.Where(x => x.Id_Plano_Acao_Risco.Equals(id)).AsQueryable().FirstOrDefault();
            data.Fl_Ativo = data.Fl_Ativo == true ? false : true;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public bool Create(PlanoAcaoRiscoInput input)
        {
            PlanoAcaoRisco data = new PlanoAcaoRisco
            {
                Id_Plano_Acao = input.Id_Plano_Acao,
                Id_Risco = input.Id_Risco, 
                Fl_Ativo = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return true;
        }

        public bool Update(PlanoAcaoRiscoInput input)
        {
            PlanoAcaoRisco data = DbSet.Where(x => x.Id_Plano_Acao_Risco.Equals(input.Id_Plano_Acao_Risco)).AsQueryable().FirstOrDefault();

            data.Id_Risco = input.Id_Risco;
            data.Id_Plano_Acao = input.Id_Plano_Acao; 

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }


        public bool Remove(long id)
        {
            PlanoAcaoRisco data = DbSet.Where(x => x.Id_Plano_Acao_Risco.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }


    }
}
