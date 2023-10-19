﻿using data = Solution.DO.Objects;
using AutoMapper;

namespace Solution.API.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile() {

            CreateMap<data.GroupUpdate, DataModels.GroupUpdate>().ReverseMap();
            CreateMap<data.GroupComment, DataModels.GroupComment>().ReverseMap();
        } 

    }
}
