using api.Domain.Models.Indice;
using api.Domain.Repository.Interface.Indice;
using api.Domain.Views.Input.Indice;
using System.Collections.Generic;
using System.Linq;

namespace api.Domain.Repository.Queryable.Indice
{
    public class MatrizItemCorRepository : Repository<MatrizItemCor, decimal>, IMatrizItemCorRepository
    {
        private readonly GRCContext _context;
        public MatrizItemCorRepository(GRCContext context) : base(context)
        {
            _context = context;
        }
 
        public IQueryable<MatrizItemCor> GetByMatrizItem(long id)
        {
            var data = DbSet.Where(x => x.Id_Matriz_Item.Equals(id)).AsQueryable();

            return data;
        }
        public IQueryable<MatrizItemCor> GetByMatriz(long id)
        {
            var data = DbSet.Where(x => x.Id_Matriz.Equals(id)).AsQueryable();

            return data;
        }

        public IQueryable<MatrizItemCor> GetExist(MatrizItemCorInput input)
        {
            var data = DbSet.Where(x => x.Id_Matriz_Item.Equals(input.Id_Matriz_Item)
                                     && x.Linha.Equals(input.Linha)
                                     && x.Coluna.Equals(input.Coluna)).AsQueryable();

            return data;
        }

        public bool Create(MatrizItemCorInput input)
        {
            MatrizItemCor data = new MatrizItemCor
            {
                Id_Matriz_Item  = input.Id_Matriz_Item,
                Id_Matriz       = input.Id_Matriz,
                Background      = input.Background,
                Linha           = input.Linha,
                Coluna          = input.Coluna 
            };

            _context.Add(data);
            _context.SaveChanges();

            return true;
        }

        public bool UpdateBackground(MatrizItemCorInput input)
        {
            MatrizItemCor data = DbSet.Where(x =>  x.Id_Matriz_Item_Cor.Equals(input.Id_Matriz_Item_Cor)).AsQueryable().FirstOrDefault();

            data.Background = input.Background;
            //data.Linha      = input.Linha;
            //data.Coluna     = input.Coluna;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }



        public bool Remove(long id)
        {
            MatrizItemCor data = DbSet.Where(x => x.Id_Matriz_Item_Cor.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }
        public bool RemoveByMatrizItem(long id)
        {
            List<MatrizItemCor> data = DbSet.Where(x => x.Id_Matriz_Item.Equals(id)).AsQueryable().ToList();

            foreach (var item in data)
            {
                _context.Remove(item);
                _context.SaveChanges();
            }



            return true;
        }

    }
}
