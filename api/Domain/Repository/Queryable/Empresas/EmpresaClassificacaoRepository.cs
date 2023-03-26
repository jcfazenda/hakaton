using api.Domain.Models.Empresas;
using api.Domain.Repository.Interface.Empresas;
using api.Domain.Views.Input.Empresas;
using System.Linq;

namespace api.Domain.Repository.Queryable.Empresas
{
    public class EmpresaClassificacaoRepository : Repository<EmpresaClassificacao, decimal>, IEmpresaClassificacaoRepository
    {
        private readonly GRCContext _context;
        public EmpresaClassificacaoRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<EmpresaClassificacao> GetAll(bool active)
        {
            var data = DbSet.Where(x => x.Fl_Ativo.Equals(active)).AsQueryable();

            return data;
        }
        public bool UpdateStatus(long id)
        {
            EmpresaClassificacao data = DbSet.Where(x => x.Id_Empresa_Classificacao.Equals(id)).AsQueryable().FirstOrDefault();
            data.Fl_Ativo = data.Fl_Ativo == true ? false : true;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public long Create(EmpresaClassificacaoInput input)
        {
            EmpresaClassificacao data = new EmpresaClassificacao
            { 
                Empresa_Classificacao_Nome = input.Empresa_Classificacao_Nome,
                Fl_Ativo = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return data.Id_Empresa_Classificacao;
        }

        public bool Update(EmpresaClassificacaoInput input)
        {
            EmpresaClassificacao data = DbSet.Where(x => x.Id_Empresa_Classificacao.Equals(input.Id_Empresa_Classificacao)).AsQueryable().FirstOrDefault();
             
            data.Empresa_Classificacao_Nome = input.Empresa_Classificacao_Nome;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }
        public bool Remove(long id)
        {
            EmpresaClassificacao data = DbSet.Where(x => x.Id_Empresa_Classificacao.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }


    }
}
