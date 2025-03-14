using CabinetDataStore.Business.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabinetDataStore.Business.CabinetDataStoreContext
{
    public partial class CabinetEntities : DbContext
    {
        public static string connString = ConfigurationManager.ConnectionStrings["CabinetContext"].ConnectionString;
        
        public CabinetEntities() : base(connString)
        {
        }
       
        public virtual DbSet<PatientsData> PatientsData { get; set; }
        public virtual DbSet<ExaminationsData> ExaminationsData { get; set; }
    }
}
