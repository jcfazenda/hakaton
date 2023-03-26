using api.Domain.Models.PerfisAcesso.Telas;
using api.Domain.Repository.Interface.PerfisAcesso.Telas;
using api.Domain.Views.Input.PerfisAcesso.Telas;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace api.Domain.Repository.Queryable.PerfisAcesso.Telas
{
    public class NivelAcessoTelaRegistroRepository : Repository<NivelAcessoTelaRegistro, decimal>, INivelAcessoTelaRegistroRepository
    {
        private readonly GRCContext _context;
        public NivelAcessoTelaRegistroRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<NivelAcessoTelaRegistro> GetAll(bool active)
        {
            var data = DbSet.Include(i => i.Tela)
                            .Where(x => x.Fl_Ativo.Equals(active)).AsQueryable();

            return data;
        }

        public IQueryable<NivelAcessoTelaRegistro> GetExist(NivelAcessoTelaRegistroInput input)
        {
            var data = DbSet.Where(x => x.Id_Nivel_Acesso.Equals(input.Id_Nivel_Acesso) &&
                                        x.Id_Tela.Equals(input.Id_Tela) &&
                                        x.Id_Registro.Equals(input.Id_Registro)).OrderBy(o => o.Id_Tela).AsQueryable();

            return data;
        }

        public IQueryable<NivelAcessoTelaRegistro> GetByTelaRegistro(NivelAcessoTelaRegistroInput input)
        {
            var data = DbSet.Where(x => x.Id_Tela.Equals(input.Id_Tela) &&
                                        x.Id_Registro.Equals(input.Id_Registro)).OrderBy(o => o.Id_Nivel_Acesso).AsQueryable();

            return data;
        }


        public IQueryable<NivelAcessoTelaRegistro> GetById(long id)
        {
            var data = DbSet.Where(x => x.Id_Nivel_Acesso.Equals(id)).AsQueryable();

            return data;
        }

        public IQueryable<NivelAcessoTelaRegistro> GetByNivelAndTela(long idNivel, long idTela)
        {
            var data = DbSet.Include(i => i.Tela)
                            .Where(x => x.Id_Nivel_Acesso.Equals(idNivel) &&
                                        x.Id_Tela.Equals(idTela)).OrderBy(o => o.Id_Tela).AsQueryable();

            return data;
        }

        public bool UpdateStatus(long id)
        {
            NivelAcessoTelaRegistro data = DbSet.Where(x => x.Id_Nivel_Acesso_Tela_Registro.Equals(id)).AsQueryable().FirstOrDefault();
            data.Fl_Ativo = data.Fl_Ativo == true ? false : true;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public bool Create(NivelAcessoTelaRegistroInput input)
        {
            NivelAcessoTelaRegistro data = new NivelAcessoTelaRegistro
            {
                Id_Nivel_Acesso = input.Id_Nivel_Acesso,
                Id_Registro = input.Id_Registro,
                Id_Tela = input.Id_Tela,

                Fl_Ativo = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return true;
        }

        public bool Update(NivelAcessoTelaRegistroInput input)
        {
            NivelAcessoTelaRegistro data = DbSet.Where(x => x.Id_Nivel_Acesso_Tela_Registro.Equals(input.Id_Nivel_Acesso_Tela_Registro)).AsQueryable().FirstOrDefault();

            data.Id_Nivel_Acesso = input.Id_Nivel_Acesso;
            data.Id_Registro = input.Id_Registro;
            data.Id_Tela = input.Id_Tela;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }
        public bool Remove(long id)
        {
            NivelAcessoTelaRegistro data = DbSet.Where(x => x.Id_Nivel_Acesso_Tela_Registro.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }


    }
}
