namespace ql_nha_sach.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KHACHHANG")]
    public partial class KHACHHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        /*public KHACHHANG()
        {
            THEMUONs = new HashSet<THEMUON>();
        }*/

        [Key]
        [StringLength(50)]
        public string MaKH { get; set; }

        [Required]
        [StringLength(100)]
        public string Tenkh { get; set; }

        [Required]
        [StringLength(100)]
        public string Diachi { get; set; }

        public int? Sdt { get; set; }

        /*public bool? Giotinh { get; set; }*/

        /*[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<THEMUON> THEMUONs { get; set; }*/
    }
}
