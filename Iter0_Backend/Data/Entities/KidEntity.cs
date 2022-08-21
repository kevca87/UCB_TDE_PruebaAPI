using System.ComponentModel.DataAnnotations;

namespace Iter0_Backend.Data.Entities
{
    public class KidEntity
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string CI { get; set; }
    }
}
