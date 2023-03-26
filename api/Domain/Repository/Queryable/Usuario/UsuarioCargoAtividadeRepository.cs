using api.Domain.Models.PlanosAcao;
using api.Domain.Models.Usuario;
using api.Domain.Repository.Interface.PlanosAcao;
using api.Domain.Repository.Interface.Usuario;
using api.Domain.Views.Input.PlanosAcao;
using api.Domain.Views.Input.Usuario;
using System;
using System.Linq;

namespace api.Domain.Repository.Queryable.Usuario
{
    public class UsuarioCargoAtividadeRepository : Repository<UsuarioCargoAtividade, decimal>, IUsuarioCargoAtividadeRepository
    {
        private readonly GRCContext _context;
        public UsuarioCargoAtividadeRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<UsuarioCargoAtividade> GetAll(bool active)
        {
            var data = DbSet.Where(x => x.Fl_Ativo.Equals(active)).AsQueryable();

            return data;
        }
        public bool UpdateStatus(long id)
        {
            UsuarioCargoAtividade data = DbSet.Where(x => x.Id_Usuario_Cargo_Atividade.Equals(id)).AsQueryable().FirstOrDefault();
            data.Fl_Ativo = data.Fl_Ativo == true ? false : true;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public bool Create(UsuarioCargoAtividadeInput input)
        {
            UsuarioCargoAtividade data = new UsuarioCargoAtividade
            {
                Usuario_Cargo_Atividade_Nome = input.Usuario_Cargo_Atividade_Nome,
                Usuario_Cargo_Atividade_Descricao = input.Usuario_Cargo_Atividade_Descricao,

                Fl_Ativo = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return true;
        }

        public bool Update(UsuarioCargoAtividadeInput input)
        {
            UsuarioCargoAtividade data = DbSet.Where(x => x.Id_Usuario_Cargo_Atividade.Equals(input.Id_Usuario_Cargo_Atividade)).AsQueryable().FirstOrDefault();

            data.Usuario_Cargo_Atividade_Nome = input.Usuario_Cargo_Atividade_Nome;
            data.Usuario_Cargo_Atividade_Descricao = input.Usuario_Cargo_Atividade_Descricao;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }


        public bool Remove(long id)
        {
            UsuarioCargoAtividade data = DbSet.Where(x => x.Id_Usuario_Cargo_Atividade.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }


    }
}
