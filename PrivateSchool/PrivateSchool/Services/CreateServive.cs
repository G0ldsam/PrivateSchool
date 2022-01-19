using IndividualProjectPartB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProjectPartB.Services
{
    class CreateServive
    {
        ValidateService ValidateService = new ValidateService();
        public Student CreateStudent()
        {
            Student student = new Student()
            {
                first_name = ValidateService.GetOnlyString("First Name", 3),
                last_name = ValidateService.GetOnlyString("Last Name", 5),
                birth_date = ValidateService.CheckDate("Birth Date"),
                tuition_fees = ValidateService.GetInt("Tuition", 2000, 2500)
            };
            return student;
        }

        public Course CreateCourse()
        {
            Course course = new Course()
            {
                title = ValidateService.GetString("Course title", 2),
                stream = ValidateService.CheckStream(),
                type = ValidateService.CheckType(),
                start_date = ValidateService.CheckDate("Start Date "),
                end_date = ValidateService.CheckDate("End Date")
                
                

            };

            return course;
        }

        public Assignment createAssignment()
        {
            Assignment assignment = new Assignment()
            {
                title = ValidateService.GetString("Title", 2),
                description = ValidateService.GetString("Description", 5),
                date = ValidateService.CheckDate("Submit Date"),
                oral_mark = ValidateService.GetInt("Oral Mark", 1, 100),
                total_mark = ValidateService.GetInt("Total Mark",1,100)
                
                
            };
            return assignment;
        }

        public Trainer createTrainer()
        {
            Trainer trainer = new Trainer()
            {
                first_name = ValidateService.GetOnlyString("First Name", 3),
                last_name = ValidateService.GetOnlyString("Last Name", 5),
                subject = ValidateService.GetOnlyString("Subject",3)
            };
            return trainer;
        }
    }
}
