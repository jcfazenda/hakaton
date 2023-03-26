using api.Domain.Models.Empresas;
using api.Domain.Repository.Interface.Empresas;
using api.Domain.Views.Input.Empresas;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace api.Domain.Repository.Queryable.Empresas
{
    public class EmpresaAcaoSocietariaItemRepository : Repository<EmpresaAcaoSocietariaItem, decimal>, IEmpresaAcaoSocietariaItemRepository
    {
        private readonly GRCContext _context;
        public EmpresaAcaoSocietariaItemRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<EmpresaAcaoSocietariaItem> GetAny(bool Active)
        {
            var data = DbSet.Where(x => x.Fl_Ativo.Equals(Active)).AsQueryable();

            return data;
        }

        public long Create(EmpresaAcaoSocietariaItemInput input)
        {
            EmpresaAcaoSocietariaItem data = new EmpresaAcaoSocietariaItem
            {
                Empresa_Acao_Societaria_Item_Nome = input.Empresa_Acao_Societaria_Item_Nome,
                Fl_Ativo = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return data.Id_Empresa_Acao_Societaria_Item;
        }

        public bool Update(EmpresaAcaoSocietariaItemInput input)
        {
            EmpresaAcaoSocietariaItem data = DbSet.Where(x => x.Id_Empresa_Acao_Societaria_Item.Equals(input.Id_Empresa_Acao_Societaria_Item)).AsQueryable().FirstOrDefault();
            data.Empresa_Acao_Societaria_Item_Nome = input.Empresa_Acao_Societaria_Item_Nome;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }


        public bool Remove(long id)
        {
            EmpresaAcaoSocietariaItem data = DbSet.Where(x => x.Id_Empresa_Acao_Societaria_Item.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }


    }
}
