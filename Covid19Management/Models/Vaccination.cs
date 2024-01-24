using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Covid19Management.Models
{
    [Table("TIEMCHUNG")]
    public class Vaccination
    {
        [Key]
        [Column("MaTC", TypeName = "int")]
        public int VaccinationCode { get; set; }

        public int? VacxinCode { get; set; }

        public virtual Vacxin? Vacxin { get; set; }

        public int? CitizenCode { get; set; }

        public virtual Citizen? Citizen { get; set; }

        [Column("NgayTiemMui1", TypeName = "datetime")]
        [DisplayName("First inject day")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = false)]
        public DateTime FirstInjectDay { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

        [Column("NgayDKTiemMui2", TypeName = "datetime")]
        [DisplayName("Second inject register day")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy HH:mm}", ApplyFormatInEditMode = false)]
        [DataType(DataType.DateTime)]
        public DateTime SecondInjectRegisterDay { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

        [Column("NgayTiemMui2", TypeName = "datetime")]
        [DisplayName("Second inject day")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy HH:mm}", ApplyFormatInEditMode = false)]
        [DataType(DataType.DateTime)]
        public DateTime SecondInjectDay { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

        [Required(ErrorMessage = "Status is required.")]
        [StringLength(255)]
        [Column("TrangThai", TypeName = "nvarchar(255)")]
        [RegularExpression(@"^[a-zA-Z0-9,.: -]+$", ErrorMessage = "Status field contains special characters")]
        public string Status { get; set; } = null!;

        [Required(ErrorMessage = "Note field is required.")]
        [StringLength(255)]
        [Column("GhiChu", TypeName = "nvarchar(255)")]
        [RegularExpression(@"^[a-zA-Z0-9,.: -]+$", ErrorMessage = "Note field contains special characters")]
        public string Note { get; set; } = null!;
    }
}
