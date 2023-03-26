using api.Domain.Models.Controles;
using api.Domain.Repository.Interface.Controles;
using api.Domain.Views.Input.Controles;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace api.Domain.Repository.Queryable.Controles
{
    public class ControleRepository : Repository<Controle, decimal>, IControleRepository
    {
        private readonly GRCContext _context;
        public ControleRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Controle> GetAll(bool active)
        {
            var data = DbSet.Include(i => i.ControleCategoria)
                           .Where(x => x.Fl_Ativo.Equals(active)).AsQueryable();

            return data;
        }
        public bool UpdateStatus(long id)
        {
            Controle data = DbSet.Where(x => x.Id_Controle.Equals(id)).AsQueryable().FirstOrDefault();
            data.Fl_Ativo = data.Fl_Ativo == true ? false : true;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public bool Create(ControleInput input)
        {
            Controle data = new Controle
            {
                Id_Controle_Categoria           = (long)input.Id_Controle_Categoria,
                Id_Controle_Frequencia          = (long)input.Id_Controle_Frequencia,
                Id_Controle_Grau_Automacao      = (long)input.Id_Controle_Grau_Automacao,
                Id_Controle_Categoria_Objetivo  = (long)input.Id_Controle_Categoria_Objetivo,
                Id_Controle_Tipo                = (long)input.Id_Controle_Tipo,

                Controle_Valor_Custo            = Convert.ToDouble(input.Controle_Valor_Custo),
                Controle_Nome                   = input.Controle_Nome,
                Controle_Descricao              = input.Controle_Descricao, 
                Fl_Ativo                        = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return true;
        }

        public bool Update(ControleInput input)
        {
            Controle data = DbSet.Where(x => x.Id_Controle.Equals(input.Id_Controle)).AsQueryable().FirstOrDefault();

            data.Id_Controle_Categoria              = (long)input.Id_Controle_Categoria;
            data.Id_Controle_Frequencia             = (long)input.Id_Controle_Frequencia;
            data.Id_Controle_Grau_Automacao         = (long)input.Id_Controle_Grau_Automacao;
            data.Id_Controle_Categoria_Objetivo     = (long)input.Id_Controle_Categoria_Objetivo;
            data.Id_Controle_Tipo                   = (long)input.Id_Controle_Tipo;

            data.Controle_Valor_Custo               = Convert.ToDouble(input.Controle_Valor_Custo);
            data.Controle_Nome                      = input.Controle_Nome;
            data.Controle_Descricao                 = input.Controle_Descricao;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }
        public bool Remove(long id)
        {
            Controle data = DbSet.Where(x => x.Id_Controle.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }


    }
}
