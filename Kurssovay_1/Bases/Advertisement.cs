//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Kurssovay_1.Bases
{
    using System;
    using System.Collections.Generic;
    
    public partial class Advertisement
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Advertisement()
        {
            this.Statements1 = new HashSet<Statements1>();
        }
    
        public int id_advertisement { get; set; }
        public int id_position { get; set; }
        public Nullable<System.DateTime> date_of_application { get; set; }
        public int id_applicant { get; set; }
    
        public virtual Applicant Applicant { get; set; }
        public virtual Positions Positions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Statements1> Statements1 { get; set; }
    }
}
