using System.ComponentModel.DataAnnotations;

namespace Talent.Data.Models
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string TagName { get; set; }
        //[JsonIgnore]
        //public virtual Post Post { get; set; }
    }
}
