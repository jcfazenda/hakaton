using api.Domain.Models.Incidentes;
using api.Domain.Repository.Interface.Incidentes;
using api.Domain.Views.Input.Incidentes;
using System;
using System.Globalization;
using System.Linq;

namespace api.Domain.Repository.Queryable.Incidentes
{
    public class IncidenteRepository : Repository<Incidente, decimal>, IIncidenteRepository
    {
        private readonly GRCContext _context;
        public IncidenteRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Incidente> GetAll(bool active)
        {
            var data = DbSet.Where(x => x.Fl_Ativo.Equals(active)).AsQueryable();

            return data;
        }
        public bool UpdateStatus(long id)
        {
            Incidente data = DbSet.Where(x => x.Id_Incidente.Equals(id)).AsQueryable().FirstOrDefault();
            data.Fl_Ativo = data.Fl_Ativo == true ? false : true;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public bool Create(IncidenteInput input)
        {
            DateTime Data_Ocorrencia = DateTime.ParseExact(input.Data_Ocorrencia.ToString(), "dd/MM/yyyy", CultureInfo.CurrentUICulture.DateTimeFormat);

            Incidente data = new Incidente
            {
                Incidente_Nome          = input.Incidente_Nome,
                Incidente_Descricao     = input.Incidente_Descricao,
                Id_Incidente_Categoria  = input.Id_Incidente_Categoria,

                Base_Origem             = input.Base_Origem,
                Perda_Financeira        = Convert.ToDouble(input.Perda_Financeira),
                Data_Ocorrencia         = Data_Ocorrencia,

                Fl_Ativo = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return true;
        }

        public bool Update(IncidenteInput input)
        {
            try
            {
                DateTime Data_Ocorrencia = DateTime.ParseExact(input.Data_Ocorrencia.ToString(), "dd/MM/yyyy", CultureInfo.CurrentUICulture.DateTimeFormat); 

                Incidente data = DbSet.Where(x => x.Id_Incidente.Equals(input.Id_Incidente)).AsQueryable().FirstOrDefault(); 

                data.Incidente_Nome             = input.Incidente_Nome;
                data.Incidente_Descricao        = input.Incidente_Descricao;
                data.Id_Incidente_Categoria     = input.Id_Incidente_Categoria; 
                data.Base_Origem                = input.Base_Origem;
                data.Perda_Financeira           = Convert.ToDouble(input.Perda_Financeira);
                data.Data_Ocorrencia            = Data_Ocorrencia;

                _context.Update(data);
                _context.SaveChanges();

                return true;

            }
            catch (Exception)
            {
                return false;
            }

           
        }

        public bool Remove(long id)
        {
            Incidente data = DbSet.Where(x => x.Id_Incidente.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }


    }
}
