using api.Domain.Models.PlanosAcao;
using api.Domain.Repository.Interface.PlanosAcao;
using api.Domain.Views.Input.PlanosAcao;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace api.Domain.Repository.Queryable.PlanosAcao
{
    public class PlanoAcaoRepository : Repository<PlanoAcao, decimal>, IPlanoAcaoRepository
    {
        private readonly GRCContext _context;
        public PlanoAcaoRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<PlanoAcao> GetAll(bool active)
        {
            var data = DbSet.Include(i => i.Departamento).Where(x => x.Fl_Ativo.Equals(active) && x.Id_Usuario > 0).AsQueryable();

            return data;
        }
        public bool UpdateStatus(long id)
        {
            PlanoAcao data = DbSet.Where(x => x.Id_Plano_Acao.Equals(id)).AsQueryable().FirstOrDefault();
            data.Fl_Ativo = data.Fl_Ativo == true ? false : true;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public bool Create(PlanoAcaoInput input)
        {
            PlanoAcao data = new PlanoAcao
            {
                Plano_Acao_Nome = input.Plano_Acao_Nome,
                Id_Plano_Acao_Status = input.Id_Plano_Acao_Status,
                Id_Usuario = input.Id_Usuario,
                Id_Departamento = input.Id_Departamento,
                Plano_Acao_Descricao = input.Plano_Acao_Descricao,
                Data_Criacao = DateTime.Now,


                Fl_Ativo = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return true;
        }

        public bool UpdateEncerramento(PlanoAcaoInput input)
        {
            PlanoAcao data = DbSet.Where(x => x.Id_Plano_Acao.Equals(input.Id_Plano_Acao)).AsQueryable().FirstOrDefault();
             
            data.Plano_Acao_Descricao_Conclusao     = input.Plano_Acao_Descricao_Conclusao;
            data.Fl_Ativo                           = true;
            data.Data_Encerramento                   = DateTime.Now;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }
        public bool Update(PlanoAcaoInput input)
        {
            PlanoAcao data = DbSet.Where(x => x.Id_Plano_Acao.Equals(input.Id_Plano_Acao)).AsQueryable().FirstOrDefault();

            data.Plano_Acao_Nome                = input.Plano_Acao_Nome;
            data.Id_Departamento                = input.Id_Departamento;
            data.Id_Plano_Acao_Status           = input.Id_Plano_Acao_Status;
            data.Plano_Acao_Descricao           = input.Plano_Acao_Descricao;
            data.Plano_Acao_Descricao_Conclusao = input.Plano_Acao_Descricao_Conclusao;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public bool UpdatePlanoAcaoWorkflow(PlanoAcaoInput input)
        {
            PlanoAcao data = DbSet.Where(x => x.Id_Plano_Acao.Equals(input.Id_Plano_Acao)).AsQueryable().FirstOrDefault();
            data.Id_Plano_Acao_Status = input.Id_Plano_Acao_Status;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }


        public bool Remove(long id)
        {
            PlanoAcao data = DbSet.Where(x => x.Id_Plano_Acao.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }

    }
}
