using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceCLP.Models
{
    [Table("Insurance")]
    public class InsuranceModel
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
        public float Value { get; set; }
        [ForeignKey("User")]
        public int UserId {  get; set; }
        public virtual UserModel UserModel {  get; set; }

    }
}
