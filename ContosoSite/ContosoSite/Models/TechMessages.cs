//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ContosoSite.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TechMessages
    {
        public int rentID { get; set; }
        public System.DateTime start { get; set; }
        public string description { get; set; }
    
        public virtual Rents Rents { get; set; }
    }
}
