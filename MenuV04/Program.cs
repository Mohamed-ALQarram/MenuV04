using EmployeeData;
namespace MenuV04
{
    internal class Program
    {
        static void Main(string[] args) 
        { 
            string[] menu = { "  NEW  ","DISPLAY"," SORT "," EXIT " };
            int highlight = 0;
            bool looping = true;
            int Xaxis = Console.WindowWidth / 2;
            int Yaxis = Console.WindowHeight / (menu.Length + 1);
            int EmpNo = 3;
            Human[] Employees = new Employee[0];
            do
            {
                Console.Clear();
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
                                Console.Write("Enter The Number of New Employees: ");
                                int.TryParse(Console.ReadLine(), out EmpNo);
                                Employees= new Employee[EmpNo];
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                for (int i = 0; i<Employees.Length; i++)
                                {
                                    Console.WriteLine($"\nAdd Data for Employee{i+1}:\n" +
                                        $"***********************");
                                    Console.WriteLine("Enter Employee Name: ");
                                    string Name = Console.ReadLine() ?? "";

                                    Console.WriteLine("Enter Employee Salary: ");
                                    decimal.TryParse(Console.ReadLine(), out decimal salary);

                                    Console.WriteLine("Enter Employee Age: ");
                                    int.TryParse(Console.ReadLine(), out int age);

                                    Console.WriteLine("Enter Gender (Male || Female): ");
                                    Gender gender = (Gender)Enum.Parse(typeof(Gender), Console.ReadLine() ?? "Male");

                                    Employees[i] = new Employee(Name,salary, age, gender);
                                    Console.Clear();   
                                }
                                break;
                            case 1:
                                if (Employees.Length > 0)
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Employees.print();
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
                                if (Employees.Length > 0)
                                {
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    Console.WriteLine("1.Sort By ID\n" +
                                        "2.Sort by Age\n" +
                                        "3.Sort By Name\n" +
                                        "4.Exit\n");
                                    Console.WriteLine("Enter Your Choice: ");
                                    char.TryParse(Console.ReadLine(), out char ch);
                                    switch (ch)
                                    {
                                        case '1':
                                            Array.Sort(Employees, new CompareByID());
                                            break;
                                        case '2':
                                            Array.Sort(Employees, new CompareByAge());
                                            break;
                                        case '3':
                                            Array.Sort(Employees, new CompareByName());
                                            break;
                                        case '4':
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
                            case 3:
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
        }
    }
}
