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
    
    public partial class IndClass
    {
        public IndClass()
        {
            this.ClassElementImages = new HashSet<ClassElementImage>();
        }
    
        public int ClassId { get; set; }
        public int Class_Attrubute_Id { get; set; }
        public Nullable<int> ClassNumber { get; set; }
        public Nullable<double> ValueRangeUpperBound { get; set; }
        public Nullable<double> ValueRangeLowerBound { get; set; }
        public string Name { get; set; }
        public Nullable<bool> HasClassElements { get; set; }
    
        public virtual Class_Attrubute Class_Attrubute { get; set; }
        public virtual ICollection<ClassElementImage> ClassElementImages { get; set; }
    }
}