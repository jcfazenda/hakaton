using api.Domain.Models.PerfisAcesso.Telas;
using api.Domain.Repository.Interface.PerfisAcesso.Telas;
using api.Domain.Views.Input.PerfisAcesso.Telas;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace api.Domain.Repository.Queryable.PerfisAcesso.Telas
{
    public class NivelAcessoUsuarioRepository : Repository<NivelAcessoUsuario, decimal>, INivelAcessoUsuarioRepository
    {
        private readonly GRCContext _context;
        public NivelAcessoUsuarioRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<NivelAcessoUsuario> GetAll(bool active)
        {
            var data = DbSet.Where(x => x.Fl_Ativo.Equals(active)).AsQueryable();

            return data;
        }

        public IQueryable<NivelAcessoUsuario> GetExist(NivelAcessoUsuarioInput input)
        {
            var data = DbSet.Where(x => x.Id_Nivel_Acesso.Equals(input.Id_Nivel_Acesso) &&
                                        x.Id_Usuario.Equals(input.Id_Usuario)).OrderBy(o => o.Id_Nivel_Acesso).AsQueryable();

            return data;
        }

        public IQueryable<NivelAcessoUsuario> GetByUsuario(long id)
        {
            var data = DbSet.Include(i => i.NivelAcesso)
                            .Where(x => x.Id_Usuario.Equals(id)).OrderBy(o => o.Id_Nivel_Acesso).AsQueryable();

            return data;
        }

        public bool UpdateStatus(long id)
        {
            NivelAcessoUsuario data = DbSet.Where(x => x.Id_Nivel_Acesso_Usuario.Equals(id)).AsQueryable().FirstOrDefault();
            data.Fl_Ativo = data.Fl_Ativo == true ? false : true;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public bool Create(NivelAcessoUsuarioInput input)
        {
            NivelAcessoUsuario data = new NivelAcessoUsuario
            {
                Id_Nivel_Acesso     = input.Id_Nivel_Acesso,
                Id_Usuario          = input.Id_Usuario,
                Data_Validade       = DateTime.Now,

                Fl_Ativo = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return true;
        }

        public bool Update(NivelAcessoUsuarioInput input)
        {
            NivelAcessoUsuario data = DbSet.Where(x => x.Id_Nivel_Acesso_Usuario.Equals(input.Id_Nivel_Acesso_Usuario)).AsQueryable().FirstOrDefault();

            data.Id_Nivel_Acesso    = input.Id_Nivel_Acesso;
            data.Id_Usuario         = input.Id_Usuario;
            data.Data_Validade      = DateTime.Now;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }
        public bool RemoveByUsuario(long id)
        {
            List<NivelAcessoUsuario> data = DbSet.Where(x => x.Id_Usuario.Equals(id)).AsQueryable().ToList();

            foreach (var item in data)
            {
                _context.Remove(item);
                _context.SaveChanges();
            }

            return true;
        }
        public bool Remove(long id)
        {
            NivelAcessoUsuario data = DbSet.Where(x => x.Id_Nivel_Acesso_Usuario.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }

    }
}
