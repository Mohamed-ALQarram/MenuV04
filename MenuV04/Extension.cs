using EmployeeData;

namespace MenuV04
{
    public static class Extension
    {
        static int i;
        static Extension() 
        {
        i=1;
        }
        public static void print(this Employee employees)
        {
                Console.WriteLine($"Employee{i++} Info's:\n" +
                                  $"***************** ");
                Console.WriteLine(employees);
        }
    }
}
