using AutoMapper;
using FamilyTreeSystem.Models;

namespace FamilyTreeSystem.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Person, PersonVM>().ReverseMap();
            CreateMap<SiblingRelation, SiblingRelationVM>().ReverseMap();
            CreateMap<FamilyTree, FamilyTreeVM>().ReverseMap();
            CreateMap<MartialRelation, MartialRelationVM>().ReverseMap();
            CreateMap<Children, ChildrenVM>().ReverseMap();
        }

    }
}
