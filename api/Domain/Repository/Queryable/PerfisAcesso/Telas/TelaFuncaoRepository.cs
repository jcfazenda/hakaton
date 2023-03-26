using api.Domain.Models.PerfisAcesso.Telas;
using api.Domain.Repository.Interface.PerfisAcesso.Telas;
using api.Domain.Views.Input.PerfisAcesso.Telas;
using System.Collections.Generic;
using System.Linq;

namespace api.Domain.Repository.Queryable.PerfisAcesso.Telas
{
    public class TelaFuncaoRepository : Repository<TelaFuncao, decimal>, ITelaFuncaoRepository
    {
        private readonly GRCContext _context;
        public TelaFuncaoRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<TelaFuncao> GetAll(bool active)
        {
            var data = DbSet.AsQueryable();

            return data;
        }

        public IQueryable<TelaFuncao> GetByTela(long id)
        {
            var data = DbSet.Where(x => x.Id_Tela.Equals(id)).AsQueryable();

            return data;
        }
        public IQueryable<TelaFuncao> GetByCodFuncao(string codFuncao, long idTela)
        {
            var data = DbSet.Where(x => x.Tela_Funcao_Codigo.Equals(codFuncao) && x.Id_Tela.Equals(idTela) ).AsQueryable();

            return data;
        }


        public bool UpdateStatus(long id)
        {
            TelaFuncao data = DbSet.Where(x => x.Id_Tela_Funcao.Equals(id)).AsQueryable().FirstOrDefault();
            data.Fl_Ativo = data.Fl_Ativo == true ? false : true;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public long Create(TelaFuncaoInput input)
        { 

            TelaFuncao data = new TelaFuncao
            {
                Tela_Funcao_Nome    = input.Tela_Funcao_Nome,
                Tela_Funcao_Codigo  = input.Tela_Funcao_Codigo, 
                Fl_Ativo            = true,
                Id_Tela             = input.Id_Tela
            };

            _context.Add(data);
            _context.SaveChanges();

            return data.Id_Tela_Funcao; 

        }

        public bool CreateByTela(TelaFuncaoInput input)
        {
            try
            {

                foreach (var item in input.ListIdTela)
                {
                    TelaFuncao data = new TelaFuncao
                    {
                        Tela_Funcao_Nome        = input.Tela_Funcao_Nome,
                        Tela_Funcao_Codigo      = input.Tela_Funcao_Codigo,
                        Fl_Ativo                = true,
                        Id_Tela                 = item
                    };

                    _context.Add(data);
                    _context.SaveChanges();
                }

                return true; 

            }
            catch (System.Exception )
            {

                throw;
            }

        }


        public long Update(TelaFuncaoInput input)
        {
            if (input.Id_Tela_Funcao > 0) { 

                TelaFuncao data = DbSet.Where(x => x.Id_Tela_Funcao.Equals(input.Id_Tela_Funcao)).AsQueryable().FirstOrDefault();

                data.Tela_Funcao_Nome   = input.Tela_Funcao_Nome;
                data.Tela_Funcao_Codigo = input.Tela_Funcao_Codigo;
                data.Icone = input.Icone;

                _context.Update(data);
                _context.SaveChanges();

                return data.Id_Tela_Funcao;

            }

            return input.Id_Tela_Funcao;
        }
        public bool Remove(long id)
        {
            TelaFuncao data = DbSet.Where(x => x.Id_Tela_Funcao.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }

        public bool RemoveByTela(long idTela)
        {
            List<TelaFuncao> data = DbSet.Where(x => x.Id_Tela.Equals(idTela)).AsQueryable().ToList();

            foreach (var item in data)
            { 
                _context.Remove(item);
                _context.SaveChanges(); 
            }

            return true;
        }


    }
}
