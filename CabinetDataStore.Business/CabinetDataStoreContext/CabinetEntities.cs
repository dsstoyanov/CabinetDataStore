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
        public CabinetEntities() : base("server=localhost;user id=postgres;password=1qaz!QAZ;database=AG_Kabinet")
        {
        }
       
        public virtual DbSet<PatientsData> PatientsData { get; set; }
        public virtual DbSet<ExaminationsData> ExaminationsData { get; set; }
    }
}
