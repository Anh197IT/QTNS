namespace ql_nha_sach.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TAIKHOAN")]
    public partial class TAIKHOAN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
       /* public TAIKHOAN()
        {
            THEMUONs = new HashSet<THEMUON>();
        }*/

        [Key]
        [StringLength(50)]
        [Required(ErrorMessage ="Ten dang nhap")]
        [Display(Name = "UserName")]
        public string TenTK { get; set; }

        [StringLength(50)]

        [Required(ErrorMessage = "mat khau")]
        [Display(Name ="Password")]
        [DataType(DataType.Password)]
        public string Matkhau { get; set; }

        [Required(ErrorMessage = "nhap lai mat khau")]
        [Display(Name = "RePassword")]
        [DataType(DataType.Password)]
        [NotMapped]
        [Compare("Matkhau",ErrorMessage ="nhap lai mat khau sai")]
        public string NhapLaiMatKhau { get; set; }

        /*[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<THEMUON> THEMUONs { get; set; }*/
    }
}
