//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Salon3.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class video
    {
        public int videoID { get; set; }
        public Nullable<int> filmID { get; set; }
        public string yol { get; set; }
        public string ad { get; set; }
    
        public virtual film film { get; set; }
    }
}
