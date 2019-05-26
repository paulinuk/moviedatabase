namespace MovieDatabase.Common.Mappings
{
    using AutoMapper;

    public interface IMappingInitializer
    {
        void Initialize(IMapperConfigurationExpression mappingConfig);
    }
}