using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web.Caching;

namespace ql_nha_sach.Models
{    public partial class Model1 : DbContext
    {
        /*Đây là constructor của lớp Model1.
        Nó gọi constructor của lớp cơ sở(DbContext) với tham số "name=Model13",
        chỉ định tên của chuỗi kết nối được định nghĩa trong tệp cấu hình của ứng dụng
        (thường là web.config hoặc app.config).*/
        public Model1()
            : base("name=Model13")
        {
        }

        public virtual DbSet<KHACHHANG> KHACHHANGs { get; set; }
        public virtual DbSet<LOAISACH> LOAISACHes { get; set; }
        public virtual DbSet<SACH> SACHes { get; set; }
        public virtual DbSet<TAIKHOAN> TAIKHOANs { get; set; }
        /* public virtual DbSet<THEMUON> THEMUONs { get; set; }*/
        public virtual DbSet<LichSuNhapSach> LichSuNhapSaches { get; set; } // Thêm dòng này
        /*Những dòng này định nghĩa các thuộc tính kiểu DbSet<T>.
            *Một DbSet đại diện cho một tập hợp các thực thể có thể được truy vấn
            *từ cơ sở dữ liệu và có thể được cập nhật.
            KHACHHANGs, LOAISACHes, SACHes, TAIKHOANs, và LichSuNhapSaches 
        đại diện cho các bảng khác nhau trong cơ sở dữ liệu.*/


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            /* Cấu hình thực thể LOAISACH.*/
            modelBuilder.Entity<LOAISACH>()
                .HasMany(e => e.SACHes)
                .WithOptional(e => e.LOAISACH)
                .WillCascadeOnDelete();/*'WillCascadeOnDelete' đảm bảo rằng nếu một LOAISACH bị xóa,
                                        * các SACH liên quan cũng sẽ bị xóa theo.*/


            modelBuilder.Entity<TAIKHOAN>()
                .Property(e => e.Matkhau)
                .IsFixedLength()
                .IsUnicode(false);


        }
    }
}
