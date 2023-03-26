using api.Domain.Models.Indice;
using api.Domain.Repository.Interface.Indice;
using api.Domain.Views.Input.Indice;
using System;
using System.Globalization;
using System.Linq;

namespace api.Domain.Repository.Queryable.Indice
{
    public class IndiceFinanceiroRepository : Repository<IndiceFinanceiro, decimal>, IIndiceFinanceiroRepository
    {
        private readonly GRCContext _context;
        public IndiceFinanceiroRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<IndiceFinanceiro> GetAll(bool active)
        {
            var data = DbSet.Where(x => x.Fl_Ativo.Equals(active)).AsQueryable();

            return data;
        }
        public bool UpdateStatus(long id)
        {
            IndiceFinanceiro data = DbSet.Where(x => x.Id_Indice_Financeiro.Equals(id)).AsQueryable().FirstOrDefault();
            data.Fl_Ativo = data.Fl_Ativo == true ? false : true;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public bool Create(IndiceFinanceiroInput input)
        {  

            IndiceFinanceiro data = new IndiceFinanceiro(); 

            data.Indice_Financeiro_Nome          = input.Indice_Financeiro_Nome;
            data.Indice_Financeiro_Descricao     = input.Indice_Financeiro_Descricao;
            data.Data_Ocorrencia                 = DateTime.Now;
            data.Valor_Referencia                = float.Parse(input.Valor_Referencia.ToString().Replace(",", "").Replace(".", ""), new CultureInfo("en-US")); 
            data.Fl_Ativo                        = true;

            _context.Add(data);
            _context.SaveChanges();

            return true;
        }

        public bool Update(IndiceFinanceiroInput input)
        { 
            DateTime myDate = DateTime.ParseExact(input.Data_Ocorrencia.ToString(), "dd/MM/yyyy", CultureInfo.CurrentUICulture.DateTimeFormat);

            IndiceFinanceiro data = DbSet.Where(x => x.Id_Indice_Financeiro.Equals(input.Id_Indice_Financeiro)).AsQueryable().FirstOrDefault();

            data.Indice_Financeiro_Nome         = input.Indice_Financeiro_Nome;
            data.Indice_Financeiro_Descricao    = input.Indice_Financeiro_Descricao;
            data.Data_Ocorrencia                = myDate;
            data.Valor_Referencia               = float.Parse(input.Valor_Referencia.ToString().Replace(",", "").Replace(".", ""), new CultureInfo("en-US")); 

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public bool Remove(long id)
        {
            IndiceFinanceiro data = DbSet.Where(x => x.Id_Indice_Financeiro.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }

    }
}
