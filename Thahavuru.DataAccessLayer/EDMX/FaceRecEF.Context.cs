﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Thahavuru.Techniques.EDMX
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FaceRecEFEntities : DbContext
    {
        public FaceRecEFEntities()
            : base("name=FaceRecEFEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Class_Attrubute> Class_Attrubute { get; set; }
        public DbSet<ClassElementImage> ClassElementImages { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<IndClass> IndClasses { get; set; }
    }
}
