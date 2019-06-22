using AutoMapper;
using System.Linq;
using PR.Entities;
using PR.EntitiesDTO;

namespace PR.Bootstrap.Automapper
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            #region MapSettings
            CreateMap<Report, ReportDTO>().ReverseMap();

            #endregion
        }
    }
}
