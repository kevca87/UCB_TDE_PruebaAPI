using AutoMapper;
using Iter0_Backend.Data.Entities;
using Iter0_Backend.Models;

namespace Iter0_Backend.Data
{
    public class AutomapperProfile: Profile
    {
        public AutomapperProfile()
        {
            this.CreateMap<KidEntity, KidModel>()
                .ReverseMap();
        }
    }
}
