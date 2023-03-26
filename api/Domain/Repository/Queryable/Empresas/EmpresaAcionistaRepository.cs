using api.Domain.Models.Empresas;
using api.Domain.Repository.Interface.Empresas;
using api.Domain.Views.Input.Empresas;
using Microsoft.EntityFrameworkCore;
using System;
using System.Globalization;
using System.Linq;

namespace api.Domain.Repository.Queryable.Empresas
{
    public class EmpresaAcionistaRepository : Repository<EmpresaAcionista, decimal>, IEmpresaAcionistaRepository
    {
        private readonly GRCContext _context;
        public EmpresaAcionistaRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<EmpresaAcionista> GetByEmpresa(long id)
        {
            var data = DbSet.Include(i => i.Acionista) 
                            .Where(x => x.Id_Empresa.Equals(id)).AsQueryable();

            return data;
        }
        public IQueryable<EmpresaAcionista> GetByAcionista(long id)
        {
            var data = DbSet.Include(i => i.Acionista)
                            .Where(x => x.Id_Acionista.Equals(id)).AsQueryable();

            return data;
        }

        public bool Create(EmpresaAcionistaInput input)
        { 

            try
            {
                EmpresaAcionista data = new EmpresaAcionista();

                data.Id_Empresa         = input.Id_Empresa;
                data.Id_Acionista       = input.Id_Acionista;
                data.Valor_Percentual   = input.Valor_Percentual; 
                data.Fl_Ativo           = true;

                if (input.Data_Entrada == null | input.Data_Entrada == "") { data.Data_Entrada = null; }
                if (input.Data_Entrada != null && input.Data_Entrada != "") { data.Data_Entrada = DateTime.ParseExact(input.Data_Entrada.ToString(), "dd/MM/yyyy", CultureInfo.CurrentUICulture.DateTimeFormat); } 

                if (input.Data_Saida == null | input.Data_Saida == "") { data.Data_Saida = null; }
                if (input.Data_Saida != null && input.Data_Saida != "") { data.Data_Saida = DateTime.ParseExact(input.Data_Saida.ToString(), "dd/MM/yyyy", CultureInfo.CurrentUICulture.DateTimeFormat); }
               

                _context.Add(data);
                _context.SaveChanges();

                return true;
            }
            catch (System.Exception )
            {
                return true;
            }

        }
        public bool UpdatePercentual(EmpresaAcionistaInput input)
        {
            try
            {  

                EmpresaAcionista data = DbSet.Where(x => x.Id_Empresa_Acionista.Equals(input.Id_Empresa_Acionista)).AsQueryable().FirstOrDefault();
                data.Valor_Percentual = input.Valor_Percentual;

                if (input.Data_Entrada == null | input.Data_Entrada == "") { data.Data_Entrada = null; }
                if (input.Data_Entrada != null && input.Data_Entrada != "") { data.Data_Entrada = DateTime.ParseExact(input.Data_Entrada.ToString(), "dd/MM/yyyy", CultureInfo.CurrentUICulture.DateTimeFormat); }

                if (input.Data_Saida == null | input.Data_Saida == "") { data.Data_Saida = null; }
                if (input.Data_Saida != null && input.Data_Saida != "") { data.Data_Saida = DateTime.ParseExact(input.Data_Saida.ToString(), "dd/MM/yyyy", CultureInfo.CurrentUICulture.DateTimeFormat); }

                _context.Update(data);
                _context.SaveChanges();

                return true;
            }
            catch (System.Exception )
            {
                return true;
            }

        } 

        public bool Remove(long id)
        {
            EmpresaAcionista data = DbSet.Where(x => x.Id_Empresa_Acionista.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }


    }
}
