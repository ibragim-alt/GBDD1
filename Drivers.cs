//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfApp2
{
    using System;
    using System.Collections.Generic;
    
    public partial class Drivers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Drivers()
        {
            this.licence = new HashSet<licence>();
        }
    
        public int Id { get; set; }
        public string name { get; set; }
        public string lastname { get; set; }
        public string middlename { get; set; }
        public int passportSerial { get; set; }
        public int passportNumber { get; set; }
        public int postCode { get; set; }
        public string address { get; set; }
        public string addressLife { get; set; }
        public string company { get; set; }
        public string jobname { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string photo { get; set; }
        public string descreption { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<licence> licence { get; set; }
    }
}
