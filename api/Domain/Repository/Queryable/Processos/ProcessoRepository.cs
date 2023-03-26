using api.Domain.Models.Processos;
using api.Domain.Repository.Interface.Processos;
using api.Domain.Views.Input.Processos;
using System.Linq;

namespace api.Domain.Repository.Queryable.Processos
{
    public class ProcessoRepository : Repository<Processo, decimal>, IProcessoRepository
    {
        private readonly GRCContext _context;
        public ProcessoRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Processo> GetAll(bool active)
        {
            var data = DbSet.Where(x => x.Fl_Ativo.Equals(active)).AsQueryable();

            return data;
        }
        public IQueryable<Processo> GetByProcessoByNivel(long idNivel)
        {
            var data = DbSet.Where(x => x.Id_Processo_Nivel.Equals(idNivel) && x.Fl_Ativo.Equals(true)).AsQueryable();

            return data;
        }

        public IQueryable<Processo> GetByProcessoByMinorNivel(long idNivel)
        {
            var data = DbSet.Where(x => x.Fl_Ativo.Equals(true)
                                     //&& x.Id_Processo_Nivel < idNivel
            ).AsQueryable();

            return data;
        }


        public bool UpdateStatus(long id)
        {
            Processo data = DbSet.Where(x => x.Id_Processo.Equals(id)).AsQueryable().FirstOrDefault();
            data.Fl_Ativo = data.Fl_Ativo == true ? false : true;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public long Create(ProcessoInput input)
        {
            try
            {
                Processo data = new Processo
                { 
                    Id_Processo_Nivel  = input.Id_Processo_Nivel,
                    Processo_Nome      = input.Processo_Nome,
                    Processo_Descricao = input.Processo_Descricao,
                    Fl_Ativo           = true
                };

                _context.Add(data);
                _context.SaveChanges();

                return data.Id_Processo;
            }
            catch (System.Exception )
            { 
                return 0;
            } 
           
        }

        public bool Update(ProcessoInput input)
        {

            try
            {
                Processo data = DbSet.Where(x => x.Id_Processo.Equals((long)input.Id_Processo)).AsQueryable().FirstOrDefault();

                data.Id_Processo_Nivel = input.Id_Processo_Nivel;
                data.Processo_Nome = input.Processo_Nome;
                data.Processo_Descricao = input.Processo_Descricao;

                _context.Update(data);
                _context.SaveChanges();

                return true;
            }
            catch (System.Exception )
            {
                return false;
            }

        }
        public bool Remove(long id)
        {
            Processo data = DbSet.Where(x => x.Id_Processo.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }


    }
}
