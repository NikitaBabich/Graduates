//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Graduates
{
    using System;
    using System.Collections.Generic;
    
    public partial class Storage_objects
    {
        public int Id { get; set; }
        public Nullable<int> Id_storage_object { get; set; }
        public Nullable<int> Id_student { get; set; }
        public Nullable<int> Id_teacher { get; set; }
    
        public virtual Student Student { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual Type_storage_object Type_storage_object { get; set; }
    }
}
