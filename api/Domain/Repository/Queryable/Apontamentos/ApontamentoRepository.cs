using api.Domain.Models.Apontamentos;
using api.Domain.Repository.Interface.Apontamentos;
using api.Domain.Views.Input.Apontamentos;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace api.Domain.Repository.Queryable.Apontamentos
{ 
    public class ApontamentoRepository : Repository<Apontamento, decimal>, IApontamentoRepository
    {
        private readonly GRCContext _context;
        public ApontamentoRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Apontamento> GetAll(bool active)
        {
            var data = DbSet.Include(i => i.ApontamentoClassificacao)
                            .Include(i => i.ApontamentoCategoria)
                            .Where(x => x.Fl_Ativo.Equals(active)).AsQueryable();
            return data;

        }
        public bool UpdateStatus(long id)
        {
            Apontamento data = DbSet.Where(x => x.Id_Apontamento.Equals(id)).AsQueryable().FirstOrDefault();
            data.Fl_Ativo = data.Fl_Ativo == true ? false : true;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public bool Create(ApontamentoInput input)
        {
            Apontamento data = new Apontamento
            {
                Apontamento_Nome                = input.Apontamento_Nome,
                Apontamento_Descricao           = input.Apontamento_Descricao,
                Id_Apontamento_Classificacao    = input.Id_Apontamento_Classificacao,
                Fl_Ativo                        = true,
                Fl_Pontecial_Saving             = input.Fl_Pontecial_Saving,
                Apontamento_Descricao_Saving    = input.Apontamento_Descricao_Saving,
                Id_Apontamento_Categoria        = input.Id_Apontamento_Categoria,
                Valor_Saving                    = input.Valor_Saving,
            };

            _context.Add(data);
            _context.SaveChanges();

            return true;
        }

        public bool Update(ApontamentoInput input)
        {
            Apontamento data = DbSet.Where(x => x.Id_Apontamento.Equals(input.Id_Apontamento)).AsQueryable().FirstOrDefault();

            data.Apontamento_Nome                   = input.Apontamento_Nome;
            data.Apontamento_Descricao              = input.Apontamento_Descricao;
            data.Id_Apontamento_Classificacao       = input.Id_Apontamento_Classificacao;
            data.Fl_Pontecial_Saving                = input.Fl_Pontecial_Saving;
            data.Apontamento_Descricao_Saving       = input.Apontamento_Descricao_Saving;
            data.Id_Apontamento_Categoria           = input.Id_Apontamento_Categoria;
            data.Valor_Saving                       = input.Valor_Saving;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public bool Remove(long id)
        {
            Apontamento data = DbSet.Where(x => x.Id_Apontamento.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }


    }

}
