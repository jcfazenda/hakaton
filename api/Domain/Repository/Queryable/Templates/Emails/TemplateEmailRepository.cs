using api.Domain.Models.Templates.Emails;
using api.Domain.Repository.Interface.Templates.Emails;
using api.Domain.Views.Input.Templates.Emails;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace api.Domain.Repository.Queryable.Templates.Emails
{
    public class TemplateEmailRepository : Repository<TemplateEmail, decimal>, ITemplateEmailRepository
    {
        private readonly GRCContext _context;
        public TemplateEmailRepository(GRCContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<TemplateEmail> GetByTela(long id)
        {
            var data = DbSet.Include(i => i.Tela)
                            .Include(i => i.TelaFuncao)
                            .Where(x => x.Id_Tela.Equals(id)).AsQueryable();

            return data;
        }
        public IQueryable<TemplateEmail> GetAny(bool active)
        {
            var data = DbSet.Include(i => i.Tela)
                            .Include(i => i.TelaFuncao)
                            .Where(x => x.Fl_Ativo.Equals(active)).AsQueryable();

            return data;
        }


        public bool UpdateStatus(long id)
        {
            TemplateEmail data = DbSet.Where(x => x.Id_Template_Email.Equals(id)).AsQueryable().FirstOrDefault();
            data.Fl_Ativo = data.Fl_Ativo == true ? false : true;

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }

        public bool Create(TemplateEmailInput input)
        {
            TemplateEmail data = new TemplateEmail
            {
                Id_Tela = input.Id_Tela,
                Id_Tela_Funcao = input.Id_Tela_Funcao,
                Evento = input.Evento, 
                Texto = input.Texto,
                Link_Button = input.Link_Button,  
                Fl_Ativo = true
            };

            _context.Add(data);
            _context.SaveChanges();

            return true;
        }

        public bool Update(TemplateEmailInput input)
        {
            TemplateEmail data = DbSet.Where(x => x.Id_Template_Email.Equals(input.Id_Template_Email)).AsQueryable().FirstOrDefault();

            data.Id_Tela = input.Id_Tela;
            data.Id_Tela_Funcao = input.Id_Tela_Funcao;
            data.Evento = input.Evento; 
            data.Texto = input.Texto;
            data.Link_Button = input.Link_Button; 

            _context.Update(data);
            _context.SaveChanges();

            return true;
        }
 
        public bool Remove(long id)
        {
            TemplateEmail data = DbSet.Where(x => x.Id_Template_Email.Equals(id)).AsQueryable().FirstOrDefault();

            _context.Remove(data);
            _context.SaveChanges();

            return true;
        }


    }
}
