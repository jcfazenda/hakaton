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
    public class UsuarioAreaAtuacaoRepository : Repository<UsuarioAreaAtuacao, decimal>, IUsuarioAreaAtuacaoRepository
    {
        private readonly GRCContext _context;
        public UsuarioAreaAtuacaoRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<UsuarioAreaAtuacao> GetAll(bool active)
        {
            var data = DbSet.Where(x => x.Fl_Ativo.Equals(active)).AsQueryable();

            return data;
        }
        public bool UpdateStatus(long id)
        {
            UsuarioAreaAtuacao data = DbSet.Where(x => x.Id_Usuario_Area_Atuacao.Equals(id)).AsQueryable().FirstOrDefault();
            data.Fl_Ativo = data.Fl_Ativo == true ? false : true;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public bool Create(UsuarioAreaAtuacaoInput input)
        {
            UsuarioAreaAtuacao data = new UsuarioAreaAtuacao
            {
                Usuario_Area_Atuacao_Nome = input.Usuario_Area_Atuacao_Nome,
                Usuario_Area_Atuacao_Descricao = input.Usuario_Area_Atuacao_Descricao, 

                Fl_Ativo = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return true;
        }

        public bool Update(UsuarioAreaAtuacaoInput input)
        {
            UsuarioAreaAtuacao data = DbSet.Where(x => x.Id_Usuario_Area_Atuacao.Equals(input.Id_Usuario_Area_Atuacao)).AsQueryable().FirstOrDefault();

            data.Usuario_Area_Atuacao_Nome = input.Usuario_Area_Atuacao_Nome;
            data.Usuario_Area_Atuacao_Descricao = input.Usuario_Area_Atuacao_Descricao; 

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }


        public bool Remove(long id)
        {
            UsuarioAreaAtuacao data = DbSet.Where(x => x.Id_Usuario_Area_Atuacao.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }


    }
}
