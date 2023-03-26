using api.Domain.Models.PerfisAcesso.Telas;
using api.Domain.Repository.Interface.PerfisAcesso.Telas;
using api.Domain.Views.Input.PerfisAcesso.Telas;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace api.Domain.Repository.Queryable.PerfisAcesso.Telas
{
    public class NivelAcessoTelaFuncaoRepository : Repository<NivelAcessoTelaFuncao, decimal>, INivelAcessoTelaFuncaoRepository
    {
        private readonly GRCContext _context;
        public NivelAcessoTelaFuncaoRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<NivelAcessoTelaFuncao> GetAll(bool active)
        {
            var data = DbSet.Where(x => x.Fl_Ativo.Equals(active)).AsQueryable();

            return data;
        }

        public IQueryable<NivelAcessoTelaFuncao> GetExist(NivelAcessoTelaFuncaoInput input)
        {
            var data = DbSet.Where(x => x.Id_Nivel_Acesso.Equals(input.Id_Nivel_Acesso) &&
                                        x.Id_Tela.Equals(input.Id_Tela) &&
                                        x.Id_Tela_Funcao.Equals(input.Id_Tela_Funcao)).OrderBy(o => o.Id_Tela).AsQueryable();

            return data;
        }

        public IQueryable<NivelAcessoTelaFuncao> GetByNivel(long id)
        {
            var data = DbSet.Include(i => i.Tela)
                            .Include(i => i.TelaFuncao)
                            .Where(x => x.Id_Nivel_Acesso.Equals(id)).OrderBy(o => o.Id_Tela).AsQueryable();

            return data;
        }
        public IQueryable<NivelAcessoTelaFuncao> GetByNivelTela(long idNivel, long idTela)
        {
            var data = DbSet.Include(i => i.Tela)
                            .Include(i => i.TelaFuncao)
                            .Where(x => x.Id_Nivel_Acesso.Equals(idNivel) &&
                                        x.Id_Tela.Equals(idTela)).OrderBy(o => o.Id_Tela).AsQueryable();

            return data;
        }

        public IQueryable<NivelAcessoTelaFuncao> GetByTela(long idTela)
        {
            var data = DbSet.Include(i => i.Tela)
                            .Include(i => i.TelaFuncao)
                            .Where(x => x.Id_Tela.Equals(idTela)).OrderBy(o => o.Id_Tela).AsQueryable();

            return data;
        }



        public bool UpdateStatus(long id)
        {
            NivelAcessoTelaFuncao data = DbSet.Where(x => x.Id_Nivel_Acesso_Tela_Funcao.Equals(id)).AsQueryable().FirstOrDefault();
            data.Fl_Ativo = data.Fl_Ativo == true ? false : true;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public bool Create(NivelAcessoTelaFuncaoInput input)
        {
            NivelAcessoTelaFuncao data = new NivelAcessoTelaFuncao
            {
                Id_Nivel_Acesso = input.Id_Nivel_Acesso,
                Id_Tela_Funcao = input.Id_Tela_Funcao,
                Id_Tela = input.Id_Tela,

                Fl_Ativo = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return true;
        }

        public bool Update(NivelAcessoTelaFuncaoInput input)
        {
            NivelAcessoTelaFuncao data = DbSet.Where(x => x.Id_Nivel_Acesso_Tela_Funcao.Equals(input.Id_Nivel_Acesso_Tela_Funcao)).AsQueryable().FirstOrDefault();

            data.Id_Nivel_Acesso = input.Id_Nivel_Acesso;
            data.Id_Tela_Funcao = input.Id_Tela_Funcao;
            data.Id_Tela = input.Id_Tela;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }
        public bool Remove(long id)
        {
            NivelAcessoTelaFuncao data = DbSet.Where(x => x.Id_Nivel_Acesso_Tela_Funcao.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }


    }
}
