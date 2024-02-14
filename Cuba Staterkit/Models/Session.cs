using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cuba_Staterkit.Models
{
    [Table("SessionTable")]
    public class Session
    {
        [Key]
        public Guid ID { get; set; }
        [Required]
        public string Name { get; set; }
        [ForeignKey(nameof(Subject))]
        public Guid? SubjectID { get; set; }
        public virtual Subject? Subject { get; set; }
    }
}
