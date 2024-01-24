using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Covid19Management.Models
{
    [Table("LOAIVACXIN")]
    public class VacxinType
    {
        [Key]
        [Column("MaLoaiVX", TypeName = "int")]
        public int VacxinTypeCode { get; set; }

        [Required(ErrorMessage = "Name field is required.")]
        [StringLength(255)]
        [Column("TenLoaiVX", TypeName = "nvarchar(255)")]
        [RegularExpression(@"^[a-zA-Z0-9,.: -]+$", ErrorMessage = "Name field contains special characters")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Manufacturing country field is required.")]
        [StringLength(255)]
        [Column("NuocSX", TypeName = "nvarchar(255)")]
        [RegularExpression(@"^[a-zA-Z0-9,.: -]+$", ErrorMessage = "Manufacturing country field contains special characters")]
        public string ManufacturingCountry { get; set; } = null!;

        [Required(ErrorMessage = "Inject days number field is required.")]
        [Column("SoNgayTiemNhac", TypeName = "int")]
        public int InjectDaysNumber { get; set; }

        public virtual IList<Vacxin>? Vacxins { get; set; }
    }
}
