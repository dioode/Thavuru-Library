//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Thahavuru.DataAccessLayer.EDMX
{
    using System;
    using System.Collections.Generic;
    
    public partial class PersonalFeatureSet
    {
        public int FeatureId { get; set; }
        public int Person_Id { get; set; }
        public int IndClass_ClassId { get; set; }
    
        public virtual IndClass IndClass { get; set; }
        public virtual Person Person { get; set; }
    }
}
