using EmployeeData;

namespace MenuV04
{
    public static class Extension
    {
        public static void print(this Human[] employees)
        {
            for (int i = 0; i < employees.Length; i++) 
            {
                Console.WriteLine($"Employee{i + 1} Info's:\n" +
                                  $"***************** ");
                Console.WriteLine(employees[i]);
            }
        }
    }
}
