using api.Domain.Models.Templates.Emails;
using api.Domain.Views.Input.Templates.Emails;
using System.Linq;

namespace api.Domain.Repository.Interface.Templates.Emails
{
    public interface ITemplateEmailRepository : IRepository<TemplateEmail, decimal>
    {
        IQueryable<TemplateEmail> GetAny(bool active);
        IQueryable<TemplateEmail> GetByTela(long id);

        bool UpdateStatus(long id);

        bool Create(TemplateEmailInput input);
        bool Update(TemplateEmailInput input);
 
        bool Remove(long id);

    }
}
