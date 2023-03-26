using api.Domain.Models.PlanosAcao;
using api.Domain.Repository.Interface.PlanosAcao;
using api.Domain.Views.Input.PlanosAcao;
using System;
using System.Linq;

namespace api.Domain.Repository.Queryable.PlanosAcao
{
    public class StepStatusRepository : Repository<StepStatus, decimal>, IStepStatusRepository
    {
        private readonly GRCContext _context;
        public StepStatusRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<StepStatus> GetAll(bool active)
        {
            var data = DbSet.Where(x => x.Fl_Ativo.Equals(active)).AsQueryable();

            return data;
        }
        public bool UpdateStatus(long id)
        {
            StepStatus data = DbSet.Where(x => x.Id_Step_Status.Equals(id)).AsQueryable().FirstOrDefault();
            data.Fl_Ativo = data.Fl_Ativo == true ? false : true;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public bool Create(StepStatusInput input)
        {
            StepStatus data = new StepStatus
            {
                Step_Status_Nome = input.Step_Status_Nome,
                Icon             = input.Icon,
                Fl_Ativo = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return true;
        }

        public bool Update(StepStatusInput input)
        {
            StepStatus data = DbSet.Where(x => x.Id_Step_Status.Equals(input.Id_Step_Status)).AsQueryable().FirstOrDefault();

            data.Step_Status_Nome = input.Step_Status_Nome;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }


        public bool Remove(long id)
        {
            StepStatus data = DbSet.Where(x => x.Id_Step_Status.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }


    }
}
