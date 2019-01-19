using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vidly.dtos;
using vidly.Models;

namespace vidly.App_Start
{
    public class mappingprofile:Profile
    {
        public mappingprofile()
        {
            Mapper.CreateMap<customer, customerdto>();
            Mapper.CreateMap<customerdto, customer>();
            Mapper.CreateMap<movie, moviedto>();
            Mapper.CreateMap<moviedto, movie>();
            Mapper.CreateMap<membershiptype, membershiptypesdto>();
            Mapper.CreateMap<genra, genradto>();
            //CreateMap<movie, moviedto>().ForMember(m => m.id, opt => opt.Ignore());
            //CreateMap<customer, customerdto>().ForMember(c => c.id, opt => opt.Ignore());

        }
    }
}