using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Covid19Management.Models
{
    [Table("CONGDAN")]
    public class Citizen
    {
        [Key]
        [Column("MaCD", TypeName = "int")]
        public int CitizenCode { get; set; }

        [Required(ErrorMessage = "Name field is required.")]
        [StringLength(255)]
        [Column("HoTen", TypeName = "nvarchar(255)")]
        [RegularExpression(@"^[a-zA-Z0-9,.: -]+$", ErrorMessage = "Name field contains special characters")]
        public string Name { get; set; } = null!;

        [Column("NgaySinh", TypeName = "datetime")]
        [DisplayName("Birthday")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy HH:mm}", ApplyFormatInEditMode = false)]
        [DataType(DataType.DateTime)]
        public DateTime Birthday { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

        [Required(ErrorMessage = "CMND field is required.")]
        [StringLength(9, MinimumLength = 9)]
        [Column("CMND", TypeName = "char(9)")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "CMND field only contains number")]
        public string CMND { get; set; } = null!;

        [Required(ErrorMessage = "Phone number field is required.")]
        [StringLength(15)]
        [Column("SoDienThoai", TypeName = "varchar(15)")]
        [RegularExpression(@"(\+84|84|0)+(3|5|7|8|9|1[2|6|8|9])+([0-9]{8,10})\b", ErrorMessage = "Phone number field only contains number or + character as prefix")]
        public string PhoneNumber { get; set; } = null!;

        [Required(ErrorMessage = "Address field is required.")]
        [StringLength(255)]
        [Column("DiaChi", TypeName = "nvarchar(255)")]
        [RegularExpression(@"^[a-zA-Z0-9,.: -]+$", ErrorMessage = "Address field contains special characters")]
        public string Address { get; set; } = null!;

        [Required(ErrorMessage = "Email field is required.")]
        [StringLength(255)]
        [Column("Email", TypeName = "nvarchar(255)")]
        [EmailAddress]
        public string Email { get; set; } = null!;

        public virtual IList<Vaccination>? Vaccinations { get; set; }
    }
}
