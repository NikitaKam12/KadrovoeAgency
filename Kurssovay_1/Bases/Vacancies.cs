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
    
    public partial class Vacancies
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vacancies()
        {
            this.Statements = new HashSet<Statements>();
        }
    
        public int id_vacancies { get; set; }
        public int exp_required { get; set; }
        public string request { get; set; }
        public int id_position { get; set; }
        public string name_vacancies { get; set; }
        public int id_employer { get; set; }
    
        public virtual Employer Employer { get; set; }
        public virtual Positions Positions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Statements> Statements { get; set; }
    }
}
