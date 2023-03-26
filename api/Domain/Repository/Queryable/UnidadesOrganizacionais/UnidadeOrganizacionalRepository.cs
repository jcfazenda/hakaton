using api.Domain.Models.UnidadesOrganizacionais;
using api.Domain.Repository.Interface.UnidadesOrganizacionais;
using api.Domain.Views.Input.UnidadesOrganizacionais;
using System;
using System.Globalization;
using System.Linq;

namespace api.Domain.Repository.Queryable.UnidadesOrganizacional
{
    public class UnidadeOrganizacionalRepository : Repository<UnidadeOrganizacional, decimal>, IUnidadeOrganizacionalRepository
    {
        private readonly GRCContext _context;
        public UnidadeOrganizacionalRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<UnidadeOrganizacional> GetAny(bool active)
        {
            var data = DbSet.Where(x => x.Fl_Ativo.Equals(active)).AsQueryable();

            return data;
        }
        public bool UpdateStatus(long id)
        {
            UnidadeOrganizacional data = DbSet.Where(x => x.Id_Unidade_Organizacional.Equals(id)).AsQueryable().FirstOrDefault();
            data.Fl_Ativo = data.Fl_Ativo == true ? false : true;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public long Create(UnidadeOrganizacionalInput input)
        {
            DateTime Data_Inicio = DateTime.ParseExact(input.Data_Inicio.ToString(), "dd/MM/yyyy", CultureInfo.CurrentUICulture.DateTimeFormat);
            DateTime Data_Fim    = DateTime.ParseExact(input.Data_Fim.ToString(), "dd/MM/yyyy", CultureInfo.CurrentUICulture.DateTimeFormat);

            UnidadeOrganizacional data = new UnidadeOrganizacional
            {
                Id_Usuario = input.Id_Usuario,
                Id_Unidade_Organizacional_Orgao = input.Id_Unidade_Organizacional_Orgao,
                Id_Unidade_Organizacional_Responsabilidade = input.Id_Unidade_Organizacional_Responsabilidade,  
                Unidade_Organizacional_Nome = input.Unidade_Organizacional_Nome,
                Unidade_Organizacional_Descricao = input.Unidade_Organizacional_Descricao, 
                Data_Inicio = Data_Inicio,
                Data_Fim = Data_Fim,

                Fl_Temporaria = input.Fl_Temporaria, 
                Fl_Ativo = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return data.Id_Unidade_Organizacional;
        }

        public long Update(UnidadeOrganizacionalInput input)
        {
            DateTime Data_Inicio = DateTime.ParseExact(input.Data_Inicio.ToString(), "dd/MM/yyyy", CultureInfo.CurrentUICulture.DateTimeFormat);
            DateTime Data_Fim    = DateTime.ParseExact(input.Data_Fim.ToString(), "dd/MM/yyyy", CultureInfo.CurrentUICulture.DateTimeFormat);

            UnidadeOrganizacional data = DbSet.Where(x => x.Id_Unidade_Organizacional.Equals(input.Id_Unidade_Organizacional)).AsQueryable().FirstOrDefault();

            data.Id_Usuario                                     = input.Id_Usuario;
            data.Id_Unidade_Organizacional_Orgao                = input.Id_Unidade_Organizacional_Orgao;
            data.Id_Unidade_Organizacional_Responsabilidade     = input.Id_Unidade_Organizacional_Responsabilidade; 
            data.Unidade_Organizacional_Nome                    = input.Unidade_Organizacional_Nome;
            data.Unidade_Organizacional_Descricao               = input.Unidade_Organizacional_Descricao; 
            data.Data_Inicio                                    = Data_Inicio;
            data.Data_Fim                                       = Data_Fim; 
            data.Fl_Temporaria                                  = input.Fl_Temporaria;
            data.Fl_Ativo                                       = input.Fl_Ativo;

            _context.Update(data);
            _context.SaveChanges();

            return data.Id_Unidade_Organizacional;
        }
        public bool Remove(long id)
        {
            UnidadeOrganizacional data = DbSet.Where(x => x.Id_Unidade_Organizacional.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }


    }
}
