using CabinetDataStore.Business.Abstraction;
using CabinetDataStore.Business.Services;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabinetDataStore.Main.AppStart
{
    public class CabinetDataStoreDependancyResolver : NinjectModule
    {
        public override void Load()
        {
            Bind<IPatient>().To<PatientService>();
            Bind<IExamination>().To<ExaminationService>();
        }
    }
}
