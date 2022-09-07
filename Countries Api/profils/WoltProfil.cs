using AutoMapper;
using Countries_Api.Dtos.categorydto;
using Countries_Api.Models;

namespace Countries_Api.profils
{
    public class WoltProfil:Profile
    {
        public WoltProfil()
        {
            CreateMap<category, categorygetdto>();
            CreateMap<categorycreatedto, category>();

        }
    }
}