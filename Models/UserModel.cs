using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 

namespace InsuranceCLP.Models
{
    [Table("User")]
    public class UserModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Addres { get; set; }
        public string phone { get; set; }
        [MaxLength(13)]
        public DateTime createdAt { get; set; }

    }
}
