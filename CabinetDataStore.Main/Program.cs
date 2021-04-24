using CabinetDataStore.Business.Abstraction;
using CabinetDataStore.Business.CabinetDataStoreContext;
using CabinetDataStore.Main.AppStart;
using Ninject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CabinetDataStore.Main
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var asd = ConfigurationManager.ConnectionStrings["CabinetContext"].ConnectionString;
            AutoMapperConfig.Register();

            IKernel kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());

            IPatient patients = kernel.Get<IPatient>();
            IExamination examinations = kernel.Get<IExamination>();

           
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new PatientForm(patients, examinations));
        }
    }
}
