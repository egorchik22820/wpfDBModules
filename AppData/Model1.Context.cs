﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace wpfDBModules.AppData
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class wpfDBEntities1 : DbContext
    {
        public wpfDBEntities1()
            : base("name=wpfDBEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Authors> Authors { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<CookingSteps> CookingSteps { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Ingredients> Ingredients { get; set; }
        public virtual DbSet<RecipeIngredients> RecipeIngredients { get; set; }
        public virtual DbSet<Recipes> Recipes { get; set; }
        public virtual DbSet<RecipeTags> RecipeTags { get; set; }
        public virtual DbSet<Reviews> Reviews { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Tags> Tags { get; set; }
    }
}
