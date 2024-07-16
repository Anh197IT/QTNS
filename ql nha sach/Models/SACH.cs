namespace ql_nha_sach.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SACH")]
    public partial class SACH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        /*public SACH()
        {
            THEMUONs = new HashSet<THEMUON>();
        }*/

        [Key]
        [StringLength(20)]
        public string MaSach { get; set; }

        [Required]
        [StringLength(30)]
        public string Tensach { get; set; }

        /*[StringLength(100)]
        public string Anhbia { get; set; }*/

        [StringLength(30)]
        public string Tentacgia { get; set; }

        [StringLength(30)]
        public string NXB { get; set; }

        public DateTime? Ngaynhap { get; set; }

        public int? Soluongnhap { get; set; }
        public double? Giaban { get; set; }

        [StringLength(20)]
        public string Maloai { get; set; }

        public virtual LOAISACH LOAISACH { get; set; }

        /*[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<THEMUON> THEMUONs { get; set; }*/
    }
}
