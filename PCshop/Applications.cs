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
    
    public partial class Applications
    {
        public int Application { get; set; }
        public Nullable<int> IDUsers { get; set; }
        public int IDArticle { get; set; }
        public int IDStatus { get; set; }
    
        public virtual Tovar Tovar { get; set; }
        public virtual Users Users { get; set; }
    }
}
