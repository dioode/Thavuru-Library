﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Thahavuru.Techniques.DataAccess.EFModel
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FaceRecEntities : DbContext
    {
        public FaceRecEntities()
            : base("name=FaceRecEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Class> Classes { get; set; }
        public DbSet<Class_Attrubute> Class_Attrubute { get; set; }
        public DbSet<ClassElementImage> ClassElementImages { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
    }
}
