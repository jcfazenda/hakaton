using api.Domain.Models.WorkFlow;
using api.Domain.Repository.Interface.WorkFlow;
using api.Domain.Views.Input.WorkFlow;
using System;
using System.Linq;

namespace api.Domain.Repository.Queryable.WorkFlow
{
    public class WorkFlowStatusRepository : Repository<WorkFlowStatus, decimal>, IWorkFlowStatusRepository
    {
        private readonly GRCContext _context;
        public WorkFlowStatusRepository(GRCContext context) : base(context)
        {
            _context = context;
        }
 
        public IQueryable<WorkFlowStatus> GetAny(bool active)
        {
            var data = DbSet.Where(x => x.Fl_Ativo.Equals(active)).AsQueryable();

            return data;
        }
        public bool UpdateStatus(long id)
        {
            WorkFlowStatus data = DbSet.Where(x => x.Id_Workflow_Status.Equals(id)).AsQueryable().FirstOrDefault();
            data.Fl_Ativo = data.Fl_Ativo == true ? false : true;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public bool Create(WorkFlowStatusInput input)
        {
            WorkFlowStatus data = new WorkFlowStatus
            {
                Workflow_Status_Nome = input.Workflow_Status_Nome, 
                Fl_Ativo = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return true;
        }

        public bool Update(WorkFlowStatusInput input)
        {
            WorkFlowStatus data = DbSet.Where(x => x.Id_Workflow_Status.Equals(input.Id_Workflow_Status)).AsQueryable().FirstOrDefault();

            data.Workflow_Status_Nome = input.Workflow_Status_Nome; 

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }
        public bool Remove(long id)
        {
            WorkFlowStatus data = DbSet.Where(x => x.Id_Workflow_Status.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }


    }
}
