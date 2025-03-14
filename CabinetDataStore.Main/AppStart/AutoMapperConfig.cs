using AutoMapper;
using CabinetDataStore.Business;
using CabinetDataStore.Business.Models;
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
                cfg.AddProfile<ExaminationsProfile>();
            });
        }

        public class PatientsProfile : Profile
        {
            public PatientsProfile()
            {
                CreateMap<PatientsData, PatientModel>()
                    .ForMember(dest=>dest.PhoneNumber, opt=>opt.MapFrom(src=>src.PhoneNumber))
                    .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDay))
                    .ForMember(dest => dest.EmailAddress, opt => opt.MapFrom(src => src.email))
                    .ForMember(dest => dest.Examinations, opt => opt.MapFrom(src => src.Examinations));

               CreateMap<PatientModel, PatientsData>()
                    .ForMember(dest=>dest.PatientName, opt=>opt.MapFrom(src=>src.PatientName))
                    .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                    .ForMember(dest => dest.BirthDay, opt => opt.MapFrom(src => src.BirthDate))
                    .ForMember(dest => dest.email, opt => opt.MapFrom(src => src.EmailAddress))
                    .ForMember(dest => dest.Examinations, opt => opt.MapFrom(src => src.Examinations));
            }
           
        }

        public class ExaminationsProfile : Profile
        {
            public ExaminationsProfile()
            {
                CreateMap<ExaminationsData, ExaminationModel>()
                   .ForMember(dest => dest.ExaminationID, opt => opt.MapFrom(src => src.ExaminationId))
                   .ForMember(dest => dest.PatientId, opt => opt.MapFrom(src => src.PatientId))
                   .ForMember(dest => dest.ExaminationDate, opt => opt.MapFrom(src => src.ExaminationDate))
                   .ForMember(dest => dest.PRM, opt => opt.MapFrom(src => src.PRM))
                   .ForMember(dest => dest.BirthsCount, opt => opt.MapFrom(src => src.Births))
                   .ForMember(dest => dest.Operations, opt => opt.MapFrom(src => src.Operations))
                   .ForMember(dest => dest.Pain, opt => opt.MapFrom(src => src.Pain))
                   .ForMember(dest => dest.Bleeding, opt => opt.MapFrom(src => src.Bleeding))
                   .ForMember(dest => dest.Fluorine, opt => opt.MapFrom(src => src.Fluorine))
                   .ForMember(dest => dest.Others, opt => opt.MapFrom(src => src.Others))
                   .ForMember(dest => dest.Colposcopy, opt => opt.MapFrom(src => src.Colposcopy))
                   .ForMember(dest => dest.Echography, opt => opt.MapFrom(src => src.Echography))
                   .ForMember(dest => dest.Results, opt => opt.MapFrom(src => src.Results))
                   .ForMember(dest => dest.Therapy, opt => opt.MapFrom(src => src.Therapy))
                   .ForMember(dest => dest.Recommendations, opt => opt.MapFrom(src => src.Recommendations))
                   .ForMember(dest => dest.Diagnosis, opt => opt.MapFrom(src => src.Diagnosis))
                   .ForMember(dest => dest.Photo, opt => opt.MapFrom(src => src.Picture));

                CreateMap<ExaminationModel, ExaminationsData>()
                   .ForMember(dest => dest.ExaminationId, opt => opt.Ignore())
                   .ForMember(dest => dest.PatientId, opt => opt.MapFrom(src => src.PatientId))
                   .ForMember(dest => dest.ExaminationDate, opt => opt.MapFrom(src => src.ExaminationDate))
                   .ForMember(dest => dest.PRM, opt => opt.MapFrom(src => src.PRM))
                   .ForMember(dest => dest.Births, opt => opt.MapFrom(src => src.BirthsCount))
                   .ForMember(dest => dest.Operations, opt => opt.MapFrom(src => src.Operations))
                   .ForMember(dest => dest.Pain, opt => opt.MapFrom(src => src.Pain))
                   .ForMember(dest => dest.Bleeding, opt => opt.MapFrom(src => src.Bleeding))
                   .ForMember(dest => dest.Fluorine, opt => opt.MapFrom(src => src.Fluorine))
                   .ForMember(dest => dest.Others, opt => opt.MapFrom(src => src.Others))
                   .ForMember(dest => dest.Colposcopy, opt => opt.MapFrom(src => src.Colposcopy))
                   .ForMember(dest => dest.Echography, opt => opt.MapFrom(src => src.Echography))
                   .ForMember(dest => dest.Results, opt => opt.MapFrom(src => src.Results))
                   .ForMember(dest => dest.Therapy, opt => opt.MapFrom(src => src.Therapy))
                   .ForMember(dest => dest.Recommendations, opt => opt.MapFrom(src => src.Recommendations))
                   .ForMember(dest => dest.Diagnosis, opt => opt.MapFrom(src => src.Diagnosis))
                   .ForMember(dest => dest.Picture, opt => opt.MapFrom(src => src.Photo));
            }
        }
    }
}
