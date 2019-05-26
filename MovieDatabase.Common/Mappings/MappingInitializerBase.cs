namespace MovieDatabase.Common.Mappings
{
    using AutoMapper;

    public abstract class MappingInitializerBase : IMappingInitializer
    {
        public abstract void Initialize(IMapperConfigurationExpression mappingConfig);
    }
}