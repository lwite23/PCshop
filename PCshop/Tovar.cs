//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PCshop
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    
    public partial class Tovar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tovar()
        {
            this.Applications = new HashSet<Applications>();
        }
    
        public int Article { get; set; }
        public string image { get; set; }
        public string TovarName { get; set; }
        public string Warranty { get; set; }
        public string Description { get; set; }
        public Nullable<int> Price { get; set; }
        public Nullable<int> Availability { get; set; }
        public Nullable<int> IDCategories { get; set; }
        public Nullable<int> IDProvider { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public string correctimage
        {
            get
            {
                string path = Path.Combine(Directory.GetParent(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName)).FullName, @"Images\");
                if (String.IsNullOrEmpty(image) || String.IsNullOrWhiteSpace(image) || image == null)
                {
                    return path + "iconpc.png";
                }
                else
                {
                    return path + image;
                }
            }
        }

        public virtual ICollection<Applications> Applications { get; set; }
        public virtual Categories Categories { get; set; }
        public virtual Provider Provider { get; set; }
    }
}
