using AutoMapper;
using MandarinExpressionsAPI.Domain;
using MandarinExpressionsAPI.DTOs;

namespace MandarinExpressionsAPI.Mapping;

public class ExpressionProfile : Profile
{
    public ExpressionProfile()
    {
        CreateMap<Expression, ExpressionResponseDto>()
            .ForMember(
                dest => dest.Level,
                opt =>
                    opt.MapFrom(src => src.Level.ToString())
            );
        CreateMap<ExpressionRequestDto, Expression>()
            .ForMember(
                dest => dest.Id,
                opt => opt.Ignore()
            )
            .ForMember(
                dest => dest.Level,
                opt => opt.MapFrom(src => Enum.Parse<Level>(src.Level, true))
            );
    }
}