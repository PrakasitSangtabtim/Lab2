using System.ComponentModel.DataAnnotations;//Key
using System.ComponentModel.DataAnnotations.Schema;//Auto Increment

namespace WebApplication1.Models
{
    public class manufacturers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
