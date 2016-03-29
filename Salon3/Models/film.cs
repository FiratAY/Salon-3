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
    
    public partial class film
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public film()
        {
            this.filmUye = new HashSet<filmUye>();
            this.resim = new HashSet<resim>();
            this.yorum = new HashSet<yorum>();
            this.video = new HashSet<video>();
        }
    
        public int filmID { get; set; }
        public int adminID { get; set; }
        public string ad { get; set; }
        public Nullable<int> begeni { get; set; }
        public string yonetmen { get; set; }
        public string vizyon { get; set; }
        public Nullable<System.DateTime> eklemeTarihi { get; set; }
        public Nullable<decimal> imdb { get; set; }
        public Nullable<int> kategoriID { get; set; }
        public string ozet { get; set; }
    
        public virtual admin admin { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<filmUye> filmUye { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<resim> resim { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<yorum> yorum { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<video> video { get; set; }
        public virtual Kategori Kategori { get; set; }
    }
}
