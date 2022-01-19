namespace IndividualProjectPartB.Entities
{
    
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Globalization;

    public partial class Student : Human
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Student()
        {
            courses = new HashSet<Course>();
        }

        [Key]
        public int student_id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? birth_date { get; set; }

        [Column(TypeName = "money")]
        public decimal? tuition_fees { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Course> courses { get; set; }

        public override string ToString()
        {
            return $"{student_id}:{first_name} {last_name}\t\tBirthDate{birth_date.Value.ToString("dd MM yyyy", CultureInfo.CreateSpecificCulture("el-GR"))}\tTuition: {tuition_fees.Value.ToString("C")} ";
        }
    }
}
