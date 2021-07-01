using AutoMapper;

namespace Test.Application.Common.Mappings
{
    public interface IMapFrom<T>
    {   
        void Mapping(Profile profile);
        //void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}
