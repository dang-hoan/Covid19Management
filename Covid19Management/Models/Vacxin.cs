using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Covid19Management.Models
{
    [Table("LIEUVACXIN")]
    public class Vacxin
    {
        [Key]
        [Column("MaLieuVX", TypeName = "int")]
        public int VacxinCode { get; set; }

        [Required(ErrorMessage = "Batch number field is required.")]
        [Column("SoLo", TypeName = "int")]
        public int BatchNumber { get; set; }

        public int? VacxinTypeCode { get; set; }

        public virtual VacxinType? VacxinType { get; set; }

        public virtual IList<Vaccination>? Vaccinations { get; set; }

        [Column("NgaySanXuat", TypeName = "datetime")]
        [DisplayName("Manufacturing date")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy HH:mm}", ApplyFormatInEditMode = false)]
        [DataType(DataType.DateTime)]
        public DateTime ManufacturingDate { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

        [Column("NgayNhap", TypeName = "datetime")]
        [DisplayName("Import date")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy HH:mm}", ApplyFormatInEditMode = false)]
        [DataType(DataType.DateTime)]
        public DateTime ImportDate { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

        [Column("NgayHetHan", TypeName = "datetime")]
        [DisplayName("Expire date")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy HH:mm}", ApplyFormatInEditMode = false)]
        [DataType(DataType.DateTime)]
        public DateTime ExpireDate { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
    }
}
