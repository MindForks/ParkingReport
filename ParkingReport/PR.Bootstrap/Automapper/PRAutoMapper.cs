using AutoMapper;

namespace PR.Bootstrap.Automapper
{
    public class PRAutoMapper : PR.Interfaces.IMapper
    {
        private readonly IMapper mapper;

        public PRAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            cfg.AddProfile<AutomapperProfile>()
            );
            mapper = config.CreateMapper();
        }

        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return mapper.Map<TSource, TDestination>(source);
        }

        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            return mapper.Map<TSource, TDestination>(source, destination);
        }
    }
}
