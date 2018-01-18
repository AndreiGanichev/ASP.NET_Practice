using ASP.NET_Practice.DataAccess.SingleEntityRepo.Models;
using ASP.NET_Practice.Models;
using AutoMapper;
using System;

namespace ASP.NET_Practice.Mappers
{
    public class CommonMapper : IMapper
    {
        public static void Configurate()
        {
            AutoMapper.Mapper.Initialize(
                cfg =>
                {
                    cfg.CreateMap<User, UserView>()
                        .ForMember(tgt => tgt.BirthDay, opt => opt.MapFrom(src => src.BirthDate.Day))
                        .ForMember(tgt => tgt.BirthMonth, opt => opt.MapFrom(src => src.BirthDate.Month))
                        .ForMember(tgt => tgt.BirthYear, opt => opt.MapFrom(src => src.BirthDate.Year));
                    cfg.CreateMap<UserView, User>()
                        .ForMember(tgt => tgt.BirthDate, opt => opt.MapFrom(src => new DateTime(src.BirthYear, src.BirthMonth, src.BirthDay)));
                });
        }

        public object Map(object source, Type sourceType, Type targetType)
        {
            return Mapper.Map(source, sourceType, targetType);
        }
    }
}