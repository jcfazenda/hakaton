using api.Domain.Models.Empresas;
using api.Domain.Repository.Interface.Empresas;
using api.Domain.Views.Input.Empresas;
using System.Linq;

namespace api.Domain.Repository.Queryable.Empresas
{
    public class EmpresaEnderecoRepository : Repository<EmpresaEndereco, decimal>, IEmpresaEnderecoRepository
    {
        private readonly GRCContext _context;
        public EmpresaEnderecoRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<EmpresaEndereco> GeById(long id)
        {
            var data = DbSet.Where(x => x.Id_Empresa_Endereco.Equals(id)).AsQueryable();

            return data;
        }
        public IQueryable<EmpresaEndereco> GetAll(bool active)
        {
            var data = DbSet.Where(x => x.Fl_Ativo.Equals(active)).AsQueryable();

            return data;
        }
        public bool UpdateStatus(long id)
        {
            EmpresaEndereco data = DbSet.Where(x => x.Id_Empresa_Endereco.Equals(id)).AsQueryable().FirstOrDefault();
            data.Fl_Ativo = data.Fl_Ativo == true ? false : true;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }
         
        public long Create(EmpresaEnderecoInput input)
        {
            try
            {
                EmpresaEndereco data = new EmpresaEndereco
                {
                    Id_Empresa  = input.Id_Empresa,
                    Cidade      = input.Cidade,
                    Logradouro  = input.Logradouro,
                    Numero      = input.Numero,
                    Cep         = input.Cep,
                    Uf          = input.Uf,
                    Complemento = input.Complemento,
                    Bairro      = input.Bairro,
                    Fl_Matriz   = input.Fl_Matriz,
                    Fl_Ativo    = true
                };

                _context.Add(data);
                _context.SaveChanges();

                return data.Id_Empresa_Endereco;
            }
            catch (System.Exception )
            {
                return 0;
            }

        }

        public bool Update(EmpresaEnderecoInput input)
        {
            EmpresaEndereco data = DbSet.Where(x => x.Id_Empresa_Endereco.Equals(input.Id_Empresa_Endereco)).AsQueryable().FirstOrDefault();

            data.Id_Empresa         = input.Id_Empresa;
            data.Cidade             = input.Cidade;
            data.Logradouro         = input.Logradouro;
            data.Numero             = input.Numero;
            data.Cep                = input.Cep;
            data.Uf                 = input.Uf;
            data.Complemento        = input.Complemento;
            data.Bairro             = input.Bairro; 
            data.Fl_Matriz          = input.Fl_Matriz;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }
        public bool Remove(long id)
        {
            EmpresaEndereco data = DbSet.Where(x => x.Id_Empresa_Endereco.Equals(id)).AsQueryable().FirstOrDefault();

            if (data != null)
            {
                _context.Remove(data);
                _context.SaveChanges();
            } 

            return true;
        }
        public bool RemoveByEmpresa(long id)
        {
            EmpresaEndereco data = DbSet.Where(x => x.Id_Empresa.Equals(id)).AsQueryable().FirstOrDefault();

            if (data != null)
            {
                _context.Remove(data);
                _context.SaveChanges();
            }

            return true;
        }

    }
}
