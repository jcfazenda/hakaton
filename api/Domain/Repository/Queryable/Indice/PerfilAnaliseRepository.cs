using api.Domain.Models.Indice;
using api.Domain.Repository.Interface.Indice;
using api.Domain.Views.Input.Indice;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace api.Domain.Repository.Queryable.Indice
{
    public class PerfilAnaliseRepository : Repository<PerfilAnalise, decimal>, IPerfilAnaliseRepository
    {
        private readonly GRCContext _context;
        public PerfilAnaliseRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<PerfilAnalise> GetAll(bool active)
        {
            var data = DbSet.Where(x => x.Fl_Ativo.Equals(active)).AsQueryable();

            return data;
        }
        public IQueryable<PerfilAnalise> Get(long id)
        {
            var data = DbSet.Include(i => i.IndiceFinanceiro).Where(x => x.Id_Perfil_Analise.Equals(id)).AsQueryable();

            return data;
        }
        public bool UpdateStatus(long id)
        {
            PerfilAnalise data = DbSet.Where(x => x.Id_Perfil_Analise.Equals(id)).AsQueryable().FirstOrDefault();
            data.Fl_Ativo = data.Fl_Ativo == true ? false : true;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public bool Create(PerfilAnaliseInput input)
        {
            PerfilAnalise data = new PerfilAnalise
            {
                Perfil_Analise_Nome         = input.Perfil_Analise_Nome,
                Perfil_Analise_Descricao    = input.Perfil_Analise_Descricao, 
                Id_Matriz                   =  input.Id_Matriz,
                Id_Indice_Financeiro        = input.Id_Indice_Financeiro,
                Id_Tipo_Avaliacao           = input.Id_Tipo_Avaliacao,
                Inerente_Residual_Planejado = input.Inerente_Residual_Planejado,
                Fl_Ativo                    = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return true;
        }

        public bool Update(PerfilAnaliseInput input)
        {
            PerfilAnalise data = DbSet.Where(x => x.Id_Perfil_Analise.Equals(input.Id_Perfil_Analise)).AsQueryable().FirstOrDefault();

            data.Perfil_Analise_Nome         = input.Perfil_Analise_Nome;
            data.Perfil_Analise_Descricao    = input.Perfil_Analise_Descricao;
            data.Id_Matriz                   = input.Id_Matriz;
            data.Id_Indice_Financeiro        = input.Id_Indice_Financeiro;
            data.Id_Tipo_Avaliacao           = input.Id_Tipo_Avaliacao;
            data.Inerente_Residual_Planejado = input.Inerente_Residual_Planejado;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public bool Remove(long id)
        {
            PerfilAnalise data = DbSet.Where(x => x.Id_Perfil_Analise.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }


    }
}
