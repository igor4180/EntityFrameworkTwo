//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntityFrameworkTwo
{
    using System;
    using System.Collections.Generic;
    
    public partial class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category()
        { }
        public Category(int id, string name)
		{
            Id = id;
            Name = name;
            
		}
		public override string ToString()
		{
			return Id.ToString() + " " + Name;
		}
	}
}
