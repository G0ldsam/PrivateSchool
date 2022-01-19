namespace IndividualProjectPartB.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Trainer : Human
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Trainer()
        {
            courses = new HashSet<Course>();
        }

        [Key]
        public int trainer_id { get; set; }

        
      

        [Required]
        [StringLength(50)]
        public string subject { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Course> courses { get; set; }


        public override string ToString()
        {
            return $"{trainer_id}: {first_name} {last_name}\t {subject}";
        }
    }
}
