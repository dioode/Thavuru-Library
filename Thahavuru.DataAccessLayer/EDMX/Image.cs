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
    
    public partial class Image
    {
        public int Image_Id { get; set; }
        public int Person_Id { get; set; }
        public string Image_uri { get; set; }
    
        public virtual Person Person { get; set; }
    }
}
