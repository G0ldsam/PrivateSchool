using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using IndividualProjectPartB.Entities;
using IndividualProjectPartB.Services;

namespace IndividualProjectPartB
{
    class Program
    {
        static void Main(string[] args)
        {

            
            //dataService.PrintData<Assignment>();
            //dataService.PrintData<Student>();
            //dataService.PrintData<Course>();
            //dataService.PrintData<Trainer>();
            //dataService.printStudentsPerCourse();
            
            //dataService.PrintAllData();
            MenuOptionsService menu = new MenuOptionsService();
            menu.Start();
                










                //var obj = string.Join("\n",schoolDb.courses.Select(c=> 
                //new { 
                //    Student= c.students.Select(s=>s.first_name).ToList(),
                //    Course= c.stream,
                //    Assignments = c.assignments.Select(a=>a.title).ToList()
                //}));

                //Student student1 = new Student()
                //{
                //    first_name = "Aimilios",
                //    last_name = "Aimiliopoulos",
                //    birth_date = new DateTime(1993,10,10),
                //    tuition_fees = 2500
                //};

                //schoolDb.students.Add(student1);
                ////schoolDb.students.Attach(student1);
                //student1.courses.Add(schoolDb.courses.Single(x => x.course_id == 1));
                //schoolDb.SaveChanges();

                //Assignment assignment1 = new Assignment()
                //{
                //    description = "Descr213",
                //    date = new DateTime(1993, 10, 10),
                //    title = "SuperAssignment",

                //};
                








                //foreach (var item in schoolDb.courses.Select(s => s))
                //{
                //    Console.WriteLine(item);
                //    Console.WriteLine(string.Join("\n", item.students));
                //    Console.WriteLine(string.Join("\n", item.assignments));
                //}


                //Console.WriteLine(string.Join("\n", schoolDb.assignments.GroupBy(a => a).Select(x => x.Key)));
            
        }

        
    }
}
