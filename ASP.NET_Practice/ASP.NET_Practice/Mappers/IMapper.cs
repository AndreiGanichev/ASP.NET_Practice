using System;

namespace ASP.NET_Practice.Mappers
{
    public interface IMapper
    {
        object Map(object source, Type sourceType, Type targetType);
    }
}
