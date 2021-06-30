using AutoMapper;
using Prova.App.ViewModels;
using Prova.Bussiness.Models;

namespace Prova.App.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Pedido, PedidoViewModel>().ReverseMap();
        }
    }
}