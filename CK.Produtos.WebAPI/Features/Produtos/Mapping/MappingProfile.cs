using AutoMapper;
using Octoplex.Impostos.Domain.Impostos;
using Octoplex.Produtos.Domain.Produtos;
using Octoplex.Produtos.Domain.Produtos.DTO;

namespace Octoplex.Produtos.WebAPI.Features.Produtos.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Produto, ProdutosDTO>()
                .ForMember(dest => dest.Codigo, map =>
                map.MapFrom(src => src.Codigo))
                .ForMember(dest => dest.Descricao, map =>
                map.MapFrom(src => src.Descricao))
                .ForMember(dest => dest.Un, map =>
                map.MapFrom(src => src.Un))
                .ForMember(dest => dest.Vrvista, map =>
                map.MapFrom(src => src.Vrvista))
                .ForMember(dest => dest.Estq, map =>
                map.MapFrom(src => src.Estq))
                .ReverseMap(); //MAPEIA DOS DOIS LADOS

            CreateMap<Imposto, ImpostosDTO>()
                .ReverseMap();
        }
    }
}
