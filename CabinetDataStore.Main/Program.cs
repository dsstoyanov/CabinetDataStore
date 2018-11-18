using CabinetDataStore.Business.Abstraction;
using CabinetDataStore.Main.AppStart;
using Ninject;
using System;
using System.Collections.Generic;
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
            AutoMapperConfig.Register();

            IKernel kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());

            IPatient patients = kernel.Get<IPatient>();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(patients));
        }
    }
}
