using api.Domain.Models.Empresas;
using api.Domain.Repository.Interface.Empresas;
using api.Domain.Views.Input.Empresas;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace api.Domain.Repository.Queryable.Empresas
{
    public class EmpresaRepository : Repository<Empresa, decimal>, IEmpresaRepository
    {
        private readonly GRCContext _context;
        public EmpresaRepository(GRCContext context) : base(context)
        {
            _context = context;
        } 

        public IQueryable<Empresa> GetAll(bool active)
        {
            var data = DbSet.Include(i => i.EmpresaEndereco).Where(x => x.Fl_Ativo.Equals(active)).AsQueryable();

            return data;
        }


        public bool UpdateStatus(long id)
        {
            Empresa data = DbSet.Where(x => x.Id_Empresa.Equals(id)).AsQueryable().FirstOrDefault();
            data.Fl_Ativo = data.Fl_Ativo == true ? false : true;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public long Create(EmpresaInput input)
        {
            DateTime Data_Operacao = DateTime.ParseExact(input.Data_Operacao.ToString(), "dd/MM/yyyy", CultureInfo.CurrentUICulture.DateTimeFormat);

            Empresa data = new Empresa
            {
                Id_Empresa_Classificacao    = input.Id_Empresa_Classificacao,
                Id_Orgao_Regulador          = input.Id_Orgao_Regulador,
                Id_Empresa_Endereco        = input.Id_Empresa_Endereco,  
                Empresa_Nome                = input.Empresa_Nome,
                Empresa_Descricao           = input.Empresa_Descricao,
                Empresa_Cnpj                = input.Empresa_Cnpj,
                Data_Operacao               = Data_Operacao,

                Fl_Empresa_Ativa            = input.Fl_Empresa_Ativa?? false,
                Fl_Ativo                    = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return data.Id_Empresa;
        }
        public bool UpdateIdEndereco(long idEmpresa, long idEmdereco)
        {
            Empresa data = DbSet.Where(x => x.Id_Empresa.Equals(idEmpresa)).AsQueryable().FirstOrDefault();
            data.Id_Empresa_Endereco = idEmdereco;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }
        public bool Update(EmpresaInput input)
        {
            DateTime Data_Operacao = DateTime.ParseExact(input.Data_Operacao.ToString(), "dd/MM/yyyy", CultureInfo.CurrentUICulture.DateTimeFormat);

            Empresa data = DbSet.Where(x => x.Id_Empresa.Equals(input.Id_Empresa)).AsQueryable().FirstOrDefault();

            data.Id_Empresa_Classificacao   = input.Id_Empresa_Classificacao;
            data.Id_Orgao_Regulador         = input.Id_Orgao_Regulador;
            data.Id_Empresa_Endereco        = input.Id_Empresa_Endereco;
            data.Empresa_Nome               = input.Empresa_Nome;
            data.Empresa_Descricao          = input.Empresa_Descricao;
            data.Empresa_Cnpj               = input.Empresa_Cnpj;
            data.Data_Operacao              = Data_Operacao;

            data.Fl_Empresa_Ativa           = input.Fl_Empresa_Ativa;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }
        public bool Remove(long id)
        {
            Empresa data = DbSet.Where(x => x.Id_Empresa.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }


    }
}
