
namespace MovieDatabase.Common.Mappings
{
    using AutoMapper;
    using MovieDatabase.Common.Models;
    public class MappingConfiguration : IMappingInitializer
    {

        public void Initialize(IMapperConfigurationExpression mappingConfig)
        {
            mappingConfig.CreateMap<Movie, SearchResponse>(MemberList.Source);            
        }
    }
}