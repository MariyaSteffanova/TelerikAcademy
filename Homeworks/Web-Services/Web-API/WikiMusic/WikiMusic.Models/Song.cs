namespace WikiMusic.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Song
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(30)]
        [Required]
        public string Title { get; set; }

        public short Year { get; set; }

        [MaxLength(20)]
        public string Genre { get; set; }

        public virtual Artist Artist { get; set; }

        public virtual Album Album { get; set; }
    }
}
