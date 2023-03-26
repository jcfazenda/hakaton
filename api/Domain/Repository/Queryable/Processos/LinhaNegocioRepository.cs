using api.Domain.Models.Processos;
using api.Domain.Repository.Interface.Processos;
using api.Domain.Views.Input.Processos;
using System.Linq;

namespace api.Domain.Repository.Queryable.Processos
{
    public class LinhaNegocioRepository : Repository<LinhaNegocio, decimal>, ILinhaNegocioRepository
    {
        private readonly GRCContext _context;
        public LinhaNegocioRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<LinhaNegocio> GetAll(bool active)
        {
            var data = DbSet.Where(x => x.Fl_Ativo.Equals(active)).AsQueryable();

            return data;
        }
        public bool UpdateStatus(long id)
        {
            LinhaNegocio data = DbSet.Where(x => x.Id_Linha_Negocio.Equals(id)).AsQueryable().FirstOrDefault();
            data.Fl_Ativo = data.Fl_Ativo == true ? false : true;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public long Create(LinhaNegocioInput input)
        {
            LinhaNegocio data = new LinhaNegocio
            { 
                Linha_Negocio_Nome      = input.Linha_Negocio_Nome,
                Linha_Negocio_Descricao = input.Linha_Negocio_Descricao,
                Fl_Ativo                = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return data.Id_Linha_Negocio;
        }

        public bool Update(LinhaNegocioInput input)
        {
            LinhaNegocio data = DbSet.Where(x => x.Id_Linha_Negocio.Equals(input.Id_Linha_Negocio)).AsQueryable().FirstOrDefault();
             
            data.Linha_Negocio_Nome      = input.Linha_Negocio_Nome;
            data.Linha_Negocio_Descricao = input.Linha_Negocio_Descricao;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }
        public bool Remove(long id)
        {
            LinhaNegocio data = DbSet.Where(x => x.Id_Linha_Negocio.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }


    }
}
