namespace IndividualProjectPartB.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Assignment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Assignment()
        {
            courses = new HashSet<Course>();
        }

        [Key]
        public int a_id { get; set; }

        [Required]
        [StringLength(50)]
        public string title { get; set; }

        [Required]
        [StringLength(40)]
        public string description { get; set; }

        [Column(TypeName = "date")]
        public DateTime date { get; set; }

        public int? oral_mark { get; set; }

        public int? total_mark { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Course> courses { get; set; }

        public override string ToString()
        {
            return $"Id:{a_id}\tTitle{title}\t{description}\tSubmit Date {date.ToShortDateString()}\t Oral Mark{oral_mark}\tTotal Mark{total_mark} ";
        }
    }
}
