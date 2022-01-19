using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndividualProjectPartB.Entities;
using IndividualProjectPartB.Interfaces;

namespace IndividualProjectPartB.Services
{
    class DataService : IDataService
    {
        public void InsertData<T>(object entity)
        {
            using (School database = new School())
            {
                Type tType = typeof(T);
                var add = database.Set(tType);
                add.Add(entity);
                database.SaveChanges();
            }
        }
       

        public void InsertData( Assignment assignment,int id)
        {
            using (School schoolDb = new School())
            {
                schoolDb.assignments.Add(assignment);
                assignment.courses.Add(schoolDb.courses.Find(id));
                schoolDb.SaveChanges();
            }
        }

        public void InsertData(Student student, int id)
        {
            using (School schoolDb = new School())
            {
                schoolDb.students.Add(student);
                student.courses.Add(schoolDb.courses.Single(x => x.course_id == id));
                schoolDb.SaveChanges();
            }
        }
        public void InsertData(Trainer trainer, int id)
        {
            using (School schoolDb = new School())
            {
                schoolDb.trainers.Add(trainer);
                trainer.courses.Add(schoolDb.courses.Single(x => x.course_id == id));
                schoolDb.SaveChanges();
            }
        }
        
        
        
        
        public void PrintAllData()
        {
            using (School schoolDb = new School())
            {
                PrintData<Student>();
                PrintData<Trainer>();
                PrintData<Assignment>();
                PrintData<Course>();
                printStudentsPerCourse();
                printTrainersPerCourse();
                printAssignmentPerCourse();
                printStudentPerAssignment();
                Console.WriteLine("------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("List of students that belongs to more than one courses:");
                Console.WriteLine(string.Join("\n", schoolDb.students.Where(x => x.courses.Count() > 1).Select(x => "\t" + x.first_name + " " + x.last_name)));
                Console.WriteLine("------------------------------------------------------------------------------------------------------------");


            }
        }
        public void printAssignmentPerCourse()
        {
            using (School schoolDb = new School())
            {
                Console.WriteLine("------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("List of Assignments per Course:");
                foreach (var course in schoolDb.courses)
                    Console.WriteLine(course.title + " " + course.stream + " " + course.type + "\n" + string.Join("\n", course.assignments.Select(y => "\t" + y.a_id + " " + y.title + " " + y.description)));
                Console.WriteLine("------------------------------------------------------------------------------------------------------------");
            }
        }
        public void printStudentPerAssignment()
        {
            using (School schoolDb = new School())
            {
                Console.WriteLine("------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("List of Student per Course per Assignment");

                foreach (var item in schoolDb.students)
                {
                    Console.WriteLine(item.student_id + " :" + item.first_name + " " + item.last_name);
                    foreach (var item2 in item.courses)
                    {
                        Console.WriteLine("\n\t" + item2.stream + " " + item2.type+":" + "\n\t\t" + string.Join("\n\t\t", item2.assignments.Select(a => a.title + a.description)));
                    }
                }
                Console.WriteLine("------------------------------------------------------------------------------------------------------------");
            }
        }
        public void printStudentsPerCourse()
        {
            using (School schoolDb = new School())
            {
                Console.WriteLine("------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("List of Students per Course:");
                foreach (var course in schoolDb.courses)
                    Console.WriteLine(course.title+ " "+course.stream + " "+course.type+"\n" + string.Join("\n", course.students.Select(y => "\t" + y.student_id + " " + y.first_name + " " + y.last_name)));
                Console.WriteLine("------------------------------------------------------------------------------------------------------------");
            }
        }
        public void printTrainersPerCourse()
        {
            using(School schoolDb = new School())
            {
                Console.WriteLine("------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("List of Trainers per Course:");

                foreach (var course in schoolDb.courses)
                    Console.WriteLine(course.title + " " + course.stream + " " + course.type + "\n" + string.Join("\n", course.trainers.Select(y => "\t" + y.trainer_id + " " + y.first_name + " " + y.last_name)));

                Console.WriteLine("------------------------------------------------------------------------------------------------------------");
            }
        }
        public void PrintData2<T,K>()
        {
            using (School db = new School())
            {
                Type tType = typeof(T);
                var types = db.Set(tType);

                foreach (var data in types)
                {
                    Console.WriteLine($"{data}");
                    PrintData<K>();
                }
                //var constructor = types.GetType().GetConstructors()[0];
                //var properties = types.GetType().GetProperties().Length;
                //var parameters = constructor.GetParameters();
                //Console.WriteLine(parameters is HashSet<Course>);
                //foreach (var item in parameters)
                //{
                //    Console.WriteLine(item.ParameterType is ICollection<Course>);

                //}
            }
        }
        public void PrintData<T>()
        {
            using (School db = new School())
            {
                Type tType = typeof(T);
                var types = db.Set(tType);
                Console.WriteLine("------------------------------------------------------------------------------------------------------------");
                Console.WriteLine($"List of {tType.Name}s");
                foreach (var data in types)
                {
                    Console.WriteLine($"\t{data}");
                }
                Console.WriteLine("-------------------------------------------------------------------------------------------------------------");
               
            }
        }
        

        

       
    }
}
