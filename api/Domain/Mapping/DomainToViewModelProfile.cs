
using api.Domain.Models.Message;
using api.Domain.Models.Usuario;
using api.Domain.Views.Output.Usuario;
using api.Domain.Views.Output.Message;
using AutoMapper;

namespace api.Domain.Mapping
{
    public class DomainToViewModelProfile : Profile
    {
        public DomainToViewModelProfile()
        {

            #region Usuarios

            CreateMap<Usuarios, UsuariosOutput>()
                .ForMember(f => f.Id_Usuario, t => t.MapFrom(m => m.Id_Usuario))
                .ForMember(f => f.Id_Cliente, t => t.MapFrom(m => m.Id_Cliente))

                .ForMember(f => f.Usuario_Nome, t => t.MapFrom(m => m.Usuario_Nome))
                .ForMember(f => f.Usuario_Sobrenome, t => t.MapFrom(m => m.Usuario_Sobrenome))
                .ForMember(f => f.Usuario_Email, t => t.MapFrom(m => m.Usuario_Email))
                .ForMember(f => f.Usuario_Senha, t => t.MapFrom(m => m.Usuario_Senha))
                .ForMember(f => f.Usuario_Avatar, t => t.MapFrom(m => m.Usuario_Avatar))
                .ForMember(f => f.Fl_Ativo, t => t.MapFrom(m => m.Fl_Ativo))

                ;

            #endregion

            #region Chat

            CreateMap<Chat, ChatOutput>()
                .ForMember(f => f.Id_Chat, t => t.MapFrom(m => m.Id_Chat))
                .ForMember(f => f.Id_Usuario, t => t.MapFrom(m => m.Id_Usuario))
                .ForMember(f => f.Id_Bot, t => t.MapFrom(m => m.Id_Bot))
                .ForMember(f => f.Mensagem, t => t.MapFrom(m => m.Mensagem))
                .ForMember(f => f.Fl_Bot, t => t.MapFrom(m => m.Fl_Bot))
                .ForMember(f => f.Data_Hora, t => t.MapFrom(m => m.Data_Hora)) 
                .ForMember(f => f.Fl_Ativo, t => t.MapFrom(m => m.Fl_Ativo))
                ;

            CreateMap<Bot, BotOutput>()
                    .ForMember(f => f.Id_Bot,           t => t.MapFrom(m => m.Id_Bot))
                    .ForMember(f => f.Id_Status,        t => t.MapFrom(m => m.Id_Status))
                    .ForMember(f => f.Api,              t => t.MapFrom(m => m.Api))
                    .ForMember(f => f.Bot_Nome,         t => t.MapFrom(m => m.Bot_Nome))
                    .ForMember(f => f.Bot_Descricao,    t => t.MapFrom(m => m.Bot_Descricao))
                    .ForMember(f => f.Icone,            t => t.MapFrom(m => m.Icone))
                    .ForMember(f => f.Fl_Ativo,         t => t.MapFrom(m => m.Fl_Ativo))
                     .ForMember(f => f.Key_Vonage_Voice, t => t.MapFrom(m => m.Key_Vonage_Voice))

                    .ForMember(f => f.BotStatus, t => t.MapFrom(m => m.BotStatus)) /* inner */
                    ;

            CreateMap<BotStatus, BotStatusOutput>()
                    .ForMember(f => f.Id_Bot_Status, t => t.MapFrom(m => m.Id_Bot_Status))
                    .ForMember(f => f.Bot_Status_Nome, t => t.MapFrom(m => m.Bot_Status_Nome)) 
                    ;

            #endregion


        }
    }
}
