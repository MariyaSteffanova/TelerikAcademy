namespace WikiMusic.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Artist
    {
        private ICollection<Album> albums;

        public Artist()
        {
            this.albums = new HashSet<Album>();
        }

        [Key]
        public int ID { get; set; }

        [MinLength(3)]
        [MaxLength(40)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        [MaxLength(30)]
        public string Country { get; set; }

        public string ImgLink { get; set; }

        public DateTime BirthDate { get; set; }

        public virtual ICollection<Album> Albums
        {
            get { return this.albums; }
            set { this.albums = value; }
        }
    }
}
