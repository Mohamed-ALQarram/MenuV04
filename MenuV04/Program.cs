using EmployeeData;
namespace MenuV04
{
    internal class Program
    {
        static void Main(string[] args) 
        { 
            string[] menu = { "  NEW  ","DISPLAY","SEARCH"," SORT "," EXIT " };
            int highlight = 0;
            bool looping = true;
            int Xaxis = Console.WindowWidth / 2;
            int Yaxis = Console.WindowHeight / (menu.Length + 1);
            //int EmpNo = 0;
            //Human[] Employees = new Employee[EmpNo];
            List<Employee> Employees = new List<Employee>();
            do
            {
            Console.Clear();
            Console.CursorVisible = false;
                for (int i = 0; i<menu.Length; i++)
                {
                    if (i == highlight)
                        Console.BackgroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(Xaxis, (i + 1) * Yaxis);
                    Console.Write(menu[i]);
                    Console.ResetColor();
                }
                Console.WriteLine();
                ConsoleKeyInfo info = Console.ReadKey();
                switch (info.Key)
                {
                    case ConsoleKey.UpArrow:
                        highlight--;
                        if (highlight< 0)
                            highlight = menu.Length - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        highlight++;
                        if (highlight == menu.Length)
                            highlight = 0;
                        break;
                    case ConsoleKey.Home:
                        highlight = 0;
                        break;
                    case ConsoleKey.End:
                        highlight = menu.Length - 1;
                        break;
                    case ConsoleKey.Enter:
                        Console.Clear();
                        switch (highlight)
                        {
                            case 0:
                                //Console.Write("Enter The Number of New Employees: ");
                                //int.TryParse(Console.ReadLine(), out EmpNo);
                                //Employees= new Employee[EmpNo];
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.CursorVisible = true;
                                Console.WriteLine($"\nAdd Data for Employee:\n" +
                                        $"***********************");
                                    Console.WriteLine("Enter Employee Name: ");
                                    string Name = Console.ReadLine() ?? "";

                                    Console.WriteLine("Enter Employee Salary: ");
                                    decimal.TryParse(Console.ReadLine(), out decimal salary);

                                    Console.WriteLine("Enter Employee Age: ");
                                    int.TryParse(Console.ReadLine(), out int age);

                                    Console.WriteLine("Enter Gender (Male || Female): ");
                                    Gender gender;
                                    
                                    if(Enum.TryParse(typeof(Gender),Console.ReadLine(),out object? g))
                                        gender = (Gender)g;
                                    else
                                        gender = 0;
                                    Employees.Add(new Employee(Name,salary, age, gender));
                                    Console.Clear();   
                                
                                break;
                            case 1:
                                if (Employees.Count > 0)
                                {
                                    Console.CursorVisible = false;
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    foreach(var emp in Employees)
                                        emp.print();
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Your List Is Empty.");
                                }
                                Console.ReadKey();
                                Console.ResetColor();
                                break;
                            case 2:
                                if(Employees.Count > 0)
                                {
                                    Console.CursorVisible = true;
                                    Employee? emp;
                                    Console.Write("Enter Employee ID or Name: ");
                                    string input = Console.ReadLine() ?? "";

                                    if(int.TryParse(input,out int ID))
                                        emp=Employees.Find(emp => emp.ID == ID);//lambda expression
                                    else
                                        emp=Employees.Find(emp=> emp.Name == input);
                                    if (emp != null)
                                        emp.print();
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Console.WriteLine("Employee Not Found");
                                        Console.ResetColor();
                                    }
                                    Console.ReadKey();
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Your List Is Empty.");
                                    Console.ReadKey();
                                    Console.ResetColor();
                                }
                                break;
                            case 3:
                                if (Employees.Count > 0)
                                {
                                    Console.CursorVisible = true;
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    Console.WriteLine("1.Sort By ID\n" +
                                        "2.Sort by Age\n" +
                                        "3.Sort By Name\n" +
                                        "4.Sort By Salary\n" +
                                        "5.Exit\n");
                                    Console.WriteLine("Enter Your Choice: ");
                                    char.TryParse(Console.ReadLine(), out char ch);
                                    switch (ch)
                                    {
                                        case '1':
                                            //Array.Sort(Employees, new CompareByID
                                            Employees.Sort(new CompareByID());
                                            break;
                                        case '2':
                                            //    Array.Sort(Employees, new CompareByAge());
                                            //Employees.OrderBy(emp => emp.Age);
                                            Employees.Sort(new CompareByAge());
                                            break;
                                        case '3':
                                            //Array.Sort(Employees, new CompareByName());
                                            //Employees.Sort(new CompareByName());
                                            Console.ForegroundColor= ConsoleColor.Cyan;

                                            Console.WriteLine("\n1.Ascending Sort");
                                            Console.WriteLine("2.Descending Sort");
                                            Console.Write("Enter Your Choice: ");
                                            char.TryParse(Console.ReadLine(), out ch);
                                            switch (ch) 
                                            {
                                                case '1':
                                                    Employees.Sort(delegate (Employee emp1, Employee emp2)
                                                        {
                                                            return emp1.Name.CompareTo(emp2.Name);
                                                        });
                                               
                                            break;
                                                case '2':
                                                    Employees.Sort(delegate (Employee emp1, Employee emp2)
                                                    {
                                                        return emp2.Name.CompareTo(emp1.Name);
                                                    });
                                                    break;
                                                default:
                                                    Console.ForegroundColor=ConsoleColor.Red;
                                                    Console.WriteLine("Enter Valied Number (1 or 2)");
                                                    break;
                                            }
                                            break;
                                        case '4':
                                            Console.ForegroundColor = ConsoleColor.Cyan;
                                            Console.WriteLine("\n1.Ascending Sort");
                                            Console.WriteLine("2.Descending Sort");
                                            Console.Write("\nEnter Your Choice: ");
                                            char.TryParse(Console.ReadLine(), out ch);
                                            switch (ch)
                                            {
                                                case '1':
                                                    Employees.Sort(delegate (Employee emp1, Employee emp2)
                                                    {
                                                        return emp1.Salary.CompareTo(emp2.Salary);
                                                    });
                                                    break;
                                                case '2':
                                                    Employees.Sort(delegate (Employee emp1, Employee emp2)
                                                    {
                                                        return emp2.Salary.CompareTo(emp1.Salary);
                                                    }); break;
                                                default:
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("Enter Valied Number (1 or 2)");
                                                    break;
                                            }

                                            Employees.Sort(delegate (Employee emp1, Employee emp2)
                                            {
                                                return emp1.Salary.CompareTo(emp2.Salary);
                                            });
                                            break;
                                        case '5':
                                            break;
                                    }
                                    Console.Clear (); 
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Sorting done Successfully");
                                    Console.ReadKey();
                                    Console.ResetColor();
                                }
                                else
                                {
                                    Console.ForegroundColor= ConsoleColor.Red; 
                                    Console.WriteLine("Your List Is Empty.");
                                    Console.ReadKey();
                                    Console.ResetColor();
                                }
                                break;
                            case 4:
                                looping = false;
                                break;
                        }
                        break;
                    case ConsoleKey.Escape:
                    looping = false;
                    break;
                }
            }
            while (looping);
            Console.ForegroundColor=ConsoleColor.Cyan;
            Console.WriteLine("\nThank You for using our program");
            Console.ForegroundColor=ConsoleColor.Black;
            Console.CursorVisible = false;

        }
    }
}
