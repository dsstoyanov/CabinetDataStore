//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CabinetDataStore.Business
{
    using System;
    using System.Collections.Generic;
    
    public partial class PatientData
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PatientData()
        {
            this.PregledDatas = new HashSet<PregledData>();
        }
    
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string PhoneNumber { get; set; }
        public System.DateTime BirthDay { get; set; }
        public string email { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PregledData> PregledDatas { get; set; }
    }
}
