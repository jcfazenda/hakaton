using api.Domain.Models.PlanosAcao;
using api.Domain.Repository.Interface.PlanosAcao;
using api.Domain.Views.Input.PlanosAcao;
using Microsoft.EntityFrameworkCore;
using System;
using System.Globalization;
using System.Linq;

namespace api.Domain.Repository.Queryable.PlanosAcao
{
    public class PlanoAcaoStepRepository : Repository<PlanoAcaoStep, decimal>, IPlanoAcaoStepRepository
    {
        private readonly GRCContext _context;
        public PlanoAcaoStepRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<PlanoAcaoStep> GetByPlanoAcao(long id)
        {
            var data = DbSet.Include(i => i.Usuarios)
                            .Include(i => i.StepStatus)
                            .Where(x => x.Id_Plano_Acao.Equals(id)).AsQueryable();
            return data;
        }

        public IQueryable<PlanoAcaoStep> GetAll(bool active)
        {
            var data = DbSet.Where(x => x.Fl_Ativo.Equals(active)).AsQueryable();

            return data;
        }

        public bool UpdateStatus(long id)
        {
            PlanoAcaoStep data = DbSet.Where(x => x.Id_Plano_Acao_Step.Equals(id)).AsQueryable().FirstOrDefault();
            data.Fl_Ativo = data.Fl_Ativo == true ? false : true;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public bool Create(PlanoAcaoStepInput input)
        {
            DateTime Data_Inicio = DateTime.ParseExact(input.Data_Inicio.ToString(), "dd/MM/yyyy", CultureInfo.CurrentUICulture.DateTimeFormat);
            DateTime Data_Conclusao = DateTime.ParseExact(input.Data_Conclusao.ToString(), "dd/MM/yyyy", CultureInfo.CurrentUICulture.DateTimeFormat);


            PlanoAcaoStep data = new PlanoAcaoStep
            {
                Id_Plano_Acao = input.Id_Plano_Acao,
                Id_Usuario_Responsavel = input.Id_Usuario_Responsavel,
                Id_Step_Status      = input.Id_Step_Status, 
                Step_Nome           = input.Step_Nome,
                Step_Descricao      = input.Step_Descricao, 
                Data_Inicio         = Data_Inicio,
                Data_Conclusao      = Data_Conclusao,

                Fl_Ativo = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return true;
        }

        public bool Update(PlanoAcaoStepInput input)
        {
            DateTime Data_Inicio = DateTime.ParseExact(input.Data_Inicio.ToString(), "dd/MM/yyyy", CultureInfo.CurrentUICulture.DateTimeFormat);
            DateTime Data_Conclusao = DateTime.ParseExact(input.Data_Conclusao.ToString(), "dd/MM/yyyy", CultureInfo.CurrentUICulture.DateTimeFormat);

            PlanoAcaoStep data = DbSet.Where(x => x.Id_Plano_Acao_Step.Equals(input.Id_Plano_Acao_Step)).AsQueryable().FirstOrDefault();

            data.Id_Plano_Acao          = input.Id_Plano_Acao;
            data.Id_Step_Status         = input.Id_Step_Status;
            data.Id_Usuario_Responsavel = input.Id_Usuario_Responsavel;
            data.Step_Nome              = input.Step_Nome;
            data.Step_Descricao         = input.Step_Descricao;
            data.Data_Inicio            = Data_Inicio;
            data.Data_Conclusao         = Data_Conclusao;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }


        public bool Remove(long id)
        {
            PlanoAcaoStep data = DbSet.Where(x => x.Id_Plano_Acao_Step.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }


    }
}
