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
    
    public partial class ModelTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ModelTable()
        {
            this.Autopark = new HashSet<Autopark>();
        }
    
        public int modelID { get; set; }
        public string brand { get; set; }
        public string model { get; set; }
        public int typeID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Autopark> Autopark { get; set; }
        public virtual TypeTable TypeTable { get; set; }
    }
}
