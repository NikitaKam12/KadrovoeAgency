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
    
    public partial class Statements1
    {
        public int id_statement1 { get; set; }
        public int id_advertisement { get; set; }
        public string login_1 { get; set; }
        public int id_status { get; set; }
    
        public virtual Advertisement Advertisement { get; set; }
        public virtual Status_ Status_ { get; set; }
    }
}
