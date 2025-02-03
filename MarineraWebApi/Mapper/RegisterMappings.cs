using Domain.Aggregates;
using Mapster;
using SharedEntities.DTOs;

namespace MarineraWebApi.Mapper;

public static class MapsterConfigs
{
    public static void RegisterMappings()
    {
        TypeAdapterConfig<ConcourseDto, Concourse>.NewConfig().ConstructUsing(src => new Concourse(src.Name, src.Date)).Map(dest => dest.Name, src => src.Name).Map(dest => dest.Date, src => src.Date);


    }
}