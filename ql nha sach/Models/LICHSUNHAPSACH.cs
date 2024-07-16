using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ql_nha_sach.Models
{
    [Table("LichSuNhapSach")]
    public partial class LichSuNhapSach /*khai báo một lớp partial tên là LichSuNhapSach*/
    {
        [Key] /*chỉ ra rằng thuộc tính Id là khóa chính của bảng.*/
        public int Id { get; set; }

        [Required] /*chỉ ra rằng MaSach là bắt buộc phải có giá trị.*/
        [StringLength(20)] /*giới hạn độ dài tối đa của chuỗi là 20 ký tự.*/
        public string MaSach { get; set; }

        public DateTime NgayNhap { get; set; }

        public int SoLuongNhap { get; set; }

        [ForeignKey("MaSach")] /*chỉ ra rằng thuộc tính SACH là khóa ngoại liên kết với thuộc tính MaSach.*/
        public virtual SACH SACH { get; set; }
    }
}
