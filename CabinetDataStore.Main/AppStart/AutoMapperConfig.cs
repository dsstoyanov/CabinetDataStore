using AutoMapper;
using CabinetDataStore.Business;
using CabinetDataStore.BusinessService.ExaminationModels;
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
                    .ForMember(dest => dest.EmailAddress, opt => opt.MapFrom(src => src.email))
                    .ForMember(dest => dest.Examinations, opt => opt.MapFrom(src => src.PregledDatas));

                CreateMap<PregledData, ExaminationModel>()
                    .ForMember(dest => dest.ExaminationID, opt => opt.MapFrom(src => src.PregledId))
                    .ForMember(dest => dest.PatientId, opt => opt.MapFrom(src => src.PatientId))
                    .ForMember(dest => dest.ExaminationDate, opt => opt.MapFrom(src => src.PregledDate))
                    .ForMember(dest => dest.PRM, opt => opt.MapFrom(src => src.PRM))
                    .ForMember(dest => dest.BirthsCount, opt => opt.MapFrom(src => src.Rajdaniq))
                    .ForMember(dest => dest.Operations, opt => opt.MapFrom(src => src.Operacii))
                    .ForMember(dest => dest.Pain, opt => opt.MapFrom(src => src.Bolka))
                    .ForMember(dest => dest.Bleeding, opt => opt.MapFrom(src => src.Kurvene))
                    .ForMember(dest => dest.Fluorine, opt => opt.MapFrom(src => src.Fluor))
                    .ForMember(dest => dest.Others, opt => opt.MapFrom(src => src.Drugi))
                    .ForMember(dest => dest.Colposcopy, opt => opt.MapFrom(src => src.Kolposkopiq))
                    .ForMember(dest => dest.Echography, opt => opt.MapFrom(src => src.Ehografiq))
                    .ForMember(dest => dest.Results, opt => opt.MapFrom(src => src.Rezultati))
                    .ForMember(dest => dest.Therapy, opt => opt.MapFrom(src => src.Terapiq))
                    .ForMember(dest => dest.Recommendations, opt => opt.MapFrom(src => src.Preporuki))
                    .ForMember(dest => dest.Diagnosis, opt => opt.MapFrom(src => src.Diagnoza))
                    .ForMember(dest => dest.Photo, opt => opt.MapFrom(src => src.Snimka));
            }
        }
    }
}
