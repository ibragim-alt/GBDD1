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
    
    public partial class licence
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public licence()
        {
            this.Dtp = new HashSet<Dtp>();
        }
    
        public Nullable<int> idDriver { get; set; }
        public Nullable<System.DateTime> licenceDate { get; set; }
        public Nullable<System.DateTime> expireDate { get; set; }
        public string categories { get; set; }
        public string licenceNum { get; set; }
        public string Vidano { get; set; }
        public string City { get; set; }
    
        public virtual Drivers Drivers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dtp> Dtp { get; set; }
    }
}
