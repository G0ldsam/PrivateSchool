using IndividualProjectPartB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace IndividualProjectPartB.Services
{
    class MenuOptionsService
    {
        public void Start()
        {
            Title = "Private School";
            RunMainMenu();

        }
        private void RunMainMenu()
        {
            string promt = @"


██████╗ ██████╗ ██╗██╗   ██╗ █████╗ ████████╗███████╗    ███████╗ ██████╗██╗  ██╗ ██████╗  ██████╗ ██╗     
██╔══██╗██╔══██╗██║██║   ██║██╔══██╗╚══██╔══╝██╔════╝    ██╔════╝██╔════╝██║  ██║██╔═══██╗██╔═══██╗██║     
██████╔╝██████╔╝██║██║   ██║███████║   ██║   █████╗      ███████╗██║     ███████║██║   ██║██║   ██║██║     
██╔═══╝ ██╔══██╗██║╚██╗ ██╔╝██╔══██║   ██║   ██╔══╝      ╚════██║██║     ██╔══██║██║   ██║██║   ██║██║     
██║     ██║  ██║██║ ╚████╔╝ ██║  ██║   ██║   ███████╗    ███████║╚██████╗██║  ██║╚██████╔╝╚██████╔╝███████╗
╚═╝     ╚═╝  ╚═╝╚═╝  ╚═══╝  ╚═╝  ╚═╝   ╚═╝   ╚══════╝    ╚══════╝ ╚═════╝╚═╝  ╚═╝ ╚═════╝  ╚═════╝ ╚══════╝
                                                                                                           
Welcome to Scool.What would you like to do ?";
            string[] options = { "Print", "Insert", "Exit" };
            MenuService mainMenu = new MenuService(promt, options);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    Print();

                    break;
                case 1:
                    Insert();
                    break;
                case 2:
                    ExitGame();
                    break;
            }

        }
        private void ExitGame()
        {
            Console.WriteLine("\n Press any key to exit...");
            ReadKey(true);
            Environment.Exit(0);
        }
        private void Print()
        {
            string prompt = "What do you want to print";
            string[] options = { "List of Students", "List of Trainers", "List of Courses", "List of Assignments","PrintAll","Back" };
            MenuService insertMenu = new MenuService(prompt, options);
            int selectedIndex = insertMenu.Run();
            DataService dataService = new DataService();
            switch (selectedIndex)
            {
                case 0:
                    dataService.PrintData<Student>();
                    Console.WriteLine("Press any key to go back");
                    ReadKey();
                    RunMainMenu();
                    break;
                case 1:
                    dataService.PrintData<Trainer>();
                    Console.WriteLine("Press any key to go back");
                    ReadKey();
                    RunMainMenu();
                    break;
                case 2:
                    dataService.PrintData<Course>();
                    Console.WriteLine("Press any key to go back");
                    ReadKey();
                    RunMainMenu();
                    break;
                case 3:
                    dataService.PrintData<Assignment>();
                    Console.WriteLine("Press any key to go back");
                    ReadKey();
                    RunMainMenu();
                    break;
                case 4:
                    PrintAll();
                    break;
                case 5:
                    RunMainMenu();
                    break;
            }
        }
        private void PrintAll()
        {
            Clear();
            DataService dataService = new DataService();
            dataService.PrintAllData();
            Console.WriteLine("Press any key to go back");
            ReadKey();
            RunMainMenu();

        }
        private void Insert()
        {
            string prompt = "What data you want to insert";
            string[] options = { "Student", "Trainer", "Course", "Assignment","Back"};
            MenuService insertMenu = new MenuService(prompt, options);
            int selectedIndex = insertMenu.Run();
            DataService dataService = new DataService();
            CreateServive createServive = new CreateServive();
            ValidateService validateService = new ValidateService();
            using(School schoolDb= new School())
            {

                bool addToCourse;
                switch (selectedIndex)
                {
                    case 0:
                        var student = createServive.CreateStudent();
                        Console.WriteLine("Do you want to add the student to a course?Y/N");
                        addToCourse = ReadLine().ToLower()=="y";
                        if(addToCourse)
                        {
                            Console.WriteLine("Choose a course from the list:");
                            dataService.PrintData<Course>();
                            int id = validateService.CheckIntInList();
                            dataService.InsertData(student, id);
                            
                        }
                        else
                        {

                            dataService.InsertData<Student>(student);
                            
                        }
                        ReturnMainMenu();
                        break;
                    case 1:
                        var trainer = createServive.createTrainer();
                        Console.WriteLine("Do you want to add the trainer to a course?Y/N");
                        addToCourse = ReadLine().ToLower() == "y";
                        if (addToCourse)
                        {
                            Console.WriteLine("Choose a course from the list:");
                            dataService.PrintData<Course>();
                            int id = validateService.CheckIntInList();
                            dataService.InsertData(trainer, id);
                            
                        }
                        else
                        {
                            dataService.InsertData<Trainer>(trainer);
                        }
                        ReturnMainMenu();
                        break;
                    case 2:
                        dataService.InsertData<Course>(createServive.CreateCourse());
                        ReturnMainMenu();
                        break;
                    case 3:

                        var assignment = createServive.createAssignment();
                        Console.WriteLine("Do you want to add the assignment to a course?Y/N");
                        addToCourse = ReadLine().ToLower() == "y";
                        if (addToCourse)
                        {
                            Console.WriteLine("Choose a course from the list:");
                            dataService.PrintData<Course>();
                            int id = validateService.CheckIntInList();
                            dataService.InsertData(assignment, id);
                            
                        }
                        else
                        {
                            dataService.InsertData<Assignment>(assignment);
                        }
                        ReturnMainMenu();
                        break;
                    case 4:
                        RunMainMenu();
                        break;
                }
            }

            
        }

        private void ReturnMainMenu()
        {
            Console.WriteLine("Press any key to go back");
            ReadKey();
            RunMainMenu();
        }
        

    }
}
