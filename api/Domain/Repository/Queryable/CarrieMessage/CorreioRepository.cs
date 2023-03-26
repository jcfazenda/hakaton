using api.Domain.Models.CarrieMessage;
using api.Domain.Repository.Interface.CarrieMessage;
using api.Domain.Views.Input.CarrieMessage;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace api.Domain.Repository.Queryable.CarrieMessage
{
    public class CorreioRepository : Repository<Correio, decimal>, ICorreioRepository
    {
        private readonly GRCContext _context;
        public CorreioRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Correio> GetAll(bool active)
        {
            var data = DbSet.Include(i => i.CorreioTipo).Where(x => x.Fl_Ativo.Equals(active)).AsQueryable();

            return data;
        }
        public IQueryable<Correio> GetByCorreio(long id)
        {
            var data = DbSet.Include(i => i.CorreioTipo).Where(x => x.Id_Correio.Equals(id)).AsQueryable();

            return data;
        }
        public IQueryable<Correio> GetByUsuarioReceive(long id, bool fl_Lido)
        {
            var data = DbSet.Include(i => i.CorreioTipo).Where(x => x.Id_Usuario_Receive.Equals(id) && 
                                                                    x.Fl_Lido.Equals(fl_Lido)).AsQueryable();

            return data;
        }
        
        public bool UpdateStatus(long id)
        {
            Correio data = DbSet.Where(x => x.Id_Correio.Equals(id)).AsQueryable().FirstOrDefault();
            data.Fl_Ativo = data.Fl_Ativo == true ? false : true;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public bool Create(CorreioInput input)
        {
            Correio data = new Correio
            {
                Id_Correio_Tipo     = input.Id_Correio_Tipo,
                Id_Usuario_Send     = input.Id_Usuario_Send,
                Id_Usuario_Receive  = input.Id_Usuario_Receive,
                Correio_Data        = DateTime.Now,
                Mensagem            = input.Mensagem,
                Mensagem_Titulo = input.Mensagem_Titulo,
                Fl_Lido             = input.Fl_Lido,

                Fl_Ativo = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return true;
        }

        public bool Update(CorreioInput input)
        {
            Correio data = DbSet.Where(x => x.Id_Correio.Equals(input.Id_Correio)).AsQueryable().FirstOrDefault();

             

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }
        public bool UpdateLido(long id)
        {
            Correio data = DbSet.Where(x => x.Id_Correio.Equals(id)).AsQueryable().FirstOrDefault();

            data.Fl_Lido = true;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }
 
        public bool Remove(long id)
        {
            Correio data = DbSet.Where(x => x.Id_Correio.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }


    }
}
