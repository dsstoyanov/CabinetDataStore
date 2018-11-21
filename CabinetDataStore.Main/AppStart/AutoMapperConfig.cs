using AutoMapper;
using CabinetDataStore.Business;
using CabinetDataStore.BusinessService.PatientModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabinetDataStore.Main.AppStart
{
    public class AutoMapperConfig
    {
        public static void Register()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<PatientsProfile>();
            });
        }

        public class PatientsProfile : Profile
        {
            public PatientsProfile()
            {
                CreateMap<PatientData, PatientModel>()
                    .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDay))
                    .ForMember(dest => dest.EmailAddress, opt => opt.MapFrom(src => src.email));
            }
        }
    }
}
