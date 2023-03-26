using api.Domain.Models.Indice;
using api.Domain.Repository.Interface.Indice;
using api.Domain.Views.Input.Indice;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace api.Domain.Repository.Queryable.Indice
{
    public class MatrizItemRepository : Repository<MatrizItem, decimal>, IMatrizItemRepository
    {
        private readonly GRCContext _context;
        public MatrizItemRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<MatrizItem> GetAll(bool active)
        {
            var data = DbSet.Where(x => x.Fl_Ativo.Equals(active)).AsQueryable();

            return data;
        }
 
        public IQueryable<MatrizItem> GetByMatriz(long id)
        {
            var data = DbSet.Include(o => o.Matriz).Where(x => x.Id_Matriz.Equals(id)).AsQueryable();

            return data;
        }

        public bool UpdateStatus(long id)
        {
            MatrizItem data = DbSet.Where(x => x.Id_Matriz_Item.Equals(id)).AsQueryable().FirstOrDefault();
            data.Fl_Ativo = data.Fl_Ativo == true ? false : true;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public long Create(MatrizItemInput input)
        {

            try
            {
                MatrizItem data = new MatrizItem
                {
                    Id_Matriz               = input.Id_Matriz,
                    Matriz_Item_Nome        = input.Matriz_Item_Nome,
                    Matriz_Item_Descricao   = input.Matriz_Item_Descricao,
                    Tipo                    = input.Tipo,
                    Percentual              = Convert.ToDouble(input.Percentual), 

                    Fl_Ativo = true
                };

                _context.Add(data);
                _context.SaveChanges();

                return data.Id_Matriz_Item;
            }
            catch (Exception )
            {

                return 0;
            }

        }

        public bool Update(MatrizItemInput input)
        {
            MatrizItem data = DbSet.Where(x => x.Id_Matriz_Item.Equals(input.Id_Matriz_Item)).AsQueryable().FirstOrDefault();

            data.Matriz_Item_Nome       = input.Matriz_Item_Nome;
            data.Matriz_Item_Descricao  = input.Matriz_Item_Descricao; 
            data.Percentual             = Convert.ToDouble(input.Percentual);

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }
         

        public bool Remove(long id)
        {
            MatrizItem data = DbSet.Where(x => x.Id_Matriz_Item.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }
        public bool RemoveByMatriz(long id)
        {
            List<MatrizItem> data = DbSet.Where(x => x.Id_Matriz.Equals(id)).AsQueryable().ToList();

            foreach (var item in data)
            {
                _context.Remove(item);
                _context.SaveChanges();
            }



            return true;
        }

    }
}
